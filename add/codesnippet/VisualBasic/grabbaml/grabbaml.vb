Imports System
Imports System.IO
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.Collections
Imports System.Reflection
Imports System.Diagnostics
Imports System.Resources
Imports System.Windows.Markup.Localizer

Public Class GrabBaml
	Public Shared Sub Main(ByVal args() As String)
		If args.Length <> 1 Then
			Console.WriteLine("this.exe [resource.dll]")
			Return
		End If

        Dim [assembly] As Assembly = assembly.LoadFrom(args(0))

		For Each resourceName As String In [assembly].GetManifestResourceNames()
			Dim resourceStream As Stream = [assembly].GetManifestResourceStream(resourceName)
			Using reader As New ResourceReader(resourceStream)
				For Each entry As DictionaryEntry In reader
					Dim name As String = TryCast(entry.Key, String)

					If Path.GetExtension(name).ToUpperInvariant() = ".BAML" Then
						Console.WriteLine("Processing baml {0}", name)

						' <Snippet1>

						' Obtain the BAML stream.
						Dim source As Stream = TryCast(entry.Value, Stream)

						' Create a BamlLocalizer on the stream.
						Dim localizer As New BamlLocalizer(source)
						Dim resources As BamlLocalizationDictionary = localizer.ExtractResources()

						' Write out all the localizable resources in the BAML.
						For Each resourceEntry As DictionaryEntry In resources
							Dim key As BamlLocalizableResourceKey = TryCast(resourceEntry.Key, BamlLocalizableResourceKey)
							Dim value As BamlLocalizableResource = TryCast(resourceEntry.Value, BamlLocalizableResource)
							Console.WriteLine("    {0}.{1}.{2} = {3}", key.Uid, key.ClassName, key.PropertyName, value.Content)
						Next resourceEntry
						' </Snippet1>

						Console.WriteLine("Done")
					End If
				Next entry
			End Using
		Next resourceName

	End Sub
End Class