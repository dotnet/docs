   ' Get data from the underlying data source.
   ' Build and return a DataView, regardless of mode.
   Protected Overrides Function ExecuteSelect(selectArgs As DataSourceSelectArguments) _
    As System.Collections.IEnumerable
      Dim dataList As IEnumerable = Nothing
      ' Open the .csv file.
      If File.Exists(Me.SourceFile) Then
         Dim data As New DataTable()

         ' Open the file to read from.
         Dim sr As StreamReader = File.OpenText(Me.SourceFile)

         Try
            ' Parse the line
            Dim dataValues() As String
            Dim col As DataColumn

            ' Do the following to add schema.
            dataValues = sr.ReadLine().Split(","c)
            ' For each token in the comma-delimited string, add a column
            ' to the DataTable schema.
            Dim token As String
            For Each token In dataValues
               col = New DataColumn(token, System.Type.GetType("System.String"))
               data.Columns.Add(col)
            Next token

            ' Do not add the first row as data if the CSV file includes column names.
            If Not IncludesColumnNames Then
               data.Rows.Add(CopyRowData(dataValues, data.NewRow()))
            End If

            ' Do the following to add data.
            Dim s As String
            Do
               s = sr.ReadLine()
               If Not s Is Nothing Then
                   dataValues = s.Split(","c)
                   data.Rows.Add(CopyRowData(dataValues, data.NewRow()))
               End If
            Loop Until s Is Nothing

         Finally
            sr.Close()
         End Try

         data.AcceptChanges()
         Dim dataView As New DataView(data)
         If Not selectArgs.SortExpression Is String.Empty Then
             dataView.Sort = selectArgs.SortExpression
         End If
         dataList = dataView
      Else
         Throw New System.Configuration.ConfigurationErrorsException("File not found, " + Me.SourceFile)
      End If

      If dataList is Nothing Then
         Throw New InvalidOperationException("No data loaded from data source.")
      End If

      Return dataList
   End Function 'ExecuteSelect


   Private Function CopyRowData([source]() As String, target As DataRow) As DataRow
      Try
         Dim i As Integer
         For i = 0 To [source].Length - 1
            target(i) = [source](i)
         Next i
      Catch iore As IndexOutOfRangeException
         ' There are more columns in this row than
         ' the original schema allows.  Stop copying
         ' and return the DataRow.
         Return target
      End Try
      Return target
   End Function 'CopyRowData