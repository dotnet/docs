   public class HelloService : MarshalByRefObject
   {
      public string HelloMethod(string name)
      {
         Console.WriteLine("Hello " + name);
         return "Hello " + name;
      }

      [PermissionSet(SecurityAction.LinkDemand)]
      public string HeaderMethod(string name,Header[] arrHeader)
      {
         Console.WriteLine("HeaderMethod " + name);
         //Header Set with the header array passed
         CallContext.SetHeaders(arrHeader);
         return "HeaderMethod " + name;
      }

   }