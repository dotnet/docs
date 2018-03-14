// Contact.cs
// The type of the items in the Contacts collection property 
//in QuickContacts.

using System;
using System.Collections;
using System.ComponentModel;
using System.Web.UI;

namespace Samples.AspNet.CS.Controls
{
    [
    TypeConverter(typeof(ExpandableObjectConverter))
    ]
    public class Contact
    {
        private string nameValue;
        private string emailValue;
        private string phoneValue;


        public Contact()
            : this(String.Empty, String.Empty, String.Empty)
        {
        }

        public Contact(string name, string email, string phone)
        {
            nameValue = name;
            emailValue = email;
            phoneValue = phone;
        }

        [
        Category("Behavior"),
        DefaultValue(""),
        Description("Name of contact"),
        NotifyParentProperty(true),
        ]
        public String Name
        {
            get
            {
                return nameValue;
            }
            set
            {
                nameValue = value;
            }
        }

        [
        Category("Behavior"),
        DefaultValue(""),
        Description("Email address of contact"),
        NotifyParentProperty(true)
        ]
        public String Email
        {
            get
            {
                return emailValue;
            }
            set
            {
                emailValue = value;
            }
        }

        [
        Category("Behavior"),
        DefaultValue(""),
        Description("Phone number of contact"),
        NotifyParentProperty(true)
        ]
        public String Phone
        {
            get
            {
                return phoneValue;
            }
            set
            {
                phoneValue = value;
            }
        }
    }
}
