'<Snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Globalization
Imports System.Resources
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

Namespace IResourceServiceExample

    ' Associates the ResourceTestControlDesigner with the 
    ' ResourceTestControl class.
    <Designer(GetType(ResourceTestControlDesigner))> _
    Public Class ResourceTestControl
        Inherits System.Windows.Forms.UserControl
        ' Initializes a string array used to store strings that this control displays.
        Public resource_strings() As String = {"Initial Default String #1", "Initial Default String #2"}

        Public Sub New()
            Me.BackColor = Color.White
            Me.Size = New Size(408, 160)
        End Sub

        ' Draws the strings contained in the string array.
        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            e.Graphics.DrawString("IResourceService Example Designer Control", New Font(FontFamily.GenericMonospace, 10), New SolidBrush(Color.Blue), 2, 2)
            e.Graphics.DrawString("String list:  (use shortcut menu in design mode)", New Font(FontFamily.GenericMonospace, 8), New SolidBrush(Color.Black), 2, 20)

            Dim i As Integer
            For i = 0 To resource_strings.Length - 1
                e.Graphics.DrawString(resource_strings(i), New Font(FontFamily.GenericMonospace, 8), New SolidBrush(Color.SeaGreen), 2, 38 + (i * 18))
            Next i
        End Sub
    End Class
    _

    ' This designer offers several menu commands for the 
    ' shortcut menu for the associated control.
    ' These commands can be used to reset the control's string 
    ' list, to generate a default resources file, or to load the string 
    ' list for the control from the default resources file.
    Public Class ResourceTestControlDesigner
        Inherits System.Windows.Forms.Design.ControlDesigner

        Public Sub New()
        End Sub 

        Public Overrides ReadOnly Property Verbs() As System.ComponentModel.Design.DesignerVerbCollection
            Get
                ' Creates a collection of designer verb menu commands 
                ' that link to event handlers in this designer.            
                Return New DesignerVerbCollection(New DesignerVerb() { _
                    New DesignerVerb("Load Strings From Default Resources File", AddressOf Me.LoadResources), _
                    New DesignerVerb("Create Default Resources File", AddressOf Me.CreateResources), _
                    New DesignerVerb("Clear ResourceTestControl String List", AddressOf Me.ClearStrings)})
            End Get
        End Property

        ' Sets the string list for the control to the strings 
        ' loaded from a resource file.
        Private Sub LoadResources(ByVal sender As Object, ByVal e As EventArgs)
            Dim rs As IResourceService = CType(Me.Component.Site.GetService(GetType(IResourceService)), IResourceService)
            If rs Is Nothing Then
                Throw New Exception("Could not obtain IResourceService.")
            End If
            Dim rr As IResourceReader = rs.GetResourceReader(CultureInfo.CurrentUICulture)
            If rr Is Nothing Then
                Throw New Exception("Resource file could not be obtained. You may need to create one first.")
            End If
            Dim de As IDictionaryEnumerator = rr.GetEnumerator()

            If Me.Control.GetType() Is GetType(ResourceTestControl) Then
                Dim rtc As ResourceTestControl = CType(Me.Control, ResourceTestControl)
                Dim s1, s2, s3 As String
                de.MoveNext()
                s1 = CStr(CType(de.Current, DictionaryEntry).Value)
                de.MoveNext()
                s2 = CStr(CType(de.Current, DictionaryEntry).Value)
                de.MoveNext()
                s3 = CStr(CType(de.Current, DictionaryEntry).Value)
                de.MoveNext()
                rtc.resource_strings = New String() {s1, s2, s3}
                Me.Control.Refresh()
            End If
        End Sub

        ' Creates a default resource file for the current 
        ' CultureInfo and adds 3 strings to it.
        Private Sub CreateResources(ByVal sender As Object, ByVal e As EventArgs)
            Dim rs As IResourceService = CType(Me.Component.Site.GetService(GetType(IResourceService)), IResourceService)
            If rs Is Nothing Then
                Throw New Exception("Could not obtain IResourceService.")
            End If
            Dim rw As IResourceWriter = rs.GetResourceWriter(CultureInfo.CurrentUICulture)
            rw.AddResource("string1", "Persisted resource string #1")
            rw.AddResource("string2", "Persisted resource string #2")
            rw.AddResource("string3", "Persisted resource string #3")
            rw.Generate()
            rw.Close()
        End Sub   

        ' Clears the string list of the associated ResourceTestControl.
        Private Sub ClearStrings(ByVal sender As Object, ByVal e As EventArgs)
            If Me.Control.GetType() Is GetType(ResourceTestControl) Then
                Dim rtc As ResourceTestControl = CType(Me.Control, ResourceTestControl)
                rtc.resource_strings = New String() {"Test String #1", "Test String #2"}
                Me.Control.Refresh()
            End If
        End Sub 
    End Class 
End Namespace 
'</Snippet1>