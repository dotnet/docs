using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Text;

namespace HtmlElementProjectCSharp
{
	partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void PrintDOMButton_Click(object sender, EventArgs e)
		{

		}

		//<SNIPPET1>
		private void PrintDomBegin()
		{
			if (webBrowser1.Document != null)
			{
				HtmlElementCollection elemColl = null;
				HtmlDocument doc = webBrowser1.Document;
				if (doc != null)
				{
					elemColl = doc.GetElementsByTagName("HTML");
					String str = PrintDom(elemColl, new System.Text.StringBuilder(), 0);
					webBrowser1.DocumentText = str;
				}
			}
		}

		private string PrintDom(HtmlElementCollection elemColl, System.Text.StringBuilder returnStr, Int32 depth)
		{
			System.Text.StringBuilder str = new System.Text.StringBuilder();

			foreach (HtmlElement elem in elemColl)
			{
				string elemName;

				elemName = elem.GetAttribute("ID");
				if (elemName == null || elemName.Length == 0)
				{
					elemName = elem.GetAttribute("name");
					if (elemName == null || elemName.Length == 0)
					{
						elemName = "<no name>";
					}
				}

				str.Append(' ', depth * 4);
				str.Append(elemName + ": " + elem.TagName + "(Level " + depth + ")");
				returnStr.AppendLine(str.ToString());

				if (elem.CanHaveChildren)
				{
					PrintDom(elem.Children, returnStr, depth + 1);
				}

				str.Remove(0, str.Length);
			}

			return(returnStr.ToString());
		}
		//</SNIPPET1>

		private void enableElementMoveButton_Click(object sender, EventArgs e)
		{
			EnableElementMove();
		}

		//<SNIPPET2>
		HtmlDocument doc;
		HtmlElement moveElement;

		private void EnableElementMove()
		{
			if (webBrowser1 != null)
			{
				doc = webBrowser1.Document;
				doc.Click += new HtmlElementEventHandler(doc_Click);
			}
		}

		void doc_Click(object sender, HtmlElementEventArgs e)
		{
			if (moveElement == null)
			{
				moveElement = webBrowser1.Document.GetElementFromPoint(e.ClientMousePosition);
			}
			else
			{
				HtmlElement targetElement = webBrowser1.Document.GetElementFromPoint(e.ClientMousePosition);
				if (targetElement.CanHaveChildren)
				{
					targetElement.AppendChild(moveElement);
					moveElement = null;
				}
			}
		}
		//</SNIPPET2>

		private void enableEditingButton_Click(object sender, EventArgs e)
		{

		}

		//<SNIPPET3>
		private void EnableEditing()
		{
			if (webBrowser1.Document != null)
			{
				HtmlElement elem = webBrowser1.Document.GetElementById("div1");
				if (elem != null)
				{
					if (elem.ClientRectangle.Width < 200)
					{
						elem.SetAttribute("width", "200px");
					}

					if (elem.ClientRectangle.Height < 50)
					{
						elem.SetAttribute("height", "50px");
					}

					elem.SetAttribute("contentEditable", "true");
					//elem.SetFocus();
				}
			}
		}
		//</SNIPPET3>

		//<SNIPPET4>
		private void CreateHyperlinkFromSelection()
		{
			if (webBrowser1.Document != null)
			{

				mshtml.IHTMLDocument2 iDoc = (mshtml.IHTMLDocument2)webBrowser1.Document.DomDocument;

				if (iDoc != null) 
				{
					mshtml.IHTMLSelectionObject iSelect = iDoc.selection;
					if (iSelect == null)
					{
						MessageBox.Show("Please select some text before using this command.");
						return;
					}

					mshtml.IHTMLTxtRange txtRange = (mshtml.IHTMLTxtRange)iSelect.createRange();

					// Create the link.
					if (txtRange.queryCommandEnabled("CreateLink"))
					{
						Object o = null;
						txtRange.execCommand("CreateLink", true, o);
					}
				}
			}
		}
		//</SNIPPET4>

		private void createLinkFromSelectionButton_Click(object sender, EventArgs e)
		{
			CreateHyperlinkFromSelection();
		}

		//<SNIPPET5>
		private void CreateHtmlMenu()
		{
			HtmlElement elem = webBrowser1.Document.GetElementById("div1");

			String htmlMenu = "<DIV id=\"menu1\" style=\"width:200px;position:absolute;\">";
			htmlMenu += "<DIV id=\"menu1_1\" style=\"background:#999999;color:white;font-weight:bold;\">";
			htmlMenu += "<SPAN id=\"menu1_0_cue\" style=\"border-style:solid;border-width:1px;color:white;background:999999;\">+</SPAN>First Level<BR>";
			htmlMenu += "<DIV id=\"menu1_1_0\" style=\"margin-left:20px;color:white;font-weight:normal;display:none;\">";
			htmlMenu += "<DIV id=\"menu1_1_1\" style=\"margin-left:20px;color:white;\">First Sub-Level</DIV>\n";
			htmlMenu += "<DIV id=\"menu1_1_2\" style=\"margin-left:20px;color:white;\">Second Sub-Level</DIV>\n" ;
			htmlMenu += "</DIV></DIV>";

			htmlMenu += "</DIV>";

			elem.InnerHtml = htmlMenu;

			// Retrieve the menu cues and hook up an event handler for expanding and collapsing display of the
			// child elements.  
			foreach (HtmlElement menuCueElem in elem.GetElementsByTagName("SPAN"))
			{
				if (menuCueElem.Id.EndsWith("cue"))
				{
					menuCueElem.Click += new HtmlElementEventHandler(Element_Click);
				}
			}
		}

