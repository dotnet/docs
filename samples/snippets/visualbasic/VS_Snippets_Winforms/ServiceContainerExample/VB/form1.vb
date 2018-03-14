'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms
Imports System.Data

'   This sample uses the ServiceContainer class, which implements 
'   the IServiceContainer interface.  It creates a service container 
'   and stores services of type Control in it.

'   When the application is run, it adds control services at two
'   times:  when button2 is clicked and when a radio button is
'   clicked.  It adds the controls to the container by calling each
'   of two overloaded versions of IServiceContainer.AddService().
'
'   Pressing button1 invokes the button1 handler, which is
'   button1_Click().  In turn, this invokes a method based on
'   whether or not button2 or a radio button has been selected.
'   If one of these two button types has been selected, then its
'   service has been added to the service container.  In this case,
'   button1_Click() gets the current service, which invokes the
'   method that was associated with this service when the service
'   was added to the container.  If a radio button is current, the
'   system updates the text of that radio button with the given text.
'   If button2 is current, the system calls CreateNewControl(), which
'   creates a new control with the given text.
'
'   Pressing button2 invokes the button2 handler, which adds a service
'   to the container by passing in a service creator callback.  This
'   enables this action to invoke the event handler that the developer
'   specifies.  In this case, the sample invokes CreateNewControl(),
'   which creates and maintains label controls, and displays them in
'   the same group box that the buttons are in.
'
'   Clicking a radio button has the effect of adding that radio button
'   to the service container.

Namespace ServiceContainerExample
   Public Class Form1
      Inherits System.Windows.Forms.Form
      Private WithEvents button1 As System.Windows.Forms.Button
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private WithEvents radioButton1 As System.Windows.Forms.RadioButton
      Private WithEvents radioButton2 As System.Windows.Forms.RadioButton
      Private WithEvents radioButton3 As System.Windows.Forms.RadioButton
      Private WithEvents radioButton4 As System.Windows.Forms.RadioButton

      Private components As System.ComponentModel.Container = Nothing
      Private WithEvents button2 As System.Windows.Forms.Button
      Private m_MyServiceContainer As ServiceContainer

      Private m_nLabelCount As Integer

      Public Sub New()
         m_MyServiceContainer = New ServiceContainer()
         InitializeComponent()
      End Sub 'New

      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            If (components IsNot Nothing) Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub 'Dispose


