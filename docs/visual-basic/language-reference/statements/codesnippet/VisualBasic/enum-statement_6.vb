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