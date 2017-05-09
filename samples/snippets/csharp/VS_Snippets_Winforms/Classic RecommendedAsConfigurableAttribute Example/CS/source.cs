using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{

    // <Snippet1>
    [RecommendedAsConfigurable(true)]
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
    public void Method1(){
        // <Snippet2>
        // Gets the attributes for the property.
        AttributeCollection attributes = 
           TypeDescriptor.GetProperties(this)["MyProperty"].Attributes;
         
        // Checks to see if the value of the RecommendedAsConfigurableAttribute is Yes.
        if(attributes[typeof(RecommendedAsConfigurableAttribute)].Equals(RecommendedAsConfigurableAttribute.Yes)) {
           // Insert code here.
        }
         
        // This is another way to see if the property is recommended as configurable.
        RecommendedAsConfigurableAttribute myAttribute = 
           (RecommendedAsConfigurableAttribute)attributes[typeof(RecommendedAsConfigurableAttribute)];
        if(myAttribute.RecommendedAsConfigurable) {
           // Insert code here.
        }
        // </Snippet2>
    }

    public void Method2(){
        // <Snippet3>
        AttributeCollection attributes = 
           TypeDescriptor.GetAttributes(MyProperty);
        if(attributes[typeof(RecommendedAsConfigurableAttribute)].Equals(RecommendedAsConfigurableAttribute.Yes)) {
           // Insert code here.
        }
        // </Snippet3>
    }
}

