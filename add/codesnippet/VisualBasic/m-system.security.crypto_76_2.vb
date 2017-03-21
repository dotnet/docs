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