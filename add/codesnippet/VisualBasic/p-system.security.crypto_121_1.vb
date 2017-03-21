        Public Overrides Property Key() As Byte()
            Get
                Return CType(keyedCrypto.Key.Clone(), Byte())
            End Get
            Set(ByVal Value As Byte())
                keyedCrypto.Key = CType(Value.Clone(), Byte())
            End Set
        End Property