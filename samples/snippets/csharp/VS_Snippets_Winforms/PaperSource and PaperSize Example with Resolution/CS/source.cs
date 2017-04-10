using System;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace WindowsApplication3
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        // my vars
        PrintDocument printDoc = new PrintDocument();
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button MyButtonPrint;
        private System.Windows.Forms.ComboBox comboPaperSize;
        private System.Windows.Forms.ComboBox comboPaperSource;
        private System.Windows.Forms.ComboBox comboPrintResolution;
        private System.Windows.Forms.ComboBox comboInstalledPrinters;
        private System.Windows.Forms.Label label4;

        private System.ComponentModel.Container components = null;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            // Setup the event handlers
            printDoc.QueryPageSettings += new QueryPageSettingsEventHandler(this.MyPrintQueryPageSettingsEvent);
            printDoc.PrintPage += new PrintPageEventHandler(this.MyPrintPageEvent);

/*            // Other way to specify custom paper size is to set the paper kind and related properties.
            PaperSize pkCustomSize2 = new PaperSize();
            pkCustomSize2.Kind = PaperSourceKind.Custom;
            pkCustomSize2.PaperName = "Other custom size";
            pkCustomSize2.Width = 100;
            pkCustomSize2.Height = 200;
            
            comboPaperSize.Items.Add(pkCustomSize2);

*/

            // <Snippet1>
            // Add list of supported paper sizes found on the printer. 
            // The DisplayMember property is used to identify the property that will provide the display string.
            comboPaperSize.DisplayMember = "PaperName";

            PaperSize pkSize;
            for (int i = 0; i < printDoc.PrinterSettings.PaperSizes.Count; i++){
                pkSize = printDoc.PrinterSettings.PaperSizes[i];
                comboPaperSize.Items.Add(pkSize);
            }

            // Create a PaperSize and specify the custom paper size through the constructor and add to combobox.
            PaperSize pkCustomSize1 = new PaperSize("First custom size", 100, 200);

            comboPaperSize.Items.Add(pkCustomSize1);

            // </Snippet1>

            // <Snippet2>
            // Add list of paper sources found on the printer to the combo box.
            // The DisplayMember property is used to identify the property that will provide the display string.
            comboPaperSource.DisplayMember="SourceName";

            PaperSource pkSource;
            for (int i = 0; i < printDoc.PrinterSettings.PaperSources.Count; i++){
                pkSource = printDoc.PrinterSettings.PaperSources[i];
                comboPaperSource.Items.Add(pkSource);
            }
            // </Snippet2>

            // <Snippet3>
            // Add list of printer resolutions found on the printer to the combobox.
            // The PrinterResolution's ToString() method will be used to provide the display string.

            PrinterResolution pkResolution;
            for (int i = 0; i < printDoc.PrinterSettings.PrinterResolutions.Count; i++){
                pkResolution = printDoc.PrinterSettings.PrinterResolutions[i];
                comboPrintResolution.Items.Add(pkResolution);
            }
            // </Snippet3>

            PopulateInstalledPrintersCombo();
        }

        // <Snippet5>
        private void PopulateInstalledPrintersCombo()
        {
            // Add list of installed printers found to the combo box.
            // The pkInstalledPrinters string will be used to provide the display string.
            String pkInstalledPrinters;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++){
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                comboInstalledPrinters.Items.Add(pkInstalledPrinters);
            }
        }

        private void comboInstalledPrinters_SelectionChanged(object sender, System.EventArgs e)
        {

            // Set the printer to a printer in the combo box when the selection changes.

            if (comboInstalledPrinters.SelectedIndex != -1) 
            {
                // The combo box's Text property returns the selected item's text, which is the printer name.
                printDoc.PrinterSettings.PrinterName= comboInstalledPrinters.Text;
            }

        }
        // </Snippet5>

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboPrintResolution = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboInstalledPrinters = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboPaperSize = new System.Windows.Forms.ComboBox();
            this.comboPaperSource = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MyButtonPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboPrintResolution
            // 
            this.comboPrintResolution.DropDownWidth = 121;
            this.comboPrintResolution.Location = new System.Drawing.Point(104, 72);
            this.comboPrintResolution.Name = "comboPrintResolution";
            this.comboPrintResolution.Size = new System.Drawing.Size(121, 21);
            this.comboPrintResolution.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 104);
            this.label4.Name = "label4";
            this.label4.TabIndex = 4;
            this.label4.Text = "Installed Printers";
            // 
            // comboInstalledPrinters
            // 
            this.comboInstalledPrinters.DropDownWidth = 120;
            this.comboInstalledPrinters.Location = new System.Drawing.Point(104, 104);
            this.comboInstalledPrinters.Name = "comboInstalledPrinters";
            this.comboInstalledPrinters.Size = new System.Drawing.Size(120, 21);
            this.comboInstalledPrinters.TabIndex = 5;
            this.comboInstalledPrinters.SelectedIndexChanged += new System.EventHandler(this.comboInstalledPrinters_SelectionChanged);
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Paper Sizes";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 72);
            this.label3.Name = "label3";
            this.label3.TabIndex = 4;
            this.label3.Text = "Printer Resolution";
            // 
            // comboPaperSize
            // 
            this.comboPaperSize.DropDownWidth = 121;
            this.comboPaperSize.Location = new System.Drawing.Point(80, 8);
            this.comboPaperSize.Name = "comboPaperSize";
            this.comboPaperSize.Size = new System.Drawing.Size(121, 21);
            this.comboPaperSize.TabIndex = 0;
            // 
            // comboPaperSource
            // 
            this.comboPaperSource.DropDownWidth = 121;
            this.comboPaperSource.Location = new System.Drawing.Point(80, 40);
            this.comboPaperSource.Name = "comboPaperSource";
            this.comboPaperSource.Size = new System.Drawing.Size(121, 21);
            this.comboPaperSource.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(8, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Paper Source";
            // 
            // MyButtonPrint
            // 
            this.MyButtonPrint.Location = new System.Drawing.Point(208, 8);
            this.MyButtonPrint.Name = "MyButtonPrint";
            this.MyButtonPrint.TabIndex = 2;
            this.MyButtonPrint.Text = "Print";
            this.MyButtonPrint.Click += new System.EventHandler(this.MyButtonPrint_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(292, 133);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.comboInstalledPrinters,
                                                                          this.comboPrintResolution,
                                                                          this.label3,
                                                                          this.comboPaperSource,
                                                                          this.MyButtonPrint,
                                                                          this.label1,
                                                                          this.comboPaperSize,
                                                                          this.label2,
                                                                          this.label4});
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.Run(new Form1());
        }

    // <Snippet4>
    private void MyButtonPrint_Click(object sender, System.EventArgs e)
    {
        // Set the paper size based upon the selection in the combo box.
        if (comboPaperSize.SelectedIndex != -1) {
            printDoc.DefaultPageSettings.PaperSize = 
                printDoc.PrinterSettings.PaperSizes[comboPaperSize.SelectedIndex];
        }

        // Set the paper source based upon the selection in the combo box.
        if (comboPaperSource.SelectedIndex != -1) {
            printDoc.DefaultPageSettings.PaperSource = 
                printDoc.PrinterSettings.PaperSources[comboPaperSource.SelectedIndex];
        }
        
        // Set the printer resolution based upon the selection in the combo box.
        if (comboPrintResolution.SelectedIndex != -1) 
        {
            printDoc.DefaultPageSettings.PrinterResolution= 
                printDoc.PrinterSettings.PrinterResolutions[comboPrintResolution.SelectedIndex];
        }

        // Print the document with the specified paper size, source, and print resolution.
        printDoc.Print();
    }
    // </Snippet4>

    protected int currentPageNumber = 1;
    // <Snippet6>

    private void MyButtonPrint_OnClick(object sender, System.EventArgs e)
    {
        
        // Set the printer name and ensure it is valid. If not, provide a message to the user.
        printDoc.PrinterSettings.PrinterName = "\\mynetworkprinter";

        if (printDoc.PrinterSettings.IsValid) {
        
            // If the printer supports printing in color, then override the printer's default behavior.
            if (printDoc.PrinterSettings.SupportsColor) {

                // Set the page default's to not print in color.
                printDoc.DefaultPageSettings.Color = false;
            }

            // Provide a friendly name, set the page number, and print the document.
            printDoc.DocumentName = "My Presentation";
            currentPageNumber = 1;
            printDoc.Print();
        }
        else {
            MessageBox.Show("Printer is not valid");
        }
    }

    private void MyPrintQueryPageSettingsEvent(object sender, QueryPageSettingsEventArgs e)
    {
        // Determines if the printer supports printing in color.
        if (printDoc.PrinterSettings.SupportsColor) {

            // If the printer supports color printing, use color.
            if (currentPageNumber == 1 ) {

                e.PageSettings.Color = true;
            }

        }    
    }
    //</Snippet6>

    private void MyPrintPageEvent(object sender, PrintPageEventArgs e)
    {
    }

    }
}
