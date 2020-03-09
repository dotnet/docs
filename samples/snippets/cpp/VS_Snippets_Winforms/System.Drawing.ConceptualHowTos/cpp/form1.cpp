#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Windows::Forms;
using namespace System::Drawing;


public ref class Form1: public System::Windows::Forms::Form
{
private:
    void DoSomething1()
    {
        // Snippet for:
        // \vbtskcodeexampledrawingfilledellipseonform.xml
        // <snippet1>
        System::Drawing::SolidBrush^ myBrush =
            gcnew System::Drawing::SolidBrush(System::Drawing::Color::Red);
        System::Drawing::Graphics^ formGraphics;
        formGraphics = this->CreateGraphics();
        formGraphics->FillEllipse(myBrush, Rectangle(0, 0, 200, 300));
        delete myBrush;
        delete formGraphics;
        // </snippet1>
    }

private:
    void DoSomething2()
    {
        // Snippet for:
        // \vbtskcodeexampledrawingfilledrectangleonform.xml
        // <snippet2>
        System::Drawing::SolidBrush^ myBrush =
            gcnew System::Drawing::SolidBrush(System::Drawing::Color::Red);
        System::Drawing::Graphics^ formGraphics;
        formGraphics = this->CreateGraphics();
        formGraphics->FillRectangle(myBrush, Rectangle(0, 0, 200, 300));
        delete myBrush;
        delete formGraphics;
        // </snippet2>
    }

private:
    void DoSomething3()
    {
        // Snippet for: \vbtskcodeexamplecreatingpen.xml
        // <snippet3>
        System::Drawing::Pen^ myPen;
        myPen = gcnew System::Drawing::Pen(System::Drawing::Color::Tomato);
        // </snippet3>
    }

private:
    void DoSomething4()
    {
        // Snippet for: \vbtskcodeexamplecreatingsolidbrush.xml
        // <snippet4>
        System::Drawing::SolidBrush^ myBrush;
        myBrush = gcnew System::Drawing::SolidBrush(
            System::Drawing::Color::PeachPuff);
        // </snippet4>
    }

private:
    void DoSomething5()
    {
        // Snippet for: \vbtskcodeexampledrawinglineonform.xml
        // <snippet5>
        System::Drawing::Pen^ myPen =
            gcnew System::Drawing::Pen(System::Drawing::Color::Red);
        System::Drawing::Graphics^ formGraphics;
        formGraphics = this->CreateGraphics();
        formGraphics->DrawLine(myPen, 0, 0, 200, 200);
        delete myPen;
        delete formGraphics;
        // </snippet5>
    }

    // Snippet for: \vbtskcodeexampledrawingoutlinedshapes.xml
    // <snippet6>
private:
    void DrawEllipse()
    {
        System::Drawing::Pen^ myPen =
            gcnew System::Drawing::Pen(System::Drawing::Color::Red);
        System::Drawing::Graphics^ formGraphics;
        formGraphics = this->CreateGraphics();
        formGraphics->DrawEllipse(myPen, Rectangle(0, 0, 200, 300));
        delete myPen;
        delete formGraphics;
    }

private:
    void DrawRectangle()
    {
        System::Drawing::Pen^ myPen =
            gcnew System::Drawing::Pen(System::Drawing::Color::Red);
        System::Drawing::Graphics^ formGraphics;
        formGraphics = this->CreateGraphics();
        formGraphics->DrawRectangle(myPen, Rectangle(0, 0, 200, 300));
        delete myPen;
        delete formGraphics;
    }

    // </snippet6>
    // Snippet for: \vbtskcodeexampledrawingtextonform2.xml
    // <snippet7>
public:
    void DrawString()
    {
        System::Drawing::Graphics^ formGraphics = this->CreateGraphics();
        String^ drawString = "Sample Text";
        System::Drawing::Font^ drawFont =
            gcnew System::Drawing::Font("Arial", 16);
        System::Drawing::SolidBrush^ drawBrush = gcnew
            System::Drawing::SolidBrush(System::Drawing::Color::Black);
        float x = 150.0F;
        float y = 50.0F;
        System::Drawing::StringFormat^ drawFormat =
            gcnew System::Drawing::StringFormat();
        formGraphics->DrawString(drawString, drawFont, drawBrush, x,
            y, drawFormat);
        delete drawFont;
        delete drawBrush;
        delete formGraphics;
    }

    // </snippet7>
    // Snippet for: \vbtskcodeexampledrawingtextonform.xml
    // <snippet8>
public:
    void DrawVerticalString()
    {
        System::Drawing::Graphics^ formGraphics = this->CreateGraphics();
        String^ drawString = "Sample Text";
        System::Drawing::Font^ drawFont =
            gcnew System::Drawing::Font("Arial", 16);
        System::Drawing::SolidBrush^ drawBrush = gcnew
            System::Drawing::SolidBrush(System::Drawing::Color::Black);
        float x = 150.0F;
        float y = 50.0F;
        System::Drawing::StringFormat^ drawFormat =
            gcnew System::Drawing::StringFormat();
        drawFormat->FormatFlags = StringFormatFlags::DirectionVertical;
        formGraphics->DrawString(drawString, drawFont, drawBrush, x,
            y, drawFormat);
        delete drawFont;
        delete drawBrush;
        delete formGraphics;
    }

    // </snippet8>
private:
    void DoSomething9()
    {
        Pen^ myPen = gcnew Pen(Color::Red);
        // Snippet for: \vbtskcodeexamplesetcolorofpen.xml
        // <snippet9>
        myPen->Color = System::Drawing::Color::PeachPuff;
        // </snippet9>
    }
    // Snippet for: \vbtskcreateashapedwindowsform.xml
    // <snippet10>
protected:
    virtual void OnPaint(
        System::Windows::Forms::PaintEventArgs^ e) override
    {
        System::Drawing::Drawing2D::GraphicsPath^ shape =
            gcnew System::Drawing::Drawing2D::GraphicsPath();
        shape->AddEllipse(0, 0, this->Width, this->Height);
        this->Region = gcnew System::Drawing::Region(shape);
    }
    // </snippet10>
};

int main()
{
    Application::Run(gcnew Form1());
}
