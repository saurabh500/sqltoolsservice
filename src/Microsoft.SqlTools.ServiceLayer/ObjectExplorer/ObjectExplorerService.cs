//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.SqlTools.ServiceLayer.Connection;
using Microsoft.SqlTools.ServiceLayer.Connection.Contracts;
using Microsoft.SqlTools.ServiceLayer.Hosting.Protocol;
using Microsoft.SqlTools.ServiceLayer.ObjectExplorer.Contracts;
using Microsoft.SqlTools.ServiceLayer.ObjectExplorer.Nodes;
using Microsoft.SqlTools.ServiceLayer.Utility;

namespace Microsoft.SqlTools.ServiceLayer.ObjectExplorer
{
    /// <summary>
    /// A Service to support querying server and database information as an Object Explorer tree.
    /// The APIs used for this are modeled closely on the VSCode TreeExplorerNodeProvider API.
    /// </summary>
    public class ObjectExplorerService
    {
        internal const string uriPrefix = "objectexplorer://";

        private static readonly Lazy<ObjectExplorerService> instance = new Lazy<ObjectExplorerService>(() => new ObjectExplorerService());
        
        // Instance of the connection service, used to get the connection info for a given owner URI
        private ConnectionService connectionService;
        private IProtocolEndpoint serviceHost;
        private Dictionary<string, ObjectExplorerSession> sessionMap;

        /// <summary>
        /// Singleton instance of the Object Explorer service
        /// </summary>
        public static ObjectExplorerService Instance
        {
            get { return instance.Value; }
        }

        /// <summary>
        /// Singleton constructor
        /// </summary>
        private ObjectExplorerService()
            : this(ConnectionService.Instance)
        {
        }

        /// <summary>
        /// Internal for testing only
        /// </summary>
        internal ObjectExplorerService(ConnectionService connService)
        {
            connectionService = connService;
            sessionMap = new Dictionary<string, ObjectExplorerSession>();
        }
        
        /// <summary>
        /// Initializes the service with the service host and registers request handlers.
        /// </summary>
        /// <param name="serviceHost">The service host instance to register with</param>
        public void InitializeService(IProtocolEndpoint serviceHost)
        {
            this.serviceHost = serviceHost;
            // Register handlers for requests
            serviceHost.SetRequestHandler(CreateSessionRequest.Type, HandleCreateSessionRequest);
            serviceHost.SetRequestHandler(ExpandRequest.Type, HandleExpandRequest);
        }
        
        internal async Task HandleCreateSessionRequest(ConnectionDetails connectionDetails, RequestContext<CreateSessionResponse> context)
        {
            Logger.Write(LogLevel.Verbose, "HandleCreateSessionRequest");
            Func<Task<CreateSessionResponse>> doCreateSession = async () =>
            {
                Validate.IsNotNull(nameof(connectionDetails), connectionDetails);
                Validate.IsNotNull(nameof(context), context);

                string uri = GenerateUri(connectionDetails);

                ObjectExplorerSession session;
                if (!sessionMap.TryGetValue(uri, out session))
                {
                    // Establish a connection to the specified server/database
                    session = await DoCreateSession(connectionDetails, context, uri, session);
                }

                CreateSessionResponse response;
                if (session == null)
                {
                    response = new CreateSessionResponse() { Success = false };
                }
                else
                {
                    // Else we have a session available, response with existing session information
                    response = new CreateSessionResponse()
                    {
                        Success = true,
                        RootNode = session.Root.ToNodeInfo(),
                        SessionId = session.Uri
                    };
                }
                return response;
            };

            await HandleRequestAsync(doCreateSession, context, "HandleCreateSessionRequest");
        }

        /// <summary>
        /// Establishes a new session and stores its information
        /// </summary>
        /// <returns><see cref="ObjectExplorerSession"/> object if successful, null if unsuccessful</returns>
        private async Task<ObjectExplorerSession> DoCreateSession(ConnectionDetails connectionDetails, RequestContext<CreateSessionResponse> context, string uri, ObjectExplorerSession session)
        {
            ConnectParams connectParams = new ConnectParams() { OwnerUri = uri, Connection = connectionDetails };

            ConnectionCompleteParams connectionResult = await Connect(connectParams);
            if (connectionResult == null)
            {
                return null;
            }

            session = ObjectExplorerSession.CreateSession(connectionResult);
            sessionMap[uri] = session;
            return session;
        }
        

        private async Task<ConnectionCompleteParams> Connect(ConnectParams connectParams)
        {
            try
            {
                // open connection based on request details
                ConnectionCompleteParams result = await connectionService.Connect(connectParams);
                return result;
            }
            catch (Exception ex)
            {
                // Send a connection failed error message in this case.
                ConnectionCompleteParams result = new ConnectionCompleteParams()
                {
                    Messages = ex.ToString()
                };
                await serviceHost.SendEvent(ConnectionCompleteNotification.Type, result);
                return null;
            }
        }

        internal async Task HandleExpandRequest(ExpandParams expandParams, RequestContext<NodeInfo[]> context)
        {
            throw new NotImplementedException();
        }
        
        private async Task HandleRequestAsync<T>(Func<Task<T>> handler, RequestContext<T> requestContext, string requestType)
        {
            Logger.Write(LogLevel.Verbose, requestType);

            try
            {
                T result = await handler();
                await requestContext.SendResult(result);
            }
            catch (Exception ex)
            {
                await requestContext.SendError(ex.ToString());
            }
        }

        /// <summary>
        /// Generates a URI for object explorer using a similar pattern to Mongo DB (which has URI-based database definition)
        /// as this should ensure uniqueness
        /// </summary>
        /// <param name="details"></param>
        /// <returns>string representing a URI</returns>
        /// <remarks>Internal for testing purposes only</remarks>
        internal static string GenerateUri(ConnectionDetails details)
        {
            Validate.IsNotNull("details", details);
            string uri = string.Format(CultureInfo.InvariantCulture, "{0}{1}", uriPrefix, Uri.EscapeUriString(details.ServerName));
            uri = AppendIfExists(uri, "databaseName", details.DatabaseName);
            uri = AppendIfExists(uri, "user", details.UserName);
            return uri;
        }

        private static string AppendIfExists(string uri, string propertyName, string propertyValue)
        {
            if (!string.IsNullOrEmpty(propertyValue))
            {
                uri += string.Format(CultureInfo.InvariantCulture, ";{0}={1}", propertyName, Uri.EscapeUriString(propertyValue));
            }
            return uri;
        }

        internal class ObjectExplorerSession
        {
            // TODO decide whether a cache is needed to handle lookups in elements with a large # children
            //private const int Cachesize = 10000;
            //private Cache<string, NodeMapping> cache;

            public ObjectExplorerSession(string uri, TreeNode root)
            {
                Validate.IsNotNullOrEmptyString("uri", uri);
                Validate.IsNotNull("root", root);
                Uri = uri;
                Root = root;
            }
            
            public string Uri { get; private set; }
            public TreeNode Root { get; private set; }

            public static ObjectExplorerSession CreateSession(ConnectionCompleteParams response)
            {
                TreeNode serverNode = new ServerNode(response.ConnectionSummary, response.ServerInfo);
                return new ObjectExplorerSession(response.OwnerUri, serverNode);
            }
            
        }
    }

}
