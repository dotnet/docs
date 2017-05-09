

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

// <snippet1>
using namespace System::Drawing;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Resources;
public ref class Form1: public Form
{
public:
   Form1()
   {
      IContainer^ components = gcnew System::ComponentModel::Container;
      ResourceManager^ resources = gcnew ResourceManager( Form1::typeid );
      TabControl^ tabControl1 = gcnew TabControl;
      TabPage^ tabPage1 = gcnew TabPage;
      
      // Declares and instantiates the ImageList Object*.
      ImageList^ myImages = gcnew ImageList( components );
      tabControl1->Controls->Add( tabPage1 );
      
      // Sets the images in myImages to display on the tabs of tabControl1. 
      tabControl1->ImageList = myImages;
      tabPage1->ImageIndex = 0;
      tabPage1->Text = "tabPage1";
      
      // Gets the handle that provides the data of myImages.
      myImages->ImageStream = (dynamic_cast<ImageListStreamer^>(resources->GetObject( "myImages.ImageStream" )));
      
      // Sets properties of myImages. 
      myImages->ColorDepth = ColorDepth::Depth8Bit;
      myImages->ImageSize = System::Drawing::Size( 16, 16 );
      myImages->TransparentColor = Color::Transparent;
      this->Controls->Add( tabControl1 );
   }

};

int main()
{
   Application::Run( gcnew Form1 );
}

// </snippet1>
