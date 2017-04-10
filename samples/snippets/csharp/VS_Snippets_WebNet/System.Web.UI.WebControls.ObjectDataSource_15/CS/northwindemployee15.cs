// <snippet2>
namespace Samples.AspNet.CS {

using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

  public class EmployeeLogic {

    public EmployeeLogic() {  
        throw new NotSupportedException("Initialize data.");
    }
    
    public EmployeeLogic(string data) {
        _data = data;
    }

    private string _data;
    
    // Returns a collection of NorthwindEmployee objects.
    public ICollection GetAllEmployees () {
      ArrayList al = new ArrayList();      
      al.Add(_data);        
      return al;
    }
    
  }

}
// </snippet2>