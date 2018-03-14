' This class creates a custom crytographic object based on the asymmetric
' algorithm by extending the abstract base class AsymmetricAlgorithm.
'<Snippet2>
Imports System
Imports System.Xml
Imports System.Text
Imports System.Security.Cryptography
Imports System.Reflection

<Assembly: AssemblyKeyFile("CustomCrypto.snk")> 
<Assembly: AssemblyVersion("1.0.0.0")> 
<Assembly: CLSCompliant(True)> 
Namespace Contoso
    ' Define a vbCustomCrypto class that inherits from the AsymmetricAlgorithm
    ' class.
    Class vbCustomCrypto
        Inherits System.Security.Cryptography.AsymmetricAlgorithm

        ' Declare local member variables.
        Private cspParameters As CspParameters
        Private ReadOnly keySizes() As keySizes = {New keySizes(8, 64, 8)}

        ' Initialize a vbCustomCrypto with the default key size of 8.
        Public Sub New()
            Me.KeySize = 8
        End Sub

        ' Initialize a vbCustomCrypto with the specified key size.
        Public Sub New(ByVal keySize As Integer)
            Me.KeySize = keySize
        End Sub

        ' Modify the KeySizeValue property inherited from the Asymmetric
        ' class. Prior to setting the value, ensure it falls within the
        ' range identified in the local keySizes member variable.
        '<Snippet9>
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
        '</Snippet9>
        ' Accessor function for keySizes member variable.
        public Overrides Readonly Property LegalKeySizes as KeySizes()
            Get
                Return keySizes
            End Get
        End Property
        ' Initialize the parameters with default values.
        Public Sub InitializeParameters()
            cspParameters = New CspParameters
            cspParameters.ProviderName = "Contoso"
            cspParameters.KeyContainerName = "SecurityBin1"
            cspParameters.KeyNumber = 1
            cspParameters.ProviderType = 2
        End Sub

        ' Parse specified xmlString for values to populate the CspParams
        '<Snippet4>
        ' Expected XML schema:
        '  <CustomCryptoKeyValue>
        '      <ProviderName></ProviderName>
        '      <KeyContainerName></KeyContainerName>
        '      <KeyNumber></KeyNumber>
        '      <ProviderType></ProviderType>
        '  </CustomCryptoKeyValue>
        Public Overrides Sub FromXmlString(ByVal xmlString As String)
            If Not xmlString Is Nothing Then
                Dim doc As New XmlDocument
                doc.LoadXml(xmlString)
                Dim firstNode As XmlNode = doc.FirstChild
                Dim nodeList As XmlNodeList

                ' Assemble parameters from values in each XML element.
                cspParameters = New CspParameters

                ' KeyContainerName is optional.
                nodeList = doc.GetElementsByTagName("KeyContainerName")
                Dim keyName As String = nodeList.Item(0).InnerText
                If Not keyName Is Nothing Then
                    cspParameters.KeyContainerName = keyName
                End If

                ' KeyNumber is optional.
                nodeList = doc.GetElementsByTagName("KeyNumber")
                Dim keyNumber As String = nodeList.Item(0).InnerText
                If Not keyNumber Is Nothing Then
                    cspParameters.KeyNumber = Int32.Parse(keyNumber)
                End If

                ' ProviderName is optional.
                nodeList = doc.GetElementsByTagName("ProviderName")
                Dim providerName As String = nodeList.Item(0).InnerText
                If Not providerName Is Nothing Then
                    cspParameters.ProviderName = providerName
                End If

                ' ProviderType is optional.
                nodeList = doc.GetElementsByTagName("ProviderType")
                Dim providerType As String = nodeList.Item(0).InnerText
                If Not providerType Is Nothing Then
                    cspParameters.ProviderType = Int32.Parse(providerType)
                End If
            Else
                Throw New ArgumentNullException("xmlString")
            End If
        End Sub
        '</Snippet4>

        ' Create an XML string representation of the parameters in the current
        ' vbCustomCrypto object.
        '<Snippet5>
        Public Overrides Function ToXmlString( _
            ByVal includePrivateParameters As Boolean) As String

            Dim keyContainerName As String = ""
            Dim keyNumber As String = ""
            Dim providerName As String = ""
            Dim providerType As String = ""

            If Not cspParameters Is Nothing Then
                keyContainerName = cspParameters.KeyContainerName
                keyNumber = cspParameters.KeyNumber.ToString()
                providerName = cspParameters.ProviderName
                providerType = cspParameters.ProviderType.ToString()
            End If

            Dim xmlBuilder As New StringBuilder
            xmlBuilder.Append("<CustomCryptoKeyValue>")

            xmlBuilder.Append("<KeyContainerName>")
            xmlBuilder.Append(keyContainerName)
            xmlBuilder.Append("</KeyContainerName>")

            xmlBuilder.Append("<KeyNumber>")
            xmlBuilder.Append(keyNumber)
            xmlBuilder.Append("</KeyNumber>")

            xmlBuilder.Append("<ProviderName>")
            xmlBuilder.Append(providerName)
            xmlBuilder.Append("</ProviderName>")

            xmlBuilder.Append("<ProviderType>")
            xmlBuilder.Append(providerType)
            xmlBuilder.Append("</ProviderType>")

            xmlBuilder.Append("</CustomCryptoKeyValue>")
            Return (xmlBuilder.ToString())
        End Function
        '</Snippet5>

        ' Return the name for the key exchange algorithm.
        '<Snippet6>
        Public Overrides ReadOnly Property KeyExchangeAlgorithm() As String
            Get
                Return "RSA-PKCS1-KeyEx"
            End Get
        End Property
        '</Snippet6>

        ' Retrieves the name of the signature alogrithm.
        '<Snippet7>
        Public Overrides ReadOnly Property SignatureAlgorithm() As String
            Get
                Return "http://www.w3.org/2000/09/xmldsig#rsa-sha1"
            End Get
        End Property
        '</Snippet7>

        ' Required member for implementing the AsymmetricAlgorithm class.
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)

        End Sub

        '<Snippet11>
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
        Public Shadows Function Create() As vbCustomCrypto
            Return Create("vbCustomCrypto")
        End Function
        '</Snippet11>

        ' Create a CustomCrypto object by calling CrytoConfig's
        ' CreateFromName method and casting the type to CustomCrypto.
        '<Snippet12>
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
        '</Snippet12>
    End Class
