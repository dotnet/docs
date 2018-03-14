//PlotPanel.cpp file
using namespace System;
using namespace System::Windows;
using namespace System::Windows::Controls;
using namespace System::Windows::Shapes;
using namespace System::Windows::Media;
using namespace System::Threading;

namespace PlotPanel {

   public ref class app : System::Windows::Application {

      // <Snippet1>
   public: 
      ref class PlotPanel : Panel {

      public: 
         PlotPanel () {};

      protected: 
         // Override the default Measure method of Panel
         // <Snippet2>
         virtual Size MeasureOverride(Size availableSize) override
         {
             Size^ panelDesiredSize = gcnew Size();

             // In our example, we just have one child. 
             // Report that our panel requires just the size of its only child.
             for each (UIElement^ child in InternalChildren)
             {
                 child->Measure(availableSize);
				 panelDesiredSize = child->DesiredSize;
             }
             return *panelDesiredSize ;
         }
         //</Snippet2>

      protected: 
         virtual System::Windows::Size ArrangeOverride (Size finalSize) override 
         {
            for each (UIElement^ child in InternalChildren)
            {
               double x = 50;
               double y = 50;
               child->Arrange(Rect(Point(x, y), child->DesiredSize));
            }
            return finalSize;
         };
      };
      //</Snippet1>

   private: 
      PlotPanel^ plot1;
      Window^ mainWindow;
      Shapes::Rectangle^ rect1;

   protected: 
      virtual void OnStartup (StartupEventArgs^ e) override 
      {
         Application::OnStartup(e);
         CreateAndShowMainWindow();
      };

   private:
      void CreateAndShowMainWindow () 
      {
         // Create the application's main window

         mainWindow = gcnew Window();
         plot1 = gcnew PlotPanel();
         plot1->Background = Brushes::White;

         rect1 = gcnew Shapes::Rectangle();
         rect1->Fill = Brushes::CornflowerBlue;
         rect1->Width = 200;
         rect1->Height = 200;
         mainWindow->Content = plot1;
         plot1->Children->Add(rect1);
         mainWindow->Title = "Custom Panel Sample";
         mainWindow->Show();
      };
   };

   private ref class EntryClass {

   public: 
      [System::STAThread()]
      static void Main () 
      {
         PlotPanel::app^ app = gcnew PlotPanel::app();
         app->Run();
      };
   };
}

//Entry Point:
[System::STAThreadAttribute()]
void main ()
{
   return PlotPanel::EntryClass::Main();
}
