// <Snippet1>
using System.Runtime.InteropServices;

public class MyClass
{
   public MyClass() {}

   [DispId(8)]
   public void MyMethod() {}
   
   public int MyOtherMethod() {
      return 0;
   }
   
   [DispId(9)]
   public bool MyField;
}
// </Snippet1>

