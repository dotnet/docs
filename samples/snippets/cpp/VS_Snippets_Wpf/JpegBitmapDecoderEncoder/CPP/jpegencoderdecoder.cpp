//jpegencoderdecoder.cpp file

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

   private:
      System::Windows::Window^ mainWindow;

   protected:
      virtual void OnStartup (System::Windows::StartupEventArgs^ e) override 
      {
         Application::OnStartup(e);
         CreateAndShowMainWindow();
      };

   private:
      void CreateAndShowMainWindow () 
      {
         // Create the application's main window
         mainWindow = gcnew System::Windows::Window();
         mainWindow->Title = "JPEG Imaging Sample";
         System::Windows::Controls::ScrollViewer^ mySV = gcnew System::Windows::Controls::ScrollViewer();

         //<Snippet4>
         int width = 128;
         int height = width;
         int stride = width / 8;
         array<System::Byte>^ pixels = gcnew array<System::Byte>(height * stride);

         // Define the image palette
         BitmapPalette^ myPalette = BitmapPalettes::Halftone256;

         // Creates a new empty image with the pre-defined palette.
         //<Snippet2>
         BitmapSource^ image = BitmapSource::Create(
            width, height,
            96, 96,
            PixelFormats::Indexed1,
            myPalette,
            pixels,
            stride);
         //</Snippet2>
         //<Snippet3>

         System::IO::FileStream^ stream = gcnew System::IO::FileStream("new.jpg", FileMode::Create);
         JpegBitmapEncoder^ encoder = gcnew JpegBitmapEncoder();
         TextBlock^ myTextBlock = gcnew System::Windows::Controls::TextBlock();
         myTextBlock->Text = "Codec Author is: " + encoder->CodecInfo->Author->ToString();
         encoder->FlipHorizontal = true;
         encoder->FlipVertical = false;
         encoder->QualityLevel = 30;
         encoder->Rotation = Rotation::Rotate90;
         encoder->Frames->Add(BitmapFrame::Create(image));
         encoder->Save(stream);
         //</Snippet3>
         //</Snippet4>

         //<Snippet1>
         // Open a Stream and decode a JPEG image
         Stream^ imageStreamSource = gcnew FileStream("tulipfarm.jpg", FileMode::Open, FileAccess::Read, FileShare::Read);
         JpegBitmapDecoder^ decoder = gcnew JpegBitmapDecoder(imageStreamSource, BitmapCreateOptions::PreservePixelFormat, BitmapCacheOption::Default);
         BitmapSource^ bitmapSource = decoder->Frames[0];

         // Draw the Image
         Image^ myImage = gcnew Image();
         myImage->Source = bitmapSource;
         myImage->Stretch = Stretch::None;
         myImage->Margin = System::Windows::Thickness(20);
         //</Snippet1>

         //<Snippet5>
         // Open a Uri and decode a JPEG image
         System::Uri^ myUri = gcnew System::Uri("tulipfarm.jpg", UriKind::RelativeOrAbsolute);
         JpegBitmapDecoder^ decoder2 = gcnew JpegBitmapDecoder(myUri, BitmapCreateOptions::PreservePixelFormat, BitmapCacheOption::Default);
         BitmapSource^ bitmapSource2 = decoder2->Frames[0];

         // Draw the Image
         Image^ myImage2 = gcnew Image();
         myImage2->Source = bitmapSource2;
         myImage2->Stretch = Stretch::None;
         myImage2->Margin = System::Windows::Thickness(20);
         //</Snippet5>

         // Define a StackPanel to host the decoded JPEG images
         StackPanel^ myStackPanel = gcnew StackPanel();
         myStackPanel->Orientation = Orientation::Vertical;
         myStackPanel->VerticalAlignment = VerticalAlignment::Stretch;
         myStackPanel->HorizontalAlignment = HorizontalAlignment::Stretch;

         // Add the Image and TextBlock to the parent Grid.
         myStackPanel->Children->Add(myImage);
         myStackPanel->Children->Add(myImage2);
         myStackPanel->Children->Add(myTextBlock);

         // Add the StackPanel as the content of the parent window.
         mySV->Content = myStackPanel;
         mainWindow->Content = mySV;
         mainWindow->Show();
      };
   };

   private ref class EntryClass {

   public: 
      [System::STAThreadAttribute()]
      static void Main () 
      {
         SDKSample::app^ app = gcnew SDKSample::app();
         app->Run();
      }
      ;
   };
}

//Entry Point:
[System::STAThreadAttribute()]
int main(array<System::String ^> ^args)
{
   return SDKSample::EntryClass::Main();
}
