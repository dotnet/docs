using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace HtmlWindowProjectCSharp
{
	partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void getLinksFromFramesButton_Click(object sender, EventArgs e)
		{
			GetLinksFromFrames();
		}

		//<SNIPPET2>
		private void GetLinksFromFrames()
		{
			Hashtable linksTable = new Hashtable();
			string frameUrl;

			if (!(webBrowser1.Document == null))
			{
				HtmlWindow currentWindow = webBrowser1.Document.Window;
				if (currentWindow.Frames.Count > 0)
				{
					foreach (HtmlWindow frame in currentWindow.Frames)
					{
						frameUrl = frame.Url.ToString();
						Hashtable frameLinksHash = new Hashtable();

						linksTable.Add(frameUrl, frameLinksHash);
						foreach (HtmlElement hrefElement in frame.Document.Links)
						{
							frameLinksHash.Add(hrefElement.GetAttribute("HREF"), "Url");
						}
					}
				}
				else
				{
					Hashtable docLinksHash = new Hashtable();
					linksTable.Add(webBrowser1.Document.Url.ToString(), docLinksHash);

                    foreach (HtmlElement hrefElement in webBrowser1.Document.Links)
					{
						docLinksHash.Add(hrefElement.GetAttribute("HREF"), "Url");
					}
				}
			}
		}
		//</SNIPPET2>

		private void ShowModalDialogButton_Click(object sender, EventArgs e)
		{
			ShowModalDialog();
		}

		//<SNIPPET3>
		private void ShowModalDialog()
		{
			if (!(webBrowser1.Document == null)) 
			{
				HtmlWindow frame = webBrowser1.Document.Window;

				String dialogArguments = "dialogHeight: 250px; dialogWidth: 300px; dialogTop: 300px;" + 
					"dialogLeft: 300px; edge: Sunken; center: Yes; help: Yes; resizable: No; status: No;";

				// Show the dialog.
				mshtml.IHTMLWindow2 rawWindow = (mshtml.IHTMLWindow2)frame.DomWindow;
				Object o = new Object();
				Object args = (Object)dialogArguments;
				rawWindow.showModalDialog("http://www.adatum.com/dialogWindow.htm", ref o, ref args);
			}
		}
		//</SNIPPET3>

		private void OpenNewWindowOverBrowserButton_Click(object sender, EventArgs e)
		{
			OpenNewWindowOverBrowser();
		}

		//<SNIPPET5>
		private void OpenNewWindowOverBrowser()
		{
			if (webBrowser1.Document != null)
			{
				HtmlWindow docWindow = webBrowser1.Document.Window;
				HtmlWindow newWindow = docWindow.OpenNew(new Uri("http://www.adatum.com/popup.htm"), "left=" + docWindow.Position.X + ",top=" + docWindow.Position.Y + ",width=" + webBrowser1.Width + ",height=" + webBrowser1.Height);
			}
		}
		//</SNIPPET5>

		private void SetWindowStatusButton_Click(object sender, EventArgs e)
		{
            SetWindowStatus();
		}

		// <SNIPPET6>
		HtmlWindow popWindow = null;

		private void SetWindowStatus()
		{
			if (webBrowser1.Document != null) 
			{
				HtmlWindow docWindow = webBrowser1.Document.Window;
				popWindow = docWindow.OpenNew(new Uri("file://C:\\testStatusBarText.htm"), "");
				popWindow.Load += new HtmlElementEventHandler(popWindow_Load);
			}
		}

		void popWindow_Load(object sender, HtmlElementEventArgs e)
		{
			MessageBox.Show("Loaded!");
		}
		//</SNIPPET6>

		private void resetFramesButton_Click(object sender, EventArgs e)
		{

		}

		// <SNIPPET8>
		private void ResetFrames()
        {
			if (!(webBrowser1.Document == null)) 
			{
				HtmlElement frameElement = null;
				HtmlWindow docWindow = webBrowser1.Document.Window;

				foreach (HtmlWindow frameWindow in docWindow.Frames)
				{
					frameElement = frameWindow.WindowFrameElement;
					String originalUrl = frameElement.GetAttribute("SRC");

					if (!originalUrl.Equals(frameWindow.Url.ToString())) 
					{
						frameWindow.Navigate(new Uri(originalUrl));
					}
				}
			}
		}
		//</SNIPPET8>
		  
		//<SNIPPET9>
		HtmlWindow balanceWindow;

		private void balanceWindowButton_Click(object sender, EventArgs e)
		{
			if (!(webBrowser1.Document == null)) 
			{
                balanceWindow = webBrowser1.Document.Window.OpenNew(new Uri("http://www.adatum.com/viewBalances.aspx"), "dialogHeight: 250px; dialogWidth: 300px; " +
                " dialogTop: 300px; dialogLeft: 300px; edge: Sunken; center: Yes; help: Yes; " +
                "resizable: No; status: No;");

                //Listen for activity on the document.
				webBrowser1.Document.Click += new HtmlElementEventHandler(Document_Click);

                windowTimeout.Interval = 300000;
                windowTimeout.Start();
            }
		}

		private void Document_Click(object sender, HtmlElementEventArgs e)
		{
			windowTimeout.Stop();
			windowTimeout.Start();
		}

		private void windowTimeout_Tick(object sender, EventArgs e) 
        {
			if (!balanceWindow.IsClosed) 
			{
				balanceWindow.Close();
				windowTimeout.Stop();
			}
		}
		//</SNIPPET9>

		private void LoadOrderFormButton_Click(object sender, EventArgs e)
		{
			LoadOrderForm();
		}

		//<SNIPPET10>
		HtmlWindow orderWindow;
		HtmlElement formElement;

		private void LoadOrderForm()
		{
			if (!(webBrowser1.Document == null)) 
			{
				HtmlDocument doc = webBrowser1.Document;
				orderWindow = doc.Window.OpenNew(new Uri("file://C:\\orderForm.htm"), "");

				//!TODO: Perform this in the load event handler!
				// Get order form. 
				HtmlElementCollection elemCollection = doc.All.GetElementsByName("NewOrderForm");
				if (elemCollection.Count == 1) 
				{
					formElement = elemCollection[0];
					//!TODO: Awaiting DCR
					//formElement.AttachEventHandler("onsubmit", new HtmlElementEventHandler(Form_Submit));
				}
			}
		}

		private void Form_Submit(object sender, HtmlElementEventArgs e)
		{
			bool doOrder = orderWindow.Confirm("Once you transmit this order, you cannot cancel it. Submit?");
			if (!doOrder)
			{
				//Cancel the submit. 
				e.ReturnValue = false;
				orderWindow.Alert("Submit cancelled.");
			}
		}
		//</SNIPPET10>

		private void OpenThreeWindowsButton_Click(object sender, EventArgs e)
		{

		}

	    //<SNIPPET13>
		private void DisplayFirstUrl()
		{
			if (webBrowser1.Document != null)
			{
				//If this is called first, the window will only have a status bar.
				webBrowser1.Document.Window.Open(new Uri("http://www.microsoft.com/"), "displayWindow", "status=yes,width=200,height=400", false);
			}
		}

		private void DisplaySecondUrl()
		{
			if (webBrowser1.Document != null)
			{
				// If this is called first, the window will only have an Address bar.
				webBrowser1.Document.Window.Open(new Uri("http://msdn.microsoft.com/"), "displayWindow", "width=400,height=200,location=yes", false);
			}
		}
		//</SNIPPET13>

		private void displayFirstUrlButton_Click(object sender, EventArgs e)
		{
			DisplayFirstUrl();
		}

		private void displaySecondUrlButton_Click(object sender, EventArgs e)
		{
			DisplaySecondUrl();
		}

		private void enableClickScrollButton_Click(object sender, EventArgs e)
		{
			EnableClickScroll();
		}

		//<SNIPPET14>
		private void EnableClickScroll()
		{
			if (webBrowser1.Document != null)
			{
				webBrowser1.Document.Click += new HtmlElementEventHandler(Doc_Click);
			}
		}

		private void Doc_Click(object sender, HtmlElementEventArgs e)
		{
			HtmlWindow docWindow = webBrowser1.Document.Window;
			docWindow.ScrollTo(e.MousePosition.X, e.MousePosition.Y);
		}
		//</SNIPPET14>

		private void ResizeWindowButton_Click(object sender, EventArgs e)
		{
			ResizeWindow();
		}

		//<SNIPPET15>
		HtmlWindow resizableWindow = null;

		private void ResizeWindow()
		{
			if (webBrowser1.Document != null)
			{
				resizableWindow = webBrowser1.Document.Window.OpenNew(new Uri("http://www.microsoft.com/"), "");
				resizableWindow.ResizeTo(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
			}
		}
		//</SNIPPET15>

		private void suppressScriptErrorButton_Click(object sender, EventArgs e)
		{
			SuppressScriptErrors();
		}	

		//<SNIPPET16>
		private void SuppressScriptErrors()
		{
			if (webBrowser1.Document != null)
			{
                webBrowser1.Document.Window.Error += new HtmlElementErrorEventHandler(scriptWindow_Error);
			}
		}
		
		private void  scriptWindow_Error(object sender, HtmlElementErrorEventArgs e)
		{
 			MessageBox.Show("Suppressed error!");
			e.Handled = true;
		}
		//</SNIPPET16>

		//<SNIPPET17>
		HtmlWindow restrictedWindow;

		private void OpenRestrictedWindow()
		{
			if (webBrowser1.Document != null)
			{
				restrictedWindow = webBrowser1.Document.Window.OpenNew(new Uri("http://www.adatum.com/"), "width=300,height=300,resizable=yes");
				// restrictedWindow.ResizeStart += new HtmlElementEventHandler(restrictedWindow_ResizeStart);
			}
		}

		private void restrictedWindow_ResizeStart(object sender, HtmlElementEventArgs e)
		{
			e.ReturnValue = true;
		}

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.Window.Navigate(new Uri("file://C:\\testError.htm"));
        }
		//</SNIPPET17>
	}
}