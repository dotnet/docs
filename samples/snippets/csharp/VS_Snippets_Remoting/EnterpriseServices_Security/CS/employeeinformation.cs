// <snippet0>
using System;
using System.EnterpriseServices;

// <snippet1>
// Set component name and strong name key.
[assembly: ApplicationName("EmployeeInformation")]
[assembly: System.Reflection.AssemblyKeyFile("EmployeeInformation.snk")]
// </snippet1>

// <snippet2>
// Set component access controls.
[assembly: ApplicationAccessControl(Authentication=AuthenticationOption.Privacy,
                                    ImpersonationLevel=ImpersonationLevelOption.Identify,
                                    AccessChecksLevel=AccessChecksLevelOption.ApplicationComponent)]
// </snippet2>

// <snippet3>
// Create a security role for the component.
[assembly: SecurityRole("Manager")]
// </snippet3>

// <snippet4>
// Accept a constructor string.
[ConstructionEnabled]

public class EmployeeInformation : ServicedComponent
{

    // The employee's user name and salary.
    private string accountName;
    private double salary = 0;

  
    // <snippet5>
    // Get the employee's name. All users can call this method.
    public string GetName ()
    {
      return(accountName);
    }
    // </snippet5>


    // <snippet6>
    // Set the employee's salary. Only managers can do this.
    public void SetSalary (double ammount)
    {
        if (SecurityCallContext.CurrentCall.IsCallerInRole("Manager"))
        {
            salary = ammount;
        }
        else
        {
            throw new UnauthorizedAccessException();
        }
    }
    // </snippet6>


    // <snippet7>
    // Get the employee's salary. Only the employee and managers can do this.
    public double GetSalary ()
    {
        if ( SecurityCallContext.CurrentCall.DirectCaller.AccountName == accountName ||
             SecurityCallContext.CurrentCall.IsCallerInRole("Manager") )
        {
            return(salary);
        }
        else
        {
          throw new UnauthorizedAccessException();
        }
    }
    // </snippet7>


    // <snippet8>
    // Use the constructor string.
    // This method is called when the object is instantiated.
    protected override void Construct (string constructorString)
    {
        accountName = constructorString;
    }
    // </snippet8>

}
// </snippet4>
// </snippet0>
