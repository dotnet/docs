' <Snippet1>
Imports Windows.Globalization
Imports MyCompany.Employees

Public NotInheritable Class BlankPage
    Inherits Page

    Protected Overrides Sub OnNavigatedTo(e As Navigation.NavigationEventArgs)
        Example.Demo(outputBlock)
    End Sub
End Class

Public Class Example
    Public Shared Sub Demo(outputBlock As Windows.UI.Xaml.Controls.TextBlock)
        ' Set the application preferences.
        ApplicationLanguages.PrimaryLanguageOverride = "fr-FR"

        ' Get the data from some data source. 
        Dim employees = InitializeData()
        outputBlock.FontFamily = New FontFamily("Courier New")
        ' Display application title.
        Dim title As String = UILibrary.GetTitle()
        outputBlock.Text += title + vbCrLf + vbCrLf

        ' Retrieve resources.
        Dim fields() As String = UILibrary.GetFieldNames()
        Dim lengths() As Integer = UILibrary.GetFieldLengths()
        Dim fmtString As String = String.Empty
        ' Create format string for field headers and data.
        For ctr = 0 To fields.Length - 1
            fmtString += String.Format("{{{0},-{1}{2}{3}   ", ctr, lengths(ctr), If(ctr >= 2, ":d", ""), "}")
        Next
        ' Display the headers.
        outputBlock.Text += String.Format(fmtString, fields) + vbCrLf + vbCrLf

        ' Display the data.
        For Each e In employees
            outputBlock.Text += String.Format(fmtString, e.Item1, e.Item2, e.Item3, e.Item4) + vbCrLf
        Next
    End Sub

    Private Shared Function InitializeData() As List(Of Tuple(Of String, String, Date, Date))
        Dim employees As New List(Of Tuple(Of String, String, Date, Date))
        Dim t1 = Tuple.Create("John", "16302", #8/18/1954#, #9/8/2006#)
        employees.Add(t1)
        t1 = Tuple.Create("Alice", "19745", #5/10/1995#, #10/17/2012#)
        employees.Add(t1)
        Return employees
    End Function
End Class
' </Snippet1>
