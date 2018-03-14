' <Snippet1>
Imports System
Imports System.Collections.ObjectModel
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Dispatcher

Namespace UE.Wfc.Samples
    Class ActionMessageFilterMatching

        Shared Sub Main()

            ' Create several action filters.
            ' <Snippet2>
            Dim myActFltr As ActionMessageFilter = New ActionMessageFilter("1st Action", "2nd Action")
            '</Snippet2>
            Dim yourACtFltr As ActionMessageFilter = New ActionMessageFilter("Your Action")

            ' Display the ActionMessageFilter actions.
            Dim results As ReadOnlyCollection(Of String) = myActFltr.Actions

            For Each result As String In results
                System.Console.WriteLine(result)
            Next

            ' Create a message.
            Dim message As Message = Channels.Message.CreateMessage(MessageVersion.Soap11WSAddressing10, "myBody")

            ' Test the message action against a single action filter.
            Dim test1 As Boolean = myActFltr.Match(message)
            Dim test2 As Boolean = yourACtFltr.Match(message)
            System.Console.WriteLine("The result of test1 is {0}", test1)
            System.Console.WriteLine("The result of test2 is {0}", test2)

        End Sub
    End Class
End Namespace
' </Snippet1>
