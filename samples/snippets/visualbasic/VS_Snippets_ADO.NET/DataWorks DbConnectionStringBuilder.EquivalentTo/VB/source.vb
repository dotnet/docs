Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.Common
Module Module1

    ' <Snippet1>
    Sub Main()
        Dim builder1 As New DbConnectionStringBuilder
        builder1.ConnectionString = _
            "Value1=SomeValue;Value2=20;Value3=30;Value4=40"
        Console.WriteLine("builder1 = " & builder1.ConnectionString)

        Dim builder2 As New DbConnectionStringBuilder
        builder2.ConnectionString = _
            "value2=20;value3=30;VALUE4=40;Value1=SomeValue"
        Console.WriteLine("builder2 = " & builder2.ConnectionString)

        Dim builder3 As New DbConnectionStringBuilder
        builder3.ConnectionString = _
            "value2=20;value3=30;VALUE4=40;Value1=SOMEVALUE"
        Console.WriteLine("builder3 = " & builder3.ConnectionString)

        ' builder1 and builder2 contain the same
        ' keys and values, in different order, and the 
        ' keys are not consistently cased. They are equivalent.
        Console.WriteLine("builder1.EquivalentTo(builder2) = " & _
            builder1.EquivalentTo(builder2).ToString())

        ' builder2 and builder3 contain the same key/value pairs in the 
        ' the same order, but the value casing is different, so they're
        ' not equivalent.
        Console.WriteLine("builder2.EquivalentTo(builder3) = " & _
            builder2.EquivalentTo(builder3).ToString())

        Console.WriteLine("Press Enter to continue.")
        Console.ReadLine()
    End Sub
    ' </Snippet1>
End Module
