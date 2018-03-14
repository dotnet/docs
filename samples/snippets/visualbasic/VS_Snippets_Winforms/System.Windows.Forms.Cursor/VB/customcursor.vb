'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace CustomCursor
   
   Public Class Form1
      Inherits System.Windows.Forms.Form
      
      <System.STAThread()> _
      Public Shared Sub Main()
         System.Windows.Forms.Application.Run(New Form1())
      End Sub 'Main

      Public Sub New()

         Me.ClientSize = New System.Drawing.Size(292, 266)
         Me.Text = "Cursor Example"
         
        ' The following generates a cursor from an embedded resource.
         
        'To add a custom cursor, create a bitmap
        '       1. Add a new cursor file to your project: 
        '               Project->Add New Item->General->Cursor File

        '--- To make the custom cursor an embedded resource  ---

        'In Visual Studio:
        '       1. Select the cursor file in the Solution Explorer
        '       2. Choose View->Properties.
        '       3. In the properties window switch "Build Action" to "Embedded Resources"

        'On the command line:
        '       Add the following flag:
        '           /res:CursorFileName.cur,Namespace.CursorFileName.cur

        '       Where "Namespace" is the namespace in which you want to use the cursor
        '       and   "CursorFileName.cur" is the cursor filename.

        'The following line uses the namespace from the passed-in type
        'and looks for CustomCursor.MyCursor.cur in the assemblies manifest.
        'NOTE: The cursor name is acase sensitive.
        Me.Cursor = New Cursor(Me.GetType(), "MyCursor.cur")
      End Sub 'New       
   End Class 'Form1
End Namespace 'CustomCursor
'</Snippet1>