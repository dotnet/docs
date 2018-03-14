//StackPanel_Ovw_Sample4.cpp file

using namespace System;
using namespace System::Windows;
using namespace System::Windows::Controls;
using namespace System::Windows::Media;
using namespace System::Windows::Media::Imaging;
using namespace System::Threading;

namespace SDKSample {

   public ref class app : Application {

   private: 
      Border^ myBorder;
      Grid^ myGrid;
      StackPanel^ myStackPanel;
      DockPanel^ myDockPanel;
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
         // <Snippet1>

         // Create the application's main window
         mainWindow = gcnew Window();
         mainWindow->Title = "StackPanel vs. DockPanel";

         // Add root Grid
         myGrid = gcnew Grid();
         myGrid->Width = 175;
         myGrid->Height = 150;
         RowDefinition^ myRowDef1 = gcnew RowDefinition();
         RowDefinition^ myRowDef2 = gcnew RowDefinition();
         myGrid->RowDefinitions->Add(myRowDef1);
         myGrid->RowDefinitions->Add(myRowDef2);

         // Define the DockPanel
         myDockPanel = gcnew DockPanel();
         Grid::SetRow(myDockPanel, 0);

         //Define an Image and Source
         Image^ myImage = gcnew Image();
         BitmapImage^ bi = gcnew BitmapImage();
         bi->BeginInit();
         bi->UriSource = gcnew System::Uri("smiley_stackpanel.png", UriKind::Relative);
         bi->EndInit();
         myImage->Source = bi;

         Image^ myImage2 = gcnew Image();
         BitmapImage^ bi2 = gcnew BitmapImage();
         bi2->BeginInit();
         bi2->UriSource = gcnew System::Uri("smiley_stackpanel.png", UriKind::Relative);
         bi2->EndInit();
         myImage2->Source = bi2;

         // <Snippet3>
         Image^ myImage3 = gcnew Image();
         BitmapImage^ bi3 = gcnew BitmapImage();
         bi3->BeginInit();
         bi3->UriSource = gcnew System::Uri("smiley_stackpanel.PNG", UriKind::Relative);
         bi3->EndInit();
         myImage3->Stretch = Stretch::Fill;
         myImage3->Source = bi3;
         //</Snippet3>

         // Add the images to the parent DockPanel
         myDockPanel->Children->Add(myImage);
         myDockPanel->Children->Add(myImage2);
         myDockPanel->Children->Add(myImage3);

         //Define a StackPanel
         myStackPanel = gcnew StackPanel();
         myStackPanel->Orientation = Orientation::Horizontal;
         Grid::SetRow(myStackPanel, 1);

         Image^ myImage4 = gcnew Image();
         BitmapImage^ bi4 = gcnew BitmapImage();
         bi4->BeginInit();
         bi4->UriSource = gcnew System::Uri("smiley_stackpanel.png", UriKind::Relative);
         bi4->EndInit();
         myImage4->Source = bi4;

         Image^ myImage5 = gcnew Image();
         BitmapImage^ bi5 = gcnew BitmapImage();
         bi5->BeginInit();
         bi5->UriSource = gcnew System::Uri("smiley_stackpanel.png", UriKind::Relative);
         bi5->EndInit();
         myImage5->Source = bi5;

         Image^ myImage6 = gcnew Image();
         BitmapImage^ bi6 = gcnew BitmapImage();
         bi6->BeginInit();
         bi6->UriSource = gcnew System::Uri("smiley_stackpanel.PNG", UriKind::Relative);
         bi6->EndInit();
         myImage6->Stretch = Stretch::Fill;
         myImage6->Source = bi6;

         // Add the images to the parent StackPanel
         myStackPanel->Children->Add(myImage4);
         myStackPanel->Children->Add(myImage5);
         myStackPanel->Children->Add(myImage6);

         // Add the layout panels as children of the Grid
         myGrid->Children->Add(myDockPanel);
         myGrid->Children->Add(myStackPanel);

         // Add the Grid as the Content of the Parent Window Object
         mainWindow->Content = myGrid;
         mainWindow->Show();

         //</Snippet1>
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
