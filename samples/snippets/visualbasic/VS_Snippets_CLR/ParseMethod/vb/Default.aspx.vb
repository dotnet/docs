Option Strict On

Imports System.Globalization
Imports System.Web.UI.WebControls

Partial Class _Default
    Inherits System.Web.UI.Page

   ' controls on web form
   Dim inputNumber As TextBox
   Dim outputNumber As Label
   Dim WithEvents OkToSingle, OkToDouble, OkToDecimal, OkToInteger, OkToLong As Button
   Dim WithEvents OkToUInteger, OkToULong As Button
   
   ' <Snippet1>
   Protected Sub OkToSingle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OkToSingle.Click
      Dim locale As String
      Dim culture As CultureInfo
      Dim number As Single

      ' Return if string is empty
      If String.IsNullOrEmpty(Me.inputNumber.Text) Then Exit Sub

      ' Get locale of web request to determine possible format of number
      If Request.UserLanguages.Length = 0 Then Exit Sub
      locale = Request.UserLanguages(0)
      If String.IsNullOrEmpty(locale) Then Exit Sub

      ' Instantiate CultureInfo object for the user's locale
      culture = New CultureInfo(locale)

      ' Convert user input from a string to a number
      Try
         number = Single.Parse(Me.inputNumber.Text, culture.NumberFormat)
      Catch ex As FormatException
         Exit Sub
      Catch ex As OverflowException
         Exit Sub
      End Try

      ' Output number to label on web form
      Me.outputNumber.Text = "Number is " & number.ToString()
   End Sub
   ' </Snippet1>

   ' <Snippet2>
   Protected Sub OkToDouble_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OkToDouble.Click
      Dim locale As String
      Dim culture As CultureInfo
      Dim number As Double

      ' Return if string is empty
      If String.IsNullOrEmpty(Me.inputNumber.Text) Then Exit Sub
      
      ' Get locale of web request to determine possible format of number
      If Request.UserLanguages.Length = 0 Then Exit Sub
      locale = Request.UserLanguages(0)
      If String.IsNullOrEmpty(locale) Then Exit Sub

      ' Instantiate CultureInfo object for the user's locale
      culture = New CultureInfo(locale)

      ' Convert user input from a string to a number
      Try
         number = Double.Parse(Me.inputNumber.Text, culture.NumberFormat)
      Catch ex As FormatException
         Exit Sub
      Catch ex As Exception
         Exit Sub
      End Try

      ' Output number to label on web form
      Me.outputNumber.Text = "Number is " & number.ToString()
   End Sub
   ' </Snippet2>

   ' <Snippet3>
   Protected Sub OkToDecimal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OkToDecimal.Click
      Dim locale As String
      Dim culture As CultureInfo
      Dim number As Decimal

      ' Return if string is empty
      If String.IsNullOrEmpty(Me.inputNumber.Text) Then Exit Sub

      ' Get locale of web request to determine possible format of number
      If Request.UserLanguages.Length = 0 Then Exit Sub
      locale = Request.UserLanguages(0)
      If String.IsNullOrEmpty(locale) Then Exit Sub

      ' Instantiate CultureInfo object for the user's locale
      culture = New CultureInfo(locale)

      ' Convert user input from a string to a number
      Try
         number = Decimal.Parse(Me.inputNumber.Text, culture.NumberFormat)
      Catch ex As FormatException
         Exit Sub
      Catch ex As Exception
         Exit Sub
      End Try

      ' Output number to label on web form
      Me.outputNumber.Text = "Number is " & number.ToString()
   End Sub
   ' </Snippet3>

   ' <Snippet4>
   Protected Sub OkToInteger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OkToInteger.Click
      Dim locale As String
      Dim culture As CultureInfo
      Dim number As Integer

      ' Return if string is empty
      If String.IsNullOrEmpty(Me.inputNumber.Text) Then Exit Sub

      ' Get locale of web request to determine possible format of number
      If Request.UserLanguages.Length = 0 Then Exit Sub
      locale = Request.UserLanguages(0)
      If String.IsNullOrEmpty(locale) Then Exit Sub

      ' Instantiate CultureInfo object for the user's locale
      culture = New CultureInfo(locale)

      ' Convert user input from a string to a number
      Try
         number = Int32.Parse(Me.inputNumber.Text, culture.NumberFormat)
      Catch ex As FormatException
         Exit Sub
      Catch ex As Exception
         Exit Sub
      End Try

      ' Output number to label on web form
      Me.outputNumber.Text = "Number is " & number.ToString()
   End Sub
   ' </Snippet4>

   ' <Snippet6>
   Protected Sub OKToUInteger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OKToUInteger.Click
      Dim locale As String
      Dim culture As CultureInfo
      Dim number As UInteger

      ' Return if string is empty
      If String.IsNullOrEmpty(Me.inputNumber.Text) Then Exit Sub

      ' Get locale of web request to determine possible format of number
      If Request.UserLanguages.Length = 0 Then Exit Sub
      locale = Request.UserLanguages(0)
      If String.IsNullOrEmpty(locale) Then Exit Sub

      ' Instantiate CultureInfo object for the user's locale
      culture = New CultureInfo(locale)

      ' Convert user input from a string to a number
      Try
         number = UInt32.Parse(Me.inputNumber.Text, culture.NumberFormat)
      Catch ex As FormatException
         Exit Sub
      Catch ex As Exception
         Exit Sub
      End Try

      ' Output number to label on web form
      Me.outputNumber.Text = "Number is " & number.ToString()
   End Sub
   ' </Snippet6>

   ' <Snippet5>
   Protected Sub OkToLong_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OkToLong.Click
      Dim locale As String
      Dim culture As CultureInfo
      Dim number As Long

      ' Return if string is empty
      If String.IsNullOrEmpty(Me.inputNumber.Text) Then Exit Sub

      ' Get locale of web request to determine possible format of number
      If Request.UserLanguages.Length = 0 Then Exit Sub
      locale = Request.UserLanguages(0)
      If String.IsNullOrEmpty(locale) Then Exit Sub

      ' Instantiate CultureInfo object for the user's locale
      culture = New CultureInfo(locale)

      ' Convert user input from a string to a number
      Try
         number = Int64.Parse(Me.inputNumber.Text, culture.NumberFormat)
      Catch ex As FormatException
         Exit Sub
      Catch ex As Exception
         Exit Sub
      End Try

      ' Output number to label on web form
      Me.outputNumber.Text = "Number is " & number.ToString()
   End Sub
   ' </Snippet5>

   ' <Snippet7>
   Protected Sub OkToULong_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OkToULong.Click
      Dim locale As String
      Dim culture As CultureInfo
      Dim number As ULong

      ' Return if string is empty
      If String.IsNullOrEmpty(Me.inputNumber.Text) Then Exit Sub

      ' Get locale of web request to determine possible format of number
      If Request.UserLanguages.Length = 0 Then Exit Sub
      locale = Request.UserLanguages(0)
      If String.IsNullOrEmpty(locale) Then Exit Sub

      ' Instantiate CultureInfo object for the user's locale
      culture = New CultureInfo(locale)

      ' Convert user input from a string to a number
      Try
         number = UInt64.Parse(Me.inputNumber.Text, culture.NumberFormat)
      Catch ex As FormatException
         Exit Sub
      Catch ex As Exception
         Exit Sub
      End Try

      ' Output number to label on web form
      Me.outputNumber.Text = "Number is " & number.ToString()
   End Sub
   ' </Snippet7>
End Class
