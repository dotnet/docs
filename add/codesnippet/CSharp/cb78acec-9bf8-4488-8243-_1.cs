                    numBytesRead = cryptoTransform.TransformBlock(
                        sourceBytes,
                        currentPosition,
                        inputBlockSize,
                        targetBytes,
                        currentPosition);