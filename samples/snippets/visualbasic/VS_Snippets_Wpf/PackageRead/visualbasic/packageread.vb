'-----------------------------------------------------------------------------
' <copyright file="PackageRead.vb" company="Microsoft">
'   Copyright (C) Microsoft Corporation.  All rights reserved.</copyright>
'
' <summary>
'   PackageWrite shows how to read a Package zip file
'   extracting content, resource, and relationship parts.</summary>
'-----------------------------------------------------------------------------


Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.IO.Packaging
Imports System.Windows

Namespace SDKSample
	Friend Class PackageRead
		Private Const PackageRelationshipType As String = "http://schemas.microsoft.com/opc/2006/sample/document"
		Private Const ResourceRelationshipType As String = "http://schemas.microsoft.com/opc/2006/sample/required-resource"


		'  ------------------------------ Main -------------------------------
		Public Shared Sub Main()
			' Path and filename of the Package zip file to extract from.
			Dim packagePath As String = "myPackage.package"
			' Relative path to the destination folder to extract to.
			Dim targetDirectory As String = "Target\"

			' Extract the parts contained in 'myPackage.package'
			'   zip file to the 'Target\' folder.
			ExtractPackageParts(packagePath, targetDirectory)

			MessageBox.Show("Normal Completion:" & vbLf & "Successfully extracted document and resource parts" & vbLf & "from '" & packagePath & "' zip to new '" & targetDirectory & "' folder.", "End of Program", MessageBoxButton.OK, MessageBoxImage.Information)
		End Sub ' end:main()


		'  ----------------------- ExtractPackageParts -----------------------
		''' <summary>
		'''   Extracts content and resource parts from a given Package
		'''   zip file to a specified target directory.</summary>
		''' <param name="packagePath">
		'''   The relative path and filename of the Package zip file.</param>
		''' <param name="targetDirectory">
		'''   The relative path from the current directory to the targer folder.
		''' </param>
		Private Shared Sub ExtractPackageParts(ByVal packagePath As String, ByVal targetDirectory As String)
			' Create a new Target directory.  If the Target directory
			' exists, first delete it and then create a new empty one.
			Dim directoryInfo As New DirectoryInfo(targetDirectory)
			If directoryInfo.Exists Then
				directoryInfo.Delete(True)
			End If
			directoryInfo.Create()

			'<SnippetPackageReadUsing>
			' Open the Package.
			' ('using' statement insures that 'package' is
			'  closed and disposed when it goes out of scope.)
			Using package As Package = Package.Open(packagePath, FileMode.Open, FileAccess.Read)
				Dim documentPart As PackagePart = Nothing
				Dim resourcePart As PackagePart = Nothing

				' Get the Package Relationships and look for
				'   the Document part based on the RelationshipType
				Dim uriDocumentTarget As Uri = Nothing
				For Each relationship As PackageRelationship In package.GetRelationshipsByType(PackageRelationshipType)
					' Resolve the Relationship Target Uri
					'   so the Document Part can be retrieved.
					uriDocumentTarget = PackUriHelper.ResolvePartUri(New Uri("/", UriKind.Relative), relationship.TargetUri)

					' Open the Document Part, write the contents to a file.
					documentPart = package.GetPart(uriDocumentTarget)
					ExtractPart(documentPart, targetDirectory)
				Next relationship

				' Get the Document part's Relationships,
				'   and look for required resources.
				Dim uriResourceTarget As Uri = Nothing
				For Each relationship As PackageRelationship In documentPart.GetRelationshipsByType(ResourceRelationshipType)
					' Resolve the Relationship Target Uri
					'   so the Resource Part can be retrieved.
					uriResourceTarget = PackUriHelper.ResolvePartUri(documentPart.Uri, relationship.TargetUri)

					' Open the Resource Part and write the contents to a file.
					resourcePart = package.GetPart(uriResourceTarget)
					ExtractPart(resourcePart, targetDirectory)
				Next relationship

			End Using ' end:using(Package package) - Close & dispose package.
			'</SnippetPackageReadUsing>

		End Sub ' end:ExtractPackageParts()


		'<SnippetPackageReadExtract>
		'  --------------------------- ExtractPart ---------------------------
		''' <summary>
		'''   Extracts a specified package part to a target folder.</summary>
		''' <param name="packagePart">
		'''   The package part to extract.</param>
		''' <param name="targetDirectory">
		'''   The relative path from the 'current' directory
		'''   to the targer folder.</param>
		Private Shared Sub ExtractPart(ByVal packagePart As PackagePart, ByVal targetDirectory As String)
			' Create a string with the full path to the target directory.
			Dim currentDirectory As String = Directory.GetCurrentDirectory()
			Dim pathToTarget As String = currentDirectory & "\" & targetDirectory

			' Remove leading slash from the Part Uri,
			'   and make a new Uri from the result
			Dim stringPart As String = packagePart.Uri.ToString().TrimStart("/"c)
			Dim partUri As New Uri(stringPart, UriKind.Relative)

			' Create a full Uri to the Part based on the Package Uri
			Dim uriFullPartPath As New Uri(New Uri(pathToTarget, UriKind.Absolute), partUri)

			' Create the necessary Directories based on the Full Part Path
			Directory.CreateDirectory(Path.GetDirectoryName(uriFullPartPath.LocalPath))

			' Create the file with the Part content
			Using fileStream As New FileStream(uriFullPartPath.LocalPath, FileMode.Create)
				CopyStream(packagePart.GetStream(), fileStream)
			End Using ' end:using(FileStream fileStream) - Close & dispose fileStream.
		End Sub ' end:ExtractPart()


		'  --------------------------- CopyStream ---------------------------
		''' <summary>
		'''   Copies data from a source stream to a target stream.</summary>
		''' <param name="source">
		'''   The source stream to copy from.</param>
		''' <param name="target">
		'''   The destination stream to copy to.</param>
		Private Shared Sub CopyStream(ByVal source As Stream, ByVal target As Stream)
			Const bufSize As Integer = &H1000
			Dim buf(bufSize - 1) As Byte
			Dim bytesRead As Integer = 0
			bytesRead = source.Read(buf, 0, bufSize)
			Do While bytesRead > 0
				target.Write(buf, 0, bytesRead)
				bytesRead = source.Read(buf, 0, bufSize)
			Loop
		End Sub ' end:CopyStream()
		'</SnippetPackageReadExtract>

	End Class ' end:class PackageRead

End Namespace ' end:namespace SDKSample
