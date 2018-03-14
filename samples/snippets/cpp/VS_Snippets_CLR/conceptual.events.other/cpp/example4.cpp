//<snippet40>
//<snippet44>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class MyForm : Form
{
private:
    TextBox^ box;
    Button^ button;

public:
    MyForm() : Form()
    {
        box = gcnew TextBox();
        box->BackColor = System::Drawing::Color::Cyan;
        box->Size = System::Drawing::Size(100,100);
        box->Location = System::Drawing::Point(50,50);
        box->Text = "Hello";

        button = gcnew Button();
        button->Location = System::Drawing::Point(50,100);
        button->Text = "Click Me";

        // To wire the event, create
        // a delegate instance and add it to the Click event.
        button->Click += gcnew EventHandler(this, &MyForm::Button_Click);
        Controls->Add(box);
        Controls->Add(button);
    }

private:
    // The event handler.
    void Button_Click(Object^ sender, EventArgs^ e)
    {
        box->BackColor = System::Drawing::Color::Green;
    }

    // The STAThreadAttribute indicates that Windows Forms uses the
    // single-threaded apartment model.
public:
    [STAThread]
    static void Main()
    {
        Application::Run(gcnew MyForm());
    }
};

int main()
{
    MyForm::Main();
}
//</snippet44>

public ref class SnippetForm : Form
{
//<snippet41>
private:
    Button^ button;
//</snippet41>

 //<snippet42>
private:
    void Button_Click(Object^ sender, EventArgs^ e)
    {
        //...
    }
//</snippet42>


public:
    SnippetForm() : Form()
    {
        button = gcnew Button();

        //<snippet43>
        button->Click += gcnew EventHandler(this, &SnippetForm::Button_Click);
        //</snippet43>
    }
};

#if 0
//<snippet45>
cl /clr:pure WinEvents.cpp
//</snippet45>
#endif
//</snippet40>
