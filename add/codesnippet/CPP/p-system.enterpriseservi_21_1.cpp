   // Set the employee's salary. Only managers can do this.
   void SetSalary( double ammount )
   {
      if ( SecurityCallContext::CurrentCall->IsCallerInRole( "Manager" ) )
      {
         salary = ammount;
      }
      else
      {
         throw gcnew UnauthorizedAccessException;
      }
   }