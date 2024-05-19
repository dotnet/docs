---
title: System.Security.Cryptography.Xml.SignedXml class
description: Learn about the System.Security.Cryptography.Xml.SignedXml class.
ms.date: 12/31/2023
---
# System.Security.Cryptography.Xml.SignedXml class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Security.Cryptography.Xml.SignedXml> class is the .NET implementation of the World Wide Web Consortium (W3C) [XML Signature Syntax and Processing Specification](https://www.w3.org/TR/xmldsig-core/), also known as XMLDSIG (XML Digital Signature). XMLDSIG is a standards-based, interoperable way to sign and verify all or part of an XML document or other data that is addressable from a Uniform Resource Identifier (URI).

Use the <xref:System.Security.Cryptography.Xml.SignedXml> class whenever you need to share signed XML data between applications or organizations in a standard way. Any data signed using this class can be verified by any conforming implementation of the W3C specification for XMLDSIG.

The <xref:System.Security.Cryptography.Xml.SignedXml> class allows you to create the following three kinds of XML digital signatures:

| Signature Type       | Description                                                     |
|----------------------|-----------------------------------------------------------------|
| Enveloped signature  | The signature is contained within the XML element being signed. |
| Enveloping signature | The signed XML is contained within the `<Signature>` element.   |
| Internal detached signature | The signature and signed XML are in the same document, but neither element contains the other. |

There is also a fourth kind of signature called an external detached signature which is when the data and signature are in separate XML documents. External detached signatures are not supported by the <xref:System.Security.Cryptography.Xml.SignedXml> class.

## Structure of an XML signature

XMLDSIG creates a `<Signature>` element, which contains a digital signature of an XML document or other data that is addressable from a URI. The `<Signature>` element can optionally contain information about where to find a key that will verify the signature and which cryptographic algorithm was used for signing. The basic structure is as follows:

```xml
<Signature xmlns:ds="http://www.w3.org/2000/09/xmldsig#">
    <SignedInfo>
      <CanonicalizationMethod Algorithm="http://www.w3.org/TR/2001/REC-xml-c14n-20010315"/>
      <SignatureMethod Algorithm="http://www.w3.org/2000/09/xmldsig#rsa-sha1"/>
      <Reference URI="">
        <Transforms>
          <Transform Algorithm="http://www.w3.org/2000/09/xmldsig#enveloped-signature"/>
        </Transforms>
        <DigestMethod Algorithm="http://www.w3.org/2000/09/xmldsig#sha1"/>
        <DigestValue>Base64EncodedValue==</DigestValue>
      </Reference>
    </SignedInfo>
    <SignatureValue>AnotherBase64EncodedValue===</SignatureValue>
</Signature>
```

The main parts of this structure are:

- The `<CanonicalizationMethod>` element

    Specifies the rules for rewriting the `Signature` element from XML/text into bytes for signature validation. The default value in .NET is <http://www.w3.org/TR/2001/REC-xml-c14n-20010315>, which identifies a trustworthy algorithm. This element is represented by the <xref:System.Security.Cryptography.Xml.SignedInfo.CanonicalizationMethod?displayProperty=nameWithType> property.

- The `<SignatureMethod>` element

   Specifies the algorithm used for signature generation and validation, which was applied to the `<Signature>` element to produce the value in `<SignatureValue>`. In the previous example, the value <http://www.w3.org/2000/09/xmldsig#rsa-sha1> identifies an RSA PKCS1 SHA-1 signature. Due to collision problems with SHA-1, Microsoft recommends a security model based on SHA-256 or better. This element is represented by the <xref:System.Security.Cryptography.Xml.SignedXml.SignatureMethod> property.

- The `<SignatureValue>` element

   Specifies the cryptographic signature for the `<Signature>` element. If this signature does not verify, then some portion of the `<Signature>` block was tampered with, and the document is considered invalid. As long as the `<CanonicalizationMethod>` value is trustworthy, this value is highly resistant to tampering. This element is represented by the <xref:System.Security.Cryptography.Xml.SignedXml.SignatureValue> property.

- The `URI` attribute of the `<Reference>` element

   Specifies a data object using a URI reference. This attribute is represented by the <xref:System.Security.Cryptography.Xml.Reference.Uri?displayProperty=nameWithType> property.

  - Not specifying the `URI` attribute, that is, setting the <xref:System.Security.Cryptography.Xml.Reference.Uri?displayProperty=nameWithType> property to `null`, means that the receiving application is expected to know the identity of the object. In most cases, a `null` URI will result in an exception being thrown. Do not use a `null` URI, unless your application is interoperating with a protocol which requires it.

  - Setting the `URI` attribute to an empty string indicates that the root element of the document is being signed, a form of enveloped signature.

  - If the value of `URI` attribute starts with #, then the value must resolve to an element in the current document. This form can be used with any of the supported signature types (enveloped signature, enveloping signature or internal detached signature).

  - Anything else is considered an external resource detached signature and is not supported by the <xref:System.Security.Cryptography.Xml.SignedXml> class.

