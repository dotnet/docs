                    Dim streamType As Type = GetType(System.IO.Stream)
                    Dim outputStream As MemoryStream
                    outputStream = CType( _
                        xmlTransform.GetOutput(streamType), _
                        MemoryStream)