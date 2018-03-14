#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::IO;

public ref class Form1: public Form
{
#pragma region " Windows Form Designer generated code "

public:
    Form1() : Form()
    {
        //This call is required by the Windows Form Designer.
        InitializeComponent();

        //Add any initialization after the InitializeComponent() call
    }

    //Form overrides dispose to clean up the component list.
protected:
    ~Form1() 
    {
        if (components != nullptr)
        {
            delete components;
        }
    }

    //Required by the Windows Form Designer
private:
    System::ComponentModel::IContainer^ components;

    //NOTE: The following procedure is required by the Windows Form Designer
    //It can be modified using the Windows Form Designer.
    //Do not modify it using the code editor.
private:
    [System::Diagnostics::DebuggerStepThrough]
    void InitializeComponent()
    {
        //
        // Form1
        //
        this->AutoScaleBaseSize = System::Drawing::Size(5, 13);
        this->ClientSize = System::Drawing::Size(292, 266);
        this->Name = "Form1";
        this->Text = "Form1";
        this->Paint += 
            gcnew System::Windows::Forms::PaintEventHandler
            (this,&Form1::Form1_Paint);
    }

#pragma endregion

    //<snippet1>
private:
    void ConstructFromResourceSaveAsGif(PaintEventArgs^ e)
    {
        // Construct a bitmap from the button image resource.
        Bitmap^ bmp1 = gcnew Bitmap(Button::typeid, "Button.bmp");
        String^ savePath =  
            Environment::GetEnvironmentVariable("TEMP") + "\\Button.bmp";

        try
        {
            // Save the image as a GIF.
            bmp1->Save(savePath, System::Drawing::Imaging::ImageFormat::Gif);
        }
        catch (IOException^)
        {
            // Carry on regardless
        }

        // Construct a new image from the GIF file.
        Bitmap^ bmp2 = nullptr;
        if (File::Exists(savePath))
        {
            bmp2 = gcnew Bitmap(savePath);
        }

        // Draw the two images.
        e->Graphics->DrawImage(bmp1, Point(10, 10));

        // If bmp1 did not save to disk, bmp2 may be null
        if (bmp2 != nullptr)
        {
            e->Graphics->DrawImage(bmp2, Point(10, 40));
        }

        // Dispose of the image files.
        delete bmp1;
        if (bmp2 != nullptr)
        {
            delete bmp2;
        }
    }
    //</snippet1>

private:
    void Form1_Paint(Object^ sender, PaintEventArgs^ e)
    {
        ConstructFromResourceSaveAsGif(e);
    }
};

[STAThread]
int main()
{
    Application::Run(gcnew Form1());
}
