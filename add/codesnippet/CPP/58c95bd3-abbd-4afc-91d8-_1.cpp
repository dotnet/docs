            array<Byte>^finalBytes = cryptoTransform->TransformFinalBlock(
               sourceBytes, currentPosition, sourceByteLength - currentPosition );