#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::VisualStyles;

namespace ProgressBarRendererSample
{
    public ref class VerticalProgressBar : public Control
    {
    private:
        int numberChunksValue;
        int ticks;
        Timer^ progressTimer;
        array<Rectangle>^ progressBarRectangles;

    public:
        VerticalProgressBar() : Control()
        {
            this->Location = Point(10, 10);
            this->Width = 50;
            progressTimer = gcnew Timer();

            // The progress bar will update every second.
            progressTimer->Interval = 1000;
            progressTimer->Tick += gcnew EventHandler(this,
                &VerticalProgressBar::progressTimer_Tick);

            // This property also calls SetupProgressBar to initialize
            // the progress bar rectangles if styles are enabled.
            NumberChunks = 20;

            // Set the default height if visual styles are not enabled.
            if (!ProgressBarRenderer::IsSupported)
            {
                this->Height = 100;
            }
        }

        // Specify the number of progress bar chunks to base the height on.
    public:
        property int NumberChunks
        {
            int get()
            {
                return numberChunksValue;
            }

            void set(int value)
            {
                if (value <= 50 && value > 0)
                {
                    numberChunksValue = value;
                }
                else
                {
                    MessageBox::Show("Number of chunks must be between " +
                        "0 and 50; defaulting to 10");
                    numberChunksValue = 10;
                }

                // Recalculate the progress bar size, if visual styles
                // are active.
                if (ProgressBarRenderer::IsSupported)
                {
                    SetupProgressBar();
                }
            }
        }

        // Draw the progress bar in its normal state.
    protected:
        virtual void OnPaint(PaintEventArgs^ e) override
        {
            __super::OnPaint(e);

            if (ProgressBarRenderer::IsSupported)
            {
                ProgressBarRenderer::DrawVerticalBar(e->Graphics, 
                    ClientRectangle);
                this->Parent->Text = "VerticalProgressBar Enabled";
            }
            else
            {
                this->Parent->Text = "VerticalProgressBar Disabled";
            }
        }

        // Initialize the rectangles used to paint the states of the
        // progress bar.
    private:
        void SetupProgressBar()
        {
            if (!ProgressBarRenderer::IsSupported)
            {
                return;
            }

            // Determine the size of the progress bar frame.
            this->Size = System::Drawing::Size(ClientRectangle.Width,
                (NumberChunks * (ProgressBarRenderer::ChunkThickness + 
                (2 * ProgressBarRenderer::ChunkSpaceThickness))) + 6);

            // Initialize the rectangles to draw each step of the
            // progress bar.
            progressBarRectangles = gcnew array<Rectangle>(NumberChunks);

            for (int i = 0; i < NumberChunks; i++)
            {
                // Use the thickness defined by the current visual style
                // to calculate the height of each rectangle. The size
                // adjustments ensure that the chunks do not paint over
                // the frame.

                int filledRectangleHeight = 
					((i + 1) * (ProgressBarRenderer::ChunkThickness +
					(2 * ProgressBarRenderer::ChunkSpaceThickness)));

                progressBarRectangles[i] = Rectangle(
                    ClientRectangle.X + 3,
                    ClientRectangle.Y + ClientRectangle.Height - 3
					- filledRectangleHeight,
                    ClientRectangle.Width - 6,
                    filledRectangleHeight);
            }
        }

        // Handle the timer tick; draw each progressively larger rectangle.
    private:
        void progressTimer_Tick(Object^ myObject, EventArgs^ e)
        {
            if (ticks < NumberChunks)
            {
                Graphics^ g = this->CreateGraphics();
                ProgressBarRenderer::DrawVerticalChunks(g,
                    progressBarRectangles[ticks]);
                ticks++;
            }
            else
            {
                progressTimer->Enabled = false;
            }
        }

        // Start the progress bar.
    public:
        void Start()
        {
            if (ProgressBarRenderer::IsSupported)
            {
                progressTimer->Start();
            }
            else
            {
                MessageBox::Show("VerticalScrollBar requires visual styles");
            }
        }
    };

    public ref class Form1 : public Form
    {
    private:
        VerticalProgressBar^ bar1;
        Button^ button1;

    public:
        Form1() : Form()
        {
            this->Size = System::Drawing::Size(500, 500);
            bar1 = gcnew VerticalProgressBar();
            bar1->NumberChunks = 30;
            button1 = gcnew Button();
            button1->Location = Point(150, 10);
            button1->Size = System::Drawing::Size(150, 30);
            button1->Text = "Start VerticalProgressBar";
            button1->Click += gcnew EventHandler(this, &Form1::button1_Click);
            Controls->AddRange(gcnew array<Control^> { button1, bar1 });
        }

        // Start the VerticalProgressBar.
    private:
        void button1_Click(Object^ sender, EventArgs^ e)
        {
            bar1->Start();
        }
    };
}


[STAThread]
int main()
{
    // The call to EnableVisualStyles below does not affect
    // whether ProgressBarRenderer.IsSupported is true; as
    // long as visual styles are enabled by the operating system,
    // IsSupported is true.
    Application::EnableVisualStyles();
    Application::Run(gcnew ProgressBarRendererSample::Form1());
}
