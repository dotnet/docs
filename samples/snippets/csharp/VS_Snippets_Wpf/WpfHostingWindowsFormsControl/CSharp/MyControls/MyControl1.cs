// <snippet1>
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace MyControls
{
    /// <summary>
    /// Summary description for UserControl1.
    /// </summary>
    public class MyControl1 : System.Windows.Forms.UserControl
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public MyControl1()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitComponent call

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Street Address";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 127);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "City";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(246, 127);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "State";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(23, 167);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Zip";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(135, 44);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(199, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(136, 84);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(198, 20);
            this.txtAddress.TabIndex = 1;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(136, 123);
            this.txtCity.Name = "txtCity";
            this.txtCity.TabIndex = 2;
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(300, 123);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(33, 20);
            this.txtState.TabIndex = 3;
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(135, 163);
            this.txtZip.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.txtZip.Name = "txtZip";
            this.txtZip.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(23, 207);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(157, 207);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(66, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(226, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Simple Windows Forms Control";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MyControl1
            // 
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtZip);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MyControl1";
            this.Size = new System.Drawing.Size(359, 244);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        // <snippet2>
        public delegate void MyControlEventHandler(object sender, MyControlEventArgs args);
        public event MyControlEventHandler OnButtonClick;
        // </snippet2>

        // <snippet4>
        private void btnOK_Click(object sender, System.EventArgs e)
        {

            MyControlEventArgs retvals = new MyControlEventArgs(true,
                                                                 txtName.Text,
                                                                 txtAddress.Text,
                                                                 txtCity.Text,
                                                                 txtState.Text,
                                                                 txtZip.Text);
            OnButtonClick(this, retvals);
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            MyControlEventArgs retvals = new MyControlEventArgs(false,
                                                                 txtName.Text,
                                                                 txtAddress.Text,
                                                                 txtCity.Text,
                                                                 txtState.Text,
                                                                 txtZip.Text);
            OnButtonClick(this, retvals);
        }
        // </snippet4>
    }

    // <snippet3>
    public class MyControlEventArgs : EventArgs
    {
        private string _Name;
        private string _StreetAddress;
        private string _City;
        private string _State;
        private string _Zip;
        private bool _IsOK;

        public MyControlEventArgs(bool result,
                                       string name,
                                       string address,
                                       string city,
                                       string state,
                                       string zip)
        {
            _IsOK = result;
            _Name = name;
            _StreetAddress = address;
            _City = city;
            _State = state;
            _Zip = zip;
        }

        public string MyName
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string MyStreetAddress
        {
            get { return _StreetAddress; }
            set { _StreetAddress = value; }
        }
        public string MyCity
        {
            get { return _City; }
            set { _City = value; }
        }
        public string MyState
        {
            get { return _State; }
            set { _State = value; }
        }
        public string MyZip
        {
            get { return _Zip; }
            set { _Zip = value; }
        }
        public bool IsOK
        {
            get { return _IsOK; }
            set { _IsOK = value; }
        }
    }
    // </snippet3>
}
// </snippet1>