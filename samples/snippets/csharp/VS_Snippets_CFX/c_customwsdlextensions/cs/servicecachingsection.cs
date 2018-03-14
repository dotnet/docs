using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Configuration;

namespace Microsoft.WCF.Documentation
{
    public class ServiceCachingElement : BehaviorExtensionElement
    {
        const string serviceCachingSectionName = "serviceCaching";

		protected override object CreateBehavior()
        {
            return new ServiceCachingBehavior();
        }

        public override Type BehaviorType
        {
          get { return typeof(ServiceCachingBehavior); }
        }
      }
}

