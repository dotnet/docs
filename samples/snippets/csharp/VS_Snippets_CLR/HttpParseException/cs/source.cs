// <Snippet2> 
using System;
using System.Security.Permissions;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Samples.AspNet.CS
{
    // Define a child control for the custom HtmlSelect.
    public class MyCustomOption
    {
        string _id;
        string _value;

        public string optionid
        {
            get
            { return _id; }
            set
            { _id = value; }
        }

        public string value
        {
            get
            { return _value; }
            set
            { _value = value; }
        }

    }

    // Define a custom HtmlSelectBuilder.
    public class MyHtmlSelectBuilderWithparseException : HtmlSelectBuilder
    {
        [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
        public override Type GetChildControlType(string tagName, IDictionary attribs)
        {
            // Distinguish between two possible types of child controls.
            if (tagName.ToLower().EndsWith("mycustomoption"))
            {
                return typeof(MyCustomOption);
            }
            else
            {
                // <Snippet3>
                throw new HttpParseException("This custom HtmlSelect control" +                                                  "requires child elements of the form \"MyCustomOption\"");
                // </Snippet3>
            }
        }

    }

    [ControlBuilderAttribute(typeof(MyHtmlSelectBuilderWithparseException))]
    public class CustomHtmlSelectWithHttpParseException : HtmlSelect
    {
        // Override the AddParsedSubObject method.
        protected override void AddParsedSubObject(object obj)
        {
            
            string _outputtext;
            if (obj is MyCustomOption)
            {
                _outputtext = "custom select option : " + ((MyCustomOption)obj).value;
                ListItem li = new ListItem(_outputtext, ((MyCustomOption)obj).value);
                base.Items.Add(li);
            }
        }      
    }

}
// </Snippet2> 