<!-- <Snippet1> -->
<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
  	' Returns an array of Boolean values
	Private Function TestPrimes(ByVal [from] As Integer, ByVal howMany As Integer) As Boolean()
		' Test a range of numbers to determine which are prime.
		Dim isPrime(howMany - 1) As Boolean

		Dim endAt As Integer = From + howMany - 1
		For i As Integer = From To endAt - 1
			isPrime(i - From) = True

			Dim sqrt As Integer = CInt(Fix(Math.Sqrt(i)))
			For factor As Integer = 2 To sqrt
				If (i Mod factor) = 0 Then
					isPrime(i - From) = False
					Exit For
				End If
			Next factor
		Next i
		Return isPrime
	End Function

'<Snippet2>
	Protected Sub Page_Load(ByVal sender As Object, ByVal args As EventArgs)
		If Not IsPostBack Then
			Primes.ItemCount = 2000
			Primes.ItemsPerPage = 20
			form1.ControlToPaginate = Primes
		End If
	End Sub
'</Snippet2>

	Protected Sub Primes_OnLoadItems(ByVal sender As Object, ByVal args As LoadItemsEventArgs)
		Dim StrBldr As New StringBuilder()
		Primes.Text = ""

		' Start the list at 2.
		Dim startNumber As Integer = args.ItemIndex + 2
		Dim isPrime() As Boolean
		isPrime = TestPrimes(startNumber, args.ItemCount)

		For i As Integer = 0 To args.ItemCount - 1
			Dim message As String
			If isPrime(i) Then
				message = String.Format("<b>{0} is prime</b>", i + startNumber)
			Else
				message = String.Format("<b>{0}</b> is not prime", i + startNumber)
			End If

			StrBldr.Append(message)
			StrBldr.Append("<br />")
		Next i
		Primes.Text = StrBldr.ToString()
	End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server" paginate="true">
        <mobile:TextView id="Primes" runat="server" 
            OnLoadItems="Primes_OnLoadItems" />
    </mobile:form>
</body>
</html>
<!-- </Snippet1> -->
