' <Snippet1>
Imports System.Collections.Generic

Module Example
    Public Sub Main()
        Console.WriteLine("Defined Classes:")
        Dim room1 As New Room()
        Dim kitchen1 As New Kitchen()
        Dim bedroom1 As New Bedroom()
        Dim guestroom1 As New Guestroom()
        Dim masterbedroom1 As New MasterBedroom()

        Dim room1Type As Type = room1.GetType()
        Dim kitchen1Type As Type = kitchen1.GetType()
        Dim bedroom1Type As Type = bedroom1.GetType()
        Dim guestroom1Type As Type = guestroom1.GetType()
        Dim masterbedroom1Type As Type = masterbedroom1.GetType()

        Console.WriteLine("room assignable from kitchen: {0}", room1Type.IsAssignableFrom(kitchen1Type))
        Console.WriteLine("bedroom assignable from guestroom: {0}", bedroom1Type.IsAssignableFrom(guestroom1Type))
        Console.WriteLine("kitchen assignable from masterbedroom: {0}", kitchen1Type.IsAssignableFrom(masterbedroom1Type))

        ' Demonstrate arrays:
        Console.WriteLine()
        Console.WriteLine("Integer arrays:")

        Dim array10(10) As Integer
        Dim array2(2) As Integer
        Dim array22(2, 2) As Integer
        Dim array24(2, 4) As Integer

        Dim array10Type As Type = array10.GetType
        Dim array2Type As Type = array2.GetType
        Dim array22Type As Type = array22.GetType
        Dim array24Type As Type = array24.GetType

        Console.WriteLine("Integer(2) assignable from Integer(10): {0}", array2Type.IsAssignableFrom(array10Type))
        Console.WriteLine("Integer(2) assignable from Integer(2,4): {0}", array2Type.IsAssignableFrom(array24Type))
        Console.WriteLine("Integer(2,4) assignable from Integer(2,2): {0}", array24Type.IsAssignableFrom(array22Type))

        ' Demonstrate generics:
        Console.WriteLine()
        Console.WriteLine("Generics:")

        Dim arrayNull(10) As Nullable(Of Integer)
        Dim genIntList As New List(Of Integer)
        Dim genTList As New List(Of Type)

        Dim arrayNullType As Type = arrayNull.GetType
        Dim genIntListType As Type = genIntList.GetType
        Dim genTListType As Type = genTList.GetType

        Console.WriteLine("Integer(10) assignable from Nullable(Of Integer)(10): {0}", array10Type.IsAssignableFrom(arrayNullType))
        Console.WriteLine("List(Of Integer) assignable from List(Of Type): {0}", genIntListType.IsAssignableFrom(genTListType))
        Console.WriteLine("List(Of Type) assignable from List(Of Integer): {0}", genTListType.IsAssignableFrom(genIntListType))
        Console.ReadLine()
    End Sub
End Module

Class Room
End Class

Class Kitchen : Inherits Room
End Class

Class Bedroom : Inherits Room
End Class

Class Guestroom : Inherits Bedroom
End Class

Class MasterBedroom : Inherits Bedroom
End Class
' The example displays the following output:
'    Defined Classes:
'    room assignable from kitchen: True
'    bedroom assignable from guestroom: True
'    kitchen assignable from masterbedroom: False
'
'    Integer arrays:
'    Integer(2) assignable from Integer(10): True
'    Integer(2) assignable from Integer(2,4): False
'    Integer(2,4) assignable from Integer(2,2): True
'
'    Generics:
'    Integer(10) assignable from Nullable(Of Integer)(10): False
'    List(Of Integer) assignable from List(Of Type): False
'    List(Of Type) assignable from List(Of Integer): False
' </Snippet1>
