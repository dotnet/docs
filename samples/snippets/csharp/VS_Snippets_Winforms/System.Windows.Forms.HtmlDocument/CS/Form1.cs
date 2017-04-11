using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HtmlDocumentProjectCSharp
{
    partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //<SNIPPET1>
        public void EnableAllElements()
        {
            if (webBrowser1.Document != null)
            {
                foreach (HtmlElement pageElement in webBrowser1.Document.All)
                {
                    pageElement.Enabled = true;
                }
            }
        }
        //</SNIPPET1>

        private void EnableAllElementsButton_Click(object sender, EventArgs e)
        {
            EnableAllElements();
        }

        //<SNIPPET2>
        private void ShowCookies()
        {
            MessageBox.Show("Cookies for the document are " + webBrowser1.Document.Cookie);
        }
        //</SNIPPET2>

        private void showCookiesButton_Click(object sender, EventArgs e)
        {
            ShowCookies();
        }

        //<SNIPPET3>
        private string GetLastModifiedDate()
        {
            if (webBrowser1.Document != null)
            {
                MSHTML.IHTMLDocument2 currentDoc = (MSHTML.IHTMLDocument2)webBrowser1.Document.DomDocument;
                return (currentDoc.lastModified);
            }
            else
            {
                return ("");
            }
        }
        //</SNIPPET3>

        private void getLastModifiedDateButton_Click(object sender, EventArgs e)
        {
            GetLastModifiedDate();
        }

        //<SNIPPET4>
        private void ResetForms()
        {
            if (webBrowser1.Document != null)
            {
                foreach (HtmlElement form in webBrowser1.Document.Forms)
                {
                    form.InvokeMember("reset");
                }
            }
        }
        //</SNIPPET4>

        private void ResetFormsButton_Click(object sender, EventArgs e)
        {
            ResetForms();
        }

        //<SNIPPET5>
        private Int32 GetTableRowCount(string tableID)
        {
            Int32 count = 0;

            if (webBrowser1.Document != null)
            {
                HtmlElement tableElem = webBrowser1.Document.GetElementById(tableID);
                if (tableElem != null)
                {
                    foreach (HtmlElement rowElem in tableElem.GetElementsByTagName("TR"))
                    {
                        count++;
                    }
                }
                else
                {
                    throw(new ArgumentException("No TABLE with an ID of " + tableID + " exists."));
                }
            }

            return(count);
        }
        //</SNIPPET5>

        //<SNIPPET6>
        private void DisplayMetaDescription()
        {
            if (webBrowser1.Document != null)
            {
                HtmlElementCollection elems = webBrowser1.Document.GetElementsByTagName("META");
                foreach (HtmlElement elem in elems)
                {
                    String nameStr = elem.GetAttribute("name");
                    if (nameStr != null && nameStr.Length != 0)
                    {
                        String contentStr = elem.GetAttribute("content");
                        MessageBox.Show("Document: " + webBrowser1.Url.ToString() + "\nDescription: " + contentStr);
                    }
                }
            }
        }
        //</SNIPPET6>

        //<SNIPPET7>
        private void Document_Click(Object sender, HtmlElementEventArgs e)
        {
            if (webBrowser1.Document != null)
            {
                HtmlElement elem = webBrowser1.Document.GetElementFromPoint(e.ClientMousePosition);
                elem.ScrollIntoView(true);
            }
        }
        //</SNIPPET7>

        //<SNIPPET8>
        private string[] GetImageUrls()
        {
            if (webBrowser1.Document != null)
            {
                HtmlDocument doc = webBrowser1.Document;
                string[] urls = (string[])Array.CreateInstance(Type.GetType("System.String"), doc.Images.Count);

                foreach (HtmlElement imgElement in doc.Images)
                {
                    urls[urls.Length] = imgElement.GetAttribute("src");
                }
                return (urls);
            }
            else
            {
                return (new string[0]);
            }
        }
        //</SNIPPET8>

        //<SNIPPET9>
        private void InvokeTestMethod(String name, String address)
        {
            if (webBrowser1.Document != null)
            {
                Object[] objArray = new Object[2];
                objArray[0] = (Object)name;
                objArray[1] = (Object)address;
                webBrowser1.Document.InvokeScript("test", objArray);
            }
        }
        //</SNIPPET9>

        //<SNIPPET10>
        private void DisplayCustomersTable()
        {
            DataSet customersSet = new DataSet();
            DataTable customersTable = null;
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Customers", "Data Source=localhost;Integrated Security=SSPI;Initial Catalog=Northwind;");
            sda.Fill(customersTable);
            customersTable = customersSet.Tables[0];

            if (webBrowser1.Document != null)
            {
                HtmlElement tableRow = null;
                HtmlElement headerElem = null;

		//<SNIPPET17>
                HtmlDocument doc = webBrowser1.Document;
                HtmlElement tableElem = doc.CreateElement("TABLE");
                doc.Body.AppendChild(tableElem);
		//</SNIPPET17>

                HtmlElement tableHeader = doc.CreateElement("THEAD");
                tableElem.AppendChild(tableHeader);
                tableRow = doc.CreateElement("TR");
                tableHeader.AppendChild(tableRow);

                foreach (DataColumn col in customersTable.Columns)
                {
                    headerElem = doc.CreateElement("TH");
                    headerElem.InnerText = col.ColumnName;
                    tableRow.AppendChild(headerElem);
                }

                // Create table rows.
                HtmlElement tableBody = doc.CreateElement("TBODY");
                tableElem.AppendChild(tableBody);
                foreach (DataRow dr in customersTable.Rows)
                {
                    tableRow = doc.CreateElement("TR");
                    tableBody.AppendChild(tableRow);
                    foreach (DataColumn col in customersTable.Columns)
                    {
                        Object dbCell = dr[col];
                        HtmlElement tableCell = doc.CreateElement("TD");
                        if (!(dbCell is DBNull))
                        {
                            tableCell.InnerText = dbCell.ToString();
                        }
                        tableRow.AppendChild(tableCell);
                    }
                }
            }
        }
        //</SNIPPET10>

        //<SNIPPET11>
        private void WriteNewDocument()
        {
            if (webBrowser1.Document != null)
            {
                HtmlDocument doc = webBrowser1.Document.OpenNew(true);
                doc.Write("<HTML><BODY>This is a new HTML document.</BODY></HTML>");
            }
        }
        //</SNIPPET11>

        //<SNIPPET12>
        private void InvokeScript()
        {
            if (webBrowser1.Document != null)
            {
                HtmlDocument doc = webBrowser1.Document;
                String str = doc.InvokeScript("test").ToString() ;
                Object jscriptObj = doc.InvokeScript("testJScriptObject");
                Object domOb = doc.InvokeScript("testElement");
            }
        }
        //</SNIPPET12>


        //<SNIPPET13>
        private void AppendText(String text)
        {
            if (webBrowser1.Document != null)
            {
                HtmlDocument doc = webBrowser1.Document;
                HtmlElement textElem = doc.CreateElement("DIV");
                textElem.InnerText = text;
                doc.Body.AppendChild(textElem);
            }
        }
        //</SNIPPET13>

        //<SNIPPET14>
        private void ExportDocumentLink()
        {
            if (webBrowser1.Document != null)
            {
                HtmlDocument doc = webBrowser1.Document;
                String link = "<A HREF=\"" + webBrowser1.Document.Url.ToString() + "\">" + webBrowser1.Document.Title + "</A>";

                IDataObject dataObj = Clipboard.GetDataObject();
                dataObj.SetData("HTML", true, (object)link);
            }
        }
        //</SNIPPET14>

        private void GetTableRowCountButton_Click(object sender, EventArgs e)
        {
            GetTableRowCount("table1");
        }

        private void DisplayMetaButton_Click(object sender, EventArgs e)
        {
            DisplayMetaDescription();
        }

        private void ActivateDragLogic()
        {
            HtmlDocument doc = null;
            if (webBrowser1.Document != null)
            {
                doc = webBrowser1.Document;
                doc.MouseDown += new HtmlElementEventHandler(doc_MouseDown);
                doc.MouseUp += new HtmlElementEventHandler(doc_MouseUp);
                doc.MouseMove += new HtmlElementEventHandler(doc_MouseMove);
            }
        }

        void doc_MouseDown(object sender, HtmlElementEventArgs e)
        {
            HtmlDocument doc = webBrowser1.Document;
        }

        void doc_MouseUp(object sender, HtmlElementEventArgs e)
        {
            
        }

        void doc_MouseMove(object sender, HtmlElementEventArgs e)
        {
            
        }

        //<SNIPPET15>
        ContextMenuStrip menuStrip = null;

        public void DetectContextMenu()
        {
            if (webBrowser1.Document != null)
            {
                webBrowser1.Document.ContextMenuShowing += new HtmlElementEventHandler(Document_ContextMenuShowing);
                menuStrip = new ContextMenuStrip();
                menuStrip.Items.Add("&Custom menu item...");
            }
        }

        void Document_ContextMenuShowing(object sender, HtmlElementEventArgs e)
        {
            menuStrip.Show(e.MousePosition);
            e.ReturnValue = false;
        }
        //</SNIPPET15>

        private void button1_Click(object sender, EventArgs e)
        {
            DetectContextMenu();
        }

        /*//<SNIPPET16>
        public void SnipSelected()
        {
            if (webBrowser1.Document != null)
            {
                object o;
                webBrowser1.Document.ExecCommand("Copy", false, o);
                string selected = (string)o;
                if (selected != null && selected.Length > 0)
                {
                    MessageBox.Show("Selected text: " + selected);
                }
            }
        }*/
        //</SNIPPET16>

        private void button2_Click(object sender, EventArgs e)
        {
            // SnipSelected();
        }
    }
}