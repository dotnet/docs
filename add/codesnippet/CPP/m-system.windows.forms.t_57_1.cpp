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