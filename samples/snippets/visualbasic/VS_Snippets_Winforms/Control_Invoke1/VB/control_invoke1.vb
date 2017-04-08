' System.Windows.Forms.Control.Invoke(Delegate,Object[]);

' The following example demonstrates the 'Invoke(Delegate,Object[])'
' method of 'Control' class.
' A 'ListBox' and a 'Button' control are added to a form, containing a delegate
' which encapsulates a method that adds items to the listbox.This function is executed
' on the thread that owns the underlying handle of the form .When user clicks on button
' the above delegate is executed using 'Invoke' method.
' <Snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Threading

Public Class MyFormControl
   Inherits Form

   Delegate Sub AddListItem(myString As String)
   Public myDelegate As AddListItem
   Private myButton As Button
   Private myThread As Thread
   Private myListBox As ListBox

   Public Sub New()
      myButton = New Button()
      myListBox = New ListBox()
      myButton.Location = New Point(72, 160)
      myButton.Size = New Size(152, 32)
      myButton.TabIndex = 1
      myButton.Text = "Add items in list box"
      AddHandler myButton.Click, AddressOf Button_Click
      myListBox.Location = New Point(48, 32)
      myListBox.Name = "myListBox"
      myListBox.Size = New Size(200, 95)
      myListBox.TabIndex = 2
      ClientSize = New Size(292, 273)
      Controls.AddRange(New Control() {myListBox, myButton})
      Text = " 'Control_Invoke' example "
      myDelegate = New AddListItem(AddressOf AddListItemMethod)
   End Sub 'New

   Shared Sub Main()
      Dim myForm As New MyFormControl()
      myForm.ShowDialog()
   End Sub 'Main

   Public Sub AddListItemMethod(myString As String)
      myListBox.Items.Add(myString)
   End Sub 'AddListItemMethod

   Private Sub Button_Click(sender As Object, e As EventArgs)
      myThread = New Thread(New ThreadStart(AddressOf ThreadFunction))
      myThread.Start()
   End Sub 'Button_Click

   Private Sub ThreadFunction()
      Dim myThreadClassObject As New MyThreadClass(Me)
      myThreadClassObject.Run()
   End Sub 'ThreadFunction
End Class 'MyFormControl

Public Class MyThreadClass
   Private myFormControl1 As MyFormControl

   Public Sub New(myForm As MyFormControl)
      myFormControl1 = myForm
   End Sub 'New
   Private myString As String

   Public Sub Run()

      Dim i As Integer
      For i = 1 To 5
         myString = "Step number " + i.ToString() + " executed"
         Thread.Sleep(400)
         ' Execute the specified delegate on the thread that owns
         ' 'myFormControl1' control's underlying window handle with
         ' the specified list of arguments.
         myFormControl1.Invoke(myFormControl1.myDelegate, New Object() {myString})
      Next i

   End Sub 'Run
End Class 'MyThreadClass
' </Snippet1>