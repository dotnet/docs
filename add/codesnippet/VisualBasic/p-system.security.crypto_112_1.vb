        Public Overrides Property KeySize() As Integer
            Get
                Return KeySizeValue
            End Get
            Set(ByVal Value As Integer)
                For i As Int16 = 0 To keySizes.Length - 1 Step i
                    If (keySizes(i).SkipSize.Equals(0)) Then
                        If (keySizes(i).MinSize.Equals(Value)) Then
                            KeySizeValue = Value
                            Return
                        End If
                    Else
                        For j As Integer = keySizes(i).MinSize _
                            To keySizes(i).MaxSize _
                            Step keySizes(i).SkipSize
                            If (j.Equals(Value)) Then
                                KeySizeValue = Value
                                Return
                            End If
                        Next
                    End If
                Next
                ' If the key does not fall within the range identified 
                ' in the keySizes member variable, throw an exception.
                Throw New CryptographicException("Invalid key size.")
            End Set
        End Property