'<Snippet3>
    Class Form1
        Inherits System.Windows.Forms.Form

        ' Event handler for Run button.
        Private Sub Button1_Click( _
            ByVal sender As System.Object, _
            ByVal e As System.EventArgs) Handles Button1.Click

            tbxOutput.Cursor = Cursors.WaitCursor
            tbxOutput.Text = ""

            ' Construct a CustomCrypto object and initialize its
            ' CspParameters.
            Dim customCrypto As New Contoso.vbCustomCrypto
            customCrypto.InitializeParameters()

            ' Display properties of the current vbCustomCrypto object.
            WriteLine("*** CustomCrypto created with default parameters:")
            DisplayProperties(customCrypto)

            ' Release all the resources used by this instance of CustomCrytpo.
            '<Snippet1>
            customCrypto.Clear()
            '</Snippet1>

            customCrypto = New Contoso.vbCustomCrypto(64)
            ' Create new parameters and set them by using the
            ' FromXmlString method.
            Dim parameterXml As String = "<CustomCryptoKeyValue>"
            parameterXml += "<ProviderName>Contoso</ProviderName>"
            parameterXml += "<KeyContainerName>SecurityBin2"
            parameterXml += "</KeyContainerName>"
            parameterXml += "<KeyNumber>1</KeyNumber>"
            parameterXml += "<ProviderType>2</ProviderType>"
            parameterXml += "</CustomCryptoKeyValue>"
            customCrypto.FromXmlString(parameterXml)

            ' Display the properties of a customCrypto object created with
            ' custom parameters.
            WriteLine(vbCrLf + "*** " + _
                "CustomCrypto created with custom parameters:")
            DisplayProperties(customCrypto)

            ' Create an object by using the assembly name.
            Try
                Dim createdCrypto As Contoso.vbCustomCrypto
                createdCrypto = customCrypto.Create("vbCustomCrypto")

                If (Not createdCrypto Is Nothing) Then
                    Write(vbCrLf + "*** Successfully created vbCustomCrytpo ")
                    WriteLine("from the Create method.")

                    DisplayProperties(createdCrypto)
                Else
                    Write("Unable to create CustomCrytpo from ")
                    WriteLine(" the Create method.")
                End If
            Catch ex As Exception
                WriteLine(ex.ToString())
            End Try

            ' Align interface and conclude application.
            WriteLine("This sample completed successfully;" + _
                " press Exit to continue.")

            ' Reset the cursor.
            tbxOutput.Cursor = Cursors.Default
        End Sub
        ' Display the properties of the specified CustomCrypto object to
        ' the output texbox.
        Public Sub DisplayProperties( _
            ByVal customCrypto As Contoso.vbCustomCrypto)

            Try
                ' Retrieve the class description for the customCrypto object.
                '<Snippet8>
                Dim classDescription As String = customCrypto.ToString()
                '</Snippet8>

                WriteLine(classDescription)
                WriteLine("KeyExchangeAlgorithm: " + _
                    customCrypto.KeyExchangeAlgorithm)
                WriteLine("SignatureAlgorithm: " + _
                    customCrypto.SignatureAlgorithm)
                WriteLine("KeySize: " + customCrypto.KeySize.ToString())
                WriteLine("Parameters described in Xml format:")
                WriteLine(customCrypto.ToXmlString(True))

                ' Display the MinSize, MaxSize, and SkipSize properties of 
                ' each KeySize item in the local keySizes member variable.
                '<Snippet10>
                Dim legalKeySizes() As KeySizes = customCrypto.LegalKeySizes
                If (legalKeySizes.Length > 0) Then
                    For i As Integer = 0 To legalKeySizes.Length - 1 Step 1
                        Write("Keysize" + i.ToString() + " min, max, step: ")
                        Write(legalKeySizes(i).MinSize.ToString() + ", ")
                        Write(legalKeySizes(i).MaxSize.ToString() + ", ")
                        Write(legalKeySizes(i).SkipSize.ToString() + ", ")
                        WriteLine("")
                    Next
                End If
                '</Snippet10>
            Catch ex As Exception
                WriteLine("Caught unexpected exception: " + ex.ToString())
            End Try
        End Sub
        ' Write the specified message and carriage return to the output
        ' textbox.
        Private Sub WriteLine(ByVal message As String)
            tbxOutput.AppendText(message + vbCrLf)
        End Sub
        ' Write the specified message to the output textbox.
        Private Sub Write(ByVal message As String)
            tbxOutput.AppendText(message)
        End Sub
        ' Event handler for Exit button.
        Private Sub Button2_Click( _
            ByVal sender As System.Object, _
            ByVal e As System.EventArgs) Handles Button2.Click

            Application.Exit()
        End Sub


        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form 
        'Designer. It can be modified using the Windows Form Designer. 
        'Do not modify it using the code editor.
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents tbxOutput As System.Windows.Forms.RichTextBox
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.Panel2 = New System.Windows.Forms.Panel
            Me.Button1 = New System.Windows.Forms.Button
            Me.Button2 = New System.Windows.Forms.Button
            Me.Panel1 = New System.Windows.Forms.Panel
            Me.tbxOutput = New System.Windows.Forms.RichTextBox
            Me.Panel2.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'Panel2
            '
            Me.Panel2.Controls.Add(Me.Button1)
            Me.Panel2.Controls.Add(Me.Button2)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel2.DockPadding.All = 20
            Me.Panel2.Location = New System.Drawing.Point(0, 320)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(616, 64)
            Me.Panel2.TabIndex = 1
            '
            'Button1
            '
            Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
            Me.Button1.Font = New System.Drawing.Font( _
                "Microsoft Sans Serif", _
                9.0!, _
                System.Drawing.FontStyle.Regular, _
                System.Drawing.GraphicsUnit.Point, _
                CType(0, Byte))
            Me.Button1.Location = New System.Drawing.Point(446, 20)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(75, 24)
            Me.Button1.TabIndex = 2
            Me.Button1.Text = "&Run"
            '
            'Button2
            '
            Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
            Me.Button2.Font = New System.Drawing.Font( _
                "Microsoft Sans Serif", _
                9.0!, _
                System.Drawing.FontStyle.Regular, _
                System.Drawing.GraphicsUnit.Point, _
                CType(0, Byte))
            Me.Button2.Location = New System.Drawing.Point(521, 20)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(75, 24)
            Me.Button2.TabIndex = 3
            Me.Button2.Text = "E&xit"
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.tbxOutput)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel1.DockPadding.All = 20
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(616, 320)
            Me.Panel1.TabIndex = 2
            '
            'tbxOutput
            '
            Me.tbxOutput.AccessibleDescription = _
                "Displays output from application."
            Me.tbxOutput.AccessibleName = "Output textbox."
            Me.tbxOutput.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tbxOutput.Location = New System.Drawing.Point(20, 20)
            Me.tbxOutput.Name = "tbxOutput"
            Me.tbxOutput.Size = New System.Drawing.Size(576, 280)
            Me.tbxOutput.TabIndex = 1
            Me.tbxOutput.Text = "Click the Run button to run the application."
            '
            'Form1
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
            Me.ClientSize = New System.Drawing.Size(616, 384)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.Panel2)
            Me.Name = "Form1"
            Me.Text = "AsymmetricAlgorithm"
            Me.Panel2.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

    End Class
