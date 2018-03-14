using System;
using System.Globalization;
using System.ComponentModel;
using System.Windows.Forms;

// <Snippet1>
[ProvideProperty("MyProperty", typeof(Control))]
public class MyClass : IExtenderProvider {
    protected CultureInfo ciMine = null;
    // Provides the Get portion of MyProperty. 
    public CultureInfo GetMyProperty(Control myControl) {
        // Insert code here.
        return ciMine;
    }
    
    // Provides the Set portion of MyProperty.
    public void SetMyProperty(Control myControl, string value) {
        // Insert code here.
    }
    
    /* When you inherit from IExtenderProvider, you must implement the 
     * CanExtend method. */
    public bool CanExtend(Object target) {
        return(target is Control);
    }
    
    // Insert additional code here.
 }
// </Snippet1>
