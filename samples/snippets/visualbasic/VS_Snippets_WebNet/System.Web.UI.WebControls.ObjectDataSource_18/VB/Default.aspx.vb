Imports System.Xml
Imports System.Runtime.Serialization
Imports System.IO


Partial Class _Default
    Inherits System.Web.UI.Page

    ' <Snippet2>
    Public Sub EmployeeUpdating(ByVal source As Object, ByVal e As ObjectDataSourceMethodEventArgs)
        Dim dcs As New DataContractSerializer(GetType(Employee))
        Dim xmlData As String
        Dim reader As XmlReader
        Dim originalEmployee As Employee

        xmlData = ViewState("OriginalEmployee").ToString()
        reader = XmlReader.Create(New StringReader(xmlData))
        originalEmployee = CType(dcs.ReadObject(reader), Employee)
        reader.Close()

        e.InputParameters.Add("originalEmployee", originalEmployee)
    End Sub

    Public Sub EmployeeSelected(ByVal source As Object, ByVal e As ObjectDataSourceStatusEventArgs)
        If e.ReturnValue IsNot Nothing Then
            Dim dcs As New DataContractSerializer(GetType(Employee))
            Dim sb As New StringBuilder()
            Dim writer As XmlWriter
            writer = XmlWriter.Create(sb)
            dcs.WriteObject(writer, e.ReturnValue)
            writer.Close()

            ViewState("OriginalEmployee") = sb.ToString()
        End If
    End Sub
    ' </Snippet2>
End Class
