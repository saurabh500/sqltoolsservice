//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

using System;
using Microsoft.SqlTools.ServiceLayer.Connection.Contracts;
using Microsoft.SqlTools.ServiceLayer.ObjectExplorer;
using Microsoft.SqlTools.ServiceLayer.ObjectExplorer.Contracts;
using Microsoft.SqlTools.ServiceLayer.ObjectExplorer.Nodes;
using Microsoft.SqlTools.Test.Utility;
using Xunit;

namespace Microsoft.SqlTools.ServiceLayer.Test.ObjectExplorer
{
    /// <summary>
    /// Tests covering basic operation of Node based classes
    /// </summary>
    public class NodeTests
    {
        private ServerInfo defaultServerInfo;
        private ConnectionSummary defaultConnectionSummary;
        public NodeTests()
        {
            defaultServerInfo = TestObjects.GetTestServerInfo();

            defaultConnectionSummary = new ConnectionSummary()
            {
                DatabaseName = "master",
                ServerName = "localhost",
                UserName = "serverAdmin"
            };
        }

        [Fact]
        public void ServerNodeConstructorValidatesFields()
        {
            Assert.Throws<ArgumentNullException>(() => new ServerNode(null, defaultServerInfo));
            Assert.Throws<ArgumentNullException>(() => new ServerNode(defaultConnectionSummary, null));
        }

        [Fact]
        public void ServerNodeConstructorShouldSetValuesCorrectly()
        {
            // Given a server node with valid inputs
            ServerNode node = new ServerNode(defaultConnectionSummary, defaultServerInfo);
            // Then expect all fields set correctly
            Assert.False(node.IsLeaf, "Server node should never be a leaf");
            
            string expectedLabel = defaultConnectionSummary.ServerName + " (SQL Server " + defaultServerInfo.ServerVersion + " - " 
                + defaultConnectionSummary.UserName + ")";
            Assert.Equal(expectedLabel, node.Label);

            Assert.Equal(NodeTypes.Server.ToString(), node.NodeType);

            Assert.Equal(1, node.NodePath.Length);
            Assert.Equal(defaultConnectionSummary.ServerName, node.NodePath[0]);
        }

        [Fact]
        public void ServerNodeLabelShouldIgnoreUserNameIfEmptyOrNull()
        {
            // Given no username set
            ConnectionSummary integratedAuthSummary = new ConnectionSummary()
            {
                DatabaseName = defaultConnectionSummary.DatabaseName,
                ServerName = defaultConnectionSummary.ServerName,
                UserName = null
            };
            // When querying label
            string label = new ServerNode(integratedAuthSummary, defaultServerInfo).Label;
            // Then only server name and version shown
            string expectedLabel = defaultConnectionSummary.ServerName + " (SQL Server " + defaultServerInfo.ServerVersion + ")";
            Assert.Equal(expectedLabel, label);
        }

        [Fact]
        public void ServerNodeConstructorShouldShowDbNameForCloud()
        {
            defaultServerInfo.IsCloud = true;

            // Given a server node for a cloud DB, with master name
            ServerNode node = new ServerNode(defaultConnectionSummary, defaultServerInfo);
            // Then expect label to not include db name
            string expectedLabel = defaultConnectionSummary.ServerName + " (SQL Server " + defaultServerInfo.ServerVersion + " - "
                + defaultConnectionSummary.UserName + ")";
            Assert.Equal(expectedLabel, node.Label);

            // But given a server node for a cloud DB that's not master
            defaultConnectionSummary.DatabaseName = "NotMaster";
            node = new ServerNode(defaultConnectionSummary, defaultServerInfo);

            // Then expect label to include db name 
            expectedLabel = defaultConnectionSummary.ServerName + " (SQL Server " + defaultServerInfo.ServerVersion + " - "
                + defaultConnectionSummary.UserName + ", "+defaultConnectionSummary.DatabaseName + ")";
            Assert.Equal(expectedLabel, node.Label);
        }
        
        [Fact]
        public void ToNodeInfoIncludeAllFields()
        {
            // Given a server connection
            ServerNode node = new ServerNode(defaultConnectionSummary, defaultServerInfo);
            // When converting to NodeInfo
            NodeInfo info = node.ToNodeInfo();
            // Then all fields should match

        }
    }
}