End Namespace
'
' This sample produces the following output:
'
' *** CustomCrypto created with default parameters:
' Contoso.vbCustomCrypto
' KeyExchangeAlgorithm: RSA-PKCS1-KeyEx
' SignatureAlgorithm: http://www.w3.org/2000/09/xmldsig#rsa-sha1
' KeySize: 8
' Parameters described in Xml format:
' <CustomCryptoKeyValue><KeyContainerName>SecurityBin1</KeyContainerName>
' <KeyNumber>1</KeyNumber><ProviderName>Contoso</ProviderName>
' <ProviderType>2</ProviderType></CustomCryptoKeyValue>
' Keysize0 min, max, step: 8, 64, 8, 
' 
' *** CustomCrypto created with custom parameters:
' Contoso.vbCustomCrypto
' KeyExchangeAlgorithm: RSA-PKCS1-KeyEx
' SignatureAlgorithm: http://www.w3.org/2000/09/xmldsig#rsa-sha1
' KeySize: 64
' Parameters described in Xml format:
' <CustomCryptoKeyValue><KeyContainerName>SecurityBin2</KeyContainerName>
' <KeyNumber>1</KeyNumber><ProviderName>Contoso</ProviderName>
' <ProviderType>2</ProviderType></CustomCryptoKeyValue>
' Keysize0 min, max, step: 8, 64, 8, 
' Unable to create CustomCrytpo from  the Create method
' This sample completed successfully; press Enter to exit.
'</Snippet3>
'</Snippet2>