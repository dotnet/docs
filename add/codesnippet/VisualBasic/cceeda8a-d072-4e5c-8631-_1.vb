  Public Overrides Function GetAllProfiles( _
  ByVal authenticationOption As ProfileAuthenticationOption, _
  ByVal pageIndex As Integer, _
  ByVal pageSize As Integer, _
   ByRef totalRecords As Integer) As ProfileInfoCollection

    totalRecords = 0

    Return New ProfileInfoCollection()
  End Function