'<snippet0>
Imports System.IO
Imports System.Xml
Imports System.ServiceModel.Dispatcher
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Xml.XPath

Namespace MessageQueryExamples


    Public Class Program

        Public Shared Sub Main(ByVal args As String())

            ' The XPathMessageQueryCollection inherits from MessageQueryCollection.
            Dim queryCollection As XPathMessageQueryCollection = MessageHelper.SetupQueryCollection()


            ' Create a message and a copy of the message. You must create a buffered copy to access the message body.
            Dim mess As Message = MessageHelper.CreateMessage()
            Dim mb As MessageBuffer = mess.CreateBufferedCopy(Integer.MaxValue)


            ' Evaluate every query in the collection. 
            Dim q As XPathMessageQuery
            For Each q In queryCollection

                ' Evaluate the query. Note the result type is an XPathResult.
                Dim qPathResult As XPathResult = q.Evaluate(Of XPathResult)(mb)

                ' Use the XPathResult to determine the result type.
                Console.WriteLine("Result type: {0}", qPathResult.ResultType)

                ' The following code prints the result according to the result type.

                If qPathResult.ResultType = XPathResultType.String Then
                    Console.WriteLine("{0} = {1}", q.Expression, qPathResult.GetResultAsString())
                End If
                If (qPathResult.ResultType = XPathResultType.NodeSet) Then

                    ' Iterate through the node set.
                    Dim ns As XPathNodeIterator = qPathResult.GetResultAsNodeset()
                    Dim n As XPathNavigator
                    For Each n In ns
                        Console.WriteLine("     {0} = {1}", q.Expression, n.Value)
                    Next
                End If
                If qPathResult.ResultType = XPathResultType.Number Then
                    Console.WriteLine("    {0} = {1}", q.Expression, qPathResult.GetResultAsNumber())
                End If
                If qPathResult.ResultType = XPathResultType.Boolean Then
                    Console.WriteLine("    {0} ={1}", q.Expression, qPathResult.GetResultAsBoolean())
                End If

                If qPathResult.ResultType = XPathResultType.Error Then
                    Console.WriteLine("    Error!")
                End If

            Next

            Console.WriteLine()

            ' The alternate code below demonstrates similar funcionality using a MessageQueryTable.
            ' The difference is the KeyValuePair that requires a key to index each value.
            ' The code uses the expression as the key, and an arbitrary value for the value.           

            'Dim mq As MessageQueryTable(Of String) = MessageHelper.SetupTable()
            'Dim kv As KeyValuePair(Of MessageQuery, String)
            'For Each kv In mq
            '    '
            '    Dim xp As XPathMessageQuery = CType(kv.Key, XPathMessageQuery)
            '    Console.WriteLine("Value = {0}", kv.Value)
            '    Console.WriteLine("{0} = {1}", xp.Expression, xp.Evaluate(Of String)(mb))
            'Next

            Console.ReadLine()
        End Sub
        Private Shared Sub Evaluate(ByVal p1 As Object)
            Throw New NotImplementedException
        End Sub
    End Class

    Public Class MessageHelper

        Shared messageBody As String = _
              "<PurchaseOrder date='today'>" + _
                  "<Number>ABC-2009-XYZ</Number>" + _
                  "<Department>OnlineSales</Department>" + _
                  "<Items>" + _
                      "<Item product='nail' quantity='1'>item1</Item>" + _
                      "<Item product='screw' quantity='2'>item2</Item>" + _
                      "<Item product='brad' quantity='3'>" + _
                          "<SpecialOffer/>" + _
                          "Special item4" + _
                      "</Item>" + _
                      "<Item product='SpecialNails' quantity='9'>item5</Item>" + _
                      "<Item product='SpecialBrads' quantity='11'>" + _
                          "<SpecialOffer/>" + _
                          "Special item6" + _
                      "</Item>" + _
                      "<Item product='hammer' quantity='1'>item7</Item>" + _
                      "<Item product='wrench' quantity='2'>item8</Item>" + _
                  "</Items>" + _
                "<Comments>" + _
                "Rush order" + _
                "</Comments>" + _
              "</PurchaseOrder>"

        Public Shared xpath As String = "/s12:Envelope/s12:Body/PurchaseOrder/Items/Item[@quantity = 1]"
        Public Shared xpath2 As String = "/s12:Envelope/s12:Body/PurchaseOrder/Items/Item[@product = 'nail']"
        Public Shared xpath3 As String = "/s12:Envelope/s12:Body/PurchaseOrder/Comments"
        Public Shared xpath4 As String = "count(/s12:Envelope/s12:Body/PurchaseOrder/Items/Item)"
        Public Shared xpath5 As String = "substring(string(/s12:Envelope/s12:Body/PurchaseOrder/Number),5,4)"
        Public Shared xpath6 As String = "/s12:Envelope/s12:Body/PurchaseOrder/Department='OnlineSales'"
        Public Shared xpath7 As String = "//PurchaseOrder/@date"
        Public Shared xpath8 As String = "//SpecialOffer/ancestor::Item[@product = 'brad']"

        ' Invoke the correlation data function.


        Public Shared xpath9 As String = "sm:correlation-data('CorrelationData1')"
        Public Shared xpath10 As String = "sm:correlation-data('CorrelationData2')"

        Public Shared xpath11 As String = "/s12:Envelope/s12:Body/PurchaseOrder/Items/Item[@quantity = 2]"


        Public Shared Function CreateMessage() As Message

            Dim stringReader As New StringReader(messageBody)
            Dim xmlReader As New XmlTextReader(stringReader)
            Dim message As Message = message.CreateMessage( _
                MessageVersion.Soap12WSAddressing10, "http://purchaseorder", xmlReader)

            ' Add two correlation properties using lambda expressions. The property names are
            ' CorrelationData1 and CorrelationData2. The first goes to "value1" and the
            ' second to "value2". You can use your own property names and values.
            Dim data As New CorrelationDataMessageProperty()

            data.Add("CorrelationData1", Function() "value1")
            data.Add("CorrelationData2", Function() "value2")
            message.Properties(CorrelationDataMessageProperty.Name) = data


            Return message
        End Function


        Public Shared Function SetupQueryCollection() As XPathMessageQueryCollection

            ' Create the query collection and add the XPath queries to it. To create
            ' the query, you must also use a new XPathMessageContext.

            Dim queryCollection As New XPathMessageQueryCollection()

            Dim context As XPathMessageContext = New XPathMessageContext()
            queryCollection.Add(New XPathMessageQuery(xpath, context))
            queryCollection.Add(New XPathMessageQuery(xpath2, context))
            queryCollection.Add(New XPathMessageQuery(xpath3, context))
            queryCollection.Add(New XPathMessageQuery(xpath4, context))
            queryCollection.Add(New XPathMessageQuery(xpath5, context))
            queryCollection.Add(New XPathMessageQuery(xpath6, context))
            queryCollection.Add(New XPathMessageQuery(xpath7, context))
            queryCollection.Add(New XPathMessageQuery(xpath8, context))
            queryCollection.Add(New XPathMessageQuery(xpath9, context))
            queryCollection.Add(New XPathMessageQuery(xpath10, context))
            queryCollection.Add(New XPathMessageQuery(xpath11, context))

            Return queryCollection
        End Function

        Public Shared Function SetupTable() As MessageQueryTable(Of String)

            ' This is optional code to demonstrate using a MessageQueryTable.
            ' Compare this to the MessageQueryCollection.
            Dim table As MessageQueryTable(Of String) = New MessageQueryTable(Of String)()
            Dim context As XPathMessageContext = New XPathMessageContext()


            ' The code adds a KeyValuePair to the table. Each pair requires
            ' a query used as the Key, and a value that is paired to the key.
            table.Add(New XPathMessageQuery(xpath, context), "value10")
            table.Add(New XPathMessageQuery(xpath2, context), "value20")
            table.Add(New XPathMessageQuery(xpath3, context), "value30")
            table.Add(New XPathMessageQuery(xpath4, context), "value40")
            table.Add(New XPathMessageQuery(xpath5, context), "value50")
            table.Add(New XPathMessageQuery(xpath6, context), "value60")
            table.Add(New XPathMessageQuery(xpath7, context), "value70")
            table.Add(New XPathMessageQuery(xpath8, context), "value80")
            table.Add(New XPathMessageQuery(xpath9, context), "value90")
            table.Add(New XPathMessageQuery(xpath10, context), "value100")
            table.Add(New XPathMessageQuery(xpath11, context), "value110")
            Return table
        End Function
    End Class
End Namespace
'</snippet0>
