//Declare a class that inherits from ToolStripControlHost.
public ref class ToolStripMonthCalendar: public ToolStripControlHost
{
public:
   // Call the base constructor passing in a MonthCalendar instance.
   ToolStripMonthCalendar() : ToolStripControlHost( gcnew MonthCalendar ) {}

   property MonthCalendar^ MonthCalendarControl 
   {
      MonthCalendar^ get()
      {
         return static_cast<MonthCalendar^>(Control);
      }
   }
   property Day FirstDayOfWeek 
   {
      // Expose the MonthCalendar.FirstDayOfWeek as a property.
      Day get()
      {
         return MonthCalendarControl->FirstDayOfWeek;
      }

      void set( Day value )
      {
         MonthCalendarControl->FirstDayOfWeek = value;
      }
   }

   // Expose the AddBoldedDate method.
   void AddBoldedDate( DateTime dateToBold )
   {
      MonthCalendarControl->AddBoldedDate( dateToBold );
   }

protected:
   // Subscribe and unsubscribe the control events you wish to expose.
   void OnSubscribeControlEvents( System::Windows::Forms::Control^ c )
   {
      // Call the base so the base events are connected.
      __super::OnSubscribeControlEvents( c );
      
      // Cast the control to a MonthCalendar control.
      MonthCalendar^ monthCalendarControl = (MonthCalendar^)c;
      
      // Add the event.
      monthCalendarControl->DateChanged += gcnew DateRangeEventHandler( this, &ToolStripMonthCalendar::HandleDateChanged );
   }

   void OnUnsubscribeControlEvents( System::Windows::Forms::Control^ c )
   {
      
      // Call the base method so the basic events are unsubscribed.
      __super::OnUnsubscribeControlEvents( c );
      
      // Cast the control to a MonthCalendar control.
      MonthCalendar^ monthCalendarControl = (MonthCalendar^)c;
      
      // Remove the event.
      monthCalendarControl->DateChanged -= gcnew DateRangeEventHandler( this, &ToolStripMonthCalendar::HandleDateChanged );
   }

public:
   event DateRangeEventHandler^ DateChanged;

private:
   // Declare the DateChanged event.
   // Raise the DateChanged event.
   void HandleDateChanged( Object^ sender, DateRangeEventArgs^ e )
   {
      if ( DateChanged != nullptr )
      {
         DateChanged( this, e );
      }
   }
};