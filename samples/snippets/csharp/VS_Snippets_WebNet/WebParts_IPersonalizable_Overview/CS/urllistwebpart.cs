// <snippet2>
namespace Samples.AspNet.CS.Controls
{

    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Web;
    using System.Web.UI;
    using System.Security.Permissions;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;

    [AspNetHostingPermission(SecurityAction.Demand,
      Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
      Level = AspNetHostingPermissionLevel.Minimal)]
    public class UrlListWebPart : WebPart, IPersonalizable
    {
        private ArrayList _sharedUrls;
        private ArrayList _userUrls;
        private bool _listDirty;

        private TextBox _nameTextBox;
        private TextBox _urlTextBox;
        private Button _addButton;
        private BulletedList _list;

        protected override void CreateChildControls()
        {
            Label nameLabel = new Label();
            Label urlLabel = new Label();
            LiteralControl breakLiteral1 = new LiteralControl("<br />");
            LiteralControl breakLiteral2 = new LiteralControl("<br />");
            LiteralControl breakLiteral3 = new LiteralControl("<br />");

            _nameTextBox = new TextBox();
            _urlTextBox = new TextBox();
            _addButton = new Button();
            _list = new BulletedList();

            nameLabel.Text = "Name: ";
            urlLabel.Text = "URL: ";
            _nameTextBox.ID = "nameTextBox";
            _urlTextBox.ID = "urlTextBox";
            _addButton.Text = "Add";
            _addButton.ID = "addButton";
            _addButton.Click += new EventHandler(this.OnClickAddButton);
            _list.DisplayMode = BulletedListDisplayMode.HyperLink;
            _list.ID = "list";

            Controls.Add(nameLabel);
            Controls.Add(_nameTextBox);
            Controls.Add(breakLiteral1);

            Controls.Add(urlLabel);
            Controls.Add(_urlTextBox);
            Controls.Add(breakLiteral2);

            Controls.Add(_addButton);
            Controls.Add(breakLiteral3);

            Controls.Add(_list);
        }

        private void OnClickAddButton(object sender, EventArgs e)
        {
            string name = _nameTextBox.Text.Trim();
            string url = _urlTextBox.Text.Trim();

            Pair p = new Pair(name, url);
            if (WebPartManager.Personalization.Scope == PersonalizationScope.Shared)
            {
                if (_sharedUrls == null)
                {
                    _sharedUrls = new ArrayList();
                }
                _sharedUrls.Add(p);
            }
            else
            {
                if (_userUrls == null)
                {
                    _userUrls = new ArrayList();
                }
                _userUrls.Add(p);
            }

            OnUrlAdded();
        }

        protected virtual void OnUrlAdded()
        {
            _listDirty = true;
            ChildControlsCreated = false;
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (_sharedUrls != null)
            {
                foreach (Pair p in _sharedUrls)
                {
                    _list.Items.Add(new ListItem((string)p.First, (string)p.Second));
                }
            }
            if (_userUrls != null)
            {
                foreach (Pair p in _userUrls)
                {
                    _list.Items.Add(new ListItem((string)p.First, (string)p.Second));
                }
            }

            base.RenderContents(writer);
        }

        public virtual bool IsDirty
        {
            get
            {
                return _listDirty;
            }
        }
		// <snippet3>
        public new virtual void Load(PersonalizationDictionary state)
        {
            if (state != null)
            {
                PersonalizationEntry sharedUrlsEntry = state["sharedUrls"];
                if (sharedUrlsEntry != null)
                {
                    _sharedUrls = (ArrayList)sharedUrlsEntry.Value;
                }

                PersonalizationEntry userUrlsEntry = state["userUrls"];
                if (userUrlsEntry != null)
                {
                    _userUrls = (ArrayList)userUrlsEntry.Value;
                }
            }
        }
		// </snippet3>

		// <snippet4>
        public virtual void Save(PersonalizationDictionary state)
        {
            if ((_sharedUrls != null) && (_sharedUrls.Count != 0))
            {
                state["sharedUrls"] = new PersonalizationEntry(_sharedUrls, PersonalizationScope.Shared);
            }
            if ((_userUrls != null) && (_userUrls.Count != 0))
            {
                state["userUrls"] = new PersonalizationEntry(_userUrls, PersonalizationScope.User);
            }
        }
		// </snippet4>
    }
}
// </snippet2>
