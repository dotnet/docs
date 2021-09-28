' <snippet10>
' <snippet11>
Imports System.Collections
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Threading
Imports System.Windows.Forms
' </snippet11>

' This form tests the PrimeNumberCalculator component.
Public Class PrimeNumberCalculatorMain
    Inherits System.Windows.Forms.Form

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Private fields
    '
    #Region "Private fields"
    
    Private WithEvents primeNumberCalculator1 As PrimeNumberCalculator
    Private taskGroupBox As System.Windows.Forms.GroupBox
    Private WithEvents listView1 As System.Windows.Forms.ListView
    Private taskIdColHeader As System.Windows.Forms.ColumnHeader
    Private progressColHeader As System.Windows.Forms.ColumnHeader
    Private currentColHeader As System.Windows.Forms.ColumnHeader
    Private buttonPanel As System.Windows.Forms.Panel
    Private panel2 As System.Windows.Forms.Panel
    Private WithEvents startAsyncButton As System.Windows.Forms.Button
    Private WithEvents cancelAsyncButton As System.Windows.Forms.Button
    Private testNumberColHeader As System.Windows.Forms.ColumnHeader
    Private resultColHeader As System.Windows.Forms.ColumnHeader
    Private firstDivisorColHeader As System.Windows.Forms.ColumnHeader
    Private components As System.ComponentModel.IContainer
    Private progressCounter As Integer
    Private progressInterval As Integer = 100


#End Region

    
    Public Sub New()

        InitializeComponent()

    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)

    End Sub


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
#Region "Implementation"

    ' This event handler selects a number randomly to test
    ' for primality. It then starts the asynchronous 
    ' calculation by calling the PrimeNumberCalculator
    ' component's CalculatePrimeAsync method.
    Private Sub startAsyncButton_Click( _
        ByVal sender As System.Object, _
        ByVal e As System.EventArgs) _
        Handles startAsyncButton.Click

        ' Randomly choose test numbers 
        ' up to 200,000 for primality.
        Dim rand As New Random
        Dim testNumber As Integer = rand.Next(200000)

        ' Task IDs are Guids.
        Dim taskId As Guid = Guid.NewGuid()
        Me.AddListViewItem(taskId, testNumber)

        ' Start the asynchronous task.
        Me.primeNumberCalculator1.CalculatePrimeAsync( _
        testNumber, _
        taskId)

    End Sub


    Private Sub listView1_SelectedIndexChanged( _
        ByVal sender As Object, ByVal e As EventArgs) _
        Handles listView1.SelectedIndexChanged

        Me.cancelAsyncButton.Enabled = CanCancel()

    End Sub


    ' This event handler cancels all pending tasks that are
    ' selected in the ListView control.
    Private Sub cancelAsyncButton_Click( _
        ByVal sender As System.Object, _
        ByVal e As System.EventArgs) _
        Handles cancelAsyncButton.Click

        Dim taskId As Guid = Guid.Empty

        ' Cancel all selected tasks.
        Dim lvi As ListViewItem
        For Each lvi In Me.listView1.SelectedItems
            ' Tasks that have been completed or canceled have 
            ' their corresponding ListViewItem.Tag property
            ' set to Nothing.
            If (lvi.Tag IsNot Nothing) Then
                taskId = CType(lvi.Tag, Guid)
                Me.primeNumberCalculator1.CancelAsync(taskId)
                lvi.Selected = False
            End If
        Next lvi

        cancelAsyncButton.Enabled = False

    End Sub

    ' <snippet40>
    ' This event handler updates the ListView control when the
    ' PrimeNumberCalculator raises the ProgressChanged event.
    '
    ' On fast computers, the PrimeNumberCalculator can raise many
    ' successive ProgressChanged events, so the user interface 
    ' may be flooded with messages. To prevent the user interface
    ' from hanging, progress is only reported at intervals. 
    Private Sub primeNumberCalculator1_ProgressChanged( _
        ByVal e As ProgressChangedEventArgs) _
        Handles primeNumberCalculator1.ProgressChanged

        Me.progressCounter += 1

        If Me.progressCounter Mod Me.progressInterval = 0 Then

            Dim taskId As Guid = CType(e.UserState, Guid)

            If TypeOf e Is CalculatePrimeProgressChangedEventArgs Then
                Dim cppcea As CalculatePrimeProgressChangedEventArgs = e
                Me.UpdateListViewItem( _
                    taskId, _
                    cppcea.ProgressPercentage, _
                    cppcea.LatestPrimeNumber)
            Else
                Me.UpdateListViewItem( _
                    taskId, e.ProgressPercentage)
            End If
        ElseIf Me.progressCounter > Me.progressInterval Then
            Me.progressCounter = 0
        End If

    End Sub
    ' </snippet40>

    ' <snippet12>
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
    ' </snippet12>

