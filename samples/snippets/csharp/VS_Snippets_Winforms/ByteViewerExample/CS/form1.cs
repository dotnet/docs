//<Snippet1>
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace ByteViewerForm
{
    public class ByteViewerForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.ComponentModel.Design.ByteViewer byteviewer;

        public ByteViewerForm()
        {
            // Initialize the controls other than the ByteViewer.
            InitializeForm();
            
            // Initialize the ByteViewer.
            byteviewer = new ByteViewer();
            byteviewer.Location = new Point( 8, 46 );
            byteviewer.Size = new Size( 600, 338 );
            byteviewer.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            byteviewer.SetBytes( new byte[] { } );
            this.Controls.Add( byteviewer );
        }

        // Show a file selection dialog and cues the byte viewer to 
        // load the data in a selected file.
        private void loadBytesFromFile(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if( ofd.ShowDialog() != DialogResult.OK )
                return;
            
            byteviewer.SetFile(ofd.FileName);
        }

        // Clear the bytes in the byte viewer.
        private void clearBytes(object sender, EventArgs e)
        {
            byteviewer.SetBytes( new byte[] { } );
        }

        // Changes the display mode of the byte viewer according to the 
        // Text property of the RadioButton sender control.
        private void changeByteMode(object sender, EventArgs e)
        {
            System.Windows.Forms.RadioButton rbutton = 
                (System.Windows.Forms.RadioButton)sender;
            
            DisplayMode mode;           
            switch( rbutton.Text )
            {
                case "ANSI":
                    mode = DisplayMode.Ansi;
                    break;
                case "Hex":
                    mode = DisplayMode.Hexdump;
                    break;
                case "Unicode":
                    mode = DisplayMode.Unicode;
                    break;
                default:
                    mode = DisplayMode.Auto;
                    break;
            }
            
            // Sets the display mode.
            byteviewer.SetDisplayMode( mode );
        }

        private void InitializeForm()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(680, 440);
            this.MinimumSize = new System.Drawing.Size(660, 400);
            this.Size = new System.Drawing.Size(680, 440);
            this.Name = "Byte Viewer Form";
            this.Text = "Byte Viewer Form";            
            
            this.button1 = new System.Windows.Forms.Button();            
            this.button1.Location = new System.Drawing.Point(8, 8);
            this.button1.Size = new System.Drawing.Size(190, 23);
            this.button1.Name = "button1";
            this.button1.Text = "Set Bytes From File...";            
            this.button1.TabIndex = 0;
            this.button1.Click += new EventHandler(this.loadBytesFromFile);
            this.Controls.Add(this.button1);

            this.button2 = new System.Windows.Forms.Button();            
            this.button2.Location = new System.Drawing.Point(198, 8);
            this.button2.Size = new System.Drawing.Size(190, 23);
            this.button2.Name = "button2";
            this.button2.Text = "Clear Bytes";     
            this.button2.Click += new EventHandler(this.clearBytes);
            this.button2.TabIndex = 1;
            
            this.Controls.Add(this.button2);

            System.Windows.Forms.GroupBox group = new System.Windows.Forms.GroupBox();
            group.Location = new Point(418, 3);
            group.Size = new Size(220, 36);
            group.Text = "Display Mode";
            this.Controls.Add( group );

            System.Windows.Forms.RadioButton rbutton1 = new System.Windows.Forms.RadioButton();
            rbutton1.Location = new Point(6, 15);
            rbutton1.Size = new Size(46, 16);
            rbutton1.Text = "Auto";
            rbutton1.Checked = true;
            rbutton1.Click += new EventHandler(this.changeByteMode);
            group.Controls.Add( rbutton1 );

            System.Windows.Forms.RadioButton rbutton2 = new System.Windows.Forms.RadioButton();
            rbutton2.Location = new Point(54, 15);
            rbutton2.Size = new Size(50, 16);
            rbutton2.Text = "ANSI";
            rbutton2.Click += new EventHandler(this.changeByteMode);
            group.Controls.Add( rbutton2 );

            System.Windows.Forms.RadioButton rbutton3 = new System.Windows.Forms.RadioButton();
            rbutton3.Location = new Point(106, 15);
            rbutton3.Size = new Size(46, 16);
            rbutton3.Text = "Hex";
            rbutton3.Click += new EventHandler(this.changeByteMode);
            group.Controls.Add( rbutton3 );

            System.Windows.Forms.RadioButton rbutton4 = new System.Windows.Forms.RadioButton();
            rbutton4.Location = new Point(152, 15);
            rbutton4.Size = new Size(64, 16);
            rbutton4.Text = "Unicode";
            rbutton4.Click += new EventHandler(this.changeByteMode);
            group.Controls.Add( rbutton4 );
            this.ResumeLayout(false);            
        }

        [STAThread]
        static void Main() 
        {
            Application.Run(new ByteViewerForm());
        }
    }
}
//</Snippet1>