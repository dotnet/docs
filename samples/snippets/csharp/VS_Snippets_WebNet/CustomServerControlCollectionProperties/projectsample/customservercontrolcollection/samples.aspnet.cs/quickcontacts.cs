// QuickContacts.cs
using System;
using System.ComponentModel;
using System.Collections;
using System.Drawing.Design;
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
    DefaultProperty("Contacts"),
    ParseChildren(true, "Contacts"),
    ToolboxData(
        "<{0}:QuickContacts runat=\"server\"> </{0}:QuickContacts>")
    ]
    public class QuickContacts : WebControl
    {
        private ArrayList contactsList;

        [
        Category("Behavior"),
        Description("The contacts collection"),
        DesignerSerializationVisibility(
            DesignerSerializationVisibility.Content),
        Editor(typeof(ContactCollectionEditor), typeof(UITypeEditor)),
        PersistenceMode(PersistenceMode.InnerDefaultProperty)
        ]
        public ArrayList Contacts
        {
            get
            {
                if (contactsList == null)
                {
                    contactsList = new ArrayList();
                }
                return contactsList;
            }
        }


        // The contacts are rendered in an HTML table.
        protected override void RenderContents(
            HtmlTextWriter writer)
        {
            Table t = CreateContactsTable();
            if (t != null)
            {
                t.RenderControl(writer);
            }
        }

        private Table CreateContactsTable()
        {
            Table t = null;

            if (contactsList != null && contactsList.Count > 0)
            {
                t = new Table();

                foreach (Contact item in contactsList)
                {
                    Contact aContact = item as Contact;

                    if (aContact != null)
                    {
                        TableRow r = new TableRow();

                        TableCell c1 = new TableCell();
                        c1.Text = aContact.Name;
                        r.Controls.Add(c1);

                        TableCell c2 = new TableCell();
                        c2.Text = aContact.Email;
                        r.Controls.Add(c2);


                        TableCell c3 = new TableCell();
                        c3.Text = aContact.Phone;
                        r.Controls.Add(c3);

                        t.Controls.Add(r);
                    }
                }
            }
            return t;
        }
    }
}