#End Region

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
#Region "Private Methods"

    Private Function AddListViewItem( _
        ByVal guid As Guid, _
        ByVal testNumber As Integer) As ListViewItem

        Dim lvi As New ListViewItem
        lvi.Text = testNumber.ToString( _
        CultureInfo.CurrentCulture.NumberFormat)

        lvi.SubItems.Add("Not Started")
        lvi.SubItems.Add("1")
        lvi.SubItems.Add(guid.ToString())
        lvi.SubItems.Add("---")
        lvi.SubItems.Add("---")
        lvi.Tag = guid

        Me.listView1.Items.Add(lvi)

        Return lvi

    End Function

    Private Overloads Function UpdateListViewItem( _
        ByVal guid As Guid, _
        ByVal percentComplete As Integer, _
        ByVal current As Integer) As ListViewItem

        Dim lviRet As ListViewItem = Nothing

        Dim lvi As ListViewItem
        For Each lvi In Me.listView1.Items
            If (lvi.Tag IsNot Nothing) Then
                If guid.CompareTo(CType(lvi.Tag, Guid)) = 0 Then
                    lvi.SubItems(1).Text = percentComplete.ToString( _
                    CultureInfo.CurrentCulture.NumberFormat)
                    lvi.SubItems(2).Text = current.ToString( _
                    CultureInfo.CurrentCulture.NumberFormat)
                    lviRet = lvi
                    Exit For
                End If
            End If
        Next lvi

        Return lviRet

    End Function


    Private Overloads Function UpdateListViewItem( _
        ByVal guid As Guid, _
        ByVal percentComplete As Integer, _
        ByVal current As Integer, _
        ByVal result As Boolean, _
        ByVal firstDivisor As Integer) As ListViewItem

        Dim lviRet As ListViewItem = Nothing

        Dim lvi As ListViewItem
        For Each lvi In Me.listView1.Items
            If guid.CompareTo(CType(lvi.Tag, Guid)) = 0 Then
                lvi.SubItems(1).Text = percentComplete.ToString( _
                CultureInfo.CurrentCulture.NumberFormat)
                lvi.SubItems(2).Text = current.ToString( _
                CultureInfo.CurrentCulture.NumberFormat)
                lvi.SubItems(4).Text = _
                    IIf(result, "Prime", "Composite")
                lvi.SubItems(5).Text = firstDivisor.ToString( _
                CultureInfo.CurrentCulture.NumberFormat)

                lviRet = lvi

                Exit For
            End If
        Next lvi

        Return lviRet

    End Function


    Private Overloads Function UpdateListViewItem( _
        ByVal guid As Guid, _
        ByVal percentComplete As Integer) As ListViewItem

        Dim lviRet As ListViewItem = Nothing

        Dim lvi As ListViewItem
        For Each lvi In Me.listView1.Items
            If (lvi.Tag IsNot Nothing) Then
                If guid.CompareTo(CType(lvi.Tag, Guid)) = 0 Then
                    lvi.SubItems(1).Text = percentComplete.ToString( _
                    CultureInfo.CurrentCulture.NumberFormat)
                    lviRet = lvi
                    Exit For
                End If
            End If
        Next lvi

        Return lviRet

    End Function


    Private Overloads Function UpdateListViewItem( _
        ByVal guid As Guid, _
        ByVal result As Boolean, _
        ByVal firstDivisor As Integer) As ListViewItem

        Dim lviRet As ListViewItem = Nothing

        Dim lvi As ListViewItem
        For Each lvi In Me.listView1.Items
            If (lvi.Tag IsNot Nothing) Then
                If guid.CompareTo(CType(lvi.Tag, Guid)) = 0 Then
                    lvi.SubItems(4).Text = _
                        IIf(result, "Prime", "Composite")
                    lvi.SubItems(5).Text = firstDivisor.ToString( _
                    CultureInfo.CurrentCulture.NumberFormat)
                    lviRet = lvi
                    Exit For
                End If
            End If
        Next lvi

        Return lviRet

    End Function


    Private Overloads Function UpdateListViewItem( _
        ByVal guid As Guid, _
        ByVal result As String) As ListViewItem

        Dim lviRet As ListViewItem = Nothing

        Dim lvi As ListViewItem
        For Each lvi In Me.listView1.Items
            If (lvi.Tag IsNot Nothing) Then
                If guid.CompareTo(CType(lvi.Tag, Guid)) = 0 Then
                    lvi.SubItems(4).Text = result
                    lviRet = lvi
                    Exit For
                End If
            End If
        Next lvi

        Return lviRet

    End Function


    Private Function CanCancel() As Boolean
        Dim oneIsActive As Boolean = False

        Dim lvi As ListViewItem
        For Each lvi In Me.listView1.SelectedItems
            If (lvi.Tag IsNot Nothing) Then
                oneIsActive = True
                Exit For
            End If
        Next lvi

        Return oneIsActive = True

    End Function

