using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Microsoft.WCF.Documentation
{
    public class OperationCachingAttribute : Attribute, IOperationBehavior
    {
        bool isCacheable;

        public OperationCachingAttribute()
            : this(true)
        {
        }

        public OperationCachingAttribute(bool isCacheable)
        {
            this.isCacheable = isCacheable;
        }

        public bool IsCacheable
        {
            get { return isCacheable; }
        }


        #region IOperationBehavior Members

        public void AddBindingParameters(OperationDescription description, BindingParameterCollection parameters)
        {
          return;
        }

        public void ApplyClientBehavior(OperationDescription description, ClientOperation proxy)
        {
          return;
        }

        public void ApplyDispatchBehavior(OperationDescription description, DispatchOperation dispatch)
        {
          dispatch.Invoker = new OperationCachingInvoker(dispatch.Action, dispatch.Invoker);
        }

        public void Validate(OperationDescription description)
        {
          return;
        }

        #endregion
      }
}
