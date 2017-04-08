

//<Snippet1>
#using <Accessibility.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;

// Declare a chart control that demonstrates accessibility in Windows Forms.
public ref class ChartControl: public System::Windows::Forms::UserControl
{
public:
   ref class ChartControlAccessibleObject;

   // forward declaration
   // Inner Class that represents a legend for a curve in the chart.
   ref class CurveLegend
   {

      //<Snippet6>
      // Inner class CurveLegendAccessibleObject represents accessible information
      // associated with the CurveLegend object.
   public:
      ref class CurveLegendAccessibleObject: public AccessibleObject
      {
      private:
         CurveLegend^ curveLegend;

      public:
         CurveLegendAccessibleObject( CurveLegend^ curveLegend )
            : AccessibleObject()
         {
            this->curveLegend = curveLegend;
         }


      private:

         property ChartControlAccessibleObject^ ChartControl 
         {

            // Private property that helps get the reference to the parent ChartControl.
            ChartControlAccessibleObject^ get()
            {
               return dynamic_cast<ChartControlAccessibleObject^>(Parent);
            }

         }

      internal:

         property int ID 
         {

            // Internal helper function that returns the ID for this CurveLegend.
            int get()
            {
               for ( int i = 0; i < ChartControl->GetChildCount(); i++ )
               {
                  if ( ChartControl->GetChild( i ) == this )
                  {
                     return i;
                  }

               }
               return  -1;
            }

         }

      public:

         property Rectangle Bounds 
         {

            // Gets the Bounds for the CurveLegend. This is used by accessibility programs.
            virtual Rectangle get() override
            {
               
               // The bounds is in screen coordinates.
               Point loc = curveLegend->Location;
               return Rectangle(curveLegend->chart->PointToScreen( loc ),curveLegend->Size);
            }

         }

         property String^ Name 
         {

            // Gets or sets the Name for the CurveLegend. This is used by accessibility programs.
            virtual String^ get() override
            {
               return curveLegend->Name;
            }

            virtual void set( String^ value ) override
            {
               curveLegend->Name = value;
            }

         }

         property AccessibleObject^ Parent 
         {

            // Gets the Curve Legend Parent's Accessible object.
            // This is used by accessibility programs.
            virtual AccessibleObject^ get() override
            {
               return curveLegend->chart->AccessibilityObject;
            }

         }

         property System::Windows::Forms::AccessibleRole Role 
         {

            // Gets the role for the CurveLegend. This is used by accessibility programs.
            virtual System::Windows::Forms::AccessibleRole get() override
            {
               return ::AccessibleRole::StaticText;
            }

         }

         property AccessibleStates State 
         {

            // Gets the state based on the selection for the CurveLegend.
            // This is used by accessibility programs.
            virtual AccessibleStates get() override
            {
               AccessibleStates state = AccessibleStates::Selectable;
               if ( curveLegend->Selected )
               {
                  state = static_cast<AccessibleStates>(state | AccessibleStates::Selected);
               }

               return state;
            }

         }

         // Navigates through siblings of this CurveLegend. This is used by accessibility programs.
         virtual AccessibleObject^ Navigate( AccessibleNavigation navdir ) override
         {
            
            // Uses the internal NavigateFromChild helper function that exists
            // on ChartControlAccessibleObject.
            return ChartControl->NavigateFromChild( this, navdir );
         }


         // Selects or unselects this CurveLegend. This is used by accessibility programs.
         virtual void Select( AccessibleSelection selection ) override
         {
            
            // Uses the internal SelectChild helper function that exists
            // on ChartControlAccessibleObject.
            ChartControl->SelectChild( this, selection );
         }

      };
      //</Snippet6>


   private:

      // class CurveLgendAccessibleObject
      String^ name;
      ChartControl^ chart;
      CurveLegendAccessibleObject^ accObj;
      bool selected;
      Point location;

   public:
      CurveLegend( ChartControl^ chart, String^ name )
      {
         this->chart = chart;
         this->name = name;
         selected = true;
      }


      property AccessibleObject^ AccessibilityObject 
      {

         // Gets the accessibility object for the curve legend.
         AccessibleObject^ get()
         {
            if ( accObj == nullptr )
            {
               accObj = gcnew CurveLegendAccessibleObject( this );
            }

            return accObj;
         }

      }

      property Rectangle Bounds 
      {

         // Gets the bounds for the curve legend.
         Rectangle get()
         {
            return Rectangle(Location,Size);
         }

      }

      property Point Location 
      {

         //<Snippet5>
         // Gets or sets the location for the curve legend.
         Point get()
         {
            return location;
         }

         void set( Point value )
         {
            location = value;
            chart->Invalidate();
            
            // Notifies the chart of the location change. This is used for
            // the accessibility information. AccessibleEvents::LocationChange
            // tells the chart the reason for the notification.
            chart->AccessibilityNotifyClients( AccessibleEvents::LocationChange, (dynamic_cast<CurveLegendAccessibleObject^>(AccessibilityObject))->ID );
         }

      }

      property String^ Name 
      {

         // Gets or sets the Name for the curve legend.
         String^ get()
         {
            return name;
         }

         void set( String^ value )
         {
            if ( name != value )
            {
               name = value;
               chart->Invalidate();
               
               // Notifies the chart of the name change. This is used for
               // the accessibility information. AccessibleEvents::NameChange
               // tells the chart the reason for the notification.
               chart->AccessibilityNotifyClients( AccessibleEvents::NameChange, (dynamic_cast<CurveLegendAccessibleObject^>(AccessibilityObject))->ID );
            }
         }

      }

      property bool Selected 
      {

         // Gets or sets the Selected state for the curve legend.
         bool get()
         {
            return selected;
         }

         void set( bool value )
         {
            if ( selected != value )
            {
               selected = value;
               chart->Invalidate();
               
               // Notifies the chart of the selection value change. This is used for
               // the accessibility information. The AccessibleEvents value depends upon
               // if the selection is true (AccessibleEvents::SelectionAdd) or
               // false (AccessibleEvents::SelectionRemove).
               chart->AccessibilityNotifyClients( selected ? AccessibleEvents::SelectionAdd : AccessibleEvents::SelectionRemove, (dynamic_cast<CurveLegendAccessibleObject^>(AccessibilityObject))->ID );
            }
         }
         //</Snippet5>

      }

      property System::Drawing::Size Size 
      {

         // Gets the Size for the curve legend.
         System::Drawing::Size get()
         {
            int legendHeight = chart->Font->Height + 4;
            Graphics^ g = chart->CreateGraphics();
            int legendWidth = (int)g->MeasureString( Name, chart->Font ).Width + 4;
            return System::Drawing::Size( legendWidth, legendHeight );
         }

      }

   };


private:

   // class CurveLegend
   CurveLegend^ legend1;
   CurveLegend^ legend2;

public:
   ChartControl()
   {
      
      // The ChartControl draws the chart in the OnPaint .
      SetStyle( ControlStyles::ResizeRedraw, true );
      SetStyle( ControlStyles::DoubleBuffer, true );
      SetStyle( ControlStyles::AllPaintingInWmPaint, true );
      this->BackColor = System::Drawing::Color::White;
      this->Name = "ChartControl";
      this->Click += gcnew System::EventHandler( this, &ChartControl::ChartControl_Click );
      this->QueryAccessibilityHelp += gcnew System::Windows::Forms::QueryAccessibilityHelpEventHandler( this, &ChartControl::ChartControl_QueryAccessibilityHelp );
      
      // The CurveLengend is not Control-based, it just
      // represents the parts of the legend.
      legend1 = gcnew CurveLegend( this,"A" );
      legend1->Location = Point(20,30);
      legend2 = gcnew CurveLegend( this,"B" );
      legend2->Location = Point(20,50);
   }



   //<Snippet2>
protected:
   // Overridden to return the custom AccessibleObject
   // for the entire chart.
   virtual AccessibleObject^ CreateAccessibilityInstance() override
   {
      return gcnew ChartControlAccessibleObject( this );
   }
   //</Snippet2>

   virtual void OnPaint( PaintEventArgs^ e ) override
   {
      
      // The ChartControl draws the chart in the OnPaint .
      System::Windows::Forms::UserControl::OnPaint( e );
      Rectangle bounds = this->ClientRectangle;
      int border = 5;
      
      // Draws the legends first.
      StringFormat^ format = gcnew StringFormat;
      format->Alignment = StringAlignment::Center;
      format->LineAlignment = StringAlignment::Center;
      if ( legend1 != nullptr )
      {
         if ( legend1->Selected )
         {
            e->Graphics->FillRectangle( gcnew SolidBrush( Color::Blue ), legend1->Bounds );
         }
         else
         {
            e->Graphics->DrawRectangle( Pens::Blue, legend1->Bounds );
         }

         e->Graphics->DrawString( legend1->Name, this->Font, Brushes::Black, legend1->Bounds, format );
      }

      if ( legend2 != nullptr )
      {
         if ( legend2->Selected )
         {
            e->Graphics->FillRectangle( gcnew SolidBrush( Color::Red ), legend2->Bounds );
         }
         else
         {
            e->Graphics->DrawRectangle( Pens::Red, legend2->Bounds );
         }

         e->Graphics->DrawString( legend2->Name, this->Font, Brushes::Black, legend2->Bounds, format );
      }

      
      // Charts out the actual curves that represent data in the Chart.
      bounds.Inflate(  -border,  -border );
      array<Point>^ temp1 = {Point(bounds.Left,bounds.Bottom),Point(bounds.Left + bounds.Width / 3,bounds.Top + bounds.Height / 5),Point(bounds.Right - bounds.Width / 3,(bounds.Top + bounds.Bottom) / 2),Point(bounds.Right,bounds.Top)};
      array<Point>^curve1 = temp1;
      array<Point>^ temp2 = {Point(bounds.Left,bounds.Bottom - bounds.Height / 3),Point(bounds.Left + bounds.Width / 3,bounds.Top + bounds.Height / 5),Point(bounds.Right - bounds.Width / 3,(bounds.Top + bounds.Bottom) / 2),Point(bounds.Right,bounds.Top + bounds.Height / 2)};
      array<Point>^curve2 = temp2;
      
      // Draws the actual curve only if it is selected.
      if ( legend1->Selected )
            e->Graphics->DrawCurve( Pens::Blue, curve1 );

      if ( legend2->Selected )
            e->Graphics->DrawCurve( Pens::Red, curve2 );

      e->Graphics->DrawRectangle( Pens::Blue, bounds );
   }

   //<Snippet3>
   // Handles the QueryAccessibilityHelp event.
   void ChartControl_QueryAccessibilityHelp( Object^ /*sender*/, System::Windows::Forms::QueryAccessibilityHelpEventArgs^ e )
   {
      e->HelpString = "Displays chart data";
   }
   //</Snippet3>

   // Handles the Click event for the chart.
   // Toggles the selection of whatever legend was clicked on
   void ChartControl_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      Point pt = this->PointToClient( Control::MousePosition );
      if ( legend1->Bounds.Contains( pt ) )
      {
         legend1->Selected =  !legend1->Selected;
      }
      else
      if ( legend2->Bounds.Contains( pt ) )
      {
         legend2->Selected =  !legend2->Selected;
      }
   }