#End Region


    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.taskGroupBox = New System.Windows.Forms.GroupBox
        Me.buttonPanel = New System.Windows.Forms.Panel
        Me.cancelAsyncButton = New System.Windows.Forms.Button
        Me.startAsyncButton = New System.Windows.Forms.Button
        Me.listView1 = New System.Windows.Forms.ListView
        Me.testNumberColHeader = New System.Windows.Forms.ColumnHeader
        Me.progressColHeader = New System.Windows.Forms.ColumnHeader
        Me.currentColHeader = New System.Windows.Forms.ColumnHeader
        Me.taskIdColHeader = New System.Windows.Forms.ColumnHeader
        Me.resultColHeader = New System.Windows.Forms.ColumnHeader
        Me.firstDivisorColHeader = New System.Windows.Forms.ColumnHeader
        Me.panel2 = New System.Windows.Forms.Panel
        Me.primeNumberCalculator1 = New PrimeNumberCalculator(Me.components)
        Me.taskGroupBox.SuspendLayout()
        Me.buttonPanel.SuspendLayout()
        Me.SuspendLayout()
        ' 
        ' taskGroupBox
        ' 
        Me.taskGroupBox.Controls.Add(Me.buttonPanel)
        Me.taskGroupBox.Controls.Add(Me.listView1)
        Me.taskGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.taskGroupBox.Location = New System.Drawing.Point(0, 0)
        Me.taskGroupBox.Name = "taskGroupBox"
        Me.taskGroupBox.Size = New System.Drawing.Size(608, 254)
        Me.taskGroupBox.TabIndex = 1
        Me.taskGroupBox.TabStop = False
        Me.taskGroupBox.Text = "Tasks"
        ' 
        ' buttonPanel
        ' 
        Me.buttonPanel.Controls.Add(Me.cancelAsyncButton)
        Me.buttonPanel.Controls.Add(Me.startAsyncButton)
        Me.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.buttonPanel.Location = New System.Drawing.Point(3, 176)
        Me.buttonPanel.Name = "buttonPanel"
        Me.buttonPanel.Size = New System.Drawing.Size(602, 75)
        Me.buttonPanel.TabIndex = 1
        ' 
        ' cancelAsyncButton
        ' 
        Me.cancelAsyncButton.Enabled = False
        Me.cancelAsyncButton.Location = New System.Drawing.Point(128, 24)
        Me.cancelAsyncButton.Name = "cancelAsyncButton"
        Me.cancelAsyncButton.Size = New System.Drawing.Size(88, 23)
        Me.cancelAsyncButton.TabIndex = 1
        Me.cancelAsyncButton.Text = "Cancel"
        ' 
        ' startAsyncButton
        ' 
        Me.startAsyncButton.Location = New System.Drawing.Point(24, 24)
        Me.startAsyncButton.Name = "startAsyncButton"
        Me.startAsyncButton.Size = New System.Drawing.Size(88, 23)
        Me.startAsyncButton.TabIndex = 0
        Me.startAsyncButton.Text = "Start New Task"
        ' 
        ' listView1
        ' 
        Me.listView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.testNumberColHeader, Me.progressColHeader, Me.currentColHeader, Me.taskIdColHeader, Me.resultColHeader, Me.firstDivisorColHeader})
        Me.listView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listView1.FullRowSelect = True
        Me.listView1.GridLines = True
        Me.listView1.Location = New System.Drawing.Point(3, 16)
        Me.listView1.Name = "listView1"
        Me.listView1.Size = New System.Drawing.Size(602, 160)
        Me.listView1.TabIndex = 0
        Me.listView1.View = System.Windows.Forms.View.Details
        ' 
        ' testNumberColHeader
        ' 
        Me.testNumberColHeader.Text = "Test Number"
        Me.testNumberColHeader.Width = 80
        ' 
        ' progressColHeader
        ' 
        Me.progressColHeader.Text = "Progress"
        ' 
        ' currentColHeader
        ' 
        Me.currentColHeader.Text = "Current"
        ' 
        ' taskIdColHeader
        ' 
        Me.taskIdColHeader.Text = "Task ID"
        Me.taskIdColHeader.Width = 200
        ' 
        ' resultColHeader
        ' 
        Me.resultColHeader.Text = "Result"
        Me.resultColHeader.Width = 80
        ' 
        ' firstDivisorColHeader
        ' 
        Me.firstDivisorColHeader.Text = "First Divisor"
        Me.firstDivisorColHeader.Width = 80
        ' 
        ' panel2
        ' 
        Me.panel2.Location = New System.Drawing.Point(200, 128)
        Me.panel2.Name = "panel2"
        Me.panel2.TabIndex = 2
        ' 
        ' PrimeNumberCalculatorMain
        '
        Me.ClientSize = New System.Drawing.Size(608, 254)
        Me.Controls.Add(taskGroupBox)
        Me.Name = "PrimeNumberCalculatorMain"
        Me.Text = "Prime Number Calculator"
        Me.taskGroupBox.ResumeLayout(False)
        Me.buttonPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

