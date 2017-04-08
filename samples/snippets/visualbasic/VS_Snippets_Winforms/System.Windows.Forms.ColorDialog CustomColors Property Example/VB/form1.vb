Imports System
Imports System.IO
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data


Namespace WindowsApplication1
    _
   '/ <summary>
   '/ Summary description for Form1.
   '/ </summary>
   Public Class Form1
      Inherits System.Windows.Forms.Form
      Private WithEvents button1 As System.Windows.Forms.Button
      '/ <summary>
      '/ Required designer variable.
      '/ </summary>
      Private components As System.ComponentModel.Container = Nothing


      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()
      End Sub 'New

      '
      ' TODO: Add any constructor code after InitializeComponent call
      '

      '/ <summary>
      '/ Clean up any resources being used.
      '/ </summary>
      Protected Overloads Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            If (components IsNot Nothing) Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub 'Dispose


      Private Sub InitializeComponent()
         Me.button1 = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' button1
         ' 
         Me.button1.Location = New System.Drawing.Point(144, 72)
         Me.button1.Name = "button1"
         Me.button1.TabIndex = 0
         Me.button1.Text = "button1"
         ' 
         ' Form1
         ' 
         Me.ClientSize = New System.Drawing.Size(292, 273)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1})
         Me.Name = "Form1"
         Me.Text = "Form1"
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent

      Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
         '<snippet1>
         Dim MyDialog = New ColorDialog()
         ' Allows the user to select or edit a custom color.
         MyDialog.AllowFullOpen = True
         ' Assigns an array of custom colors to the CustomColors property.
         MyDialog.CustomColors = New Integer() {6916092, 15195440, 16107657, 1836924, _
            3758726, 12566463, 7526079, 7405793, 6945974, 241502, 2296476, 5130294, _
            3102017, 7324121, 14993507, 11730944}

         ' Allows the user to get help. (The default is false.)
         MyDialog.ShowHelp = True
         ' Sets the initial color select to the current text color,
         ' so that if the user cancels out, the original color is restored.
         MyDialog.Color = Me.BackColor
         MyDialog.ShowDialog()
         Me.BackColor = MyDialog.Color
         '</snippet1>
         ' Print the custom colors if the user has changed them.
         PrintCustomColors(MyDialog.CustomColors)
      End Sub 'button1_Click


      Private Sub PrintCustomColors(ByVal clrs() As Integer)
         Dim writer = New StreamWriter("colors.txt")
         If (True) Then
            Dim i As Integer
            For Each i In clrs
               writer.WriteLine(i)
            Next i
         End If
         writer.Close()
      End Sub 'PrintCustomColors

      '      private int[] AddCustomColors()
      '      {
      '         return new int[]{6916092, 
      '                            15195440,
      '                            16107657,
      '                            1836924,
      '                            3758726,
      '                            12566463,
      '                            7526079,
      '                            7405793,
      '                            6945974,
      '                            241502,
      '                            2296476,
      '                            5130294,
      '                            3102017,
      '                            7324121,
      '                            14993507,
      '                            11730944,
      '         };
      '      }
      <STAThread()> Shared _
      Sub Main()
         Application.Run(New Form1())
      End Sub 'Main
   End Class 'Form1 
End Namespace 'WindowsApplication1