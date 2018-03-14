'<Snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Namespace IDictionaryServiceControl

    ' This example control works with the IDictionaryServiceDesigner to demonstrate
    ' using the IDictionaryService for storing data provided by a designer, and
    ' accessing it from a control. The IDictionaryService provides a Site-specific 
    ' key-based dictionary. An IDictionaryServiceDesigner sets an ArrayList of strings 
    ' to the dictionary with a "DesignerData" key, and its contents are accessed and
    ' displayed once the Update box is clicked at design time.
    <DesignerAttribute(GetType(IDictionaryServiceDesigner), GetType(IDesigner))> _
     Public Class IDictionaryServiceControl
        Inherits System.Windows.Forms.UserControl
        Public al As ArrayList

        Public Sub New()
            ' Initializes the example control.
            al = New ArrayList()
            Me.Size = New Size(344, 88)
            Me.BackColor = Color.White
        End Sub 

        ' Draws the instructions and user interface, and any strings contained
        ' in a local ArrayList.
        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            If Me.DesignMode Then
                e.Graphics.DrawString("IDictionaryServiceDesigner Control", New Font(FontFamily.GenericMonospace, 9), New SolidBrush(Color.Blue), 5, 4)
                e.Graphics.DrawString("Click the Update box to update display strings", New Font(FontFamily.GenericMonospace, 8), New SolidBrush(Color.DarkGreen), 5, 17)
                e.Graphics.DrawString("from the IDictionaryService.", New Font(FontFamily.GenericMonospace, 8), New SolidBrush(Color.DarkGreen), 5, 29)

                e.Graphics.FillRectangle(New SolidBrush(Color.Beige), 270, 7, 60, 10)
                e.Graphics.DrawRectangle(New Pen(New SolidBrush(Color.Black), 1), 270, 7, 60, 10)
                e.Graphics.DrawString("Update", New Font(FontFamily.GenericMonospace, 7), New SolidBrush(Color.Black), 282, 7)

                Dim i As Integer
                For i = 0 To al.Count - 1
                    e.Graphics.DrawString(CStr(al(i)), New Font(FontFamily.GenericMonospace, 8), New SolidBrush(Color.Black), 5, 44 + i * 12)
                Next i
            End If
        End Sub

        ' On mouse down, this method attempts to access the IDictionaryService and 
        ' obtain an ArrayList with a key of "DesignerData" in the dictionary.
        ' If successful, this ArrayList is set to the local ArrayList.
        Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
'<Snippet2>
            ' Attempts to obtain the IDictionaryService using the Control.GetService method.
            Dim ds As IDictionaryService = CType(GetService(GetType(IDictionaryService)), IDictionaryService)
            ' If the service was obtained...
            If (ds IsNot Nothing) Then
                ' Attempts to retrieve a list with a key of "DesignerData".
                Dim list As ArrayList = CType(ds.GetValue("DesignerData"), ArrayList)
'</Snippet2>
                ' If the list exists, sets the list obtained by the 
                ' IDictionaryService to the local list.
                If (list IsNot Nothing) Then
                    Me.al = list
                End If
                Me.Refresh()
            End If
        End Sub 
    End Class 

    ' This designer uses the IDictionaryService to store an ArrayList of 
    ' information strings that the associated control can access and 
    ' display. The IDictionaryService creates a new dictionary for each Site.
    Public Class IDictionaryServiceDesigner
        Inherits System.Windows.Forms.Design.ControlDesigner

        Public Sub New()
        End Sub 

        ' On designer initialization, this method attempts to obtain 
        ' the IDictionaryService, and populates an ArrayList
        ' associated with a "DesignerData" key in the dictionary with 
        ' designer- and control-related information strings.
        Public Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)
            MyBase.Initialize(component)
            Dim ds As IDictionaryService = CType(component.Site.GetService(GetType(IDictionaryService)), IDictionaryService)
            If (ds IsNot Nothing) Then
                ' If the dictionary service does not contain a 
                ' DesignerData key, adds an ArrayList for that key.
                If ds.GetValue("DesignerData") Is Nothing Then
                    ds.SetValue("DesignerData", New ArrayList())
                    ds.SetValue("DesignerData", New ArrayList())
                End If

                ' Obtains the ArrayList with the "DesignerData" key 
                ' from the dictionary service.
                Dim al As ArrayList = CType(ds.GetValue("DesignerData"), ArrayList)
                If (al IsNot Nothing) Then
                    al.Clear()
                    ' Populates the array list with designer and 
                    ' control information strings.
                    al.Add(("Designer type: " + Me.GetType().Name))
                    al.Add(("Control type:  " + Me.Control.GetType().Name))
                    al.Add(("Control name:  " + Me.Control.Name))
                End If
            End If
        End Sub 

        ' Translates the point to client coordinates and passes the 
        ' messages to the control while over the click box.
        Protected Overrides Function GetHitTest(ByVal point As System.Drawing.Point) As Boolean
            Dim translated As Point = Me.Control.PointToClient(point)
            If translated.X > 269 And translated.X < 331 And translated.Y > 7 And translated.Y < 18 Then
                Return True
            Else
                Return MyBase.GetHitTest(point)
            End If
        End Function 
    End Class 

End Namespace 
'</Snippet1>