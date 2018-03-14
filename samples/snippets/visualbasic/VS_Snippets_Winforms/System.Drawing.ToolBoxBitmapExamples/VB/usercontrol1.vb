Imports System.ComponentModel

Class Form1
    Inherits Form
    Private button1 As New System.Windows.Forms.Button()
    
    Public Sub New() 
        'InitializeComponent();
    End Sub 'New

    <STAThread()>  _
    Shared Sub Main() 
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    
    End Sub 'Main
    '<snippet4>
    Private Function GetImageOfCustomControl(ByVal userControl As Control) As Image 
        Dim controlImage As Image = Nothing
        Dim attrCol As AttributeCollection = TypeDescriptor.GetAttributes(userControl)
        Dim imageAttr As ToolboxBitmapAttribute = _
            CType(attrCol(GetType(ToolboxBitmapAttribute)), ToolboxBitmapAttribute)
        If (imageAttr IsNot Nothing) Then
            controlImage = imageAttr.GetImage(userControl)
        End If
        
        Return controlImage
    
    End Function
    '</snippet4>
   
End Class

' The following code example demonstrates how to use the 
' ToolBoxBitmapAttribute#ctor(string) costructor to set stop.bmp as the
' toolbox icon for the StopSignControl. This example assumes
' the existence of a 16-by-16-pixel bitmap named stop.bmp at c:\.
'<snippet1>
<System.Drawing.ToolboxBitmap("c:\stop.bmp")> _
Public Class StopSignControl
    Inherits System.Windows.Forms.UserControl

    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button

    Public Sub New()
        MyBase.New()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button

        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", _
            12.0F, System.Drawing.FontStyle.Regular, _
            System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(24, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Stop!"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(56, 88)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 32)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "stop"

        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "StopSignControl"

    End Sub

    Private Sub StopSignControl_MouseEnter(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles MyBase.MouseEnter

        Label1.Text.ToUpper()
        Label1.Font = New System.Drawing.Font(Label1.Font.FontFamily, _
            14.0F, System.Drawing.FontStyle.Bold)
        Button1.Enabled = True
    End Sub

    Private Sub StopSignControl_MouseLeave(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles MyBase.MouseLeave

        Label1.Text.ToLower()
        Label1.Font = New System.Drawing.Font(Label1.Font.FontFamily, 12.0F, _
             System.Drawing.FontStyle.Regular)
        Button1.Enabled = False
    End Sub

End Class
'</snippet1>

' The following code example demonstrates how to use the 
' ToolBoxBitmapAttribute#ctor(type, string) constructor to set StopSignControl2.bmp as a toolbox
' icon for the StopSignControl. This example assumes
' the existence of a 16-by-16-pixel bitmap named StopSignControl2.bmp with its 
' BuildAction property set to EmbeddedResource.
'<snippet2>
<System.Drawing.ToolboxBitmap(GetType(StopSignControl2), "StopSignControl2.bmp")> _
Public Class StopSignControl2
    Inherits System.Windows.Forms.UserControl

    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button

    Public Sub New()
        MyBase.New()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button

        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", _
            12.0F, System.Drawing.FontStyle.Regular, _
            System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(24, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Stop!"
        Me.Label1.TextAlign = _
            System.Drawing.ContentAlignment.MiddleCenter
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(56, 88)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 32)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "stop"
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "StopSignControl"

    End Sub

    Private Sub StopSignControl_MouseEnter(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles MyBase.MouseEnter
        Label1.Text.ToUpper()
        Label1.Font = New System.Drawing.Font(Label1.Font.FontFamily, 14.0F, _
             System.Drawing.FontStyle.Bold)
        Button1.Enabled = True
    End Sub

    Private Sub StopSignControl_MouseLeave(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles MyBase.MouseLeave

        Label1.Text.ToLower()
        Label1.Font = New System.Drawing.Font(Label1.Font.FontFamily, 12.0F, _
             System.Drawing.FontStyle.Regular)
        Button1.Enabled = False
    End Sub

End Class
'</snippet2>

' The following code example demonstrates how to use the 
' ToolBoxBitmapAttribute#ctor(type) constructor to set the icon of the System.Windows.Forms.Button control
' to the toolbox icon for a UserControl named StopSignControl3. 
'<snippet3>
<System.Drawing.ToolboxBitmap(GetType(System.Windows.Forms.Button))> _
Public Class StopSignControl3
    Inherits System.Windows.Forms.UserControl

    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button

    Public Sub New()
        MyBase.New()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button

        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", _
            12.0F, System.Drawing.FontStyle.Regular, _
            System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(24, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Stop!"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(56, 88)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 32)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "stop"
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "StopSignControl"

    End Sub

    Private Sub StopSignControl_MouseEnter(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles MyBase.MouseEnter
        Label1.Text.ToUpper()
        Label1.Font = New System.Drawing.Font(Label1.Font.FontFamily, 14.0F, _
            System.Drawing.FontStyle.Bold)
        Button1.Enabled = True
    End Sub

    Private Sub StopSignControl_MouseLeave(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles MyBase.MouseLeave
        Label1.Text.ToLower()
        Label1.Font = New System.Drawing.Font(Label1.Font.FontFamily, 12.0F, _
             System.Drawing.FontStyle.Regular)
        Button1.Enabled = False
    End Sub

End Class
'</snippet3>




