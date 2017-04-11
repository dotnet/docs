// <Snippet1>
using System;
using System.Reflection;

internal struct S
{
    public int X;
}

public abstract class Example
{
    protected sealed class NestedClass {}

    public interface INested {}

    public static void Main()
    {
        // Create an array of types.
        Type[] types = { typeof(Example), typeof(NestedClass),
                         typeof(INested), typeof(S) };

        foreach (var t in types) {
           Console.WriteLine("Attributes for type {0}:", t.Name);

           TypeAttributes attr = t.Attributes;

           // To test for visibility attributes, you must use the visibility mask.
           TypeAttributes visibility = attr & TypeAttributes.VisibilityMask;
           switch (visibility)
           {
               case TypeAttributes.NotPublic:
                   Console.WriteLine("   ...is not public");
                   break;
               case TypeAttributes.Public:
                   Console.WriteLine("   ...is public");
                   break;
               case TypeAttributes.NestedPublic:
                   Console.WriteLine("   ...is nested and public");
                   break;
               case TypeAttributes.NestedPrivate:
                   Console.WriteLine("   ...is nested and private");
                   break;
               case TypeAttributes.NestedFamANDAssem:
                   Console.WriteLine("   ...is nested, and inheritable only within the assembly" +
                      "\n         (cannot be declared in C#)");
                   break;
               case TypeAttributes.NestedAssembly:
                   Console.WriteLine("   ...is nested and internal");
                   break;
               case TypeAttributes.NestedFamily:
                   Console.WriteLine("   ...is nested and protected");
                   break;
               case TypeAttributes.NestedFamORAssem:
                   Console.WriteLine("   ...is nested and protected internal");
                   break;
           }

           ' Use the layout mask to test for layout attributes.
           TypeAttributes layout = attr & TypeAttributes.LayoutMask;
           switch (layout)
           {
               case TypeAttributes.AutoLayout:
                   Console.WriteLine("   ...is AutoLayout");
                   break;
               case TypeAttributes.SequentialLayout:
                   Console.WriteLine("   ...is SequentialLayout");
                   break;
               case TypeAttributes.ExplicitLayout:
                   Console.WriteLine("   ...is ExplicitLayout");
                   break;
           }

           ' Use the class semantics mask to test for class semantics attributes.
           TypeAttributes classSemantics = attr & TypeAttributes.ClassSemanticsMask;
           switch (classSemantics)
           {
               case TypeAttributes.Class:
                   if (t.IsValueType)
                   {
                       Console.WriteLine("   ...is a value type");
                   }
                   else
                   {
                       Console.WriteLine("   ...is a class");
                   }
                   break;
               case TypeAttributes.Interface:
                   Console.WriteLine("   ...is an interface");
                   break;
           }

           if (0!=(attr & TypeAttributes.Abstract))
           {
               Console.WriteLine("   ...is abstract");
           }

           if (0!=(attr & TypeAttributes.Sealed))
           {
               Console.WriteLine("   ...is sealed");
           }
           Console.WriteLine();
       }
    }
}
// The example displays the following output:
//       Attributes for type Example:
//          ...is Public
//          ...is AutoLayout
//          ...is a class
//          ...is MustInherit
//
//       Attributes for type NestedClass:
//          ...is nested and Protected
//          ...is AutoLayout
//          ...is a class
//          ...is NotInheritable
//
//       Attributes for type INested:
//          ...is nested and Public
//          ...is AutoLayout
//          ...is an interface
//          ...is MustInherit
//
//       Attributes for type S:
//          ...is not Public
//          ...is SequentialLayout
//          ...is a value type
//          ...is NotInheritable
// </Snippet1>

