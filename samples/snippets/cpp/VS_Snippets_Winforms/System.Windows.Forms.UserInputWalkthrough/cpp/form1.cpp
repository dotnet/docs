// User Input Test Application for new Windows Forms user input conceptual topics
// in Visual Studio 2005 documentation.

// <Snippet0>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

namespace UserInputWalkthrough
{
    public ref class Form1 : public Form
    {
        Label^ lblEvent;
        Label^ lblInput;

        TextBox^ TextBoxOutput;
        TextBox^ TextBoxInput;
        GroupBox^ GroupBoxEvents;
        Button^ ButtonClear;
        LinkLabel^ LinkLabelDrag;

        CheckBox^ CheckBoxToggleAll;
        CheckBox^ CheckBoxMouse;
        CheckBox^ CheckBoxMouseEnter;
        CheckBox^ CheckBoxMouseMove;
        CheckBox^ CheckBoxMousePoints;
        CheckBox^ CheckBoxMouseDrag;
        CheckBox^ CheckBoxMouseDragOver;
        CheckBox^ CheckBoxKeyboard;
        CheckBox^ CheckBoxKeyUpDown;
        CheckBox^ CheckBoxFocus;
        CheckBox^ CheckBoxValidation;

    public:
        Form1() : Form()
        {
            this->Load += gcnew EventHandler(this, &Form1::Form1_Load);

            lblEvent = gcnew Label();
            lblInput = gcnew Label();

            TextBoxOutput = gcnew TextBox();
            TextBoxInput = gcnew TextBox();
            GroupBoxEvents = gcnew GroupBox();
            ButtonClear = gcnew Button();
            LinkLabelDrag = gcnew LinkLabel();

            CheckBoxToggleAll = gcnew CheckBox();
            CheckBoxMouse = gcnew CheckBox();
            CheckBoxMouseEnter = gcnew CheckBox();
            CheckBoxMouseMove = gcnew CheckBox();
            CheckBoxMousePoints = gcnew CheckBox();
            CheckBoxMouseDrag = gcnew CheckBox();
            CheckBoxMouseDragOver = gcnew CheckBox();
            CheckBoxKeyboard = gcnew CheckBox();
            CheckBoxKeyUpDown = gcnew CheckBox();
            CheckBoxFocus = gcnew CheckBox();
            CheckBoxValidation = gcnew CheckBox();
        }

    private:
        void Form1_Load(Object^ sender, EventArgs^ e)
        {
            this->GroupBoxEvents->SuspendLayout();
            this->SuspendLayout();

            lblEvent->Location = Point(232, 12);
            lblEvent->Size = System::Drawing::Size(98, 14);
            lblEvent->AutoSize = true;
            lblEvent->Text = "Generated Events:";

            lblInput->Location = Point(13, 12);
            lblInput->Size = System::Drawing::Size(95, 14);
            lblInput->AutoSize = true;
            lblInput->Text = "User Input Target:";

            TextBoxInput->Location = Point(13, 34);
            TextBoxInput->Size = System::Drawing::Size(200, 200);
            TextBoxInput->AllowDrop = true;
            TextBoxInput->AutoSize = false;
            TextBoxInput->Cursor = Cursors::Cross;
            TextBoxInput->Multiline = true;
            TextBoxInput->TabIndex = 1;

            LinkLabelDrag->AllowDrop = true;
            LinkLabelDrag->AutoSize = true;
            LinkLabelDrag->Location = Point(13, 240);
            LinkLabelDrag->Size = System::Drawing::Size(175, 14);
            LinkLabelDrag->TabIndex = 2;
            LinkLabelDrag->TabStop = true;
            LinkLabelDrag->Text = "Click here to use as a drag source";
            LinkLabelDrag->Links->Add(gcnew LinkLabel::Link(0,
                LinkLabelDrag->Text->Length));

            GroupBoxEvents->Location = Point(13, 281);
            GroupBoxEvents->Size = System::Drawing::Size(200, 302);
            GroupBoxEvents->Text = "Event Filter:";
            GroupBoxEvents->TabStop = true;
            GroupBoxEvents->TabIndex = 3;
            GroupBoxEvents->Controls->Add(CheckBoxMouseEnter);
            GroupBoxEvents->Controls->Add(CheckBoxToggleAll);
            GroupBoxEvents->Controls->Add(CheckBoxMousePoints);
            GroupBoxEvents->Controls->Add(CheckBoxKeyUpDown);
            GroupBoxEvents->Controls->Add(CheckBoxMouseDragOver);
            GroupBoxEvents->Controls->Add(CheckBoxMouseDrag);
            GroupBoxEvents->Controls->Add(CheckBoxValidation);
            GroupBoxEvents->Controls->Add(CheckBoxMouseMove);
            GroupBoxEvents->Controls->Add(CheckBoxFocus);
            GroupBoxEvents->Controls->Add(CheckBoxKeyboard);
            GroupBoxEvents->Controls->Add(CheckBoxMouse);

            CheckBoxToggleAll->AutoSize = true;
            CheckBoxToggleAll->Location = Point(7, 20);
            CheckBoxToggleAll->Size = System::Drawing::Size(122, 17);
            CheckBoxToggleAll->TabIndex = 4;
            CheckBoxToggleAll->Text = "Toggle All Events";

            CheckBoxMouse->AutoSize = true;
            CheckBoxMouse->Location = Point(7, 45);
            CheckBoxMouse->Size = System::Drawing::Size(137, 17);
            CheckBoxMouse->TabIndex = 5;
            CheckBoxMouse->Text = "Mouse and Click Events";

            CheckBoxMouseEnter->AutoSize = true;
            CheckBoxMouseEnter->Location = Point(26, 69);
            CheckBoxMouseEnter->Margin = 
                System::Windows::Forms::Padding(3, 3, 3, 1);
            CheckBoxMouseEnter->Size = System::Drawing::Size(151, 17);
            CheckBoxMouseEnter->TabIndex = 6;
            CheckBoxMouseEnter->Text = "Mouse Enter/Hover/Leave";

            CheckBoxMouseMove->AutoSize = true;
            CheckBoxMouseMove->Location = Point(26, 89);
            CheckBoxMouseMove->Margin = 
                System::Windows::Forms::Padding(3, 2, 3, 3);
            CheckBoxMouseMove->Size = System::Drawing::Size(120, 17);
            CheckBoxMouseMove->TabIndex = 7;
            CheckBoxMouseMove->Text = "Mouse Move Events";

            CheckBoxMousePoints->AutoSize = true;
            CheckBoxMousePoints->Location = Point(26, 112);
            CheckBoxMousePoints->Margin =
                System::Windows::Forms::Padding(3, 3, 3, 1);
            CheckBoxMousePoints->Size = System::Drawing::Size(141, 17);
            CheckBoxMousePoints->TabIndex = 8;
            CheckBoxMousePoints->Text = "Draw Mouse Points";

            CheckBoxMouseDrag->AutoSize = true;
            CheckBoxMouseDrag->Location = Point(26, 135);
            CheckBoxMouseDrag->Margin = 
                System::Windows::Forms::Padding(3, 1, 3, 3);
            CheckBoxMouseDrag->Size = System::Drawing::Size(151, 17);
            CheckBoxMouseDrag->TabIndex = 9;
            CheckBoxMouseDrag->Text = "Mouse Drag && Drop Events";

            CheckBoxMouseDragOver->AutoSize = true;
            CheckBoxMouseDragOver->Location = Point(44, 159);
            CheckBoxMouseDragOver->Size = System::Drawing::Size(142, 17);
            CheckBoxMouseDragOver->TabIndex = 10;
            CheckBoxMouseDragOver->Text = "Mouse Drag Over Events";

            CheckBoxKeyboard->AutoSize = true;
            CheckBoxKeyboard->Location = Point(8, 184);
            CheckBoxKeyboard->Size = System::Drawing::Size(103, 17);
            CheckBoxKeyboard->TabIndex = 11;
            CheckBoxKeyboard->Text = "Keyboard Events";

            CheckBoxKeyUpDown->AutoSize = true;
            CheckBoxKeyUpDown->Location = Point(26, 207);
            CheckBoxKeyUpDown->Margin = 
                System::Windows::Forms::Padding(3, 3, 3, 1);
            CheckBoxKeyUpDown->Size = System::Drawing::Size(133, 17);
            CheckBoxKeyUpDown->TabIndex = 12;
            CheckBoxKeyUpDown->Text = "Key Up && Down Events";

            CheckBoxFocus->AutoSize = true;
            CheckBoxFocus->Location = Point(8, 233);
            CheckBoxFocus->Margin = 
                System::Windows::Forms::Padding(3, 2, 3, 3);
            CheckBoxFocus->Size = System::Drawing::Size(146, 17);
            CheckBoxFocus->TabIndex = 13;
            CheckBoxFocus->Text = "Focus && Activation Events";

            CheckBoxValidation->AutoSize = true;
            CheckBoxValidation->Location = Point(8, 257);
            CheckBoxValidation->Size = System::Drawing::Size(104, 17);
            CheckBoxValidation->TabIndex = 14;
            CheckBoxValidation->Text = "Validation Events";

            TextBoxOutput->Location = Point(232, 34);
            TextBoxOutput->Size = System::Drawing::Size(308, 510);
            TextBoxOutput->Multiline = true;
            TextBoxOutput->CausesValidation = false;
            TextBoxOutput->ReadOnly = true;
            TextBoxOutput->ScrollBars = ScrollBars::Vertical;
            TextBoxOutput->TabIndex = 15;
            TextBoxOutput->WordWrap = false;

            ButtonClear->Location = Point(232, 560);
            ButtonClear->Size = System::Drawing::Size(308, 23);
            ButtonClear->TabIndex = 16;
            ButtonClear->Text = "Clear Event List";

            this->ClientSize = System::Drawing::Size(552, 595);
            this->Controls->Add(LinkLabelDrag);
            this->Controls->Add(ButtonClear);
            this->Controls->Add(GroupBoxEvents);
            this->Controls->Add(lblEvent);
            this->Controls->Add(lblInput);
            this->Controls->Add(TextBoxInput);
            this->Controls->Add(TextBoxOutput);
            this->Text = "User Input Events";

            ButtonClear->Click +=
                gcnew EventHandler(this, &Form1::ButtonClear_Click);
            TextBoxInput->KeyDown +=
                gcnew KeyEventHandler(this, &Form1::TextBoxInput_KeyDown);
            TextBoxInput->KeyPress +=
                gcnew KeyPressEventHandler(this, 
                    &Form1::TextBoxInput_KeyPress);
            TextBoxInput->KeyUp +=
                gcnew KeyEventHandler(this, &Form1::TextBoxInput_KeyUp);
            TextBoxInput->Click +=
                gcnew EventHandler(this, &Form1::TextBoxInput_Click);
            TextBoxInput->DoubleClick +=
                gcnew EventHandler(this, &Form1::TextBoxInput_DoubleClick);
            TextBoxInput->MouseClick +=
                gcnew MouseEventHandler(this, &Form1::TextBoxInput_MouseClick);
            TextBoxInput->MouseDoubleClick +=
                gcnew MouseEventHandler(this, 
                    &Form1::TextBoxInput_MouseDoubleClick);
            TextBoxInput->MouseDown +=
                gcnew MouseEventHandler(this, &Form1::TextBoxInput_MouseDown);
            TextBoxInput->MouseUp +=
                gcnew MouseEventHandler(this, &Form1::TextBoxInput_MouseUp);
            TextBoxInput->MouseEnter +=
                gcnew EventHandler(this, &Form1::TextBoxInput_MouseEnter);
            TextBoxInput->MouseHover +=
                gcnew EventHandler(this, &Form1::TextBoxInput_MouseHover);
            TextBoxInput->MouseLeave +=
                gcnew EventHandler(this, &Form1::TextBoxInput_MouseLeave);
            TextBoxInput->MouseWheel +=
                gcnew MouseEventHandler(this, &Form1::TextBoxInput_MouseWheel);
            TextBoxInput->MouseMove +=
                gcnew MouseEventHandler(this, &Form1::TextBoxInput_MouseMove);
            TextBoxInput->MouseCaptureChanged +=
                gcnew EventHandler(this, 
                    &Form1::TextBoxInput_MouseCaptureChanged);
            TextBoxInput->DragEnter +=
                gcnew DragEventHandler(this, &Form1::TextBoxInput_DragEnter);
            TextBoxInput->DragDrop +=
                gcnew DragEventHandler(this, &Form1::TextBoxInput_DragDrop);
            TextBoxInput->DragOver +=
                gcnew DragEventHandler(this, &Form1::TextBoxInput_DragOver);
            TextBoxInput->DragLeave +=
                gcnew EventHandler(this, &Form1::TextBoxInput_DragLeave);
            TextBoxInput->Enter +=
                gcnew EventHandler(this, &Form1::TextBoxInput_Enter);
            TextBoxInput->Leave +=
                gcnew EventHandler(this, &Form1::TextBoxInput_Leave);
            TextBoxInput->GotFocus +=
                gcnew EventHandler(this, &Form1::TextBoxInput_GotFocus);
            TextBoxInput->LostFocus +=
                gcnew EventHandler(this, &Form1::TextBoxInput_LostFocus);
            TextBoxInput->Validated +=
                gcnew EventHandler(this, &Form1::TextBoxInput_Validated);
            TextBoxInput->Validating +=
                gcnew CancelEventHandler(this,
                    &Form1::TextBoxInput_Validating);

            LinkLabelDrag->MouseDown +=
                gcnew MouseEventHandler(this, &Form1::LinkLabelDrag_MouseDown);
            LinkLabelDrag->GiveFeedback +=
                gcnew GiveFeedbackEventHandler(this,
                    &Form1::LinkLabelDrag_GiveFeedback);

            CheckBoxToggleAll->CheckedChanged +=
                gcnew EventHandler(this, 
                    &Form1::CheckBoxToggleAll_CheckedChanged);
            CheckBoxMouse->CheckedChanged +=
                gcnew EventHandler(this, &Form1::CheckBoxMouse_CheckedChanged);
            CheckBoxMouseDrag->CheckedChanged +=
                gcnew EventHandler(this,
                    &Form1::CheckBoxMouseDrag_CheckedChanged);
            CheckBoxMouseEnter->CheckedChanged +=
                gcnew EventHandler(this,
                    &Form1::CheckBoxMouseMove_CheckedChanged);
            CheckBoxMouseMove->CheckedChanged +=
                gcnew EventHandler(this,
                    &Form1::CheckBoxMouseMove_CheckedChanged);
            CheckBoxKeyboard->CheckedChanged +=
                gcnew EventHandler(this,
                    &Form1::CheckBoxKeyboard_CheckedChanged);

            this->GroupBoxEvents->ResumeLayout(false);
            this->GroupBoxEvents->PerformLayout();
            this->ResumeLayout(false);
            this->PerformLayout();
            CheckAllChildCheckBoxes(this, true);
        }

        // Recursively search the form for all contained checkboxes and
        // initially check them
    private:
        void CheckAllChildCheckBoxes(Control^ parent, bool value)
        {
            CheckBox^ box;
            for each (Control^ currentControl in parent->Controls)
            {
                if (dynamic_cast<CheckBox^>(currentControl))
                {
                    box = (CheckBox^)currentControl;
                    box->Checked = value;
                }

                // Recurse if control contains other controls
                if (currentControl->Controls->Count > 0)
                {
                    CheckAllChildCheckBoxes(currentControl, value);
                }
            }
        }

        // All-purpose method for displaying a line of text in the
        // text boxe.
    private:
        void DisplayLine(String^ line)
        {
            TextBoxOutput->AppendText(line);
            TextBoxOutput->AppendText(Environment::NewLine);
        }

        // Click event handler for the button that clears the text box.
    private:
        void ButtonClear_Click(Object^ sender, EventArgs^ e)
        {
            TextBoxOutput->Invalidate();
            TextBoxOutput->Clear();
        }

    private:
        void TextBoxInput_KeyDown(Object^ sender, KeyEventArgs^ e)
        {
            if (CheckBoxKeyUpDown->Checked)
            {
                DisplayLine("KeyDown: " + e->KeyData.ToString());
            }
        }

    private:
        void TextBoxInput_KeyUp(Object^ sender, KeyEventArgs^ e)
        {
            if (CheckBoxKeyUpDown->Checked)
            {
                DisplayLine("KeyUp: " + e->KeyData.ToString());
            }
        }

    private:
        void TextBoxInput_KeyPress(Object^ sender,
            KeyPressEventArgs^ e)
        {
            if (CheckBoxKeyboard->Checked)
            {
                if (Char::IsWhiteSpace(e->KeyChar))
                {
                    DisplayLine("KeyPress: WS");
                }
                else
                {
                    DisplayLine("KeyPress: " + e->KeyChar.ToString());
                }
            }
        }

    private:
        void TextBoxInput_Click(Object^ sender, EventArgs^ e)
        {
            if (CheckBoxMouse->Checked)
            {
                DisplayLine("Click event");
            }
        }

    private:
        void TextBoxInput_DoubleClick(Object^ sender, EventArgs^ e)
        {
            if (CheckBoxMouse->Checked)
            {
                DisplayLine("DoubleClick event");
            }
        }

    private:
        void TextBoxInput_MouseClick(Object^ sender, MouseEventArgs^ e)
        {
            if (CheckBoxMouse->Checked)
            {
                DisplayLine("MouseClick: " + e->Button.ToString() +
                    " " + e->Location.ToString());
            }
        }

    private:
        void TextBoxInput_MouseDoubleClick(Object^ sender,
            MouseEventArgs^ e)
        {
            if (CheckBoxMouse->Checked)
            {
                DisplayLine("MouseDoubleClick: " + e->Button.ToString() +
                    " " + e->Location.ToString());
            }
        }

    private:
        void TextBoxInput_MouseDown(Object^ sender,
            MouseEventArgs^ e)
        {
            if (CheckBoxMouse->Checked)
            {
                DisplayLine("MouseDown: " + e->Button.ToString() +
                    " " + e->Location.ToString());
            }
        }

    private:
        void TextBoxInput_MouseUp(Object^ sender,
            MouseEventArgs^ e)
        {
            if (CheckBoxMouse->Checked)
            {
                DisplayLine("MouseUp: " + e->Button.ToString() +
                    " " + e->Location.ToString());
            }

            // The TextBox control was designed to change focus only on
            // the primary click, so force focus to avoid user confusion.
            if (!TextBoxInput->Focused)
            {
                TextBoxInput->Focus();
            }
        }

    private:
        void TextBoxInput_MouseEnter(Object^ sender, EventArgs^ e)
        {
            if (CheckBoxMouseEnter->Checked)
            {
                DisplayLine("MouseEnter event");
            }
        }

    private:
        void TextBoxInput_MouseHover(Object^ sender, EventArgs^ e)
        {
            if (CheckBoxMouseEnter->Checked)
            {
                DisplayLine("MouseHover event");
            }
        }

    private:
        void TextBoxInput_MouseLeave(Object^ sender, EventArgs^ e)
        {
            if (CheckBoxMouseEnter->Checked)
            {
                DisplayLine("MouseLeave event");
            }
        }

    private:
        void TextBoxInput_MouseWheel(Object^ sender,
            MouseEventArgs^ e)
        {
            if (CheckBoxMouse->Checked)
            {
                DisplayLine("MouseWheel: " + e->Delta.ToString() +
                    " detents at " + e->Location.ToString());
            }
        }

    private:
        void TextBoxInput_MouseMove(Object^ sender,
            MouseEventArgs^ e)
        {
            if (CheckBoxMouseMove->Checked)
            {
                DisplayLine("MouseMove: " + e->Button.ToString() + " " +
                    e->Location.ToString());
            }

            if (CheckBoxMousePoints->Checked)
            {
                Graphics^ g = TextBoxInput->CreateGraphics();
                g->FillRectangle(Brushes::Black, e->Location.X,
                    e->Location.Y, 1, 1);
                delete g;
            }
        }

    private:
        void TextBoxInput_MouseCaptureChanged(Object^ sender,
            EventArgs^ e)
        {
            if (CheckBoxMouseDrag->Checked)
            {
                DisplayLine("MouseCaptureChanged event");
            }
        }

    private:
        void TextBoxInput_DragEnter(Object^ sender, DragEventArgs^ e)
        {
            if (CheckBoxMouseDrag->Checked)
            {
                Point^ pt = gcnew Point(e->X, e->Y);
                DisplayLine("DragEnter: " +
                    CovertKeyStateToString(e->KeyState)
                    + " at " + pt->ToString());
            }
        }

    private:
        void TextBoxInput_DragDrop(Object^ sender, DragEventArgs^ e)
        {
            if (CheckBoxMouseDrag->Checked)
            {
                Point^ pt = gcnew Point(e->X, e->Y);
                DisplayLine("DragDrop: " +
                    CovertKeyStateToString(e->KeyState)
                    + " at " + pt->ToString());
            }
        }

    private:
        void TextBoxInput_DragOver(Object^ sender, DragEventArgs^ e)
        {
            if (CheckBoxMouseDragOver->Checked)
            {
                Point^ pt = gcnew Point(e->X, e->Y);
                DisplayLine("DragOver: " +
                    CovertKeyStateToString(e->KeyState)
                    + " at " + pt->ToString());
            }

            // Allow if drop data is of type string.
            if (!e->Data->GetDataPresent(String::typeid))
            {
                e->Effect = DragDropEffects::None;
            }
            else
            {
                e->Effect = DragDropEffects::Copy;
            }
        }

    private:
        void TextBoxInput_DragLeave(Object^ sender,
            EventArgs^ e)
        {
            if (CheckBoxMouseDrag->Checked)
            {
                DisplayLine("DragLeave event");
            }
        }

    private:
        static String^ CovertKeyStateToString(int keyState)
        {
            String^ keyString = "None";

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

    private:
        void TextBoxInput_Enter(Object^ sender, EventArgs^ e)
        {
            if (CheckBoxFocus->Checked)
            {
                DisplayLine("Enter event");
            }
        }

    private:
        void TextBoxInput_Leave(Object^ sender, EventArgs^ e)
        {
            if (CheckBoxFocus->Checked)
            {
                DisplayLine("Leave event");
            }
        }

    private:
        void TextBoxInput_GotFocus(Object^ sender, EventArgs^ e)
        {
            if (CheckBoxFocus->Checked)
            {
                DisplayLine("GotFocus event");
            }
        }

    private:
        void TextBoxInput_LostFocus(Object^ sender, EventArgs^ e)
        {
            if (CheckBoxFocus->Checked)
            {
                DisplayLine("LostFocus event");
            }
        }

    private:
        void TextBoxInput_Validated(Object^ sender, EventArgs^ e)
        {
            if (CheckBoxValidation->Checked)
            {
                DisplayLine("Validated event");
            }
        }

    private:
        void TextBoxInput_Validating(
            Object^ sender, CancelEventArgs^ e)
        {
            if (CheckBoxValidation->Checked)
            {
                DisplayLine("Validating event");
            }
        }

    private:
        void CheckBoxToggleAll_CheckedChanged(
            Object^ sender, EventArgs^ e)
        {
            if (dynamic_cast<CheckBox^>(sender))
            {
                CheckAllChildCheckBoxes(this, ((CheckBox^)sender)->Checked);
            }
        }

    private:
        void CheckBoxMouse_CheckedChanged(
            Object^ sender, EventArgs^ e)
        {
            ConfigureCheckBoxSettings();
        }

    private:
        void CheckBoxMouseDrag_CheckedChanged(
            Object^ sender, EventArgs^ e)
        {
            ConfigureCheckBoxSettings();
        }

    private:
        void CheckBoxKeyboard_CheckedChanged(
            Object^ sender, EventArgs^ e)
        {
            ConfigureCheckBoxSettings();
        }

    private:
        void CheckBoxMouseMove_CheckedChanged(
            Object^ sender, EventArgs^ e)
        {
            ConfigureCheckBoxSettings();
        }

        // Reconcile dependencies between the check box
        // selection choices.
    private:
        void ConfigureCheckBoxSettings()
        {
            // CheckBoxMouse is a top-level check box.
            if (!CheckBoxMouse->Checked)
            {
                CheckBoxMouseEnter->Enabled = false;
                CheckBoxMouseMove->Enabled = false;
                CheckBoxMouseDrag->Enabled = false;
                CheckBoxMouseDragOver->Enabled = false;
                CheckBoxMousePoints->Enabled = false;
            }
            else
            {
                CheckBoxMouseEnter->Enabled = true;
                CheckBoxMouseMove->Enabled = true;
                CheckBoxMouseDrag->Enabled = true;
                CheckBoxMousePoints->Enabled = true;

                // Enable children depending on the state of the parent.
                if (!CheckBoxMouseDrag->Checked)
                {
                    CheckBoxMouseDragOver->Enabled = false;
                }
                else
                {
                    CheckBoxMouseDragOver->Enabled = true;
                }
            }

            if (!CheckBoxKeyboard->Checked)
            {
                CheckBoxKeyUpDown->Enabled = false;
            }
            else
            {
                CheckBoxKeyUpDown->Enabled = true;
            }
        }

    private:
        void LinkLabelDrag_MouseDown(Object^ sender, MouseEventArgs^ e)
        {
            String^ data = "Sample Data";
            LinkLabelDrag->DoDragDrop(data, DragDropEffects::All);
        }

    private:
        void LinkLabelDrag_GiveFeedback(Object^ sender,
            GiveFeedbackEventArgs^ e)
        {
            if ((e->Effect & DragDropEffects::Copy) ==
                DragDropEffects::Copy)
            {
                LinkLabelDrag->Cursor = Cursors::HSplit;
            }
            else
            {
                LinkLabelDrag->Cursor = Cursors::Default;
            }
        }
    };
}

[STAThread]
int main()
{
    Application::EnableVisualStyles();
    Application::Run(gcnew UserInputWalkthrough::Form1());
}
// </Snippet0>
