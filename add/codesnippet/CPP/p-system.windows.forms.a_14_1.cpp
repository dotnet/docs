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