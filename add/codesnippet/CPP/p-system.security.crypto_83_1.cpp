        public:
            property String^ KeyExchangeAlgorithm 
            {
                virtual String^ get() override
                {
                    return "RSA-PKCS1-KeyEx";
                }
            }