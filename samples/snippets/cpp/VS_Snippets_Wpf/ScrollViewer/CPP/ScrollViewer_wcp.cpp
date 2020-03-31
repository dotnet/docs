//ScrollViewer_wcp.cpp file

using namespace System;
using namespace System::Windows;
using namespace System::Windows::Controls;
using namespace System::Windows::Media;
using namespace System::Windows::Shapes;
using namespace System::Threading;

namespace SDKSample {

   public ref class app : Application {

   private: 
      ScrollViewer^ myScrollViewer;
      StackPanel^ myStackPanel;
      Window^ mainWindow;

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
         mainWindow = gcnew System::Windows::Window();
         mainWindow->Title = "ScrollViewer Sample";

         // Define a ScrollViewer
         myScrollViewer = gcnew ScrollViewer();
         myScrollViewer->HorizontalScrollBarVisibility = ScrollBarVisibility::Auto;

         // Add Layout control
         myStackPanel = gcnew StackPanel();
         myStackPanel->HorizontalAlignment = HorizontalAlignment::Left;
         myStackPanel->VerticalAlignment = VerticalAlignment::Top;

         TextBlock^ myTextBlock = gcnew TextBlock();
         myTextBlock->TextWrapping = TextWrapping::Wrap;
         myTextBlock->Margin = System::Windows::Thickness(0, 0, 0, 20);
         myTextBlock->Text = "Scrolling is enabled when it is necessary. Resize the Window, making it larger and smaller.";

         Rectangle^ myRectangle = gcnew Rectangle();
         myRectangle->Fill = Brushes::Red;
         myRectangle->Width = 500;
         myRectangle->Height = 500;

         // Add child elements to the parent StackPanel
         myStackPanel->Children->Add(myTextBlock);
         myStackPanel->Children->Add(myRectangle);

         // Add the StackPanel as the lone Child of the Border
         myScrollViewer->Content = myStackPanel;

         // Add the Border as the Content of the Parent Window Object
         mainWindow->Content = myScrollViewer;
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
