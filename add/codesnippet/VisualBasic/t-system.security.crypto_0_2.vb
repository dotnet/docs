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
            customCrypto.Clear()

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
                Dim classDescription As String = customCrypto.ToString()

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