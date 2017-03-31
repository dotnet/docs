' <Snippet1>
Imports System.Collections.Generic

Friend Class Program
	Shared Sub Main(ByVal args() As String)
		' <Snippet2>
		Dim Boxes As New List(Of Box)()
		Boxes.Add(New Box(4, 20, 14))
		Boxes.Add(New Box(12, 12, 12))
		Boxes.Add(New Box(8, 20, 10))
		Boxes.Add(New Box(6, 10, 2))
		Boxes.Add(New Box(2, 8, 4))
		Boxes.Add(New Box(2, 6, 8))
		Boxes.Add(New Box(4, 12, 20))
		Boxes.Add(New Box(18, 10, 4))
		Boxes.Add(New Box(24, 4, 18))
		Boxes.Add(New Box(10, 4, 16))
		Boxes.Add(New Box(10, 2, 10))
		Boxes.Add(New Box(6, 18, 2))
		Boxes.Add(New Box(8, 12, 4))
		Boxes.Add(New Box(12, 10, 8))
		Boxes.Add(New Box(14, 6, 6))
		Boxes.Add(New Box(16, 6, 16))
		Boxes.Add(New Box(2, 8, 12))
		Boxes.Add(New Box(4, 24, 8))
		Boxes.Add(New Box(8, 6, 20))
		Boxes.Add(New Box(18, 18, 12))

		' Sort by an Comparer<T> implementation that sorts
		' first by the length.
		Boxes.Sort(New BoxLengthFirst())

		Console.WriteLine("H - L - W")
		Console.WriteLine("==========")
		For Each bx As Box In Boxes
            Console.WriteLine("{0}" & vbTab & "{1}" & vbTab & "{2}", _
                              bx.Height.ToString(), bx.Length.ToString(), _
                              bx.Width.ToString())
		Next bx
		' </Snippet2>

		Console.WriteLine()
		Console.WriteLine("H - L - W")
		Console.WriteLine("==========")

		' <Snippet3>
		' Get the default comparer that 
		' sorts first by the height.
		Dim defComp As Comparer(Of Box) = Comparer(Of Box).Default

		' Calling Boxes.Sort() with no parameter
		' is the same as calling Boxs.Sort(defComp)
		' because they are both using the default comparer.
		Boxes.Sort()

		For Each bx As Box In Boxes
            Console.WriteLine("{0}" & vbTab & "{1}" & vbTab & "{2}", _
                              bx.Height.ToString(), _
                              bx.Length.ToString(), _
                              bx.Width.ToString())
		Next bx
		' </Snippet3>

		' <Snippet4>

		' This explicit interface implementation
		' compares first by the length.
		' Returns -1 because the length of BoxA
		' is less than the length of BoxB.
		Dim LengthFirst As New BoxLengthFirst()

		Dim bc As Comparer(Of Box) = CType(LengthFirst, Comparer(Of Box))

		Dim BoxA As New Box(2, 6, 8)
		Dim BoxB As New Box(10, 12, 14)
		Dim x As Integer = LengthFirst.Compare(BoxA, BoxB)
		Console.WriteLine()
		Console.WriteLine(x.ToString())
		' </Snippet4>



	End Sub

End Class

' <Snippet5>
Public Class BoxLengthFirst
	Inherits Comparer(Of Box)
	' <Snippet6>
	' Compares by Length, Height, and Width.
	Public Overrides Function Compare(ByVal x As Box, ByVal y As Box) As Integer
		If x.Length.CompareTo(y.Length) <> 0 Then
			Return x.Length.CompareTo(y.Length)
		ElseIf x.Height.CompareTo(y.Height) <> 0 Then
			Return x.Height.CompareTo(y.Height)
		ElseIf x.Width.CompareTo(y.Width) <> 0 Then
			Return x.Width.CompareTo(y.Width)
		Else
			Return 0
		End If
	End Function
	' </Snippet6>

End Class
' </Snippet5>

' <Snippet7>
' This class is not demonstrated in the Main method
' and is provided only to show how to implement
' the interface. It is recommended to derive
' from Comparer<T> instead of implementing IComparer<T>.
Public Class BoxComp
	Implements IComparer(Of Box)
	' Compares by Height, Length, and Width.
    Public Function Compare(ByVal x As Box, ByVal y As Box) As Integer Implements _
                                                IComparer(Of Box).Compare
        If x.Height.CompareTo(y.Height) <> 0 Then
            Return x.Height.CompareTo(y.Height)
        ElseIf x.Length.CompareTo(y.Length) <> 0 Then
            Return x.Length.CompareTo(y.Length)
        ElseIf x.Width.CompareTo(y.Width) <> 0 Then
            Return x.Width.CompareTo(y.Width)
        Else
            Return 0
        End If
    End Function
End Class
' </Snippet7>

' <Snippet8>
Public Class Box
	Implements IComparable(Of Box)

	Public Sub New(ByVal h As Integer, ByVal l As Integer, ByVal w As Integer)
		Me.Height = h
		Me.Length = l
		Me.Width = w
	End Sub
	Private privateHeight As Integer
	Public Property Height() As Integer
		Get
			Return privateHeight
		End Get
		Private Set(ByVal value As Integer)
			privateHeight = value
		End Set
	End Property
	Private privateLength As Integer
	Public Property Length() As Integer
		Get
			Return privateLength
		End Get
		Private Set(ByVal value As Integer)
			privateLength = value
		End Set
	End Property
	Private privateWidth As Integer
	Public Property Width() As Integer
		Get
			Return privateWidth
		End Get
		Private Set(ByVal value As Integer)
			privateWidth = value
		End Set
	End Property

    Public Function CompareTo(ByVal other As Box) As Integer _
                        Implements IComparable(Of Box).CompareTo
        ' Compares Height, Length, and Width.
        If Me.Height.CompareTo(other.Height) <> 0 Then
            Return Me.Height.CompareTo(other.Height)
        ElseIf Me.Length.CompareTo(other.Length) <> 0 Then
            Return Me.Length.CompareTo(other.Length)
        ElseIf Me.Width.CompareTo(other.Width) <> 0 Then
            Return Me.Width.CompareTo(other.Width)
        Else
            Return 0
        End If
    End Function

End Class
' </Snippet8>

' </Snippet1>
