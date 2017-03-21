' Override default implementation to Render children according to needs. 
      Protected Overrides Sub RenderChildren(output As HtmlTextWriter)
         If HasControls() Then
            ' Render Children in reverse order.
            Dim i As Integer

            For i = Controls.Count - 1 To 0 Step -1
               Controls(i).RenderControl(output)
            Next

         End If
      End Sub 'RenderChildren
      
      
      Protected Overrides Sub Render(output As HtmlTextWriter)
         output.Write(("<br>Message from Control : " + Message))
         output.Write(("Showing Custom controls created in reverse" + "order"))
         ' Render Controls.
         RenderChildren(output)
      End Sub
   End Class
