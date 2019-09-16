---
title: "Strong Naming (Unmanaged API Reference)"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "strong naming [.NET Framework], using the unmanaged API"
  - "native API reference [.NET Framework], strong naming"
  - "unmanaged API reference [.NET Framework], strong naming"
ms.assetid: 428c68b6-a7b4-44be-b280-75905f46612c
author: "rpetrusha"
ms.author: "ronpet"
---
# Strong Naming (Unmanaged API Reference)
The strong naming API enables a client to administer strong name signing for assemblies.  
  
 Signing an assembly with a strong name adds a public key encryption to the file containing the assembly manifest. Strong name signing helps verify name uniqueness, prevents name spoofing, and provides callers with a unique identity when a reference is resolved. However, no level of trust is associated with a strong name.  
  
## In This Section  
  
> [!NOTE]
> All of these functions have been deprecated starting with the .NET Framework 4. For suggested alternatives, see the [ICLRStrongName](../hosting/iclrstrongname-interface.md) interface.  
  
 [GetHashFromAssemblyFile Function](gethashfromassemblyfile-function.md)  
 Gets a hash of the specified assembly file, using the specified hash algorithm. Deprecated starting with the .NET Framework 4.  
  
 [GetHashFromAssemblyFileW Function](gethashfromassemblyfilew-function.md)  
 Gets a hash of the assembly file specified as a Unicode string, using the specified hash algorithm. Deprecated starting with the .NET Framework 4.  
  
 [GetHashFromBlob Function](gethashfromblob-function.md)  
 Gets a hash of the assembly at the specified memory address, using the specified hash algorithm. Deprecated starting with the .NET Framework 4.  
  
 [GetHashFromFile Function](gethashfromfile-function.md)  
 Generates a hash over the contents of the specified file.  Deprecated starting with the .NET Framework 4.  
  
 [GetHashFromFileW Function](gethashfromfilew-function.md)  
 Generates a hash over the contents of the file specified by a Unicode string. Deprecated starting with the .NET Framework 4.  
  
 [GetHashFromHandle Function](gethashfromhandle-function.md)  
 Generates a hash over the contents of the file with the specified file handle, using the specified hash algorithm.  Deprecated starting with the .NET Framework 4.  
  
 [StrongNameCompareAssemblies Function](strongnamecompareassemblies-function.md)  
 Determines whether two assemblies differ only by their strong name signatures. Deprecated starting with the .NET Framework 4.  
  
 [StrongNameErrorInfo Function](strongnameerrorinfo-function.md)  
 Gets the last error code that was raised by one of the strong name functions.  
  
 [StrongNameFreeBuffer Function](strongnamefreebuffer-function.md)  
 Frees memory that was allocated with a previous call to a strong name function such as [StrongNameGetPublicKey](strongnamegetpublickey-function.md), [StrongNameTokenFromPublicKey](strongnametokenfrompublickey-function.md), or [StrongNameSignatureGeneration](strongnamesignaturegeneration-function.md).   Deprecated starting with the .NET Framework 4.  
  
 [StrongNameGetBlob Function](strongnamegetblob-function.md)  
 Fills the specified buffer with the binary representation of the executable file at the specified address. Deprecated starting with the .NET Framework 4.  
  
 [StrongNameGetBlobFromImage Function](strongnamegetblobfromimage-function.md)  
 Gets a binary representation of the assembly image at the specified memory address. Deprecated starting with the .NET Framework 4.  
  
 [StrongNameGetPublicKey Function](strongnamegetpublickey-function.md)  
 Gets the public key from a private/public key pair. Deprecated starting with the .NET Framework 4.  
  
 [StrongNameHashSize Function](strongnamehashsize-function.md)  
 Gets the buffer size required for a hash, using the specified hash algorithm.  Deprecated starting with the .NET Framework 4.  
  
 [StrongNameKeyDelete Function](strongnamekeydelete-function.md)  
 Deletes the specified key container. Deprecated starting with the .NET Framework 4.  
  
 [StrongNameKeyGen Function](strongnamekeygen-function.md)  
 Creates a new public/private key pair for strong name use.  Deprecated starting with the .NET Framework 4.  
  
 [StrongNameKeyGenEx Function](strongnamekeygenex-function.md)  
 Generates a new public/private key pair with the specified key size for strong name use. Deprecated starting with the .NET Framework 4.  
  
 [StrongNameKeyInstall Function](strongnamekeyinstall-function.md)  
 Imports a public/private key pair into a container.  Deprecated starting with the .NET Framework 4.  
  
 [StrongNameSignatureGeneration Function](strongnamesignaturegeneration-function.md)  
 Generates a strong name signature for the specified assembly.   Deprecated starting with the .NET Framework 4.  
  
 [StrongNameSignatureGenerationEx Function](strongnamesignaturegenerationex-function.md)  
 Generates a strong name signature for the specified assembly, based on the specified flags.    Deprecated starting with the .NET Framework 4.  
  
 [StrongNameSignatureSize Function](strongnamesignaturesize-function.md)  
 Returns the size of the strong name signature. Deprecated starting with the .NET Framework 4.  
  
 [StrongNameSignatureVerification Function](strongnamesignatureverification-function.md)  
 Gets a value indicating whether the assembly manifest at the supplied path contains a strong name signature, which is verified according to the specified flags. Deprecated starting with the .NET Framework 4.  
  
 [StrongNameSignatureVerificationEx Function](strongnamesignatureverificationex-function.md)  
 Gets a value indicating whether the assembly manifest at the supplied path contains a strong name signature.  Deprecated starting with the .NET Framework 4.  
  
 [StrongNameSignatureVerificationFromImage Function](strongnamesignatureverificationfromimage-function.md)  
 Verifies that an assembly that has already been mapped to memory is valid for the associated public key. Deprecated starting with the .NET Framework 4.  
  
 [StrongNameTokenFromAssembly Function](strongnametokenfromassembly-function.md)  
 Creates a strong name token from the specified assembly file.  Deprecated starting with the .NET Framework 4.  
  
 [StrongNameTokenFromAssemblyEx Function](strongnametokenfromassemblyex-function.md)  
 Creates a strong name token from the specified assembly file, and returns the public key. Deprecated starting with the .NET Framework 4.  
  
 [StrongNameTokenFromPublicKey Function](strongnametokenfrompublickey-function.md)  
 Gets a token representing a public key. Deprecated starting with the .NET Framework 4.  
  
 [PublicKeyBlob Structure](publickeyblob-structure.md)  
 Represents the public key of a public/private key pair in binary format.  
  
## See also

- [ICLRStrongName Interface](../hosting/iclrstrongname-interface.md)
- [Unmanaged API Reference](../index.md)
