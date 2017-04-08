using System;
using System.Runtime.InteropServices;

public class Example
{
   public static void Main()
   {
   }

   // <Snippet2>
   public void SomeMethod([MarshalAs(UnmanagedType.LPStr)] String s)
   // </Snippet2>
   {
      
   }


   
   // <Snippet3>
   decimal _money;   
   
   public decimal Money 
   {
      [return: MarshalAs(UnmanagedType.Currency)]
      get { return this._money; }
      [param: MarshalAs(UnmanagedType.Currency)]
      set { this._money = value; }
   }
   // </Snippet3>
}
