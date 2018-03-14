Imports System
Imports System.Text
Imports System.Printing
Imports System.IO


Namespace WriteToSpoolFile
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			'<SnippetAddUnnamedJob>
			' Create the printer server and print queue objects
			Dim localPrintServer As New LocalPrintServer()
			Dim defaultPrintQueue As PrintQueue = LocalPrintServer.GetDefaultPrintQueue()

			' Call AddJob
			Dim myPrintJob As PrintSystemJobInfo = defaultPrintQueue.AddJob()

			' Write a Byte buffer to the JobStream and close the stream
			Dim myStream As Stream = myPrintJob.JobStream
			Dim myByteBuffer() As Byte = UnicodeEncoding.Unicode.GetBytes("This is a test string for the print job stream.")
			myStream.Write(myByteBuffer, 0, myByteBuffer.Length)
			myStream.Close()
			'</SnippetAddUnnamedJob>

			'<SnippetAddNamedJob>
			' Create the printer server and print queue objects
			Dim localPrintServer2 As New LocalPrintServer()
			Dim defaultPrintQueue2 As PrintQueue = LocalPrintServer.GetDefaultPrintQueue()

			' Call AddJob 
			Dim anotherPrintJob As PrintSystemJobInfo = defaultPrintQueue2.AddJob("MyJob")

			' Read a file into a StreamReader
			Dim myStreamReader As New StreamReader("C:\test.txt")

			' Write a Byte buffer to the JobStream and close the stream
			Dim anotherStream As Stream = anotherPrintJob.JobStream
			Dim anotherByteBuffer() As Byte = UnicodeEncoding.Unicode.GetBytes(myStreamReader.ReadToEnd())
			anotherStream.Write(anotherByteBuffer, 0, anotherByteBuffer.Length)
			anotherStream.Close()
			'</SnippetAddNamedJob>

		End Sub 'end Main

	End Class 'end Program class

End Namespace ' end namespace
