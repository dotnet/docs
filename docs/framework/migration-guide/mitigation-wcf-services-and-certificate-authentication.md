---
title: "Mitigation: WCF Services and Certificate Authentication"
description: Learn how to mitigate certificate authentication issues from the changes to the WCF SSL protocol default list in .NET Framework 4.6.
ms.date: "03/30/2017"
ms.assetid: ef19c91a-b9df-4bf0-a28e-eb1e99c4bc95
---
# Mitigation: WCF Services and Certificate Authentication

The .NET Framework 4.6 adds TLS 1.1 and TLS 1.2 to the WCF SSL protocol default list. When both client and server machines have  the .NET Framework 4.6 or later installed, TLS 1.2 is used for negotiation.

## Impact

TLS 1.2 does not support MD5 certificate authentication. As a result, if a customer uses an SSL certificate which uses MD5 for the hash algorithm, the WCF client fails to connect to the WCF service. For more information, see [Mitigation: WCF Services and Certificate Authentication](mitigation-wcf-services-and-certificate-authentication.md).

## Mitigation

You can work around this issue so that a WCF client can connect to a WCF server by doing any of the following:

- Update the certificate to not use the MD5 algorithm. This is the recommended solution.

- If the binding is not dynamically configured in source code, update the application's configuration file to use TLS 1.1 or an earlier version of the protocol. This allows you to continue to use a certificate with the MD5 hash algorithm.

  > [!CAUTION]
  > This workaround is not recommended, since a certificate with the MD5 hash algorithm is considered insecure.

  The following configuration file does this:

  ```xml
  <configuration>
      <system.serviceModel>
          <bindings>
              <netTcpBinding>
                  <binding>
                      <security mode= "None|Transport|Message|TransportWithMessageCredential" >
                          <transport clientCredentialType="None|Windows|Certificate"
                                              protectionLevel="None|Sign|EncryptAndSign"
                                              sslProtocols="Ssl3|Tls1|Tls11">
                          </transport>
                      </security>
                  </binding>
              </netTcpBinding>
          </bindings>
      </system.serviceModel>
  </configuration>
  ```

- If the binding is dynamically configured in source code, update the <xref:System.ServiceModel.TcpTransportSecurity.SslProtocols%2A?displayProperty=nameWithType> property to use TLS 1.1 (<xref:System.Security.Authentication.SslProtocols.Tls11?displayProperty=nameWithType>) or an  earlier version of the protocol in the source code.

  > [!CAUTION]
  > This workaround is not recommended, since a certificate with the MD5 hash algorithm is considered insecure.

## See also

- [Application compatibility](application-compatibility.md)
