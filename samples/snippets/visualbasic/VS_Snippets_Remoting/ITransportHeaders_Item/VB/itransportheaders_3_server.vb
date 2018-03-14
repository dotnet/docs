' System.Runtime.Remoting.Channels.ITransportHeaders
' System.Runtime.Remoting.Channels.ITransportHeaders.Item
' System.Runtime.Remoting.Channels.ITransportHeaders.GetEnumerator()

' The following program demonstrates the 'ITransportHeaders' interface,
' its 'Item' property and 'GetEnumerator' method. It implements the 'Item'
' property and 'GetEnumerator' method in a class derived from 'ITransportHeaders'
' interface. It then adds a few headers to the header list and displays them.

' <Snippet1>

Imports System
Imports System.Collections
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp

Class MyITransportHeadersClass
   Implements ITransportHeaders
' <Snippet2>
' <Snippet3>
   Private myInt As Integer = 0
   Private myDictionaryEntry(9) As DictionaryEntry
   ' Implement the 'Item' property.
   Property ITransportHeaders(myKey As Object) As Object Implements ITransportHeaders.Item
      Get
         If Not (myKey Is Nothing) Then
            Dim i As Integer
            For i = 0 To myInt
               If myDictionaryEntry(i).Key = myKey Then
                  Return myDictionaryEntry(i).Value
               End If
            Next i
         End If
         Return 0
      End Get
      Set
         myDictionaryEntry(myInt) = New DictionaryEntry(myKey, value)
         myInt += 1
      End Set
   End Property

   ' Implement the 'GetEnumerator' method.
   Function GetEnumerator() As IEnumerator  Implements ITransportHeaders.GetEnumerator
      Dim myHashtable As New Hashtable()
      Dim j As Integer
      For j = 0 To myInt - 1
         myHashtable.Add(myDictionaryEntry(j).Key, myDictionaryEntry(j).Value)
      Next j
      Return myHashtable.GetEnumerator()
   End Function 'ITransportHeaders.GetEnumerator

   Public Shared Sub Main()
      Try
         ' Create and register a 'TcpChannel' object.
         Dim myTcpChannel As New TcpChannel(8085)
         ChannelServices.RegisterChannel(myTcpChannel)
         RemotingConfiguration.RegisterWellKnownServiceType(GetType(MyHelloServer), "SayHello", _
                                                         WellKnownObjectMode.SingleCall)
         ' Create an instance of 'myITransportHeadersObj'.
         Dim myITransportHeadersObj As New MyITransportHeadersClass()
         Dim myITransportHeaders As ITransportHeaders = _
                                              CType(myITransportHeadersObj, ITransportHeaders)
         ' Add items to the header list.
         myITransportHeaders("Header1") = "TransportHeader1"
         myITransportHeaders("Header2") = "TransportHeader2"
         ' Get the 'ITranportHeader' item value with key 'Header2'.
         Console.WriteLine("ITransport Header item value with key 'Header2' is :" + _
                                                        myITransportHeaders("Header2"))
         Dim myEnumerator As IEnumerator = myITransportHeaders.GetEnumerator()
         Console.WriteLine("     -KEY-      -VALUE-")
         While myEnumerator.MoveNext()
            ' Display the 'Key' and 'Value' of the current element.
            Dim myEntry As Object = myEnumerator.Current
            Dim myDictionaryEntry As DictionaryEntry = CType(myEntry, DictionaryEntry)
            Console.WriteLine("   {0}:   {1}", myDictionaryEntry.Key, myDictionaryEntry.Value)
         End While
         Console.WriteLine("Hit <enter> to exit...")
         Console.ReadLine()
      Catch ex As Exception
         Console.WriteLine("The following exception is raised on the server side: " + ex.Message)
      End Try
   End Sub 'Main
' </Snippet3>
' </Snippet2>
End Class 'MyITransportHeadersClass

' </Snippet1>