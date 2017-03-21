   Sub Page_Load(Sender As Object, e As EventArgs)
   
      ' Note: This property can also be set in <%@ Page ...> tag.
      If (Not IsPostBack) Then
         Me.ErrorPage = "Error_Page.aspx"
    End If
   End Sub