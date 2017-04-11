' <snippet1>
Imports System
Imports System.IO
Imports System.Runtime
Imports System.Reflection
Imports System.Runtime.Remoting.Lifetime
Imports Microsoft.VisualBasic
Imports System.Security.Permissions

Namespace StreamWriterSample

    Public Class Logger
        '</snippet1>
        'Constructors
        Public Sub New()
            BeginWrite()
        End Sub
        Public Sub New(ByVal LogFile As String)
            BeginWrite(LogFile)
        End Sub
        Protected Overrides Sub Finalize()
            EndWrite()
        End Sub
        '<snippet2> 
        Public Sub CreateTextFile(ByVal FileName As String, _
            ByVal TextToAdd As String)

            Dim Fs As FileStream = New FileStream(FileName, _
                FileMode.CreateNew, FileAccess.Write, FileShare.None)

            Dim SwFromFile As StreamWriter = New StreamWriter(FileName)
            SwFromFile.Write(TextToAdd)
            SwFromFile.Flush()
            SwFromFile.Close()

            Dim SwFromFileStream As StreamWriter = New StreamWriter(Fs)
            SwFromFileStream.Write(TextToAdd)
            SwFromFileStream.Flush()
            SwFromFileStream.Close()

            Dim SwFromFileStreamDefaultEnc As StreamWriter = _
             New StreamWriter(Fs, System.Text.Encoding.Default)
            SwFromFileStreamDefaultEnc.Write(TextToAdd)
            SwFromFileStreamDefaultEnc.Flush()
            SwFromFileStreamDefaultEnc.Close()

            Dim SwFromFileTrue As StreamWriter = _
             New StreamWriter(FileName, True)
            SwFromFileTrue.Write(TextToAdd)
            SwFromFileTrue.Flush()
            SwFromFileTrue.Close()

            Dim SwFromFileTrueUTF8Buffer = _
             New StreamWriter(FileName, _
             True, System.Text.Encoding.UTF8, 512)
            SwFromFileTrueUTF8Buffer.Write(TextToAdd)
            SwFromFileTrueUTF8Buffer.Flush()
            SwFromFileTrueUTF8Buffer.Close()

            Dim SwFromFileTrueUTF8 = _
             New StreamWriter(FileName, True, _
             System.Text.Encoding.UTF8)
            SwFromFileTrueUTF8.Write(TextToAdd)
            SwFromFileTrueUTF8.Flush()
            SwFromFileTrueUTF8.Close()

            Dim SwFromFileStreamUTF8Buffer = _
             New StreamWriter(Fs, System.Text.Encoding.UTF8, 512)
            SwFromFileStreamUTF8Buffer.Write(textToAdd)
            SwFromFileStreamUTF8Buffer.Flush()
            SwFromFileStreamUTF8Buffer.Close()

        End Sub
        '</snippet2>

        '<snippet3> 
        <SecurityPermissionAttribute(SecurityAction.Demand, Flags:=SecurityPermissionFlag.Infrastructure)> _
        Private Sub BeginWrite(ByVal LogFile As String)
            '</snippet3>
            '<snippet4>
            Dim Sw As StreamWriter = New StreamWriter(LogFile, True)
            '</snippet4>
            '<snippet5> 
            ' Gets or sets a value indicating whether the StreamWriter
            ' will flush its buffer to the underlying stream after every 
            ' call to StreamWriter.Write.
            Sw.AutoFlush = True
            '</snippet5>
            '<snippet6> 
            If Sw.Equals(StreamWriter.Null) Then
                Sw.WriteLine("The store can be written to, but not read from.")
            End If
            '</snippet6>
            '<snippet7> 
            Sw.Write(Char.Parse(" "))
            '</snippet7>
            '<snippet8> 
            Dim hello As String = "Hellow World!"
            Dim buffer As Char() = hello.ToCharArray()
            Sw.Write(buffer)
            '</snippet8>
            '<snippet9> 
            Dim HelloWorld As String = "Hellow World!"
            Sw.Write(HelloWorld)
            '</snippet9>
            '<snippet10> 
            Sw.WriteLine("---Begin Log Entry---")
            '</snippet10>
            '<snippet11> 
            ' Write out the current text encoding.
            Sw.WriteLine("Encoding: {0}", _
             Sw.Encoding.ToString())
            '</snippet11>
            '<snippet12> 
            ' Display the Format Provider
            Sw.WriteLine("Format Provider: {0} ", _
                Sw.FormatProvider)
            '</snippet12>
            '<snippet13> 
            ' Set the characters you would like to designate a new line.
            Sw.NewLine = Constants.vbCrLf
            '</snippet13>
            '<snippet14> 
            Dim Obj As ILease = Sw.InitializeLifetimeService()
            If Not Obj Is Nothing Then
                Sw.WriteLine("Object initialized lease " _
                    & "time remaining: {0}.", _
                    Obj.CurrentLeaseTime.ToString())
            End If
            '</snippet14>
            '<snippet15> 
            Dim Lease As ILease = Sw.GetLifetimeService()
            If Not Lease Is Nothing Then
                Sw.WriteLine("Object lease time remaining: {0}.", _
                    Lease.CurrentLeaseTime().ToString())
            End If
            '</snippet15>
            '<snippet16> 
            ' Update the underlying file.
            Sw.Flush()
            '</snippet16>
            '<snippet17> 
            ' Close the file by closing the writer.
            Sw.Close()
            '</snippet17>
            '<snippet18> 
        End Sub
        '</snippet18> 
        Private Sub BeginWrite()
            BeginWrite(DateTime.Now.ToShortDateString().Replace("/", _
                "-").Replace("\", "-") + ".log")
        End Sub

        Private Sub EndWrite(ByVal LogFile As String)
            Dim Sw As StreamWriter = New StreamWriter(LogFile, True)
            ' Set the file pointer to the end of file.
            Sw.BaseStream.Seek(0, SeekOrigin.End)
            ' Write text to the file.
            Sw.WriteLine("---End Log Entry---")
            ' Update the underlying file.
            Sw.Flush()
            ' Close the file by closing the writer.
            Sw.Close()
        End Sub

        Private Sub EndWrite()
            EndWrite(DateTime.Now.ToShortDateString().Replace("/", _
                "-").Replace("\", "-") + ".log")
        End Sub
        '<snippet19> 
    End Class
End Namespace
'</snippet19>
Class EntryPoint
    Shared Sub Main()
        Dim A As New StreamWriterSample.Logger()
    End Sub
End Class
