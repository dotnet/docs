
'<snippet1>
Imports Windows.UI.Xaml.Navigation
Imports System.Reflection
Imports System.Globalization
Imports System.Text
Imports System

Public NotInheritable Class MainPage
    Inherits Page

    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        Dim t As TypeInfo = GetType(Calendar).GetTypeInfo()
        Dim pList As IEnumerable(Of PropertyInfo) = t.DeclaredProperties
        Dim mList As IEnumerable(Of MethodInfo) = t.DeclaredMethods

        Dim sb As New StringBuilder()

        sb.Append("Properties:")
        For Each p As PropertyInfo In pList

            sb.Append((vbLf + p.DeclaringType.Name & ": ") + p.Name)
        Next
        sb.Append(vbLf & "Methods:")
        For Each m As MethodInfo In mList
            sb.Append((vbLf + m.DeclaringType.Name & ": ") + m.Name)
        Next

        textblock1.Text = sb.ToString()

    End Sub
End Class
'</snippet1>
