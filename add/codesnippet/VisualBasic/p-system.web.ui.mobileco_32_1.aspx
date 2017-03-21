	Protected Sub Page_Load(ByVal sender As Object, ByVal args As EventArgs)
		If Not IsPostBack Then
			Primes.ItemCount = 2000
			Primes.ItemsPerPage = 20
			form1.ControlToPaginate = Primes
		End If
	End Sub