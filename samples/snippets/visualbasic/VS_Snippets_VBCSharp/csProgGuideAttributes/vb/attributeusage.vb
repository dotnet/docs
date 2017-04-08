'<Snippet42>
Imports System
'</Snippet42>

'<Snippet38>
<AttributeUsage(AttributeTargets.Property Or AttributeTargets.Field)> 
Class NewPropertyOrFieldAttribute
    Inherits Attribute
End Class
'</Snippet38>

Module Module1
    '<Snippet36>
    <System.AttributeUsage(System.AttributeTargets.All, 
                       AllowMultiple:=False, 
                       Inherited:=True)> 
    Class NewAttribute
        Inherits System.Attribute
    End Class

    '</Snippet36>

    Sub Main()

    End Sub


End Module


Module M2

    '<Snippet37>
    <System.AttributeUsage(System.AttributeTargets.All)> 
    Class NewAttribute
        Inherits System.Attribute
    End Class
    '</Snippet37>
End Module

Module M4
    '<Snippet39>
    <AttributeUsage(AttributeTargets.Class, AllowMultiple:=True)> 
    Class MultiUseAttr
        Inherits Attribute
    End Class
    
    <MultiUseAttr(), MultiUseAttr()> 
    Class Class1
    End Class

    '</Snippet39>
End Module

Module M5
    '<Snippet40>
    <AttributeUsage(AttributeTargets.Class, Inherited:=False)> 
    Class Attr1
        Inherits Attribute
    End Class

    <Attr1()> 
    Class BClass

    End Class  

    Class DClass
        Inherits BClass
    End Class
    '</Snippet40>
End Module

Module M6
    '<Snippet41>
    ' Create some custom attributes:
    <AttributeUsage(System.AttributeTargets.Class, Inherited:=False)> 
    Class A1
        Inherits System.Attribute
    End Class

    <AttributeUsage(System.AttributeTargets.Class)> 
    Class A2
        Inherits System.Attribute
    End Class    

    <AttributeUsage(System.AttributeTargets.Class, AllowMultiple:=True)> 
    Class A3
        Inherits System.Attribute
    End Class


    ' Apply custom attributes to classes:
    <A1(), A2()> 
    Class BaseClass

    End Class

    <A3(), A3()> 
    Class DerivedClass
        Inherits BaseClass
    End Class


    Public Class TestAttributeUsage
        Sub Main()
            Dim b As New BaseClass
            Dim d As New DerivedClass
            ' Display custom attributes for each class.
            Console.WriteLine("Attributes on Base Class:")
            Dim attrs() As Object = b.GetType().GetCustomAttributes(True)

            For Each attr In attrs
                Console.WriteLine(attr)
            Next

            Console.WriteLine("Attributes on Derived Class:")
            attrs = d.GetType().GetCustomAttributes(True)
            For Each attr In attrs
                Console.WriteLine(attr)
            Next            
        End Sub
    End Class

    '</Snippet41>
End Module
