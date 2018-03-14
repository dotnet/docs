using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XpsApiSdk
{
    public partial class SignatureDialog : Form
    {
        public SignatureDialog()
        {
            InitializeComponent();
            Font columnHeaderFont = new System.Drawing.Font(Font, System.Drawing.FontStyle.Bold);
            Padding columnMargin = new Padding(0, 3, 0, 0);
            Padding columnPadding = new Padding(10, 0, 0, 0);
            Label nameHeader = new Label();
            nameHeader.Text = "Name";
            nameHeader.Font = columnHeaderFont;
            nameHeader.MinimumSize = new Size(16 + 100, 0);
            nameHeader.Margin = columnMargin;
            nameHeader.Padding = columnPadding;

            Label intentHeader = new Label();
            intentHeader.Text ="Intent";
            intentHeader.Font = columnHeaderFont;
            intentHeader.MinimumSize = new Size(100, 0);
            intentHeader.Margin = columnMargin;
            intentHeader.Padding = columnPadding;

            Label locationHeader = new Label();
            locationHeader.Text = "Locale";
            locationHeader.Font = columnHeaderFont;
            locationHeader.MinimumSize = new Size(100, 0);
            locationHeader.Margin = columnMargin;
            locationHeader.Padding = columnPadding;

            Label signByHeader = new Label();
            signByHeader.Text = "Sign By";
            signByHeader.Font = columnHeaderFont;
            signByHeader.MinimumSize = new Size(100, 0);
            signByHeader.Margin = columnMargin;
            signByHeader.Padding = columnPadding;

            ColumnHeader.Controls.Add(nameHeader);
            ColumnHeader.Controls.Add(intentHeader);
            ColumnHeader.Controls.Add(locationHeader);
            ColumnHeader.Controls.Add(signByHeader);
        }
    }
}