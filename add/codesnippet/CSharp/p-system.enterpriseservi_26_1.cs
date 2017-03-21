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