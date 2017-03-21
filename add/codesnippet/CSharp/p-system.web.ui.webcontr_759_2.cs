    // This InsertNewEmployeeWrapper method is a wrapper method that enables
    // the use of ObjectDataSource and InsertParameters, without
    // substantially rewriting the true implementation for the NorthwindEmployee
    // or the EmployeeLogic objects.
    //
    // The parameters to the method must be named the same as the
    // DataControlFields used by the GridView or DetailsView controls.
    public static void InsertNewEmployeeWrapper (string FirstName,
                                                 string LastName,
                                                 string Title,
                                                 string Courtesy,
                                                 int    Supervisor)
    {
      // Build the NorthwindEmployee object and
      // call the true  implementation.
      NorthwindEmployee tempEmployee = new NorthwindEmployee();

      tempEmployee.FirstName  = FirstName;
      tempEmployee.LastName   = LastName;
      tempEmployee.Title      = Title;
      tempEmployee.Courtesy   = Courtesy;
      tempEmployee.Supervisor = Supervisor;

      // Call the true implementation.
      InsertNewEmployee(tempEmployee);
    }

    public static void InsertNewEmployee(NorthwindEmployee ne) {
      bool retval = ne.Save();
      if (! retval) { throw new NorthwindDataException("InsertNewEmployee failed."); }
    }