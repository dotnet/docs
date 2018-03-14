using System;
using System.Drawing;
using System.Drawing.Design;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Windows.Forms;
using System.Data;

namespace MoreEventHandlerExamples
{
	internal class Form1 : System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			InitializeComponent();
		}

        //<Snippet1>
        public void LinkResolveNameEvent(
                IDesignerSerializationManager serializationManager)
        {
            // Registers an event handler for the ResolveName event.
            serializationManager.ResolveName += 
                new ResolveNameEventHandler(this.OnResolveName);
        }

        private void OnResolveName(object sender, ResolveNameEventArgs e)
        {                        
            // Displays ResolveName event information on the console. 
            Console.WriteLine("Name of the name to resolve: "+e.Name);
            Console.WriteLine("ToString output of the object that no name was resolved for: "+e.Value.ToString());            
        }
        //</Snippet1>

        //<Snippet2>
        public void LinkToolboxComponentsCreatedEvent(ToolboxItem item)
        {
            item.ComponentsCreated += new ToolboxComponentsCreatedEventHandler(this.OnComponentsCreated);
        }

        private void OnComponentsCreated(object sender, ToolboxComponentsCreatedEventArgs e)
        {
            // Lists created components on the Console.
            for( int i=0; i< e.Components.Length; i++ )
                Console.WriteLine("Component #"+i.ToString()+": "+e.Components[i].Site.Name.ToString());            
        }
        //</Snippet2>

        //<Snippet3>
        public void LinkToolboxComponentsCreatingEvent(ToolboxItem item)
        {
            item.ComponentsCreating += new ToolboxComponentsCreatingEventHandler(this.OnComponentsCreating);
        }
        
        private void OnComponentsCreating(object sender, ToolboxComponentsCreatingEventArgs e)
        {
            // Displays ComponentsCreating event information on the Console.
            Console.WriteLine("Name of the class of the root component of " +
            "the designer host receiving new components: " +
            e.DesignerHost.RootComponentClassName);
        }
        //</Snippet3>

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.Size = new System.Drawing.Size(300,300);
			this.Text = "Form1";
		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
	}
}
