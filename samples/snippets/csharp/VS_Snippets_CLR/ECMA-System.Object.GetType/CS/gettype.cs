// <Snippet1>
using System;

public class MyBaseClass {
}

public class MyDerivedClass: MyBaseClass {
}

public class Test 
{
   public static void Main() 
   {
      MyBaseClass myBase = new MyBaseClass();
      MyDerivedClass myDerived = new MyDerivedClass();
      object o = myDerived;
      MyBaseClass b = myDerived;

      Console.WriteLine("mybase: Type is {0}", myBase.GetType());
      Console.WriteLine("myDerived: Type is {0}", myDerived.GetType());
      Console.WriteLine("object o = myDerived: Type is {0}", o.GetType());
      Console.WriteLine("MyBaseClass b = myDerived: Type is {0}", b.GetType());
   }
}
// The example displays the following output:
//    mybase: Type is MyBaseClass
//    myDerived: Type is MyDerivedClass
//    object o = myDerived: Type is MyDerivedClass
//    MyBaseClass b = myDerived: Type is MyDerivedClass 
// </Snippet1>
