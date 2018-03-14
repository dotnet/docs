using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;

public class Class1
{
    protected CultureInfo myCultureInfo;
    // <Snippet1>
    [DesignOnly(true)]
     public CultureInfo GetLanguage {
        get {
           // Insert code here.
           return myCultureInfo;
        }
        set {
           // Insert code here.
        }
     }
    // </Snippet1>

    private int Property1
        {
        get
            {
            // <Snippet2>
            // Gets the attributes for the property.
             AttributeCollection attributes = 
                TypeDescriptor.GetProperties(this)["GetLanguage"].Attributes;

             /* Prints whether the property is marked as DesignOnly 
              * by retrieving the DesignOnlyAttribute from the AttributeCollection. */
             DesignOnlyAttribute myAttribute = 
                (DesignOnlyAttribute)attributes[typeof(DesignOnlyAttribute)];
             Console.WriteLine("This property is design only :" +
                myAttribute.IsDesignOnly.ToString());
             // </Snippet2>
             return 1;
            }
        }
}
