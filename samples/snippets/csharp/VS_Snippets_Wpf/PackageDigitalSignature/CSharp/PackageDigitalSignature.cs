// PackageDigitalSignature SDK Sample - PackageDigitalSignature.cs
// Copyright (c) Microsoft Corporation. All rights reserved.

using System;
using System.IO;
using System.IO.Packaging;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Collections;
using System.Collections.Generic;
using System.Windows;

namespace SDKSample
{
    class PackageDigitalSignatureSample
    {
        private static string _targetDirectory = @"Target";
        private static string _packageFilename = @"myPackage.package";
        private static string _samplePackageRelationshipType =
            "http://schemas.microsoft.com/opc/2006/06/sample/document";
        private static string _sampleResourceRelationshipType =
            "http://schemas.microsoft.com/xps/2005/06/required-resource";
        private static string _digitalSignatureUri =
            "/package/services/digital-signature/_rels/origin.psdsor.rels";


        //  ------------------------------ Main -------------------------------
        public static void Main()
        {
            string msg;
            msg = "Click OK to create '" + _packageFilename +
                  "' \nwith X.509 digitally signed parts.";
            if (MessageBox.Show(msg, "Create New Package",
                MessageBoxButton.OKCancel) != MessageBoxResult.OK)  return;

            // Create the package from /Content and /Resources items.
            CreatePackage(_packageFilename);

            msg = "'" + _packageFilename + "' created.\n\n" +
                  "Click OK to validate signed parts and extract parts\nfrom '" +
                  _packageFilename + "' to '" + _targetDirectory + "' folder.";
            if (MessageBox.Show(msg, "Extract Package Parts",
                MessageBoxButton.OKCancel) != MessageBoxResult.OK)  return;

            // Validate and extract the parts from the new package to /Target.
            ExtractPackageParts(_packageFilename);

            msg = "'" + _packageFilename + "' parts validated\nand extracted to '" +
                  _targetDirectory + "' folder.\n\nEnd of Program.";
            MessageBox.Show(msg, "End of Program", MessageBoxButton.OK);
        }


        //  -------------------------- CreatePackage --------------------------
        /// <summary>
        ///   Creates a package zip file containing specified
        ///   content and resource files.</summary>
        /// <param name="packageFilename">
        ///   The filename of the Package to create.</param>
        private static void CreatePackage(String packageFilename)
        {
            // Create URIs for the parts that will be added to the Package.
            Uri uriDocument = new Uri(@"Content\Document.xml", UriKind.Relative);
            Uri uriResource = new Uri(@"Resources\Image1.jpg", UriKind.Relative);

            // CreatePartUri converts the content file names to part names.
            Uri partUriDocument = PackUriHelper.CreatePartUri(uriDocument);
            Uri partUriResource = PackUriHelper.CreatePartUri(uriResource);

            // Create the Package
            // (If the package file already exists, FileMode.Create will
            //  automatically delete it first before creating a new one.
            //  The 'using' keyword ensures that 'package' is
            //  closed and disposed when it goes out of scope.)
            using (Package package =
                           Package.Open(packageFilename, FileMode.Create))
            {
                // Add a Document part to the Package.
                PackagePart packagePartDocument =
                    package.CreatePart(partUriDocument,
                                    System.Net.Mime.MediaTypeNames.Text.Xml);

                // Add content to the Document Part.
                using (FileStream fileStream =
                    new FileStream(uriDocument.ToString(), FileMode.Open, FileAccess.Read))
                {
                    CopyStream(fileStream, packagePartDocument.GetStream());
                }

                // Add a Package Relationship to the Document Part.
                package.CreateRelationship(packagePartDocument.Uri,
                    TargetMode.Internal, _samplePackageRelationshipType);

                // Add a Resource Part to the Package.
                PackagePart packagePartResource =
                    package.CreatePart(partUriResource,
                                    System.Net.Mime.MediaTypeNames.Image.Jpeg);

                // Add content to the Resource Part
                using (FileStream fileStream =
                    new FileStream(uriResource.ToString(), FileMode.Open, FileAccess.Read))
                {
                    CopyStream(fileStream, packagePartResource.GetStream());
                }

                // Add a Relationship from the Document part to the Resource part
                packagePartDocument.CreateRelationship(
                                        new Uri(@"../Resources/Image1.jpg",
                                        UriKind.Relative),
                                        TargetMode.Internal,
                                        _sampleResourceRelationshipType);

                // Flush the package to ensure all data is written.
                package.Flush();

                // Digitally sign all the Parts and Relationships in the Package.
                SignAllParts(package);

            }// end:using (package) - Close and dispose 'package'

        }// end:CreatePackage()


