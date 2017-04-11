using System;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Reflection;

namespace Samples.AspNet.CS
{

    // <summary>
    // This example demonstrates the following overloads of
    // the HtmlTextWriter.WriteLine method: WriteLine(String, Object),
    // WriteLine(String, Object[]), WriteLine(String, Object, Object),
    // and WriteLine(Char[], Int32, Int32).
    // </summary>
    [AspNetHostingPermission(SecurityAction.Demand,
        Level=AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
        Level=AspNetHostingPermissionLevel.Minimal)]
    public class RenderObjects : Control
    {
// <snippet13>
        private char[] testChars = {'h', 'e', 'l', 'l', 'o',
            HtmlTextWriter.SpaceChar ,'w', 'o', 'r', 'l', 'd'};
// </snippet13>
        private int intAmtOrdered = 80;

// <snippet14>
        private object[] curPriceTime = {4.25, DateTime.Now};
// </snippet14>

        protected override void Render(HtmlTextWriter writer)
        {


// <snippet8>
            // Render a formatted string and the
            // text representation of a variable, int0,
            // as the contents of a <label> element.
            writer.RenderBeginTag(HtmlTextWriterTag.Label);
            writer.Write("Thanks for buying {0} widgets.", intAmtOrdered);
            writer.RenderEndTag();
// </snippet8>

            writer.RenderBeginTag(HtmlTextWriterTag.Br);
            writer.RenderEndTag();

// <snippet9>
            // Render a formatted string and the
            // text representation of an object array,
            // myObjectArray, as the contents of
            // a <label> element.
            writer.RenderBeginTag(HtmlTextWriterTag.Label);
            writer.Write("The trade value at {1} is ${0}.", curPriceTime);
            writer.RenderEndTag();
// </snippet9>

            writer.RenderBeginTag(HtmlTextWriterTag.Br);
            writer.RenderEndTag();
// <snippet10>
            // Render a formatted string and the
            // text representation of two variables,
            // int0 and int1, as the contents of
            // a <label> element.
            writer.RenderBeginTag(HtmlTextWriterTag.Label);
            writer.Write("The winning numbers are {0} and {1}.", 47, 825);
            writer.RenderEndTag();
// </snippet10>

            writer.RenderBeginTag(HtmlTextWriterTag.Br);
            writer.RenderEndTag();
// <snippet11>
            // Render a subarray of a character array
            // as the contents of a <label> element.
            writer.RenderBeginTag(HtmlTextWriterTag.Label);
            writer.Write(testChars, 0, 5);
            writer.RenderEndTag();
// </snippet11>
            writer.RenderBeginTag(HtmlTextWriterTag.Br);
            writer.RenderEndTag();
// <snippet12>
            // Render a character array as the 
            // contents of a <label> element.
            writer.RenderBeginTag(HtmlTextWriterTag.Label);
            writer.Write(testChars);
            writer.RenderEndTag();
// </snippet12>
        }
    }
}
