// <Snippet1>
using System;
using System.Reflection;

public class Example
{
   public static void Main()
   {
      var t = new TestClass();  
      Console.WriteLine(t.GetValue());
      t.Value = 10;
      Console.WriteLine(t.Value);
      Console.WriteLine();
      
      var tg =new Test<int>(200);
      Console.WriteLine(tg.GetValue());
      var b = tg.ConvertValue<Byte>();
      Console.WriteLine("{0} -> {1} ({2})", tg.GetValue().GetType().Name,
                        b, b.GetType().Name);
   }
}        

public class TestClass
{
   private Nullable<int> _value;
   
   public TestClass()
   {
      MethodBase m = MethodBase.GetCurrentMethod();
      Console.WriteLine("Executing {0}.{1}", 
                        m.ReflectedType.Name, m.Name);
   }
   
   public TestClass(int value)
   {
      MethodBase m = MethodBase.GetCurrentMethod();
      Console.WriteLine("Executing {0}.{1}", 
                        m.ReflectedType.Name, m.Name);
      _value = value;
   }
   
   public int Value
   {  
      get {
         MethodBase m = MethodBase.GetCurrentMethod();
         Console.WriteLine("Executing {0}.{1}", 
                           m.ReflectedType.Name, m.Name);
         return _value.GetValueOrDefault();
      }
      set {
         MethodBase m = MethodBase.GetCurrentMethod();
         Console.WriteLine("Executing {0}.{1}", 
                           m.ReflectedType.Name, m.Name);
         _value = value;
      }
   }
   
   public int GetValue()
   {
      MethodBase m = MethodBase.GetCurrentMethod();
      Console.WriteLine("Executing {0}.{1}", 
                        m.ReflectedType.Name, m.Name);
      return this.Value;
   }
}

public class Test<T>
{
   private T value;
   
   public Test(T value)
   {
      MethodBase m = MethodBase.GetCurrentMethod();
      Console.WriteLine("Executing {0}.{1}", 
                        m.ReflectedType.Name, m.Name);
      this.value = value;
   }
   
   public T GetValue()
   {
      MethodBase m = MethodBase.GetCurrentMethod();
      Console.WriteLine("Executing {0}.{1}", 
                        m.ReflectedType.Name, m.Name);
      return value;
   }
   
   public Y ConvertValue<Y>() 
   {
      MethodBase m = MethodBase.GetCurrentMethod();
      Console.WriteLine("Executing {0}.{1}", 
                        m.ReflectedType.Name, m.Name);
      Console.Write("      Generic method: {0}, definition: {1}, Args: ", 
                        m.IsGenericMethod, m.IsGenericMethodDefinition);
      if (m.IsGenericMethod) {
         foreach (var arg in m.GetGenericArguments())
            Console.Write("{0} ", arg.Name);
      }
      Console.WriteLine();
      try {
         return (Y) Convert.ChangeType(value, typeof(Y));
      }
      catch (OverflowException) {
         throw; 
      }   
      catch (InvalidCastException) {
         throw;
      }   
   }   
}
// The example displays the following output:
//       Executing TestClass..ctor
//       Executing TestClass.GetValue
//       Executing TestClass.get_Value
//       0
//       Executing TestClass.set_Value
//       Executing TestClass.get_Value
//       10
//       
//       Executing Test`1..ctor
//       Executing Test`1.GetValue
//       200
//       Executing Test`1.ConvertValue
//             Generic method: True, definition: True, Args: Y
//       Executing Test`1.GetValue
//       Int32 -> 200 (Byte)
// </Snippet1>

