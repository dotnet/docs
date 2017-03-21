    Public Sub dataGridView1_CellToolTipTextNeeded(ByVal sender As Object, _
        ByVal e As DataGridViewCellToolTipTextNeededEventArgs) _
        Handles dataGridView1.CellToolTipTextNeeded

        Dim newLine As String = Environment.NewLine
        If e.RowIndex > -1 Then
            Dim dataGridViewRow1 As DataGridViewRow = _
            dataGridView1.Rows(e.RowIndex)

            ' Add the employee's ID to the ToolTipText.
            e.ToolTipText = String.Format("EmployeeID {0}: {1}", _
                dataGridViewRow1.Cells("EmployeeID").Value.ToString(), _
                newLine)

            ' Add the employee's name to the ToolTipText.
            e.ToolTipText += String.Format("{0} {1} {2} {3}", _
                dataGridViewRow1.Cells("TitleOfCourtesy").Value.ToString(), _
                dataGridViewRow1.Cells("FirstName").Value.ToString(), _
                dataGridViewRow1.Cells("LastName").Value.ToString(), _
                newLine)

            ' Add the employee's title to the ToolTipText.
            e.ToolTipText += String.Format("{0}{1}{2}", _
                dataGridViewRow1.Cells("Title").Value.ToString(), _
                newLine, newLine)

            ' Add the employee's contact information to the ToolTipText.
            e.ToolTipText += String.Format("{0}{1}{2}, ", _
                dataGridViewRow1.Cells("Address").Value.ToString(), newLine, _
                dataGridViewRow1.Cells("City").Value.ToString())
            If Not String.IsNullOrEmpty( _
                dataGridViewRow1.Cells("Region").Value.ToString())

                e.ToolTipText += String.Format("{0}, ", _
                   dataGridViewRow1.Cells("Region").Value.ToString())
            End If
            e.ToolTipText += String.Format("{0}, {1}{2}{3} EXT:{4}{5}{6}", _
                dataGridViewRow1.Cells("Country").Value.ToString(), _
                dataGridViewRow1.Cells("PostalCode").Value.ToString(), _
                newLine, _
                dataGridViewRow1.Cells("HomePhone").Value.ToString(), _
                dataGridViewRow1.Cells("Extension").Value.ToString(), _
                newLine, newLine)

            ' Add employee information to the ToolTipText.
            Dim HireDate As DateTime = _
                CType(dataGridViewRow1.Cells("HireDate").Value, DateTime)
            e.ToolTipText += _
                String.Format("Employee since: {0}/{1}/{2}{3}Manager: {4}", _
                    HireDate.Month.ToString(), HireDate.Day.ToString(), _
                    HireDate.Year.ToString(), newLine, _
                    dataGridViewRow1.Cells("Manager").Value.ToString())
        End If
    End Sub