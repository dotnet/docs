//<snippet1>
#using <System.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Design.dll>

using namespace System;
using namespace System::Collections::Generic;
using namespace System::ComponentModel;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::Design;
using namespace System::Windows::Forms::Design::Behavior;
using namespace System::Text;

namespace BehaviorServiceSample
{

    public ref class UserControl1 : public UserControl
    {
    private:
        System::ComponentModel::IContainer^ components;

    public:
        UserControl1()
        {
            InitializeComponent();
        }

    protected:
        ~UserControl1()
        {
            if (components != nullptr)
            {
                delete components;
            }
        }

    private:
        void InitializeComponent()
        {
            this->Name = "UserControl1";
            this->Size = System::Drawing::Size(170, 156);
        }
    };

    public ref class Form1 : public Form
    {
    private:
        UserControl1^ userControl;

    public:
        Form1()
        {
            InitializeComponent();
        }

    private:
        System::ComponentModel::IContainer^ components;

    protected:
        ~Form1()
        {
            if (components != nullptr)
            {
                delete components;
            }
        }

    private:
        void InitializeComponent()
        {
            this->userControl = gcnew UserControl1();
            this->SuspendLayout();

            this->userControl->Location = System::Drawing::Point(12,13);
            this->userControl->Name = "userControl";
            this->userControl->Size = System::Drawing::Size(143,110);
            this->userControl->TabIndex = 0;

            this->AutoScaleBaseSize = System::Drawing::Size(5, 13);
            this->ClientSize = System::Drawing::Size(184, 153);
            this->Controls->Add(this->userControl);
            this->Name = "Form1";
            this->Text = "Form1";
            this->ResumeLayout(false);
        }
    };

    //<snippet5>

    // By providing our own behavior we can do something
    // interesting when the user clicks or manipulates our glyph.
    //<snippet6>
    public  ref class DemoBehavior : public Behavior
    {
    public:
        bool OnMouseUp(Glyph^ g, MouseButtons^ button)
        {
            MessageBox::Show("Hey, you clicked the mouse here");

            // indicating we processed this event.
            return true;
        }
    };
    //</snippet6>

    public ref class DemoGlyph : public Glyph
    {
        Control^ control;
        BehaviorService^ behavior;

        //<snippet7>
    public:
        DemoGlyph(BehaviorService^ behavior, Control^ control):
          Glyph(gcnew BehaviorServiceSample::DemoBehavior)
          {
              this->behavior = behavior;
              this->control = control;
          }
          //</snippet7>

          //<snippet8>
    public:
        virtual property Rectangle Bounds
        {
            Rectangle get() override
            {
                // Create a glyph that is 10x10 and sitting
                // in the middle of the control.  Glyph coordinates
                // are in adorner window coordinates, so we must map
                // using the behavior service.
                Point edge = behavior->ControlToAdornerWindow(control);
                Size size = control->Size;
                Point center = Point(edge.X + (size.Width / 2),
                    edge.Y + (size.Height / 2));

                Rectangle bounds = Rectangle(center.X - 5,
                    center.Y - 5, 10, 10);

                return bounds;
            }
        }
        //</snippet8>

        //<snippet9>
    public:
        virtual Cursor^ GetHitTest(Point p) override
        {
            // GetHitTest is called to see if the point is
            // within this glyph.  This gives us a chance to decide
            // what cursor to show.  Returning null from here means
            // the mouse pointer is not currently inside of the
            // glyph.  Returning a valid cursor here indicates the
            // pointer is inside the glyph, and also enables our
            // Behavior property as the active behavior.
            if (Bounds.Contains(p))
            {
                return Cursors::Hand;
            }
            return nullptr;
        }
        //</snippet9>

        //<snippet10>
    public:
        virtual void Paint(PaintEventArgs^ pe) override
        {
            // Draw our glyph.  Our's is simple:  a blue ellipse.
            pe->Graphics->FillEllipse(Brushes::Blue, Bounds);
        }
        //</snippet10>
    };

    //</snippet5>

    //<snippet2>
    public ref class DemoDesigner : public ControlDesigner
    {
    private:
        Adorner^ demoAdorner;

    protected:
        ~DemoDesigner()
        {
            if (demoAdorner != nullptr)
            {
                System::Windows::Forms::Design::Behavior::BehaviorService^ b = 
                    this->BehaviorService;
                if (b != nullptr)
                {
                    b->Adorners->Remove(demoAdorner);
                }
            }
        }

    public:
        virtual void Initialize(IComponent^ component) override
        {
            __super::Initialize(component);

            // Get a hold of the behavior service and add our own set
            // of glyphs.  Glyphs live on adorners.
            //<snippet4>
            //<snippet3>
            demoAdorner = gcnew Adorner();
            BehaviorService->Adorners->Add(demoAdorner);
            //</snippet3>
            demoAdorner->Glyphs->Add 
                (gcnew DemoGlyph(BehaviorService, Control));
            //</snippet4>
        }
    };
    //</snippet2>
}

[STAThread]
int main()
{
    Application::EnableVisualStyles();
    Application::Run(gcnew BehaviorServiceSample::Form1());
}


//</snippet1>
