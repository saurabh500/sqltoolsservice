//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

using System;
using System.Collections.Generic;
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
            Assert.False(node.IsAlwaysLeaf, "Server node should never be a leaf");
            Assert.Equal(defaultConnectionSummary.ServerName, node.NodeValue);

            string expectedLabel = defaultConnectionSummary.ServerName + " (SQL Server " + defaultServerInfo.ServerVersion + " - "
                + defaultConnectionSummary.UserName + ")";
            Assert.Equal(expectedLabel, node.Label);

            Assert.Equal(NodeTypes.ServerInstance.ToString(), node.NodeType);
            string[] nodePath = node.GetNodePath();
            Assert.Equal(1, nodePath.Length);
            Assert.Equal(defaultConnectionSummary.ServerName, nodePath[0]);
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
                + defaultConnectionSummary.UserName + ", " + defaultConnectionSummary.DatabaseName + ")";
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
            Assert.Equal(node.IsAlwaysLeaf, info.IsLeaf);
            Assert.Equal(node.Label, info.Label);
            Assert.Equal(node.NodeType, info.NodeType);
            string[] nodePath = node.GetNodePath();
            Assert.Equal(nodePath.Length, info.NodePath.Length);
            for (int i = 0; i < nodePath.Length; i++)
            {
                Assert.Equal(nodePath[i], info.NodePath[i]);
            }
        }

        [Fact]
        public void AddChildShouldSetParent()
        {
            TreeNode parent = new TreeNode("parent");
            TreeNode child = new TreeNode("child");
            Assert.Null(child.Parent);
            parent.AddChild(child);
            Assert.Equal(parent, child.Parent);
        }
        
        [Fact]
        public void GetChildrenShouldReturnReadonlyList()
        {
            TreeNode node = new TreeNode("parent");
            IList<TreeNode> children = node.GetChildren();
            Assert.Throws<NotSupportedException>(() => children.Add(new TreeNode("child")));
        }

        [Fact]
        public void GetChildrenShouldReturnAddedNodesInOrder()
        {
            TreeNode parent = new TreeNode("parent");
            TreeNode[] expectedKids = new TreeNode[] { new TreeNode("1"), new TreeNode("2") };
            foreach (TreeNode child in expectedKids)
            {
                parent.AddChild(child);
            }
            IList<TreeNode> children = parent.GetChildren();
            Assert.Equal(expectedKids.Length, children.Count);
            for (int i = 0; i < expectedKids.Length; i++)
            {
                Assert.Equal(expectedKids[i], children[i]);
            }
        }

        public void MultiLevelTreeShouldFormatPath()
        {
            TreeNode root = new TreeNode("root");
            Assert.Equal(new [] { "root" }, root.GetNodePath());

            TreeNode level1Child1 = new TreeNode("L1C1");
            TreeNode level1Child2 = new TreeNode("L1C2");
            root.AddChild(level1Child1);
            root.AddChild(level1Child2);
            Assert.Equal(new[] { "root", "L1C1" }, level1Child1.GetNodePath());
            Assert.Equal(new[] { "root", "L1C2" }, level1Child2.GetNodePath());

            TreeNode level2Child1 = new TreeNode("L2C2");
            level1Child1.AddChild(level2Child1);
            Assert.Equal(new[] { "root", "L1C1", "L2C2" }, level2Child1.GetNodePath());
        }
        
    }
}
