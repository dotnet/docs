using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Xps.Packaging;

namespace SDKSample
{
    /// <summary>
    /// A Dialog that diplays and allows editing of the properties
    /// of an Xps Document
    /// </summary>
    public partial class PropertiesDialog : Form
    {
        public PropertiesDialog(XpsDocument xpsDocument )
        {
            _xpsDocument = xpsDocument;
            _propertyUtility = new PropertiesUtility();
            InitializeComponent();
            _propertyUtility.ReadProperties(_xpsDocument, this);
        }
        XpsDocument _xpsDocument;

        private void Ok_Click(object sender, EventArgs e)
        {
            _propertyUtility.WriteProperties(_xpsDocument, this);
        }

        private PropertiesUtility _propertyUtility;
    }
}