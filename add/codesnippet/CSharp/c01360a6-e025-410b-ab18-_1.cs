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
      Type myType = typeof(MyService);
      MethodInfo myMethodInfo = myType.GetMethod("Add");
      // Create a synchronous 'LogicalMethodInfo' instance.
      LogicalMethodInfo myLogicalMethodInfo = 
         (LogicalMethodInfo.Create(new MethodInfo[] {myMethodInfo}, 
                                   LogicalMethodTypes.Sync))[0];
      // Display the method for which the attributes are being displayed.
      Console.WriteLine("\nDisplaying the attributes for the method : {0}\n",
                           myLogicalMethodInfo.MethodInfo);

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