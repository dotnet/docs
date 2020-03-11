

// <snippet0>
#using <System.EnterpriseServices.dll>

using namespace System;
using namespace System::EnterpriseServices;

// <snippet1>
// Set component name and strong name key.
[assembly:ApplicationName("EmployeeInformation")];
[assembly:System::Reflection::AssemblyKeyFile("EmployeeInformation.snk")];
// </snippet1>

// <snippet2>
// Set component access controls.
[assembly:ApplicationAccessControl(Authentication=AuthenticationOption::Privacy,
ImpersonationLevel=ImpersonationLevelOption::Identify,
AccessChecksLevel=AccessChecksLevelOption::ApplicationComponent)];
// </snippet2>

// <snippet3>
// Create a security role for the component.
[assembly:SecurityRole("Manager")];
// </snippet3>

// <snippet4>
// Accept a constructor string.

[ConstructionEnabled]
public ref class EmployeeInformation: public ServicedComponent
{
private:

   // The employee's user name and salary.
   String^ accountName;
   double salary;

public:

   // <snippet5>
   // Get the employee's name. All users can call this method.
   String^ GetName()
   {
      return (accountName);
   }
   // </snippet5>

   // <snippet6>
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
   // </snippet6>

   // <snippet7>
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
   // </snippet7>

   // <snippet8>
protected:
   // Use the constructor string.
   // This method is called when the object is instantiated.
   virtual void Construct( String^ constructorString ) override
   {
      accountName = constructorString;
   }
   // </snippet8>
};

// </snippet4>
// </snippet0>
