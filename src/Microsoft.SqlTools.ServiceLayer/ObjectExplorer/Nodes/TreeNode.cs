//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.SqlTools.ServiceLayer.ObjectExplorer.Contracts;
using Microsoft.SqlTools.ServiceLayer.Utility;

namespace Microsoft.SqlTools.ServiceLayer.ObjectExplorer.Nodes
{
    /// <summary>
    /// Base class for elements in the object explorer tree. Provides common methods for tree navigation
    /// and other core functionality
    /// </summary>
    public class TreeNode
    {
        private List<TreeNode> children = new List<TreeNode>();
        private TreeNode parent;
        private string[] nodePath;
        private string label;
        
        /// <summary>
        /// Constructor that accepts a label to identify the node
        /// </summary>
        /// <param name="value">Label identifying the node</param>
        public TreeNode(string value)
        {
            // We intentionally do not valid this being null or empty since
            // some nodes may need to set it 
            NodeValue = value;

        }

        /// <summary>
        /// Value describing this node
        /// </summary>
        public string NodeValue { get; set; }

        /// <summary>
        /// The type of the node - for example Server, Database, Folder, Table
        /// </summary>
        public string NodeType { get; set; }

        /// <summary>
        /// Label to display to the user, describing this node.
        /// If not explicitly set this will fall back to the <see cref="NodeValue"/> but
        /// for many nodes such as the server, the display label will be different
        /// to the value.
        /// </summary>
        public string Label {
            get
            {
                if(label == null)
                {
                    return NodeValue;
                }
                return label;
            }
            set
            {
                label = value;
            }
        }

        /// <summary>
        /// Is this a leaf node (in which case no children can be generated) or
        /// is it expandable?
        /// </summary>
        public bool IsLeaf { get; set; }

        /// <summary>
        /// Parent of this node
        /// </summary>
        public TreeNode Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
                // Reset the node path since it's no longer valid
                nodePath = null;
            }
        }
        
        /// <summary>
        /// Path identifying this node: for example a table will be at ["server", "database", "tables", "tableName"].
        /// This enables rapid navigation of the tree without the need for a global registry of elements.
        /// The path functions as a unique ID and is used to disambiguate the node when sending requests for expansion.
        /// A common ID is needed since processes do not share address space and need a unique identifier
        /// </summary>
        public string[] GetNodePath()
        {
            if (nodePath == null)
            {
                GenerateNodePath();
            }
            return nodePath;
        }

        private void GenerateNodePath()
        {
            LinkedList<string> path = new LinkedList<string>();
            ObjectExplorerUtils.VisitChildAndParents(this, node =>
            {
                if (string.IsNullOrEmpty(node.NodeValue))
                {
                    // Hit a node with no NodeValue. This indicates we need to stop traversing
                    return false;
                }
                // Otherwise add this value to the beginning of the path and keep iterating up
                path.AddFirst(node.NodeValue);
                return true;
            });
            nodePath = path.ToArray();
        }

        /// <summary>
        /// Converts to a <see cref="NodeInfo"/> object for serialization with just the relevant properties 
        /// needed to identify the node
        /// </summary>
        /// <returns></returns>
        public NodeInfo ToNodeInfo()
        {
            return new NodeInfo()
            {
                IsLeaf = this.IsLeaf,
                Label = this.Label,
                NodePath = this.GetNodePath(),
                NodeType = this.NodeType
            };
        }

        /// <summary>
        /// Gets a readonly view of the children for this node. 
        /// Since the tree needs to keep track of parent relationships, directly 
        /// adding to the list is not supported
        /// </summary>
        /// <returns><see cref="IList{TreeNode}"/> containing all children for this node</returns>
        public IList<TreeNode> GetChildren()
        {
            return children.AsReadOnly();
        }

        /// <summary>
        /// Adds a child to the list of children under this node
        /// </summary>
        /// <param name="newChild"><see cref="TreeNode"/></param>
        public void AddChild(TreeNode newChild)
        {
            Validate.IsNotNull(nameof(newChild), newChild);
            children.Add(newChild);
            newChild.Parent = this;
        }


        
    }
}
