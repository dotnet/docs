// <Snippet2>
using System;
using System.Runtime.InteropServices;

[Guid("936DA01F-9ABD-4d9d-80C7-02AF85C822A8")]
public class Example
{
   public static void Main()
   {
      GuidAttribute guidAttr = (GuidAttribute) Attribute.GetCustomAttribute(typeof(Example), 
                                                      typeof(GuidAttribute));
      Guid guidValue = Guid.Parse(guidAttr.Value);
      Object[] values = { null , 16, 
                          Guid.Parse("01e75c83-c6f5-4192-b57e-7427cec5560d"),
                          guidValue };
      foreach (var value in values) {
         try {
            Console.WriteLine("{0} and {1}: {2}", guidValue, 
                              value == null ? "null" : value,
                              guidValue.CompareTo(value));
         }
         catch (ArgumentException) {
            Console.WriteLine("Cannot compare {0} and {1}", guidValue,
                              value == null ? "null" : value);
         }                     
      }                         
   }
}
// The example displays the following output:
//    936da01f-9abd-4d9d-80c7-02af85c822a8 and null: 1
//    Cannot compare 936da01f-9abd-4d9d-80c7-02af85c822a8 and 16
//    936da01f-9abd-4d9d-80c7-02af85c822a8 and 01e75c83-c6f5-4192-b57e-7427cec5560d: 1
//    936da01f-9abd-4d9d-80c7-02af85c822a8 and 936da01f-9abd-4d9d-80c7-02af85c822a8: 0
// </Snippet2>

