// Accept a constructor string.
[ConstructionEnabled]

public class EmployeeInformation : ServicedComponent
{

    // The employee's user name and salary.
    private string accountName;
    private double salary = 0;

  
    // Get the employee's name. All users can call this method.
    public string GetName ()
    {
      return(accountName);
    }


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


    // Use the constructor string.
    // This method is called when the object is instantiated.
    protected override void Construct (string constructorString)
    {
        accountName = constructorString;
    }

}