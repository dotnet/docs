//<snippet0>
using System;
using System.Windows.Forms;
using System.Security.Permissions;

[PermissionSet(SecurityAction.Demand, Name="FullTrust")]
[System.Runtime.InteropServices.ComVisibleAttribute(true)]
public class Form1 : Form
{
    private WebBrowser webBrowser1 = new WebBrowser();
    private Button button1 = new Button();

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }

    public Form1()
    {
        button1.Text = "call script code from client code";
        button1.Dock = DockStyle.Top;
        button1.Click += new EventHandler(button1_Click);
        webBrowser1.Dock = DockStyle.Fill;
        Controls.Add(webBrowser1);
        Controls.Add(button1);
        Load += new EventHandler(Form1_Load);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        //<snippet1>
        webBrowser1.AllowWebBrowserDrop = false;
        //</snippet1>
        //<snippet2>
        webBrowser1.IsWebBrowserContextMenuEnabled = false;
        //</snippet2>
        //<snippet3>
        webBrowser1.WebBrowserShortcutsEnabled = false;
        //</snippet3>
        //<snippet4>
        webBrowser1.ObjectForScripting = this;
        //</snippet4>
        //<snippet9>
        // Uncomment the following line when you are finished debugging.
        //webBrowser1.ScriptErrorsSuppressed = true;
        //</snippet9>

        webBrowser1.DocumentText =
            "<html><head><script>" +
            "function test(message) { alert(message); }" +
            "</script></head><body><button " +
            "onclick=\"window.external.Test('called from script code')\">" +
            "call client code from script code</button>" +
            "</body></html>";
    }

    //<snippet5>
    public void Test(String message)
    {
        MessageBox.Show(message, "client code");
    }
    //</snippet5>

    private void button1_Click(object sender, EventArgs e)
    {
        //<snippet8>
        webBrowser1.Document.InvokeScript("test",
            new String[] { "called from client code" });
        //</snippet8>
    }

}
//</snippet0>