End Class

' <snippet30>

' <snippet7>
Public Delegate Sub ProgressChangedEventHandler( _
    ByVal e As ProgressChangedEventArgs)

Public Delegate Sub CalculatePrimeCompletedEventHandler( _
    ByVal sender As Object, _
    ByVal e As CalculatePrimeCompletedEventArgs)
' </snippet7>

' This class implements the Event-based Asynchronous Pattern.
' It asynchronously computes whether a number is prime or
' composite (not prime).
Public Class PrimeNumberCalculator
    Inherits System.ComponentModel.Component

    ' <snippet22>
    Private Delegate Sub WorkerEventHandler( _
    ByVal numberToCheck As Integer, _
    ByVal asyncOp As AsyncOperation)
    ' </snippet22>

    ' <snippet9>
    Private onProgressReportDelegate As SendOrPostCallback
    Private onCompletedDelegate As SendOrPostCallback
    ' </snippet9>

    ' <snippet23>
    Private userStateToLifetime As New HybridDictionary()
    ' </snippet23>

    Private components As System.ComponentModel.Container = Nothing

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
#Region "Public events"

    ' <snippet8>
    Public Event ProgressChanged _
        As ProgressChangedEventHandler
    Public Event CalculatePrimeCompleted _
        As CalculatePrimeCompletedEventHandler
    ' </snippet8>

#End Region

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
#Region "Construction and destruction"


    Public Sub New(ByVal container As System.ComponentModel.IContainer)

        container.Add(Me)
        InitializeComponent()

        InitializeDelegates()

    End Sub


    ' <snippet21>
    Public Sub New()

        InitializeComponent()

        InitializeDelegates()

    End Sub
    ' </snippet21>


    ' <snippet20>
    Protected Overridable Sub InitializeDelegates()
        onProgressReportDelegate = _
            New SendOrPostCallback(AddressOf ReportProgress)
        onCompletedDelegate = _
            New SendOrPostCallback(AddressOf CalculateCompleted)
    End Sub
    ' </snippet20>


    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)

    End Sub

