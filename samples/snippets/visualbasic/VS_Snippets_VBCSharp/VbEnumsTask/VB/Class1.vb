'<Snippet22>
Imports WindowsApplication1.Form1.Days
Imports WindowsApplication1.Form1.WorkDays
'</Snippet22>

Public Class Class3
    Dim X As Integer

    Sub test()
        '<Snippet24>
        X = Sunday
        '</Snippet24>
    End Sub


    '<Snippet25>
    Public Sub New()
        ' Insert code to implement constructor.
        X = Monday
    End Sub
    '</Snippet25>
End Class


Public Class Class4
    '<snippet41>
    Public Class Egg
        Enum EggSizeEnum
            Jumbo
            ExtraLarge
            Large
            Medium
            Small
        End Enum

        Public Sub Poach()
            Dim size As EggSizeEnum

            size = EggSizeEnum.Medium
            ' Continue processing...
        End Sub
    End Class
    '</snippet41>

    '<snippet42>
    Public Sub Scramble(ByVal size As Egg.EggSizeEnum)
        ' Process for the three largest sizes.
        ' Throw an exception for any other size.
        Select Case size
            Case Egg.EggSizeEnum.Jumbo
                ' Process.
            Case Egg.EggSizeEnum.ExtraLarge
                ' Process.
            Case Egg.EggSizeEnum.Large
                ' Process.
            Case Else
                Throw New ApplicationException("size is invalid: " & size.ToString)
        End Select
    End Sub
    '</snippet42>
End Class


Public Class Class5
    '<snippet51>
    Enum EggSizeEnum
        Jumbo
        ExtraLarge
        Large
        Medium
        Small
    End Enum

    Public Sub Iterate()
        Dim names = [Enum].GetNames(GetType(EggSizeEnum))
        For Each name In names
            Console.Write(name & " ")
        Next
        Console.WriteLine()
        ' Output: Jumbo ExtraLarge Large Medium Small 

        Dim values = [Enum].GetValues(GetType(EggSizeEnum))
        For Each value In values
            Console.Write(value & " ")
        Next
        Console.WriteLine()
        ' Output: 0 1 2 3 4 
    End Sub
    '</snippet51>
End Class



Public Class Class6
    '<snippet61>
    ' Apply the Flags attribute, which allows an instance
    ' of the enumeration to have multiple values.
    <Flags()> Public Enum FilePermissions As Integer
        None = 0
        Create = 1
        Read = 2
        Update = 4
        Delete = 8
    End Enum

    Public Sub ShowBitwiseEnum()

        ' Declare the non-exclusive enumeration object and
        ' set it to multiple values.
        Dim perm As FilePermissions
        perm = FilePermissions.Read Or FilePermissions.Update

        ' Show the values in the enumeration object.
        Console.WriteLine(perm.ToString)
        ' Output: Read, Update

        ' Show the total integer value of all values
        ' in the enumeration object.
        Console.WriteLine(CInt(perm))
        ' Output: 6

        ' Show whether the enumeration object contains
        ' the specified flag.
        Console.WriteLine(perm.HasFlag(FilePermissions.Update))
        ' Output: True
    End Sub
    '</snippet61>
End Class
