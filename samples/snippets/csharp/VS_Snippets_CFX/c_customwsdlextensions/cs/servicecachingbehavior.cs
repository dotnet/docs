using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Microsoft.WCF.Documentation
{
    public class ServiceCachingBehavior : IServiceBehavior
    {
      public ServiceCachingBehavior()
      {
        Console.WriteLine("Caching behavior running.");
      }

        public void AddBindingParameters(ServiceDescription description, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection parameters)
        {
          return;
        }

        public void ApplyDispatchBehavior(ServiceDescription description, ServiceHostBase serviceHostBase)
        {
            serviceHostBase.Extensions.Add(new OperationCache());
        }

        public void Validate(ServiceDescription description, ServiceHostBase serviceHostBase)
        {
          return;
        }
      }

	class OperationCache : IOperationCache, IExtension<ServiceHostBase>
	{
		Dictionary<OperationCacheKey, OperationCacheValue> cache;

		public OperationCache()
		{
			this.cache = new Dictionary<OperationCacheKey, OperationCacheValue>();
      Console.WriteLine("Caching extension running.");
		}

		#region IOperationCache Implementation

		public void Insert(OperationCacheKey key, OperationCacheValue value)
		{
			this.cache.Add(key, value);
		}

		public OperationCacheValue Lookup(OperationCacheKey key)
		{
			OperationCacheValue value;

			if (!this.cache.TryGetValue(key, out value))
			{
				return null;
			}

			return value;
		}

		public void Remove(OperationCacheKey key)
		{
			this.cache.Remove(key);
		}

		#endregion

		#region IExtension<ServiceHost> Implementation

		void IExtension<ServiceHostBase>.Attach(ServiceHostBase owner) { }

		void IExtension<ServiceHostBase>.Detach(ServiceHostBase owner) { }

		#endregion
	}
}
