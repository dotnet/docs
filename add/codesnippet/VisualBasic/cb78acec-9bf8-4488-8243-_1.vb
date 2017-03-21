                    numBytesRead = cryptoTransform.TransformBlock( _
                        sourceBytes, _
                        currentPosition, _
                        inputBlockSize, _
                        targetBytes, _
                        currentPosition)