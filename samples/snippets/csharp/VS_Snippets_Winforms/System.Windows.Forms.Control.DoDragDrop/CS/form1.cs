//<Snippet1>
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Snip_DragNDrop
{
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.ListBox ListDragSource;
        private System.Windows.Forms.ListBox ListDragTarget;
        private System.Windows.Forms.CheckBox UseCustomCursorsCheck;
        private System.Windows.Forms.Label DropLocationLabel;

        private int indexOfItemUnderMouseToDrag;
        private int indexOfItemUnderMouseToDrop;        
        
        private Rectangle dragBoxFromMouseDown;
        private Point screenOffset;

        private Cursor MyNoDropCursor;
        private Cursor MyNormalCursor;

        /// The main entry point for the application.
        [STAThread]
        static void Main() 
        {
            Application.Run(new Form1());
        }

        public Form1()
        {
            this.ListDragSource = new System.Windows.Forms.ListBox();
            this.ListDragTarget = new System.Windows.Forms.ListBox();
            this.UseCustomCursorsCheck = new System.Windows.Forms.CheckBox();
            this.DropLocationLabel = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // ListDragSource
            this.ListDragSource.Items.AddRange(new object[] {"one", "two", "three", "four", 
                                                                "five", "six", "seven", "eight",
                                                                "nine", "ten"});
            this.ListDragSource.Location = new System.Drawing.Point(10, 17);
            this.ListDragSource.Size = new System.Drawing.Size(120, 225);
            this.ListDragSource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListDragSource_MouseDown);
            this.ListDragSource.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.ListDragSource_QueryContinueDrag);
            this.ListDragSource.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListDragSource_MouseUp);
            this.ListDragSource.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ListDragSource_MouseMove);
            this.ListDragSource.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.ListDragSource_GiveFeedback);

            // ListDragTarget
            this.ListDragTarget.AllowDrop = true;
            this.ListDragTarget.Location = new System.Drawing.Point(154, 17);
            this.ListDragTarget.Size = new System.Drawing.Size(120, 225);
            this.ListDragTarget.DragOver += new System.Windows.Forms.DragEventHandler(this.ListDragTarget_DragOver);
            this.ListDragTarget.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListDragTarget_DragDrop);
            this.ListDragTarget.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListDragTarget_DragEnter);
            this.ListDragTarget.DragLeave += new System.EventHandler(this.ListDragTarget_DragLeave);

            // UseCustomCursorsCheck
            this.UseCustomCursorsCheck.Location = new System.Drawing.Point(10, 243);
            this.UseCustomCursorsCheck.Size = new System.Drawing.Size(137, 24);
            this.UseCustomCursorsCheck.Text = "Use Custom Cursors";

            // DropLocationLabel
            this.DropLocationLabel.Location = new System.Drawing.Point(154, 245);
            this.DropLocationLabel.Size = new System.Drawing.Size(137, 24);
            this.DropLocationLabel.Text = "None";
           
            // Form1
            this.ClientSize = new System.Drawing.Size(292, 270);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {this.ListDragSource,
                                                        this.ListDragTarget, this.UseCustomCursorsCheck,
                                                        this.DropLocationLabel});
            this.Text = "drag-and-drop Example";

            this.ResumeLayout(false);

        }

        private void ListDragSource_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) 
        {
            // Get the index of the item the mouse is below.
            indexOfItemUnderMouseToDrag = ListDragSource.IndexFromPoint(e.X, e.Y);

            if (indexOfItemUnderMouseToDrag != ListBox.NoMatches) {
                                
                // Remember the point where the mouse down occurred. The DragSize indicates
                // the size that the mouse can move before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width /2),
                                                               e.Y - (dragSize.Height /2)), dragSize);
            } else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;

        }

        private void ListDragSource_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e) {
            // Reset the drag rectangle when the mouse button is raised.
            dragBoxFromMouseDown = Rectangle.Empty;
        }

        //<Snippet2>
        private void ListDragSource_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e) 
        {
            
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left) {

                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty && 
                    !dragBoxFromMouseDown.Contains(e.X, e.Y)) {

                    // Create custom cursors for the drag-and-drop operation.
                    try {
                        MyNormalCursor = new Cursor("3dwarro.cur");
                        MyNoDropCursor = new Cursor("3dwno.cur");

                    } catch {
                        // An error occurred while attempting to load the cursors, so use
                        // standard cursors.
                        UseCustomCursorsCheck.Checked = false;
                    }finally {

                        // The screenOffset is used to account for any desktop bands 
                        // that may be at the top or left side of the screen when 
                        // determining when to cancel the drag drop operation.
                        screenOffset = SystemInformation.WorkingArea.Location;

                        // Proceed with the drag-and-drop, passing in the list item.                    
                        DragDropEffects dropEffect = ListDragSource.DoDragDrop(ListDragSource.Items[indexOfItemUnderMouseToDrag], DragDropEffects.All | DragDropEffects.Link);

                        // If the drag operation was a move then remove the item.
                        if (dropEffect == DragDropEffects.Move) {                        
                            ListDragSource.Items.RemoveAt(indexOfItemUnderMouseToDrag);

                            // Selects the previous item in the list as long as the list has an item.
                            if (indexOfItemUnderMouseToDrag > 0)
                                ListDragSource.SelectedIndex = indexOfItemUnderMouseToDrag -1;

                            else if (ListDragSource.Items.Count > 0)
                                // Selects the first item.
                                ListDragSource.SelectedIndex =0;
                        }

                        // Dispose of the cursors since they are no longer needed.
                        if (MyNormalCursor != null)
                            MyNormalCursor.Dispose();

                        if (MyNoDropCursor != null)
                            MyNoDropCursor.Dispose();
                    }
                }
            }
        }
        //</Snippet2>
        //<Snippet9>
        //<Snippet3>
        private void ListDragSource_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e) 
        {
            // Use custom cursors if the check box is checked.
            if (UseCustomCursorsCheck.Checked) {

                // Sets the custom cursor based upon the effect.
                e.UseDefaultCursors = false;
                if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
                    Cursor.Current = MyNormalCursor;
                else 
                    Cursor.Current = MyNoDropCursor;
            }
        
        }
        //</Snippet3>
        //<Snippet4>
        private void ListDragTarget_DragOver(object sender, System.Windows.Forms.DragEventArgs e) 
        {

            // Determine whether string data exists in the drop data. If not, then
            // the drop effect reflects that the drop cannot occur.
            if (!e.Data.GetDataPresent(typeof(System.String))) {

                e.Effect = DragDropEffects.None;
                DropLocationLabel.Text = "None - no string data.";
                return;
            }

            // Set the effect based upon the KeyState.
            if ((e.KeyState & (8+32)) == (8+32) && 
                (e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link) {
                // KeyState 8 + 32 = CTL + ALT

                // Link drag-and-drop effect.
                e.Effect = DragDropEffects.Link;

            } else if ((e.KeyState & 32) == 32 && 
                (e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link) {

                // ALT KeyState for link.
                e.Effect = DragDropEffects.Link;

            } else if ((e.KeyState & 4) == 4 && 
                (e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move) {

                // SHIFT KeyState for move.
                e.Effect = DragDropEffects.Move;

            } else if ((e.KeyState & 8) == 8 && 
                (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy) {

                // CTL KeyState for copy.
                e.Effect = DragDropEffects.Copy;

            } else if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)  {

                // By default, the drop action should be move, if allowed.
                e.Effect = DragDropEffects.Move;

            } else
                e.Effect = DragDropEffects.None;
                
            // Get the index of the item the mouse is below. 

            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.

            indexOfItemUnderMouseToDrop = 
                ListDragTarget.IndexFromPoint(ListDragTarget.PointToClient(new Point(e.X, e.Y)));

            // Updates the label text.
            if (indexOfItemUnderMouseToDrop != ListBox.NoMatches){

                DropLocationLabel.Text = "Drops before item #" + (indexOfItemUnderMouseToDrop + 1);
            } else
                DropLocationLabel.Text = "Drops at the end.";

        }
        //</Snippet4>
        //<Snippet5>        
        private void ListDragTarget_DragDrop(object sender, System.Windows.Forms.DragEventArgs e) 
        {
            // Ensure that the list item index is contained in the data.
            if (e.Data.GetDataPresent(typeof(System.String))) {

                Object item = (object)e.Data.GetData(typeof(System.String));

                // Perform drag-and-drop, depending upon the effect.
                if (e.Effect == DragDropEffects.Copy ||
                    e.Effect == DragDropEffects.Move) {
                
                    // Insert the item.
                    if (indexOfItemUnderMouseToDrop != ListBox.NoMatches)
                        ListDragTarget.Items.Insert(indexOfItemUnderMouseToDrop, item);
                    else
                        ListDragTarget.Items.Add(item);
                    
                }
            }
            // Reset the label text.
            DropLocationLabel.Text = "None";
        }
        //</Snippet5>
        //<Snippet6>
        private void ListDragSource_QueryContinueDrag(object sender, System.Windows.Forms.QueryContinueDragEventArgs e) {
            // Cancel the drag if the mouse moves off the form.
            ListBox lb = sender as ListBox;

            if (lb != null) {

                Form f = lb.FindForm();

                // Cancel the drag if the mouse moves off the form. The screenOffset
                // takes into account any desktop bands that may be at the top or left
                // side of the screen.
                if (((Control.MousePosition.X - screenOffset.X) < f.DesktopBounds.Left) ||
                    ((Control.MousePosition.X - screenOffset.X) > f.DesktopBounds.Right) ||
                    ((Control.MousePosition.Y - screenOffset.Y) < f.DesktopBounds.Top) ||
                    ((Control.MousePosition.Y - screenOffset.Y) > f.DesktopBounds.Bottom)) {

                    e.Action = DragAction.Cancel;
                }
            }
        }
        //</Snippet6>
        //<Snippet7>
        private void ListDragTarget_DragEnter(object sender, System.Windows.Forms.DragEventArgs e) {
            // Reset the label text.
            DropLocationLabel.Text = "None";
        }
        //</Snippet7>
        //<Snippet8>
        private void ListDragTarget_DragLeave(object sender, System.EventArgs e) {
            // Reset the label text.
            DropLocationLabel.Text = "None";
        }
        //</Snippet8>
        //</Snippet9>
    }
}
//</Snippet1>