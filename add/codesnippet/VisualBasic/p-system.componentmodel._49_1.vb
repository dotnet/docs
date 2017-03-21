        ' Abort the operation if the user has canceled.
        ' Note that a call to CancelAsync may have set 
        ' CancellationPending to true just after the
        ' last invocation of this method exits, so this 
        ' code will not have the opportunity to set the 
        ' DoWorkEventArgs.Cancel flag to true. This means
        ' that RunWorkerCompletedEventArgs.Cancelled will
        ' not be set to true in your RunWorkerCompleted
        ' event handler. This is a race condition.
        If worker.CancellationPending Then
            e.Cancel = True
        Else
            If n < 2 Then
                result = 1
            Else
                result = ComputeFibonacci(n - 1, worker, e) + _
                         ComputeFibonacci(n - 2, worker, e)
            End If

            ' Report progress as a percentage of the total task.
            Dim percentComplete As Integer = _
                CSng(n) / CSng(numberToCompute) * 100
            If percentComplete > highestPercentageReached Then
                highestPercentageReached = percentComplete
                worker.ReportProgress(percentComplete)
            End If

        End If