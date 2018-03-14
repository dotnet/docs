'*************************************************************************
'<Snippet10>
Public Class widgetRepository
    Public widgetColl As New Microsoft.VisualBasic.Collection()
    ' Insert code to implement additional functionality.
End Class
'</Snippet10>


'*************************************************************************
Public Class widget
End Class


'*************************************************************************
Public Class Class2

  Sub test2()
    '<Snippet14>
    Dim customers As New Microsoft.VisualBasic.Collection()
    Dim stringQueue As New System.Collections.Generic.Queue(Of String)
    '</Snippet14>
  End Sub


  '***********************************************************************
  Sub test()
    Dim widgetColl As New Microsoft.VisualBasic.Collection()

    '<Snippet11>
    Dim notWidget As String = "This is not a widget object!"
    widgetColl.Add(notWidget)
    '</Snippet11>

    '<Snippet13>
    Dim nextWidget As widget
    Try
        nextWidget = CType(widgetColl.Item(1), widget)
    Catch ex As Exception
        ' Insert code to run if the collection item is not a widget.
    End Try
    '</Snippet13>
  End Sub

  '<Snippet12>
  Public widgetColl As New System.Collections.Generic.List(Of widget)
  '</Snippet12>
End Class