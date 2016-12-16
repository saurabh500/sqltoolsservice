//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

using System;
using System.Collections.Generic;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlTools.ServiceLayer.ObjectExplorer.Nodes;

namespace Microsoft.SqlTools.ServiceLayer.ObjectExplorer.SmoModel
{
    public class SmoChildFactoryBase : ChildFactory
    {
        public override IEnumerable<string> ApplicableParents()
        {
            return null;
        }


        public override IEnumerable<TreeNode> Expand(TreeNode parent)
        {
            //parent.BeginChildrenInit();
            try
            {
                List<TreeNode> allChildren = new List<TreeNode>();
                OnExpandPopulateFolders(allChildren, parent);
                RemoveFoldersFromInvalidSqlServerVersions(allChildren, parent);
                OnExpandPopulateNonFolders(allChildren, parent);
                OnBeginAsyncOperations(parent);
                return allChildren;
            }
            finally
            {
                //parent.EndChildrenInit();
            }
        }
        
        /// <summary>
        /// Populates any folders for a given parent node 
        /// </summary>
        /// <param name="allChildren">List to which nodes should be added</param>
        /// <param name="parent">Parent the nodes are being added to</param>
        protected virtual void OnExpandPopulateFolders(IList<TreeNode> allChildren, TreeNode parent)
        {
        }

        /// <summary>
        /// Populates any non-folder nodes such as specific items in the tree.
        /// </summary>
        /// <param name="allChildren">List to which nodes should be added</param>
        /// <param name="parent">Parent the nodes are being added to</param>
        protected virtual void OnExpandPopulateNonFolders(IList<TreeNode> allChildren, TreeNode parent)
        {
        }

        /// <summary>
        /// Filters out invalid folders if they cannot be displayed for the current server version
        /// </summary>
        /// <param name="allChildren">List to which nodes should be added</param>
        /// <param name="parent">Parent the nodes are being added to</param>
        protected virtual void RemoveFoldersFromInvalidSqlServerVersions(IList<TreeNode> allChildren, TreeNode parent)
        {
        }

        // TODO Assess whether async operations node is required
        protected virtual void OnBeginAsyncOperations(TreeNode parent)
        {
        }

        public override bool CanCreateChild(TreeNode parent, object context)
        {
            return false;
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            throw new NotImplementedException();
        }

        protected virtual void InitializeChild(TreeNode child, object context)
        {
            NamedSmoObject smoObj = (NamedSmoObject) context;

            SmoTreeNode childAsMeItem = (SmoTreeNode)child;
            childAsMeItem.CacheInfoFromModel(smoObj);
        }

        internal virtual Type[] TypesToReverse { 
            get
            {
                return null;
            }
        }
    }
}
