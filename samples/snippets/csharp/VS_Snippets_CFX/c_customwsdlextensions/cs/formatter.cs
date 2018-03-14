using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml;

namespace Microsoft.WCF.Documentation
{
  public class Formatter
  {

		#region Utility Functions

    public static XmlElement CreateSummaryElement(XmlDocument owningDoc, string text)
    {
      XmlElement summaryElement = owningDoc.CreateElement("summary");
      summaryElement.InnerText = text;
      return summaryElement;
    }

		public static CodeCommentStatementCollection FormatComments(string text)
		{
      /*
       * Note that in Visual C# the XML comment format absorbs a 
       * documentation element with a line break in the middle. This sample
       * could take an XmlElement and create code comments in which 
       * the element never had a line break in it.
      */

      CodeCommentStatementCollection collection = new CodeCommentStatementCollection();
			collection.Add(new CodeCommentStatement("From WsdlDocumentation:", true));
			collection.Add(new CodeCommentStatement(String.Empty, true));

			foreach (string line in WordWrap(text, 80))
			{
				collection.Add(new CodeCommentStatement(line, true));
			}

			collection.Add(new CodeCommentStatement(String.Empty, true));
			return collection;
		}

		public static Collection<string> WordWrap(string text, int columnWidth)
		{
			Collection<string> lines = new Collection<string>();
			System.Text.StringBuilder builder = new System.Text.StringBuilder();

			string[] words = text.Split(' ');
			foreach (string word in words)
			{
				if ((builder.Length > 0) && ((builder.Length + word.Length + 1) > columnWidth))
				{
					lines.Add(builder.ToString());
					builder = new System.Text.StringBuilder();
				}
				builder.Append(word);
				builder.Append(' ');
			}
			lines.Add(builder.ToString());

			return lines;
		}

		#endregion  
  
    public static XmlElement CreateReturnsElement(XmlDocument owner, string p)
    {
      XmlElement returnsElement = owner.CreateElement("returns");
      returnsElement.InnerText = p;
      return returnsElement;
    }
  }
}
