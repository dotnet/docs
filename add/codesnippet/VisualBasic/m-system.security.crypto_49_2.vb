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