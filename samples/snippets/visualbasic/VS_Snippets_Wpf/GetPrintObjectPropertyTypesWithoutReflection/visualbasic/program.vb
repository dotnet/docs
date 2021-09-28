Imports System.Collections.Generic
Imports System.Text
Imports System.Printing
Imports System.Printing.IndexedProperties
Imports System.Collections

Namespace GetPrintObjectPropertiesWithoutReflection
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			'<SnippetShowPropertyTypesWithoutReflection>

			' Enumerate the properties, and their types, of a queue without using Reflection
			Dim localPrintServer As New LocalPrintServer()
			Dim defaultPrintQueue As PrintQueue = LocalPrintServer.GetDefaultPrintQueue()

			Dim printQueueProperties As PrintPropertyDictionary = defaultPrintQueue.PropertiesCollection

            Console.WriteLine("These are the properties, and their types, of {0}, a {1}", defaultPrintQueue.Name, defaultPrintQueue.GetType().ToString() + vbLf)

			For Each entry As DictionaryEntry In printQueueProperties
				Dim [property] As PrintProperty = CType(entry.Value, PrintProperty)

				If [property].Value IsNot Nothing Then
					Console.WriteLine([property].Name & vbTab & "(Type: {0})", [property].Value.GetType().ToString())
				End If
			Next entry
			Console.WriteLine(vbLf & vbLf & "Press Return to continue...")
			Console.ReadLine()

			'</SnippetShowPropertyTypesWithoutReflection>
		End Sub
	End Class
End Namespace
