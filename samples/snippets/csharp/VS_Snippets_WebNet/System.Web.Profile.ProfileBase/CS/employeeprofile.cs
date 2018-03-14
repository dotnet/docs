//<Snippet1>
using System;
using System.Web.Profile;

namespace Samples.AspNet.Profile
{
  public class EmployeeProfile : ProfileBase
  {
    [SettingsAllowAnonymous(false)]
    [ProfileProvider("EmployeeInfoProvider")]
    public string Department
    {
      get { return base["EmployeeDepartment"].ToString(); }
      set { base["EmployeeDepartment"] = value; }
    }

    [SettingsAllowAnonymous(false)]
    [ProfileProvider("EmployeeInfoProvider")]
    public EmployeeInfo Details
    {
      get { return (EmployeeInfo)base["EmployeeInfo"]; }
      set { base["EmployeeInfo"] = value; }
    }

  }

  public class EmployeeInfo
  {
    public string Name;
    public string Address;
    public string Phone;
    public string EmergencyContactName;
    public string EmergencyContactAddress;
    public string EmergencyContactPhone;
  }
}
//</Snippet1>