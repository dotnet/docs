' This sample demonstrates how to encode and decode a string using
' the RSAOAEPKeyExchangeFormatter and RSAOAEPKeyExchangeDeformatter classes.
'<Snippet2>
Imports System
Imports System.Security.Cryptography
Imports System.Text

Public Class Form1
    Inherits System.Windows.Forms.Form

    ' Use a member variable to hold the RSA key for encoding and decoding.
    Private rsaKey As RSA

    ' Event handler for Run button.
    Private Sub Button1_Click( _
        ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        tbxOutput.Cursor = Cursors.WaitCursor
        tbxOutput.Text = ""

        Dim message As String = "A phrase to be encoded."

        InitializeKey(RSA.Create())

        WriteLine("Encoding the following message:")
        WriteLine(message)
        Dim encodedMessage() As Byte = EncodeMessage(message)
        WriteLine("Resulting message encoded:")
        WriteLine(Encoding.ASCII.GetString(encodedMessage))

        Dim decodedMessage As String = DecodeMessage(encodedMessage)
        WriteLine("Resulting message decoded:")
        WriteLine(decodedMessage)

        ' Construct a formatter to demonstrate how to set each property.
        ConstructFormatter()

        ' Construct a deformatter to demonstrate how to set each property.
        ConstructDeformatter()

        ' Align interface and conclude application.
        tbxOutput.AppendText(vbCrLf + "This sample completed " + _
            "successfully; press Exit to continue.")

        ' Reset the cursor.
        tbxOutput.Cursor = Cursors.Default
    End Sub
    ' Initialize an rsaKey member variable with the specified RSA key.
    private sub InitializeKey(byval key as RSA)
        rsaKey = key
    End Sub
    ' Use the RSAOAEPKeyExchangeDeformatter class to decode the 
    ' specified message.
    Private Function EncodeMessage(ByVal message As String) As Byte()
        Dim encodedMessage() As Byte = Nothing

        Try
            ' Construct a formatter with the specified RSA key.
            '<Snippet3>
            Dim keyEncryptor As New RSAOAEPKeyExchangeFormatter(rsaKey)
            '</Snippet3>

            ' Convert the message to bytes to create the encrypted data.
            '<Snippet4>
            Dim byteMessage() As Byte
            byteMessage = Encoding.ASCII.GetBytes(message)
            encodedMessage = keyEncryptor.CreateKeyExchange(byteMessage)
            '</Snippet4>

        Catch ex As Exception
            WriteLine("Unexpected exception caught:" + ex.ToString())
        End Try

        Return encodedMessage

    End Function
    ' Use the RSAOAEPKeyExchangeDeformatter class to decode the
    ' specified message.
    Private Function DecodeMessage(ByVal encodedMessage() As Byte) As String
        Dim decodedMessage As String = Nothing

        Try
            ' Construct a deformatter with the specified RSA key.
            '<Snippet8>
            Dim keyDecryptor As New RSAOAEPKeyExchangeDeformatter(rsaKey)
            '</Snippet8>

            ' Decrypt the encoded message.
            '<Snippet9>
            Dim decodedBytes() As Byte
            decodedBytes = keyDecryptor.DecryptKeyExchange(encodedMessage)
            '</Snippet9>

            ' Retrieve a string representation of the decoded message.
            decodedMessage = Encoding.ASCII.GetString(decodedBytes)
        Catch ex As Exception
            WriteLine("Unexpected exception caught:" + ex.ToString())
        End Try

        Return decodedMessage

    End Function
    ' Create an RSAOAEPKeyExchangeFormatter object with a new RSA key.
    ' Display its properties to the console.
    Private Sub ConstructFormatter()
        ' Construct an empty Optimal Asymmetric Encryption Padding (OAEP)
        ' key exchange.
        '<Snippet1>
        Dim rsaFormatter = New RSAOAEPKeyExchangeFormatter
        '</Snippet1>

        ' Create an RSA and set it into the specified 
        ' RSAOAEPKeyExchangeFormatter.
        '<Snippet5>
        Dim key As RSA = RSA.Create()
        rsaFormatter.SetKey(key)
        '</Snippet5>

        ' Create a random number using the RNGCryptoServiceProvider provider.
        '<Snippet6>
        Dim ring As New RNGCryptoServiceProvider
        rsaFormatter.Rng = ring
        '</Snippet6>

        ' Export InverseQ and set it into RSAOAEPKeyExchangeFormatter.
        '<Snippet7>
        rsaFormatter.Parameter = key.ExportParameters(True).InverseQ
        '</Snippet7>

        WriteLine(vbCrLf + "**" + rsaFormatter.ToString() + "**")
        WriteLine("The following random number was generated for the class:")
        WriteLine(rsaFormatter.Rng.ToString())

        WriteLine(vbCrLf + "The RSA formatter contains the following " + _
            "InverseQ parameter:")
        WriteLine(Encoding.ASCII.GetString(rsaFormatter.Parameter))

        '<Snippet13>
        Dim xmlParameters as string = rsaFormatter.Parameters
        '</Snippet13>

        WriteLine(vbCrLf + "The RSA formatter has the following parameters:")
        WriteLine(xmlParameters )
    End Sub

    ' Create an RSAOAEPKeyExchangeDeformatter object with a new RSA key.
    ' Display its properties to the console.
    Private Sub ConstructDeformatter()
        ' Construct an empty OAEP key exchange.
        '<Snippet10>
        Dim rsaDeformatter As New RSAOAEPKeyExchangeDeformatter
        '</Snippet10>

        ' Create an RSAKey and set it into the specified 
        ' RSAOAEPKeyExchangeDeformatter.
        '<Snippet11>
        Dim key As RSA = RSA.Create()
        rsaDeformatter.SetKey(key)
        '</Snippet11>

        '<Snippet12>
        Dim xmlParameters as string = rsaDeformatter.Parameters
        '</Snippet12>

        WriteLine(vbCrLf + "**" + rsaDeformatter.ToString() + "**")
        WriteLine(vbCrLf + "The RSA deformatter has the following ")
        WriteLine("parameters:" + xmlParameters)
    End Sub
    ' Write message with carriage return to output textbox.
    Private Sub WriteLine(ByVal message As String)
        tbxOutput.AppendText(message + vbCrLf)
    End Sub
    ' Event handler for Exit button.
    Private Sub Button2_Click( _
        ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button2.Click

        Application.Exit()
    End Sub
#Region " Windows Form Designer generated code "

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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
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
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", _
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
            "Microsoft Sans Serif", 9.0!, _
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
        Me.Text = "RSAOAEPKeyExchangeFormatter"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
End Class
'
' This sample produces the following output:
'
' Encoding the following message:
' A phrase to be encoded.
' Resulting message encoded:k90)DU890fus8d9u*D_(8
' Resulting message decoded:
' A phrase to be encoded.
' 
' **System.Security.Cryptography.RSAOAEPKeyExchangeFormatter**
' The following random number was generated for the class:
' System.Security.Cryptography.RNGCryptoServiceProvider
' 
' The RSA formatter contains the following InverseQ parameter:
' J*Df89uDZ*(*F09
' The RSA formatter has the following parameters:
' 
' 
' **System.Security.Cryptography.RSAOAEPKeyExchangeDeformatter**
' 
' The RSA deformatter has the following 
' parameters:
' 
' This sample completed successfully; press Exit to continue.
'</Snippet2>