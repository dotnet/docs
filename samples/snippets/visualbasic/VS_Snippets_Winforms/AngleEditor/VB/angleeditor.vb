'<Snippet1>
Option Strict Off
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Reflection
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

' This UITypeEditor can be associated with Int32, Double and Single
' properties to provide a design-mode angle selection interface.
<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Public Class AngleEditor
    Inherits System.Drawing.Design.UITypeEditor

    Public Sub New()
    End Sub

    ' Indicates whether the UITypeEditor provides a form-based (modal) dialog, 
    ' drop down dialog, or no UI outside of the properties window.
    Public Overloads Overrides Function GetEditStyle(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.Drawing.Design.UITypeEditorEditStyle
        Return UITypeEditorEditStyle.DropDown
    End Function

    ' Displays the UI for value selection.
    Public Overloads Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As System.IServiceProvider, ByVal value As Object) As Object
        ' Return the value if the value is not of type Int32, Double and Single.
        If value.GetType() IsNot GetType(Double) AndAlso value.GetType() IsNot GetType(Single) AndAlso value.GetType() IsNot GetType(Integer) Then
            Return value
        End If
        ' Uses the IWindowsFormsEditorService to display a 
        ' drop-down UI in the Properties window.
        Dim edSvc As IWindowsFormsEditorService = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)
        If (edSvc IsNot Nothing) Then
            ' Display an angle selection control and retrieve the value.
            Dim angleControl As New AngleControl(System.Convert.ToDouble(value))
            edSvc.DropDownControl(angleControl)

            ' Return the value in the appropraite data format.
            If value Is GetType(Double) Then
                Return angleControl.angle
            ElseIf value Is GetType(Single) Then
                Return System.Convert.ToSingle(angleControl.angle)
            ElseIf value Is GetType(Integer) Then
                Return System.Convert.ToInt32(angleControl.angle)
            End If
        End If
        Return value
    End Function

    ' Draws a representation of the property's value.
    Public Overloads Overrides Sub PaintValue(ByVal e As System.Drawing.Design.PaintValueEventArgs)
        Dim normalX As Integer = e.Bounds.Width / 2
        Dim normalY As Integer = e.Bounds.Height / 2

        ' Fill background and ellipse and center point.
        e.Graphics.FillRectangle(New SolidBrush(Color.DarkBlue), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
        e.Graphics.FillEllipse(New SolidBrush(Color.White), e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 3, e.Bounds.Height - 3)
        e.Graphics.FillEllipse(New SolidBrush(Color.SlateGray), normalX + e.Bounds.X - 1, normalY + e.Bounds.Y - 1, 3, 3)

        ' Draw line along the current angle.
        Dim radians As Double = System.Convert.ToDouble(e.Value) * Math.PI / System.Convert.ToDouble(180)
        e.Graphics.DrawLine(New Pen(New SolidBrush(Color.Red), 1), normalX + e.Bounds.X, normalY + e.Bounds.Y, e.Bounds.X + (normalX + System.Convert.ToInt32(System.Convert.ToDouble(normalX) * Math.Cos(radians))), e.Bounds.Y + (normalY + System.Convert.ToInt32(System.Convert.ToDouble(normalY) * Math.Sin(radians))))
    End Sub

    ' Indicates whether the UITypeEditor supports painting a 
    ' representation of a property's value.
    Public Overloads Overrides Function GetPaintValueSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function
End Class

' Provides a user interface for adjusting an angle value.
Friend Class AngleControl
    Inherits System.Windows.Forms.UserControl

    ' Stores the angle.
    Public angle As Double
    ' Stores the rotation offset.
    Private rotation As Integer = 0
    ' Control state tracking variables.
    Private dbx As Integer = -10
    Private dby As Integer = -10
    Private overButton As Integer = -1

    Public Sub New(ByVal initial_angle As Double)
        Me.angle = initial_angle
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        ' Set angle origin point at center of control.
        Dim originX As Integer = Me.Width / 2
        Dim originY As Integer = Me.Height / 2

        ' Fill background and ellipse and center point.
        e.Graphics.FillRectangle(New SolidBrush(Color.DarkBlue), 0, 0, Me.Width, Me.Height)
        e.Graphics.FillEllipse(New SolidBrush(Color.White), 1, 1, Me.Width - 3, Me.Height - 3)
        e.Graphics.FillEllipse(New SolidBrush(Color.SlateGray), originX - 1, originY - 1, 3, 3)

        ' Draw angle markers.
        Dim startangle As Integer = (270 - rotation) Mod 360
        e.Graphics.DrawString(startangle.ToString(), New Font("Arial", 8), New SolidBrush(Color.DarkGray), Me.Width / 2 - 10, 10)
        startangle = (startangle + 90) Mod 360
        e.Graphics.DrawString(startangle.ToString(), New Font("Arial", 8), New SolidBrush(Color.DarkGray), Me.Width - 18, Me.Height / 2 - 6)
        startangle = (startangle + 90) Mod 360
        e.Graphics.DrawString(startangle.ToString(), New Font("Arial", 8), New SolidBrush(Color.DarkGray), Me.Width / 2 - 6, Me.Height - 18)
        startangle = (startangle + 90) Mod 360
        e.Graphics.DrawString(startangle.ToString(), New Font("Arial", 8), New SolidBrush(Color.DarkGray), 10, Me.Height / 2 - 6)

        ' Draw line along the current angle.   
        Dim radians As Double = ((angle + rotation + 360) Mod 360) * Math.PI / System.Convert.ToDouble(180)
        e.Graphics.DrawLine(New Pen(New SolidBrush(Color.Red), 1), originX, originY, originX + System.Convert.ToInt32(System.Convert.ToDouble(originX) * Math.Cos(radians)), originY + System.Convert.ToInt32(System.Convert.ToDouble(originY) * Math.Sin(radians)))

        ' Output angle information.
        e.Graphics.FillRectangle(New SolidBrush(Color.Gray), Me.Width - 84, 3, 82, 13)
        e.Graphics.DrawString("Angle: " + angle.ToString("F4"), New Font("Arial", 8), New SolidBrush(Color.Yellow), Me.Width - 84, 2)
        ' Draw square at mouse position of last angle adjustment.
        e.Graphics.DrawRectangle(New Pen(New SolidBrush(Color.Black), 1), dbx - 2, dby - 2, 4, 4)
        ' Draw rotation adjustment buttons.
        If overButton = 1 Then
            e.Graphics.FillRectangle(New SolidBrush(Color.Green), Me.Width - 28, Me.Height - 14, 12, 12)
            e.Graphics.FillRectangle(New SolidBrush(Color.Gray), 2, Me.Height - 13, 110, 12)
            e.Graphics.DrawString("Rotate 90 degrees left", New Font("Arial", 8), New SolidBrush(Color.White), 2, Me.Height - 14)
        Else
            e.Graphics.FillRectangle(New SolidBrush(Color.DarkGreen), Me.Width - 28, Me.Height - 14, 12, 12)
        End If
        If overButton = 2 Then
            e.Graphics.FillRectangle(New SolidBrush(Color.Green), Me.Width - 14, Me.Height - 14, 12, 12)
            e.Graphics.FillRectangle(New SolidBrush(Color.Gray), 2, Me.Height - 13, 116, 12)
            e.Graphics.DrawString("Rotate 90 degrees right", New Font("Arial", 8), New SolidBrush(Color.White), 2, Me.Height - 14)
        Else
            e.Graphics.FillRectangle(New SolidBrush(Color.DarkGreen), Me.Width - 14, Me.Height - 14, 12, 12)
        End If
        e.Graphics.DrawEllipse(New Pen(New SolidBrush(Color.White), 1), Me.Width - 11, Me.Height - 11, 6, 6)
        e.Graphics.DrawEllipse(New Pen(New SolidBrush(Color.White), 1), Me.Width - 25, Me.Height - 11, 6, 6)
        If overButton = 1 Then
            e.Graphics.FillRectangle(New SolidBrush(Color.Green), Me.Width - 25, Me.Height - 6, 4, 4)
        Else
            e.Graphics.FillRectangle(New SolidBrush(Color.DarkGreen), Me.Width - 25, Me.Height - 6, 4, 4)
        End If
        If overButton = 2 Then
            e.Graphics.FillRectangle(New SolidBrush(Color.Green), Me.Width - 8, Me.Height - 6, 4, 4)
        Else
            e.Graphics.FillRectangle(New SolidBrush(Color.DarkGreen), Me.Width - 8, Me.Height - 6, 4, 4)
        End If
        e.Graphics.FillPolygon(New SolidBrush(Color.White), New Point() {New Point(Me.Width - 7, Me.Height - 8), New Point(Me.Width - 3, Me.Height - 8), New Point(Me.Width - 5, Me.Height - 4)})
        e.Graphics.FillPolygon(New SolidBrush(Color.White), New Point() {New Point(Me.Width - 26, Me.Height - 8), New Point(Me.Width - 21, Me.Height - 8), New Point(Me.Width - 25, Me.Height - 4)})
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        ' Handle rotation adjustment button clicks.
        If e.X >= Me.Width - 28 AndAlso e.X <= Me.Width - 2 AndAlso e.Y >= Me.Height - 14 AndAlso e.Y <= Me.Height - 2 Then
            If e.X <= Me.Width - 16 Then
                rotation -= 90
            ElseIf e.X >= Me.Width - 14 Then
                rotation += 90
            End If
            If rotation < 0 Then
                rotation += 360
            End If
            rotation = rotation Mod 360
            dbx = -10
            dby = -10
        Else
            UpdateAngle(e.X, e.Y)
        End If
        Me.Refresh()
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            UpdateAngle(e.X, e.Y)
            overButton = -1
        ElseIf e.X >= Me.Width - 28 AndAlso e.X <= Me.Width - 16 AndAlso e.Y >= Me.Height - 14 AndAlso e.Y <= Me.Height - 2 Then
            overButton = 1
        ElseIf e.X >= Me.Width - 14 AndAlso e.X <= Me.Width - 2 AndAlso e.Y >= Me.Height - 14 AndAlso e.Y <= Me.Height - 2 Then
            overButton = 2
        Else
            overButton = -1
        End If
        Me.Refresh()
    End Sub

    Private Sub UpdateAngle(ByVal mx As Integer, ByVal my As Integer)
        ' Store mouse coordinates.
        dbx = mx
        dby = my

        ' Translate y coordinate input to GetAngle function to correct for ellipsoid distortion.
        Dim widthToHeightRatio As Double = System.Convert.ToDouble(Me.Width) / System.Convert.ToDouble(Me.Height)
        Dim tmy As Integer
        If my = 0 Then
            tmy = my
        ElseIf my < Me.Height / 2 Then
            tmy = Me.Height / 2 - Fix((Me.Height / 2 - my) * widthToHeightRatio)
        Else
            tmy = Me.Height / 2 + Fix(System.Convert.ToDouble(my - Me.Height / 2) * widthToHeightRatio)
        End If
        ' Retrieve updated angle based on rise over run.
        angle = (GetAngle(Me.Width / 2, Me.Height / 2, mx, tmy) - rotation) Mod 360
    End Sub

    Private Function GetAngle(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer) As Double
        Dim degrees As Double

        ' Avoid divide by zero run values.
        If x2 - x1 = 0 Then
            If y2 > y1 Then
                degrees = 90
            Else
                degrees = 270
            End If
        Else
            ' Calculate angle from offset.
            Dim riseoverrun As Double = System.Convert.ToDouble(y2 - y1) / System.Convert.ToDouble(x2 - x1)
            Dim radians As Double = Math.Atan(riseoverrun)
            degrees = radians * (System.Convert.ToDouble(180) / Math.PI)

            ' Handle quadrant specific transformations.           
            If x2 - x1 < 0 OrElse y2 - y1 < 0 Then
                degrees += 180
            End If
            If x2 - x1 > 0 AndAlso y2 - y1 < 0 Then
                degrees -= 180
            End If
            If degrees < 0 Then
                degrees += 360
            End If
        End If
        Return degrees
    End Function
End Class

Public Class AngleEditorTestControl
    Inherits System.Windows.Forms.UserControl
    Private int_angle As Double

    <BrowsableAttribute(True), EditorAttribute(GetType(AngleEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property Angle() As Double
        Get
            Return int_angle
        End Get
        Set(ByVal Value As Double)
            int_angle = Value
        End Set
    End Property

    Public Sub New()
        int_angle = 90
        Me.Size = New Size(190, 42)
        Me.BackColor = Color.Beige
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        If Me.DesignMode Then
            e.Graphics.DrawString("Use the Properties Window to access", New Font("Arial", 8), New SolidBrush(Color.Black), 3, 2)
            e.Graphics.DrawString("the AngleEditor UITypeEditor by", New Font("Arial", 8), New SolidBrush(Color.Black), 3, 14)
            e.Graphics.DrawString("configuring the ""Angle"" property.", New Font("Arial", 8), New SolidBrush(Color.Black), 3, 26)
        Else
            e.Graphics.DrawString("This example requires design mode.", New Font("Arial", 8), New SolidBrush(Color.Black), 3, 2)
        End If
    End Sub
End Class
'</Snippet1>
