                byte[] finalBytes = cryptoTransform.TransformFinalBlock(
                    sourceBytes,
                    currentPosition,
                    sourceByteLength - currentPosition);