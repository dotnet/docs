/*
   System.Runtime.InteropServices.ProgIdAttribute.Value
   
   The program shows MyClass as a COM class with prog id 'InteropSample.MyClass'.
   It get all attributes of MyClass by calling GetAttributes method of TypeDescriptor
   then prints the 'Value' property of 'ProgIdAttribute' class.
*/
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace InteropSample
{   
// <Snippet1>
   [ClassInterface(ClassInterfaceType.AutoDispatch)]
   [ProgId("InteropSample.MyClass")]
   public class MyClass
   {
       public MyClass() {}
   }

   class TestApplication
   {      
      public static void Main()
      {
         try
         {
            AttributeCollection attributes;
            attributes = TypeDescriptor.GetAttributes(typeof(MyClass));
            ProgIdAttribute progIdAttributeObj = (ProgIdAttribute)attributes[typeof(ProgIdAttribute)];
            Console.WriteLine("ProgIdAttribute's value is set to : " + progIdAttributeObj.Value);
         }         
         catch(Exception e)
         {
            Console.WriteLine("Exception : " + e.Message);
         }
      }
   }
// </Snippet1>
}
