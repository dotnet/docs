// <Snippet1>
using System;
using System.Runtime.Remoting.Metadata;
using System.Runtime.Remoting.MetadataServices;
using System.IO;

public class Test {

   class TestClass {
      int integer;
      public double dFloatingPoint = 5.1999;

      public int Int {
         get { return integer; }
         set { integer = value; }
      }

      public void Print () {
         Console.WriteLine("The double is equal to {0}.", dFloatingPoint);
      }
   }
   

   public static void Main() {

      Type[] types = new Type[4];

      String s = "a";
      int i = -5;
      double d = 3.1415;
      TestClass tc = new TestClass();

      types[0] = s.GetType();
      types[1] = i.GetType();
      types[2] = d.GetType();
      types[3] = tc.GetType();

      FileStream fs = new FileStream("test.xml", FileMode.OpenOrCreate);
      MetaData.ConvertTypesToSchemaToStream(types, SdlType.Wsdl, fs);
   }
}
// </Snippet1>