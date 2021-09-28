//WDPEncoderDecoder.cpp file


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

   private: Window^ mainWindow;

   protected: virtual void OnStartup (System::Windows::StartupEventArgs^ e) override 
              {
                 Application::OnStartup(e);
                 CreateAndShowMainWindow();
              };

   private: void CreateAndShowMainWindow () 
            {

               // Create the application's main window
               mainWindow = gcnew System::Windows::Window();
               mainWindow->Title = "WDP Imaging Sample";
               ScrollViewer^ mySV = gcnew ScrollViewer();

               //<Snippet4>
               int width = 128;
               int height = width;
               int stride = width / 8;
               array<System::Byte>^ pixels = gcnew array<System::Byte>(height * stride);

               // Define the image palette
               BitmapPalette^ myPalette = BitmapPalettes::WebPalette;

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
               FileStream^ stream = gcnew FileStream("new.wdp", FileMode::Create);
               WmpBitmapEncoder^ encoder = gcnew WmpBitmapEncoder();
               TextBlock^ myTextBlock = gcnew TextBlock();
               myTextBlock->Text = "Codec Author is: " + encoder->CodecInfo->Author->ToString();
               encoder->Frames->Add(BitmapFrame::Create(image));
               encoder->Save(stream);
               //</Snippet3>

               //</Snippet4>

               //<Snippet1>

               // Open a Stream and decode a WDP image
               Stream^ imageStreamSource = gcnew FileStream("tulipfarm.wdp", FileMode::Open, FileAccess::Read, FileShare::Read);
               WmpBitmapDecoder^ decoder = gcnew WmpBitmapDecoder(imageStreamSource, BitmapCreateOptions::PreservePixelFormat, BitmapCacheOption::Default);
               BitmapSource^ bitmapSource = decoder->Frames[0];

               // Draw the Image
               Image^ myImage = gcnew Image();
               myImage->Source = bitmapSource;
               myImage->Stretch = Stretch::None;
               myImage->Margin = System::Windows::Thickness(20);
               //</Snippet1>

               //<Snippet5>

               // Open a Uri and decode a WDP image
               System::Uri^ myUri = gcnew System::Uri("tulipfarm.wdp", UriKind::RelativeOrAbsolute);
               WmpBitmapDecoder^ decoder3 = gcnew WmpBitmapDecoder(myUri, BitmapCreateOptions::PreservePixelFormat, BitmapCacheOption::Default);
               BitmapSource^ bitmapSource3 = decoder3->Frames[0];

               // Draw the Image
               Image^ myImage2 = gcnew Image();
               myImage2->Source = bitmapSource3;
               myImage2->Stretch = Stretch::None;
               myImage2->Margin = System::Windows::Thickness(20);
               //</Snippet5>

               //<Snippet6>
               FileStream^ stream2 = gcnew FileStream("tulipfarm.jpg", FileMode::Open);
               JpegBitmapDecoder^ decoder2 = gcnew JpegBitmapDecoder(stream2, BitmapCreateOptions::PreservePixelFormat, BitmapCacheOption::Default);
               BitmapSource^ bitmapSource2 = decoder2->Frames[0];
               FileStream^ stream3 = gcnew FileStream("new2.wdp", FileMode::Create);
               WmpBitmapEncoder^ encoder2 = gcnew WmpBitmapEncoder();
               encoder2->Frames->Add(BitmapFrame::Create(bitmapSource2));
               encoder2->Save(stream3);
               //</Snippet6>

               // Define a StackPanel to host the decoded WDP images
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
            };
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

//Entry Point:
[System::STAThreadAttribute()]
void main ()
{
   return SDKSample::EntryClass::Main();
}
