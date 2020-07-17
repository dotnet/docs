//ShapesProcedural.cpp file

using namespace System;
using namespace System::Windows;
using namespace System::Windows::Controls;
using namespace System::Windows::Media;
using namespace System::Windows::Shapes;
using namespace System::Threading;

namespace ShapesProcedural {

   public ref class app : Application {

   private: 
      Border^ myBorder;
      Rectangle^ myRect;
      Ellipse^ myEllipse;
      Line^ myLine;
      Path^ myPath;
      Polygon^ myPolygon;
      Polyline^ myPolyline;
      Grid^ myGrid;
      TextBlock^ myTextBlock;
      ColumnDefinition^ myColDef1;
      ColumnDefinition^ myColDef2;
      RowDefinition^ myRowDef;
      RowDefinition^ myRowDef1;
      RowDefinition^ myRowDef2;
      RowDefinition^ myRowDef3;
      RowDefinition^ myRowDef4;
      RowDefinition^ myRowDef5;
      RowDefinition^ myRowDef6;
      Window^ myWindow;

   protected: virtual void OnStartup (StartupEventArgs^ e) override 
              {
                 Application::OnStartup(e);
                 CreateAndShowMainWindow();
              };

   private: void CreateAndShowMainWindow () 
            {
               // Create the application's main window
               myWindow = gcnew Window();

               // Add a Border
               myBorder = gcnew Border();
               myBorder->BorderBrush = Brushes::Black;
               myBorder->BorderThickness = Thickness(2);
               myBorder->Width = 400;
               myBorder->Height = 600;
               myBorder->Padding = Thickness(15);
               myBorder->Background = Brushes::White;

               // Create a Grid to host the Shapes
               myGrid = gcnew Grid();
               myGrid->Margin = Thickness(15);
               myColDef1 = gcnew ColumnDefinition();
               myColDef1->Width = GridLength(125);
               myColDef2 = gcnew ColumnDefinition();
               myColDef2->Width = GridLength(1, GridUnitType::Star);
               myGrid->ColumnDefinitions->Add(myColDef1);
               myGrid->ColumnDefinitions->Add(myColDef2);
               myRowDef = gcnew RowDefinition();
               myRowDef1 = gcnew RowDefinition();
               myRowDef2 = gcnew RowDefinition();
               myRowDef3 = gcnew RowDefinition();
               myRowDef4 = gcnew RowDefinition();
               myRowDef5 = gcnew RowDefinition();
               myRowDef6 = gcnew RowDefinition();
               myGrid->RowDefinitions->Add(myRowDef);
               myGrid->RowDefinitions->Add(myRowDef1);
               myGrid->RowDefinitions->Add(myRowDef2);
               myGrid->RowDefinitions->Add(myRowDef3);
               myGrid->RowDefinitions->Add(myRowDef4);
               myGrid->RowDefinitions->Add(myRowDef5);
               myGrid->RowDefinitions->Add(myRowDef6);
               myTextBlock = gcnew TextBlock();
               myTextBlock->FontSize = 20;
               myTextBlock->Text = "WPF Shapes Gallery";
               myTextBlock->HorizontalAlignment = HorizontalAlignment::Left;
               myTextBlock->VerticalAlignment = VerticalAlignment::Center;
               myGrid->Children->Add(myTextBlock);
               Grid::SetRow(myTextBlock, 0);
               Grid::SetColumnSpan(myTextBlock, 2);

               //<SnippetShapesProceduralRectangle>

               // Add a Rectangle Element
               myRect = gcnew Rectangle();
               myRect->Stroke = Brushes::Black;
               myRect->Fill = Brushes::SkyBlue;
               myRect->HorizontalAlignment = HorizontalAlignment::Left;
               myRect->VerticalAlignment = VerticalAlignment::Center;
               myRect->Height = 50;
               myRect->Width = 50;
               myGrid->Children->Add(myRect);
               //</SnippetShapesProceduralRectangle>
               Grid::SetRow(myRect, 1);
               Grid::SetColumn(myRect, 0);
               TextBlock^ myTextBlock1 = gcnew TextBlock();
               myTextBlock1->FontSize = 14;
               myTextBlock1->Text = "A Rectangle Element";
               myTextBlock1->VerticalAlignment = VerticalAlignment::Center;
               myGrid->Children->Add(myTextBlock1);
               Grid::SetRow(myTextBlock1, 1);
               Grid::SetColumn(myTextBlock1, 1);

               //<SnippetShapesProceduralEllipse>

               // Add an Ellipse Element
               myEllipse = gcnew Ellipse();
               myEllipse->Stroke = Brushes::Black;
               myEllipse->Fill = Brushes::DarkBlue;
               myEllipse->HorizontalAlignment = HorizontalAlignment::Left;
               myEllipse->VerticalAlignment = VerticalAlignment::Center;
               myEllipse->Width = 50;
               myEllipse->Height = 75;
               myGrid->Children->Add(myEllipse);
               //</SnippetShapesProceduralEllipse>
               Grid::SetRow(myEllipse, 2);
               Grid::SetColumn(myEllipse, 0);
               TextBlock^ myTextBlock2 = gcnew TextBlock();
               myTextBlock2->FontSize = 14;
               myTextBlock2->Text = "An Ellipse Element";
               myTextBlock2->VerticalAlignment = VerticalAlignment::Center;
               myGrid->Children->Add(myTextBlock2);
               Grid::SetRow(myTextBlock2, 2);
               Grid::SetColumn(myTextBlock2, 1);

               //<SnippetShapesProceduralLine>

               // Add a Line Element
               myLine = gcnew Line();
               myLine->Stroke = Brushes::LightSteelBlue;
               myLine->X1 = 1;
               myLine->X2 = 50;
               myLine->Y1 = 1;
               myLine->Y2 = 50;
               myLine->HorizontalAlignment = HorizontalAlignment::Left;
               myLine->VerticalAlignment = VerticalAlignment::Center;
               myLine->StrokeThickness = 2;
               myGrid->Children->Add(myLine);
               //</SnippetShapesProceduralLine>
               Grid::SetRow(myLine, 3);
               Grid::SetColumn(myLine, 0);
               TextBlock^ myTextBlock3 = gcnew TextBlock();
               myTextBlock3->FontSize = 14;
               myTextBlock3->Text = "A Line Element";
               myTextBlock3->VerticalAlignment = VerticalAlignment::Center;
               myGrid->Children->Add(myTextBlock3);
               Grid::SetRow(myTextBlock3, 3);
               Grid::SetColumn(myTextBlock3, 1);

               //<SnippetShapesProceduralPath>

               //Add the Path Element
               myPath = gcnew Path();
               myPath->Stroke = Brushes::Black;
               myPath->Fill = Brushes::MediumSlateBlue;
               myPath->StrokeThickness = 4;
               myPath->HorizontalAlignment = HorizontalAlignment::Left;
               myPath->VerticalAlignment = VerticalAlignment::Center;
               EllipseGeometry^ myEllipseGeometry = gcnew EllipseGeometry();
               myEllipseGeometry->Center = Point(50, 50);
               myEllipseGeometry->RadiusX = 25;
               myEllipseGeometry->RadiusY = 25;
               myPath->Data = myEllipseGeometry;
               myGrid->Children->Add(myPath);
               //</SnippetShapesProceduralPath>
               Grid::SetRow(myPath, 4);
               Grid::SetColumn(myPath, 0);
               TextBlock^ myTextBlock4 = gcnew TextBlock();
               myTextBlock4->FontSize = 14;
               myTextBlock4->Text = "A Path Element";
               myTextBlock4->VerticalAlignment = VerticalAlignment::Center;
               myGrid->Children->Add(myTextBlock4);
               Grid::SetRow(myTextBlock4, 4);
               Grid::SetColumn(myTextBlock4, 1);

               //<SnippetShapesProceduralPolygon>

               //Add the Polygon Element
               myPolygon = gcnew Polygon();
               myPolygon->Stroke = Brushes::Black;
               myPolygon->Fill = Brushes::LightSeaGreen;
               myPolygon->StrokeThickness = 2;
               myPolygon->HorizontalAlignment = HorizontalAlignment::Left;
               myPolygon->VerticalAlignment = VerticalAlignment::Center;
               Point Point1 = Point(1, 50);
               Point Point2 = Point(10, 80);
               Point Point3 = Point(50, 50);
               PointCollection^ myPointCollection = gcnew PointCollection();
               myPointCollection->Add(Point1);
               myPointCollection->Add(Point2);
               myPointCollection->Add(Point3);
               myPolygon->Points = myPointCollection;
               myGrid->Children->Add(myPolygon);
               //</SnippetShapesProceduralPolygon>
               Grid::SetRow(myPolygon, 5);
               Grid::SetColumn(myPolygon, 0);
               TextBlock^ myTextBlock5 = gcnew TextBlock();
               myTextBlock5->Text = "A Polygon Element";
               myTextBlock5->FontSize = 14;
               myTextBlock5->VerticalAlignment = VerticalAlignment::Center;
               myGrid->Children->Add(myTextBlock5);
               Grid::SetRow(myTextBlock5, 5);
               Grid::SetColumn(myTextBlock5, 1);

               //<SnippetShapesProceduralPolyline>

               // Add the Polyline Element
               myPolyline = gcnew Polyline();
               myPolyline->Stroke = Brushes::SlateGray;
               myPolyline->StrokeThickness = 2;
               myPolyline->FillRule = FillRule::EvenOdd;
               Point Point4 = Point(1, 50);
               Point Point5 = Point(10, 80);
               Point Point6 = Point(20, 40);
               PointCollection^ myPointCollection2 = gcnew PointCollection();
               myPointCollection2->Add(Point4);
               myPointCollection2->Add(Point5);
               myPointCollection2->Add(Point6);
               myPolyline->Points = myPointCollection2;
               myGrid->Children->Add(myPolyline);
               //</SnippetShapesProceduralPolyline>
               Grid::SetRow(myPolyline, 6);
               Grid::SetColumn(myPolyline, 0);
               TextBlock^ myTextBlock6 = gcnew TextBlock();
               myTextBlock6->FontSize = 14;
               myTextBlock6->Text = "A Polyline Element";
               myTextBlock6->VerticalAlignment = VerticalAlignment::Center;
               myGrid->Children->Add(myTextBlock6);
               Grid::SetRow(myTextBlock6, 6);
               Grid::SetColumn(myTextBlock6, 1);

               // Add the Grid to the Window as Content and show the Window
               myBorder->Child = myGrid;
               myWindow->Content = myBorder;
               myWindow->Background = Brushes::LightSlateGray;
               myWindow->Title = "Shapes Sample";
               myWindow->Show();

            };
   };

   private ref class EntryClass {

   public: 
      [System::STAThread()]
      static void Main () 
      {
         ShapesProcedural::app^ app = gcnew ShapesProcedural::app();
         app->Run();
      };
   };
}

//Entry Point:
[System::STAThreadAttribute()]
void main ()
{
   return ShapesProcedural::EntryClass::Main();
}
