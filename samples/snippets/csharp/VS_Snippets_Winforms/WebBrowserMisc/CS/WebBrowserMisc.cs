using System;
using System.Windows.Forms;
using System.Security.Permissions;

[PermissionSetAttribute(SecurityAction.Demand, Name="FullTrust")]
public class Form1 : Form
{
    [STAThread]
    public static void Main()
    {
        Application.Run(new Form1());
    }

    private Button button = new Button();

    public Form1()
    {
        button.Click += new EventHandler(button_Click);
        this.Controls.Add(button);
        this.Controls.Add(webBrowser1);
    }

    void button_Click(object sender, EventArgs e)
    {
        PrintHelpPage();
    }

    //<snippet10>
    private void PrintHelpPage()
    {
        // Create a WebBrowser instance. 
        WebBrowser webBrowserForPrinting = new WebBrowser();

        // Add an event handler that prints the document after it loads.
        webBrowserForPrinting.DocumentCompleted +=
            new WebBrowserDocumentCompletedEventHandler(PrintDocument);

        // Set the Url property to load the document.
        webBrowserForPrinting.Url = new Uri(@"\\myshare\help.html");
    }

    private void PrintDocument(object sender,
        WebBrowserDocumentCompletedEventArgs e)
    {
        // Print the document now that it is fully loaded.
        ((WebBrowser)sender).Print();

        // Dispose the WebBrowser now that the task is complete. 
        ((WebBrowser)sender).Dispose();
    }
    //</snippet10>

    private WebBrowser webBrowser1 = new WebBrowser();

    private void InitializeHtmlViewer()
    {
        //<snippet20>
        webBrowser1.AllowWebBrowserDrop = false;
        //</snippet20>

        //<snippet21>
        webBrowser1.Url = new Uri("http://www.contoso.com/");
        //</snippet21>
    }

    //<snippet30>
    private void Form1_Load(object sender, EventArgs e)
    {
        webBrowser1.DocumentText =
            "<html><body>Please enter your name:<br/>" +
            "<input type='text' name='userName'/><br/>" +
            "<a href='http://www.microsoft.com'>continue</a>" +
            "</body></html>";
        webBrowser1.Navigating += 
            new WebBrowserNavigatingEventHandler(webBrowser1_Navigating);
    }

    private void webBrowser1_Navigating(object sender, 
        WebBrowserNavigatingEventArgs e)
    {
        System.Windows.Forms.HtmlDocument document =
            this.webBrowser1.Document;

        if (document != null && document.All["userName"] != null && 
            String.IsNullOrEmpty(
            document.All["userName"].GetAttribute("value")))
        {
            e.Cancel = true;
            System.Windows.Forms.MessageBox.Show(
                "You must enter your name before you can navigate to " +
                e.Url.ToString());
        }
    }
    //</snippet30>

    //<snippet40>
    // Hides script errors without hiding other dialog boxes.
    private void SuppressScriptErrorsOnly(WebBrowser browser)
    {
        // Ensure that ScriptErrorsSuppressed is set to false.
        browser.ScriptErrorsSuppressed = false;

        // Handle DocumentCompleted to gain access to the Document object.
        browser.DocumentCompleted +=
            new WebBrowserDocumentCompletedEventHandler(
                browser_DocumentCompleted);
    }

    private void browser_DocumentCompleted(object sender, 
        WebBrowserDocumentCompletedEventArgs e)
    {
        ((WebBrowser)sender).Document.Window.Error += 
            new HtmlElementErrorEventHandler(Window_Error);
    }

    private void Window_Error(object sender, 
        HtmlElementErrorEventArgs e)
    {
        // Ignore the error and suppress the error dialog box. 
        e.Handled = true;
    }
    //</snippet40>

}