public:

   property array<CurveLegend^>^ Legends 
   {

      // Gets an array of CurveLengends used in the Chart.
      array<CurveLegend^>^ get()
      {
         array<CurveLegend^>^temp3 = {legend1,legend2};
         return temp3;
      }

   }

   //<Snippet4>
   // Inner class ChartControlAccessibleObject represents accessible information associated with the ChartControl.
   // The ChartControlAccessibleObject is returned in the ChartControl::CreateAccessibilityInstance .
   ref class ChartControlAccessibleObject: public ControlAccessibleObject
   {
   private:
      ChartControl^ chartControl;

   public:
      ChartControlAccessibleObject( ChartControl^ ctrl )
         : ControlAccessibleObject( ctrl )
      {
         chartControl = ctrl;
      }


      property System::Windows::Forms::AccessibleRole Role 
      {

         // Gets the role for the Chart. This is used by accessibility programs.
         virtual System::Windows::Forms::AccessibleRole get() override
         {
            return ::AccessibleRole::Chart;
         }

      }

      property AccessibleStates State 
      {

         // Gets the state for the Chart. This is used by accessibility programs.
         virtual AccessibleStates get() override
         {
            return AccessibleStates::ReadOnly;
         }

      }

      // The CurveLegend objects are "child" controls in terms of accessibility so
      // return the number of ChartLengend objects.
      virtual int GetChildCount() override
      {
         return chartControl->Legends->Length;
      }


      // Gets the Accessibility object of the child CurveLegend idetified by index.
      virtual AccessibleObject^ GetChild( int index ) override
      {
         if ( index >= 0 && index < chartControl->Legends->Length )
         {
            return chartControl->Legends[ index ]->AccessibilityObject;
         }

         return nullptr;
      }


   internal:

      // Helper function that is used by the CurveLegend's accessibility object
      // to navigate between sibiling controls. Specifically, this function is used in
      // the CurveLegend::CurveLegendAccessibleObject.Navigate function.
      AccessibleObject^ NavigateFromChild( CurveLegend::CurveLegendAccessibleObject^ child, AccessibleNavigation navdir )
      {
         switch ( navdir )
         {
            case AccessibleNavigation::Down:
            case AccessibleNavigation::Next:
               return GetChild( child->ID + 1 );

            case AccessibleNavigation::Up:
            case AccessibleNavigation::Previous:
               return GetChild( child->ID - 1 );
         }
         return nullptr;
      }


      // Helper function that is used by the CurveLegend's accessibility object
      // to select a specific CurveLegend control. Specifically, this function is used
      // in the CurveLegend::CurveLegendAccessibleObject.Select function.
      void SelectChild( CurveLegend::CurveLegendAccessibleObject^ child, AccessibleSelection selection )
      {
         int childID = child->ID;
         
         // Determine which selection action should occur, based on the
         // AccessibleSelection value.
         if ( (selection & AccessibleSelection::TakeSelection) != (AccessibleSelection)0 )
         {
            for ( int i = 0; i < chartControl->Legends->Length; i++ )
            {
               if ( i == childID )
               {
                  chartControl->Legends[ i ]->Selected = true;
               }
               else
               {
                  chartControl->Legends[ i ]->Selected = false;
               }

            }
            
            // AccessibleSelection->AddSelection means that the CurveLegend will be selected.
            if ( (selection & AccessibleSelection::AddSelection) != (AccessibleSelection)0 )
            {
               chartControl->Legends[ childID ]->Selected = true;
            }
            
            // AccessibleSelection->AddSelection means that the CurveLegend will be unselected.
            if ( (selection & AccessibleSelection::RemoveSelection) != (AccessibleSelection)0 )
            {
               chartControl->Legends[ childID ]->Selected = false;
            }
         }
      }

   };

   // class ChartControlAccessibleObject
   //</Snippet4>
};


// class ChartControl
public ref class Form1: public System::Windows::Forms::Form
{
private:

   // Test out the Chart Control.
   ChartControl^ chart1;

public:
   Form1()
   {
      
      // Create a chart control and add it to the form.
      this->chart1 = gcnew ChartControl;
      this->ClientSize = System::Drawing::Size( 920, 566 );
      this->chart1->Location = System::Drawing::Point( 47, 16 );
      this->chart1->Size = System::Drawing::Size( 600, 400 );
      this->Controls->Add( this->chart1 );
   }

};


// class Form1

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}

//</Snippet1>
