//<Snippet1>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Security.Permissions;
using System.Windows.Forms;

namespace TextDataTextBoxComponent
{
    // Component that adds a "Text" data format ToolboxItemCreatorCallback 
    // to the Toolbox. This component uses a custom ToolboxItem that 
    // creates a TextBox containing the text data.
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public class TextDataTextBoxComponent : Component
    {
        private bool creatorAdded = false;
        private IToolboxService ts;

        public TextDataTextBoxComponent()
        {                     
        }

        // ISite override to register TextBox creator
        public override System.ComponentModel.ISite Site
        {
            get
            {
                return base.Site;
            }
            set
            {
                if( value != null )
                {                    
                    base.Site = value;

                    if (!creatorAdded)
                    {
                        AddTextTextBoxCreator();
                    }
                }
                else
                {
                    if (creatorAdded)
                    {
                        RemoveTextTextBoxCreator();
                    }

                    base.Site = value;             
                }
            }
        }

        // Adds a "Text" data format creator to the toolbox that creates 
        // a textbox from a text fragment pasted to the toolbox.
        private void AddTextTextBoxCreator()
        {
            ts = (IToolboxService)GetService(typeof(IToolboxService));

            if (ts != null) 
            {
                ToolboxItemCreatorCallback textCreator = 
                    new ToolboxItemCreatorCallback(this.CreateTextBoxForText);

                try
                {
                    ts.AddCreator(
                        textCreator, 
                        "Text", 
                        (IDesignerHost)GetService(typeof(IDesignerHost)));

                    creatorAdded = true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(
                        ex.ToString(), 
                        "Exception Information");
                }                
            }
        }

        // Removes any "Text" data format creator from the toolbox.
        private void RemoveTextTextBoxCreator()
        {
            if (ts != null)             
            {
                ts.RemoveCreator(
                    "Text", 
                    (IDesignerHost)GetService(typeof(IDesignerHost)));            

                creatorAdded = false;
            }
        }

        // ToolboxItemCreatorCallback delegate format method to create 
        // the toolbox item.
        private ToolboxItem CreateTextBoxForText(
            object serializedObject, 
            string format)
        {
            DataObject o = new DataObject((IDataObject)serializedObject);

            string[] formats = o.GetFormats();

            if (o.GetDataPresent("System.String", true))
            {
                string toolboxText = (string)(o.GetData("System.String", true));
                return (new TextToolboxItem(toolboxText));
            }

            return null;
        }

        protected override void Dispose(bool disposing)
        {
            if (creatorAdded)
            {
                RemoveTextTextBoxCreator();
            }
        }        
    }

    // Custom toolbox item creates a TextBox and sets its Text property
    // to the constructor-specified text.
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")] 
    public class TextToolboxItem : ToolboxItem
    {
        private string text;
        private delegate void SetTextMethodHandler(Control c, string text);

        public TextToolboxItem(string text) : base()
        {
            this.text = text;
        }

        // ToolboxItem.CreateComponentsCore override to create the TextBox 
        // and link a method to set its Text property.
        [PermissionSet(SecurityAction.Demand, Name="FullTrust")] 
        protected override IComponent[] CreateComponentsCore(IDesignerHost host)
        {
            System.Windows.Forms.TextBox textbox = 
                (TextBox)host.CreateComponent(typeof(TextBox));
                
            // Because the designer resets the text of the textbox, use 
            // a SetTextMethodHandler to set the text to the value of 
            // the text data.
            Control c = host.RootComponent as Control;
            c.BeginInvoke(
                new SetTextMethodHandler(OnSetText), 
                new object[] {textbox, text});
           
            return new System.ComponentModel.IComponent[] { textbox };
        }        

        // Method to set the text property of a TextBox after it is initialized.
        private void OnSetText(Control c, string text) 
        {
            c.Text = text;
        }
    }
}
//</Snippet1>
