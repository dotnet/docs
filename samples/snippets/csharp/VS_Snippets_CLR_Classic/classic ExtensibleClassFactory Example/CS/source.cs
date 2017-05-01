// <Snippet1>
using System;
using System.Runtime.InteropServices;

public class CallBack
{
   public IntPtr Activate(IntPtr Aggregator)
   {
      ECFSRV32Lib.ObjectActivator oCOM = new ECFSRV32Lib.ObjectActivator();
      ECFSRV32Lib.IObjectActivator itf = (ECFSRV32Lib.IObjectActivator)oCOM;
      return (IntPtr) itf.CreateBaseComponent((int)Aggregator);
   }
}

//
// The EcfInner class. First .NET class derived directly from COM class.
//
public class EcfInner : ECFSRV32Lib.BaseComponent
{
   static CallBack callbackInner;

   static void RegisterInner()
   {      
      callbackInner = new CallBack();
      System.Runtime.InteropServices.ExtensibleClassFactory.RegisterObjectCreationCallback(new System.Runtime.InteropServices.ObjectCreationDelegate(callbackInner.Activate));
   }

   //This is the static initializer.    
   static EcfInner()
   {
      RegisterInner();
   }
}
// </Snippet1>

//This namespace is a placeholder for the ECFSRV32Lib - since
// this library may not exist on the build machine we place
// a dummy namespace with dummy classes to keep the compiler
// happy.
namespace ECFSRV32Lib
{
   public class BaseComponent
   {

   }

   public class ObjectActivator : IObjectActivator
   {
      public int CreateBaseComponent(int Aggregator)
      {
         return 0;
      }
   } 

   interface IObjectActivator
   {
      int CreateBaseComponent(int Aggregator);
   }
}