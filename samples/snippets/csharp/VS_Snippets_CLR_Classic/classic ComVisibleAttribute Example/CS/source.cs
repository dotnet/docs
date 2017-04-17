// <Snippet1>
using System.Runtime.InteropServices;

[ComVisible(false)]
class MyClass
{
   public MyClass()
   {
      //Insert code here.
   }
   
   [ComVisible(false)]
   public int MyMethod(string param) 
   {
      return 0;
   }

   public bool MyOtherMethod() 
   {
      return true;
   }

   [ComVisible(false)]
   public int MyProperty
   {
      get
      {
         return MyProperty;
      }
   }
}
// </Snippet1>

