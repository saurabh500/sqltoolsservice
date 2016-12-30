//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

using System;
using System.Composition;
using System.Linq;
using System.Reflection;
using Microsoft.SqlTools.ServiceLayer.Extensibility;
using Microsoft.SqlTools.ServiceLayer.ObjectExplorer.SmoModel;
using Xunit;

namespace Microsoft.SqlTools.ServiceLayer.Test.Extensibility
{
    public class ExtensionTests
    {

        [Fact]
        public void CreateAssemblyStoreShouldFindTypesInAssembly()
        {
            // Given a store for MyExportType
            ExtensionStore store = ExtensionStore.CreateAssemblyStore<MyExportType>(GetType().GetTypeInfo().Assembly);
            // Then should get any export for this type and subtypes
            Assert.Equal(2, store.GetExports<MyExportType>().Count());

            // But for a different type, expect throw as the store only contains MyExportType
            Assert.Throws<InvalidCastException>(() => store.GetExports<MyOtherType>().Count());
        }


        [Fact]
        public void CreateDefaultLoaderShouldOnlyFindTypesInMainAssembly()
        {
            // Given a store created using CreateDefaultLoader
            // Then should not find exports from a different assembly
            ExtensionStore store = ExtensionStore.CreateDefaultLoader<MyExportType>();
            Assert.Equal(0, store.GetExports<MyExportType>().Count());

            // But should find exports that are defined in the main assembly
            store = ExtensionStore.CreateDefaultLoader<SmoQuerier>();
            Assert.NotEmpty(store.GetExports<SmoQuerier>());
        }

        [Fact]
        public void CreateStoreForCurrentDirectoryShouldFindExportsInDirectory()
        {
            // Given stores created for types in different assemblies
            ExtensionStore myStore = ExtensionStore.CreateStoreForCurrentDirectory<MyExportType>();
            ExtensionStore querierStore = ExtensionStore.CreateStoreForCurrentDirectory<SmoQuerier>();

            // When I query exports
            // Then exports for all assemblies should be found
            Assert.Equal(2, myStore.GetExports<MyExportType>().Count());
            Assert.NotEmpty(querierStore.GetExports<SmoQuerier>());
        }
    }

    // Note: in order for the MEF lookup to succeed, one class must have 
    [Export(typeof(MyExportType))]
    public class MyExportType
    {

    }
    
    public class MyExportSubType : MyExportType
    {

    }

    public class MyOtherType
    {

    }
}

