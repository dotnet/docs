        public override byte[] Key
        {
            get
            {
                return (byte[]) keyedCrypto.Key.Clone();
            }
            set
            {
                keyedCrypto.Key = (byte[]) value.Clone();
            }
        }