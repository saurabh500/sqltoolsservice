//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

using Microsoft.SqlServer.Management.Smo;

namespace Microsoft.SqlTools.ServiceLayer.ObjectExplorer.SmoModel
{
    /// <summary>
    /// Context object containing key properties needed to query for SMO objects
    /// </summary>
    public class SmoQueryContext
    {
        /// <summary>
        /// Creates a context object with a server to use as the basis for any queries
        /// </summary>
        /// <param name="server"></param>
        public SmoQueryContext(Server server)
        {
            Server = server;
        }

        /// <summary>
        /// The server SMO will query against
        /// </summary>
        public Server Server { get; private set; }

        /// <summary>
        /// Optional Database context object to query against
        /// </summary>
        public Database Database { get; set; }

        /// <summary>
        /// Parent of a give node to use for queries
        /// </summary>
        public SmoObjectBase Parent { get; set; }
    }
}
