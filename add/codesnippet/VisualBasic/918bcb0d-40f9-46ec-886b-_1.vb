            Dim inputBlockSize As Integer = base64Transform.InputBlockSize

            While (inputBytes.Length - inputOffset > inputBlockSize)
                base64Transform.TransformBlock( _
                    inputBytes, _
                    inputOffset, _
                    inputBytes.Length - inputOffset, _
                    outputBytes, _
                    0)

                inputOffset += base64Transform.InputBlockSize
                outputFileStream.Write(outputBytes, _
                    0, _
                    base64Transform.OutputBlockSize)
            End While