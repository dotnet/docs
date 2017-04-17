// <Snippet1>
// StyledRegister.cs
using System;
using System.ComponentModel;
using System.Drawing;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Samples.AspNet.CS.Controls
{
    [
    AspNetHostingPermission(SecurityAction.Demand,
        Level = AspNetHostingPermissionLevel.Minimal),
    AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level=AspNetHostingPermissionLevel.Minimal),
    DefaultEvent("Submit"),
    DefaultProperty("ButtonText"),
    ToolboxData(
        "<{0}:StyledRegister runat=\"server\"> </{0}:StyledRegister>"),
    ]
    public class StyledRegister : CompositeControl
    {
        private Button submitButton;
        private TextBox nameTextBox;
        private Label nameLabel;
        private TextBox emailTextBox;
        private Label emailLabel;
        private RequiredFieldValidator _emailValidator;
        private RequiredFieldValidator _nameValidator;
        private Style _buttonStyle;
        private Style _textBoxStyle;

        private static readonly object EventSubmitKey = new object();

        #region Properties delegated to child controls
        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue(""),
        Description("The text to display on the button.")
        ]
        public string ButtonText
        {
            get
            {
                EnsureChildControls();
                return submitButton.Text;
            }
            set
            {
                EnsureChildControls();
                submitButton.Text = value;
            }
        }

        [
        Bindable(true),
        Category("Default"),
        DefaultValue(""),
        Description("The user name.")
        ]
        public string Name
        {
            get
            {
                EnsureChildControls();
                return nameTextBox.Text;
            }
            set
            {
                EnsureChildControls();
                nameTextBox.Text = value;
            }
        }

        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue(""),
        Description(
            "The error message of the name validator.")
        ]
        public string NameErrorMessage
        {
            get
            {
                EnsureChildControls();
                return _nameValidator.ErrorMessage;
            }
            set
            {
                EnsureChildControls();
                _nameValidator.ErrorMessage = value;
                _nameValidator.ToolTip = value;
            }
        }

        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue(""),
        Description("The text for the name label.")
        ]
        public string NameLabelText
        {
            get
            {
                EnsureChildControls();
                return nameLabel.Text;
            }
            set
            {
                EnsureChildControls();
                nameLabel.Text = value;
            }
        }

        [
        Bindable(true),
        Category("Default"),
        DefaultValue(""),
        Description("The e-mail address.")
        ]
        public string Email
        {
            get
            {
                EnsureChildControls();
                return emailTextBox.Text;
            }
            set
            {
                EnsureChildControls();
                emailTextBox.Text = value;
            }
        }

        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue(""),
        Description(
            "Error message of the e-mail validator.")
        ]
        public string EmailErrorMessage
        {
            get
            {
                EnsureChildControls();
                return _emailValidator.ErrorMessage;
            }
            set
            {
                EnsureChildControls();
                _emailValidator.ErrorMessage = value;
                _emailValidator.ToolTip = value;
            }
        }

        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue(""),
        Description("The text for the e-mail label.")
        ]
        public string EmailLabelText
        {
            get
            {
                EnsureChildControls();
                return emailLabel.Text;
            }
            set
            {
                EnsureChildControls();
                emailLabel.Text = value;

            }
        }
        #endregion

        #region Typed Style properties
        [
        Category("Styles"),
        DefaultValue(null),
        DesignerSerializationVisibility(
            DesignerSerializationVisibility.Content),
        PersistenceMode(PersistenceMode.InnerProperty),
        Description(
            "The strongly typed style for the Button child control.")
        ]
        public virtual Style ButtonStyle
        {
            get
            {
                if (_buttonStyle == null)
                {
                    _buttonStyle = new Style();
                    if (IsTrackingViewState)
                    {
                        ((IStateManager)_buttonStyle).TrackViewState();
                    }
                }
                return _buttonStyle;
            }
        }

        [
        Category("Styles"),
        DefaultValue(null),
        DesignerSerializationVisibility(
            DesignerSerializationVisibility.Content),
        PersistenceMode(PersistenceMode.InnerProperty),
        Description(
            "The strongly typed style for the TextBox child control.")
        ]
        public virtual Style TextBoxStyle
        {
            get
            {
                if (_textBoxStyle == null)
                {
                    _textBoxStyle = new Style();
                    if (IsTrackingViewState)
                    {
                        ((IStateManager)_textBoxStyle).TrackViewState();
                    }
                }
                return _textBoxStyle;
            }
        }
        #endregion

        #region Event definition
        // The Submit event.
        [
        Category("Action"),
        Description("Raised when the user clicks the button")
        ]
        public event EventHandler Submit
        {
            add
            {
                Events.AddHandler(EventSubmitKey, value);
            }
            remove
            {
                Events.RemoveHandler(EventSubmitKey, value);
            }
        }

        // The method that raises theSubmit event.
        protected virtual void OnSubmit(EventArgs e)
        {
            EventHandler SubmitHandler =
                (EventHandler)Events[EventSubmitKey];
            if (SubmitHandler != null)
            {
                SubmitHandler(this, e);
            }
        }

        // Handles the Click event of the Button and raises
        // the Submit event.
        private void _button_Click(object source, EventArgs e)
        {
            OnSubmit(EventArgs.Empty);
        }
        #endregion

        #region Overridden methods

        protected override void RecreateChildControls()
        {
            EnsureChildControls();
        }


        protected override void CreateChildControls()
        {
            Controls.Clear();

            nameLabel = new Label();

            nameTextBox = new TextBox();
            nameTextBox.ID = "nameTextBox";

            _nameValidator = new RequiredFieldValidator();
            _nameValidator.ID = "validator1";
            _nameValidator.ControlToValidate = nameTextBox.ID;
            _nameValidator.Text = "*";
            _nameValidator.Display = ValidatorDisplay.Static;

            emailLabel = new Label();

            emailTextBox = new TextBox();
            emailTextBox.ID = "emailTextBox";

            _emailValidator = new RequiredFieldValidator();
            _emailValidator.ID = "validator2";
            _emailValidator.ControlToValidate = emailTextBox.ID;
            _emailValidator.Text = "*";
            _emailValidator.Display = ValidatorDisplay.Static;

            submitButton = new Button();
            submitButton.ID = "button1";
            submitButton.Click += new EventHandler(_button_Click);

            this.Controls.Add(nameLabel);
            this.Controls.Add(nameTextBox);
            this.Controls.Add(_nameValidator);
            this.Controls.Add(emailLabel);
            this.Controls.Add(emailTextBox);
            this.Controls.Add(_emailValidator);
            this.Controls.Add(submitButton);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            AddAttributesToRender(writer);

            writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding,
                "1", false);
            writer.RenderBeginTag(HtmlTextWriterTag.Table);

            if (_buttonStyle != null)
            {
                submitButton.ApplyStyle(ButtonStyle);
            }

            if (_textBoxStyle != null)
            {
                nameTextBox.ApplyStyle(TextBoxStyle);
                emailTextBox.ApplyStyle(TextBoxStyle);
            }

            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            nameLabel.RenderControl(writer);
            writer.RenderEndTag();  // Closing td.
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            nameTextBox.RenderControl(writer);
            writer.RenderEndTag();  //Closing td.
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            _nameValidator.RenderControl(writer);
            writer.RenderEndTag();  //Closing td.
            writer.RenderEndTag();  //Closing tr.

            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            emailLabel.RenderControl(writer);
            writer.RenderEndTag();  //Closing td.
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            emailTextBox.RenderControl(writer);
            writer.RenderEndTag();  //Closing td.
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            _emailValidator.RenderControl(writer);
            writer.RenderEndTag();  //Closing td.
            writer.RenderEndTag();  //Closing tr.

            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.AddAttribute(HtmlTextWriterAttribute.Colspan,
                "2", false);
            writer.AddAttribute(HtmlTextWriterAttribute.Align,
                "right", false);
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            submitButton.RenderControl(writer);
            writer.RenderEndTag();  //closing td.
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            writer.Write("&nbsp;");
            writer.RenderEndTag();  //closing td.
            writer.RenderEndTag();  //closing tr.

            writer.RenderEndTag();  //closing table.
        }
        #endregion

        #region Custom state management
        protected override void LoadViewState(object savedState)
        {
            if (savedState == null)
            {
                base.LoadViewState(null);
                return;
            }
            else 
            {
                Triplet t = savedState as Triplet;
                
                if (t != null)
                {
                    // Always invoke LoadViewState on the base class even if 
                    // the saved state is null.
                    base.LoadViewState(t.First);
    
                    if ((t.Second) != null)
                    {
                        ((IStateManager)ButtonStyle).LoadViewState(t.Second);
                    }

                    if ((t.Third) != null)
                    {
                        ((IStateManager)TextBoxStyle).LoadViewState(t.Third);
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid view state .");
                }
            }
        }

        protected override object SaveViewState()
        {
            object baseState = base.SaveViewState();
            object buttonStyleState = null;
            object textBoxStyleState = null;

            if (_buttonStyle != null)
            {
                buttonStyleState =
                    ((IStateManager)_buttonStyle).SaveViewState();
            }

            if (_textBoxStyle != null)
            {
                textBoxStyleState =
                    ((IStateManager)_textBoxStyle).SaveViewState();
            }

            return new Triplet(baseState,
                buttonStyleState, textBoxStyleState);

        }

        protected override void TrackViewState()
        {
            base.TrackViewState();
            if (_buttonStyle != null)
            {
                ((IStateManager)_buttonStyle).TrackViewState();
            }
            if (_textBoxStyle != null)
            {
                ((IStateManager)_textBoxStyle).TrackViewState();
            }
        }
        #endregion
    }
}
// </Snippet1>
