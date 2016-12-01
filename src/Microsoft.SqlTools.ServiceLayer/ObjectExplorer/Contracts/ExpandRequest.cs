using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.SqlTools.ServiceLayer.Hosting.Protocol.Contracts;

namespace Microsoft.SqlTools.ServiceLayer.ObjectExplorer.Contracts
{
    /// <summary>
    /// Parameters to the <see cref="ExpandRequest"/>.
    /// </summary>
    public class ExpandParams
    {
        /// <summary>
        /// The Id returned from a <see cref="CreateSessionRequest"/>. This
        /// is used to disambiguate between different trees. 
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// Path identifying the node to expand. See <see cref="NodeInfo.NodePath"/> for details
        /// </summary>
        public NodeInfo[] NodePath { get; set; }
    }

    /// <summary>
    /// A request to expand a 
    /// </summary>
    public class ExpandRequest
    {
        /// <summary>
        /// Returns children of a given node as a <see cref="NodeInfo"/> array.
        /// </summary>
        public static readonly
            RequestType<ExpandParams, NodeInfo[]> Type =
            RequestType<ExpandParams, NodeInfo[]>.Create("objectexplorer/expand");
    }
}
