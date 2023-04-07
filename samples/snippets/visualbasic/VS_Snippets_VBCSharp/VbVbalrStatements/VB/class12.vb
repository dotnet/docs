' Imports Statement (.NET Namespace and Type)
' 7062f8aa-d890-4232-9eed-92836e13fb6e

'<Snippet153>
' Place Imports statements at the top of your program.
Imports System.Text
Imports System.IO
Imports Microsoft.VisualBasic.ControlChars
'</Snippet153>

'<Snippet155>
Imports systxt = System.Text
Imports sysio = System.IO
Imports ch = Microsoft.VisualBasic.ControlChars
'</Snippet155>

'<Snippet157>
Imports strbld = System.Text.StringBuilder
Imports dirinf = System.IO.DirectoryInfo
'</Snippet157>

Public Class Class12

    Class testClass1
        '<Snippet152>
        Public Function GetFolders() As String
            ' Create a new StringBuilder, which is used
            ' to efficiently build strings.
            Dim sb As New System.Text.StringBuilder

            Dim dInfo As New System.IO.DirectoryInfo("c:\")

            ' Obtain an array of directories, and iterate through
            ' the array.
            For Each dir As System.IO.DirectoryInfo In dInfo.GetDirectories()
                sb.Append(dir.Name)
                sb.Append(Microsoft.VisualBasic.ControlChars.CrLf)
            Next

            Return sb.ToString
        End Function
        '</Snippet152>
    End Class

    Class testClass2
        '<Snippet154>
        Public Function GetFolders() As String
            Dim sb As New StringBuilder

            Dim dInfo As New DirectoryInfo("c:\")
            For Each dir As DirectoryInfo In dInfo.GetDirectories()
                sb.Append(dir.Name)
                sb.Append(CrLf)
            Next

            Return sb.ToString
        End Function
        '</Snippet154>
    End Class

    Class testClass3
        '<Snippet156>
        Public Function GetFolders() As String
            Dim sb As New systxt.StringBuilder

            Dim dInfo As New sysio.DirectoryInfo("c:\")
            For Each dir As sysio.DirectoryInfo In dInfo.GetDirectories()
                sb.Append(dir.Name)
                sb.Append(ch.CrLf)
            Next

            Return sb.ToString
        End Function
        '</Snippet156>
    End Class

    Class testClass4
        '<Snippet158>
        Public Function GetFolders() As String
            Dim sb As New strbld

            Dim dInfo As New dirinf("c:\")
            For Each dir As dirinf In dInfo.GetDirectories()
                sb.Append(dir.Name)
                sb.Append(ControlChars.CrLf)
            Next

            Return sb.ToString
        End Function
        '</Snippet158>
    End Class

End Class