- The `<Transforms>` element

   Contains an ordered list of `<Transform>` elements that describe how the signer obtained the data object that was digested. A transform algorithm is similar to the canonicalization method, but instead of rewriting the `<Signature>` element, it rewrites the content identified by the `URI` attribute of the `<Reference>` element. The `<Transforms>` element is represented by the <xref:System.Security.Cryptography.Xml.TransformChain> class.

  - Each transform algorithm is defined as taking either XML (an XPath node-set) or bytes as input. If the format of the current data differs from the transform input requirements, conversion rules are applied.

  - Each transform algorithm is defined as producing either XML or bytes as the output.

  - If the output of the last transform algorithm is not defined in bytes (or no transforms were specified), then the [canonicalization method](https://www.w3.org/TR/2001/REC-xml-c14n-20010315) is used as an implicit transform (even if a different algorithm was specified in the `<CanonicalizationMethod>` element).

  - A value of <http://www.w3.org/2000/09/xmldsig#enveloped-signature> for the transform algorithm encodes a rule which is interpreted as remove the `<Signature>` element from the document. Otherwise, a verifier of an enveloped signature will digest the document, including the signature, but the signer would have digested the document before the signature was applied, leading to different answers.

- The `<DigestMethod>` element

   Identifies the digest (cryptographic hash) method to apply on the transformed content identified by the `URI` attribute of the `<Reference>` element. This is represented by the <xref:System.Security.Cryptography.Xml.Reference.DigestMethod?displayProperty=nameWithType> property.

## Choosing a canonicalization method

Unless interoperating with a specification which requires the use of a different value, we recommend that you use the default .NET canonicalization method, which is the XML-C14N 1.0 algorithm, whose value is <http://www.w3.org/TR/2001/REC-xml-c14n-20010315>. The XML-C14N 1.0 algorithm is required to be supported by all implementations of XMLDSIG, particularly as it is an implicit final transform to apply.

There are versions of canonicalization algorithms which support preserving comments. Comment-preserving canonicalization methods are not recommended because they violate the "sign what is seen" principle. That is, the comments in a `<Signature>` element will not alter the processing logic for how the signature is performed, merely what the signature value is. When combined with a weak signature algorithm, allowing the comments to be included gives an attacker unnecessary freedom to force a hash collision, making a tampered document appear legitimate. In .NET Framework, only built-in canonicalizers are supported by default. To support additional or custom canonicalizers, see the <xref:System.Security.Cryptography.Xml.SignedXml.SafeCanonicalizationMethods> property. If the document uses a canonicalization method that is not in the collection represented by the <xref:System.Security.Cryptography.Xml.SignedXml.SafeCanonicalizationMethods> property, then the <xref:System.Security.Cryptography.Xml.SignedXml.CheckSignature%2A> method will return `false`.

> [!NOTE]
> An extremely defensive application can remove any values it does not expect signers to use from the <xref:System.Security.Cryptography.Xml.SignedXml.SafeCanonicalizationMethods%2A> collection.

## Are the reference values safe from tampering?

Yes, the `<Reference>` values are safe from tampering. .NET verifies the `<SignatureValue>` computation before processing any of the `<Reference>` values and their associated transforms, and will abort early to avoid potentially malicious processing instructions.

## Choose the elements to sign

We recommend that you use the value of "" for the `URI` attribute (or set the <xref:System.Security.Cryptography.Xml.Reference.Uri> property to an empty string), if possible. This means the whole document is considered for the digest computation, which means the whole document is protected from tampering.

It is very common to see `URI` values in the form of anchors such as #foo, referring to an element whose ID attribute is "foo". Unfortunately, it is easy for this to be tampered with because this includes only the content of the target element, not the context. Abusing this distinction is known as XML Signature Wrapping (XSW).

If your application considers comments to be semantic (which is not common when dealing with XML), then you should use "#xpointer(/)" instead of "", and "#xpointer(id('foo'))" instead of "#foo". The #xpointer versions are interpreted as including comments, while the shortname forms are excluding comments.

If you need to accept documents which are only partially protected and you want to ensure that you are reading the same content that the signature protected, use the <xref:System.Security.Cryptography.Xml.SignedXml.GetIdElement%2A> method.

## Security considerations about the KeyInfo element

The data in the optional `<KeyInfo>` element (that is, the <xref:System.Security.Cryptography.Xml.SignedXml.KeyInfo> property), which contains a key to validate the signature,  should not be trusted.

In particular, when the <xref:System.Security.Cryptography.Xml.SignedXml.KeyInfo%2A> value represents a bare RSA, DSA or ECDSA public key,  the document could have been tampered with, despite the <xref:System.Security.Cryptography.Xml.SignedXml.CheckSignature%2A> method reporting that the signature is valid. This can happen because the entity doing the tampering just has to generate a new key and re-sign the tampered document with that new key. So, unless your application verifies that the public key is an expected value, the document should be treated as if it were tampered with. This requires that your application examine the public key embedded within the document and verify it against a list of known values for the document context. For example, if the document could be understood to be issued by a known user, you'd check the key against a list of known keys used by that user.

You can also verify the key after processing the document by using the <xref:System.Security.Cryptography.Xml.SignedXml.CheckSignatureReturningKey%2A> method, instead of using the <xref:System.Security.Cryptography.Xml.SignedXml.CheckSignature%2A> method. But, for the optimal security, you should verify the key beforehand.

Alternately, consider trying the user's registered public keys, rather than reading what's in the `<KeyInfo>` element.

## Security considerations about the X509Data element

The optional `<X509Data>` element is a child of the `<KeyInfo>` element and contains one or more X509 certificates or identifiers for X509 certificates. The data in the `<X509Data>` element should also not be inherently trusted.

When verifying a document with the embedded `<X509Data>` element, .NET verifies only that the data resolves to an X509 certificate whose public key can be successfully used to validate the document signature. Unlike calling the <xref:System.Security.Cryptography.Xml.SignedXml.CheckSignature%2A> method with the `verifySignatureOnly` parameter set to `false`, no revocation check is performed, no chain trust is checked, and no expiration is verified. Even if your application extracts the certificate itself and passes it to the <xref:System.Security.Cryptography.Xml.SignedXml.CheckSignature%2A> method with the `verifySignatureOnly` parameter set to `false`, that is still not sufficient validation to prevent document tampering. The certificate still needs to be verified as being appropriate for the document being signed.

Using an embedded signing certificate can provide useful key rotation strategies, whether in the `<X509Data>` section or in the document content. When using this approach an application should extract the certificate manually and perform validation similar to:

- The certificate was issued directly or via a chain by a Certificate Authority (CA) whose public certificate is embedded in the application.

  Using the OS-provided trust list without additional checks, such as a known subject name, is not sufficient to prevent tampering in <xref:System.Security.Cryptography.Xml.SignedXml>.

- The certificate is verified to have not been expired at the time of document signing (or "now" for near real-time document processing).

- For long-lived certificates issued by a CA which supports revocation, verify the certificate was not revoked.

- The certificate subject is verified as being appropriate to the current document.

## Choosing the transform algorithm

If you are interoperating with a specification which has dictated specific values (such as XrML), then you need to follow the specification. If you have an enveloped signature (such as when signing the whole document), then you need to use <http://www.w3.org/2000/09/xmldsig#enveloped-signature> (represented by the <xref:System.Security.Cryptography.Xml.XmlDsigEnvelopedSignatureTransform> class). You can specify the implicit XML-C14N transform as well, but it's not necessary. For an enveloping or detached signature, no transforms are required. The implicit XML-C14N transform takes care of everything.

With the security updated introduced by the [Microsoft Security Bulletin MS16-035](/security-updates/securitybulletins/2016/ms16-035), .NET has restricted what transforms can be used in document verification by default, with untrusted transforms causing <xref:System.Security.Cryptography.Xml.SignedXml.CheckSignature%2A> to always return `false`. In particular, transforms which require additional input (specified as child elements in the XML) are no longer allowed due to their susceptibility of abuse by malicious users. The W3C advises avoiding the XPath and XSLT transforms, which are the two main transforms affected by these restrictions.

## The problem with external references

If an application does not verify that external references seem appropriate for the current context, they can be abused in ways that provide for many security vulnerabilities (including Denial of Service, Distributed Reflection Denial of Service, Information Disclosure, Signature Bypass, and Remote Code Execution). Even if an application were to validate the external reference URI, there would remain a problem of the resource being loaded twice: once when your application reads it, and once when <xref:System.Security.Cryptography.Xml.SignedXml> reads it. Since there's no guarantee that the application read and document verify steps have the same content, the signature does not provide trustworthiness.

Given the risks of external references, <xref:System.Security.Cryptography.Xml.SignedXml> will throw an exception when an external reference is encountered. For more information about this issue, see [KB article 3148821](https://support.microsoft.com/kb/3148821).
