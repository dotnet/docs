//<Snippet1>
using System;
using System.Reflection;

namespace ResolveMethodExample
{
    // Metadata tokens for the MethodRefs that are to be resolved.
    // If you change this program, some or all of these metadata tokens might
    // change. The new token values can be discovered by compiling the example
    // and examining the assembly with Ildasm.exe, using the /TOKENS option. 
    // Recompile the program after correcting the token values. 
    enum Tokens
    {
        Case1 = 0x2b000001,
        Case2 = 0x0A000006,
        Case3 = 0x2b000002,
        Case4 = 0x06000006,
        Case5 = 0x2b000002        
    }

    class G1<Tg1>
    {
        public void GM1<Tgm1> (Tg1 param1, Tgm1 param2) {}
        public void M1(Tg1 param) {}
    }

    class G2<Tg2>
    {
        public void GM2<Tgm2> (Tg2 param1, Tgm2 param2)
        {
            // Case 1: A generic method call that depends on its generic 
            // context, because it uses the type parameters of the enclosing
            // generic type G2 and the enclosing generic method GM2. The token 
            // for the MethodSpec is Tokens.Case1.
            G1<Tg2> g = new G1<Tg2>();
            g.GM1<Tgm2>(param1, param2);

            // Case 2: A non-generic method call that depends on its generic 
            // context, because it uses the type parameter of the enclosing
            // generic type G2. The token for the MemberRef is Tokens.Case2.
            g.M1(param1);

            // Case 3: A generic method call that does not depend on its generic 
            // context, because it does not use type parameters of the enclosing
            // generic type or method. The token for the MethodSpec is Tokens.Case3.
            G1<int> gi = new G1<int>();
            gi.GM1<object>(42, new Object());

            // Case 4: A non-generic method call that does not depend on its 
            // generic context, because it does not use the type parameters of the
            // enclosing generic type or method. The token for the MethodDef is 
            // Tokens.Case4.
            Example e = new Example();
            e.M();
        } 
    }

    class Example
    {
        public void M()
        {
            G1<int> g = new G1<int>();
            // Case 5: A generic method call that does not have any generic 
            // context. The token for the MethodSpec is Tokens.Case5.
            g.GM1<object>(42, new Object());
        }

