' System.Windows.Forms.Control.BeginInvoke(Delegate, object[])
' System.Windows.Forms.Control.BeginInvoke(Delegate)

' The following program demonstrates the 'BeginInvoke(Delegate)' and BeginInvoke(Delegate, object[])
' methods of 'Control' class.
' A 'TextBox' and  two 'Button' controls are added to the form. When the first 'Button'
' is clicked a delegate is called asynchronously using 'BeginInvoke' method of 'Control'
' class and an array of objects is passed as an arguments to the delegator which adds
' 'Label' control to the form. When the second 'Button' control is
' clicked a delegate is called asynchronously using 'BeginInvoke' which will display
' a message in the 'TextBox'.

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Public Class MyForm
   Inherits Form
   Private components As System.ComponentModel.Container = Nothing
   Private myTextBox As TextBox
   Private myButton As Button
   Private invokeButton As Button
   
   Public Sub New()
      ' Required for Windows Form Designer support.
      InitializeComponent()
   End Sub 'New
   
   Protected Overrides Overloads Sub Dispose(disposing As Boolean)
      If disposing Then
         If (components IsNot Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub 'Dispose
   
   
   Private Sub InitializeComponent()
      ' Set 'myTextBox' properties.
      Me.myTextBox = New TextBox()
      myTextBox.Location = New Point(90, 16)
      myTextBox.Size = New Size(160, 25)
      ' Set 'myButton' properties.
      Me.myButton = New Button()
      myButton.Text = "Add Label"
      myButton.Location = New Point(45, 50)
      myButton.Size = New Size(70, 25)
      AddHandler myButton.Click, AddressOf Button_Click
      
      invokeButton = New Button()
      invokeButton.Text = "Invoke Delegate"
      invokeButton.Location = New Point(120, 50)
      invokeButton.Size = New Size(100, 25)
      AddHandler invokeButton.Click, AddressOf Invoke_Click
      
      Me.ClientSize = New System.Drawing.Size(292, 273)
      Me.Name = "MyForm"
      Me.Text = "Invoke example"
      
      Me.Controls.Add(myTextBox)
      Me.Controls.Add(myButton)
      Me.Controls.Add(invokeButton)
   End Sub 'InitializeComponent
   
   <STAThread()>  _
   Public Shared Sub Main()
      Application.Run(New MyForm())
   End Sub 'Main
   
' <Snippet1>
   Delegate Sub MyDelegate(myControl As Label, myArg2 As String)
   
   Private Sub Button_Click(sender As Object, e As EventArgs)
      Dim myArray(1) As Object
      
      myArray(0) = New Label()
      myArray(1) = "Enter a Value"
      myTextBox.BeginInvoke(New MyDelegate(AddressOf DelegateMethod), myArray)
   End Sub 'Button_Click
   
   Public Sub DelegateMethod(myControl As Label, myCaption As String)
      myControl.Location = New Point(16, 16)
      myControl.Size = New Size(80, 25)
      myControl.Text = myCaption
      Me.Controls.Add(myControl)
   End Sub 'DelegateMethod
   
' </Snippet1>
' <Snippet2>
   Delegate Sub InvokeDelegate()
   
   Private Sub Invoke_Click(sender As Object, e As EventArgs)
      myTextBox.BeginInvoke(New InvokeDelegate(AddressOf InvokeMethod))
   End Sub 'Invoke_Click
   
   Public Sub InvokeMethod()
      myTextBox.Text = "Executed the given delegate"
   End Sub 'InvokeMethod
' </Snippet2>
End Class 'MyForm 