		private void Element_Click(Object sender, HtmlElementEventArgs e)
		{
			// !TODO: Need SetStyle() implemented per DCR. 
		}
		//</SNIPPET5>

		private void CreateHtmlMenuButton_Click(object sender, EventArgs e)
		{
			CreateHtmlMenu();
		}

		//<SNIPPET6>
		private void GetOffsets()
		{
			String str = "";
			HtmlDocument doc = webBrowser1.Document;

			foreach (HtmlElement elem in doc.GetElementsByTagName("SPAN"))
			{
				str += "OffsetParent for " + elem.Id + " is " + elem.OffsetParent.Id;
				str += "; OffsetRectangle is " + elem.OffsetRectangle.ToString() + "\n";
			}

			MessageBox.Show(str);
		}
		//</SNIPPET6>

		private void GetOffsetsButton_Click(object sender, EventArgs e)
		{
			GetOffsets();
		}

		//<SNIPPET7>
		private void AddUrlToTooltip()
		{
			if (webBrowser1.Document != null)
			{
				foreach (HtmlElement elem in webBrowser1.Document.GetElementsByTagName("IMG"))
				{
					if (elem.Parent.TagName.Equals("A"))
					{
						String altStr = elem.GetAttribute("ALT");
						if (!(altStr == null) && (altStr.Length != 0))
						{
							elem.SetAttribute("ALT", altStr + " - points to " + elem.Parent.GetAttribute("HREF"));
						}
						else
						{
							elem.SetAttribute("ALT", "Points to " + elem.Parent.GetAttribute("HREF"));
						}
					}
				}
			}
		}
		//</SNIPPET7>

		private void AddUrlToTooltipButton_Click(object sender, EventArgs e)
		{
			AddUrlToTooltip("http://www.adatum.com/");
		}

		//<SNIPPET8>
		private void AddUrlToTooltip(string url)
		{
			if (webBrowser1.Document != null)
			{
				HtmlElement elem = webBrowser1.Document.CreateElement("A");
				elem.SetAttribute("HREF", url);
				elem.InnerText = "Visit our Web site for more details.";

				webBrowser1.Document.Body.AppendChild(elem);
			}
		}
		//</SNIPPET8>

		//<SNIPPET9>
		public void AddDivMessage()
		{
			Uri currentUri = new Uri(webBrowser1.Url.ToString());
			String hostName = null;

			// Ensure we have a host name, and not just an IP, against which to test.
			if (!(currentUri.HostNameType == UriHostNameType.Dns))
			{
				DnsPermission permit = new DnsPermission(System.Security.Permissions.PermissionState.Unrestricted);
				permit.Assert();

				IPHostEntry hostEntry = System.Net.Dns.GetHostEntry(currentUri.Host);
				hostName = hostEntry.HostName;
			} else {
				hostName = currentUri.Host;
			}

			if (!hostName.Contains("adatum.com"))
			{
				AddTopPageMessage("You are viewing a web site other than ADatum.com. " +
					"Please exercise caution, and ensure your Web surfing complies with all " +
					"corporate regulations as laid out in the company handbook.");
			}
		}

		private void AddTopPageMessage(String message)
		{
			if (webBrowser1.Document != null) 
			{
				HtmlDocument doc = webBrowser1.Document;

                // Do not insert the warning again if it already exists. 
                HtmlElementCollection returnedElems = doc.All.GetElementsByName("ADatumWarningDiv");
                if ((returnedElems != null) && (returnedElems.Count > 0)) 
				{
                    return;
				}

                HtmlElement divElem = doc.CreateElement("DIV");
                divElem.Name = "ADatumWarningDiv";
                divElem.Style = "background-color:black;color:white;font-weight:bold;width:100%;";
                divElem.InnerText = message;

                divElem = doc.Body.InsertAdjacentElement(HtmlElementInsertionOrientation.AfterBegin, divElem);
			}
		}
		//</SNIPPET9>

		private void AddDivMessageButton_Click(object sender, EventArgs e)
		{
			AddDivMessage();
		}

