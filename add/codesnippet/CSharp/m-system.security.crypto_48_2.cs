// Create a ContentInfo object from the inner content obtained 
// independently from encodedMessage.
ContentInfo contentInfo = new ContentInfo(innerContent);

// Create a new, detached SignedCms message.
SignedCms signedCms = new SignedCms(contentInfo, true);

// encodedMessage is the encoded message received from 
// the sender.
signedCms.Decode(encodedMessage);

// Verify the signature without validating the 
// certificate.
signedCms.CheckSignature(true);