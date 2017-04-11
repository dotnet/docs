' This is a simple example for VisualStyleInformation that displays
' all of the visual style values in a ListView.

' <Snippet0>
Imports System
Imports System.Drawing
Imports System.Text
Imports System.Reflection
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles

Namespace VisualStyleInformationSample

    Public Class Form1
        Inherits Form
        Private listView1 As New ListView()

        <STAThread()> _
        Shared Sub Main()
            Application.EnableVisualStyles()
            Application.Run(New Form1())
        End Sub

        Public Sub New()
            Me.Text = "VisualStyleInformation Property Values"
            Me.AutoSize = True

            With listView1
                .Bounds = New Rectangle(New Point(10, 10), New Size(400, 300))
                .View = View.Details
                .Sorting = SortOrder.Ascending
            End With

            ' Get an array of property details for the
            ' VisualStyleInformation class.
            Dim typeInfo As Type = GetType(VisualStyleInformation)
            Dim elementProperties As PropertyInfo() = _
                typeInfo.GetProperties(BindingFlags.Static Or BindingFlags.Public)

            ' Use these variables to store the name and value of each property.
            Dim propertyName As New StringBuilder()
            Dim propertyValue As Object
            Dim prop As PropertyInfo

            For Each prop In elementProperties
                ' Get the name and value of the current property.
                propertyName.Append(prop.Name)
                propertyValue = prop.GetValue(Nothing, BindingFlags.Static, _
                    Nothing, Nothing, Nothing)
                ' Insert the property name and value into the ListView.
                Dim newItem As New ListViewItem(propertyName.ToString(), 0)
                newItem.SubItems.Add(propertyValue.ToString())
                listView1.Items.Add(newItem)
                ' Clear the property name for the next iteration.
                propertyName.Remove(0, propertyName.Length)
            Next prop

            ' Create columns for the items and subitems.
            listView1.Columns.Add("Property", -1, _
                System.Windows.Forms.HorizontalAlignment.Left)
            listView1.Columns.Add("Value", -1, _
                System.Windows.Forms.HorizontalAlignment.Left)
            Me.Controls.Add(listView1)
        End Sub
    End Class
End Namespace
' </Snippet0>