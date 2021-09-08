---
title: "How to: Create Temporary Certificates for Use During Development"
description: Learn how to use a PowerShell cmdlet to create two temporary X.509 certificates for use in developing a secure WCF service or client.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "certificates [WCF], creating temporary certificates"
  - "temporary certificates [WCF]"
ms.assetid: bc5f6637-5513-4d27-99bb-51aad7741e4a
---
# How to: Create Temporary Certificates for Use During Development

When developing a secure service or client using Windows Communication Foundation (WCF), it is often necessary to supply an X.509 certificate to be used as a credential. The certificate typically is part of a chain of certificates with a root authority found in the Trusted Root Certification Authorities store of the computer. Having a certificate chain enables you to scope a set of certificates where typically the root authority is from your organization or business unit. To emulate this at development time, you can create two certificates to satisfy the security requirements. The first is a self-signed certificate that is placed in the Trusted Root Certification Authorities store, and the second certificate is created from the first and is placed in either the Personal store of the Local Machine location, or the Personal store of the Current User location. This topic walks through the steps to create these two certificates using the PowerShell [New-SelfSignedCertificate)](/powershell/module/pki/new-selfsignedcertificate) cmdlet.

> [!IMPORTANT]
> The certificates that the New-SelfSignedCertificate cmdlet generates are provided for testing purposes only. When deploying a service or client, be sure to use an appropriate certificate provided by a certification authority. This could either be from a Windows Server certificate server in your organization or a third party.
>
> By default, the [New-SelfSignedCertificate](/powershell/module/pki/new-selfsignedcertificate) cmdlet creates certificates that are self-signed and these certificates are insecure. Placing the self-signed certificates in the Trusted Root Certification Authorities store enables you to create a development environment that more closely simulates your deployment environment.

 For more information about creating and using certificates, see [Working with Certificates](working-with-certificates.md). For more information about using a certificate as a credential, see [Securing Services and Clients](securing-services-and-clients.md). For a tutorial about using Microsoft Authenticode technology, see [Authenticode Overviews and Tutorials](/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms537360(v=vs.85)).

## To create a self-signed root authority certificate and export the private key

The following command creates a self-signed certificate with a subject name of "RootCA" in the Current User Personal store.

```powershell
$rootCert = New-SelfSignedCertificate -CertStoreLocation Cert:\CurrentUser\My -DnsName "RootCA" -TextExtension @("2.5.29.19={text}CA=true") -KeyUsage CertSign,CrlSign,DigitalSignature
```

We need to export the certificate to a PFX file so that it can be imported to where it's needed in a later step. When exporting a certificate with the private key, a password is needed to protect it. We save the password in a `SecureString` and use the [Export-PfxCertificate](/powershell/module/pki/export-pfxcertificate) cmdlet to export the certificate with the associated private key to a PFX file. We also save just the public certificate into a CRT file using the [Export-Certificate](/powershell/module/pki/export-certificate) cmdlet.

```powershell
[System.Security.SecureString]$rootCertPassword = ConvertTo-SecureString -String "password" -Force -AsPlainText
[String]$rootCertPath = Join-Path -Path 'cert:\CurrentUser\My\' -ChildPath "$($rootCert.Thumbprint)"
Export-PfxCertificate -Cert $rootCertPath -FilePath 'RootCA.pfx' -Password $rootCertPassword
Export-Certificate -Cert $rootCertPath -FilePath 'RootCA.crt'
```

## To create a new certificate signed by a root authority certificate

The following command creates a certificate signed by the `RootCA` with a subject name of "SignedByRootCA" using the private key of the issuer.

```powershell
$testCert = New-SelfSignedCertificate -CertStoreLocation Cert:\LocalMachine\My -DnsName "SignedByRootCA" -KeyExportPolicy Exportable -KeyLength 2048 -KeyUsage DigitalSignature,KeyEncipherment -Signer $rootCert
```

Similarly, we save the signed certificate with private key into a PFX file and just the public key into a CRT file.

```powershell
[String]$testCertPath = Join-Path -Path 'cert:\LocalMachine\My\' -ChildPath "$($testCert.Thumbprint)"
Export-PfxCertificate -Cert $testCertPath -FilePath testcert.pfx -Password $rootCertPassword
Export-Certificate -Cert $testCertPath -FilePath testcert.crt
```

## Installing a Certificate in the Trusted Root Certification Authorities Store

Once a self-signed certificate is created, you can install it in the Trusted Root Certification Authorities store. Any certificates that are signed with the certificate at this point are trusted by the computer. For this reason, delete the certificate from the store as soon as you no longer need it. When you delete this root authority certificate, all other certificates that signed with it become unauthorized. Root authority certificates are simply a mechanism whereby a group of certificates can be scoped as necessary. For example, in peer-to-peer applications, there is typically no need for a root authority because you simply trust the identity of an individual by its supplied certificate.

### To install a self-signed certificate in the Trusted Root Certification Authorities

1. Open the certificate snap-in. For more information, see [How to: View Certificates with the MMC Snap-in](how-to-view-certificates-with-the-mmc-snap-in.md).

2. Open the folder to store the certificate, either the **Local Computer** or the **Current User**.

3. Open the **Trusted Root Certification Authorities** folder.

4. Right-click the **Certificates** folder and click **All Tasks**, then click **Import**.

5. Follow the on-screen wizard instructions to import the RootCA.pfx into the store.

## Using certificates With WCF

Once you have set up the temporary certificates, you can use them to develop WCF solutions that specify certificates as a client credential type. For example, the following XML configuration specifies message security and a certificate as the client credential type.

### To specify a certificate as the client credential type

1. In the configuration file for a service, use the following XML to set the security mode to message, and the client credential type to certificate.

    ```xml
    <bindings>
      <wsHttpBinding>
        <binding name="CertificateForClient">
          <security>
            <message clientCredentialType="Certificate" />
          </security>
        </binding>
      </wsHttpBinding>
    </bindings>
    ```

2. In the configuration file for a client, use the following XML to specify that the certificate is found in the user’s store, and can be found by searching the SubjectName field for the value "CohoWinery."

    ```xml
    <behaviors>
      <endpointBehaviors>
        <behavior name="CertForClient">
          <clientCredentials>
            <clientCertificate findValue="CohoWinery" x509FindType="FindBySubjectName" />
          </clientCredentials>
        </behavior>
      </endpointBehaviors>
    </behaviors>
    ```

For more information about using certificates in WCF, see [Working with Certificates](working-with-certificates.md).

## .NET Framework security

Be sure to delete any temporary root authority certificates from the **Trusted Root Certification Authorities** and **Personal** folders by right-clicking the certificate, then clicking **Delete**.

## See also

- [Working with Certificates](working-with-certificates.md)
- [How to: View Certificates with the MMC Snap-in](how-to-view-certificates-with-the-mmc-snap-in.md)
- [Securing Services and Clients](securing-services-and-clients.md)
