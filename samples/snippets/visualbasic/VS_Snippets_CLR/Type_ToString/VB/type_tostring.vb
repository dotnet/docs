' <Snippet1>	
Namespace MyNamespace
    Class [MyClass]
    End Class 
End Namespace 

Public Class Example
    Public Shared Sub Main()
         Dim myType As Type = GetType(MyNamespace.MyClass)
         Console.WriteLine(", myType)
         ' Get the namespace of the MyClass class.
         Console.WriteLine("   Namespace: {0}.", myType.Namespace)
         ' Get the name of the module.
         Console.WriteLine("   Module: {0}.", myType.Module)
         ' Get the fully qualified type name.
         Console.WriteLine("   Fully qualified name: {0}.", myType.ToString())
    End Sub
End Class
' The example displays the following output:
'       Displaying information about MyNamespace.MyClass:
'          Namespace: MyNamespace.
'          Module: type_tostring.exe.
'          Fully qualified name: MyNamespace.MyClass.
' </Snippet1>	