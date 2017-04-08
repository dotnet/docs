using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

public class Form1: Form
{
// <Snippet1>
public static void MyMethod(Type type, Type baseType) {
    Trace.Assert(type != null, "Type parameter is null", 
       "Can't get object for null type");
 
   // Perform some processing.
 }

// </Snippet1>
}
