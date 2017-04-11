
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel
Imports System.ServiceModel.Channels

Module Module1
    Sub Main(ByVal args() As String)
        ' <Snippet0>
        Dim msgVersion As MessageVersion = MessageVersion.Default
        ' </Snippet0>


        ' <Snippet1>
        Dim addrVersion As AddressingVersion = msgVersion.Addressing
        ' </Snippet1>

        ' <Snippet2>
        Dim envVersion As EnvelopeVersion = msgVersion.Envelope
        ' </Snippet2>

        ' <Snippet3>
        msgVersion.ToString()
        ' </Snippet3>

        ' <Snippet4>
        Dim msgVersion2 As MessageVersion = MessageVersion.None
        ' </Snippet4>

        ' <Snippet5>
        msgVersion = MessageVersion.Soap11
        ' </Snippet5>

        ' <Snippet6>
        msgVersion = MessageVersion.Soap11WSAddressing10
        ' </Snippet6>

        ' <Snippet7>
        msgVersion = MessageVersion.Soap11WSAddressingAugust2004
        ' </Snippet7>

        ' <Snippet8>
        msgVersion = MessageVersion.Soap12
        ' </Snippet8>

        ' <Snippet9>
        msgVersion = MessageVersion.Soap12WSAddressing10
        ' </Snippet9>

        ' <Snippet10>
        msgVersion = MessageVersion.Soap12WSAddressingAugust2004
        ' </Snippet10>

        ' <Snippet11>
        msgVersion = MessageVersion.CreateVersion(envVersion)
        ' </Snippet11>

        ' <Snippet12>
        msgVersion = MessageVersion.CreateVersion(envVersion, addrVersion)
        ' </Snippet12>

        ' <Snippet13>
        msgVersion.Equals(msgVersion2)
        ' </Snippet13>

        ' <Snippet14>
        msgVersion.GetHashCode()
        ' </Snippet14>




    End Sub
End Module
