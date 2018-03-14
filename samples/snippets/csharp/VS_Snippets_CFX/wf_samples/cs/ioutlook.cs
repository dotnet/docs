using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Office.Core
{
    //Hack: Skeleton of the interfaces that the code sample is looking for in the obsolete Outlook Interop Assembly...
    public class Application
    {
        public _MailItem CreateItem(String item)
        {
            return new _MailItem();
        }
        public class SessionClass
        {
            public CurrentUserClass CurrentUser;
        }
        public class CurrentUserClass
        {
            public string Address;
        }
        public SessionClass Session;
    }
    public class _MailItem
    {
        public string To;
        public string Subject;
        public string Body;
        public void Send() { }
    }
    public class OlItemType
    {
        public static string olMailItem;
        
    }
}
