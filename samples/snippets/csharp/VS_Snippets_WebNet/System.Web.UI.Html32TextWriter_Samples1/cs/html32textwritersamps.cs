using System;
// <snippet1>
using System.IO;
using System.Web.UI;

namespace Examples.AspNet
{
	public class CustomHtml32TextWriter : Html32TextWriter
	{
		// Create a constructor for the class
		// that takes a TextWriter as a parameter.
		public CustomHtml32TextWriter(TextWriter writer) 
			: this(writer, DefaultTabString) 
		{
		}

		// Create a constructor for the class that takes
		// a TextWriter and a string as parameters.
		public CustomHtml32TextWriter(TextWriter writer, String tabString) 
			: base(writer, tabString)
		{
		}
		
		// <snippet2>
		// Override the RenderBeforeContent method to render
		// styles before rendering the content of a <th> element.
		protected override string RenderBeforeContent()
		{
			// Check the TagKey property. If its value is
			// HtmlTextWriterTag.TH, check the value of the 
			// SupportsBold property. If true, return the
			// opening tag of a <b> element; otherwise, render
			// the opening tag of a <font> element with a color
			// attribute set to the hexadecimal value for red.
			if (TagKey == HtmlTextWriterTag.Th)
			{
				if (SupportsBold)
					return "<b>";
				else
					return "<font color=\"FF0000\">";
			}

			// Check whether the element being rendered
            // is an <H4> element. If it is, check the 
            // value of the SupportsItalic property.
            // If true, render the opening tag of the <i> element
            // prior to the <H4> element's content; otherwise, 
            // render the opening tag of a <font> element 
            // with a color attribute set to the hexadecimal
            // value for navy blue.
			if (TagKey == HtmlTextWriterTag.H4)
			{
				if (SupportsItalic)
					return "<i>";
				else
					return "<font color=\"000080\">";
			}
			// Call the base method.
			return base.RenderBeforeContent();
		}
		// </snippet2>

		// <snippet4>
		// Override the RenderAfterContent method to close
		// styles opened during the call to the RenderBeforeContent
		// method.
		protected override string RenderAfterContent()
		{
			// Check whether the element being rendered is a <th> element.
			// If so, and the requesting device supports bold formatting,
			// render the closing tag of the <b> element. If not,
			// render the closing tag of the <font> element.
			if (TagKey == HtmlTextWriterTag.Th)
			{
				if (SupportsBold)
					return "</b>";
				else
					return "</font>";
			}

			// Check whether the element being rendered is an <H4>.
            // element. If so, and the requesting device supports italic
            // formatting, render the closing tag of the <i> element.
            // If not, render the closing tag of the <font> element.
			if (TagKey == HtmlTextWriterTag.H4)
			{
				if (SupportsItalic)
					return "</i>";
				else
					return "</font>";
			}
			// Call the base method
			return base.RenderAfterContent();
		}
		// </snippet4>

		// <snippet3>
        // Override the RenderBeforeTag method to render the
        // opening tag of a <small> element to modify the text size of 
        // any <a> elements that this writer encounters.
		protected override string RenderBeforeTag()
		{
            // Check whether the element being rendered is an 
            // <a> element. If so, render the opening tag
            // of the <small> element; otherwise, call the base method.
			if (TagKey == HtmlTextWriterTag.A)
				return "<small>";
			return base.RenderBeforeTag();
		}
		// </snippet3>

		// <snippet5>
        // Override the RenderAfterTag method to render
        // close any elements opened in the RenderBeforeTag
        // method call.
		protected override string RenderAfterTag()
		{
            // Check whether the element being rendered is an
            // <a> element. If so, render the closing tag of the
            // <small> element; otherwise, call the base method.
			if (TagKey == HtmlTextWriterTag.A)
				return "</small>";
			return base.RenderAfterTag();
		}
		// </snippet5>
	}
}
// </snippet1>
