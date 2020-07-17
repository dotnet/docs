'<SnippetThreadingPrimeNumberCodeBehind>
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Threading
Imports System.Threading

Namespace SDKSamples
    Partial Public Class MainWindow
        Inherits Window
        '<SnippetThreadingPrimeNumberInit>
        Public Delegate Sub NextPrimeDelegate()
        '</SnippetThreadingPrimeNumberInit>

        'Current number to check 
        Private num As Long = 3

        Private continueCalculating As Boolean = False

        Public Sub New()
            MyBase.New()
            InitializeComponent()
        End Sub

        '<SnippetThreadingPrimeNumberStartOrStop>
        Private Sub StartOrStop(ByVal sender As Object, ByVal e As EventArgs)
            If continueCalculating Then
                continueCalculating = False
                startStopButton.Content = "Resume"
            Else
                continueCalculating = True
                startStopButton.Content = "Stop"
                '<SnippetThreadingPrimeNumberBeginInvoke>
                startStopButton.Dispatcher.BeginInvoke(DispatcherPriority.Normal, New NextPrimeDelegate(AddressOf CheckNextNumber))
                '</SnippetThreadingPrimeNumberBeginInvoke>
            End If
        End Sub
        '</SnippetThreadingPrimeNumberStartOrStop>

        '<SnippetThreadingPrimeNumberCheckNextNumber>
        Public Sub CheckNextNumber()
            ' Reset flag.
            NotAPrime = False

            For i As Long = 3 To Math.Sqrt(num)
                If num Mod i = 0 Then
                    ' Set not a prime flag to true.
                    NotAPrime = True
                    Exit For
                End If
            Next

            ' If a prime number.
            If Not NotAPrime Then
                bigPrime.Text = num.ToString()
            End If

            num += 2
            If continueCalculating Then
                startStopButton.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.SystemIdle, New NextPrimeDelegate(AddressOf Me.CheckNextNumber))
            End If
        End Sub

        Private NotAPrime As Boolean = False
        '</SnippetThreadingPrimeNumberCheckNextNumber>
    End Class
End Namespace
'</SnippetThreadingPrimeNumberCodeBehind>