        static void Main ()
        {      
            Module mod = typeof(Example).Assembly.ManifestModule;
            MethodInfo miResolved2 = null;

            // Case 1: A generic method call that is dependent on its generic context.
            //
            // Create and display a MethodInfo representing the MethodSpec of the 
            // generic method g.GM1<Tgm2>() that is called in G2<Tg2>.GM2<Tgm2>().
            Type t = typeof(G1<>).MakeGenericType(typeof(G2<>).GetGenericArguments());
            MethodInfo mi = typeof(G2<>).GetMethod("GM2");
            MethodInfo miTest = t.GetMethod("GM1").MakeGenericMethod(mi.GetGenericArguments());
            Console.WriteLine("\nCase 1:\n{0}", miTest);

            // Resolve the MethodSpec token for method G1<Tg2>.GM1<Tgm2>(), which 
            // is called in method G2<Tg2>.GM2<Tgm2>(). The GetGenericArguments method 
            // must be used to obtain the context for resolving the method.
            MethodInfo miResolved = (MethodInfo) mod.ResolveMethod(
                (int)Tokens.Case1, 
                typeof(G2<>).GetGenericArguments(), 
                typeof(G2<>).GetMethod("GM2").GetGenericArguments());
            Console.WriteLine(miResolved);
            Console.WriteLine("Is the resolved method the same? {0}", miResolved == miTest);

            // The overload that doesn't specify generic context throws an exception
            // because there is insufficient context to resolve the token.
            try 
            { 
                miResolved2 = (MethodInfo) mod.ResolveMethod((int)Tokens.Case1);
            } 
            catch (Exception ex) 
            { 
                Console.WriteLine("{0}: {1}", ex.GetType(), ex.Message); 
            }


            // Case 2: A non-generic method call that is dependent on its generic context.
            //
            // Create and display a MethodInfo representing the MemberRef of the 
            // non-generic method g.M1() that is called in G2<Tg2>.GM2<Tgm2>().
            t = typeof(G1<>).MakeGenericType(typeof(G2<>).GetGenericArguments());
            miTest = t.GetMethod("M1");
            Console.WriteLine("\nCase 2:\n{0}", miTest);

            // Resolve the MemberRef token for method G1<Tg2>.M1(), which is
            // called in method G2<Tg2>.GM2<Tgm2>(). The GetGenericArguments method 
            // must be used to obtain the context for resolving the method, because
            // the method parameter comes from the generic type G1, and the type
            // argument, Tg2, comes from the generic type that encloses the call.
            // There is no enclosing generic method, so the value Type.EmptyTypes
            // could be passed for the genericMethodArguments parameter.
            miResolved = (MethodInfo) mod.ResolveMethod(
                (int)Tokens.Case2, 
                typeof(G2<>).GetGenericArguments(), 
                typeof(G2<>).GetMethod("GM2").GetGenericArguments());
            Console.WriteLine(miResolved);
            Console.WriteLine("Is the resolved method the same? {0}", miResolved == miTest);

            // The overload that doesn't specify generic context throws an exception
            // because there is insufficient context to resolve the token.
            try 
            { 
                miResolved2 = (MethodInfo) mod.ResolveMethod((int)Tokens.Case2);
            } 
            catch (Exception ex) 
            { 
                Console.WriteLine("{0}: {1}", ex.GetType(), ex.Message); 
            }


            // Case 3: A generic method call that is independent of its generic context.
            //
            // Create and display a MethodInfo representing the MethodSpec of the 
            // generic method gi.GM1<object>() that is called in G2<Tg2>.GM2<Tgm2>().
            mi = typeof(G1<int>).GetMethod("GM1");
            miTest = mi.MakeGenericMethod(new Type[] { typeof(object) });
            Console.WriteLine("\nCase 3:\n{0}", miTest);

            // Resolve the token for method G1<int>.GM1<object>(), which is called
            // in G2<Tg2>.GM2<Tgm2>(). The GetGenericArguments method is used to 
            // obtain the context for resolving the method, but the method call in
            // this case does not use type parameters of the enclosing type or
            // method, so Type.EmptyTypes could be used for both arguments.
            miResolved = (MethodInfo) mod.ResolveMethod(
                (int)Tokens.Case3, 
                typeof(G2<>).GetGenericArguments(), 
                typeof(G2<>).GetMethod("GM2").GetGenericArguments());
            Console.WriteLine(miResolved);
            Console.WriteLine("Is the resolved method the same? {0}", miResolved == miTest);

            // The method call in this case does not depend on the enclosing generic
            // context, so the token can also be resolved by the simpler overload.
            miResolved2 = (MethodInfo) mod.ResolveMethod((int)Tokens.Case3);


            // Case 4: A non-generic method call that is independent of its generic context.
            //
            // Create and display a MethodInfo representing the MethodDef of the 
            // method e.M() that is called in G2<Tg2>.GM2<Tgm2>().
            miTest = typeof(Example).GetMethod("M");
            Console.WriteLine("\nCase 4:\n{0}", miTest);

            // Resolve the token for method Example.M(), which is called in
            // G2<Tg2>.GM2<Tgm2>(). The GetGenericArguments method is used to 
            // obtain the context for resolving the method, but the non-generic 
            // method call does not use type parameters of the enclosing type or
            // method, so Type.EmptyTypes could be used for both arguments.
            miResolved = (MethodInfo) mod.ResolveMethod(
                (int)Tokens.Case4, 
                typeof(G2<>).GetGenericArguments(), 
                typeof(G2<>).GetMethod("GM2").GetGenericArguments());
            Console.WriteLine(miResolved);
            Console.WriteLine("Is the resolved method the same? {0}", miResolved == miTest);

            // The method call in this case does not depend on any enclosing generic
            // context, so the token can also be resolved by the simpler overload.
            miResolved2 = (MethodInfo) mod.ResolveMethod((int)Tokens.Case4);


            // Case 5: Generic method call in a non-generic context.
            //
            // Create and display a MethodInfo representing the MethodRef of the 
            // closed generic method g.GM1<object>() that is called in Example.M().
            mi = typeof(G1<int>).GetMethod("GM1");
            miTest = mi.MakeGenericMethod(new Type[] { typeof(object) });
            Console.WriteLine("\nCase 5:\n{0}", miTest);

            // Resolve the token for method G1<int>.GM1<object>(), which is called
            // in method Example.M(). The GetGenericArguments method is used to 
            // obtain the context for resolving the method, but the enclosing type
            // and method are not generic, so Type.EmptyTypes could be used for
            // both arguments.
            miResolved = (MethodInfo) mod.ResolveMethod(
                (int)Tokens.Case5, 
                typeof(Example).GetGenericArguments(),
                typeof(Example).GetMethod("M").GetGenericArguments());
            Console.WriteLine(miResolved);
            Console.WriteLine("Is the resolved method the same? {0}", miResolved == miTest);

            // The method call in this case does not depend on any enclosing generic
            // context, so the token can also be resolved by the simpler overload.
            miResolved2 = (MethodInfo) mod.ResolveMethod((int)Tokens.Case5);
        }
    }
}
/* This example produces the following output:

Case 1:
Void GM1[Tgm2](Tg2, Tgm2)
Void GM1[Tgm2](Tg2, Tgm2)
Is the resolved method the same? True
System.ArgumentException: A BadImageFormatException has been thrown while parsing the signature. This is likely due to lack of a generic context. Ensure genericTypeArguments and genericMethodArguments are provided and contain enough context.

Case 2:
Void M1(Tg2)
Void M1(Tg2)
Is the resolved method the same? True
System.ArgumentException: A BadImageFormatException has been thrown while parsing the signature. This is likely due to lack of a generic context. Ensure genericTypeArguments and genericMethodArguments are provided and contain enough context.

Case 3:
Void GM1[Object](Int32, System.Object)
Void GM1[Object](Int32, System.Object)
Is the resolved method the same? True

Case 4:
Void M()
Void M()
Is the resolved method the same? True

Case 5:
Void GM1[Object](Int32, System.Object)
Void GM1[Object](Int32, System.Object)
Is the resolved method the same? True
 */
//</Snippet1>
