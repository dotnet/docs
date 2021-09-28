using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Windows;
using namespace System::Windows::Controls;
using namespace System::Windows::Media;
using namespace System::Windows::Media::Imaging;
using namespace System::Threading;
using namespace System::Security;

namespace SDKSample {

	public ref class app : Application {

		private: System::Windows::Window^ mainWindow;

		protected: virtual void OnStartup (System::Windows::StartupEventArgs^ e) override 
        {
        	Application::OnStartup(e);
         	CreateAndShowMainWindow();
        };

		private: void CreateAndShowMainWindow () 
		{
			// Create the application's main window
            mainWindow = gcnew System::Windows::Window();
            mainWindow->Title = "BMP Imaging Sample";
            ScrollViewer^ mySV = gcnew ScrollViewer();

            //<Snippet4>
            int width = 128;
            int height = width;
            int stride = width / 8;
            array<System::Byte>^ pixels = gcnew array<System::Byte>(height * stride);

			List<Color>^ colors = gcnew List<Color>();
            colors->Add(Colors::Red);
            colors->Add(Colors::Blue);
            colors->Add(Colors::Green);
            BitmapPalette^ myPalette = gcnew BitmapPalette(colors);

			// Creates a new empty image with the pre-defined palette

               //<Snippet2>
               BitmapSource^ image = BitmapSource::Create(
                  width,
                  height,
                  96,
                  96,
                  PixelFormats::Indexed1,
                  myPalette,
                  pixels,
                  stride);
               //</Snippet2>

			   //<Snippet3>
               FileStream^ stream = gcnew FileStream("new.bmp", FileMode::Create);
               BmpBitmapEncoder^ encoder = gcnew BmpBitmapEncoder();
               TextBlock^ myTextBlock = gcnew TextBlock();
               myTextBlock->Text = "Codec Author is: " + encoder->CodecInfo->Author->ToString();
               encoder->Frames->Add(BitmapFrame::Create(image));
               encoder->Save(stream);
               //</Snippet3>

               //</Snippet4>

               //<Snippet1>

			   // Open a Stream and decode a BMP image
               Stream^ imageStreamSource = gcnew FileStream("tulipfarm.bmp", FileMode::Open, FileAccess::Read, FileShare::Read);
               BmpBitmapDecoder^ decoder = gcnew BmpBitmapDecoder(imageStreamSource, BitmapCreateOptions::PreservePixelFormat, BitmapCacheOption::Default);
               BitmapSource^ bitmapSource = decoder->Frames[0];

               // Draw the Image
               Image^ myImage = gcnew Image();
               myImage->Source = bitmapSource;
               myImage->Stretch = Stretch::None;
               myImage->Margin = System::Windows::Thickness(20);
               //</Snippet1>

               //<Snippet5>

               // Open a Uri and decode a BMP image
               System::Uri^ myUri = gcnew System::Uri("tulipfarm.bmp", UriKind::RelativeOrAbsolute);
               BmpBitmapDecoder^ decoder2 = gcnew BmpBitmapDecoder(myUri, BitmapCreateOptions::PreservePixelFormat, BitmapCacheOption::Default);
               BitmapSource^ bitmapSource2 = decoder2->Frames[0];

               // Draw the Image
               Image^ myImage2 = gcnew Image();
               myImage2->Source = bitmapSource2;
               myImage2->Stretch = Stretch::None;
               myImage2->Margin = System::Windows::Thickness(20);
               //</Snippet5>

			// Define a StackPanel to host the decoded BMP images
			StackPanel^ myStackPanel = gcnew StackPanel();
		    myStackPanel->Orientation = Orientation::Vertical;
		    myStackPanel->VerticalAlignment = VerticalAlignment::Stretch;
		    myStackPanel->HorizontalAlignment = HorizontalAlignment::Stretch;

		    // Add the Image and TextBlock to the parent Grid
		    myStackPanel->Children->Add(myImage);
		    myStackPanel->Children->Add(myImage2);
		    myStackPanel->Children->Add(myTextBlock);

 		    // Add the StackPanel as the Content of the Parent Window Object
 		    mySV->Content = myStackPanel;
		    mainWindow->Content = mySV;
		    mainWindow->Show();
		}	


	};


	private ref class EntryClass {

  	public: 
    	[System::STAThread()]
    	static void Main () 
    	{
    		SDKSample::app^ app = gcnew SDKSample::app();
        	app->Run();
    	};
   	};

}


[System::STAThreadAttribute()]
void main ()
{
    return SDKSample::EntryClass::Main();
}