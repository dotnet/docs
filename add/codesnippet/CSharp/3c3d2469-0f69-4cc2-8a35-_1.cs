// Create a new, nondetached SignedCms message.
SignedCms signedCms = new SignedCms();

// encodedMessage is the encoded message received from 
// the sender.
signedCms.Decode(encodedMessage);

// Verify the signature without validating the 
// certificate.
signedCms.CheckSignature(true);