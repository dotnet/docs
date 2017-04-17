'<Snippet1>
' Define a base and a derived class.
Public Class MyBaseClass
End Class 

Public Class MyDerivedClass : Inherits MyBaseClass
End Class 

Public Class Test
    Public Shared Sub Main() 
        Dim base As New MyBaseClass()
        Dim derived As New MyDerivedClass()
        Dim o As Object = derived
        Dim b As MyBaseClass = derived
        
        Console.WriteLine("base.GetType returns {0}", base.GetType())
        Console.WriteLine("derived.GetType returns {0}", derived.GetType())
        Console.WriteLine("Dim o As Object = derived; o.GetType returns {0}", o.GetType())
        Console.WriteLine("Dim b As MyBaseClass = derived; b.Type returns {0}", b.GetType())
    End Sub 
End Class 
' The example displays the following output:
'    base.GetType returns MyBaseClass
'    derived.GetType returns MyDerivedClass
'    Dim o As Object = derived; o.GetType returns MyDerivedClass
'    Dim b As MyBaseClass = derived; b.Type returns MyDerivedClass
'</Snippet1>
