//WrapPanel_Code.cpp file

using namespace System;
using namespace System::Windows;
using namespace System::Windows::Controls;
using namespace System::Windows::Media;
using namespace System::Threading;

namespace WrapPanel_Demo {

   public ref class app : System::Windows::Application {

   private: 
      System::Windows::Controls::Button^ btn1;
      System::Windows::Controls::Button^ btn2;
      System::Windows::Controls::Button^ btn3;
      System::Windows::Controls::WrapPanel^ myWrapPanel;
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
         mainWindow = gcnew System::Windows::Window();
         mainWindow->Title = "WrapPanel Sample";

         // <Snippet2>

         // Instantiate a new WrapPanel and set properties
         myWrapPanel = gcnew WrapPanel();
         myWrapPanel->Background = Brushes::Azure;
         myWrapPanel->Orientation = Orientation::Horizontal;
         // <Snippet4>
         myWrapPanel->ItemHeight = 25;
         // </Snippet4>

         // <Snippet3>
         myWrapPanel->ItemWidth = 75;
         // </Snippet3>
         myWrapPanel->Width = 150;
         myWrapPanel->HorizontalAlignment = HorizontalAlignment::Left;
         myWrapPanel->VerticalAlignment = VerticalAlignment::Top;

         // Define 3 button elements. Each button is sized at width of 75, so the third button wraps to the next line.
         btn1 = gcnew Button();
         btn1->Content = "Button 1";
         btn2 = gcnew Button();
         btn2->Content = "Button 2";
         btn3 = gcnew Button();
         btn3->Content = "Button 3";

         // Add the buttons to the parent WrapPanel using the Children.Add method.
         myWrapPanel->Children->Add(btn1);
         myWrapPanel->Children->Add(btn2);
         myWrapPanel->Children->Add(btn3);

         // Add the WrapPanel to the MainWindow as Content
         mainWindow->Content = myWrapPanel;
         mainWindow->Show();
         // </Snippet2>

         //</Snippet1>
      };
   };

   private ref class EntryClass {

   public: 
      [System::STAThread()]
      static void Main () 
      {
         WrapPanel_Demo::app^ app = gcnew WrapPanel_Demo::app();
         app->Run();
      };
   };
}

//Entry Point:
[System::STAThreadAttribute()]
void main ()
{
   return WrapPanel_Demo::EntryClass::Main();
}
