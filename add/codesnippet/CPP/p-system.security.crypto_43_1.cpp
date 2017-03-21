        public:
            property String^ SignatureAlgorithm
            {
                virtual String^ get() override
                {
                    return "http://www.w3.org/2000/09/xmldsig#rsa-sha1";
                }
            }