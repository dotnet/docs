Imports System
Imports System.Windows
Imports System.Windows.Xps.Packaging
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates


Namespace SDKSample
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Public Class SignatureUtilites

		'<SnippetIterateSignatureDefinitions>

		' -------------------- IterateSignatureDefinitions --------------------
		''' <summary>
		'''   Interates through the SignatureDefinition contained in a given
		'''   XPS document displaying and updating the signature properties
		'''   through a user dialog.</summary>
		''' <param name="signatureDialog">
		'''   The user dialog to use in displaying and
		'''   updating the signature information.</param>
		''' <param name="xpsDocument">
		'''   The XPS document containing the signature information.</param>
		Public Sub IterateSignatureDefinitions(ByVal signatureDialog As SignatureDialog, ByVal xpsDocument As XpsDocument)
			Dim docSeq As IXpsFixedDocumentSequenceReader = xpsDocument.FixedDocumentSequenceReader

			' For every FixedDocument in the XPS document.
			For Each doc As IXpsFixedDocumentReader In docSeq.FixedDocuments
				' For every SignatureDefinition in each FixedDocument.
				For Each signature As XpsSignatureDefinition In doc.SignatureDefinitions
					Dim item As SignatureDisplayItem = signatureDialog.AddSignatureItem(signature)

					' Signatures are bound to signature definitions by GUID.
					' If the SignatureDefintion SpotId is the same as the
					' SignatureId, the signature is signing that definition.

					' For every signature in the XPS document.
					For Each sig As XpsDigitalSignature In xpsDocument.Signatures
						If sig.Id IsNot Nothing AndAlso sig.Id = signature.SpotId Then
							Dim cert As X509Certificate2 = TryCast(sig.SignerCertificate, X509Certificate2)
							item.Signer = cert.GetNameInfo(X509NameType.SimpleName, False)
							item.IsSigned = True
						End If
					Next sig ' end:foreach (XpsDigitalSignature

				Next signature ' end:foreach (XpsSignatureDefinition

			Next doc ' end:foreach (IXpsFixedDocumentReader

		End Sub ' end:IterateSignatureDefinitions()

		'</SnippetIterateSignatureDefinitions>

		' ------------------------- IterateSignatures ------------------------
		''' <summary>
		'''   Interates through signatures that are not associated with
		'''   a SignatureDefinition.</summary>
		''' <param name="signatureDialog">
		'''   The user dialog to use in displaying and
		'''   updating the signature information.</param>
		''' <param name="xpsDocument">
		'''   The XPS document containing the signature information.</param>
		Public Sub IterateSignatures(ByVal signatureDialog As SignatureDialog, ByVal xpsDocument As XpsDocument)
			Dim found As Boolean = False
			Dim docSeq As IXpsFixedDocumentSequenceReader = xpsDocument.FixedDocumentSequenceReader

			' For every signature in the XPS document.
			For Each sig As XpsDigitalSignature In xpsDocument.Signatures
				found = False

				' For every FixedDocument in the XPS document.
				For Each doc As IXpsFixedDocumentReader In docSeq.FixedDocuments
					' For every SignatureDefinition in each FixedDocument.
					For Each signature As XpsSignatureDefinition In doc.SignatureDefinitions
						If sig.Id IsNot Nothing AndAlso sig.Id = signature.SpotId Then
							found = True
							Exit For
						End If
					Next signature 'end:foreach (XpsSignatureDefinition

					If found Then
						Exit For
					End If
				Next doc ' end:foreach (IXpsFixedDocument

				If Not found Then
					Dim item As SignatureDisplayItem = signatureDialog.AddSignatureItem(Nothing)
					Dim cert As X509Certificate2 = TryCast(sig.SignerCertificate, X509Certificate2)
					item.Signer = cert.GetNameInfo(X509NameType.SimpleName, False)
					item.IsSigned = True
				End If
			Next sig ' end:foreach (XpsDigitalSignature

		End Sub ' end:IterateSignatures()


		'<SnippetSignXpsDocument>

		' ------------------------------ SignXps -----------------------------
		''' <summary>
		'''   Signs an XPS document with a given X509 certificate, and if one
		'''   exists, associates the signature with a given SignatureDefintion
		'''   spotId GUID.</summary>
		''' <param name="xpsDocument">
		'''   The XPS document to sign.</param>
		''' <param name="cert">
		'''   The X509 certificate to use for signing.</param>
		''' <param name="spotId">
		'''   The nullable spotId GUID of the signature definition.</param>
		Public Sub SignXps(ByVal xpsDocument As XpsDocument, ByVal cert As X509Certificate, ByVal spotId? As Guid)
			' If there's a SignatureDefinition spotId,
			' associate it with the signature.
			If spotId IsNot Nothing Then
				xpsDocument.SignDigitally(cert, True, XpsDigSigPartAlteringRestrictions.None, spotId.Value)
			Else
				xpsDocument.SignDigitally(cert, True, XpsDigSigPartAlteringRestrictions.None)
			End If

		End Sub ' end:SignXps()

		'</SnippetSignXpsDocument>

	End Class ' end:class SignatureUtilites

End Namespace ' end:namespace
