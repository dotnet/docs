// <Snippet2> 
using System;
using System.Security.Permissions;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Samples.AspNet.CS.Controls
{
        // Define a type of child control for the custom HtmlSelect control.
	public class MyOption1
	{
		string _id;
		string _value;
		string _text;

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

		public string text
		{
			get
			{ return _text; }
			set
			{ _text = value; }
		}
	}

       // Define a type of child control for the custom HtmlSelect control.
	public class MyOption2
	{
		string _id;
		string _value;
		string _text;

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

		public string text
		{
			get
			{ return _text; }
			set
			{ _text = value; }
		}
	}

	// Define a custom HtmlSelectBuilder control.
	public class MyHtmlSelectBuilder : HtmlSelectBuilder
	{
		// <Snippet3>
		[AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
		public override Type GetChildControlType(string tagName, IDictionary attribs)
		{
			// Distinguish between two possible types of child controls.
			if (tagName.ToLower().EndsWith("myoption1"))
			{
				return typeof(MyOption1);
			}
			else if (tagName.ToLower().EndsWith("myoption2"))
			{
				return typeof(MyOption2);
			}
			return null;
		}
		// </Snippet3>

	}

	[ControlBuilderAttribute(typeof(MyHtmlSelectBuilder))]
	public class CustomHtmlSelect : HtmlSelect
	{
		
		// Override AddParsedSubObject to treat the two types
		// of child controls differently.
		protected override void AddParsedSubObject(object obj)
		{
			string _outputtext;
			if (obj is MyOption1)
			{
				_outputtext = "option group 1: " + ((MyOption1)obj).text;
				ListItem li = new ListItem(_outputtext, ((MyOption1)obj).value);
				base.Items.Add(li);
			}
			if (obj is MyOption2)
			{
				_outputtext = "option group 2: " + ((MyOption2)obj).text;
				ListItem li = new ListItem(_outputtext, ((MyOption2)obj).value);
				base.Items.Add(li);
			}
		}
      
	}

}
// </Snippet2> 