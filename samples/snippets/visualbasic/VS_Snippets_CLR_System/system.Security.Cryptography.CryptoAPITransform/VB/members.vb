' This sample demonstrates how to use each member of the CryptoAPITransform
' class.
'<Snippet1>
Imports System
Imports System.Security.Cryptography
Imports System.Collections
Imports System.Text

Public Class Form1
    Inherits System.Windows.Forms.Form

    ' Use a public service provider for encryption and decryption.
    Dim desCSP As New DESCryptoServiceProvider

    ' Event handler for Run button.
    Private Sub Button1_Click( _
        ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        tbxOutput.Cursor = Cursors.WaitCursor
        tbxOutput.Text = ""

        Dim message As String = "01234567890123456789"
        Dim sourceBytes() As Byte = Encoding.ASCII.GetBytes(message)
        tbxOutput.AppendText("** Phrase to be encoded: " + message + vbCrLf)

        Dim encodedBytes() As Byte = EncodeBytes(sourceBytes)
        tbxOutput.AppendText("** Phrase after encoding: " + _
            Encoding.ASCII.GetString(encodedBytes) + vbCrLf)

        Dim decodedBytes() As Byte = DecodeBytes(encodedBytes)
        tbxOutput.AppendText("** Phrase after decoding: " + _
            Encoding.ASCII.GetString(decodedBytes) + vbCrLf)

        tbxOutput.AppendText(vbCrLf + "Sample ended successfully; " + _
            "press Enter to continue.")
        tbxOutput.Cursor = Cursors.Default
    End Sub

    ' Encode the specified byte array by using CryptoAPITranform.
    Private Function EncodeBytes(ByVal sourceBytes() As Byte) As Byte()
        Dim currentPosition As Int16 = 0
        Dim targetBytes(1024) As Byte
        Dim sourceByteLength As Integer = sourceBytes.Length

        ' Create a DES encryptor from this instance to perform encryption.
        Dim cryptoTransform As CryptoAPITransform
        cryptoTransform = CType(desCSP.CreateEncryptor(), CryptoAPITransform)

        ' Retrieve the block size to read the bytes.
        '<Snippet4>
        Dim inputBlockSize As Integer = cryptoTransform.InputBlockSize
        '</Snippet4>

        ' Retrieve the key handle.
        '<Snippet5>
        Dim keyHandle As IntPtr = cryptoTransform.KeyHandle
        '</Snippet5>

        ' Retrieve the block size to write the bytes.
        '<Snippet6>
        Dim outputBlockSize As Integer = cryptoTransform.OutputBlockSize
        '</Snippet6>

        Try
            ' Determine if multiple blocks can be transformed.
            '<Snippet3>
            If (cryptoTransform.CanTransformMultipleBlocks) Then
                '</Snippet3>
                Dim numBytesRead As Int16 = 0
                While (sourceByteLength - currentPosition >= inputBlockSize)
                    ' Transform the bytes from currentposition in the 
                    ' sourceBytes array, writing the bytes to the targetBytes
                    ' array.
                    '<Snippet8>
                    numBytesRead = cryptoTransform.TransformBlock( _
                        sourceBytes, _
                        currentPosition, _
                        inputBlockSize, _
                        targetBytes, _
                        currentPosition)
                    '</Snippet8>

                    ' Advance the current position in the sourceBytes array.
                    currentPosition += numBytesRead
                End While

                ' Transform the final block of bytes.
                ' <Snippet9>
                Dim finalBytes() As Byte
                finalBytes = cryptoTransform.TransformFinalBlock( _
                    sourceBytes, _
                    currentPosition, _
                    sourceByteLength - currentPosition)
                '</Snippet9>

                ' Copy the contents of the finalBytes array to the targetBytes
                ' array.
                finalBytes.CopyTo(targetBytes, currentPosition)
            End If

        Catch ex As Exception
            tbxOutput.AppendText("Caught unexpected exception:" + _
                ex.ToString() + vbCrLf)

        End Try

        ' Determine if the current transform can be reused.
        '<Snippet2>
        If (Not cryptoTransform.CanReuseTransform) Then
            '</Snippet2>

            ' Free up any used resources.
            '<Snippet7>
            cryptoTransform.Clear()
            '</Snippet7>
        End If

        ' Trim the extra bytes in the array that were not used.
        Return TrimArray(targetBytes)
    End Function

    ' Decode the specified byte array using CryptoAPITranform.
    Private Function DecodeBytes(ByVal sourceBytes() As Byte) As Byte()

        Dim currentPosition As Int16 = 0
        Dim targetBytes(1024) As Byte
        Dim sourceByteLength As Integer = sourceBytes.Length

        ' Create a DES decryptor from this instance to perform decryption.
        Dim cryptoTransform As CryptoAPITransform
        cryptoTransform = CType(desCSP.CreateDecryptor(), CryptoAPITransform)

        Dim inputBlockSize As Integer = cryptoTransform.InputBlockSize

        Try
            ' Determine if multiple blocks can be transformed.
            If (cryptoTransform.CanTransformMultipleBlocks) Then

                Dim numBytesRead As Int16 = 0
                While (sourceByteLength - currentPosition >= inputBlockSize)

                    ' Transform the bytes from currentPosition in the
                    ' sourceBytes array, writing the bytes to the targetBytes
                    ' array.
                    numBytesRead = cryptoTransform.TransformBlock( _
                        sourceBytes, _
                        currentPosition, _
                        inputBlockSize, _
                        targetBytes, _
                        currentPosition)

                    ' Advance the current position in the source array.
                    currentPosition += numBytesRead
                End While

                ' Transform the final block of bytes.
                Dim finalBytes() As Byte
                finalBytes = cryptoTransform.TransformFinalBlock( _
                    sourceBytes, _
                    currentPosition, _
                    sourceByteLength - currentPosition)

                ' Copy the contents of the finalBytes array to the targetBytes
                ' array.
                finalBytes.CopyTo(targetBytes, currentPosition)
            End If

        Catch ex As Exception
            tbxOutput.AppendText("Caught unexpected exception:" + _
                ex.ToString() + vbCrLf)

        End Try

        ' Strip out the second block of bytes.
        Array.Copy(targetBytes, (inputBlockSize * 2), targetBytes, inputBlockSize, targetBytes.Length - (inputBlockSize * 2))

        ' Trim the extra bytes in the array that were not used.
        Return TrimArray(targetBytes)
    End Function

    ' Resize the dimensions of the array to a size that contains only valid
    ' bytes.
    Private Function TrimArray(ByVal targetArray() As Byte) As Byte()

        Dim enum1 As IEnumerator = targetArray.GetEnumerator()
        Dim i As Int16 = 0

        While (enum1.MoveNext())
            If (enum1.Current.ToString().Equals("0")) Then
                Exit While
            End If

            i += 1
        End While

        ' Create a new array with the number of valid bytes.
        Dim returnedArray(i - 1) As Byte
        For j As Int16 = 0 To i - 1 Step 1
            returnedArray(j) = targetArray(j)
        Next

        Return returnedArray
    End Function


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
        Me.Text = "CryptoAPITransform"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
End Class
'
' This sample produces the following output:
'
' ** Phrase to be encoded: 01234567890123456789
' ** Phrase after encoding: Eaa0$\iv\oXgS
' ** Phrase after decoding: 01234567890123456789
' 
' Sample ended successfully; press Enter to continue.
'</Snippet1>