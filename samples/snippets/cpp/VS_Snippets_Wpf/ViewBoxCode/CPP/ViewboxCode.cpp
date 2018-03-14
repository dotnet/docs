//ViewboxCode.cpp file
using namespace System;
using namespace System::Windows;
using namespace System::Windows::Controls;
using namespace System::Windows::Media;
using namespace System::Windows::Shapes;
using namespace System::Threading;

namespace ViewboxCode {

   public ref class app : Application {

   private: 
      Canvas^ myCanvas;
      Window^ mainWindow;
      Viewbox^ myViewbox;
      Grid^ myGrid;
      TextBlock^ myTextBlock;
      Ellipse^ myEllipse;

   protected: 
      virtual void OnStartup (StartupEventArgs^ e) override 
      {
         Application::OnStartup(e);
         CreateAndShowMainWindow();
      }
      ;

   private: 
      void CreateAndShowMainWindow () 
      {
         // Create the application's main window
         mainWindow = gcnew Window();

         // Create a Canvas sized to fill the window
         myCanvas = gcnew Canvas();
         myCanvas->Background = Brushes::Silver;
         myCanvas->Width = 600;
         myCanvas->Height = 600;
         // <Snippet1>

         // <Snippet2>

         // Create a Viewbox and add it to the Canvas
         myViewbox = gcnew Viewbox();
         myViewbox->StretchDirection = StretchDirection::Both;
         myViewbox->Stretch = Stretch::Fill;
         myViewbox->MaxWidth = 400;
         myViewbox->MaxHeight = 400;
         //</Snippet2>

         // Create a Grid that will be hosted inside the Viewbox
         myGrid = gcnew Grid();

         // Create an Ellipse that will be hosted inside the Viewbox
         myEllipse = gcnew Ellipse();
         myEllipse->Stroke = Brushes::RoyalBlue;
         myEllipse->Fill = Brushes::LightBlue;

         // Create an TextBlock that will be hosted inside the Viewbox
         myTextBlock = gcnew TextBlock();
         myTextBlock->Text = "Viewbox";

         // Add the children to the Grid
         myGrid->Children->Add(myEllipse);
         myGrid->Children->Add(myTextBlock);

         // <Snippet3>

         // Add the Grid as the single child of the Viewbox
         myViewbox->Child = myGrid;

         //</Snippet3>

         // Position the Viewbox in the Parent Canvas
         Canvas::SetTop(myViewbox, 100);
         Canvas::SetLeft(myViewbox, 100);
         myCanvas->Children->Add(myViewbox);

         //</Snippet1>

         // Set the Window content
         mainWindow->Content = myCanvas;
         mainWindow->Show();


      };
   };

   private ref class EntryClass {

   public: 
      [System::STAThread()]
      static void Main () 
      {
         ViewboxCode::app^ app = gcnew ViewboxCode::app();
         app->Run();
      };
   };
}

//Entry Point:
[System::STAThreadAttribute()]
void main ()
{
   return ViewboxCode::EntryClass::Main();
}
