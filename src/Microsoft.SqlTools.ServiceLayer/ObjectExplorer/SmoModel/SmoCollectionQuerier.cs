//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

using System;
using System.Collections.Generic;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Broker;

namespace Microsoft.SqlTools.ServiceLayer.ObjectExplorer.SmoModel
{
    /// <summary>
    /// Supports querying the Smo model. 
    /// </summary>
    public abstract class SmoCollectionQuerier
    {
        public abstract IEnumerable<SqlSmoObject> Query(SmoQueryContext context);
    }
    
}
