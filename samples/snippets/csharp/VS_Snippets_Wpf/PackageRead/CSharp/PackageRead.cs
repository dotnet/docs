//-----------------------------------------------------------------------------
// <copyright file="PackageRead.cs" company="Microsoft">
//   Copyright (C) Microsoft Corporation.  All rights reserved.</copyright>
//
// <summary>
//   PackageWrite shows how to read a Package zip file
//   extracting content, resource, and relationship parts.</summary>
//-----------------------------------------------------------------------------

using System;
using System.IO;
using System.IO.Packaging;
using System.Windows;

namespace SDKSample
{
    class PackageRead
    {
        private const string PackageRelationshipType =
            @"http://schemas.microsoft.com/opc/2006/sample/document";
        private const string ResourceRelationshipType =
            @"http://schemas.microsoft.com/opc/2006/sample/required-resource";


        //  ------------------------------ Main -------------------------------
        public static void Main()
        {
            // Path and filename of the Package zip file to extract from.
            string packagePath = @"myPackage.package";
            // Relative path to the destination folder to extract to.
            string targetDirectory = @"Target\";

            // Extract the parts contained in 'myPackage.package'
            //   zip file to the 'Target\' folder.
            ExtractPackageParts(packagePath, targetDirectory);

            MessageBox.Show("Normal Completion:\n" +
                "Successfully extracted document and resource parts\n" +
                "from '" + packagePath + "' zip to new '" +
                targetDirectory + "' folder.", "End of Program",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }// end:main()


        //  ----------------------- ExtractPackageParts -----------------------
        /// <summary>
        ///   Extracts content and resource parts from a given Package
        ///   zip file to a specified target directory.</summary>
        /// <param name="packagePath">
        ///   The relative path and filename of the Package zip file.</param>
        /// <param name="targetDirectory">
        ///   The relative path from the current directory to the targer folder.
        /// </param>
        private static void ExtractPackageParts(
            string packagePath, string targetDirectory)
        {
            // Create a new Target directory.  If the Target directory
            // exists, first delete it and then create a new empty one.
            DirectoryInfo directoryInfo = new DirectoryInfo(targetDirectory);
            if (directoryInfo.Exists)
                directoryInfo.Delete(true);
            directoryInfo.Create();

            //<SnippetPackageReadUsing>
            // Open the Package.
            // ('using' statement insures that 'package' is
            //  closed and disposed when it goes out of scope.)
            using (Package package =
                Package.Open(packagePath, FileMode.Open, FileAccess.Read))
            {
                PackagePart documentPart = null;
                PackagePart resourcePart = null;

                // Get the Package Relationships and look for
                //   the Document part based on the RelationshipType
                Uri uriDocumentTarget = null;
                foreach (PackageRelationship relationship in
                    package.GetRelationshipsByType(PackageRelationshipType))
                {
                    // Resolve the Relationship Target Uri
                    //   so the Document Part can be retrieved.
                    uriDocumentTarget = PackUriHelper.ResolvePartUri(
                        new Uri("/", UriKind.Relative), relationship.TargetUri);

                    // Open the Document Part, write the contents to a file.
                    documentPart = package.GetPart(uriDocumentTarget);
                    ExtractPart(documentPart, targetDirectory);
                }

                // Get the Document part's Relationships,
                //   and look for required resources.
                Uri uriResourceTarget = null;
                foreach (PackageRelationship relationship in
                    documentPart.GetRelationshipsByType(
                                            ResourceRelationshipType))
                {
                    // Resolve the Relationship Target Uri
                    //   so the Resource Part can be retrieved.
                    uriResourceTarget = PackUriHelper.ResolvePartUri(
                        documentPart.Uri, relationship.TargetUri);

                    // Open the Resource Part and write the contents to a file.
                    resourcePart = package.GetPart(uriResourceTarget);
                    ExtractPart(resourcePart, targetDirectory);
                }

            }// end:using(Package package) - Close & dispose package.
            //</SnippetPackageReadUsing>

        }// end:ExtractPackageParts()


        //<SnippetPackageReadExtract>
        //  --------------------------- ExtractPart ---------------------------
        /// <summary>
        ///   Extracts a specified package part to a target folder.</summary>
        /// <param name="packagePart">
        ///   The package part to extract.</param>
        /// <param name="targetDirectory">
        ///   The relative path from the 'current' directory
        ///   to the targer folder.</param>
        private static void ExtractPart(
            PackagePart packagePart, string targetDirectory)
        {
            // Create a string with the full path to the target directory.
            string currentDirectory = Directory.GetCurrentDirectory();
            string pathToTarget = currentDirectory + @"\" + targetDirectory;

            // Remove leading slash from the Part Uri,
            //   and make a new Uri from the result
            string stringPart = packagePart.Uri.ToString().TrimStart('/');
            Uri partUri = new Uri(stringPart, UriKind.Relative);

            // Create a full Uri to the Part based on the Package Uri
            Uri uriFullPartPath =
            new Uri(new Uri(pathToTarget, UriKind.Absolute), partUri);

            // Create the necessary Directories based on the Full Part Path
            Directory.CreateDirectory(
                Path.GetDirectoryName(uriFullPartPath.LocalPath));

            // Create the file with the Part content
            using (FileStream fileStream =
                new FileStream(uriFullPartPath.LocalPath, FileMode.Create))
            {
                CopyStream(packagePart.GetStream(), fileStream);
            }// end:using(FileStream fileStream) - Close & dispose fileStream.
        }// end:ExtractPart()


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
        //</SnippetPackageReadExtract>

    }// end:class PackageRead

}// end:namespace SDKSample
