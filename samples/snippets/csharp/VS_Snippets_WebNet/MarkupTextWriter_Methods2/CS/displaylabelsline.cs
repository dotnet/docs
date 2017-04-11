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
    public class RenderObjectsWriteLine : Control
    {
// <snippet6>
        private char[] testChars = {'h', 'e', 'l', 'l', 'o',
            HtmlTextWriter.SpaceChar ,'w', 'o', 'r', 'l', 'd'};
// </snippet6>
        private int numOrdered = 80;

// <snippet7>
        private object[] curPriceTime = {4.25, DateTime.Now};
// </snippet7>

        protected override void Render(HtmlTextWriter writer)
        {


// <snippet1>
            // Render a formatted string and the
            // text representation of a variable, int0,
            // as the contents of a <label> element.
            writer.RenderBeginTag(HtmlTextWriterTag.Label);
            writer.WriteLine("Thanks for buying {0} widgets.", numOrdered);
            writer.RenderEndTag();
// </snippet1>

            writer.RenderBeginTag(HtmlTextWriterTag.Br);
            writer.RenderEndTag();

// <snippet2>
            // Render a formatted string and the
            // text representation of an object array,
            // myObjectArray, as the contents of
            // a <label> element.
            writer.RenderBeginTag(HtmlTextWriterTag.Label);
            writer.WriteLine("The trade value at {1} is ${0}.", curPriceTime);
            writer.RenderEndTag();
// </snippet2>

            writer.RenderBeginTag(HtmlTextWriterTag.Br);
            writer.RenderEndTag();
// <snippet3>
            // Render a formatted string and the
            // text representation of two variables,
            // int0 and int1, as the contents of
            // a <label> element.
            writer.RenderBeginTag(HtmlTextWriterTag.Label);
            writer.WriteLine("The winning numbers are {0} and {1}.", 47, 825);
            writer.RenderEndTag();
// </snippet3>

            writer.RenderBeginTag(HtmlTextWriterTag.Br);
            writer.RenderEndTag();
// <snippet4>
            // Render a subarray of a character array
            // as the contents of a <label> element.
            writer.RenderBeginTag(HtmlTextWriterTag.Label);
            writer.WriteLine(testChars, 0, 5);
            writer.RenderEndTag();
// </snippet4>
            writer.RenderBeginTag(HtmlTextWriterTag.Br);
            writer.RenderEndTag();
// <snippet5>
            // Render a character array as the contents of 
            // a <label> element.
            writer.RenderBeginTag(HtmlTextWriterTag.Label);
            writer.WriteLine(testChars);
            writer.RenderEndTag();
// </snippet5>
        }
    }
}
