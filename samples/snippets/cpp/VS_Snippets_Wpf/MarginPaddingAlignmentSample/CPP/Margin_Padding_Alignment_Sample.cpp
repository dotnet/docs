//Margin_Padding_Alignment_Sample.cpp file
using namespace System;
using namespace System::Windows;
using namespace System::Windows::Controls;
using namespace System::Windows::Media;
using namespace System::Windows::Shapes;
using namespace System::Threading;

namespace Margin_Padding_Alignment_Sample {

   public ref class app : Application {

   private: 
      Border^ myBorder;
      Grid^ myGrid;
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
         // <Snippet4>
         mainWindow = gcnew Window();

         // <Snippet3>
         myBorder = gcnew Border();
         myBorder->Background = Brushes::LightBlue;
         myBorder->BorderBrush = Brushes::Black;
         myBorder->BorderThickness = Thickness(2);
         myBorder->CornerRadius = CornerRadius(45);
         myBorder->Padding = Thickness(25);
         //</Snippet3>

         // Define the Grid.
         myGrid = gcnew Grid();
         myGrid->Background = Brushes::White;
         myGrid->ShowGridLines = true;

         // Define the Columns.
         ColumnDefinition^ myColDef1 = gcnew ColumnDefinition();
         myColDef1->Width = GridLength(1, GridUnitType::Auto);
         ColumnDefinition^ myColDef2 = gcnew ColumnDefinition();
         myColDef2->Width = GridLength(1, GridUnitType::Star);
         ColumnDefinition^ myColDef3 = gcnew ColumnDefinition();
         myColDef3->Width = GridLength(1, GridUnitType::Auto);

         // Add the ColumnDefinitions to the Grid.
         myGrid->ColumnDefinitions->Add(myColDef1);
         myGrid->ColumnDefinitions->Add(myColDef2);
         myGrid->ColumnDefinitions->Add(myColDef3);

         // Add the first child StackPanel.
         StackPanel^ myStackPanel = gcnew StackPanel();
         myStackPanel->HorizontalAlignment = HorizontalAlignment::Left;
         myStackPanel->VerticalAlignment = VerticalAlignment::Top;
         Grid::SetColumn(myStackPanel, 0);
         Grid::SetRow(myStackPanel, 0);
         TextBlock^ myTextBlock1 = gcnew TextBlock();
         myTextBlock1->FontSize = 18;
         myTextBlock1->HorizontalAlignment = HorizontalAlignment::Center;
         myTextBlock1->Margin = Thickness(0, 0, 0, 15);
         myTextBlock1->Text = "StackPanel 1";
         // <Snippet2>
         Button^ myButton1 = gcnew Button();
         myButton1->Margin = Thickness(0, 10, 0, 10);
         myButton1->Content = "Button 1";
         Button^ myButton2 = gcnew Button();
         myButton2->Margin = Thickness(0, 10, 0, 10);
         myButton2->Content = "Button 2";
         Button^ myButton3 = gcnew Button();
         myButton3->Margin = Thickness(0, 10, 0, 10);
         //</Snippet2>
         TextBlock^ myTextBlock2 = gcnew TextBlock();
         myTextBlock2->Text = "ColumnDefinition.Width = \"Auto\"";
         TextBlock^ myTextBlock3 = gcnew TextBlock();
         myTextBlock3->Text = "StackPanel.HorizontalAlignment = \"Left\"";
         TextBlock^ myTextBlock4 = gcnew TextBlock();
         myTextBlock4->Text = "StackPanel.VerticalAlignment = \"Top\"";
         TextBlock^ myTextBlock5 = gcnew TextBlock();
         myTextBlock5->Text = "StackPanel.Orientation = \"Vertical\"";
         TextBlock^ myTextBlock6 = gcnew TextBlock();
         myTextBlock6->Text = "Button.Margin = \"1,10,0,10\"";
         myStackPanel->Children->Add(myTextBlock1);
         myStackPanel->Children->Add(myButton1);
         myStackPanel->Children->Add(myButton2);
         myStackPanel->Children->Add(myButton3);
         myStackPanel->Children->Add(myTextBlock2);
         myStackPanel->Children->Add(myTextBlock3);
         myStackPanel->Children->Add(myTextBlock4);
         myStackPanel->Children->Add(myTextBlock5);
         myStackPanel->Children->Add(myTextBlock6);

         // Add the second child StackPanel.
         StackPanel^ myStackPanel2 = gcnew StackPanel();
         myStackPanel2->HorizontalAlignment = HorizontalAlignment::Stretch;
         myStackPanel2->VerticalAlignment = VerticalAlignment::Top;
         myStackPanel2->Orientation = Orientation::Vertical;
         Grid::SetColumn(myStackPanel2, 1);
         Grid::SetRow(myStackPanel2, 0);
         TextBlock^ myTextBlock7 = gcnew TextBlock();
         myTextBlock7->FontSize = 18;
         myTextBlock7->HorizontalAlignment = HorizontalAlignment::Center;
         myTextBlock7->Margin = Thickness(0, 0, 0, 15);
         myTextBlock7->Text = "StackPanel 2";
         Button^ myButton4 = gcnew Button();
         myButton4->Margin = Thickness(10, 0, 10, 0);
         myButton4->Content = "Button 4";
         Button^ myButton5 = gcnew Button();
         myButton5->Margin = Thickness(10, 0, 10, 0);
         myButton5->Content = "Button 5";
         Button^ myButton6 = gcnew Button();
         myButton6->Margin = Thickness(10, 0, 10, 0);
         myButton6->Content = "Button 6";
         TextBlock^ myTextBlock8 = gcnew TextBlock();
         myTextBlock8->HorizontalAlignment = HorizontalAlignment::Center;
         myTextBlock8->Text = "ColumnDefinition.Width = \"*\"";
         TextBlock^ myTextBlock9 = gcnew TextBlock();
         myTextBlock9->HorizontalAlignment = HorizontalAlignment::Center;
         myTextBlock9->Text = "StackPanel.HorizontalAlignment = \"Stretch\"";
         TextBlock^ myTextBlock10 = gcnew TextBlock();
         myTextBlock10->HorizontalAlignment = HorizontalAlignment::Center;
         myTextBlock10->Text = "StackPanel.VerticalAlignment = \"Top\"";
         TextBlock^ myTextBlock11 = gcnew TextBlock();
         myTextBlock11->HorizontalAlignment = HorizontalAlignment::Center;
         myTextBlock11->Text = "StackPanel.Orientation = \"Horizontal\"";
         TextBlock^ myTextBlock12 = gcnew TextBlock();
         myTextBlock12->HorizontalAlignment = HorizontalAlignment::Center;
         myTextBlock12->Text = "Button.Margin = \"10,0,10,0\"";
         myStackPanel2->Children->Add(myTextBlock7);
         myStackPanel2->Children->Add(myButton4);
         myStackPanel2->Children->Add(myButton5);
         myStackPanel2->Children->Add(myButton6);
         myStackPanel2->Children->Add(myTextBlock8);
         myStackPanel2->Children->Add(myTextBlock9);
         myStackPanel2->Children->Add(myTextBlock10);
         myStackPanel2->Children->Add(myTextBlock11);
         myStackPanel2->Children->Add(myTextBlock12);

         // Add the final child StackPanel.
         StackPanel^ myStackPanel3 = gcnew StackPanel();
         myStackPanel3->HorizontalAlignment = HorizontalAlignment::Left;
         myStackPanel3->VerticalAlignment = VerticalAlignment::Top;
         Grid::SetColumn(myStackPanel3, 2);
         Grid::SetRow(myStackPanel3, 0);
         TextBlock^ myTextBlock13 = gcnew TextBlock();
         myTextBlock13->FontSize = 18;
         myTextBlock13->HorizontalAlignment = HorizontalAlignment::Center;
         myTextBlock13->Margin = Thickness(0, 0, 0, 15);
         myTextBlock13->Text = "StackPanel 3";
         // <Snippet1>
         Button^ myButton7 = gcnew Button();
         myButton7->Margin = Thickness(10);
         myButton7->Content = "Button 7";
         Button^ myButton8 = gcnew Button();
         myButton8->Margin = Thickness(10);
         myButton8->Content = "Button 8";
         Button^ myButton9 = gcnew Button();
         myButton9->Margin = Thickness(10);
         myButton9->Content = "Button 9";
         //</Snippet1>
         TextBlock^ myTextBlock14 = gcnew TextBlock();
         myTextBlock14->Text = "ColumnDefinition.Width = \"Auto\"";
         TextBlock^ myTextBlock15 = gcnew TextBlock();
         myTextBlock15->Text = "StackPanel.HorizontalAlignment = \"Left\"";
         TextBlock^ myTextBlock16 = gcnew TextBlock();
         myTextBlock16->Text = "StackPanel.VerticalAlignment = \"Top\"";
         TextBlock^ myTextBlock17 = gcnew TextBlock();
         myTextBlock17->Text = "StackPanel.Orientation = \"Vertical\"";
         TextBlock^ myTextBlock18 = gcnew TextBlock();
         myTextBlock18->Text = "Button.Margin = \"10\"";
         myStackPanel3->Children->Add(myTextBlock13);
         myStackPanel3->Children->Add(myButton7);
         myStackPanel3->Children->Add(myButton8);
         myStackPanel3->Children->Add(myButton9);
         myStackPanel3->Children->Add(myTextBlock14);
         myStackPanel3->Children->Add(myTextBlock15);
         myStackPanel3->Children->Add(myTextBlock16);
         myStackPanel3->Children->Add(myTextBlock17);
         myStackPanel3->Children->Add(myTextBlock18);

         // Add child content to the parent Grid.
         myGrid->Children->Add(myStackPanel);
         myGrid->Children->Add(myStackPanel2);
         myGrid->Children->Add(myStackPanel3);

         // Add the Grid as the lone child of the Border.
         myBorder->Child = myGrid;

         // Add the Border to the Window as Content and show the Window.
         mainWindow->Content = myBorder;
         mainWindow->Title = "Margin, Padding, and Alignment Sample";
         mainWindow->Show();
         //</Snippet4>
      };
   };

   private ref class EntryClass {

   public: 
      [System::STAThread()]
      static void Main () 
      {
         Margin_Padding_Alignment_Sample::app^ app = gcnew Margin_Padding_Alignment_Sample::app();
         app->Run();
      };
   };
}

//Entry Point:
[System::STAThreadAttribute()]
void main ()
{
   return Margin_Padding_Alignment_Sample::EntryClass::Main();
}
