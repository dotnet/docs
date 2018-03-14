'Types:System.Reflection.TypeFilter Vendor: Richter
'<snippet1>
Imports System.Reflection

' This interface is defined in this assembly.
Public Interface IBookRetailer
    Sub Purchase()
    Sub ApplyDiscount()
End Interface

' This interface is also defined in this assembly.
Public Interface IMusicRetailer
    Sub Purchase()
End Interface

' This class implements three interfaces;
'    Two are defined in this assembly.
'    One is defined in another assembly.
Public Class MyRetailer
    Implements IBookRetailer, IMusicRetailer, IComparable

    ' For demonstration purposes, this method returns nothing.
    Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
        Return Nothing
    End Function

    ' For demonstration purposes only, this method does nothing.
    Public Sub ApplyDiscount() Implements IBookRetailer.ApplyDiscount
    End Sub

    ' For demonstration purposes only, this method does nothing.
    Public Sub Purchase() Implements IBookRetailer.Purchase
    End Sub

    ' For demonstration purposes only, this method does nothing.
    Public Sub Purchase1() Implements IMusicRetailer.Purchase
    End Sub
End Class

Module Module1
    Sub Main()
        ' Find the interfaces defined by the MyRetailer class. Each interface found is passed to
        ' the TypeFilter method which checks if the interface is defined in the executing assembly.
        Dim retailerType As Type = GetType(MyRetailer)
        Dim interfaces() As Type = _
            retailerType.FindInterfaces(AddressOf TypeFilter, retailerType.Assembly.GetName().ToString())

        ' Show the interfaces that are defined in this assembly that are also implemented by MyRetailer.
        Console.WriteLine("MyRetailer implements the following interfaces (defined in this assembly):")
        For Each t In interfaces
            Console.WriteLine("   {0}", t.Name)
        Next
    End Sub

    ' This method is called by the FindInterfaces method. 
    ' This method is called once per defined interface.
    Function TypeFilter(ByVal t As Type, ByVal filterCriteria As Object) As Boolean
        ' Return true if interface is defined in the same 
        ' assembly identified by the filterCriteria object.
        Return t.Assembly.GetName().ToString() = CType(filterCriteria, String)
    End Function
End Module
' The example displays the following output:
'    MyRetailer implements the following interfaces (defined in this assembly):
'      IBookRetailer
'      IMusicRetailer
'</snippet1>