		//<SNIPPET10>
		private void SubmitForm(String formName)
		{
			HtmlElementCollection elems = null;
			HtmlElement elem = null;

			if (webBrowser1.Document != null)
			{
				HtmlDocument doc = webBrowser1.Document;
                elems = doc.All.GetElementsByName(formName);
                if (elems != null && elems.Count > 0) 
				{
                    elem = elems[0];
                    if (elem.TagName.Equals("FORM"))
					{
                        elem.InvokeMember("Submit");
                    }
				}
			}
		}
		//</SNIPPET10>

		private void submitFormButtom_Click(object sender, EventArgs e)
		{
			SubmitForm("form1");
		}



		//<SNIPPET11>
		private void ShiftRows(String tableName)
		{
			if (webBrowser1.Document != null)
			{
				HtmlDocument doc = webBrowser1.Document;
				HtmlElementCollection elems = doc.All.GetElementsByName(tableName);
				if (elems != null && elems.Count > 0)
				{
					HtmlElement elem = elems[0];

					// Prepare the arguments.
					Object[] args = new Object[2];
					args[0] = (Object)"-1";
					args[1] = (Object)"0";

					elem.InvokeMember("moveRow", args);
				}
			}
		}
		//</SNIPPET11>

		//<SNIPPET12>
		private void ScrollToElement(String elemName)
		{
			if (webBrowser1.Document != null)
			{
				HtmlDocument doc = webBrowser1.Document;
                HtmlElementCollection elems = doc.All.GetElementsByName(elemName);
                if (elems != null && elems.Count > 0) 
				{
                    HtmlElement elem = elems[0];

                    elem.ScrollIntoView(true);
				}
			}
		}
		//</SNIPPET12>

		//<SNIPPET13>
		private void InsertImageFooter()
		{
			if (webBrowser1.Document != null)
			{
				HtmlDocument doc = webBrowser1.Document;
				HtmlElement elem = doc.CreateElement("IMG");
				elem.SetAttribute("SRC", "http://www.adatum.com/images/footer-banner.jpg");

				doc.Body.AppendChild(elem);
			}
		}
		//</SNIPPET13>

		// <SNIPPET14>
		HtmlElement bodyElement = null;

		private void SetBody()
		{
			if (webBrowser1.Document != null)
			{
				HtmlDocument doc = webBrowser1.Document;
				bodyElement = doc.Body;
				//bodyElement.Error += new HtmlElementEventHandler(HandleError);
			}
		}

		private void HandleError(Object sender, HtmlElementEventArgs e)
		{
			//System.Diagnostics.EventLog.WriteEntry("Custom Application", "Scripting error occurred: " & _
			//e.
		}
		//</SNIPPET14>

		// <SNIPPET15>
		HtmlElement targetFormElement;

		private void HandleFormFocus()
		{
			if (webBrowser1.Document != null) 
			{
				HtmlDocument doc = webBrowser1.Document;
				if (doc.Forms.Count > 0) 
				{
					HtmlElement targetForm = doc.Forms[0];
					HtmlElementCollection searchCollection = targetForm.All.GetElementsByName("text1");
					if (searchCollection.Count == 1) 
					{
                        targetFormElement = searchCollection[0];
					}
				}
			}
		}

		private void TargetFormElement_Focus(Object sender, HtmlElementEventArgs e)
		{
			HtmlElement textElement = e.FromElement;
			String elementText = textElement.GetAttribute("value");

			// Check that this value is at least five characters long.
			if (elementText.Length < 5)
			{
				e.ReturnValue = true;
				MessageBox.Show("The entry in the current field must be at least five characters long.");
			}
		}
		//</SNIPPET15>

		private void AttachEventHandlerButton_Click(object sender, EventArgs e)
		{
			AttachCopyHandler();
		}

		//<SNIPPET16>
        private void AttachCopyHandler()
        {
            if (webBrowser1.Document != null) {
                HtmlElement div = webBrowser1.Document.GetElementById("Div1");
                div.AttachEventHandler("oncopy", new EventHandler(HtmlElement_OnCopy));
            }
        }

        private void HtmlElement_OnCopy(Object sender, EventArgs e)
        {
            browserStatus.Text = "Selection copied. Selection is: " + Clipboard.GetText();
        }
		//</SNIPPET16>

        private void button2_Click(object sender, EventArgs e)
        {
            ScrollList();
        }

        //<SNIPPET17>
        HtmlElement elem = null;
        int lastKeystrokeOn = 0;
        StringBuilder keystrokes;

        private void ScrollList()
        {

            if (webBrowser1.Document != null)
            {
                keystrokes = new StringBuilder();

                elem = webBrowser1.Document.GetElementById("text1");
                elem.KeyDown += new HtmlElementEventHandler(elem_KeyDown);
            }
        }

        void elem_KeyDown(object sender, HtmlElementEventArgs e)
        {
            Char c = (char)e.KeyPressedCode;

            if (Char.IsLetterOrDigit(c))
            {
                lastKeystrokeOn++;
            }
        }
        //</SNIPPET17>
	}
}