#Region "Component Designer generated code"
      ' text
      Private Sub InitializeComponent()
         Me.button1 = New System.Windows.Forms.Button()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me.button2 = New System.Windows.Forms.Button()
         Me.radioButton4 = New System.Windows.Forms.RadioButton()
         Me.radioButton3 = New System.Windows.Forms.RadioButton()
         Me.radioButton2 = New System.Windows.Forms.RadioButton()
         Me.radioButton1 = New System.Windows.Forms.RadioButton()
         Me.groupBox1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' button1
         ' 
         Me.button1.Location = New System.Drawing.Point(24, 16)
         Me.button1.Name = "button1"
         Me.button1.Size = New System.Drawing.Size(112, 32)
         Me.button1.TabIndex = 0
         Me.button1.Text = "button1"
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.AddRange(New System.Windows.Forms.Control() _
                 {Me.button2, Me.radioButton4, Me.radioButton3, Me.radioButton2, _
                 Me.radioButton1})
         Me.groupBox1.Location = New System.Drawing.Point(8, 56)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(272, 200)
         Me.groupBox1.TabIndex = 1
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "groupBox1"
         ' 
         ' button2
         ' 
         Me.button2.Location = New System.Drawing.Point(40, 152)
         Me.button2.Name = "button2"
         Me.button2.Size = New System.Drawing.Size(90, 26)
         Me.button2.TabIndex = 4
         Me.button2.Text = "button2"
         ' 
         ' radioButton4
         ' 
         Me.radioButton4.Location = New System.Drawing.Point(32, 112)
         Me.radioButton4.Name = "radioButton4"
         Me.radioButton4.TabIndex = 3
         Me.radioButton4.Text = "radioButton4"
         ' 
         ' radioButton3
         ' 
         Me.radioButton3.Location = New System.Drawing.Point(32, 80)
         Me.radioButton3.Name = "radioButton3"
         Me.radioButton3.TabIndex = 2
         Me.radioButton3.Text = "radioButton3"
         ' 
         ' radioButton2
         ' 
         Me.radioButton2.Location = New System.Drawing.Point(32, 48)
         Me.radioButton2.Name = "radioButton2"
         Me.radioButton2.TabIndex = 1
         Me.radioButton2.Text = "radioButton2"
         ' 
         ' radioButton1
         ' 
         Me.radioButton1.Location = New System.Drawing.Point(32, 16)
         Me.radioButton1.Name = "radioButton1"
         Me.radioButton1.TabIndex = 0
         Me.radioButton1.Text = "radioButton1"
         ' 
         ' Form1
         ' 
         Me.ClientSize = New System.Drawing.Size(292, 272)
         Me.Controls.AddRange(New System.Windows.Forms.Control() _
                                {Me.groupBox1, Me.button1})
         Me.Name = "Form1"
         Me.Text = "Form1"
         Me.groupBox1.ResumeLayout(False)
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent
#End Region

      Public Shared Sub Main()
            Application.Run(New Form1())
      End Sub 'Main

      Private Sub radioButton1_CheckedChanged(ByVal sender As Object, _
            ByVal e As System.EventArgs) Handles radioButton4.CheckedChanged, _
            radioButton3.CheckedChanged, radioButton2.CheckedChanged, _
            radioButton1.CheckedChanged
         ' The application never displays this control so a generic
         '  type of Control is fine 
         m_MyServiceContainer.RemoveService(GetType(Control))
'<Snippet2>
         m_MyServiceContainer.AddService(GetType(Control), sender)
'</Snippet2>
      End Sub 'radioButton1_CheckedChanged

      Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
                    Handles button1.Click
         ' Get the current control, if one is current.  Here it's either a
         '  push button or a radio control 
         Dim c As Control = CType(m_MyServiceContainer.GetService(GetType(Control)), Control)
         If (c IsNot Nothing) Then
            ' Update the text of whichever control is currently selected.
            c.Text = "Button1 clicked"
         End If
      End Sub 'button1_Click


      Private Sub button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
                    Handles button2.Click
         ' ServiceContainer will throw an excpetion if a duplicate service
         '  is added so remove it before we add 
'<Snippet4>
         m_MyServiceContainer.RemoveService(GetType(Control))
'</Snippet4>

         ' Whenever button2 is pressed, attach the callback method to the service
         '  and add the service to the container.  This causes any update to
         '  invoke CreateNewControl() when button1 is pressed 
'<Snippet3>
          m_MyServiceContainer.AddService(GetType(Control), New ServiceCreatorCallback( _
                    AddressOf CreateNewControl))
'</Snippet3>
     End Sub 'button2_Click

     '  If the application arrives at this method, it means that in button1_Click(),
     '   GetService() was passed the service that corresponds to button2.  This has
     '   the effect of invoking the service creator callback for button2, which is
     '   the method CreateNewControl(), and which was mapped in button2_Click(). 
      Private Function CreateNewControl(ByVal container As IServiceContainer, _
                    ByVal serviceType As Type) As Object
         Dim c As New Label()
         c.Size = radioButton1.Size
         Dim loc As Point = button2.Location

         loc.X = 160
         loc.Y = 20 + 25 * m_nLabelCount

         c.Location = loc
         groupBox1.Controls.Add(c)
         Return c
      End Function 'CreateNewControl
   End Class 'Form1
End Namespace 'ServiceContainerExample
'</Snippet1>
