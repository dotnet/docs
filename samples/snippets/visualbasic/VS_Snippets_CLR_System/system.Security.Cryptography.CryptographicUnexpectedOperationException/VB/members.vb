' This sample demonstrates how to use each member of the
' CryptographicUnexpectedOperationException class.
'<Snippet2>
Imports System
Imports System.Security.Cryptography
Imports System.Runtime.Serialization

Public Class Form1
    Inherits System.Windows.Forms.Form

    ' Event handler for Run button.
    Private Sub Button1_Click( _
        ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        tbxOutput.Cursor = Cursors.WaitCursor
        tbxOutput.Text = ""

        TestConstructors()
        ShowProperties()

        ' Reset the cursor and conclude application.
        tbxOutput.AppendText(vbCrLf + "This sample completed " + _
            "successfully; press Exit to continue.")
        tbxOutput.Cursor = Cursors.Default
    End Sub

    ' Test each public implementation of the
    ' CryptographicUnexpectedOperationException constructors.
    Private Sub TestConstructors()
        EmptyConstructor()
        StringConstructor()
        StringExceptionConstructor()
        StringStringConstructor()
    End Sub

    Private Sub EmptyConstructor()
        ' Construct a CryptographicUnexpectedOperationException
        ' with no parameters.
        '<Snippet1>
        Dim cryptographicException As _
            New CryptographicUnexpectedOperationException
        '</Snippet1>
        WriteLine("Created an empty " + _
            "CryptographicUnexpectedOperationException.")
    End Sub

    Private Sub StringConstructor()
        ' Construct a CryptographicUnexpectedOperationException using a custom
        ' error message.
        '<Snippet3>
        Dim errorMessage As String = "Unexpected operation exception."
        Dim cryptographicException As _
            New CryptographicUnexpectedOperationException(errorMessage)
        '</Snippet3>
        WriteLine("Created a CryptographicUnexpectedOperationException " + _
            "with the following error message: " + errorMessage)
    End Sub

    Private Sub StringExceptionConstructor()
        ' Construct a CryptographicUnexpectedOperationException using a
        ' custom error message and an inner exception.
        '<Snippet4>
        Dim errorMessage As String = "The current operation is not supported."
        Dim nullException As New NullReferenceException
        Dim cryptographicException As _
            New CryptographicUnexpectedOperationException( _
            errorMessage, nullException)
        '</Snippet4>
        Write("Created a CryptographicUnexpectedOperationException ")
        Write("with the following error message: " + errorMessage)
        WriteLine(" and inner exception: " + nullException.ToString())
    End Sub

    Private Sub StringStringConstructor()
        ' Create a CryptographicUnexpectedOperationException using
        ' a time format and the current date.
        '<Snippet5>
        Dim dateFormat As String = "{0:t}"
        Dim timeStamp As String = DateTime.Now.ToString()
        Dim cryptographicException As New _
            CryptographicUnexpectedOperationException(dateFormat, timeStamp)
        '</Snippet5>
        Write("Created a CryptographicUnexpectedOperationException with ")
        Write(dateFormat + " as the format and " + timeStamp)
        WriteLine(" as the message.")
    End Sub

    ' Construct an invalid DSACryptoServiceProvider to throw a
    ' CryptographicUnexpectedOperationException for introspection.
    Private Sub ShowProperties()
        ' Attempting to encode an OID greater than 127 bytes is not supported
        ' and will throw an exception.
        Dim veryLongNumber As String = "1234567890.1234567890."

        For i As Int16 = 0 To 4 Step 1
            veryLongNumber += veryLongNumber
        Next
        veryLongNumber += "0"

        Try
            Dim tooLongOID() As Byte
            tooLongOID = CryptoConfig.EncodeOID(veryLongNumber)

        Catch ex As CryptographicUnexpectedOperationException
            ' Retrieve the link to the Help file for the exception.
            '<Snippet6>
            Dim helpLink As String = ex.HelpLink
            '</Snippet6>            

            ' Retrieve the exception that caused the current
            ' CryptographicUnexpectedOperationException.
            '<Snippet7>            
            Dim innerException As System.Exception = ex.InnerException
            '</Snippet7>
            Dim innerExceptionMessage As String = ""
            If (Not innerException Is Nothing) Then
                innerExceptionMessage = innerException.ToString()
            End If

            ' Retrieve the message that describes the exception.
            '<Snippet8>
            Dim message As String = ex.Message
            '</Snippet8>

            ' Retrieve the name of the application that caused the exception.
            '<Snippet9>
            Dim exceptionSource As String = ex.Source
            '</Snippet9>

            ' Retrieve the call stack at the time the exception occurred.
            '<Snippet10>
            Dim stackTrace As String = ex.StackTrace
            '</Snippet10>

            ' Retrieve the method that threw the exception.
            '<Snippet11>
            Dim targetSite As System.Reflection.MethodBase
            targetSite = ex.TargetSite
            '</Snippet11>
            Dim siteName As String = targetSite.Name

            ' Retrieve the entire exception as a single string.
            '<Snippet12>
            Dim entireException As String = ex.ToString()
            '</Snippet12>

            ' GetObjectData
            setSerializationInfo(ex)

            ' Get the root exception that caused the current
            ' CryptographicUnexpectedOperationException.
            '<Snippet13>
            Dim baseException As System.Exception = ex.GetBaseException()
            '</Snippet13>
            Dim baseExceptionMessage As String = ""
            If (Not baseException Is Nothing) Then
                baseExceptionMessage = baseException.Message
            End If

            WriteLine("Caught an expected exception:")
            WriteLine(entireException)

            WriteLine(vbCrLf + "Properties of the exception are as follows:")
            WriteLine("Message: " + message)
            WriteLine("Source: " + exceptionSource)
            WriteLine("Stack trace: " + stackTrace)
            WriteLine("Help link: " + helpLink)
            WriteLine("Target site's name: " + siteName)
            WriteLine("Base exception message: " + baseExceptionMessage)
            WriteLine("Inner exception message: " + innerExceptionMessage)

        End Try
    End Sub

    Private Sub setSerializationInfo( _
        ByRef ex As CryptographicUnexpectedOperationException)

        ' Insert information about the exception into a serialized object.
        '<Snippet14>
        Dim formatConverter As New FormatterConverter
        Dim serializationInfo As _
            New SerializationInfo(ex.GetType(), formatConverter)
        Dim streamingContext As _
            New StreamingContext(StreamingContextStates.All)

        ex.GetObjectData(serializationInfo, streamingContext)
        '</Snippet14>
    End Sub

    ' Write specified message to the output textbox.
    Private Sub Write(ByVal message As String)
        tbxOutput.AppendText(message)
    End Sub

    ' Write specified message with a carriage return to the output textbox.
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
        Me.Button1.Font = New System.Drawing.Font( _
            "Microsoft Sans Serif", 9.0!, _
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
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", _
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
        Me.Text = "CryptographicUnexpectedOperationException"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
End Class
'
' This sample produces the following output:
'
' Created an empty CryptographicUnexpectedOperationException.
' Created a CryptographicUnexpectedOperationException with the following error
' message: Unexpected operation exception.
' Created a CryptographicUnexpectedOperationException with the following error
' message: The current operation is not supported. and inner exception:
' System.NullReferenceException: Object reference not set to an instance of an
' object.
' Created a CryptographicUnexpectedOperationException with {0:t} as the format
' and 2/24/2004 2:29:32 PM as the message.
' Caught an expected exception:
' System.Security.Cryptography.CryptographicUnexpectedOperationException:
' Encoded OID length is too large (greater than 0x7f bytes).
'  at System.Security.Cryptography.CryptoConfig.EncodeOID(String str)
'  at WindowsApplication1.Form1.ShowProperties() in 
' C:\WindowsApplication1\Form1.vb:line 103
'
' Properties of the exception are as follows:
' Message: Encoded OID length is too large (greater than 0x7f bytes).
' Source: mscorlib
' Stack trace:    at System.Security.Cryptography.CryptoConfig.EncodeOID(
' String str) at WindowsApplication1.Form1.ShowProperties() in
' C:\WindowsApplication1\Form1.vb:line 103
' Help link: 
' Target site's name: EncodeOID
' Base exception message: Encoded OID length is too large (greater than 0x7f
' bytes).
' Inner exception message: 
' 
' This sample completed successfully; press Exit to continue.
'</Snippet2>