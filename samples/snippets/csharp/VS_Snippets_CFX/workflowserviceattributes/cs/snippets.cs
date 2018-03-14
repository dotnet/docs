using System;
using System.Workflow.Activities;
using System.ServiceModel;

namespace WorkflowServiceAttributesSnippets
{
    class snippets
    {
        void Container0()
        {
            //WorkflowServiceAttributes.WorkflowServiceAttributes
            //<snippet0>
            WorkflowServiceAttributes attributes = new WorkflowServiceAttributes();
            //</snippet0>
        }
        void Container1()
        {
            //WorkflowServiceAttributes.AddressFilterMode
            //<snippet1>
            WorkflowServiceAttributes attributes = new WorkflowServiceAttributes();
            attributes.AddressFilterMode = AddressFilterMode.Exact;
            //</snippet1>
        }
        void Container2()
        {
            //WorkflowServiceAttributes.ConfigurationName
            //<snippet2>
            WorkflowServiceAttributes attributes = new WorkflowServiceAttributes();
            attributes.ConfigurationName = "CalculatorService";
            //</snippet2>
        }
        void Container3()
        {
            //WorkflowServiceAttributes.IgnoreExtensionDataObject
	    //<snippet3>
            WorkflowServiceAttributes attributes = new WorkflowServiceAttributes();
            attributes.IgnoreExtensionDataObject = true;
            
            //</snippet3>
        }
        void Container4()
        {
            //WorkflowServiceAttributes.IncludeExceptionDetailInFaults
            //<snippet4>
            WorkflowServiceAttributes attributes = new WorkflowServiceAttributes();
            attributes.IncludeExceptionDetailInFaults = true;
            //</snippet4>
        }
        void Container5()
        {
            //WorkflowServiceAttributes.MaxItemsInObjectGraph
            //<snippet5>
            WorkflowServiceAttributes attributes = new WorkflowServiceAttributes();
            attributes.MaxItemsInObjectGraph = 10;
            //</snippet5>
        }
        void Container6()
        {
            //WorkflowServiceAttributes.Name
            //<snippet6>
            WorkflowServiceAttributes attributes = new WorkflowServiceAttributes();
            attributes.Name = "CalculatorService";
            //</snippet6>
        }
        void Container7()
        {
            //WorkflowServiceAttributes.Namespace
            //<snippet7>
            WorkflowServiceAttributes attributes = new WorkflowServiceAttributes();
            attributes.Namespace = "Microsoft.Samples.WorkflowServices.SampleCode";
            //</snippet7>
        }
        void Container8()
        {
            //WorkflowServiceAttributes.UseSynchronizationContext
            //<snippet8>
            WorkflowServiceAttributes attributes = new WorkflowServiceAttributes();
            attributes.UseSynchronizationContext = false;
            //</snippet8>
        }
        void Container9()
        {
            //WorkflowServiceAttributes.ValidateMustUnderstand
            //<snippet9>
            WorkflowServiceAttributes attributes = new WorkflowServiceAttributes();
            attributes.ValidateMustUnderstand = false;
            //</snippet9>
        }

    }
}
