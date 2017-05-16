// <Snippet0>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;

namespace SingleVersusDoubleClick
{
    public ref class Form1 : public Form
    {
    private:
        Rectangle hitTestRectangle;
    private:
        Rectangle doubleClickRectangle;
    private:
        TextBox^ outputBox;
    private:
        Timer^ doubleClickTimer;
    private:
        ProgressBar^ doubleClickBar;
    private:
        Label^ hitTestLabel;
    private:
        Label^ timerLabel;
    private:
        bool isFirstClick;
    private:
        bool isDoubleClick;
    private:
        int milliseconds;

    public:
        Form1()
        {
            hitTestRectangle = Rectangle();
            hitTestRectangle.Location = Point(30, 20);
            hitTestRectangle.Size = System::Drawing::Size(100, 40);

            doubleClickRectangle = Rectangle();

            outputBox = gcnew TextBox();
            outputBox->Location = Point(30, 120);
            outputBox->Size = System::Drawing::Size(200, 100);
            outputBox->AutoSize = false;
            outputBox->Multiline = true;

            doubleClickTimer = gcnew Timer();
            doubleClickTimer->Interval = 100;
            doubleClickTimer->Tick +=
                gcnew EventHandler(this, &Form1::doubleClickTimer_Tick);

            doubleClickBar = gcnew ProgressBar();
            doubleClickBar->Location = Point(30, 85);
            doubleClickBar->Minimum = 0;
            doubleClickBar->Maximum = SystemInformation::DoubleClickTime;

            hitTestLabel = gcnew Label();
            hitTestLabel->Location = Point(30, 5);
            hitTestLabel->Size = System::Drawing::Size(100, 15);
            hitTestLabel->Text = "Hit test rectangle:";

            timerLabel = gcnew Label();
            timerLabel->Location = Point(30, 70);
            timerLabel->Size = System::Drawing::Size(100, 15);
            timerLabel->Text = "Double click timer:";

            isFirstClick = true;

            this->Paint += gcnew PaintEventHandler(this, &Form1::Form1_Paint);
            this->MouseDown += 
                gcnew MouseEventHandler(this, &Form1::Form1_MouseDown);
            this->Controls->
                AddRange(gcnew array<Control^> { doubleClickBar, outputBox,
                hitTestLabel, timerLabel });
        }

        // <Snippet10>
        // Detect a valid single click or double click.
    private:
        void Form1_MouseDown(Object^ sender, MouseEventArgs^ e)
        {
            // Verify that the mouse click is in the main hit
            // test rectangle.
            if (!hitTestRectangle.Contains(e->Location))
            {
                return;
            }

            // This is the first mouse click.
            if (isFirstClick)
            {
                isFirstClick = false;

                // Determine the location and size of the double click
                // rectangle area to draw around the cursor point.
                doubleClickRectangle = Rectangle(
                    e->X - (SystemInformation::DoubleClickSize.Width / 2),                    
                    e->Y - (SystemInformation::DoubleClickSize.Height / 2),                    
                    SystemInformation::DoubleClickSize.Width,                    
                    SystemInformation::DoubleClickSize.Height);
                Invalidate();

                // Start the double click timer.
                doubleClickTimer->Start();
            }

            // This is the second mouse click.
            else
            {
                // Verify that the mouse click is within the double click
                // rectangle and is within the system-defined double
                // click period.
                if (doubleClickRectangle.Contains(e->Location) &&
                    milliseconds < SystemInformation::DoubleClickTime)
                {
                    isDoubleClick = true;
                }
            }
        }
        // </Snippet10>

    private:
        void doubleClickTimer_Tick(Object^ sender, EventArgs^ e)
        {
            milliseconds += 100;
            doubleClickBar->Increment(100);

            // The timer has reached the double click time limit.
            if (milliseconds >= SystemInformation::DoubleClickTime)
            {
                doubleClickTimer->Stop();

                if (isDoubleClick)
                {
                    outputBox->AppendText("Perform double click action");
                    outputBox->AppendText(Environment::NewLine);
                }
                else
                {
                    outputBox->AppendText("Perform single click action");
                    outputBox->AppendText(Environment::NewLine);
                }

                // Allow the MouseDown event handler to process clicks again.
                isFirstClick = true;
                isDoubleClick = false;
                milliseconds = 0;
                doubleClickBar->Value = 0;
            }
        }

        // Paint the hit test and double click rectangles.
    private:
        void Form1_Paint(Object^ sender, PaintEventArgs^ e)
        {
            // Draw the border of the main hit test rectangle.
            e->Graphics->DrawRectangle(Pens::Black, hitTestRectangle);

            // Fill in the double click rectangle.
            e->Graphics->FillRectangle(Brushes::Blue, doubleClickRectangle);
        }
    };
}


[STAThread]
int main()
{
    Application::EnableVisualStyles();
    Application::Run(gcnew SingleVersusDoubleClick::Form1);
}
// </Snippet0>
