//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.SqlTools.ServiceLayer.Utility;

namespace Microsoft.SqlTools.ServiceLayer.Extensibility
{

    /// <summary>
    /// A service provider implementation that allows registering of specific services
    /// </summary>
    public class RegisteredServiceProvider : ServiceProviderBase
    {
        public delegate IEnumerable ServiceLookup();

        protected Dictionary<Type, ServiceLookup> services = new Dictionary<Type, ServiceLookup>();

        /// <summary>
        /// Registers a singular service to be returned during lookup
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>this provider, to simplify fluent declarations</returns>
        /// <exception cref="ArgumentNullException">If service is null</exception>
        /// <exception cref="InvalidOperationException">If an existing service is already registered</exception>
        public RegisteredServiceProvider RegisterSingleService<T>(T service)
        {
            Validate.IsNotNull(nameof(service), service);
            ThrowIfAlreadyRegistered<T>();
            services.Add(typeof(T), () => service.SingleItemAsEnumerable());
            return this;
        }

        /// <summary>
        /// Registers a function that can look up multiple services
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>this provider, to simplify fluent declarations</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceLookup"/> is null</exception>
        /// <exception cref="InvalidOperationException">If an existing service is already registered</exception>
        public RegisteredServiceProvider Register<T>(Func<IEnumerable<T>> serviceLookup)
        {
            Validate.IsNotNull(nameof(serviceLookup), serviceLookup);
            ThrowIfAlreadyRegistered<T>();
            services.Add(typeof(T), () => serviceLookup());
            return this;
        }

        private void ThrowIfAlreadyRegistered<T>()
        {
            if (services.ContainsKey(typeof(T)))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, SR.ServiceAlreadyRegistered, nameof(T)));
            }
        }

        protected override IEnumerable<T> GetServicesImpl<T>()
        {
            ServiceLookup serviceLookup;
            if (services.TryGetValue(typeof(T), out serviceLookup))
            {
                return serviceLookup().Cast<T>();
            }
            return Enumerable.Empty<T>();
        }
    }
}
