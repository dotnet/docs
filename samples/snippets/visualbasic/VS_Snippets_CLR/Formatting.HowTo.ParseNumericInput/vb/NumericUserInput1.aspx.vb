Imports System.Web.UI
Imports System.Web.UI.WebControls

' <Snippet1>
Imports System.Globalization

Partial Class NumericUserInput
   Inherits System.Web.UI.Page

   Protected Sub OKButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OKButton.Click
      Dim locale As String
      Dim culture As CultureInfo = Nothing
      Dim number As Double
      Dim result As Boolean

      ' Exit if input is absent.
      If String.IsNullOrEmpty(Me.NumericString.Text) Then Exit Sub

      ' Hide form elements.
      Me.NumericInput.Visible = False

      ' Get user culture/region
      If Not (Request.UserLanguages.Length = 0 OrElse String.IsNullOrEmpty(Request.UserLanguages(0))) Then
         Try
            locale = Request.UserLanguages(0)
            culture = New CultureInfo(locale, False)

            ' Parse input using user culture.
            result = Double.TryParse(Me.NumericString.Text, NumberStyles.Any, culture.NumberFormat, number)
         Catch
         End Try
         ' If parse fails, parse input using any additional languages.
         If Not result Then
            If Request.UserLanguages.Length > 1 Then
               For ctr As Integer = 1 To Request.UserLanguages.Length - 1
                  Try
                     locale = Request.UserLanguages(ctr)
                     ' Remove quality specifier, if present.
                     locale = Left(locale, InStr(locale, ";") - 1)
                     culture = New CultureInfo(Request.UserLanguages(ctr), False)
                     result = Double.TryParse(Me.NumericString.Text, NumberStyles.Any, culture.NumberFormat, number)
                     If result Then Exit For
                  Catch
                  End Try
               Next
            End If
         End If
      End If
      ' If parse operation fails, use invariant culture.
      If Not result Then
         result = Double.TryParse(Me.NumericString.Text, NumberStyles.Any, CultureInfo.InvariantCulture, number)
      End If
      ' Double result
      number *= 2

      ' Display result to user.
      If result Then
         Response.Write("<P />")
         Response.Write(Server.HtmlEncode(Me.NumericString.Text) + " * 2 = " + number.ToString("N", culture) + "<BR />")
      Else
         ' Unhide form.
         Me.NumericInput.Visible = True

         Response.Write("<P />")
         Response.Write("Unable to recognize " + Server.HtmlEncode(Me.NumericString.Text))
      End If
   End Sub   
End Class
' </Snippet1>

' needed for code to compile
Partial Class NumericUserInput
   Protected NumericInput As New UserControl()
   Protected NumericString As New TextBox()
   Protected WithEvents OKButton As New Button()
End Class
