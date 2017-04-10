// System.Web.Services.Protocols.LogicalMethodTypes.Sync
// System.Web.Services.Protocols.LogicalMethodTypes.LogicalMethodTypes
// System.Web.Services.Protocols.LogicalMethodInfo.MethodInfo

// All the following have been grouped as one snippet : Snippet4

// System.Web.Services.Protocols.LogicalMethodInfo.GetCustomAttribute(Type)
// System.Web.Services.Protocols.LogicalMethodInfo.GetCustomAttributes(Type)
// System.Web.Services.Protocols.LogicalMethodInfo.ReturnTypeCustomAttributeProvider
// System.Web.Services.Protocols.LogicalMethodInfo.CustomAttributeProvider



/*
   This following example demonstrates the 'MethodInfo',
   'ReturnTypeCustomAttributeProvider', 'CustomAttributeProvider',
   properties and 'GetCustomAttribute(Type)', 
   'GetCustomAttributes(Type)' methods of the 'LogicalMethodInfo' class
   and 'Sync' enum member of 'LogicalMethodTypes' enumeration. 
   This example demonstrates custom attributes and return attributes of the
   'Add' method.
   
   Note : The 'LogicalMethodInfo' class should only be used with
   'SoapMessage'. 'SoapClientMessage' and 'SoapServerMessage' contain
   a property named 'MethodInfo' which provides for an instance of
   'LogicalMethodInfo'. If you are interested only in the reflection
   of a type then use the 'System.Reflection' namespace and not this
   class. This class gives information about the method invoked for
   a web service and hence should only be used as such. For example
   purposes it is being showed in a more simplified scenario.
 */
// <Snippet4>
using System;
using System.Reflection;
using System.Web.Services.Protocols;

// Define a custom attribute with one named parameter.
[AttributeUsage(AttributeTargets.Method | AttributeTargets.ReturnValue, AllowMultiple=true)]
public class MyAttribute : Attribute
{
   private string myName;
   public MyAttribute(string name)
   {
      myName = name;
   }
   public string Name 
   {
      get 
      {
         return myName;
      }
   }
}

public class MyService 
{
   [MyAttribute("This is the first sample attribute")]
   [MyAttribute("This is the second sample attribute")]
   [return: MyAttribute("This is the return sample attribute")]
   public int Add(int xValue, int yValue)
   {
      return (xValue + yValue);
   }
}

public class LogicalMethodInfo_GetCustomAttribute
{
   public static void Main()
   {
// <Snippet3>      
      Type myType = typeof(MyService);
      MethodInfo myMethodInfo = myType.GetMethod("Add");
// <Snippet1>
// <Snippet2>
      // Create a synchronous 'LogicalMethodInfo' instance.
      LogicalMethodInfo myLogicalMethodInfo = 
         (LogicalMethodInfo.Create(new MethodInfo[] {myMethodInfo}, 
                                   LogicalMethodTypes.Sync))[0];
// </Snippet2>
// </Snippet1>
      // Display the method for which the attributes are being displayed.
      Console.WriteLine("\nDisplaying the attributes for the method : {0}\n",
                           myLogicalMethodInfo.MethodInfo);
// </Snippet3>

      // Displaying a custom attribute of type 'MyAttribute'
      Console.WriteLine("\nDisplaying attribute of type 'MyAttribute'\n");
      object attribute = myLogicalMethodInfo.GetCustomAttribute(typeof(MyAttribute));
      Console.WriteLine(((MyAttribute)attribute).Name);

      // Display all custom attribute of type 'MyAttribute'.
      Console.WriteLine("\nDisplaying all attributes of type 'MyAttribute'\n");
      object[] attributes = myLogicalMethodInfo.GetCustomAttributes(typeof(MyAttribute));
      for(int i = 0; i < attributes.Length; i++)
         Console.WriteLine(((MyAttribute)attributes[i]).Name);

      // Display all return attributes of type 'MyAttribute'.
      Console.WriteLine("\nDisplaying all return attributes of type 'MyAttribute'\n");
      ICustomAttributeProvider myCustomAttributeProvider = 
                  myLogicalMethodInfo.ReturnTypeCustomAttributeProvider;
      if(myCustomAttributeProvider.IsDefined(typeof(MyAttribute), true))
      {
         attributes = myCustomAttributeProvider.GetCustomAttributes(true);
         for(int i = 0; i < attributes.Length; i++)
            if(attributes[i].GetType().Equals(typeof(MyAttribute)))
               Console.WriteLine(((MyAttribute)attributes[i]).Name);
      }

      // Display all the custom attributes of type 'MyAttribute'.
      Console.WriteLine("\nDisplaying all attributes of type 'MyAttribute'\n");
      myCustomAttributeProvider = myLogicalMethodInfo.CustomAttributeProvider;
      if(myCustomAttributeProvider.IsDefined(typeof(MyAttribute), true))
      {
         attributes = myCustomAttributeProvider.GetCustomAttributes(true);
         for(int i = 0; i < attributes.Length; i++)
            if(attributes[i].GetType().Equals(typeof(MyAttribute)))
               Console.WriteLine(((MyAttribute)attributes[i]).Name);
      }
   }
}
// </Snippet4>