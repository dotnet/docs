' <snippet1>
Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

' <snippet10>
' This class implements a ToolStripItem that highlights
' its border and text when the mouse enters its
' client rectangle. It has a clickable state which is
' exposed through the Clicked property and displayed
' by highlighting or graying out the item's image. 
Public Class RolloverItem
    Inherits ToolStripItem

   Private clickedValue As Boolean = False
   Private rolloverValue As Boolean = False
   
   Private imageRect As Rectangle
   Private textRect As Rectangle
   
   ' For brevity, this implementation limits the possible 
   ' TextDirection values to ToolStripTextDirection.Horizontal. 
   Public Overrides Property TextDirection() As ToolStripTextDirection
      Get
         Return MyBase.TextDirection
      End Get
      Set
         If value = ToolStripTextDirection.Horizontal Then
            MyBase.TextDirection = value
         Else
                Throw New ArgumentException( _
                "RolloverItem supports only horizontal text.")
         End If
      End Set
   End Property
   
   ' For brevity, this implementation limits the possible 
   ' TextImageRelation values to ImageBeforeText and TextBeforeImage. 
   Public Shadows Property TextImageRelation() As TextImageRelation
      Get
         Return MyBase.TextImageRelation
      End Get
      
      Set
            If Value = TextImageRelation.ImageBeforeText OrElse _
               Value = TextImageRelation.TextBeforeImage Then
                MyBase.TextImageRelation = Value
            Else
                Throw New ArgumentException("Unsupported TextImageRelation value.")
            End If
      End Set
   End Property
   
   ' This property returns true if the mouse is 
   ' inside the client rectangle.
   Public ReadOnly Property Rollover() As Boolean
      Get
         Return Me.rolloverValue
      End Get
    End Property

   ' This property returns true if the item 
   ' has been toggled into the clicked state.
   ' Clicking again toggles it to the 
   ' unclicked state.
   Public ReadOnly Property Clicked() As Boolean
      Get
         Return Me.clickedValue
      End Get
   End Property
   
   ' <snippet11>
   ' The method defines the behavior of the Click event.
   ' It simply toggles the state of the clickedValue field.
   Protected Overrides Sub OnClick(e As EventArgs)
      MyBase.OnClick(e)
      
        Me.clickedValue = Me.clickedValue Xor True
    End Sub
    ' </snippet11>

   ' <snippet14>
   ' The method defines the behavior of the DoubleClick 
   ' event. It shows a MessageBox with the item's text.
   Protected Overrides Sub OnDoubleClick(e As EventArgs)
      MyBase.OnDoubleClick(e)
      
      Dim msg As String = String.Format("Item: {0}", Me.Text)
      
      MessageBox.Show(msg)
    End Sub
    ' </snippet14>

   ' <snippet15>
   ' This method defines the behavior of the MouseEnter event.
   ' It sets the state of the rolloverValue field to true and
   ' tells the control to repaint.
   Protected Overrides Sub OnMouseEnter(e As EventArgs)
      MyBase.OnMouseEnter(e)
      
      Me.rolloverValue = True
      
      Me.Invalidate()
    End Sub
    ' </snippet15>
   
   ' <snippet16>
   ' This method defines the behavior of the MouseLeave event.
   ' It sets the state of the rolloverValue field to false and
   ' tells the control to repaint.
   Protected Overrides Sub OnMouseLeave(e As EventArgs)
      MyBase.OnMouseLeave(e)
      
      Me.rolloverValue = False
      
      Me.Invalidate()
    End Sub
    ' </snippet16>
   
   ' <snippet12>
   ' This method defines the painting behavior of the control.
   ' It performs the following operations:
   '
   ' Computes the layout of the item's image and text.
   ' Draws the item's background image.
   ' Draws the item's image.
   ' Draws the item's text.
   '
   ' Drawing operations are implemented in the 
   ' RolloverItemRenderer class.
   Protected Overrides Sub OnPaint(e As PaintEventArgs)
      MyBase.OnPaint(e)
      
      If (Me.Owner IsNot Nothing) Then
         ' Find the dimensions of the image and the text 
         ' areas of the item. 
         Me.ComputeImageAndTextLayout()
         
         ' Draw the background. This includes drawing a highlighted 
         ' border when the mouse is in the client area.
         Dim ea As New ToolStripItemRenderEventArgs(e.Graphics, Me)
         Me.Owner.Renderer.DrawItemBackground(ea)
         
         ' Draw the item's image. 
         Dim irea As New ToolStripItemImageRenderEventArgs(e.Graphics, Me, imageRect)
         Me.Owner.Renderer.DrawItemImage(irea)
         
         ' If the item is on a drop-down, give its
         ' text a different highlighted color.
            Dim highlightColor As Color = CType(IIf(Me.IsOnDropDown, Color.Salmon, SystemColors.ControlLightLight), Color)
         
         ' Draw the text, and highlight it if the 
         ' the rollover state is true.
            Dim rea As New ToolStripItemTextRenderEventArgs( _
               e.Graphics, _
               Me, _
               MyBase.Text, _
               textRect, _
               CType(IIf(Me.rolloverValue, highlightColor, MyBase.ForeColor), Color), _
               MyBase.Font, _
               MyBase.TextAlign)
         Me.Owner.Renderer.DrawItemText(rea)
      End If
    End Sub
    ' </snippet12>

   ' <snippet13>
   ' This utility method computes the layout of the 
   ' RolloverItem control's image area and the text area.
   ' For brevity, only the following settings are 
   ' supported:
   '
   ' ToolStripTextDirection.Horizontal
   ' TextImageRelation.ImageBeforeText 
   ' TextImageRelation.ImageBeforeText
   ' 
   ' It would not be difficult to support vertical text
   ' directions and other image/text relationships.
   Private Sub ComputeImageAndTextLayout()
      Dim cr As Rectangle = MyBase.ContentRectangle
      Dim img As Image = MyBase.Owner.ImageList.Images(MyBase.ImageKey)
      
      ' Compute the center of the item's ContentRectangle.
        Dim centerY As Integer = CInt((cr.Height - img.Height) / 2)
      
      ' Find the dimensions of the image and the text 
      ' areas of the item. The text occupies the space 
      ' not filled by the image. 
        If MyBase.TextImageRelation = _
        TextImageRelation.ImageBeforeText AndAlso _
        MyBase.TextDirection = ToolStripTextDirection.Horizontal Then

            imageRect = New Rectangle( _
            MyBase.ContentRectangle.Left, _
            centerY, _
            MyBase.Image.Width, _
            MyBase.Image.Height)

            textRect = New Rectangle( _
            imageRect.Width, _
            MyBase.ContentRectangle.Top, _
            MyBase.ContentRectangle.Width - imageRect.Width, _
            MyBase.ContentRectangle.Height)

        ElseIf MyBase.TextImageRelation = _
        TextImageRelation.TextBeforeImage AndAlso _
        MyBase.TextDirection = ToolStripTextDirection.Horizontal Then

            imageRect = New Rectangle( _
            MyBase.ContentRectangle.Right - MyBase.Image.Width, _
            centerY, _
            MyBase.Image.Width, _
            MyBase.Image.Height)

            textRect = New Rectangle( _
            MyBase.ContentRectangle.Left, _
            MyBase.ContentRectangle.Top, _
            imageRect.X, _
            MyBase.ContentRectangle.Bottom)

        End If
    End Sub
