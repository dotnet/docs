    Public Sub New(ByVal virtualPath As String, ByVal provider As SamplePathProvider)
      MyBase.New(virtualPath)
      spp = provider
      GetData()
    End Sub

    Protected Sub GetData()
      ' Get the data from the SamplePathProvider.
      Dim spp As SamplePathProvider
      spp = CType(HostingEnvironment.VirtualPathProvider, SamplePathProvider)

      Dim ds As DataSet
      ds = spp.GetVirtualData

      ' Get the virtual file data from the resource table.
      Dim files As DataTable
      files = ds.Tables("resource")

      Dim rows As DataRow()
      rows = files.Select( _
        String.Format("(name='{0}') AND (type='file')", Me.Name))

      ' If the select returned a row, store the file contents.
      If (rows.Length > 0) Then
        Dim row As DataRow
        row = rows(0)

        content = row("content").ToString()
      End If
    End Sub