        //  ----------------------- ExtractPackageParts -----------------------
        /// <summary>
        ///   Unpacks the content of a Package including resources.</summary>
        /// <param name="packageFilename">
        ///   The filename of the package to unpack.</param>
        /// <remarks>
        ///   Extracting parts from the Package is done without knowledge of the
        ///   Package content.  Relationships are used to locate the package
        ///   parts to be extracted.</remarks>
        private static void ExtractPackageParts(string packageFilename)
        {
            // Create a string with the full target directory path.
            string targetDirectory =
                Directory.GetCurrentDirectory() + @"\" + _targetDirectory;

            // If the target directory exists, delete it and create an empty one.
            DirectoryInfo directoryInfo = new DirectoryInfo(targetDirectory);
            if (directoryInfo.Exists)
                directoryInfo.Delete(true);
            directoryInfo = Directory.CreateDirectory(targetDirectory);

            // Move the current Package to the Target directory.
            string targetFilename = targetDirectory + @"\" + packageFilename;
            File.Copy(packageFilename, targetFilename);

            // Open the Package copy in the target directory.
            using (Package package =
                Package.Open(targetFilename, FileMode.Open, FileAccess.Read))
            {
                // Validate the Package Signatures.
                // If all package signatures are valid, go ahead and unpack.
                if (ValidateSignatures(package))
                {
                    PackagePart packagePartDocument = null;
                    PackagePart packagePartResource = null;

                    // Get the Package Relationships and look for
                    // the Document part based on the RelationshipType.
                    foreach (PackageRelationship relationship in
                        package.GetRelationshipsByType(
                                            _samplePackageRelationshipType))
                    {
                        // Open the Document part, write the contents to a file.
                        packagePartDocument = package.GetPart(
                                                      relationship.TargetUri);
                        ExtractPart(packagePartDocument, targetFilename);
                    }

                    // Get the Document part's Relationships,
                    //   and look for required resources.
                    Uri uriResourceTarget = null;
                    foreach (PackageRelationship relationship in
                        packagePartDocument.GetRelationshipsByType(
                                               _sampleResourceRelationshipType))
                    {
                        // Resolve the Relationship Target Uri
                        //   so the Resource Part can be retrieved.
                        uriResourceTarget = PackUriHelper.ResolvePartUri(
                            packagePartDocument.Uri, relationship.TargetUri);

                        // Open the Resource Part and write the contents to a file
                        packagePartResource = package.GetPart(uriResourceTarget);
                        ExtractPart(packagePartResource, targetFilename);
                    }
                }// end:if (ValidateSignature(package))

                // Display error message if signature validation fails.
                else // if (ValidateSignatures(package) == false)
                {
                    string msg = "Digital signatures in '" + packageFilename +
                        "\n' failed validation.  Unpacking canceled.";
                    MessageBox.Show(msg, "Digital Signature Validation Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }// end:using (package} - Close and dispose 'package'

        }// end:ExtractPackageParts()


        //  --------------------------- ExtractPart ---------------------------
        /// <summary>
        ///   Extracts a specified part from a given package.</summary>
        /// <param name="packagePart">
        ///   The package part to unpack.</param>
        /// <param name="packageFilename">
        ///   The path and filename of package to unpack the part from.</param>
        private static void ExtractPart(
                PackagePart packagePart, string packageFilename)
        {
            // Remove leading slash from Part Uri,
            //   make a new Uri from the result.
            string stringPart = packagePart.Uri.ToString().TrimStart('/');
            Uri partUri = new Uri(stringPart, UriKind.Relative);

            // Create a full Uri to the Part based on the Package Uri.
            Uri uriFullPartPath =
                new Uri(new Uri(packageFilename, UriKind.Absolute), partUri);

            // Create the necessary Directories based on the full part path.
            Directory.CreateDirectory(
                Path.GetDirectoryName(uriFullPartPath.LocalPath));

            // Create the file with the Part content
            using (FileStream fileStream =
                new FileStream(uriFullPartPath.LocalPath, FileMode.Create))
            {
                CopyStream(packagePart.GetStream(), fileStream);
            }
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
        }


        //<SnippetPackageDigSigValidate>
        // ------------------------ ValidateSignatures ------------------------
        /// <summary>
        ///   Validates all the digital signatures of a given package.</summary>
        /// <param name="package">
        ///   The package for validating digital signatures.</param>
        /// <returns>
        ///   true if all digital signatures are valid; otherwise false if the
        ///   package is unsigned or any of the signatures are invalid.</returns>
        private static bool ValidateSignatures(Package package)
        {
            if (package == null)
                throw new ArgumentNullException("ValidateSignatures(package)");

            // Create a PackageDigitalSignatureManager for the given Package.
            PackageDigitalSignatureManager dsm =
                new PackageDigitalSignatureManager(package);

            // Check to see if the package contains any signatures.
            if (!dsm.IsSigned)
                return false;   // The package is not signed.

            // Verify that all signatures are valid.
            VerifyResult result = dsm.VerifySignatures(false);
            if (result != VerifyResult.Success)
                return false;   // One or more digital signatures are invalid.

            // else if (result == VerifyResult.Success)
            return true;        // All signatures are valid.

        }// end:ValidateSignatures()
        //</SnippetPackageDigSigValidate>


        //<SnippetPackageDigSigSign>
        private static void SignAllParts(Package package)
        {
            if (package == null)
                throw new ArgumentNullException("SignAllParts(package)");

            // Create the DigitalSignature Manager
            PackageDigitalSignatureManager dsm =
                new PackageDigitalSignatureManager(package);
            dsm.CertificateOption =
                CertificateEmbeddingOption.InSignaturePart;

            // Create a list of all the part URIs in the package to sign
            // (GetParts() also includes PackageRelationship parts).
            System.Collections.Generic.List<Uri> toSign =
                new System.Collections.Generic.List<Uri>();
            foreach (PackagePart packagePart in package.GetParts())
            {
                // Add all package parts to the list for signing.
                toSign.Add(packagePart.Uri);
            }

            // Add the URI for SignatureOrigin PackageRelationship part.
            // The SignatureOrigin relationship is created when Sign() is called.
            // Signing the SignatureOrigin relationship disables counter-signatures.
            toSign.Add(PackUriHelper.GetRelationshipPartUri(dsm.SignatureOrigin));

            // Also sign the SignatureOrigin part.
            toSign.Add(dsm.SignatureOrigin);

            // Add the package relationship to the signature origin to be signed.
            toSign.Add(PackUriHelper.GetRelationshipPartUri(new Uri("/", UriKind.RelativeOrAbsolute)));

            // Sign() will prompt the user to select a Certificate to sign with.
            try
            {
                dsm.Sign(toSign);
            }

            // If there are no certificates or the SmartCard manager is
            // not running, catch the exception and show an error message.
            catch (CryptographicException ex)
            {
                MessageBox.Show(
                    "Cannot Sign\n" + ex.Message,
                    "No Digital Certificates Available",
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
            }

        }// end:SignAllParts()

        //</SnippetPackageDigSigSign>

    }// end:class PackageDigitalSignatureSample

}// end:namespace SDKSample
