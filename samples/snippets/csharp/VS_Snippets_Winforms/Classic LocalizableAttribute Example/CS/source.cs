using System;
using System.ComponentModel;
public class Class1
{
    // <Snippet1>
    [Localizable(true)]
     public int MyProperty {
        get {
           // Insert code here.
           return 0;
        }
        set {
           // Insert code here.
        }
     }
    // </Snippet1>

    public void Method1()
    {
        // <Snippet2>
        // Gets the attributes for the property.
        AttributeCollection attributes = 
        TypeDescriptor.GetProperties(this)["MyProperty"].Attributes;

        // Checks to see if the property needs to be localized.
        LocalizableAttribute myAttribute = 
        (LocalizableAttribute)attributes[typeof(LocalizableAttribute)];
        if(myAttribute.IsLocalizable) {
        // Insert code here.
        }
        // </Snippet2>
    }
}
