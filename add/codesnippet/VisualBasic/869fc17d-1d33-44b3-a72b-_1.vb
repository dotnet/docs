        ' One-dimensional list for the grid data.
        Private dataArray As New ArrayList()

        ' Copy grid data to one-dimensional list, add row separators.
        Protected Overrides Sub PerformDataBinding(ByVal data As IEnumerable)

            Dim dataSourceEnumerator As IEnumerator = data.GetEnumerator()

            ' Iterate through the table rows.
            While dataSourceEnumerator.MoveNext()

                ' Add the next data row to the ArrayList.
                dataArray.AddRange(CType(dataSourceEnumerator.Current, _
                                        DataRowView).Row.ItemArray)

                ' Add a separator to the ArrayList.
                dataArray.Add("----------")
            End While
        End Sub 'PerformDataBinding

        ' Render the data source as a one-dimensional list.
        Protected Overrides Sub RenderContents( _
            ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Render the data list.
            Dim col As Integer
            For col = 0 To dataArray.Count - 1
                writer.Write(dataArray(col))
                writer.WriteBreak()
            Next col
        End Sub 'RenderContents