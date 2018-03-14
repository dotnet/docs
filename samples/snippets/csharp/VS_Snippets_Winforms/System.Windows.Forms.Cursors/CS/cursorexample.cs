//<Snippet1>
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MCursor
{
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.ComboBox cursorSelectionComboBox;

        private System.Windows.Forms.Panel testPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView cursorEventViewer;
        private System.Windows.Forms.Label label3;
        
        [STAThread]
        static void Main() 
        {
            Application.Run(new Form1());
        }

        public Form1()
        {
            this.cursorSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.testPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cursorEventViewer = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();

            // Select Cursor Label
            this.label2.Location = new System.Drawing.Point(24, 16);
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.Text = "Select cursor:";

            // Cursor Testing Panel Label
            this.label1.Location = new System.Drawing.Point(24, 80);
            this.label1.Size = new System.Drawing.Size(144, 23);
            this.label1.Text = "Cursor testing panel:";

            // Cursor Changed Events Label
            this.label3.Location = new System.Drawing.Point(184, 16);
            this.label3.Size = new System.Drawing.Size(128, 16);
            this.label3.Text = "Cursor changed events:";
            
            // Cursor Selection ComboBox
            this.cursorSelectionComboBox.Location = new System.Drawing.Point(24, 40);
            this.cursorSelectionComboBox.Size = new System.Drawing.Size(152, 21);
            this.cursorSelectionComboBox.TabIndex = 0;
            this.cursorSelectionComboBox.SelectedIndexChanged += 
                 new System.EventHandler(this.cursorSelectionComboBox_SelectedIndexChanged);

            // Cursor Test Panel
            this.testPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.testPanel.Location = new System.Drawing.Point(24, 104);
            this.testPanel.Size = new System.Drawing.Size(152, 160);
            this.testPanel.CursorChanged += new System.EventHandler(this.testPanel_CursorChanged);

            // Cursor Event ListView
            this.cursorEventViewer.Location = new System.Drawing.Point(184, 40);
            this.cursorEventViewer.Size = new System.Drawing.Size(256, 224);
            this.cursorEventViewer.TabIndex = 4;
            this.cursorEventViewer.View = System.Windows.Forms.View.List;

            // Set up how the form should be displayed and add the controls to the form.
            this.ClientSize = new System.Drawing.Size(456, 286);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                        this.label3, this.cursorEventViewer,
                                        this.label2, this.label1,
                                        this.testPanel, this.cursorSelectionComboBox});

            this.Text = "Cursors Example";

            // Add all the cursor types to the combobox.
            foreach (Cursor cursor in CursorList())
            {
                cursorSelectionComboBox.Items.Add(cursor);
            }
        
        }

        private Cursor [] CursorList()
        {

            // Make an array of all the types of cursors in Windows Forms.
            return new Cursor [] {
                                     Cursors.AppStarting, Cursors.Arrow, Cursors.Cross,
                                     Cursors.Default, Cursors.Hand, Cursors.Help,
                                     Cursors.HSplit, Cursors.IBeam, Cursors.No,
                                     Cursors.NoMove2D, Cursors.NoMoveHoriz, Cursors.NoMoveVert,
                                     Cursors.PanEast, Cursors.PanNE, Cursors.PanNorth,
                                     Cursors.PanNW, Cursors.PanSE, Cursors.PanSouth,
                                     Cursors.PanSW, Cursors.PanWest, Cursors.SizeAll,
                                     Cursors.SizeNESW, Cursors.SizeNS, Cursors.SizeNWSE,
                                     Cursors.SizeWE, Cursors.UpArrow, Cursors.VSplit, Cursors.WaitCursor};

        }

        private void cursorSelectionComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // Set the cursor in the test panel to be the selected cursor style.
            testPanel.Cursor = (Cursor)cursorSelectionComboBox.SelectedItem;
        }

        private void testPanel_CursorChanged(object sender, System.EventArgs e)
        {
            // Build up a string containing the type of object sending the event, and the event.
            string cursorEvent = string.Format("[{0}]: {1}", sender.GetType().ToString(), "Cursor changed");                
        
            // Record this event in the list view.
            this.cursorEventViewer.Items.Add(cursorEvent);
        }
    }
}
//</Snippet1>