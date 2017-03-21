    ' This method is invoked via the AsyncOperation object,
    ' so it is guaranteed to be executed on the correct thread.
    Private Sub CalculateCompleted(ByVal operationState As Object)
        Dim e As CalculatePrimeCompletedEventArgs = operationState

        OnCalculatePrimeCompleted(e)

    End Sub


    ' This method is invoked via the AsyncOperation object,
    ' so it is guaranteed to be executed on the correct thread.
    Private Sub ReportProgress(ByVal state As Object)
        Dim e As ProgressChangedEventArgs = state

        OnProgressChanged(e)

    End Sub

    Protected Sub OnCalculatePrimeCompleted( _
        ByVal e As CalculatePrimeCompletedEventArgs)

        RaiseEvent CalculatePrimeCompleted(Me, e)

    End Sub


    Protected Sub OnProgressChanged( _
        ByVal e As ProgressChangedEventArgs)

        RaiseEvent ProgressChanged(e)

    End Sub