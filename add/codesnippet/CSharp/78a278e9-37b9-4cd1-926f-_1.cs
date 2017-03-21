  public class NorthwindEmployee
  {
    public NorthwindEmployee() { }

    private int _employeeID;
    [DataObjectFieldAttribute(true, true, false)]
    public int EmployeeID
    {
      get { return _employeeID; }
      set { _employeeID = value; }
    }

    private string _firstName = String.Empty;
    [DataObjectFieldAttribute(false, false, true)]
    public string FirstName
    {
      get { return _firstName; }
      set { _firstName = value; }
    }

    private string _lastName = String.Empty;
    [DataObjectFieldAttribute(false, false, true)]
    public string LastName
    {
      get { return _lastName; }
      set { _lastName = value; }
    }
  }