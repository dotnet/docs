//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.Statements;
using System.ServiceModel;
using System.ServiceModel.Activities;

namespace Microsoft.Samples.WF.ResumeBookmarkEndpoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Sequence workflow;
            WorkflowServiceHost host = null;           
            try
            {
                workflow = CreateWorkflow();
                host = new WorkflowServiceHost(workflow, new Uri("net.pipe://localhost"));
                ResumeBookmarkEndpoint endpoint = new ResumeBookmarkEndpoint(new NetNamedPipeBinding(NetNamedPipeSecurityMode.None), new EndpointAddress("net.pipe://localhost/workflowCreationEndpoint"));
                host.AddServiceEndpoint(endpoint);
                host.Open();
                IWorkflowCreation client = new ChannelFactory<IWorkflowCreation>(endpoint.Binding, endpoint.Address).CreateChannel();
                //create an instance
                Guid id = client.Create(null);
                Console.WriteLine("Workflow instance {0} created",id);
                //resume bookmark
                client.ResumeBookmark(id, "hello","Hello World!");
                Console.WriteLine("Press return to exit ...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (host != null)
                {
                    host.Close();
                }
            }

        }

        static Sequence CreateWorkflow()
        {
            Sequence workflow = new Sequence
            {
                Activities =
                {
                    new WriteActivity
                    {
                        BookmarkName = "hello"
                    }
                }
            };

            return workflow;
        }
    }

    //custom activity 
    class WriteActivity : NativeActivity
    {
        public string BookmarkName { get; set; }

        protected override bool CanInduceIdle
        {
            get { return true; }
        }

        protected override void Execute(NativeActivityContext context)
        {
            //create a bookmark
            context.CreateBookmark(BookmarkName, new BookmarkCallback(OnBookmarkCallback));
        }

        void OnBookmarkCallback(NativeActivityContext context, Bookmark bookmark, object state)
        {
            //write a message when bookmark resumed
            string message = (string)state;
            Console.WriteLine(message);
        }        
    }

}
