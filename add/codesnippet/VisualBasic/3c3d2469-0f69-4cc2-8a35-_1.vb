        ' Create a new, nondetached SignedCms message.
        Dim signedCms As New SignedCms()

        ' encodedMessage is the encoded message received from 
        ' the sender.
        signedCms.Decode(encodedMessage)

        ' Verify the signature without validating the 
        ' certificate.
        signedCms.CheckSignature(True)