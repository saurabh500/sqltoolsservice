//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

using System.Collections.Generic;
using Microsoft.SqlTools.ServiceLayer.Connection;
using Microsoft.SqlTools.ServiceLayer.Extensibility;
using Microsoft.SqlTools.ServiceLayer.ObjectExplorer;

namespace Microsoft.SqlTools.ServiceLayer.Test.ObjectExplorer
{
    // Base class providing common test functionality for OE tests
    public abstract class ObjectExplorerTestBase
    {
        protected RegisteredServiceProvider ServiceProvider
        {
            get;
            set;
        }

        protected RegisteredServiceProvider CreateServiceProviderWithMinServices()
        {
            return CreateProvider()
                .RegisterSingleService(new ConnectionService())
                .RegisterSingleService(new ObjectExplorerService());
        }

        protected RegisteredServiceProvider CreateProvider()
        {
            ServiceProvider = new RegisteredServiceProvider();
            return ServiceProvider;
        }
        
        protected ObjectExplorerService CreateOEService(ConnectionService connService)
        {
            CreateProvider()
                .RegisterSingleService(connService)
                .RegisterSingleService(new ObjectExplorerService());

            // Create the service using the service provider, which will initialize dependencies
            return ServiceProvider.GetService<ObjectExplorerService>();
        }

    }
}
