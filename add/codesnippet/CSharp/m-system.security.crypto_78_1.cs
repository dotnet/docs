// The dataToSign byte array holds the data to be signed.
ContentInfo contentInfo = new ContentInfo(dataToSign);

// Create a new, nondetached SignedCms message.
SignedCms signedCms = new SignedCms(contentInfo);

// Sign the message.
signedCms.ComputeSignature();

// Encode the message.
byte[] myCmsMessage = signedCms.Encode();

// The signed CMS/PKCS #7 message is ready to send.
// The original content is included in this byte array.