' <Snippet1>
Imports System.IO
Imports System.IO.MemoryMappedFiles
Imports System.Runtime.InteropServices

Class Program

    Sub Main()
        Dim offset As Long = &H10000000 ' 256 megabytes
        Dim length As Long = &H20000000 ' 512 megabytes

        ' Create the memory-mapped file.
        Using mmf = MemoryMappedFile.CreateFromFile("c:\ExtremelyLargeImage.data", FileMode.Open, "ImgA")
            ' <Snippet2>
            ' Create a random access view, from the 256th megabyte (the offset)
            ' to the 768th megabyte (the offset plus length).
            Using accessor = mmf.CreateViewAccessor(offset, length)
                Dim colorSize As Integer = Marshal.SizeOf(GetType(MyColor))
                Dim color As MyColor
                Dim i As Long = 0

                ' Make changes to the view.
                Do While (i < length)
                    accessor.Read(i, color)
                    color.Brighten(10)
                    accessor.Write(i, color)
                    i += colorSize
                Loop
            End Using
            ' </Snippet2>
        End Using
    End Sub
End Class

Public Structure MyColor
    Public Red As Short
    Public Green As Short
    Public Blue As Short
    Public Alpha As Short

    ' Make the view brighter.
    Public Sub Brighten(ByVal value As Short)
        Red = CType(Math.Min(Short.MaxValue, (CType(Red, Integer) + value)), Short)
        Green = CType(Math.Min(Short.MaxValue, (CType(Green, Integer) + value)), Short)
        Blue = CType(Math.Min(Short.MaxValue, (CType(Blue, Integer) + value)), Short)
        Alpha = CType(Math.Min(Short.MaxValue, (CType(Alpha, Integer) + value)), Short)
    End Sub
End Structure
' </Snippet1>
