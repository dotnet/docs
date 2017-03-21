            // The create function attempts to create a CustomCrypto 
            // object using the assembly name. This functionality requires 
            // modification of the machine.config file. Add the following 
            // section to the configuration element and modify the values 
            // of the cryptoClass to reflect what isinstalled 
            // in your machines GAC.
            //<mscorlib>
            //  <cryptographySettings>
            //    <cryptoNameMapping>
            //      <cryptoClasses>
            //        <cryptoClass CustomCrypto="Contoso.CustomCrypto,
            //          CustomCrypto,
            //          Culture=neutral,
            //          PublicKeyToken=fdb9f9c4851028bf,
            //          Version=1.0.1448.27640" />
            //      </cryptoClasses>
            //      <nameEntry name="Contoso.CustomCrypto" 
            //         class="CustomCrypto" />
            //      <nameEntry name="CustomCrypto" class="CustomCrypto" />
            //    </cryptoNameMapping>
            //  </cryptographySettings>
            //</mscorlib>

        public:
            static CustomCrypto^ Create() 
            {
                return Create("CustomCrypto");
            }