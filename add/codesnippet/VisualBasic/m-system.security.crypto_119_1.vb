        ' The create function attempts to create a vbCustomCrypto object using
        ' the assembly name. This functionality requires modification of the
        ' machine.config file. Add the following section to the configuration
        ' element and modify the values of the cryptoClass to reflect what is
        ' installed in your machines GAC.
        '<mscorlib>
        '    <cryptographySettings>
        '      <cryptoNameMapping>
        '        <cryptoClasses>
        '          <cryptoClass vbCustomCrypto="Contoso.vbCustomCrypto, 
        '            vbCustomCrypto, 
        '            Culture=neutral, 
        '            PublicKeyToken=fdb9f9c4851028bf, 
        '            Version=1.0.1448.27640" />
        '        </cryptoClasses>
        '        <nameEntry name="Contoso.vbCustomCrypto" 
        '                   class="vbCustomCrypto" />
        '        <nameEntry name="vbCustomCrypto" class="vbCustomCrypto" />
        '      </cryptoNameMapping>
        '    </cryptographySettings>
        '</mscorlib>
        Public Shadows Function Create( _
            ByVal algorithmName As String) As vbCustomCrypto

            Return CType( _
                CryptoConfig.CreateFromName(algorithmName), _
                vbCustomCrypto)

        End Function