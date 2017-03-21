    ' This event handler updates the ListView control when the
    ' PrimeNumberCalculator raises the CalculatePrimeCompleted
    ' event. The ListView item is updated with the appropriate
    ' outcome of the calculation: Canceled, Error, or result.
    Private Sub primeNumberCalculator1_CalculatePrimeCompleted( _
        ByVal sender As Object, _
        ByVal e As CalculatePrimeCompletedEventArgs) _
        Handles primeNumberCalculator1.CalculatePrimeCompleted

        Dim taskId As Guid = CType(e.UserState, Guid)

        If e.Cancelled Then
            Dim result As String = "Canceled"

            Dim lvi As ListViewItem = UpdateListViewItem( _
                taskId, _
                result)

            If (lvi IsNot Nothing) Then
                lvi.BackColor = Color.Pink
                lvi.Tag = Nothing
            End If

        ElseIf e.Error IsNot Nothing Then

            Dim result As String = "Error"

            Dim lvi As ListViewItem = UpdateListViewItem( _
                taskId, result)

            If (lvi IsNot Nothing) Then
                lvi.BackColor = Color.Red
                lvi.ForeColor = Color.White
                lvi.Tag = Nothing
            End If
        Else
            Dim result As Boolean = e.IsPrime

            Dim lvi As ListViewItem = UpdateListViewItem( _
                taskId, _
                result, _
                e.FirstDivisor)

            If (lvi IsNot Nothing) Then
                lvi.BackColor = Color.LightGray
                lvi.Tag = Nothing
            End If
        End If

    End Sub