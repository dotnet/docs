// <snippet2>
namespace Samples.AspNet.CS {

using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
  //
  // EmployeeLogic is a stateless business object that encapsulates
  // the operations you can perform on a NorthwindEmployee object.
  //
  public class EmployeeLogic {

    public EmployeeLogic () : this(DateTime.Now) {        
    }
    
    public EmployeeLogic (DateTime creationTime) { 
        _creationTime = creationTime;
    }

    private DateTime _creationTime;
    
    // Returns a collection of NorthwindEmployee objects.
    public ICollection GetCreateTime () {
      ArrayList al = new ArrayList();
      
      // Returns creation time for this example.      
      al.Add("The business object that you are using was created at " + _creationTime);
      
      return al;
    }
  }
}
// </snippet2>