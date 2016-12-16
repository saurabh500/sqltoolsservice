//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

using System;
using System.Globalization;
using Microsoft.SqlTools.ServiceLayer.Connection.Contracts;
using Microsoft.SqlTools.ServiceLayer.Utility;

namespace Microsoft.SqlTools.ServiceLayer.ObjectExplorer.Nodes
{
    /// <summary>
    /// Server node implementation with support for 
    /// </summary>
    public class ServerNode : TreeNode
    {
        private ConnectionSummary connectionSummary;
        private ServerInfo serverInfo;

        public ServerNode(ConnectionSummary connectionSummary, ServerInfo serverInfo)
            : base()
        {
            Validate.IsNotNull(nameof(connectionSummary), connectionSummary);
            Validate.IsNotNull(nameof(serverInfo), serverInfo);

            this.connectionSummary = connectionSummary;
            this.serverInfo = serverInfo;
            NodeValue = connectionSummary.ServerName;
            IsAlwaysLeaf = false;
            NodeType = NodeTypes.ServerInstance.ToString();
            Label = GetConnectionLabel();
        }
        
        /// <summary>
        /// Returns the label to display to the user.
        /// </summary>
        internal string GetConnectionLabel()
        {
            string userName = connectionSummary.UserName;

            // TODO Domain and username is not yet supported on .Net Core. 
            // Consider passing as an input from the extension where this can be queried
            //if (string.IsNullOrWhiteSpace(userName))
            //{
            //    userName = Environment.UserDomainName + @"\" + Environment.UserName;
            //}

            // TODO Consider adding IsAuthenticatingDatabaseMaster check in the code and
            // referencing result here
            if (!string.IsNullOrWhiteSpace(connectionSummary.DatabaseName) &&
                string.Compare(connectionSummary.DatabaseName, CommonConstants.MasterDatabaseName, StringComparison.OrdinalIgnoreCase) != 0 &&
                (serverInfo.IsCloud /* || !ci.IsAuthenticatingDatabaseMaster */))
            {
                // We either have an azure with a database specified or a Denali database using a contained user
                userName += ", " + connectionSummary.DatabaseName;
            }

            string label;
            if (string.IsNullOrWhiteSpace(userName))
            {
                label = string.Format(
                CultureInfo.InvariantCulture,
                "{0} ({1} {2})",
                connectionSummary.ServerName,
                "SQL Server",
                serverInfo.ServerVersion);
            }
            else
            {
                label = string.Format(
                CultureInfo.InvariantCulture,
                "{0} ({1} {2} - {3})",
                connectionSummary.ServerName,
                "SQL Server",
                serverInfo.ServerVersion,
                userName);
            }

            return label;
        }
    }
}
