#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace ValidatingTypeSampleCSharp
{
	partial class Form1: Form
	{
		public Form1()
		{
			InitializeComponent();
		}

        //<SNIPPET1>
        private void Form1_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Mask = "00/00/0000";
            maskedTextBox1.ValidatingType = typeof(System.DateTime);
            maskedTextBox1.TypeValidationCompleted += new TypeValidationEventHandler(maskedTextBox1_TypeValidationCompleted);
            maskedTextBox1.KeyDown += new KeyEventHandler(maskedTextBox1_KeyDown);

            toolTip1.IsBalloon = true;
        }

        void maskedTextBox1_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                toolTip1.ToolTipTitle = "Invalid Date";
                toolTip1.Show("The data you supplied must be a valid date in the format mm/dd/yyyy.", maskedTextBox1, 0, -20, 5000);
            }
            else
            {
                //Now that the type has passed basic type validation, enforce more specific type rules.
                DateTime userDate = (DateTime)e.ReturnValue;
                if (userDate < DateTime.Now)
                {
                    toolTip1.ToolTipTitle = "Invalid Date";
                    toolTip1.Show("The date in this field must be greater than today's date.", maskedTextBox1, 0, -20, 5000);
                    e.Cancel = true;
                }
            }
        }

        // Hide the tooltip if the user starts typing again before the five-second display limit on the tooltip expires.
        void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            toolTip1.Hide(maskedTextBox1);
        }
        //</SNIPPET1>
    }
}