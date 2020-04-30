#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::VisualStyles;

namespace SimpleVisualStyleRendererSample
{
    public ref class CustomControl : public Control
    {
        // <Snippet4>
    private:
        VisualStyleRenderer^ renderer;
        VisualStyleElement^ element;

    public:
        CustomControl()
        {
            this->Location = Point(50, 50);
            this->Size = System::Drawing::Size(200, 200);
            this->BackColor = SystemColors::ActiveBorder;
            this->element = 
                VisualStyleElement::StartPanel::LogOffButtons::Normal;
            if (Application::RenderWithVisualStyles &&
                VisualStyleRenderer::IsElementDefined(element))
            {
                renderer = gcnew VisualStyleRenderer(element);
            }
        }
        // </Snippet4>

        // <Snippet6>
    protected:
        virtual void OnPaint(PaintEventArgs^ e) override
        {
            // Draw the element if the renderer has been set.
            if (renderer != nullptr)
            {
                renderer->DrawBackground(e->Graphics, this->ClientRectangle);
            }

            // Visual styles are disabled or the element is undefined,
            // so just draw a message.
            else
            {
                this->Text = "Visual styles are disabled.";
                TextRenderer::DrawText(e->Graphics, this->Text, this->Font,
                    Point(0, 0), this->ForeColor);
            }
        }
        // </Snippet6>
    };

    public ref class SimpleVisualStyleRendererForm : public Form
    {
    public:
        SimpleVisualStyleRendererForm()
        {
            this->Size = System::Drawing::Size(400, 400);
            this->BackColor = Color::WhiteSmoke;
            this->Controls->Add(gcnew CustomControl());
        }
    };
}

using namespace SimpleVisualStyleRendererSample;

[STAThread]
int main()
{
    Application::EnableVisualStyles();
    Application::Run(gcnew SimpleVisualStyleRendererForm());
}
