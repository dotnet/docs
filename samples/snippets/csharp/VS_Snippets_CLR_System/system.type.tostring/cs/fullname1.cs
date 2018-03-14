// <Snippet1>
using System;
using System.Collections.Generic;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      Type t = typeof(String);
      ShowTypeInfo(t);

      t = typeof(System.Collections.Generic.List<>);
      ShowTypeInfo(t);

      var list = new List<String>();
      t = list.GetType();
      ShowTypeInfo(t);

      Object v = 12;
      t = v.GetType();
      ShowTypeInfo(t);

      t = typeof(IFormatProvider);
      ShowTypeInfo(t);

      IFormatProvider ifmt = NumberFormatInfo.CurrentInfo;
      t = ifmt.GetType();
      ShowTypeInfo(t);
   }

   private static void ShowTypeInfo(Type t)
   {
      Console.WriteLine("Name: {0}", t.Name);
      Console.WriteLine("Full Name: {0}", t.FullName);
      Console.WriteLine("ToString:  {0}", t.ToString());
      Console.WriteLine("Assembly Qualified Name: {0}",
                        t.AssemblyQualifiedName);
      Console.WriteLine();
   }
}
// The example displays output like the following:
//    Name: String
//    Full Name: System.String
//    ToString:  System.String
//    Assembly Qualified Name: System.String, mscorlib, Version=4.0.0.0, Culture=neutr
//    al, PublicKeyToken=b77a5c561934e089
//
//    Name: List`1
//    Full Name: System.Collections.Generic.List`1
//    ToString:  System.Collections.Generic.List`1[T]
//    Assembly Qualified Name: System.Collections.Generic.List`1, mscorlib, Version=4.
//    0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
//
//    Name: List`1
//    Full Name: System.Collections.Generic.List`1[[System.String, mscorlib, Version=4
//    .0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]
//    ToString:  System.Collections.Generic.List`1[System.String]
//    Assembly Qualified Name: System.Collections.Generic.List`1[[System.String, mscor
//    lib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorl
//    ib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
//
//    Name: Int32
//    Full Name: System.Int32
//    ToString:  System.Int32
//    Assembly Qualified Name: System.Int32, mscorlib, Version=4.0.0.0, Culture=neutra
//    l, PublicKeyToken=b77a5c561934e089
//
//    Name: IFormatProvider
//    Full Name: System.IFormatProvider
//    ToString:  System.IFormatProvider
//    Assembly Qualified Name: System.IFormatProvider, mscorlib, Version=4.0.0.0, Cult
//    ure=neutral, PublicKeyToken=b77a5c561934e089
//
//    Name: NumberFormatInfo
//    Full Name: System.Globalization.NumberFormatInfo
//    ToString:  System.Globalization.NumberFormatInfo
//    Assembly Qualified Name: System.Globalization.NumberFormatInfo, mscorlib, Versio
//    n=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// </Snippet1>

