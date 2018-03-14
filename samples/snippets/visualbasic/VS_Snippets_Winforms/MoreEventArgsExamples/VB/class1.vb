Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.ComponentModel.Design.Serialization
Imports System.Drawing
Imports System.Drawing.Design

Class Class1
   
   'Entry point which delegates to C-style main Private Function
   Public Overloads Shared Sub Main()
      Main(System.Environment.GetCommandLineArgs())
   End Sub
   
   <STAThread()>  _
   Overloads Shared Sub Main(args() As String)
    End Sub
End Class

Public Class EventArgsCreators

    '<Snippet1>
    Public Function CreateResolveNameEventArgs(ByVal value As Object, ByVal name As String) As ResolveNameEventArgs
        Dim e As New ResolveNameEventArgs(name)
        ' The name to resolve                       e.Name       
        ' Stores an object matching the name        e.Value            
        Return e
    End Function

    '</Snippet1>
    '<Snippet2>
    Public Function CreatePaintValueEventArgs(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal value As Object, ByVal graphics As Graphics, ByVal bounds As Rectangle) As PaintValueEventArgs
        Dim e As New PaintValueEventArgs(context, value, graphics, bounds)
        ' The context of the paint value event         e.Context
        ' The object representing the value to paint   e.Value
        ' The graphics to use to paint                 e.Graphics
        ' The rectangle in which to paint              e.Bounds                       
        Return e
    End Function

    '</Snippet2>
    '<Snippet3>
    Public Function CreateToolboxComponentsCreatedEventArgs(ByVal components() As System.ComponentModel.IComponent) As ToolboxComponentsCreatedEventArgs
        Dim e As New ToolboxComponentsCreatedEventArgs(components)
        ' The components that were just created        e.Components            
        Return e
    End Function

    '</Snippet3>

    '<Snippet4>
    Public Function CreateToolboxComponentsCreatingEventArgs(ByVal host As System.ComponentModel.Design.IDesignerHost) As ToolboxComponentsCreatingEventArgs
        Dim e As New ToolboxComponentsCreatingEventArgs(host)
        ' The designer host of the document receiving the components        e.DesignerHost            
        Return e
    End Function
    '</Snippet4>

End Class