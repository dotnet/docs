'-----------------------------------------------------------------------------
' <copyright file="PackageWrite.vb" company="Microsoft">
'   Copyright (C) Microsoft Corporation.  All rights reserved.
' </copyright>
'
' Description:
'   PackageWrite shows how to write a Package zip file
'   containing content, resource, and relationship parts.
'-----------------------------------------------------------------------------



Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.IO.Packaging
Imports System.Windows


Namespace SDKSample
    Friend Class PackageWrite
        ' Relative path and filename of the Package zip file to write.
        Private Shared packagePath As String = "myPackage.package"
        ' Relative path and filename of the content file to add to the package.
        Private Shared documentPath As String = "Content\Document.xml"
        ' Relative path and filename of the resource file to add to the package.
        Private Shared resourcePath As String = "Resources\Image1.jpg"

        Private Const PackageRelationshipType As String = "http://schemas.microsoft.com/opc/2006/sample/document"
        Private Const ResourceRelationshipType As String = "http://schemas.microsoft.com/opc/2006/sample/required-resource"


        '  ------------------------------ Main -------------------------------
        Public Shared Sub Main()
            ' Create a Package zip file containing content and resource files.
            CreatePackage()

            MessageBox.Show("Normal Completion:" & vbLf & "Successfully packaged '" & documentPath & "' and" & vbLf & "'" & resourcePath & "' into new '" & packagePath & "' zip file.", "End of Program", MessageBoxButton.OK, MessageBoxImage.Information)
        End Sub ' end:main()


        '<SnippetPackageWriteCreatePackage>
        '  -------------------------- CreatePackage --------------------------
        ''' <summary>
        '''   Creates a package zip file containing specified
        '''   content and resource files.</summary>
        Private Shared Sub CreatePackage()
            '<SnippetPackageWriteCreatePartUri>
            ' Convert system path and file names to Part URIs. In this example
            ' Dim partUriDocument as Uri /* /Content/Document.xml */ =
            '     PackUriHelper.CreatePartUri(
            '         New Uri("Content\Document.xml", UriKind.Relative))
            ' Dim partUriResource as Uri /* /Resources/Image1.jpg */ =
            '     PackUriHelper.CreatePartUri(
            '         New Uri("Resources\Image1.jpg", UriKind.Relative))
            Dim partUriDocument As Uri = PackUriHelper.CreatePartUri(New Uri(documentPath, UriKind.Relative))
            Dim partUriResource As Uri = PackUriHelper.CreatePartUri(New Uri(resourcePath, UriKind.Relative))
            '</SnippetPackageWriteCreatePartUri>

            ' Create the Package
            ' (If the package file already exists, FileMode.Create will
            '  automatically delete it first before creating a new one.
            '  The 'using' statement insures that 'package' is
            '  closed and disposed when it goes out of scope.)
            '<SnippetPackageWriteUsingPackage>
            Using package As Package = Package.Open(packagePath, FileMode.Create)
                '<SnippetPackageWriteCreatePackageRelationship>
                '<SnippetPackageWriteCreatePart>
                ' Add the Document part to the Package
                Dim packagePartDocument As PackagePart = package.CreatePart(partUriDocument, System.Net.Mime.MediaTypeNames.Text.Xml)

                ' Copy the data to the Document Part
                Using fileStream As New FileStream(documentPath, FileMode.Open, FileAccess.Read)
                    CopyStream(fileStream, packagePartDocument.GetStream())
                End Using ' end:using(fileStream) - Close and dispose fileStream.
                '</SnippetPackageWriteCreatePart>

                ' Add a Package Relationship to the Document Part
                package.CreateRelationship(packagePartDocument.Uri, TargetMode.Internal, PackageRelationshipType)
                '</SnippetPackageWriteCreatePackageRelationship>

                '<SnippetPackageWriteCreateRelationship>
                ' Add a Resource Part to the Package
                Dim packagePartResource As PackagePart = package.CreatePart(partUriResource, System.Net.Mime.MediaTypeNames.Image.Jpeg)

                ' Copy the data to the Resource Part
                Using fileStream As New FileStream(resourcePath, FileMode.Open, FileAccess.Read)
                    CopyStream(fileStream, packagePartResource.GetStream())
                End Using ' end:using(fileStream) - Close and dispose fileStream.

                ' Add Relationship from the Document part to the Resource part
                packagePartDocument.CreateRelationship(New Uri("../resources/image1.jpg", UriKind.Relative), TargetMode.Internal, ResourceRelationshipType)
                '</SnippetPackageWriteCreateRelationship>

            End Using ' end:using (Package package) - Close and dispose package.
            '</SnippetPackageWriteUsingPackage>

        End Sub ' end:CreatePackage()


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
        '</SnippetPackageWriteCreatePackage>

    End Class ' end:class PackageWrite

End Namespace ' end:namespace SDKSample
