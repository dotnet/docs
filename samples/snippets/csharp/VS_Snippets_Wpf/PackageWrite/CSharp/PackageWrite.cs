//-----------------------------------------------------------------------------
// <copyright file="PackageWrite.cs" company="Microsoft">
//   Copyright (C) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// Description:
//   PackageWrite shows how to write a Package zip file
//   containing content, resource, and relationship parts.
//-----------------------------------------------------------------------------


using System;
using System.IO;
using System.IO.Packaging;
using System.Windows;


namespace SDKSample
{
    class PackageWrite
    {
        // Relative path and filename of the Package zip file to write.
        private static string packagePath  = @"myPackage.package";
        // Relative path and filename of the content file to add to the package.
        private static string documentPath = @"Content\Document.xml";
        // Relative path and filename of the resource file to add to the package.
        private static string resourcePath = @"Resources\Image1.jpg";

        private const string PackageRelationshipType =
            @"http://schemas.microsoft.com/opc/2006/sample/document";
        private const string ResourceRelationshipType =
            @"http://schemas.microsoft.com/opc/2006/sample/required-resource";


        //  ------------------------------ Main -------------------------------
        public static void Main()
        {
            // Create a Package zip file containing content and resource files.
            CreatePackage();

            MessageBox.Show("Normal Completion:\n" + "Successfully packaged '" +
                documentPath + "' and\n'" + resourcePath + "' into new '" +
                packagePath + "' zip file.", "End of Program",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }// end:main()


        //<SnippetPackageWriteCreatePackage>
        //  -------------------------- CreatePackage --------------------------
        /// <summary>
        ///   Creates a package zip file containing specified
        ///   content and resource files.</summary>
        private static void CreatePackage()
        {
            //<SnippetPackageWriteCreatePartUri>
            // Convert system path and file names to Part URIs. In this example
            // Uri partUriDocument /* /Content/Document.xml */ =
            //     PackUriHelper.CreatePartUri(
            //         new Uri("Content\Document.xml", UriKind.Relative));
            // Uri partUriResource /* /Resources/Image1.jpg */ =
            //     PackUriHelper.CreatePartUri(
            //         new Uri("Resources\Image1.jpg", UriKind.Relative));
            Uri partUriDocument = PackUriHelper.CreatePartUri(
                                      new Uri(documentPath, UriKind.Relative));
            Uri partUriResource = PackUriHelper.CreatePartUri(
                                      new Uri(resourcePath, UriKind.Relative));
            //</SnippetPackageWriteCreatePartUri>

            // Create the Package
            // (If the package file already exists, FileMode.Create will
            //  automatically delete it first before creating a new one.
            //  The 'using' statement insures that 'package' is
            //  closed and disposed when it goes out of scope.)
            //<SnippetPackageWriteUsingPackage>
            using (Package package =
                Package.Open(packagePath, FileMode.Create))
            {
                //<SnippetPackageWriteCreatePackageRelationship>
                //<SnippetPackageWriteCreatePart>
                // Add the Document part to the Package
                PackagePart packagePartDocument =
                    package.CreatePart(partUriDocument,
                                   System.Net.Mime.MediaTypeNames.Text.Xml);

                // Copy the data to the Document Part
                using (FileStream fileStream = new FileStream(
                       documentPath, FileMode.Open, FileAccess.Read))
                {
                    CopyStream(fileStream, packagePartDocument.GetStream());
                }// end:using(fileStream) - Close and dispose fileStream.
                //</SnippetPackageWriteCreatePart>

                // Add a Package Relationship to the Document Part
                package.CreateRelationship(packagePartDocument.Uri,
                                           TargetMode.Internal,
                                           PackageRelationshipType);
                //</SnippetPackageWriteCreatePackageRelationship>

                //<SnippetPackageWriteCreateRelationship>
                // Add a Resource Part to the Package
                PackagePart packagePartResource =
                    package.CreatePart(partUriResource,
                                   System.Net.Mime.MediaTypeNames.Image.Jpeg);

                // Copy the data to the Resource Part
                using (FileStream fileStream = new FileStream(
                       resourcePath, FileMode.Open, FileAccess.Read))
                {
                    CopyStream(fileStream, packagePartResource.GetStream());
                }// end:using(fileStream) - Close and dispose fileStream.

                // Add Relationship from the Document part to the Resource part
                packagePartDocument.CreateRelationship(
                                        new Uri(@"../resources/image1.jpg",
                                        UriKind.Relative),
                                        TargetMode.Internal,
                                        ResourceRelationshipType);
                //</SnippetPackageWriteCreateRelationship>

            }// end:using (Package package) - Close and dispose package.
            //</SnippetPackageWriteUsingPackage>

        }// end:CreatePackage()


        //  --------------------------- CopyStream ---------------------------
        /// <summary>
        ///   Copies data from a source stream to a target stream.</summary>
        /// <param name="source">
        ///   The source stream to copy from.</param>
        /// <param name="target">
        ///   The destination stream to copy to.</param>
        private static void CopyStream(Stream source, Stream target)
        {
            const int bufSize = 0x1000;
            byte[] buf = new byte[bufSize];
            int bytesRead = 0;
            while ((bytesRead = source.Read(buf, 0, bufSize)) > 0)
                target.Write(buf, 0, bytesRead);
        }// end:CopyStream()
        //</SnippetPackageWriteCreatePackage>

    }// end:class PackageWrite

}// end:namespace SDKSample
