// User Input Test Application for new Windows Forms user input conceptual topics
// in Visual Studio 2005 documentation.

// <Snippet0>
using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace UserInputWalkthrough
{
    public class Form1 : Form
    {
        Label Label1 = new Label();
        Label Label2 = new Label();
        TextBox TextBoxOutput = new TextBox();
        TextBox TextBoxInput = new TextBox();
        GroupBox GroupBoxEvents = new GroupBox();
        Button ButtonClear = new Button();
        LinkLabel LinkLabelDrag = new LinkLabel();

        CheckBox CheckBoxToggleAll = new CheckBox();
        CheckBox CheckBoxMouse = new CheckBox();
        CheckBox CheckBoxMouseEnter = new CheckBox();
        CheckBox CheckBoxMouseMove = new CheckBox();
        CheckBox CheckBoxMousePoints = new CheckBox();
        CheckBox CheckBoxMouseDrag = new CheckBox();
        CheckBox CheckBoxMouseDragOver = new CheckBox();
        CheckBox CheckBoxKeyboard = new CheckBox();
        CheckBox CheckBoxKeyUpDown = new CheckBox();
        CheckBox CheckBoxFocus = new CheckBox();
        CheckBox CheckBoxValidation = new CheckBox();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        public Form1()
            : base()
        {
            this.Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.GroupBoxEvents.SuspendLayout();
            this.SuspendLayout();

            Label1.Location = new Point(232, 12);
            Label1.Size = new Size(98, 14);
            Label1.AutoSize = true;
            Label1.Text = "Generated Events:";

            Label2.Location = new Point(13, 12);
            Label2.Size = new Size(95, 14);
            Label2.AutoSize = true;
            Label2.Text = "User Input Target:";

            TextBoxInput.Location = new Point(13, 34);
            TextBoxInput.Size = new Size(200, 200);
            TextBoxInput.AllowDrop = true;
            TextBoxInput.AutoSize = false;
            TextBoxInput.Cursor = Cursors.Cross;
            TextBoxInput.Multiline = true;
            TextBoxInput.TabIndex = 1;

            LinkLabelDrag.AllowDrop = true;
            LinkLabelDrag.AutoSize = true;
            LinkLabelDrag.Location = new Point(13, 240);
            LinkLabelDrag.Size = new Size(175, 14);
            LinkLabelDrag.TabIndex = 2;
            LinkLabelDrag.TabStop = true;
            LinkLabelDrag.Text = "Click here to use as a drag source";
            LinkLabelDrag.Links.Add(new LinkLabel.Link(0,
                LinkLabelDrag.Text.Length));

            GroupBoxEvents.Location = new Point(13, 281);
            GroupBoxEvents.Size = new Size(200, 302);
            GroupBoxEvents.Text = "Event Filter:";
            GroupBoxEvents.TabStop = true;
            GroupBoxEvents.TabIndex = 3;
            GroupBoxEvents.Controls.Add(CheckBoxMouseEnter);
            GroupBoxEvents.Controls.Add(CheckBoxToggleAll);
            GroupBoxEvents.Controls.Add(CheckBoxMousePoints);
            GroupBoxEvents.Controls.Add(CheckBoxKeyUpDown);
            GroupBoxEvents.Controls.Add(CheckBoxMouseDragOver);
            GroupBoxEvents.Controls.Add(CheckBoxMouseDrag);
            GroupBoxEvents.Controls.Add(CheckBoxValidation);
            GroupBoxEvents.Controls.Add(CheckBoxMouseMove);
            GroupBoxEvents.Controls.Add(CheckBoxFocus);
            GroupBoxEvents.Controls.Add(CheckBoxKeyboard);
            GroupBoxEvents.Controls.Add(CheckBoxMouse);

            CheckBoxToggleAll.AutoSize = true;
            CheckBoxToggleAll.Location = new Point(7, 20);
            CheckBoxToggleAll.Size = new Size(122, 17);
            CheckBoxToggleAll.TabIndex = 4;
            CheckBoxToggleAll.Text = "Toggle All Events";

            CheckBoxMouse.AutoSize = true;
            CheckBoxMouse.Location = new Point(7, 45);
            CheckBoxMouse.Size = new Size(137, 17);
            CheckBoxMouse.TabIndex = 5;
            CheckBoxMouse.Text = "Mouse and Click Events";

            CheckBoxMouseEnter.AutoSize = true;
            CheckBoxMouseEnter.Location = new Point(26, 69);
            CheckBoxMouseEnter.Margin = new Padding(3, 3, 3, 1);
            CheckBoxMouseEnter.Size = new System.Drawing.Size(151, 17);
            CheckBoxMouseEnter.TabIndex = 6;
            CheckBoxMouseEnter.Text = "Mouse Enter/Hover/Leave";

            CheckBoxMouseMove.AutoSize = true;
            CheckBoxMouseMove.Location = new Point(26, 89);
            CheckBoxMouseMove.Margin = new Padding(3, 2, 3, 3);
            CheckBoxMouseMove.Size = new Size(120, 17);
            CheckBoxMouseMove.TabIndex = 7;
            CheckBoxMouseMove.Text = "Mouse Move Events";

            CheckBoxMousePoints.AutoSize = true;
            CheckBoxMousePoints.Location = new Point(26, 112);
            CheckBoxMousePoints.Margin = new Padding(3, 3, 3, 1);
            CheckBoxMousePoints.Size = new Size(141, 17);
            CheckBoxMousePoints.TabIndex = 8;
            CheckBoxMousePoints.Text = "Draw Mouse Points";

            CheckBoxMouseDrag.AutoSize = true;
            CheckBoxMouseDrag.Location = new Point(26, 135);
            CheckBoxMouseDrag.Margin = new Padding(3, 1, 3, 3);
            CheckBoxMouseDrag.Size = new Size(151, 17);
            CheckBoxMouseDrag.TabIndex = 9;
            CheckBoxMouseDrag.Text = "Mouse Drag && Drop Events";

            CheckBoxMouseDragOver.AutoSize = true;
            CheckBoxMouseDragOver.Location = new Point(44, 159);
            CheckBoxMouseDragOver.Size = new Size(142, 17);
            CheckBoxMouseDragOver.TabIndex = 10;
            CheckBoxMouseDragOver.Text = "Mouse Drag Over Events";

            CheckBoxKeyboard.AutoSize = true;
            CheckBoxKeyboard.Location = new Point(8, 184);
            CheckBoxKeyboard.Size = new Size(103, 17);
            CheckBoxKeyboard.TabIndex = 11;
            CheckBoxKeyboard.Text = "Keyboard Events";

            CheckBoxKeyUpDown.AutoSize = true;
            CheckBoxKeyUpDown.Location = new Point(26, 207);
            CheckBoxKeyUpDown.Margin = new Padding(3, 3, 3, 1);
            CheckBoxKeyUpDown.Size = new Size(133, 17);
            CheckBoxKeyUpDown.TabIndex = 12;
            CheckBoxKeyUpDown.Text = "Key Up && Down Events";

            CheckBoxFocus.AutoSize = true;
            CheckBoxFocus.Location = new Point(8, 233);
            CheckBoxFocus.Margin = new Padding(3, 2, 3, 3);
            CheckBoxFocus.Size = new Size(146, 17);
            CheckBoxFocus.TabIndex = 13;
            CheckBoxFocus.Text = "Focus && Activation Events";

            CheckBoxValidation.AutoSize = true;
            CheckBoxValidation.Location = new Point(8, 257);
            CheckBoxValidation.Size = new Size(104, 17);
            CheckBoxValidation.TabIndex = 14;
            CheckBoxValidation.Text = "Validation Events";

            TextBoxOutput.Location = new Point(232, 34);
            TextBoxOutput.Size = new Size(308, 510);
            TextBoxOutput.Multiline = true;
            TextBoxOutput.CausesValidation = false;
            TextBoxOutput.ReadOnly = true;
            TextBoxOutput.ScrollBars = ScrollBars.Vertical;
            TextBoxOutput.TabIndex = 15;
            TextBoxOutput.WordWrap = false;

            ButtonClear.Location = new Point(232, 560);
            ButtonClear.Size = new Size(308, 23);
            ButtonClear.TabIndex = 16;
            ButtonClear.Text = "Clear Event List";

            this.ClientSize = new Size(552, 595);
            this.Controls.Add(LinkLabelDrag);
            this.Controls.Add(ButtonClear);
            this.Controls.Add(GroupBoxEvents);
            this.Controls.Add(Label1);
            this.Controls.Add(Label2);
            this.Controls.Add(TextBoxInput);
            this.Controls.Add(TextBoxOutput);
            this.Text = "User Input Events";

            ButtonClear.Click +=
                new EventHandler(ButtonClear_Click);
            TextBoxInput.KeyDown +=
                new KeyEventHandler(TextBoxInput_KeyDown);
            TextBoxInput.KeyPress +=
                new KeyPressEventHandler(TextBoxInput_KeyPress);
            TextBoxInput.KeyUp +=
                new KeyEventHandler(TextBoxInput_KeyUp);
            TextBoxInput.Click +=
                new EventHandler(TextBoxInput_Click);
            TextBoxInput.DoubleClick +=
                new EventHandler(TextBoxInput_DoubleClick);
            TextBoxInput.MouseClick +=
                new MouseEventHandler(TextBoxInput_MouseClick);
            TextBoxInput.MouseDoubleClick +=
                new MouseEventHandler(TextBoxInput_MouseDoubleClick);
            TextBoxInput.MouseDown +=
                new MouseEventHandler(TextBoxInput_MouseDown);
            TextBoxInput.MouseUp +=
                new MouseEventHandler(TextBoxInput_MouseUp);
            TextBoxInput.MouseEnter +=
                new EventHandler(TextBoxInput_MouseEnter);
            TextBoxInput.MouseHover +=
                new EventHandler(TextBoxInput_MouseHover);
            TextBoxInput.MouseLeave +=
                new EventHandler(TextBoxInput_MouseLeave);
            TextBoxInput.MouseWheel +=
                new MouseEventHandler(TextBoxInput_MouseWheel);
            TextBoxInput.MouseMove +=
                new MouseEventHandler(TextBoxInput_MouseMove);
            TextBoxInput.MouseCaptureChanged +=
                new EventHandler(TextBoxInput_MouseCaptureChanged);
            TextBoxInput.DragEnter +=
                new DragEventHandler(TextBoxInput_DragEnter);
            TextBoxInput.DragDrop +=
                new DragEventHandler(TextBoxInput_DragDrop);
            TextBoxInput.DragOver +=
                new DragEventHandler(TextBoxInput_DragOver);
            TextBoxInput.DragLeave +=
                new EventHandler(TextBoxInput_DragLeave);
            TextBoxInput.Enter +=
                new EventHandler(TextBoxInput_Enter);
            TextBoxInput.Leave +=
                new EventHandler(TextBoxInput_Leave);
            TextBoxInput.GotFocus +=
                new EventHandler(TextBoxInput_GotFocus);
            TextBoxInput.LostFocus +=
                new EventHandler(TextBoxInput_LostFocus);
            TextBoxInput.Validated +=
                new EventHandler(TextBoxInput_Validated);
            TextBoxInput.Validating +=
                new CancelEventHandler(TextBoxInput_Validating);

            LinkLabelDrag.MouseDown +=
                new MouseEventHandler(LinkLabelDrag_MouseDown);
            LinkLabelDrag.GiveFeedback +=
                new GiveFeedbackEventHandler(LinkLabelDrag_GiveFeedback);

            CheckBoxToggleAll.CheckedChanged +=
                new EventHandler(CheckBoxToggleAll_CheckedChanged);
            CheckBoxMouse.CheckedChanged +=
                new EventHandler(CheckBoxMouse_CheckedChanged);
            CheckBoxMouseDrag.CheckedChanged +=
                new EventHandler(CheckBoxMouseDrag_CheckedChanged);
            CheckBoxMouseEnter.CheckedChanged +=
                new EventHandler(CheckBoxMouseMove_CheckedChanged);
            CheckBoxMouseMove.CheckedChanged +=
                new EventHandler(CheckBoxMouseMove_CheckedChanged);
            CheckBoxKeyboard.CheckedChanged +=
                new EventHandler(CheckBoxKeyboard_CheckedChanged);

            this.GroupBoxEvents.ResumeLayout(false);
            this.GroupBoxEvents.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
            CheckAllChildCheckBoxes(this, true);
        }

        // Recursively search the form for all contained checkboxes and 
        // initially check them
        private void CheckAllChildCheckBoxes(Control parent, bool value)
        {
            CheckBox box;
            foreach (Control currentControl in parent.Controls)
            {
                if (currentControl is CheckBox)
                {
                    box = (CheckBox)currentControl;
                    box.Checked = value;
                }

                // Recurse if control contains other controls
                if (currentControl.Controls.Count > 0)
                {
                    CheckAllChildCheckBoxes(currentControl, value);
                }
            }
        }

        // All-purpose method for displaying a line of text in the
        // text boxe.
        private void DisplayLine(string line)
        {
            TextBoxOutput.AppendText(line);
            TextBoxOutput.AppendText(Environment.NewLine);
        }

        // Click event handler for the button that clears the text box.
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            TextBoxOutput.Invalidate();
            TextBoxOutput.Clear();
        }

        private void TextBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (CheckBoxKeyUpDown.Checked)
            {
                DisplayLine("KeyDown: " + e.KeyData.ToString());
            }
        }

        private void TextBoxInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (CheckBoxKeyUpDown.Checked)
            {
                DisplayLine("KeyUp: " + e.KeyData.ToString());
            }
        }

        private void TextBoxInput_KeyPress(object sender,
            KeyPressEventArgs e)
        {
            if (CheckBoxKeyboard.Checked)
            {
                if (Char.IsWhiteSpace(e.KeyChar))
                {
                    DisplayLine("KeyPress: WS");
                }
                else
                {
                    DisplayLine("KeyPress: " + e.KeyChar.ToString());
                }
            }
        }

        private void TextBoxInput_Click(object sender, EventArgs e)
        {
            if (CheckBoxMouse.Checked)
            {
                DisplayLine("Click event");
            }
        }

        private void TextBoxInput_DoubleClick(object sender, EventArgs e)
        {
            if (CheckBoxMouse.Checked)
            {
                DisplayLine("DoubleClick event");
            }
        }

        private void TextBoxInput_MouseClick(object sender, MouseEventArgs e)
        {
            if (CheckBoxMouse.Checked)
            {
                DisplayLine("MouseClick: " + e.Button.ToString() +
                        " " + e.Location.ToString());
            }
        }

        private void TextBoxInput_MouseDoubleClick(object sender,
            MouseEventArgs e)
        {
            if (CheckBoxMouse.Checked)
            {
                DisplayLine("MouseDoubleClick: " + e.Button.ToString() +
                        " " + e.Location.ToString());
            }
        }

        private void TextBoxInput_MouseDown(object sender,
            MouseEventArgs e)
        {
            if (CheckBoxMouse.Checked)
            {
                DisplayLine("MouseDown: " + e.Button.ToString() +
                        " " + e.Location.ToString());
            }
        }

        private void TextBoxInput_MouseUp(object sender,
            MouseEventArgs e)
        {
            if (CheckBoxMouse.Checked)
            {
                DisplayLine("MouseUp: " + e.Button.ToString() +
                        " " + e.Location.ToString());
            }

            // The TextBox control was designed to change focus only on  
            // the primary click, so force focus to avoid user confusion.
            if (!TextBoxInput.Focused)
            {
                TextBoxInput.Focus();
            }
        }

        private void TextBoxInput_MouseEnter(object sender, EventArgs e)
        {
            if (CheckBoxMouseEnter.Checked)
            {
                DisplayLine("MouseEnter event");
            }
        }

        private void TextBoxInput_MouseHover(object sender, EventArgs e)
        {
            if (CheckBoxMouseEnter.Checked)
            {
                DisplayLine("MouseHover event");
            }
        }

        private void TextBoxInput_MouseLeave(object sender, EventArgs e)
        {
            if (CheckBoxMouseEnter.Checked)
            {
                DisplayLine("MouseLeave event");
            }
        }

        private void TextBoxInput_MouseWheel(object sender,
            MouseEventArgs e)
        {
            if (CheckBoxMouse.Checked)
            {
                DisplayLine("MouseWheel: " + e.Delta.ToString() +
                        " detents at " + e.Location.ToString());
            }
        }

        private void TextBoxInput_MouseMove(object sender,
            MouseEventArgs e)
        {
            if (CheckBoxMouseMove.Checked)
            {
                DisplayLine("MouseMove: " + e.Button.ToString() + " " +
                        e.Location.ToString());
            }

            if (CheckBoxMousePoints.Checked)
            {
                Graphics g = TextBoxInput.CreateGraphics();
                g.FillRectangle(Brushes.Black, e.Location.X,
                    e.Location.Y, 1, 1);
                g.Dispose();
            }
        }

        private void TextBoxInput_MouseCaptureChanged(object sender,
            EventArgs e)
        {
            if (CheckBoxMouseDrag.Checked)
            {
                DisplayLine("MouseCaptureChanged event");
            }
        }

        private void TextBoxInput_DragEnter(object sender,
            DragEventArgs e)
        {
            if (CheckBoxMouseDrag.Checked)
            {
                Point pt = new Point(e.X, e.Y);
                DisplayLine("DragEnter: " +
                    CovertKeyStateToString(e.KeyState)
                    + " at " + pt.ToString());
            }
        }

        private void TextBoxInput_DragDrop(object sender,
            DragEventArgs e)
        {
            if (CheckBoxMouseDrag.Checked)
            {
                Point pt = new Point(e.X, e.Y);
                DisplayLine("DragDrop: " +
                    CovertKeyStateToString(e.KeyState)
                    + " at " + pt.ToString());
            }
        }

        private void TextBoxInput_DragOver(object sender,
            DragEventArgs e)
        {
            if (CheckBoxMouseDragOver.Checked)
            {
                Point pt = new Point(e.X, e.Y);
                DisplayLine("DragOver: " +
                    CovertKeyStateToString(e.KeyState)
                    + " at " + pt.ToString());
            }

            // Allow if drop data is of type string.
            if (!e.Data.GetDataPresent(typeof(String)))
            {
                e.Effect = DragDropEffects.None;
            }
            else
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void TextBoxInput_DragLeave(object sender,
            EventArgs e)
        {
            if (CheckBoxMouseDrag.Checked)
            {
                DisplayLine("DragLeave event");
            }
        }

        private string CovertKeyStateToString(int keyState)
        {
            string keyString = "None";

            // Which button was pressed?
            if ((keyState & 1) == 1)
            {
                keyString = "Left";
            }
            else if ((keyState & 2) == 2)
            {
                keyString = "Right";
            }
            else if ((keyState & 16) == 16)
            {
                keyString = "Middle";
            }

            // Are one or more modifier keys also pressed?
            if ((keyState & 4) == 4)
            {
                keyString += "+SHIFT";
            }

            if ((keyState & 8) == 8)
            {
                keyString += "+CTRL";
            }

            if ((keyState & 32) == 32)
            {
                keyString += "+ALT";
            }

            return keyString;
        }

        private void TextBoxInput_Enter(object sender, EventArgs e)
        {
            if (CheckBoxFocus.Checked)
            {
                DisplayLine("Enter event");
            }
        }

        private void TextBoxInput_Leave(object sender, EventArgs e)
        {
            if (CheckBoxFocus.Checked)
            {
                DisplayLine("Leave event");
            }
        }

        private void TextBoxInput_GotFocus(object sender, EventArgs e)
        {
            if (CheckBoxFocus.Checked)
            {
                DisplayLine("GotFocus event");
            }
        }

        private void TextBoxInput_LostFocus(object sender, EventArgs e)
        {
            if (CheckBoxFocus.Checked)
            {
                DisplayLine("LostFocus event");
            }
        }

        private void TextBoxInput_Validated(object sender, EventArgs e)
        {
            if (CheckBoxValidation.Checked)
            {
                DisplayLine("Validated event");
            }
        }

        private void TextBoxInput_Validating(
            object sender, CancelEventArgs e)
        {
            if (CheckBoxValidation.Checked)
            {
                DisplayLine("Validating event");
            }
        }

        private void CheckBoxToggleAll_CheckedChanged(
            object sender, EventArgs e)
        {
            if (sender is CheckBox)
            {
                CheckAllChildCheckBoxes(this, ((CheckBox)sender).Checked);
            }
        }

        private void CheckBoxMouse_CheckedChanged(
            object sender, EventArgs e)
        {
            ConfigureCheckBoxSettings();
        }

        private void CheckBoxMouseDrag_CheckedChanged(
            object sender, EventArgs e)
        {
            ConfigureCheckBoxSettings();
        }

        private void CheckBoxKeyboard_CheckedChanged(
            object sender, EventArgs e)
        {
            ConfigureCheckBoxSettings();
        }

        private void CheckBoxMouseMove_CheckedChanged(
            object sender, EventArgs e)
        {
            ConfigureCheckBoxSettings();
        }

        // Reconcile dependencies between the check box 
        // selection choices. 
        private void ConfigureCheckBoxSettings()
        {
            // CheckBoxMouse is a top-level check box.
            if (!CheckBoxMouse.Checked)
            {
                CheckBoxMouseEnter.Enabled = false;
                CheckBoxMouseMove.Enabled = false;
                CheckBoxMouseDrag.Enabled = false;
                CheckBoxMouseDragOver.Enabled = false;
                CheckBoxMousePoints.Enabled = false;
            }
            else
            {
                CheckBoxMouseEnter.Enabled = true;
                CheckBoxMouseMove.Enabled = true;
                CheckBoxMouseDrag.Enabled = true;
                CheckBoxMousePoints.Enabled = true;

                // Enable children depending on the state of the parent.
                if (!CheckBoxMouseDrag.Checked)
                {
                    CheckBoxMouseDragOver.Enabled = false;
                }
                else
                {
                    CheckBoxMouseDragOver.Enabled = true;
                }
            }

            if (!CheckBoxKeyboard.Checked)
            {
                CheckBoxKeyUpDown.Enabled = false;
            }
            else
            {
                CheckBoxKeyUpDown.Enabled = true;
            }
        }

        private void LinkLabelDrag_MouseDown(object sender,
            MouseEventArgs e)
        {
            string data = "Sample Data";
            LinkLabelDrag.DoDragDrop(data, DragDropEffects.All);
        }

        private void LinkLabelDrag_GiveFeedback(object sender,
            GiveFeedbackEventArgs e)
        {
            if ((e.Effect & DragDropEffects.Copy) ==
                DragDropEffects.Copy)
            {
                LinkLabelDrag.Cursor = Cursors.HSplit;
            }
            else
            {
                LinkLabelDrag.Cursor = Cursors.Default;
            }
        }
    }
}
// </Snippet0>