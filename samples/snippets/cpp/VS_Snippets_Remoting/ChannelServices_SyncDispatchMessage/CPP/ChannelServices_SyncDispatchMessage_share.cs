/*
   The class 'PrintServer' is derived from 'MarshalByRefObject' to
   make it remotable.
*/
using System;
using System.Runtime.Remoting;
public class PrintServer : MarshalByRefObject
{
   public int MyPrintMethod(String myString, double fValue, int iValue)
   {
      Console.WriteLine("PrintServer.MyPrintMethod {0} {1} {2}",
         myString, fValue, iValue);
      return iValue;
   }
}
