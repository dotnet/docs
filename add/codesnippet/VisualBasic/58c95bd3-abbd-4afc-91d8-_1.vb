                Dim finalBytes() As Byte
                finalBytes = cryptoTransform.TransformFinalBlock( _
                    sourceBytes, _
                    currentPosition, _
                    sourceByteLength - currentPosition)