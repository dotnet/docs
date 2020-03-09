//CanvasAttachedProps.cpp file

using namespace System;
using namespace System::Windows;
using namespace System::Windows::Controls;
using namespace System::Windows::Media;
using namespace System::Threading;

namespace SDKSample {

   public ref class app : Application {

   private: 
      Window^ mainWindow;

   protected: 
      virtual void OnStartup (StartupEventArgs^ e) override 
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
         mainWindow->Title = "Canvas Attached Properties Sample";

         // Add a Border
         Border^ myBorder = gcnew Border();
         myBorder->HorizontalAlignment = HorizontalAlignment::Left;
         myBorder->VerticalAlignment = VerticalAlignment::Top;
         myBorder->BorderBrush = Brushes::Black;
         myBorder->BorderThickness = System::Windows::Thickness(2);

         // Create the Canvas
         Canvas^ myCanvas = gcnew Canvas();
         myCanvas->Background = Brushes::LightBlue;
         myCanvas->Width = 400;
         myCanvas->Height = 400;

         // Create the child Button elements
         Button^ myButton1 = gcnew Button();
         Button^ myButton2 = gcnew Button();
         Button^ myButton3 = gcnew Button();
         Button^ myButton4 = gcnew Button();

         // Set Positioning attached properties on Button elements
         Canvas::SetTop(myButton1, 50);
         myButton1->Content = "Canvas.Top=50";
         Canvas::SetBottom(myButton2, 50);
         myButton2->Content = "Canvas.Bottom=50";
         Canvas::SetLeft(myButton3, 50);
         myButton3->Content = "Canvas.Left=50";
         Canvas::SetRight(myButton4, 50);
         myButton4->Content = "Canvas.Right=50";

         // Add Buttons to the Canvas' Children collection
         myCanvas->Children->Add(myButton1);
         myCanvas->Children->Add(myButton2);
         myCanvas->Children->Add(myButton3);
         myCanvas->Children->Add(myButton4);

         // Add the Canvas as the lone Child of the Border
         myBorder->Child = myCanvas;

         // Add the Border as the Content of the Parent Window Object
         mainWindow->Content = myBorder;
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