#End Region

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
#Region "Implementation"


    ' <snippet3>
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
    ' </snippet3>

    ' <snippet32>
    ' Utility method for determining if a 
    ' task has been canceled.
    Private Function TaskCanceled(ByVal taskId As Object) As Boolean
        Return (userStateToLifetime(taskId) Is Nothing)
    End Function
    ' </snippet32>

    ' <snippet4>
    ' This method cancels a pending asynchronous operation.
    Public Sub CancelAsync(ByVal taskId As Object)

        Dim obj As Object = userStateToLifetime(taskId)
        If (obj IsNot Nothing) Then

            SyncLock userStateToLifetime.SyncRoot

                userStateToLifetime.Remove(taskId)

            End SyncLock

        End If

    End Sub
    ' </snippet4>

    ' <snippet27>
    ' This method performs the actual prime number computation.
    ' It is executed on the worker thread.
    Private Sub CalculateWorker( _
        ByVal numberToTest As Integer, _
        ByVal asyncOp As AsyncOperation)

        Dim prime As Boolean = False
        Dim firstDivisor As Integer = 1
        Dim exc As Exception = Nothing

        ' Check that the task is still active.
        ' The operation may have been canceled before
        ' the thread was scheduled.
        If Not Me.TaskCanceled(asyncOp.UserSuppliedState) Then

            Try
                ' Find all the prime numbers up to the
                ' square root of numberToTest.
                Dim primes As ArrayList = BuildPrimeNumberList( _
                    numberToTest, asyncOp)

                ' Now we have a list of primes less than 
                'numberToTest.
                prime = IsPrime( _
                    primes, _
                    numberToTest, _
                    firstDivisor)

            Catch ex As Exception
                exc = ex
            End Try

        End If

        Me.CompletionMethod( _
            numberToTest, _
            firstDivisor, _
            prime, _
            exc, _
            TaskCanceled(asyncOp.UserSuppliedState), _
            asyncOp)

    End Sub
    ' </snippet27>

    ' <snippet5>
    ' This method computes the list of prime numbers used by the
    ' IsPrime method.
    Private Function BuildPrimeNumberList( _
        ByVal numberToTest As Integer, _
        ByVal asyncOp As AsyncOperation) As ArrayList

        Dim e As ProgressChangedEventArgs = Nothing
        Dim primes As New ArrayList
        Dim firstDivisor As Integer
        Dim n As Integer = 5

        ' Add the first prime numbers.
        primes.Add(2)
        primes.Add(3)

        ' Do the work.
        While n < numberToTest And _
            Not Me.TaskCanceled(asyncOp.UserSuppliedState)

            If IsPrime(primes, n, firstDivisor) Then
                ' Report to the client that you found a prime.
                e = New CalculatePrimeProgressChangedEventArgs( _
                    n, _
                    CSng(n) / CSng(numberToTest) * 100, _
                    asyncOp.UserSuppliedState)

                asyncOp.Post(Me.onProgressReportDelegate, e)

                primes.Add(n)

                ' Yield the rest of this time slice.
                Thread.Sleep(0)
            End If

            ' Skip even numbers.
            n += 2

        End While

        Return primes

    End Function
    ' </snippet5>


    ' <snippet28>
    ' This method tests n for primality against the list of 
    ' prime numbers contained in the primes parameter.
    Private Function IsPrime( _
        ByVal primes As ArrayList, _
        ByVal n As Integer, _
        ByRef firstDivisor As Integer) As Boolean

        Dim foundDivisor As Boolean = False
        Dim exceedsSquareRoot As Boolean = False

        Dim i As Integer = 0
        Dim divisor As Integer = 0
        firstDivisor = 1

        ' Stop the search if:
        ' there are no more primes in the list,
        ' there is a divisor of n in the list, or
        ' there is a prime that is larger than 
        ' the square root of n.
        While i < primes.Count AndAlso _
            Not foundDivisor AndAlso _
            Not exceedsSquareRoot

            ' The divisor variable will be the smallest prime number 
            ' not yet tried.
            divisor = primes(i)
            i = i + 1

            ' Determine whether the divisor is greater than the 
            ' square root of n.
            If divisor * divisor > n Then
                exceedsSquareRoot = True
                ' Determine whether the divisor is a factor of n.
            ElseIf n Mod divisor = 0 Then
                firstDivisor = divisor
                foundDivisor = True
            End If
        End While

        Return Not foundDivisor

    End Function
    ' </snippet28>


    ' <snippet24>
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
    ' </snippet24>


    ' <snippet26>
    ' This is the method that the underlying, free-threaded 
    ' asynchronous behavior will invoke.  This will happen on
    '  an arbitrary thread.
    Private Sub CompletionMethod( _
        ByVal numberToTest As Integer, _
        ByVal firstDivisor As Integer, _
        ByVal prime As Boolean, _
        ByVal exc As Exception, _
        ByVal canceled As Boolean, _
        ByVal asyncOp As AsyncOperation)

        ' If the task was not previously canceled,
        ' remove the task from the lifetime collection.
        If Not canceled Then
            SyncLock userStateToLifetime.SyncRoot
                userStateToLifetime.Remove(asyncOp.UserSuppliedState)
            End SyncLock
        End If

        ' Package the results of the operation in a 
        ' CalculatePrimeCompletedEventArgs.
        Dim e As New CalculatePrimeCompletedEventArgs( _
            numberToTest, _
            firstDivisor, _
            prime, _
            exc, _
            canceled, _
            asyncOp.UserSuppliedState)

        ' End the task. The asyncOp object is responsible 
        ' for marshaling the call.
        asyncOp.PostOperationCompleted(onCompletedDelegate, e)

        ' Note that after the call to PostOperationCompleted, asyncOp
        ' is no longer usable, and any attempt to use it will cause.
        ' an exception to be thrown.

    End Sub
    ' </snippet26>

