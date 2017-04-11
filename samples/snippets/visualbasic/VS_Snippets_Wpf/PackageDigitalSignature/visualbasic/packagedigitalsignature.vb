' PackageDigitalSignature SDK Sample - PackageDigitalSignature.vb
' Copyright (c) Microsoft Corporation. All rights reserved.

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.IO.Packaging
Imports System.Security.Cryptography
' for CryptographicException
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Permissions
Imports System.Collections
Imports System.Collections.Generic
Imports System.Windows
' for MessageBox
Namespace SDKSample
    Class PackageDigitalSignatureSample
        Private Shared _targetDirectory As String = "Target"
        Private Shared _packageFilename As String = "myPackage.package"
        Private Shared _samplePackageRelationshipType As String = "http://schemas.microsoft.com/opc/2006/06/sample/document"
        Private Shared _sampleResourceRelationshipType As String = "http://schemas.microsoft.com/xps/2005/06/required-resource"
        Private Shared _digitalSignatureUri As String = "/package/services/digital-signature/_rels/origin.psdsor.rels"


        ' ------------------------------ Main -------------------------------
        Public Shared Sub Main()
            Dim msg As String
            msg = "Click OK to create '" & _packageFilename & "' " & Constants.vbLf & "with X.509 digitally signed parts."
            If MessageBox.Show(msg, "Create New Package", MessageBoxButton.OKCancel) <> MessageBoxResult.OK Then
                Exit Sub
            End If

            ' Create the package from /Content and /Resources items.
            CreatePackage(_packageFilename)

            msg = (("'" & _packageFilename & "' created." & vbLf & vbLf & "Click OK to validate signed parts and extract parts" & vbLf & "from '") + _packageFilename & "' to '") + _targetDirectory & "' folder."
            If MessageBox.Show(msg, "Extract Package Parts", MessageBoxButton.OKCancel) <> MessageBoxResult.OK Then
                Exit Sub
            End If

            ' Validate and extract the parts from the new package to /Target.
            ExtractPackageParts(_packageFilename)

            msg = ("'" & _packageFilename & "' parts validated" & vbLf & "and extracted to '") + _targetDirectory & "' folder." & vbLf & vbLf & "End of Program."
            MessageBox.Show(msg, "End of Program", MessageBoxButton.OK)
        End Sub


        ' -------------------------- CreatePackage --------------------------
        ''' <summary>
        ''' Creates a package zip file containing specified
        ''' content and resource files.</summary>
        ''' <param name="packageFilename">
        ''' The filename of the Package to create.</param>
        Private Shared Sub CreatePackage(ByVal packageFilename As [String])
            ' Create URIs for the parts that will be added to the Package.
            Dim uriDocument As New Uri("Content\Document.xml", UriKind.Relative)
            Dim uriResource As New Uri("Resources\Image1.jpg", UriKind.Relative)

            ' CreatePartUri converts the content file names to part names.
            Dim partUriDocument As Uri = PackUriHelper.CreatePartUri(uriDocument)
            Dim partUriResource As Uri = PackUriHelper.CreatePartUri(uriResource)

            ' Create the Package
            ' (If the package file already exists, FileMode.Create will
            ' automatically delete it first before creating a new one.
            ' The 'using' keyword ensures that 'package' is
            ' closed and disposed when it goes out of scope.)
            Using package__1 As Package = Package.Open(packageFilename, FileMode.Create)
                ' Add a Document part to the Package.
                Dim packagePartDocument As PackagePart = package__1.CreatePart(partUriDocument, System.Net.Mime.MediaTypeNames.Text.Xml)

                ' Add content to the Document Part.
                Using fileStream As New FileStream(uriDocument.ToString(), FileMode.Open, FileAccess.Read)
                    CopyStream(fileStream, packagePartDocument.GetStream())
                End Using

                ' Add a Package Relationship to the Document Part.
                package__1.CreateRelationship(packagePartDocument.Uri, TargetMode.Internal, _samplePackageRelationshipType)

                ' Add a Resource Part to the Package.
                Dim packagePartResource As PackagePart = package__1.CreatePart(partUriResource, System.Net.Mime.MediaTypeNames.Image.Jpeg)

                ' Add content to the Resource Part
                Using fileStream As New FileStream(uriResource.ToString(), FileMode.Open, FileAccess.Read)
                    CopyStream(fileStream, packagePartResource.GetStream())
                End Using

                ' Add a Relationship from the Document part to the Resource part
                packagePartDocument.CreateRelationship(New Uri("../Resources/Image1.jpg", UriKind.Relative), TargetMode.Internal, _sampleResourceRelationshipType)

                ' Flush the package to ensure all data is written.
                package__1.Flush()

                ' Digitally sign all the Parts and Relationships in the Package.

                SignAllParts(package__1)
                ' end:using (package) - Close and dispose 'package'
            End Using
        End Sub
        ' end:CreatePackage()

        ' ----------------------- ExtractPackageParts -----------------------
        ''' <summary>
        ''' Unpacks the content of a Package including resources.</summary>
        ''' <param name="packageFilename">
        ''' The filename of the package to unpack.</param>
        ''' <remarks>
        ''' Extracting parts from the Package is done without knowledge of the
        ''' Package content. Relationships are used to locate the package
        ''' parts to be extracted.</remarks>
        Private Shared Sub ExtractPackageParts(ByVal packageFilename As String)
            ' Create a string with the full target directory path.
            Dim targetDirectory As String = (Directory.GetCurrentDirectory() & "\") + _targetDirectory

            ' If the target directory exists, delete it and create an empty one.
            Dim directoryInfo As New DirectoryInfo(targetDirectory)
            If directoryInfo.Exists Then
                directoryInfo.Delete(True)
            End If
            directoryInfo = Directory.CreateDirectory(targetDirectory)

            ' Move the current Package to the Target directory.
            Dim targetFilename As String = (targetDirectory & "\") + packageFilename
            File.Copy(packageFilename, targetFilename)

            ' Open the Package copy in the target directory.
            Using package__1 As Package = Package.Open(targetFilename, FileMode.Open, FileAccess.Read)
                ' Validate the Package Signatures.
                ' If all package signatures are valid, go ahead and unpack.
                If ValidateSignatures(package__1) Then
                    Dim packagePartDocument As PackagePart = Nothing
                    Dim packagePartResource As PackagePart = Nothing

                    ' Get the Package Relationships and look for
                    ' the Document part based on the RelationshipType.
                    For Each relationship As PackageRelationship In package__1.GetRelationshipsByType(_samplePackageRelationshipType)
                        ' Open the Document part, write the contents to a file.
                        packagePartDocument = package__1.GetPart(relationship.TargetUri)
                        ExtractPart(packagePartDocument, targetFilename)
                    Next

                    ' Get the Document part's Relationships,
                    ' and look for required resources.
                    Dim uriResourceTarget As Uri = Nothing
                    For Each relationship As PackageRelationship In packagePartDocument.GetRelationshipsByType(_sampleResourceRelationshipType)
                        ' Resolve the Relationship Target Uri
                        ' so the Resource Part can be retrieved.
                        uriResourceTarget = PackUriHelper.ResolvePartUri(packagePartDocument.Uri, relationship.TargetUri)

                        ' Open the Resource Part and write the contents to a file
                        packagePartResource = package__1.GetPart(uriResourceTarget)
                        ExtractPart(packagePartResource, targetFilename)
                    Next
                Else
                    ' end:if (ValidateSignature(package))
                    ' Display error message if signature validation fails.
                    ' if (ValidateSignatures(package) == false)
                    Dim msg As String = "Digital signatures in '" & packageFilename & vbLf & "' failed validation. Unpacking canceled."
                    MessageBox.Show(msg, "Digital Signature Validation Error", MessageBoxButton.OK, MessageBoxImage.[Error])

                End If
                ' end:using (package} - Close and dispose 'package'
            End Using
        End Sub
        ' end:ExtractPackageParts()

        ' --------------------------- ExtractPart ---------------------------
        ''' <summary>
        ''' Extracts a specified part from a given package.</summary>
        ''' <param name="packagePart">
        ''' The package part to unpack.</param>
        ''' <param name="packageFilename">
        ''' The path and filename of package to unpack the part from.</param>
        Private Shared Sub ExtractPart(ByVal packagePart As PackagePart, ByVal packageFilename As String)
            ' Remove leading slash from Part Uri,
            ' make a new Uri from the result.
            Dim stringPart As String = packagePart.Uri.ToString().TrimStart("/"c)
            Dim partUri As New Uri(stringPart, UriKind.Relative)

            ' Create a full Uri to the Part based on the Package Uri.
            Dim uriFullPartPath As New Uri(New Uri(packageFilename, UriKind.Absolute), partUri)

            ' Create the necessary Directories based on the full part path.
            Directory.CreateDirectory(Path.GetDirectoryName(uriFullPartPath.LocalPath))

            ' Create the file with the Part content
            Using fileStream As New FileStream(uriFullPartPath.LocalPath, FileMode.Create)
                CopyStream(packagePart.GetStream(), fileStream)
            End Using
        End Sub
        ' end:ExtractPart()

        ' --------------------------- CopyStream ---------------------------
        ''' <summary>
        ''' Copies data from a source stream to a target stream.</summary>
        ''' <param name="source">
        ''' The source stream to copy from.</param>
        ''' <param name="target">
        ''' The destination stream to copy to.</param>
        Private Shared Sub CopyStream(ByVal source As Stream, ByVal target As Stream)
            Const bufSize As Integer = &H1000
            Dim buf As Byte() = New Byte(bufSize - 1) {}
            Dim bytesRead As Integer = 0
            While (InlineAssignHelper(bytesRead, source.Read(buf, 0, bufSize))) > 0
                target.Write(buf, 0, bytesRead)
            End While
        End Sub


        '<SnippetPackageDigSigValidate>
        ' ------------------------ ValidateSignatures ------------------------
        ''' <summary>
        ''' Validates all the digital signatures of a given package.</summary>
        ''' <param name="package">
        ''' The package for validating digital signatures.</param>
        ''' <returns>
        ''' true if all digital signatures are valid; otherwise false if the
        ''' package is unsigned or any of the signatures are invalid.</returns>
        Private Shared Function ValidateSignatures(ByVal package As Package) As Boolean
            If package Is Nothing Then
                Throw New ArgumentNullException("ValidateSignatures(package)")
            End If

            ' Create a PackageDigitalSignatureManager for the given Package.
            Dim dsm As New PackageDigitalSignatureManager(package)

            ' Check to see if the package contains any signatures.
            If Not dsm.IsSigned Then
                Return False
            End If
            ' The package is not signed.
            ' Verify that all signatures are valid.
            Dim result As VerifyResult = dsm.VerifySignatures(False)
            If result <> VerifyResult.Success Then
                Return False
            End If
            ' One or more digital signatures are invalid.
            ' else if (result == VerifyResult.Success)
            ' All signatures are valid.
            Return True
        End Function
        ' end:ValidateSignatures()
        '</SnippetPackageDigSigValidate>

        '<SnippetPackageDigSigSign>
        Private Shared Sub SignAllParts(ByVal package As Package)
            If package Is Nothing Then
                Throw New ArgumentNullException("SignAllParts(package)")
            End If

            ' Create the DigitalSignature Manager
            Dim dsm As New PackageDigitalSignatureManager(package)
            dsm.CertificateOption = CertificateEmbeddingOption.InSignaturePart

            ' Create a list of all the part URIs in the package to sign
            ' (GetParts() also includes PackageRelationship parts).
            Dim toSign As New System.Collections.Generic.List(Of Uri)()
            For Each packagePart As PackagePart In package.GetParts()
                ' Add all package parts to the list for signing.
                toSign.Add(packagePart.Uri)
            Next

            ' Add the URI for SignatureOrigin PackageRelationship part.
            ' The SignatureOrigin relationship is created when Sign() is called.
            ' Signing the SignatureOrigin relationship disables counter-signatures.
            toSign.Add(PackUriHelper.GetRelationshipPartUri(dsm.SignatureOrigin))

            ' Also sign the SignatureOrigin part.
            toSign.Add(dsm.SignatureOrigin)

            ' Add the package relationship to the signature origin to be signed.
            toSign.Add(PackUriHelper.GetRelationshipPartUri(New Uri("/", UriKind.RelativeOrAbsolute)))

            ' Sign() will prompt the user to select a Certificate to sign with.
            Try
                dsm.Sign(toSign)
            Catch ex As CryptographicException

                ' If there are no certificates or the SmartCard manager is
                ' not running, catch the exception and show an error message.
                MessageBox.Show("Cannot Sign" & vbLf & ex.Message, "No Digital Certificates Available", MessageBoxButton.OK, MessageBoxImage.Exclamation)

            End Try
        End Sub
        Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
            target = value
            Return value
        End Function
        ' end:SignAllParts()
        '</SnippetPackageDigSigSign>

    End Class
    ' end:class PackageDigitalSignatureSample
End Namespace
' end:namespace SDKSample