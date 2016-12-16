//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

using System;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlTools.ServiceLayer.ObjectExplorer.Nodes;

namespace Microsoft.SqlTools.ServiceLayer.ObjectExplorer.SmoModel
{
    /// <summary>
    /// A Node in the tree representing a 
    /// </summary>
    public class SmoTreeNode : TreeNode
    {
        public static int FolderSortPriority = 0;
        private static int _nextSortPriority = FolderSortPriority + 1; // 0 is reserved for folders

        public SmoTreeNode() : base()
        {
        }
        protected virtual void OnInitialize()
        {
            // TODO setup initialization
        }


        /// <summary>
        /// Sort Priority to help when ordering elements in the tree
        /// </summary>
        public int? SortPriority { get; set; }

        /// <summary>
        /// Is this a system (MSShipped) object?
        /// </summary>
        public bool IsMsShippedOwned { get; set; }

        /// <summary>
        /// Indicates which platforms a node is valid for
        /// </summary>
        public ValidForFlag ValidFor { get; set; }

        /// <summary>
        /// A SMO URN can be used to identify an element and retrieve it in the future, e.g. to query
        /// its children.
        /// </summary>
        public string Urn { get; private set; }

        public static int NextSortPriority
        {
            get
            {
                return System.Threading.Interlocked.Increment(ref _nextSortPriority);
            }
        }

        public virtual void CacheInfoFromModel(NamedSmoObject smoObject)
        {
            NodeValue = smoObject.Name;
            Urn = smoObject.Urn;
        }
    }
}
