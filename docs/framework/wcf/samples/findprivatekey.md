---
title: "FindPrivateKey sample - WCF"
ms.date: "12/04/2017"
ms.prod: ".net-framework"
ms.technology: "dotnet-clr"
ms.topic: "article"
helpviewer_keywords: 
  - "FindPrivateKey"
ms.assetid: 16b54116-0ceb-4413-af0c-753bb2a785a6
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# FindPrivateKey sample

It can be difficult to find the location and name of the private key file associated with a specific X.509 certificate in the certificate store. The FindPrivateKey.exe tool facilitates this process.

> [!IMPORTANT]
> FindPrivateKey is a sample that needs to be compiled prior to use. See the [To build the FindPrivateKey project](#to-build-the-findprivatekey-project) section for instructions on how to build the FindPrivateKey tool.

X.509 certificates are installed by an Administrator or any user in the machine. However, the certificate may be accessed by a service running under a different account. For example, the NETWORK SERVICE account.

This account may not have access to the private key file because the certificate was not installed by it originally. The FindPrivateKey tool gives you the location of a given X.509 Certificate's private key file. You can add permissions or remove permissions to this file once you know the location of the particular X.509 certificates' private key file.

The samples that use certificates for security use the FindPrivateKey tool in the *Setup.bat* file. Once the private key file has been found, you can use other tools such as *Cacls.exe* to set the appropriate access rights onto the file.

When running a Windows Communication Foundation (WCF) service under a user account, such as a self-hosted executable, ensure that the user account has read-only access to the file. When running a WCF service under Internet Information Services (IIS) the default accounts that the service runs under are the NETWORK SERVICE on IIS 7 and earlier versions, or Application Pool Identity on IIS 7.5 and later versions. For more information, see [Application Pool Identities](/iis/manage/configuring-security/application-pool-identities).

## Examples

When accessing a certificate for which the process doesn't have read privilege, you see an exception message similar to the following example:

```
System.ArgumentException was unhandled
Message="The certificate 'CN=localhost' must have a private key that is capable of key exchange.  The process must have access rights for the private key."
Source="System.ServiceModel"
```

When this occurs, use the FindPrivateKey tool to find the private key file, and then set the access right for the process that the service is running under. For example, this can be done with the Cacls.exe tool as shown in the following example:

```
cacls.exe "C:\Documents and Settings\All Users\Application Data\Microsoft\Crypto\RSA\MachineKeys\8aeda5eb81555f14f8f9960745b5a40d_38f7de48-5ee9-452d-8a5a-92789d7110b1" /E /G "NETWORK SERVICE":R
```

#### To build the FindPrivateKey project

To download the project, visit [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](https://www.microsoft.com/download/details.aspx?id=21459).

1. Open [!INCLUDE[fileExplorer](../../../../includes/fileexplorer-md.md)] and navigate to the *WF_WCF_Samples\WCF\Setup\FindPrivateKey\CS* folder under the directory location where you installed the sample.

2. Double-click the .sln file icon to open the file in Visual Studio.

3. In the **Build** menu, select **Rebuild Solution**.

4. Building the solution generates the file: FindPrivateKey.exe.

## Conventions—Command-Line entries

 "[*option*]" represents an optional set of parameters.

 "{*option*}" represents a mandatory set of parameters.

 "*option1* &#124; *option2*" represents a choice between sets of options.

 "\<*value*>" represents a parameter value to be entered.

## Usage

```
FindPrivateKey <storeName> <storeLocation> [{ {-n <subjectName>} | {-t <thumbprint>} } [-f | -d | -a]]
```

Where:

```
       <subjectName> The subject name of the certificate
       <thumbprint>  The thumbprint of the certificate (You can use the Certmgr.exe tool to find this)
       -f            output file name only
       -d            output directory only
       -a            output absolute file name
```

If no parameters are specified at the command prompt, then this help text is displayed.

## Examples

This example finds the filename of the certificate with a subject name of "CN=localhost", in the Personal store of the Current User.

```
FindPrivateKey My CurrentUser -n "CN=localhost"
```

This example finds the filename of the certificate with a subject name of "CN=localhost", in the Personal store of the Current User and output the full directory path.

```
FindPrivateKey My CurrentUser -n "CN=localhost" -a
```

This example finds the filename of the certificate with a thumbprint of "03 33 98 63 d0 47 e7 48 71 33 62 64 76 5c 4c 9d 42 1d 6b 52", in the Personal store of the Local Computer.

```
FindPrivateKey My LocalMachine -t "03 33 98 63 d0 47 e7 48 71 33 62 64 76 5c 4c 9d 42 1d 6b 52"
```
