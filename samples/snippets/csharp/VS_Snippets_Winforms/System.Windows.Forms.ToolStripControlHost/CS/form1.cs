using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace System.Windows.Forms.ToolStripControlHostExample
{	
	public partial class Form1 : System.Windows.Forms.Form
	{	
		private System.ComponentModel.IContainer components = null;
		private ToolStripTextBox textbox1;
		public Form1()
		{
			InitializeComponent();
			InitializeDropDownMonthCalendar();
			textbox1 = new ToolStripTextBox();
			textbox1.Width = 70;
			toolStrip1.Items.Add(textbox1);
			InitializeDateTimePickerHost();
			
		}
		static void Main()
		{
			Application.Run(new Form1());
		}
		
		private void InitializeComponent()
		{
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.ToolStripPanel1 = new System.Windows.Forms.ToolStripPanel();
			this.SuspendLayout();
// 
// toolStrip1
// 
			this.toolStrip1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			this.toolStrip1.Visible = true;
// 
// ToolStripPanel1
// 
			this.ToolStripPanel1.AutoSize = true;
			this.ToolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ToolStripPanel1.Location = new System.Drawing.Point(9, 9);
			this.ToolStripPanel1.Name = "ToolStripPanel1";
			this.ToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.ToolStripPanel1.RowMargin = new System.Windows.Forms.Padding(0);
			this.ToolStripPanel1.Size = new System.Drawing.Size(274, 25);
			this.ToolStripPanel1.TabIndex = 0;
			this.ToolStripPanel1.Text = "ToolStripPanelToolStripPanelTop";
			this.ToolStripPanel1.Join(this.toolStrip1);
// 
// Form1
// 
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.ToolStripPanel1);
			this.Name = "Form1";
			this.Padding = new System.Windows.Forms.Padding(9);
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripPanel ToolStripPanel1;

		// The following snippet demonstrates the ToolStripControlHost(Control)
		// constructor, the ToolStripControlHost.Font, Width, DisplayStyle,
		// Text properties.
		//<snippet1>
		ToolStripControlHost dateTimePickerHost;

		private void InitializeDateTimePickerHost()
		{

			// Create a new ToolStripControlHost, passing in a control.
			dateTimePickerHost = new ToolStripControlHost(new DateTimePicker());

			// Set the font on the ToolStripControlHost, this will affect the hosted control.
			dateTimePickerHost.Font = new Font("Arial", 7.0F, FontStyle.Italic);

			// Set the Width property, this will also affect the hosted control.
			dateTimePickerHost.Width = 100;
			dateTimePickerHost.DisplayStyle = ToolStripItemDisplayStyle.Text;

			// Setting the Text property requires a string that converts to a 
			// DateTime type since that is what the hosted control requires.
			dateTimePickerHost.Text = "12/23/2005";

			// Cast the Control property back to the original type to set a 
			// type-specific property.
			((DateTimePicker)dateTimePickerHost.Control).Format = DateTimePickerFormat.Short;

			// Add the control host to the ToolStrip.
			toolStrip1.Items.Add(dateTimePickerHost);

		}
		//</snippet1>

		// The following example shows how to set the custom 
		// ToolStripMonthCalendar control.
		//<snippet2>
		private void InitializeDropDownMonthCalendar()
		{
			// Declare the drop-down button and the drop-down.
			ToolStripDropDownButton dropDownButton2 = new ToolStripDropDownButton();

			// Set the image to the MonthCalendar embedded bitmap
			// image.
			dropDownButton2.Image = new Bitmap(typeof(MonthCalendar), "MonthCalendar.bmp");

			// Add the button to the ToolStrip.
			toolStrip1.Items.Add(dropDownButton2);

			// Construct a new drop-down.
			ToolStripDropDown dropDown = new ToolStripDropDown();

			// Construct a new wrapped MonthCalendar control.
			ToolStripMonthCalendar monthCalendar = new ToolStripMonthCalendar();

			// Set a date in boldface.
			monthCalendar.AddBoldedDate(DateTime.Today.AddDays(7));

            // Handle the DateChanged event.
			monthCalendar.DateChanged += new DateRangeEventHandler(monthCalendar_DateChanged);
			
            //Add the calendar to the drop-down.
			dropDown.Items.Add(monthCalendar);
			
			//Set the drop-down on the DropDownButton.
			dropDownButton2.DropDown = dropDown;
		}
		

		private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
		{
			textbox1.Text = e.Start.ToShortDateString();
		}
        //</snippet2>
	}

    // The following example shows how to wrap a control
	// using ToolStripControlHost.
	//<snippet13>
	//Declare a class that inherits from ToolStripControlHost.
	public class ToolStripMonthCalendar : ToolStripControlHost
	{
		//<snippet10>
		// Call the base constructor passing in a MonthCalendar instance.
		public ToolStripMonthCalendar() : base (new MonthCalendar()) { }
		//</snippet10>

		//<snippet11>
		public MonthCalendar MonthCalendarControl
		{
			get
			{
				return Control as MonthCalendar;
			}
		}
		//</snippet11>

		//<snippet12>
		// Expose the MonthCalendar.FirstDayOfWeek as a property.
		public Day FirstDayOfWeek
		{
			get
			{
				return MonthCalendarControl.FirstDayOfWeek;
			}
			set { MonthCalendarControl.FirstDayOfWeek = value; }
		}

		// Expose the AddBoldedDate method.
		public void AddBoldedDate(DateTime dateToBold)
		{
			MonthCalendarControl.AddBoldedDate(dateToBold);
		}
		//</snippet12>

		// Subscribe and unsubscribe the control events you wish to expose.
		//<snippet16>
		//<snippet14>
		protected override void OnSubscribeControlEvents(Control c)
		{
			// Call the base so the base events are connected.
			base.OnSubscribeControlEvents(c);

			// Cast the control to a MonthCalendar control.
			MonthCalendar monthCalendarControl = (MonthCalendar) c;

			// Add the event.
			monthCalendarControl.DateChanged +=
				new DateRangeEventHandler(OnDateChanged);
		}
		//</snippet14>

		//<snippet15>
		protected override void OnUnsubscribeControlEvents(Control c)
		{
			// Call the base method so the basic events are unsubscribed.
			base.OnUnsubscribeControlEvents(c);

			// Cast the control to a MonthCalendar control.
			MonthCalendar monthCalendarControl = (MonthCalendar) c;

			// Remove the event.
			monthCalendarControl.DateChanged -=
				new DateRangeEventHandler(OnDateChanged);
		}
		//</snippet15>
		//</snippet16>

		//<snippet17>
		// Declare the DateChanged event.
		public event DateRangeEventHandler DateChanged;

		// Raise the DateChanged event.
		private void OnDateChanged(object sender, DateRangeEventArgs e)
		{
			if (DateChanged != null)
			{
				DateChanged(this, e);
			}
		}
		//</snippet17>
	}
	//</snippet13>
}

