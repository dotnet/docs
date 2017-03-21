                    Dim streamType As Type = GetType(System.IO.Stream)

                    Dim outputStream As CryptoStream
                    outputStream = CType( _
                        xmlTransform.GetOutput(streamType), _
                        CryptoStream)