End Class
' </snippet13>
' </snippet10>

' <snippet20>
' This is the custom renderer for the RolloverItem control.
' It draws a border around the item when the mouse is
' in the item's client area. It also draws the item's image
' in an inactive state (grayed out) until the user clicks
' the item to toggle its "clicked" state.
Friend Class RolloverItemRenderer
    Inherits ToolStripSystemRenderer

    ' <snippet21>
    Protected Overrides Sub OnRenderItemImage(ByVal e As ToolStripItemImageRenderEventArgs)
        MyBase.OnRenderItemImage(e)

        Dim item As RolloverItem = CType(e.Item, RolloverItem)

        ' If the ToolSTripItem is of type RolloverItem, 
        ' perform custom rendering for the image.
        If (item IsNot Nothing) Then
            If item.Clicked Then
                ' The item is in the clicked state, so 
                ' draw the image as usual.
                e.Graphics.DrawImage(e.Image, e.ImageRectangle.X, e.ImageRectangle.Y)
            Else
                ' In the unclicked state, gray out the image.
                ControlPaint.DrawImageDisabled(e.Graphics, e.Image, e.ImageRectangle.X, e.ImageRectangle.Y, item.BackColor)
            End If
        End If
    End Sub
    ' </snippet21>

    ' <snippet22>
    ' This method defines the behavior for rendering the
    ' background of a ToolStripItem. If the item is a
    ' RolloverItem, it paints the item's BackgroundImage 
    ' centered in the client area. If the mouse is in the 
    ' item's client area, a border is drawn around it.
    ' If the item is on a drop-down or if it is on the
    ' overflow, a gradient is painted in the background.
    Protected Overrides Sub OnRenderItemBackground(ByVal e As ToolStripItemRenderEventArgs)
        MyBase.OnRenderItemBackground(e)

        Dim item As RolloverItem = CType(e.Item, RolloverItem)

        ' If the ToolSTripItem is of type RolloverItem, 
        ' perform custom rendering for the background.
        If (item IsNot Nothing) Then
            If item.Placement = ToolStripItemPlacement.Overflow OrElse item.IsOnDropDown Then
                Dim b As New LinearGradientBrush(item.ContentRectangle, Color.Salmon, Color.DarkRed, 0.0F, False)
                Try
                    e.Graphics.FillRectangle(b, item.ContentRectangle)
                Finally
                    b.Dispose()
                End Try
            End If

            ' The RolloverItem control only supports 
            ' the ImageLayout.Center setting for the
            ' BackgroundImage property.
            If item.BackgroundImageLayout = ImageLayout.Center Then
                ' Get references to the item's ContentRectangle
                ' and BackgroundImage, for convenience.
                Dim cr As Rectangle = item.ContentRectangle
                Dim bgi As Image = item.BackgroundImage

                ' Compute the center of the item's ContentRectangle.
                Dim centerX As Integer = CInt((cr.Width - bgi.Width) / 2)
                Dim centerY As Integer = CInt((cr.Height - bgi.Height) / 2)

                ' If the item is selected, draw the background
                ' image as usual. Otherwise, draw it as disabled.
                If item.Selected Then
                    e.Graphics.DrawImage(bgi, centerX, centerY)
                Else
                    ControlPaint.DrawImageDisabled(e.Graphics, bgi, centerX, centerY, item.BackColor)
                End If
            End If

            ' If the item is in the rollover state, 
            ' draw a border around it.
            If item.Rollover Then
                ControlPaint.DrawFocusRectangle(e.Graphics, item.ContentRectangle)
            End If
        End If
    End Sub
    ' </snippet22>

