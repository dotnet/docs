

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Class Form1
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer = Nothing
    Private textbox1 As ToolStripTextBox

    Public Sub New()
        InitializeComponent()
        InitializeDropDownMonthCalendar()
        textbox1 = New ToolStripTextBox()
        textbox1.Width = 70
        toolStrip1.Items.Add(textbox1)
        InitializeDateTimePickerHost()

    End Sub

    Shared Sub Main()
        Application.Run(New Form1())

    End Sub

    Private Sub InitializeComponent()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripPanel1 = New System.Windows.Forms.ToolStripPanel()
        Me.SuspendLayout()
        ' 
        ' toolStrip1
        ' 
        Me.toolStrip1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.TabIndex = 1
        Me.toolStrip1.Text = "toolStrip1"
        Me.toolStrip1.Visible = True
        ' 
        ' ToolStripPanel1
        ' 
        Me.ToolStripPanel1.AutoSize = True
        Me.ToolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolStripPanel1.Location = New System.Drawing.Point(9, 9)
        Me.ToolStripPanel1.Name = "ToolStripPanel1"
        Me.ToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.ToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStripPanel1.Size = New System.Drawing.Size(274, 25)
        Me.ToolStripPanel1.TabIndex = 0
        Me.ToolStripPanel1.Text = "ToolStripPanelToolStripPanelTop"
        Me.ToolStripPanel1.Join(Me.toolStrip1)
        ' 
        ' Form1
        ' 
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(ToolStripPanel1)
        Me.Name = "Form1"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub


    ' <summary>
    ' Clean up any resources being used.
    ' </summary>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)

    End Sub

    Private toolStrip1 As System.Windows.Forms.ToolStrip
    Private ToolStripPanel1 As System.Windows.Forms.ToolStripPanel

    ' The following snippet demonstrates the ToolStripControlHost(Control)
    ' constructor, the ToolStripControlHost.Font, Width, DisplayStyle,
    ' Text properties.
    '<snippet1>
    Private dateTimePickerHost As ToolStripControlHost


    Private Sub InitializeDateTimePickerHost()

        ' Create a new ToolStripControlHost, passing in a control.
        dateTimePickerHost = New ToolStripControlHost(New DateTimePicker())

        ' Set the font on the ToolStripControlHost, this will affect the hosted control.
        dateTimePickerHost.Font = New Font("Arial", 7.0F, FontStyle.Italic)

        ' Set the Width property, this will also affect the hosted control.
        dateTimePickerHost.Width = 100
        dateTimePickerHost.DisplayStyle = ToolStripItemDisplayStyle.Text

        ' Setting the Text property requires a string that converts to a 
        ' DateTime type since that is what the hosted control requires.
        dateTimePickerHost.Text = "12/23/2005"

        ' Cast the Control property back to the original type to set a 
        ' type-specific property.
        CType(dateTimePickerHost.Control, DateTimePicker).Format = DateTimePickerFormat.Short

        ' Add the control host to the ToolStrip.
        toolStrip1.Items.Add(dateTimePickerHost)

    End Sub
    '</snippet1>

    ' The following example shows how to set the custom 
    ' ToolStripMonthCalendar control.
    '<snippet2>
    Dim WithEvents monthCalendar As ToolStripMonthCalendar

    Private Sub InitializeDropDownMonthCalendar()

        ' Declare the drop-down button and the drop-down.
        Dim dropDownButton2 As New ToolStripDropDownButton()

        ' Set the image to the MonthCalendar embedded bitmap
        ' image.
        dropDownButton2.Image = New Bitmap(GetType(MonthCalendar), "MonthCalendar.bmp")

        ' Add the button to the ToolStrip.
        toolStrip1.Items.Add(dropDownButton2)

        ' Construct a new drop-down.
        Dim dropDown As New ToolStripDropDown()

        ' Construct a new wrapped MonthCalendar control.
        monthCalendar = New ToolStripMonthCalendar()

        ' Set a date in boldface.
        monthCalendar.AddBoldedDate(DateTime.Today.AddDays(7))

        'Add the calendar to the drop-down.
        dropDown.Items.Add(monthCalendar)

        'Set the drop-down on the DropDownButton.
        dropDownButton2.DropDown = dropDown

    End Sub 'InitializeDropDownMonthCalendar


    Public Sub monthCalendar_DateChanged( _
    ByVal sender As Object, _
    ByVal e As DateRangeEventArgs) _
    Handles monthCalendar.DateChanged

        textbox1.Text = e.Start.ToShortDateString()

    End Sub
    '</snippet2>

End Class

' The following example shows how to wrap a control
' using ToolStripControlHost.
'<snippet13>
'Declare a class that inherits from ToolStripControlHost.

Public Class ToolStripMonthCalendar
    Inherits ToolStripControlHost
    
    '<snippet10>
    ' Call the base constructor passing in a MonthCalendar instance.
    Public Sub New() 
        MyBase.New(New MonthCalendar())
    
    End Sub
    '</snippet10>

    '<snippet11>
    Public ReadOnly Property MonthCalendarControl() As MonthCalendar 
        Get
            Return CType(Control, MonthCalendar)
        End Get
    End Property
    '</snippet11>

    '<snippet12>
    ' Expose the MonthCalendar.FirstDayOfWeek as a property.
    Public Property FirstDayOfWeek() As Day 
        Get
            Return MonthCalendarControl.FirstDayOfWeek
        End Get
        Set
            MonthCalendarControl.FirstDayOfWeek = value
        End Set
    End Property
     
    ' Expose the AddBoldedDate method.
    Public Sub AddBoldedDate(ByVal dateToBold As DateTime) 
        MonthCalendarControl.AddBoldedDate(dateToBold)
    
    End Sub
    '</snippet12>

    ' Subscribe and unsubscribe the control events you wish to expose.
    '<snippet16>
    '<snippet14>
    Protected Overrides Sub OnSubscribeControlEvents(ByVal c As Control) 

        ' Call the base so the base events are connected.
        MyBase.OnSubscribeControlEvents(c)
        
        ' Cast the control to a MonthCalendar control.
        Dim monthCalendarControl As MonthCalendar = _
            CType(c, MonthCalendar)

        ' Add the event.
        AddHandler monthCalendarControl.DateChanged, _
            AddressOf HandleDateChanged
    
    End Sub
    '</snippet14>

    '<snippet15>
    Protected Overrides Sub OnUnsubscribeControlEvents(ByVal c As Control)
        ' Call the base method so the basic events are unsubscribed.
        MyBase.OnUnsubscribeControlEvents(c)

        ' Cast the control to a MonthCalendar control.
        Dim monthCalendarControl As MonthCalendar = _
            CType(c, MonthCalendar)

        ' Remove the event.
        RemoveHandler monthCalendarControl.DateChanged, _
            AddressOf HandleDateChanged

    End Sub
    '</snippet15>
    '</snippet16>

    '<snippet17>
    ' Declare the DateChanged event.
    Public Event DateChanged As DateRangeEventHandler

    ' Raise the DateChanged event.
    Private Sub HandleDateChanged(ByVal sender As Object, _
        ByVal e As DateRangeEventArgs)

        RaiseEvent DateChanged(Me, e)
    End Sub
End Class
'</snippet17>
'</snippet13>
'

