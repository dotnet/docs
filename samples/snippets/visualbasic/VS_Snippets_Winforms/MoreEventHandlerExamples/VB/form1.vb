Imports System
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.ComponentModel.Design.Serialization
Imports System.Windows.Forms
Imports System.Data

Friend Class Form1
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.Container = Nothing

    Public Sub New()
        InitializeComponent()
    End Sub

    '<Snippet1>
    Public Sub LinkResolveNameEvent(ByVal serializationManager As IDesignerSerializationManager)
        ' Registers an event handler for the resolve name event.
        AddHandler serializationManager.ResolveName, AddressOf Me.OnResolveName
    End Sub

    Private Sub OnResolveName(ByVal sender As Object, ByVal e As ResolveNameEventArgs)
        ' Displays ResolveName event information on the Console.
        Console.WriteLine(("Name of the name to resolve: " + e.Name))
        Console.WriteLine(("ToString output of the object that no name was resolved for: " + e.Value.ToString()))
    End Sub
    '</Snippet1>

    '<Snippet2>
    Public Sub LinkToolboxComponentsCreatedEvent(ByVal item As ToolboxItem)
        AddHandler item.ComponentsCreated, AddressOf Me.OnComponentsCreated
    End Sub

    Private Sub OnComponentsCreated(ByVal sender As Object, ByVal e As ToolboxComponentsCreatedEventArgs)
        ' Lists created components on the Console.
        Dim i As Integer
        For i = 0 To e.Components.Length - 1
            Console.WriteLine(("Component #" + i.ToString() + ": " + e.Components(i).Site.Name.ToString()))
        Next i
    End Sub
    '</Snippet2>

    '<Snippet3>
    Public Sub LinkToolboxComponentsCreatingEvent(ByVal item As ToolboxItem)
        AddHandler item.ComponentsCreating, AddressOf Me.OnComponentsCreating
    End Sub

    Private Sub OnComponentsCreating(ByVal sender As Object, ByVal e As ToolboxComponentsCreatingEventArgs)
        ' Displays ComponentsCreating event information on the Console.
        Console.WriteLine(("Name of the class of the root component of the designer host receiving new components: " + e.DesignerHost.RootComponentClassName))
    End Sub
    '</Snippet3>

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Size = New System.Drawing.Size(300, 300)
        Me.Text = "Form1"
    End Sub

    <STAThread()> _
    Shared Sub Main()
        Application.Run(New Form1())
    End Sub

End Class