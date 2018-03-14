

using System.Drawing.Printing;
using System;
using System.Windows.Forms;
using System.Drawing;

public class Form1 :
    System.Windows.Forms.Form
{
    public static void Main()
    {
        Application.Run(new Form1());
    }
    public Form1()
    {
        this.Load +=new EventHandler(Form1_Load);
    }

//<snippet1>
    private ComboBox comboInstalledPrinters = new ComboBox();
    private PrintDocument printDoc = new PrintDocument();

    private void PopulateInstalledPrintersCombo()
    {
        comboInstalledPrinters.Dock = DockStyle.Top;
        Controls.Add(comboInstalledPrinters);

        // Add list of installed printers found to the combo box.
        // The pkInstalledPrinters string will be used to provide the display string.
        int i;
        string pkInstalledPrinters;

        for (i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
        {
            pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
            comboInstalledPrinters.Items.Add(pkInstalledPrinters);
            if (printDoc.PrinterSettings.IsDefaultPrinter)
            {
                comboInstalledPrinters.Text = printDoc.PrinterSettings.PrinterName;
            }
        }
    }
//</snippet1>

    private void Form1_Load(object sender, System.EventArgs e)
    {
        PopulateInstalledPrintersCombo();
    }
}






