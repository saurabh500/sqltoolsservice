//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.SqlTools.ServiceLayer.Hosting.Protocol;

namespace Microsoft.SqlTools.ServiceLayer.Hosting
{
    /// <summary>
    /// Defines a hosted service that communicates with external processes via
    /// messages passed over the <see cref="ServiceHost"/>. The service defines
    /// a standard initialization method where it can hook up to the host.
    /// </summary>
    interface IHostedService 
    {
        /// <summary>
        /// Callback to initialize this service
        /// </summary>
        /// <param name="serviceHost"><see cref="IProtocolEndpoint"/> which supports registering
        /// event handlers and other callbacks for messages passed to external callers</param>
        void InitializeService(IProtocolEndpoint serviceHost);
    }
}
