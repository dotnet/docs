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