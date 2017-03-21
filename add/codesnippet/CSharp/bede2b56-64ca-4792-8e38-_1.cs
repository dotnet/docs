        public override void SetKey(AsymmetricAlgorithm key) {
            if (key != null)
            {
                rsaKey = (RSA)key;
            }
            else
            {
                throw new ArgumentNullException("key");
            }
        }