End Class
' </snippet20>

' This form tests various features of the RolloverItem
' control. RolloverItem conrols are created and added
' to the form's ToolStrip. They are also created and 
' added to a button's ContextMenuStrip. The behavior
' of the RolloverItem control differs depending on 
' the type of parent control.

Public Class RolloverItemTestForm
   Inherits Form
   Private toolStrip1 As System.Windows.Forms.ToolStrip
   Private WithEvents button1 As System.Windows.Forms.Button
   
   Private infoIconKey As String = "Information icon"
   Private handIconKey As String = "Hand icon"
   Private exclIconKey As String = "Exclamation icon"
   Private questionIconKey As String = "Question icon"
   Private warningIconKey As String = "Warning icon "
   
   Private components As System.ComponentModel.IContainer = Nothing
   
   
   Public Sub New()
      InitializeComponent()
      
      ' Set up the form's ToolStrip control.
      InitializeToolStrip()
      
      ' Set up the ContextMenuStrip for the button.
      InitializeContextMenu()
    End Sub
   
   
   ' This utility method initializes the ToolStrip control's 
   ' image list. For convenience, icons from the SystemIcons 
   ' class are used for this demonstration, but any images
   ' could be used.
   Private Sub InitializeImageList(ts As ToolStrip)
      If ts.ImageList Is Nothing Then
         ts.ImageList = New ImageList()
         ts.ImageList.ImageSize = SystemIcons.Exclamation.Size
         
         ts.ImageList.Images.Add(Me.infoIconKey, SystemIcons.Information)
         
         ts.ImageList.Images.Add(Me.handIconKey, SystemIcons.Hand)
         
         ts.ImageList.Images.Add(Me.exclIconKey, SystemIcons.Exclamation)
         
         ts.ImageList.Images.Add(Me.questionIconKey, SystemIcons.Question)
         
         ts.ImageList.Images.Add(Me.warningIconKey, SystemIcons.Warning)
      End If
    End Sub
   
   
   Private Sub InitializeToolStrip()
      Me.InitializeImageList(Me.toolStrip1)
      
      Me.toolStrip1.Renderer = New RolloverItemRenderer()
      
      Dim item As RolloverItem = Me.CreateRolloverItem(Me.toolStrip1, "RolloverItem on ToolStrip", Me.Font, infoIconKey, TextImageRelation.ImageBeforeText, exclIconKey)
      
      Me.toolStrip1.Items.Add(item)
      
      item = Me.CreateRolloverItem(Me.toolStrip1, "RolloverItem on ToolStrip", Me.Font, infoIconKey, TextImageRelation.ImageBeforeText, exclIconKey)
      
      Me.toolStrip1.Items.Add(item)
    End Sub
   
   
   Private Sub InitializeContextMenu()
        Dim f As New System.Drawing.Font("Arial", 18.0F, FontStyle.Bold)
      
      Dim cms As New ContextMenuStrip()
      Me.InitializeImageList(cms)
      
      cms.Renderer = New RolloverItemRenderer()
      cms.AutoSize = True
      cms.ShowCheckMargin = False
      cms.ShowImageMargin = False
      
        Dim item As RolloverItem = Me.CreateRolloverItem( _
        cms, _
        "RolloverItem on ContextMenuStrip", _
        f, _
        handIconKey, _
        TextImageRelation.ImageBeforeText, _
        exclIconKey)
      
      cms.Items.Add(item)
      
        item = Me.CreateRolloverItem( _
        cms, _
        "Another RolloverItem on ContextMenuStrip", _
        f, _
        questionIconKey, _
        TextImageRelation.ImageBeforeText, _
        exclIconKey)
      
      cms.Items.Add(item)
      
        item = Me.CreateRolloverItem( _
        cms, _
        "And another RolloverItem on ContextMenuStrip", _
        CType(f, Drawing.Font), _
        warningIconKey, _
        TextImageRelation.ImageBeforeText, _
        exclIconKey)
      
      cms.Items.Add(item)
      
      AddHandler cms.Closing, AddressOf cms_Closing
      
      Me.button1.ContextMenuStrip = cms
    End Sub
   
   
   ' This method handles the ContextMenuStrip 
   ' control's Closing event. It prevents the 
   ' RolloverItem from closing the drop-down  
   ' when the item is clicked.
   Private Sub cms_Closing(sender As Object, e As ToolStripDropDownClosingEventArgs)
      If e.CloseReason = ToolStripDropDownCloseReason.ItemClicked Then
         e.Cancel = True
      End If
    End Sub
   
   
   ' <snippet3>
   ' This method handles the Click event for the button.
   ' it selects the first item in the ToolStrip control
   ' by using the ToolStripITem.Select method.
   Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        Dim item As RolloverItem = CType(Me.toolStrip1.Items(0), RolloverItem)
      
      If (item IsNot Nothing) Then
         item.Select()
         
         Me.Invalidate()
      End If
    End Sub
    ' </snippet3>

   ' <snippet2>
   ' This utility method creates a RolloverItem 
   ' and adds it to a ToolStrip control.
    Private Function CreateRolloverItem( _
    ByVal owningToolStrip As ToolStrip, _
    ByVal txt As String, _
    ByVal f As Font, _
    ByVal imgKey As String, _
    ByVal tir As TextImageRelation, _
    ByVal backImgKey As String) As RolloverItem

        Dim item As New RolloverItem()

        item.Alignment = ToolStripItemAlignment.Left
        item.AllowDrop = False
        item.AutoSize = True

        item.BackgroundImage = owningToolStrip.ImageList.Images(backImgKey)
        item.BackgroundImageLayout = ImageLayout.Center
        item.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
        item.DoubleClickEnabled = True
        item.Enabled = True
        item.Font = f

        ' These assignments are equivalent. Each assigns an
        ' image from the owning toolstrip's image list.
        item.ImageKey = imgKey
        'item.Image = owningToolStrip.ImageList.Images[infoIconKey];
        'item.ImageIndex = owningToolStrip.ImageList.Images.IndexOfKey(infoIconKey);
        item.ImageScaling = ToolStripItemImageScaling.None

        item.Owner = owningToolStrip
        item.Padding = New Padding(2)
        item.Text = txt
        item.TextAlign = ContentAlignment.MiddleLeft
        item.TextDirection = ToolStripTextDirection.Horizontal
        item.TextImageRelation = tir

        Return item
    End Function
    ' </snippet2>

   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
    End Sub
   
   #Region "Windows Form Designer generated code"
   
   Private Sub InitializeComponent()
      Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
      Me.button1 = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      ' 
      ' toolStrip1
      ' 
      Me.toolStrip1.AllowItemReorder = True
      Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
      Me.toolStrip1.Name = "toolStrip1"
      Me.toolStrip1.Size = New System.Drawing.Size(845, 25)
      Me.toolStrip1.TabIndex = 0
      Me.toolStrip1.Text = "toolStrip1"
      ' 
      ' button1
      ' 
      Me.button1.Location = New System.Drawing.Point(12, 100)
      Me.button1.Name = "button1"
      Me.button1.Size = New System.Drawing.Size(86, 23)
      Me.button1.TabIndex = 1
      Me.button1.Text = "Click to select"
      Me.button1.UseVisualStyleBackColor = True
      ' 
      ' RolloverItemTestForm
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 14F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.AutoSize = True
      Me.ClientSize = New System.Drawing.Size(845, 282)
      Me.Controls.Add(button1)
      Me.Controls.Add(toolStrip1)
        Me.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
      Me.Name = "RolloverItemTestForm"
      Me.Text = "Form1"
      Me.ResumeLayout(False)
      Me.PerformLayout()
    End Sub
   
#End Region

End Class


Public Class Program

    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New RolloverItemTestForm())
    End Sub
End Class
' </snippet1>