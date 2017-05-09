using System;
using System.Workflow.Activities;
using System.Workflow.ComponentModel;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;



namespace SendActivitySnippets
{
    class snippets
    {
        void Container0()
        {
            ChannelToken channelToken1 = new ChannelToken();
            SendActivity RequestQuoteFromShipper3 = new SendActivity();
            ActivityBind activityBind2 = new ActivityBind();
            ActivityBind activityBind3 = new ActivityBind();
            ActivityBind activityBind4 = new ActivityBind();
            WorkflowParameterBinding workflowParameterBinding2 = new WorkflowParameterBinding();
            WorkflowParameterBinding workflowParameterBinding3 = new WorkflowParameterBinding();
            WorkflowParameterBinding workflowParameterBinding4 = new WorkflowParameterBinding();

            //SendActivity.ParameterBindings
            //<snippet0>
            channelToken1.EndpointName = "Shipper3Endpoint";
            channelToken1.Name = "Shipper3Endpoint";
            channelToken1.OwnerActivityName = "GetShippingQuotes";
            RequestQuoteFromShipper3.ChannelToken = channelToken1;
            RequestQuoteFromShipper3.Name = "RequestQuoteFromShipper3";
            activityBind2.Name = "SupplierWorkflow";
            activityBind2.Path = "order";
            workflowParameterBinding2.ParameterName = "po";
            workflowParameterBinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activityBind2)));
            activityBind3.Name = "SupplierWorkflow";
            activityBind3.Path = "contextShipper3";
            workflowParameterBinding3.ParameterName = "context";
            workflowParameterBinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activityBind3)));
            activityBind4.Name = "SupplierWorkflow";
            activityBind4.Path = "ackShipper3";
            workflowParameterBinding4.ParameterName = "(ReturnValue)";
            workflowParameterBinding4.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activityBind4)));
            RequestQuoteFromShipper3.ParameterBindings.Add(workflowParameterBinding2);
            RequestQuoteFromShipper3.ParameterBindings.Add(workflowParameterBinding3);
            RequestQuoteFromShipper3.ParameterBindings.Add(workflowParameterBinding4);
            //</snippet0>
        }
        void Container1()
        {
            //SendActivity.ServiceOperationInfo
            //<snippet1>
            SendActivity RequestQuoteFromShipper3 = new SendActivity();
            TypedOperationInfo typedOperationInfo2 = new TypedOperationInfo();
            typedOperationInfo2.ContractType = typeof(IShippingRequest);
            typedOperationInfo2.Name = "RequestShippingQuote";
            RequestQuoteFromShipper3.ServiceOperationInfo = typedOperationInfo2;
            //</snippet1>
        }
        interface IShippingRequest { }
        //SendActivity.AfterResponse
        //<snippet2>
        [System.Diagnostics.DebuggerNonUserCode]
        private void InitializeComponent()
        {
            SendActivity sendActivity1 = new SendActivity();
            sendActivity1.AfterResponse += new EventHandler<SendActivityEventArgs>(sendActivity1_AfterResponse);
        }

        void sendActivity1_AfterResponse(object sender, SendActivityEventArgs e)
        {
            Console.WriteLine("SendActivity1 AfterResponse event fired.");
        }
            
        //</snippet2>
    }
    class Snippets2
    {
        

        //SendActivity.BeforeSend
        //<snippet3>
        [System.Diagnostics.DebuggerNonUserCode]
        private void InitializeComponent()
        {
            SendActivity sendActivity1 = new SendActivity();
            sendActivity1.BeforeSend += new EventHandler<SendActivityEventArgs>(sendActivity1_BeforeSend);
        }

        void sendActivity1_BeforeSend(object sender, SendActivityEventArgs e)
        {
            Console.WriteLine("SendActivity1 BeforeSend event fired.");
        }

        void sendActivity1_AfterResponse(object sender, SendActivityEventArgs e)
        {
            Console.WriteLine("SendActivity1 AfterResponse event fired.");
        }
        //</snippet3>

        void Container6()
        {
            //SendActivity.ReturnValuePropertyName
            //<snippet6>
            String retValName = SendActivity.ReturnValuePropertyName;
            //</snippet6>
        }
        void Container7()
        {
            //SendActivity.ChannelToken
            //<snippet7>
            ChannelToken channelToken1 = new ChannelToken();
            SendActivity requestQuoteFromShipper3 = new SendActivity();
            channelToken1.EndpointName = "Shipper3Endpoint";
            channelToken1.Name = "Shipper3Endpoint";
            channelToken1.OwnerActivityName = "GetShippingQuotes";
            requestQuoteFromShipper3.ChannelToken = channelToken1;
            //</snippet7>
        }


        //SendActivity.Context
        //<snippet8>
        static public void ApplyContext(SendActivity activity, IDictionary<string, string> context)
        {
            if (activity.ExecutionStatus == ActivityExecutionStatus.Initialized)
            {
                activity.Context = context;
            }
        }
        //</snippet8>


        //SendActivity.CustomAddress
        static string contextHeaderName = "";
        static string contextHeaderNamespace = "";

        //<snippet9>
        static public void ApplyEndpointAddress(SendActivity activity, EndpointAddress epr)
        {
            if (activity.ExecutionStatus == ActivityExecutionStatus.Initialized)
            {
                if (epr.Uri != null)
                {
                    activity.CustomAddress = epr.Uri.ToString();
                }
                if (epr.Headers != null && epr.Headers.Count > 0)
                {
                    AddressHeader contextHeader = epr.Headers.FindHeader(contextHeaderName, contextHeaderNamespace);
                    IDictionary<string, string> context = contextHeader.GetValue<Dictionary<string, string>>();
                    activity.Context = context;
                }
            }
        }
        //</snippet9>

        void Container10()
        {
            //SendActivity.GetContext()
            //<snippet10>

            //</snippet10>
        }
        void Container12()
        {
            //SendActivity.GetContext(Activity, ChannelToken, Type)
            Type contractType = typeof(string);
            //<snippet12>
            SendActivity sendActivity1 = new SendActivity();
            ChannelToken channelToken1 = new ChannelToken();
            sendActivity1.ChannelToken = channelToken1;
            Dictionary<String, String> Context = (Dictionary<String, String>)SendActivity.GetContext(sendActivity1, channelToken1, contractType);
            //</snippet12>
        }
        
        void Container15()
        {
            //SendActivity.GetContext(Activity, String, String, Type)
            Type contractType = typeof(string);
            String endpointName = "";
            String ownerActivityName = "";
            //<snippet15>
            SendActivity sendActivity1 = new SendActivity();
            Dictionary<String, String> Context = (Dictionary<String, String>)SendActivity.GetContext(sendActivity1, endpointName, ownerActivityName, contractType);
            //</snippet15>
        }
        void Container16()
        {
            //SendActivity.SendActivity()
            //<snippet16>
            SendActivity RequestQuoteFromShipper3;
            RequestQuoteFromShipper3 = new System.Workflow.Activities.SendActivity();
            //</snippet16>
        }
        void Container17()
        {
            //SendActivity.SendActivity(String)
            //<snippet17>
            SendActivity RequestQuoteFromShipper3;
            RequestQuoteFromShipper3 = new System.Workflow.Activities.SendActivity("RequestQuoteFromShipper3");
            //</snippet17>
        }
    
    }
}
