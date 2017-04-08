using System;
using System.IdentityModel;
using System.IdentityModel.Claims;
using System.Runtime.Serialization;
using System.Workflow.Activities;
using System.Workflow.ComponentModel;
using System.ServiceModel;
using System.Collections.Generic;
using System.Xml;
using System.ServiceModel.Channels;


namespace ReceiveActivitySnippets
{
    class snippets
    {
        void Container0()
        {
            //ReceiveActivity.CanCreateInstance
            //<snippet0>
            ReceiveActivity receiveRequestShippingQuote;
            CodeActivity doAcceptQuoteRequest;

            doAcceptQuoteRequest = new System.Workflow.Activities.CodeActivity();
            receiveRequestShippingQuote = new System.Workflow.Activities.ReceiveActivity();

            receiveRequestShippingQuote.Activities.Add(doAcceptQuoteRequest);
            receiveRequestShippingQuote.CanCreateInstance = true;
            //</snippet0>
        }
        void Container1()
        {
            //ReceiveActivity.ContextToken
            //<snippet1>
            ReceiveActivity receiveQuoteFromShipper3;
            receiveQuoteFromShipper3 = new System.Workflow.Activities.ReceiveActivity();
            System.Workflow.Activities.ContextToken contexttoken1 = new System.Workflow.Activities.ContextToken();
            contexttoken1.Name = "Shipper3Context";
            receiveQuoteFromShipper3.ContextToken = contexttoken1;
            //</snippet1>
        }
        void Container2()
        {
            //ReceiveActivity.FaultMessage
            //<snippet2>
            ReceiveActivity receiveQuote;
            receiveQuote = new ReceiveActivity();

            FaultException message = receiveQuote.FaultMessage;
            //</snippet2>
        }
        void Container3()
        {
            //ReceiveActivity.ParameterBindings
            //<snippet3>
            ReceiveActivity receiveQuoteFromShipper1 = new ReceiveActivity();
            CodeActivity shipper1ShippingQuote = new CodeActivity();
            ContextToken contextToken1 = new ContextToken();
            ActivityBind activityBind1 = new ActivityBind();
            WorkflowParameterBinding workflowParameterBinding1 = new WorkflowParameterBinding();
            TypedOperationInfo typedOperationInfo1 = new TypedOperationInfo();
            
            receiveQuoteFromShipper1.Activities.Add(shipper1ShippingQuote);
            contextToken1.Name = "Shipper1Context";
            contextToken1.OwnerActivityName = "GetShippingQuotes";
            receiveQuoteFromShipper1.ContextToken = contextToken1;
            receiveQuoteFromShipper1.Name = "receiveQuoteFromShipper1";
            activityBind1.Name = "SupplierWorkflow";
            activityBind1.Path = "quoteShipper1";
            workflowParameterBinding1.ParameterName = "quote";
            workflowParameterBinding1.SetBinding(WorkflowParameterBinding.ValueProperty, ((ActivityBind)(activityBind1)));
            receiveQuoteFromShipper1.ParameterBindings.Add(workflowParameterBinding1);
            typedOperationInfo1.ContractType = typeof(IShippingQuote);
            typedOperationInfo1.Name = "ShippingQuote";
            receiveQuoteFromShipper1.ServiceOperationInfo = typedOperationInfo1;
            //</snippet3>
        }
        void Container4()
        {
            //ReceiveActivity.ServiceOperationInfo
            //<snippet4>
            ReceiveActivity receiveQuoteFromShipper1 = new ReceiveActivity();
            CodeActivity shipper1ShippingQuote = new CodeActivity();
            ContextToken contextToken1 = new ContextToken();
            ActivityBind activityBind1 = new ActivityBind();
            WorkflowParameterBinding workflowParameterBinding1 = new WorkflowParameterBinding();
            TypedOperationInfo typedOperationInfo1 = new TypedOperationInfo();

            receiveQuoteFromShipper1.Activities.Add(shipper1ShippingQuote);
            contextToken1.Name = "Shipper1Context";
            contextToken1.OwnerActivityName = "GetShippingQuotes";
            receiveQuoteFromShipper1.ContextToken = contextToken1;
            receiveQuoteFromShipper1.Name = "receiveQuoteFromShipper1";
            activityBind1.Name = "SupplierWorkflow";
            activityBind1.Path = "quoteShipper1";
            workflowParameterBinding1.ParameterName = "quote";
            workflowParameterBinding1.SetBinding(WorkflowParameterBinding.ValueProperty, ((ActivityBind)(activityBind1)));
            receiveQuoteFromShipper1.ParameterBindings.Add(workflowParameterBinding1);
            typedOperationInfo1.ContractType = typeof(IShippingQuote);
            typedOperationInfo1.Name = "ShippingQuote";
            receiveQuoteFromShipper1.ServiceOperationInfo = typedOperationInfo1;
            //</snippet4>
        }
        void Container5()
        {
            //ReceiveActivity.GetWorkflowServiceAttributes
            Activity rootActivity = new Activity();
            //<snippet5>
            WorkflowServiceAttributes serviceAttributes = (WorkflowServiceAttributes)ReceiveActivity.GetWorkflowServiceAttributes(rootActivity);
            //</snippet5>
        }
        void Container6()
        {
            //ReceiveActivity.SetWorkflowServiceAttributes
            ReceiveActivity receiveActivity1 = new ReceiveActivity();
            //<snippet6>
            WorkflowServiceAttributes attributes = new WorkflowServiceAttributes();
            attributes.ConfigurationName = "ServiceConfig";
            attributes.IncludeExceptionDetailInFaults = true;
            attributes.AddressFilterMode = AddressFilterMode.Exact;

            ReceiveActivity.SetWorkflowServiceAttributes(receiveActivity1, attributes);
            //</snippet6>
        }
        //ReceiveActivity.OperationValidation
        Claim AuthorizedClaim = new Claim("placeholder", null, "placeholder");
        //<snippet7>
        [System.Diagnostics.DebuggerNonUserCode]
        private void InitializeComponent()
        {
            ReceiveActivity receiveActivity1 = new ReceiveActivity();
            receiveActivity1.OperationValidation += new EventHandler<OperationValidationEventArgs>(receiveActivity1_OperationValidation);
        }

