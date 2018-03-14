' <Snippet1>
Imports System
Imports System.Messaging

Public Class MyNewQueue


        
        ' Provides an entry point into the application.
        '		 
        ' This example demonstrates several ways to set
        ' a queue's path.
        

        Public Shared Sub Main()

            ' Create a new instance of the class.
            Dim myNewQueue As New MyNewQueue()

            myNewQueue.SendPublic()
            myNewQueue.SendPrivate()
            myNewQueue.SendByLabel()
            myNewQueue.SendByFormatName()
            myNewQueue.MonitorComputerJournal()
            myNewQueue.MonitorQueueJournal()
            myNewQueue.MonitorDeadLetter()
            myNewQueue.MonitorTransactionalDeadLetter()

            Return

        End Sub 'Main


        ' References public queues.
        Public Sub SendPublic()

            Dim myQueue As New MessageQueue(".\myQueue")
            myQueue.Send("Public queue by path name.")

            Return

        End Sub 'SendPublic


        ' References private queues.
        Public Sub SendPrivate()

            Dim myQueue As New MessageQueue(".\Private$\myQueue")
            myQueue.Send("Private queue by path name.")

            Return

        End Sub 'SendPrivate


        ' References queues by label.
        Public Sub SendByLabel()

            Dim myQueue As New MessageQueue("Label:TheLabel")
            myQueue.Send("Queue by label.")

            Return

        End Sub 'SendByLabel


        ' References queues by format name.
        Public Sub SendByFormatName()

            Dim myQueue As New _
                MessageQueue("FormatName:Public=" + _
                    "5A5F7535-AE9A-41d4-935C-845C2AFF7112")
            myQueue.Send("Queue by format name.")

            Return

        End Sub 'SendByFormatName


        ' References computer journal queues.
        Public Sub MonitorComputerJournal()

            Dim computerJournal As New MessageQueue(".\Journal$")

            While True

                Dim journalMessage As Message = _
                    computerJournal.Receive()

                ' Process the journal message.

            End While

            Return
        End Sub 'MonitorComputerJournal


        ' References queue journal queues.
        Public Sub MonitorQueueJournal()

            Dim queueJournal As New _
                            MessageQueue(".\myQueue\Journal$")

            While True

                Dim journalMessage As Message = _
                    queueJournal.Receive()

                ' Process the journal message.

            End While

            Return
        End Sub 'MonitorQueueJournal


        ' References dead-letter queues.
        Public Sub MonitorDeadLetter()
            Dim deadLetter As New MessageQueue(".\DeadLetter$")

            While True

                Dim deadMessage As Message = deadLetter.Receive()

                ' Process the dead-letter message.

            End While

            Return

        End Sub 'MonitorDeadLetter


        ' References transactional dead-letter queues.
        Public Sub MonitorTransactionalDeadLetter()

            Dim TxDeadLetter As New MessageQueue(".\XactDeadLetter$")

            While True

                Dim txDeadLetterMessage As Message = _
                    TxDeadLetter.Receive()

                ' Process the transactional dead-letter message.

            End While

            Return

        End Sub 'MonitorTransactionalDeadLetter

End Class 'MyNewQueue 

' </Snippet1>