Imports System
Imports System.Globalization

Public Class Example
    Public Shared Sub Main()
        Console.WriteLine("Hi!")
    End Sub
End Class

' System.String.Compare(System.String,System.Int32,System.String,System.Int32,System.Int32)
Public Class CompareSample1_1
    '<Snippet2>
    Shared Function IsFileURI(ByVal path As String) As Boolean
        If String.Compare(path, 0, "file:", 0, 5, True) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    '</Snippet2>
End Class

' System.String.Compare(System.String,System.Int32,System.String,System.Int32,System.Int32)
Public Class CompareSample1_2
    '<Snippet3>
    Shared Function IsFileURI(ByVal path As String) As Boolean
        If String.Compare(path, 0, "file:", 0, 5, StringComparison.OrdinalIgnoreCase) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    '</Snippet3>
End Class

'System.String.Compare(System.String,System.Int32,System.String,System.Int32,System.Int32,System.Boolean)
Public Class CompareSample2_1
    '<Snippet4>
    Shared Function IsFileURI(ByVal path As String) As Boolean
        If String.Compare(path, 0, "file:", 0, 5, True) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    '</Snippet4>
End Class

'System.String.Compare(System.String,System.Int32,System.String,System.Int32,System.Int32,System.Boolean)
Public Class CompareSample2_2
    '<Snippet5>
    Shared Function IsFileURI(ByVal path As String) As Boolean
        If String.Compare(path, 0, "file:", 0, 5, StringComparison.OrdinalIgnoreCase) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    '</Snippet5>
End Class


'System.String.Compare(System.String,System.Int32,System.String,System.Int32,System.Int32,
'  System.Boolean,System.Globalization.CultureInfo)
Public Class CompareSample3_1
    '<Snippet6>
    Shared Function IsFileURI(ByVal path As String) As Boolean
        If String.Compare(path, 0, "file:", 0, 5, True) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    '</Snippet6>
End Class

'System.String.Compare(System.String,System.Int32,System.String,System.Int32,System.Int32,
'  System.Boolean,System.Globalization.CultureInfo)
Public Class CompareSample3_2
    '<Snippet7>
    Shared Function IsFileURI(ByVal path As String) As Boolean
        If String.Compare(path, 0, "file:", 0, 5, StringComparison.OrdinalIgnoreCase) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    '</Snippet7>
End Class

'System.String.Compare(System.String,System.Int32,System.String,System.Int32,
'  System.Int32,System.StringComparison)
Public Class CompareSample4_1
    '<Snippet8>
    Shared Function IsFileURI(ByVal path As String) As Boolean
        If String.Compare(path, 0, "file:", 0, 5, True) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    '</Snippet8>
End Class

'System.String.Compare(System.String,System.Int32,System.String,System.Int32,
'  System.Int32,System.StringComparison)
Public Class CompareSample4_2
    '<Snippet9>
    Shared Function IsFileURI(ByVal path As String) As Boolean
        If String.Compare(path, 0, "file:", 0, 5, StringComparison.OrdinalIgnoreCase) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    '</Snippet9>
End Class

'System.String.Compare(System.String,System.String)
Public Class CompareSample5_1
    '<Snippet10>
    Shared Function IsFileURI(ByVal path As String) As Boolean
        If String.Compare(path, 0, "file:", 0, 5, True) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    '</Snippet10>
End Class

'System.String.Compare(System.String,System.String)
Public Class CompareSample5_2
    '<Snippet11>
    Shared Function IsFileURI(ByVal path As String) As Boolean
        If String.Compare(path, 0, "file:", 0, 5, StringComparison.OrdinalIgnoreCase) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    '</Snippet11>
End Class

'System.String.Compare(System.String,System.String,System.Boolean)
Public Class CompareSample6_1
    '<Snippet12>
    Shared Function IsFileURI(ByVal path As String) As Boolean
        If String.Compare(path, 0, "file:", 0, 5, True) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    '</Snippet12>
End Class

'System.String.Compare(System.String,System.String,System.Boolean)
Public Class CompareSample6_2
    '<Snippet13>
    Shared Function IsFileURI(ByVal path As String) As Boolean
        If String.Compare(path, 0, "file:", 0, 5, StringComparison.OrdinalIgnoreCase) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    '</Snippet13>
End Class

'System.String.Compare(System.String,System.String,System.Boolean,System.Globalization.CultureInfo)
Public Class CompareSample7_1
    '<Snippet14>
    Shared Function IsFileURI(ByVal path As String) As Boolean
        If String.Compare(path, 0, "file:", 0, 5, True) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    '</Snippet14>
End Class

'System.String.Compare(System.String,System.String,System.Boolean,System.Globalization.CultureInfo)
Public Class CompareSample7_2
    '<Snippet15>
    Shared Function IsFileURI(ByVal path As String) As Boolean
        If String.Compare(path, 0, "file:", 0, 5, StringComparison.OrdinalIgnoreCase) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    '</Snippet15>
End Class

'System.String.Compare(System.String,System.String,System.StringComparison)
Public Class CompareSample8_1
    '<Snippet16>
    Shared Function IsFileURI(ByVal path As String) As Boolean
        If String.Compare(path, 0, "file:", 0, 5, True) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    '</Snippet16>
End Class

'System.String.Compare(System.String,System.String,System.StringComparison)
Public Class CompareSample8_2
    '<Snippet17>
    Shared Function IsFileURI(ByVal path As String) As Boolean
        If String.Compare(path, 0, "file:", 0, 5, StringComparison.OrdinalIgnoreCase) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    '</Snippet17>
End Class
