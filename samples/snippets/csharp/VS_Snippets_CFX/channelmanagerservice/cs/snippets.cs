using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.ServiceModel.Description;
using System.Collections.Specialized;
using System.ServiceModel.Channels;

namespace ChannelManagerServiceSnippets
{
    class snippets : ServiceHostBase
    {
        void Container0()
        {
            //ChannelManagerService.ChannelManagerService
            WorkflowRuntime workflowRuntime = new WorkflowRuntime();
            //<snippet0>
            // Add ChannelManager.
            ChannelManagerService channelmgr = new ChannelManagerService();
            workflowRuntime.AddService(channelmgr);
            //</snippet0>
        }
        void Container1()
        {
            string contextFileName;
            WorkflowRuntime workflowRuntime = new WorkflowRuntime();
            LocalServiceHost localServiceHost = null;
            String contextFileExtension = null;
            //ChannelManagerService.ChannelManagerService(IList)
            //<snippet1>
            contextFileName = localServiceHost.Description.ServiceType.Name + contextFileExtension;

            // add local client endpoints
            workflowRuntime = this.Description.Behaviors.Find<WorkflowRuntimeBehavior>().WorkflowRuntime;
            workflowRuntime.AddService(new ChannelManagerService(localServiceHost.ClientEndpoints));

            localServiceHost.Open();
            
            //</snippet1>
        }
        void Container2()
        {
            //ChannelManagerService.ChannelManagerService(NameValueCollection)
            //<snippet2>
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("idleTimeout", TimeSpan.FromMinutes(10).ToString());
            parameters.Add("leaseTimeout", TimeSpan.FromMinutes(1).ToString());
            parameters.Add("maxIdleChannelsPerEndpoint", "10");
            ChannelManagerService service = new ChannelManagerService(parameters);
            //</snippet2>
        }
        void Container3()
        {
            //ChannelManagerService.ChannelManagerService(ChannelPoolSettings)
            //<snippet3>
            ChannelPoolSettings settings = new ChannelPoolSettings();
            settings.IdleTimeout = TimeSpan.FromMinutes(10);
            settings.LeaseTimeout = TimeSpan.FromMinutes(1);
            settings.MaxOutboundChannelsPerEndpoint = 10;
            ChannelManagerService service = new ChannelManagerService(settings);
            //</snippet3>
        }
        void Container4()
        {
            //ChannelManagerService.ChannelManagerService(ChannelPoolSettings, Ilist)
            ContractDescription contractDescription = null;
            //<snippet4>
            ChannelPoolSettings settings = new ChannelPoolSettings();
            settings.IdleTimeout = TimeSpan.FromMinutes(10);
            settings.LeaseTimeout = TimeSpan.FromMinutes(1);
            settings.MaxOutboundChannelsPerEndpoint = 10;
            IList<ServiceEndpoint> endpoints = new List<ServiceEndpoint>();
            endpoints.Add(new ServiceEndpoint(contractDescription));
            ChannelManagerService service = new ChannelManagerService(settings, endpoints);
            //</snippet4>
        }

        class LocalServiceHost : ServiceHost
        {
            public LocalServiceHost(object singletonInstance, params Uri[] baseAddresses)
                : base(singletonInstance, baseAddresses)
            {
            }

            IList<ServiceEndpoint> clientEndpoints = null;
            internal IList<ServiceEndpoint> ClientEndpoints
            {
                get { return clientEndpoints; }
            }
        }


        protected override ServiceDescription CreateDescription(out IDictionary<string, ContractDescription> implementedContracts)
        {
            throw new NotImplementedException();
        }
    }
}
