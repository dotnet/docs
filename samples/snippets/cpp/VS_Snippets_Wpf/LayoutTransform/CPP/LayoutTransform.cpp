//LayoutTransform.cpp file

using namespace System;
using namespace System::Windows;
using namespace System::Windows::Controls;
using namespace System::Windows::Media;
using namespace System::Threading;

namespace LayoutTransformCode {

   public ref class app : Application {

   private: 
      Grid^ grid1;
      ColumnDefinition^ colDef1;
      ColumnDefinition^ colDef2;
      RowDefinition^ rowDef1;
      RowDefinition^ rowDef2;
      RowDefinition^ rowDef3;
      RowDefinition^ rowDef4;
      RowDefinition^ rowDef5;
      RowDefinition^ rowDef6;
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
         mainWindow->Title = "LayoutTransform Sample";

         // Create the Grid
         grid1 = gcnew Grid();
         grid1->HorizontalAlignment = HorizontalAlignment::Left;
         grid1->VerticalAlignment = VerticalAlignment::Top;
         grid1->ShowGridLines = true;

         // Define the Columns
         colDef1 = gcnew ColumnDefinition();
         colDef1->Width = GridLength::Auto;
         colDef2 = gcnew ColumnDefinition();
         colDef2->Width = GridLength::Auto;
         grid1->ColumnDefinitions->Add(colDef1);
         grid1->ColumnDefinitions->Add(colDef2);

         // Define the Rows
         rowDef1 = gcnew RowDefinition();
         rowDef1->Height = GridLength::Auto;
         rowDef2 = gcnew RowDefinition();
         rowDef2->Height = GridLength::Auto;
         rowDef3 = gcnew RowDefinition();
         rowDef3->Height = GridLength::Auto;
         rowDef4 = gcnew RowDefinition();
         rowDef4->Height = GridLength::Auto;
         rowDef5 = gcnew RowDefinition();
         rowDef5->Height = GridLength::Auto;
         rowDef6 = gcnew RowDefinition();
         rowDef6->Height = GridLength::Auto;
         grid1->RowDefinitions->Add(rowDef1);
         grid1->RowDefinitions->Add(rowDef2);
         grid1->RowDefinitions->Add(rowDef3);
         grid1->RowDefinitions->Add(rowDef4);
         grid1->RowDefinitions->Add(rowDef5);
         grid1->RowDefinitions->Add(rowDef6);

         // RotateTransform Sample
         Button^ btn1 = gcnew Button();
         btn1->Background = Brushes::LightCoral;
         btn1->Content = "No Transform Applied";
         Grid::SetRow(btn1, 0);
         Grid::SetColumn(btn1, 0);
         grid1->Children->Add(btn1);

         // <Snippet1>

         Button^ btn2 = gcnew Button();
         btn2->Background = Brushes::LightCoral;
         btn2->Content = "RotateTransform";
         btn2->LayoutTransform = gcnew RotateTransform(45, 25, 25);
         Grid::SetRow(btn2, 0);
         Grid::SetColumn(btn2, 1);
         grid1->Children->Add(btn2);

         //</Snippet1>

         // SkewTransform Sample
         Button^ btn3 = gcnew Button();
         btn3->Background = Brushes::LightCyan;
         btn3->Content = "No Transform Applied";
         Grid::SetRow(btn3, 1);
         Grid::SetColumn(btn3, 0);
         grid1->Children->Add(btn3);

         Button^ btn4 = gcnew Button();
         btn4->Background = Brushes::LightCyan;
         btn4->Content = "SkewTransform";
         btn4->LayoutTransform = gcnew SkewTransform(45, 0, 0, 0);
         Grid::SetRow(btn4, 1);
         Grid::SetColumn(btn4, 1);
         grid1->Children->Add(btn4);

         // ScaleTransform Sample
         Button^ btn5 = gcnew Button();
         btn5->Background = Brushes::LightSlateGray;
         btn5->Content = "No Transform Applied";
         Grid::SetRow(btn5, 2);
         Grid::SetColumn(btn5, 0);
         grid1->Children->Add(btn5);

         Button^ btn6 = gcnew Button();
         btn6->Background = Brushes::LightSlateGray;
         btn6->Content = "ScaleTransform";
         btn6->LayoutTransform = gcnew ScaleTransform(2, 2, 25, 25);
         Grid::SetRow(btn6, 2);
         Grid::SetColumn(btn6, 1);
         grid1->Children->Add(btn6);

         // TranslateTransform : RenderTransform Sample
         Button^ btn7 = gcnew Button();
         btn7->Background = Brushes::LightSeaGreen;
         btn7->Content = "No Transform Applied";
         Grid::SetRow(btn7, 3);
         Grid::SetColumn(btn7, 0);
         grid1->Children->Add(btn7);

         Button^ btn8 = gcnew Button();
         btn8->Background = Brushes::LightSeaGreen;
         btn8->Content = "TranslateTransform: RenderTransform";
         btn8->RenderTransform = gcnew TranslateTransform(100, 200);
         Grid::SetRow(btn8, 3);
         Grid::SetColumn(btn8, 1);
         grid1->Children->Add(btn8);

         // TranslateTransform : LayoutTransform Sample
         Button^ btn9 = gcnew Button();
         btn9->Background = Brushes::LightBlue;
         btn9->Content = "No Transform Applied";
         Grid::SetRow(btn9, 4);
         Grid::SetColumn(btn9, 0);
         grid1->Children->Add(btn9);

         Button^ btn10 = gcnew Button();
         btn10->Background = Brushes::LightBlue;
         btn10->Content = "TranslateTransform: LayoutTransform";
         btn10->LayoutTransform = gcnew TranslateTransform(100, 200);
         Grid::SetRow(btn10, 4);
         Grid::SetColumn(btn10, 1);
         grid1->Children->Add(btn10);

         // MatrixTransform Sample
         Button^ btn11 = gcnew Button();
         btn11->Background = Brushes::LightGoldenrodYellow;
         btn11->Content = "No Transform Applied";
         Grid::SetRow(btn11, 5);
         Grid::SetColumn(btn11, 0);
         grid1->Children->Add(btn11);

         Button^ btn12 = gcnew Button();
         btn12->Background = Brushes::LightGoldenrodYellow;
         btn12->Content = "MatrixTransform";
         btn12->LayoutTransform = gcnew MatrixTransform(1, 3, 3, 3, 3, 3);
         Grid::SetRow(btn12, 5);
         Grid::SetColumn(btn12, 1);
         grid1->Children->Add(btn12);

         mainWindow->Content = grid1;
         mainWindow->Show();
      };
   };

   private ref class EntryClass {

   public: 
      [System::STAThread()]
      static void Main () 
      {
         LayoutTransformCode::app^ app = gcnew LayoutTransformCode::app();
         app->Run();
      };
   };
}

//Entry Point:
[System::STAThreadAttribute()]
void main ()
{
   return LayoutTransformCode::EntryClass::Main();
}
