// <snippet2>
namespace Samples.AspNet.CS {

using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;
  //
  // EmployeeLogic is a stateless business object that encapsulates 
  // the operations you can perform on a NorthwindEmployee object.
  //
  public class EmployeeLogic {
  
    
    // Returns a collection of NorthwindEmployee objects.
    public static ICollection GetAllEmployees () {
      ArrayList data = new ArrayList();
           
      data.Add(new NorthwindEmployee(1,"Nancy","Davolio","507 - 20th Ave. E. Apt. 2A"));
      data.Add(new NorthwindEmployee(2,"Andrew","Fuller","908 W. Capital Way"));
      data.Add(new NorthwindEmployee(3,"Janet","Leverling","722 Moss Bay Blvd."));
      data.Add(new NorthwindEmployee(4,"Margaret","Peacock","4110 Old Redmond Rd."));
      data.Add(new NorthwindEmployee(5,"Steven","Buchanan","14 Garrett Hill"));
      data.Add(new NorthwindEmployee(6,"Michael","Suyama","Coventry House Miner Rd."));
      data.Add(new NorthwindEmployee(7,"Robert","King","Edgeham Hollow Winchester Way"));
      
      return data;
    }
    
    public static NorthwindEmployee GetEmployee(object anID) {
      ArrayList data = GetAllEmployees() as ArrayList;     
      int empID = Int32.Parse(anID.ToString());      
      return data[empID] as NorthwindEmployee;
    }

    // 
    // To support basic filtering, the employees cannot
    // be returned as an array of objects, rather as a 
    // DataSet of the raw data values. 
    public static DataSet GetAllEmployeesAsDataSet () {
      ICollection employees = GetAllEmployees();
      
      DataSet ds = new DataSet("Table");
      
      // Create the schema of the DataTable.
      DataTable dt = new DataTable();
      DataColumn dc;
      dc = new DataColumn("EmpID",   typeof(int));    dt.Columns.Add(dc);
      dc = new DataColumn("FullName",typeof(string)); dt.Columns.Add(dc);
      dc = new DataColumn("Address", typeof(string)); dt.Columns.Add(dc);
      
      // Add rows to the DataTable.
      DataRow row;
            
      foreach (NorthwindEmployee ne in employees) {                
        row = dt.NewRow();
        row["EmpID"]    = ne.EmpID;
        row["FullName"] = ne.FullName;
        row["Address"]  = ne.Address;
        dt.Rows.Add(row);
      } 
      // Add the complete DataTable to the DataSet.
      ds.Tables.Add(dt);
      
      return ds;
    }    
  }

  public class NorthwindEmployee {

    public NorthwindEmployee (int anID, 
                              string aFirstName,
                              string aLastName,
                              string anAddress) {
      ID = anID;
      firstName = aFirstName;
      lastName = aLastName;   
      address = anAddress;
    }

    private object ID;
    public string EmpID {
      get { return ID.ToString();  }
    }

    private string lastName;
    public string LastName {
      get { return lastName; }
      set { lastName = value; }
    }

    private string firstName;
    public string FirstName {
      get { return firstName; }
      set { firstName = value;  }
    }
    
    public string FullName {
      get { return FirstName  + " " +  LastName; }
    }
    
    private string address;
    public string Address {
      get { return address; }
      set { address = value;  }
    }    
    
  }
}
// </snippet2>