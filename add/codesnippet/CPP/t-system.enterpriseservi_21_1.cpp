// Accept a constructor string.

[ConstructionEnabled]
public ref class EmployeeInformation: public ServicedComponent
{
private:

   // The employee's user name and salary.
   String^ accountName;
   double salary;

public:

   // Get the employee's name. All users can call this method.
   String^ GetName()
   {
      return (accountName);
   }

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

   // Get the employee's salary. Only the employee and managers can do this.
   double GetSalary()
   {
      if ( SecurityCallContext::CurrentCall->DirectCaller->AccountName == accountName || SecurityCallContext::CurrentCall->IsCallerInRole( "Manager" ) )
      {
         return (salary);
      }
      else
      {
         throw gcnew UnauthorizedAccessException;
      }
   }

protected:
   // Use the constructor string.
   // This method is called when the object is instantiated.
   virtual void Construct( String^ constructorString ) override
   {
      accountName = constructorString;
   }
};
