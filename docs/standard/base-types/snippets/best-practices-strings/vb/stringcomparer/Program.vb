Module Program
    Sub Main()
        Dim file1 As New FileName("autoexec.bat", Nothing)
        Dim file2 As New FileName("AutoExec.BAT", Nothing)

        Console.WriteLine(file1.CompareTo(file2))
    End Sub
End Module

'<class>
Class FileName
    Implements IComparable

    Private ReadOnly _comparer As StringComparer

    Public ReadOnly Property Name As String

    Public Sub New(name As String, comparer As StringComparer)
        If (String.IsNullOrEmpty(name)) Then Throw New ArgumentNullException(NameOf(name))

        Me.Name = name

        If comparer IsNot Nothing Then
            _comparer = comparer
        Else
            _comparer = StringComparer.OrdinalIgnoreCase
        End If
    End Sub

    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        If obj Is Nothing Then Return 1

        If TypeOf obj IsNot FileName Then
            Return _comparer.Compare(Name, obj.ToString())
        Else
            Return _comparer.Compare(Name, DirectCast(obj, FileName).Name)
        End If
    End Function
End Class
'</class>
