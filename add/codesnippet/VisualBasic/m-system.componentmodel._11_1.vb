    ' This method starts an asynchronous calculation. 
    ' First, it checks the supplied task ID for uniqueness.
    ' If taskId is unique, it creates a new WorkerEventHandler 
    ' and calls its BeginInvoke method to start the calculation.
    Public Overridable Sub CalculatePrimeAsync( _
        ByVal numberToTest As Integer, _
        ByVal taskId As Object)

        ' Create an AsyncOperation for taskId.
        Dim asyncOp As AsyncOperation = _
            AsyncOperationManager.CreateOperation(taskId)

        ' Multiple threads will access the task dictionary,
        ' so it must be locked to serialize access.
        SyncLock userStateToLifetime.SyncRoot
            If userStateToLifetime.Contains(taskId) Then
                Throw New ArgumentException( _
                    "Task ID parameter must be unique", _
                    "taskId")
            End If

            userStateToLifetime(taskId) = asyncOp
        End SyncLock

        ' Start the asynchronous operation.
        Dim workerDelegate As New WorkerEventHandler( _
            AddressOf CalculateWorker)

        workerDelegate.BeginInvoke( _
            numberToTest, _
            asyncOp, _
            Nothing, _
            Nothing)

    End Sub