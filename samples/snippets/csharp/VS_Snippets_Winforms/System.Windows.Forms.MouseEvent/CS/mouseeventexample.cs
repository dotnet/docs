//<Snippet1>
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MouseEvent
{
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button clearButton;
        private System.Drawing.Drawing2D.GraphicsPath mousePath;
        private System.Windows.Forms.GroupBox groupBox1;

        private int fontSize = 20;        

        [STAThread]
        static void Main() 
        {
            Application.Run(new Form1());
        }

        public Form1()
        {            
            mousePath = new System.Drawing.Drawing2D.GraphicsPath();

            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();

            // Mouse Events Label
            this.label1.Location = new System.Drawing.Point(24, 504);
            this.label1.Size = new System.Drawing.Size(392, 23);
            // DoubleClickSize Label
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 48);
            this.label2.Size = new System.Drawing.Size(35, 13);
            // DoubleClickTime Label
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 72);
            this.label3.Size = new System.Drawing.Size(35, 13);
            // MousePresent Label
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 96);
            this.label4.Size = new System.Drawing.Size(35, 13);
            // MouseButtons Label
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 120);
            this.label5.Size = new System.Drawing.Size(35, 13);
            // MouseButtonsSwapped Label
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(320, 48);
            this.label6.Size = new System.Drawing.Size(35, 13);
            // MouseWheelPresent Label
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(320, 72);
            this.label7.Size = new System.Drawing.Size(35, 13);
            // MouseWheelScrollLines Label
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(320, 96);
            this.label8.Size = new System.Drawing.Size(35, 13);
            // NativeMouseWheelSupport Label
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(320, 120);
            this.label9.Size = new System.Drawing.Size(35, 13);

            // Mouse Panel
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right);
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Location = new System.Drawing.Point(16, 160);
            this.panel1.Size = new System.Drawing.Size(664, 320);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.panel1.MouseHover += new System.EventHandler(this.panel1_MouseHover);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseWheel);

            // Clear Button
            this.clearButton.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.clearButton.Location = new System.Drawing.Point(592, 504);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "Clear";
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            
            // GroupBox
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right);
            this.groupBox1.Location = new System.Drawing.Point(16, 24);
            this.groupBox1.Size = new System.Drawing.Size(664, 128);
            this.groupBox1.Text = "System.Windows.Forms.SystemInformation";

            // Set up how the form should be displayed and add the controls to the form.
            this.ClientSize = new System.Drawing.Size(696, 534);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                        this.label9,this.label8,this.label7,this.label6,
                                        this.label5,this.label4,this.label3,this.label2,
                                        this.clearButton,this.panel1,this.label1,this.groupBox1});
            this.Text = "Mouse Event Example";

            //<Snippet6>
            // Displays information about the system mouse.
            label2.Text = "SystemInformation.DoubleClickSize: " + SystemInformation.DoubleClickSize.ToString();
            label3.Text = "SystemInformation.DoubleClickTime: " + SystemInformation.DoubleClickTime.ToString();
            label4.Text = "SystemInformation.MousePresent: " + SystemInformation.MousePresent.ToString();
            label5.Text = "SystemInformation.MouseButtons: " + SystemInformation.MouseButtons.ToString();
            label6.Text = "SystemInformation.MouseButtonsSwapped: " + SystemInformation.MouseButtonsSwapped.ToString();
            label7.Text = "SystemInformation.MouseWheelPresent: " + SystemInformation.MouseWheelPresent.ToString();
            label8.Text = "SystemInformation.MouseWheelScrollLines: " + SystemInformation.MouseWheelScrollLines.ToString();
            label9.Text = "SystemInformation.NativeMouseWheelSupport: " + SystemInformation.NativeMouseWheelSupport.ToString();
            //</Snippet6>

        }

        //<Snippet2>
        private void panel1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) 
        {
            // Update the mouse path with the mouse information
            Point mouseDownLocation = new Point(e.X, e.Y);

            string eventString = null;
            switch (e.Button) {
                case MouseButtons.Left:
                    eventString = "L";
                    break;
                case MouseButtons.Right:
                    eventString = "R";
                    break;
                case MouseButtons.Middle:
                    eventString = "M";
                    break;
                case MouseButtons.XButton1:
                    eventString = "X1";
                    break;
                case MouseButtons.XButton2:
                    eventString = "X2";
                    break;
                case MouseButtons.None:
                default:
                    break;
            }

            if (eventString != null) 
            {
                mousePath.AddString(eventString, FontFamily.GenericSerif, (int)FontStyle.Bold, fontSize, mouseDownLocation, StringFormat.GenericDefault);
            }
            else 
            {
                mousePath.AddLine(mouseDownLocation,mouseDownLocation);
            }
            panel1.Focus();
            panel1.Invalidate();
        }
        //</Snippet2>

        //<Snippet3>
        private void panel1_MouseEnter(object sender, System.EventArgs e) 
        {
            // Update the mouse event label to indicate the MouseEnter event occurred.
            label1.Text = sender.GetType().ToString() + ": MouseEnter";
        }

        private void panel1_MouseHover(object sender, System.EventArgs e) 
        {
            // Update the mouse event label to indicate the MouseHover event occurred.
            label1.Text = sender.GetType().ToString() + ": MouseHover";
        }

        private void panel1_MouseLeave(object sender, System.EventArgs e) 
        {
            // Update the mouse event label to indicate the MouseLeave event occurred.
            label1.Text = sender.GetType().ToString() + ": MouseLeave";
        }

        private void panel1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Update the mouse path that is drawn onto the Panel.
            int mouseX = e.X;
            int mouseY = e.Y;
            
            mousePath.AddLine(mouseX,mouseY,mouseX,mouseY);
        }
        //</Snippet3>

        //<Snippet4>
        private void panel1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Update the drawing based upon the mouse wheel scrolling.
      
            int numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            int numberOfPixelsToMove = numberOfTextLinesToMove * fontSize;

            if (numberOfPixelsToMove != 0) {
                System.Drawing.Drawing2D.Matrix translateMatrix = new  System.Drawing.Drawing2D.Matrix();
                translateMatrix.Translate(0, numberOfPixelsToMove);
                mousePath.Transform(translateMatrix);
            }
            panel1.Invalidate();
        }
        //</Snippet4>
        //<Snippet5>
        private void panel1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e) 
        {
            Point mouseUpLocation = new System.Drawing.Point(e.X, e.Y);
        
            // Show the number of clicks in the path graphic.
            int numberOfClicks = e.Clicks;
            mousePath.AddString("    " + numberOfClicks.ToString(), 
                        FontFamily.GenericSerif, (int)FontStyle.Bold, 
                        fontSize, mouseUpLocation, StringFormat.GenericDefault);

            panel1.Invalidate();
        }
        //</Snippet5>

        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e) 
        {    
            // Perform the painting of the Panel.
            e.Graphics.DrawPath(System.Drawing.Pens.DarkRed, mousePath);
        }

        private void clearButton_Click(object sender, System.EventArgs e)
        {
            // Clear the Panel display.
            mousePath.Dispose();
            mousePath = new System.Drawing.Drawing2D.GraphicsPath();
            panel1.Invalidate();
        }
    }
}
//</Snippet1>