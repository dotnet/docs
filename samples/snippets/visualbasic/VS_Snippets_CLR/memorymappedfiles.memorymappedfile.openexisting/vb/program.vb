' <Snippet1>
Imports System
Imports System.IO.MemoryMappedFiles
Imports System.Runtime.InteropServices

Class Program
    Public Shared Sub Main(ByVal args As String())
        ' Assumes another process has created the memory-mapped file.
        Using mmf = MemoryMappedFile.OpenExisting("ImgA")
            Using accessor = mmf.CreateViewAccessor(4000000, 2000000)
                Dim colorSize As Integer = Marshal.SizeOf(GetType(MyColor))
                Dim color As MyColor

                ' Make changes to the view.
                Dim i As Long = 0
                While i < 1500000
                    accessor.Read(i, color)
                    color.Brighten(30)
                    accessor.Write(i, color)
                    i += colorSize
                End While
            End Using
        End Using
    End Sub
End Class

Public Structure MyColor
    Public Red As Short
    Public Green As Short
    Public Blue As Short
    Public Alpha As Short

    ' Make the view brigher.
    Public Sub Brighten(ByVal value As Short)
        Red = CShort(Math.Min(Short.MaxValue, CInt(Red) + value))
        Green = CShort(Math.Min(Short.MaxValue, CInt(Green) + value))
        Blue = CShort(Math.Min(Short.MaxValue, CInt(Blue) + value))
        Alpha = CShort(Math.Min(Short.MaxValue, CInt(Alpha) + value))
    End Sub
End Structure
' </Snippet1>