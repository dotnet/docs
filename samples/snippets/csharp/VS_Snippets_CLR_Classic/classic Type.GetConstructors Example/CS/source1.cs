// <Snippet1>
 using System;
 using System.Reflection;
 
 public class t {
     public t() {}
     static t() {}
     public t(int i) {}
 
     public static void Main() {
         ConstructorInfo[] p = typeof(t).GetConstructors();
         Console.WriteLine(p.Length);
 
         for (int i=0;i<p.Length;i++) {
             Console.WriteLine(p[i].IsStatic);
         }
     }
 }
// </Snippet1>
