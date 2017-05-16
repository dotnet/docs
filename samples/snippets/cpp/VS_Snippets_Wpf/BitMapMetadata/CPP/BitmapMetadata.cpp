//BitmapMetadata.cpp file

using namespace System;
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

   protected: virtual void OnStartup (StartupEventArgs^ e) override 
              {
                 Application::OnStartup(e);
                 CreateAndShowMainWindow();
              };

   private: void CreateAndShowMainWindow ()
            {

               // Create the application's main window
               mainWindow = gcnew Window();
               mainWindow->Title = "Image Metadata";

               // <SnippetSetQuery>
               Stream^ pngStream = gcnew FileStream("smiley.png", FileMode::Open, FileAccess::ReadWrite, FileShare::ReadWrite);
               PngBitmapDecoder^ pngDecoder = gcnew PngBitmapDecoder(pngStream, BitmapCreateOptions::PreservePixelFormat, BitmapCacheOption::Default);
               BitmapFrame^ pngFrame = pngDecoder->Frames[0];
               InPlaceBitmapMetadataWriter^ pngInplace = pngFrame->CreateInPlaceBitmapMetadataWriter();
               if (pngInplace->TrySave() == true)
               {
                  pngInplace->SetQuery("/Text/Description", "Have a nice day.");
               }
               pngStream->Close();
               // </SnippetSetQuery>

               // Draw the Image
               Image^ myImage = gcnew Image();
               myImage->Source = gcnew BitmapImage(gcnew System::Uri("smiley.png", UriKind::Relative));
               myImage->Stretch = Stretch::None;
               myImage->Margin = System::Windows::Thickness(20);

               // <SnippetGetQuery>

               // Add the metadata of the bitmap image to the text block.
               TextBlock^ myTextBlock = gcnew TextBlock();
               myTextBlock->Text = "The Description metadata of this image is: " + pngInplace->GetQuery("/Text/Description")->ToString();
               // </SnippetGetQuery>

               // Define a StackPanel to host Controls
               StackPanel^ myStackPanel = gcnew StackPanel();
               myStackPanel->Orientation = Orientation::Vertical;
               myStackPanel->Height = 200;
               myStackPanel->VerticalAlignment = VerticalAlignment::Top;
               myStackPanel->HorizontalAlignment = HorizontalAlignment::Center;

               // Add the Image and TextBlock to the parent Grid
               myStackPanel->Children->Add(myImage);
               myStackPanel->Children->Add(myTextBlock);

               // Add the StackPanel as the Content of the Parent Window Object
               mainWindow->Content = myStackPanel;
               mainWindow->Show();
            };
   };

   // Define a static entry class
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