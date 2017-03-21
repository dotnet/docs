    <Personalizable(), WebBrowsable(), WebDisplayName("Job Type"), _
      WebDescription("Select the category that corresponds to your job.")> _
    Public Property UserJobType() As JobTypeName
      Get
        Dim o As Object = ViewState("UserJobType")
        If Not (o Is Nothing) Then
          Return CType(o, JobTypeName)
        Else
          Return _userJobType
        End If
      End Get
      Set(ByVal value As JobTypeName)
        _userJobType = CType(value, JobTypeName)
      End Set
    End Property