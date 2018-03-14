//<Snippet1>
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Data;

/* This sample uses the ServiceContainer class, which implements 
    the IServiceContainer interface.  It creates a service container 
    and stores services of type Control in it.

    When the application is run, it adds control services at two
    times:  when button2 is clicked and when a radio button is
    clicked.  It adds the controls to the container by calling each
    of two overloaded versions of IServiceContainer.AddService().

    Pressing button1 invokes the button1 handler, which is
    button1_Click().  In turn, this invokes a method based on
    whether or not button2 or a radio button has been selected.
    If one of these two button types has been selected, then its
    service has been added to the service container.  In this case,
    button1_Click() gets the current service, which invokes the
    method that was associated with this service when the service
    was added to the container.  If a radio button is current, the
    system updates the text of that radio button with the given text.
    If button2 is current, the system calls CreateNewControl(), which
    creates a new control with the given text.

    Pressing button2 invokes the button2 handler, which adds a service
    to the container by passing in a service creator callback.  This
    enables this action to invoke the event handler that the developer
    specifies.  In this case, the sample invokes CreateNewControl(),
    which creates and maintains label controls, and displays them in
    the same group box that the buttons are in.

    Clicking a radio button has the effect of adding that radio button
    to the service container.
*/

namespace ServiceContainerExample
{
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;

        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button button2;
        ServiceContainer m_MyServiceContainer;

        int m_nLabelCount;

        public Form1()
        {
            m_MyServiceContainer = new ServiceContainer();

            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
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

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                this.button2,
                                                this.radioButton4,
                                                this.radioButton3,
                                                this.radioButton2,
                                                this.radioButton1});
            this.groupBox1.Location = new System.Drawing.Point(8, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 200);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(40, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 26);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // radioButton4
            // 
            this.radioButton4.Location = new System.Drawing.Point(32, 112);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Text = "radioButton4";
            this.radioButton4.CheckedChanged += new System.
                        EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(32, 80);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "radioButton3";
            this.radioButton3.CheckedChanged += new System.
                        EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(32, 48);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.CheckedChanged += new System.
                        EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(32, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.CheckedChanged += new System.
                        EventHandler(this.radioButton1_CheckedChanged);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(292, 272);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                    this.groupBox1,
                                    this.button1});
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion

        // The main entry point for the application.
        [STAThread]
        static void Main() 
        {
            Application.Run(new Form1());
        }

        private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            /* The application never displays this control so a generic
                type of Control is fine */
            m_MyServiceContainer.RemoveService(typeof(Control));
//<Snippet2>
            m_MyServiceContainer.AddService(typeof(Control), sender);
//</Snippet2>
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            /* Get the current control, if one is current.  Here it's either a
                push button or a radio control */
            Control c = (Control)m_MyServiceContainer.GetService(typeof(Control));
            if (c != null) 
            {
                // Update the text of whichever control is currently selected.
                c.Text = "Button1 clicked";
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            /* ServiceContainer will throw an excpetion if a duplicate service
                is added so remove it before we add */
//<Snippet4>
            m_MyServiceContainer.RemoveService(typeof(Control));
//</Snippet4>

            /* Whenever button2 is pressed, attach the callback method to the service
                and add the service to the container.  This causes any update to
                invoke CreateNewControl() when button1 is pressed */
//<Snippet3>
            m_MyServiceContainer.AddService(typeof(Control),
                            new ServiceCreatorCallback(this.CreateNewControl));
//</Snippet3>
        }

        /* If the application arrives at this method, it means that in button1_Click(),
            GetService() was passed the service that corresponds to button2.  This has
            the effect of invoking the service creator callback for button2, which is
            the method CreateNewControl(), and which was mapped in button2_Click(). */
        private object CreateNewControl(IServiceContainer container, Type serviceType) 
        {
            Control c = new Label();
            c.Size = radioButton1.Size;
            Point loc = button2.Location;

            loc.X = 160;
            loc.Y = 20 + 25 * m_nLabelCount;

            c.Location = loc;
            groupBox1.Controls.Add(c);

            ++m_nLabelCount;

            return c;
        }
    }
}
//</Snippet1>