#End Region


    Private Sub InitializeComponent()

    End Sub


End Class

' <snippet29>
Public Class CalculatePrimeProgressChangedEventArgs
    Inherits ProgressChangedEventArgs
    Private latestPrimeNumberValue As Integer = 1


    Public Sub New( _
        ByVal latestPrime As Integer, _
        ByVal progressPercentage As Integer, _
        ByVal UserState As Object)

        MyBase.New(progressPercentage, UserState)
        Me.latestPrimeNumberValue = latestPrime

    End Sub

    Public ReadOnly Property LatestPrimeNumber() As Integer
        Get
            Return latestPrimeNumberValue
        End Get
    End Property
End Class
' </snippet29>

' <snippet6>
Public Class CalculatePrimeCompletedEventArgs
    Inherits AsyncCompletedEventArgs
    Private numberToTestValue As Integer = 0
    Private firstDivisorValue As Integer = 1
    Private isPrimeValue As Boolean


    Public Sub New( _
    ByVal numberToTest As Integer, _
    ByVal firstDivisor As Integer, _
    ByVal isPrime As Boolean, _
    ByVal e As Exception, _
    ByVal canceled As Boolean, _
    ByVal state As Object)

        MyBase.New(e, canceled, state)
        Me.numberToTestValue = numberToTest
        Me.firstDivisorValue = firstDivisor
        Me.isPrimeValue = isPrime

    End Sub


    Public ReadOnly Property NumberToTest() As Integer
        Get
            ' Raise an exception if the operation failed 
            ' or was canceled.
            RaiseExceptionIfNecessary()

            ' If the operation was successful, return 
            ' the property value.
            Return numberToTestValue
        End Get
    End Property


    Public ReadOnly Property FirstDivisor() As Integer
        Get
            ' Raise an exception if the operation failed 
            ' or was canceled.
            RaiseExceptionIfNecessary()

            ' If the operation was successful, return 
            ' the property value.
            Return firstDivisorValue
        End Get
    End Property


    Public ReadOnly Property IsPrime() As Boolean
        Get
            ' Raise an exception if the operation failed 
            ' or was canceled.
            RaiseExceptionIfNecessary()

            ' If the operation was successful, return 
            ' the property value.
            Return isPrimeValue
        End Get
    End Property
End Class
' </snippet6>
' </snippet30>
' </snippet10>