        void receiveActivity1_OperationValidation(object sender, OperationValidationEventArgs e)
        {
            OperationContext context = OperationContext.Current;
            bool authorized = false;
            foreach (ClaimSet claims in context.ServiceSecurityContext.AuthorizationContext.ClaimSets)
            {
                if (claims.ContainsClaim(AuthorizedClaim))
                {
                    authorized = true;
                }
            }
            e.IsValid = authorized;  
        }

        //</snippet7>
       
        void Container11()
        {
            //ReceiveActivity.ReceiveActivity()
            //<snippet11>
            ReceiveActivity receiveActivity1 = new ReceiveActivity();
            //</snippet11>
        }
        void Container12()
        {
            //ReceiveActivity.ReceiveActivity(String)
            //<snippet12>
            ReceiveActivity receiveActivity1 = new ReceiveActivity("receiveActivity1");
            //</snippet12>
        }
        void Container13()
        {
            //ReceiveActivity.GetContext(Activity, ContextToken)
            //<snippet13>
            ReceiveActivity receiveActivity1 = new ReceiveActivity();
            Dictionary<XmlQualifiedName, String> context = (Dictionary<XmlQualifiedName, String>)ReceiveActivity.GetContext(receiveActivity1, receiveActivity1.ContextToken);
            //</snippet13>
        }
        
        //14 was a discontinued method

        void Container15()
        {
            //ReceiveActivity.GetContext(Activity, String, String)
            //<snippet15>
            ReceiveActivity receiveActivity1 = new ReceiveActivity();
            Dictionary<XmlQualifiedName, String> context =
                (Dictionary<XmlQualifiedName, String>)ReceiveActivity.GetContext(
                receiveActivity1,
                "ContextToken1",
                "ReceiveActivity1");
            //</snippet15>
        }
        void Container16()
        {
            //ReceiveActivity.GetRootContext
            //<snippet16>
            ReceiveActivity receiveActivity1 = new ReceiveActivity();
            Dictionary<XmlQualifiedName, String> context =
                (Dictionary<XmlQualifiedName, String>)ReceiveActivity.GetRootContext(receiveActivity1);
            //</snippet16>
        }

        //ReceiveActivity.Context
        //<snippet17>
        // Create EndpointAddress from Uri and ReceiveActivity
        static public EndpointAddress CreateEndpointAddress(string uri, ReceiveActivity receiveActivity)
        {
            return CreateEndpointAddress(uri, receiveActivity.Context);
        }
        //</snippet17>

        // Create EndpointAddress from Uri and Context
        static public EndpointAddress CreateEndpointAddress(string uri, IDictionary<XmlQualifiedName, string> context)
        {
            EndpointAddress epr = null;
            if (context != null && context.Count > 0)
            {
                AddressHeader contextHeader = AddressHeader.CreateAddressHeader(contextHeaderName, contextHeaderNamespace, new Dictionary<XmlQualifiedName, string>(context));
                epr = new EndpointAddress(new Uri(uri), contextHeader);
            }
            else
            {
                epr = new EndpointAddress(uri);
            }
            return epr;
        }
        static readonly string contextHeaderName = "Context";
        static readonly string contextHeaderNamespace = "http://schemas.microsoft.com/ws/2006/05/context";


       

        

        [ServiceContract]
        public interface IShippingQuote
        {
            [OperationContract(IsOneWay = true)]
            void ShippingQuote(ShippingQuote quote);
        }
        [DataContract]
        public class ShippingQuote
        {
            [DataMember]
            public int ShippingCost;
            [DataMember]
            public DateTime EstimatedShippingDate;
        }

    }
}
