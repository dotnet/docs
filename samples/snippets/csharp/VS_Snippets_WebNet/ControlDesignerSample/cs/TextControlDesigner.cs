//<Snippet1>
using System;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace ASPNet.Design.Samples.CS
{
    // Simple text Web control renders a text string.
    // This control is associated with the TextSizeWebControlDesigner.
    [DesignerAttribute(typeof(TextSizeWebControlDesigner)),
    ToolboxData("<{0}:TextControl runat=\"server\"></{0}:TextControl>")]
    public class TextControl : Label
    {
        private bool _largeText = true;

        // Constructor
        public TextControl()
        {
            Text = "Test Phrase";
            SetSize();
        }

        // Determines whether the text is large or small
        [Bindable(true), Category("Appearance"), DefaultValue("true")]
        public bool LargeText
        {
            get { return _largeText; }
            set
            {
                _largeText = value;
                SetSize();
            }
        }

        // Applies the LargeText property to the control
        private void SetSize()
        {
            if (LargeText)
                this.Font.Size = FontUnit.XLarge;
            else
                this.Font.Size = FontUnit.Small;
        }
    }

    // This control designer offers DesignerActionList commands
    // that can alter the design time html of the associated control.
    public class TextSizeWebControlDesigner : ControlDesigner
    {
        private DesignerActionListCollection _actionLists = null;

        // Do not allow direct resizing of the control
        public override bool AllowResize
        {
            get { return false; }
        }

        // Return a custom ActionList collection
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (_actionLists == null)
                {
                    _actionLists = new DesignerActionListCollection();
                    _actionLists.AddRange(base.ActionLists);

                    // Add a custom DesignerActionList
                    _actionLists.Add(new ActionList(this));
                }
                return _actionLists;
            }
        }

        //<Snippet2>
        public class ActionList : DesignerActionList
        {
            private TextSizeWebControlDesigner _parent;
            private DesignerActionItemCollection _items;

            // Constructor
            public ActionList(TextSizeWebControlDesigner parent)
                : base(parent.Component)
            {
                _parent = parent;

            }

            // Create the ActionItem collection and add one command
            public override DesignerActionItemCollection GetSortedActionItems()
            {
                if (_items == null)
                {
                    _items = new DesignerActionItemCollection();
                    _items.Add(new DesignerActionMethodItem(this, "ToggleLargeText", "Toggle Text Size", true));
                }
                return _items;
            }

            // ActionList command to change the text size
            private void ToggleLargeText()
            {
                // Get a reference to the parent designer's associated control
                TextControl ctl = (TextControl)_parent.Component;

                // Get a reference to the control's LargeText property
                PropertyDescriptor propDesc = TypeDescriptor.GetProperties(ctl)["LargeText"];

                // Get the current value of the property
                bool v = (bool)propDesc.GetValue(ctl);

                // Toggle the property value
                propDesc.SetValue(ctl, !v);
            }
        }
        //</Snippet2>
    }
}
//</Snippet1>
