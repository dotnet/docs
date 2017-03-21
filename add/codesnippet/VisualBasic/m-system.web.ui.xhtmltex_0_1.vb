    ' Create a class that inherits from XhtmlTextWriter.
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class CustomXhtmlTextWriter
        Inherits XhtmlTextWriter

        ' Create two constructors, following 
        ' the pattern for implementing a
        ' TextWriter constructor.
        Public Sub New(writer As TextWriter)
          MyClass.New(writer, DefaultTabString)
        End Sub 'New


        Public Sub New(writer As TextWriter, tabString As String)
          MyBase.New(writer, tabString)
        End Sub 'New