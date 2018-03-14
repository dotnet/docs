' This sample class demonstrates how to use the ContosoKeyedHash class to
' compute Hash
'<Snippet21>
Imports System
Imports System.IO
Imports System.Text
Imports System.Collections
Imports System.Security.Cryptography

Namespace Contoso
    Public Class Form1
        Inherits System.Windows.Forms.Form

        ' Event handler for Run button.
        Private Sub Button1_Click( _
            ByVal sender As System.Object, _
            ByVal e As System.EventArgs) Handles Button1.Click

            tbxOutput.Cursor = Cursors.WaitCursor
            tbxOutput.Text = ""

            EncodeMessage()
            EncodeStream()

            ' Reset the cursor and conclude application.
            tbxOutput.AppendText(vbCrLf + "This sample completed " + _
                "successfully; press Exit to continue.")
            tbxOutput.Cursor = Cursors.Default
        End Sub

        ' Compute the hash for a ContosoKeyedHash that has transformed
        ' a file stream.
        Private Sub EncodeStream()
            '<Snippet4>
            Dim keyData(24) As Byte
            RandomNumberGenerator.Create.GetBytes(keyData)
            Dim localCrypto As New ContosoKeyedHash(keyData)
            '</Snippet4>

            Dim filePath As String
            filePath = System.IO.Directory.GetCurrentDirectory() + _
                "\members.txt"

            Try
                '<Snippet14>
                Dim fileStream As _
                    New FileStream(filePath, FileMode.Open, FileAccess.Read)

                localCrypto.ComputeHash(fileStream)
                '</Snippet14>

                SummarizeMAC(localCrypto, _
                    "ContosoKeyedHash after encoding a file stream.")
            Catch ex As FileNotFoundException
                WriteLine("Specified path was not found: " + filePath)
            End Try

        End Sub

        ' Compute the hash for a ContosoKeyedHash that has transformed
        ' a byte array.
        Private Sub EncodeMessage()

            Dim keyData(24) As Byte
            RandomNumberGenerator.Create().GetBytes(keyData)
            Dim localCrypto As New ContosoKeyedHash(keyData)

            '<Snippet13>
            Dim message As String = "Hello World."
            Dim encodedMessage() As Byte = _
                EncodeBytes(Encoding.ASCII.GetBytes(message))

            localCrypto.ComputeHash(encodedMessage)
            '</Snippet13>

            SummarizeMAC(localCrypto, _
                "ContosoKeyedHash after encoding a message.")
        End Sub

        ' Transform the byte array using ContosoKeyedHash,
        ' then summarize its properties.
        Private Function EncodeBytes(ByVal sourceBytes As Byte()) As Byte()
            Dim currentPosition As Int16 = 0
            Dim targetBytes(1024) As Byte
            Dim sourceByteLength As Int16 = sourceBytes.Length

            ' Create an encryptor with a random key and the KeyedHashAlgorithm
            ' class name.
            Dim key(24) As Byte
            RandomNumberGenerator.Create().GetBytes(key)
            Dim keyedHashName As String 
            keyedHashName = "System.Security.Cryptography.KeyedHashAlgorithm"
            Dim localCrypto As New ContosoKeyedHash(keyedHashName, key)

            ' Retrieve the block size to read the bytes.
            '<Snippet9>
            Dim inputBlockSize As Integer = localCrypto.InputBlockSize
            '</Snippet9>

            Try
                ' Determine if multiple blocks can be transformed.
                '<Snippet6>
                If (localCrypto.CanTransformMultipleBlocks) Then
                    '</Snippet6>
                    Dim numBytesRead As Int16 = 0

                    While (sourceByteLength - currentPosition >= _
                         inputBlockSize)

                        ' Transform the bytes from the currentposition in the
                        ' sourceBytes array, writing the bytes to the 
                        ' targetBytes array.
                        '<Snippet18>
                        numBytesRead = localCrypto.TransformBlock( _
                            sourceBytes, _
                            currentPosition, _
                            inputBlockSize, _
                            targetBytes, _
                            currentPosition)
                        '</Snippet18>

                        ' Advance the current position in the source array.
                        currentPosition += numBytesRead
                    End While

                    ' Transform the final block of bytes.
                    '<Snippet19>
                    Dim finalBytes() As Byte
                    finalBytes = localCrypto.TransformFinalBlock( _
                        sourceBytes, _
                        currentPosition, _
                        sourceByteLength - currentPosition)
                    '</Snippet19>

                    ' Copy the contents of the finalBytes array to the
                    ' targetBytes array.
                    finalBytes.CopyTo(targetBytes, currentPosition)
                End If

            Catch ex As Exception

                WriteLine("Caught unexpected exception:" + _
                    ex.ToString())
            End Try

            ' Find the length of valid bytes (those without zeros).
            '<Snippet15>
            Dim enum1 As IEnumerator = targetBytes.GetEnumerator()
            Dim i As Int16

            While (enum1.MoveNext())
                If (enum1.Current.ToString().Equals("0")) Then
                    Exit While
                End If
                i = i + 1
            End While

            ' Compute the hash based on the valid bytes in the array.
            'Dim somebytes() As Byte
            'somebytes = localCrypto.ComputeHash(targetBytes, 0, i)
            localCrypto.ComputeHash(targetBytes, 0, i)
            '</Snippet15>

            SummarizeMAC(localCrypto, "ContosoKeyedHash after computing " + _
                "hash for specified region of byte array")

            '<Snippet5>
            ' Determine if the current transform can be reused.
            If (Not localCrypto.CanReuseTransform) Then
                '</Snippet5>

                ' Free up any used resources.
                '<Snippet12>
                localCrypto.Clear()
                '</Snippet12>

                '<Snippet16>
                localCrypto.Initialize()
                '</Snippet16>
            End If

            ' Create a new array with the number of valid bytes.
            Dim returnedArray(i) As Byte
            For j As Int16 = 0 To i Step 1
                returnedArray(j) = targetBytes(j)
            Next

            Return returnedArray
        End Function
        ' Write a summary of the specified ContosoKeyedHash to the 
        ' console window.
        Private Sub SummarizeMAC( _
            ByVal localCrypto As ContosoKeyedHash, _
            ByVal description As String)

            '<Snippet20>
            Dim classDescription As String = localCrypto.ToString()
            '</Snippet20>

            '<Snippet7>
            Dim computedHash() As Byte = localCrypto.Hash
            '</Snippet7>

            '<Snippet8>
            Dim hashSize As Integer = localCrypto.HashSize
            '</Snippet8>

            '<Snippet11>
            Dim outputBlockSize As Integer = localCrypto.OutputBlockSize
            '</Snippet11>

            ' Retrieve the key used in the hash algorithm.
            '<Snippet10>
            Dim key() As Byte = localCrypto.Key
            '</Snippet10>

            WriteLine(vbCrLf + "**********************************")
            WriteLine(classDescription)
            WriteLine(description)
            WriteLine("----------------------------------")
            WriteLine("The size of the computed hash : " + _
                hashSize.ToString())
            WriteLine("The key used in the hash algorithm : " + _
                Encoding.ASCII.GetString(key))
            WriteLine("The value of the computed hash : " + _
                Encoding.ASCII.GetString(computedHash))
        End Sub
        Private Sub WriteLine(ByVal Message As String)
            tbxOutput.AppendText(Message + vbCrLf)
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

        'NOTE:The following procedure is required by the Windows Form Designer
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
            Me.Text = "KeyedHashAlgorithm"
            Me.Panel2.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub
#End Region
    End Class
End Namespace
'</Snippet21>