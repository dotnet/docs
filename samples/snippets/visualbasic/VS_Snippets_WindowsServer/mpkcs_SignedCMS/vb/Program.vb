#Region "Using directives"

Imports System
Imports System.Security.Cryptography.Pkcs

#End Region

Module Module1

    Sub Main()

    End Sub

    Sub Test_CheckSignature1(ByVal encodedMessage() As Byte)
        '<Snippet1>
        ' Create a new, nondetached SignedCms message.
        Dim signedCms As New SignedCms()

        ' encodedMessage is the encoded message received from 
        ' the sender.
        signedCms.Decode(encodedMessage)

        ' Verify the signature without validating the 
        ' certificate.
        signedCms.CheckSignature(True)
        '</Snippet1>
    End Sub 'Test_CheckSignature1

    Sub Test_CheckSignature2(ByVal innerContent() As Byte, ByVal encodedMessage() As Byte)
        '<Snippet2>
        ' Create a ContentInfo object from the inner content obtained 
        ' independently from encodedMessage.
        Dim contentInfo As New ContentInfo(innerContent)

        ' Create a new, detached SignedCms message.
        Dim signedCms As New SignedCms(contentInfo, True)

        ' encodedMessage is the encoded message received from 
        ' the sender.
        signedCms.Decode(encodedMessage)

        ' Verify the signature without validating the 
        ' certificate.
        signedCms.CheckSignature(True)
        '</Snippet2>
    End Sub 'Test_CheckSignature2

    Sub Test_ComputeSignature1(ByVal dataToSign() As Byte)
        '<Snippet3>
        ' The dataToSign byte array holds the data to be signed.
        Dim contentInfo As New ContentInfo(dataToSign)

        ' Create a new, nondetached SignedCms message.
        Dim signedCms As New SignedCms(contentInfo)

        ' Sign the message.
        signedCms.ComputeSignature()

        ' Encode the message.
        Dim myCmsMessage As Byte() = signedCms.Encode()

        ' The signed CMS/PKCS #7 message is ready to send.
        ' The original content is included in this byte array.
        '</Snippet3>
    End Sub 'Test_ComputeSignature1

    Sub Test_ComputeSignature2(ByVal dataToSign() As Byte)
        '<Snippet4>
        ' The dataToSign byte array holds the data to be signed.
        Dim contentInfo As New ContentInfo(dataToSign)

        ' Create a new, detached SignedCms message.
        Dim signedCms As New SignedCms(contentInfo, True)

        ' Sign the message.
        signedCms.ComputeSignature()

        ' Encode the message.
        Dim myCmsMessage As Byte() = signedCms.Encode()

        ' The signed CMS/PKCS #7 message is ready to send.
        ' The original content is not included in this byte array.
        '</Snippet4>
    End Sub 'Test_ComputeSignature2 

End Module
