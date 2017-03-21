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