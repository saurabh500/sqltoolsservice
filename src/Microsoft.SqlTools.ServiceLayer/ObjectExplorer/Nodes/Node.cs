//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

using Microsoft.SqlTools.ServiceLayer.ObjectExplorer.Contracts;

namespace Microsoft.SqlTools.ServiceLayer.ObjectExplorer.Nodes
{
    /// <summary>
    /// Base class for elements in the object explorer tree. Provides common methods for tree navigation
    /// and other core functionality
    /// </summary>
    public abstract class Node : NodeInfo
    {

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
                NodePath = this.NodePath,
                NodeType = this.NodeType
            };
        }
    }
}
