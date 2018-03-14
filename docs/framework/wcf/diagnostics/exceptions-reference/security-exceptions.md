---
title: "Security Exceptions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 76d5e5cd-e4f4-404f-9a5a-ec3522494ad8
caps.latest.revision: 6
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Security Exceptions
This topic lists all security exceptions.  
  
## Exception List  
  
|Resource Code|Resource String|  
|-------------------|---------------------|  
|AnonymousLogonsAreNotAllowed|The service does not allow you to log on anonymously.|  
|AtLeastOneContractOperationRequestRequiresProtectionLevelNotSupportedByBinding|The request message must be protected. This is required by an operation of the specified contract. The protection must be provided by the specified binding.|  
|AtLeastOneContractOperationResponseRequiresProtectionLevelNotSupportedByBinding|The response message must be protected. This is required by an operation of the specified contract. The protection must be provided by the specified binding.|  
|AtMostOnePrimarySignatureInReceiveSecurityHeader|Only one primary signature is allowed in a security header.|  
|BadContextTokenFaultReason|The security context token expired or is not valid. The message was not processed.|  
|BadEncryptionState|The EncryptedData or EncryptedKey is in an invalid state for this operation.|  
|BasicHttpMessageSecurityRequiresCertificate|BasicHttp binding requires that BasicHttpBinding.Security.Message.ClientCredentialType be equivalent to the BasicHttpMessageCredentialType.Certificate credential type for secure messages. Select Transport or TransportWithMessageCredential security for UserName credentials.|  
|BasicTokenCannotBeWrittenWithoutEncryption|The basic token cannot be written without encryption.|  
|BindingDoesNotSupportProtectionForRst|The specified binding for the specified contract is configured with SecureConversation, but the authentication mode is not able to provide the request/reply-based integrity and confidentiality required for the negotiation.|  
|BindingDoesNotSupportWindowsIdenityForImpersonation|The specified contract operation requires Windows identity for automatic impersonation. A Windows identity that represents the caller is not provided by the specified binding for the specified contract.|  
|CachedNegotiationStateQuotaReached|The service cannot cache the negotiation state as the specified capacity has been reached. Retry the request.|  
|CacheQuotaReached|The item cannot be added. The maximum cache size is specified.|  
|CannotDetermineSPNBasedOnAddress|Client cannot determine the Service Principal Name based on the identity in the specified target address for the purpose of SspiNegotiation/Kerberos. The target address identity must be a UPN identity (like acmedomain\\\alice) or SPN identity (like host/bobs-machine).|  
|CannotFindCert|Cannot find the X.509 certificate using the specified search criteria: StoreName, StoreLocation, FindType, FindValue.|  
|CannotFindCertForTarget|Cannot find The X.509 certificate using the specified search criteria: StoreName, StoreLocation, FindType, FindValue for the specified target.|  
|CannotFindCorrelationStateForApplyingSecurity|Cannot find the correlation state for applying security to reply at the responder.|  
|CannotFindNegotiationState|Cannot find the negotiation state for the specified context.|  
|CannotFindSecuritySession|Cannot find the security session with the specified ID.|  
|CannotImportProtectionLevelForContract|The policy to import a process cannot import a binding for the specified contract. The protection requirements for the binding are not compatible with a binding already imported for the contract. You must reconfigure the binding.|  
|CannotImportSupportingTokensForOperationWithoutRequestAction|Security policy import failed. The security policy contains supporting token requirements at the operation scope. The contract description does not specify the action for the request message associated with this operation.|  
|CannotIssueRstTokenType|Cannot issue the token or specified type.|  
|CannotObtainIssuedTokenKeySize|Cannot determine the key size of the issued token.|  
|CannotPerformImpersonationOnUsernameToken|Impersonation using the client token is not possible. The specified binding for the specified contract uses the Username Security Token for client authentication with a Membership Provider registered. Use a different type of security token for the client.|  
|CannotPerformS4UImpersonationOnPlatform|The specified binding for the specified contract supports impersonation only on [!INCLUDE[ws2003](../../../../../includes/ws2003-md.md)] and newer version of Windows. Use SspiNegotiated authentication and a binding with Secure Conversation with cancellation enabled.|  
|CannotReadKeyIdentifier|Cannot read the KeyIdentifier from the specified element with the specified namespace.|  
|CannotReadToken|Cannot read the token from the specified element with the specified namespace for BinarySecretSecurityToken, with a specified ValueType. If this element is expected to be valid, ensure that security is configured to consume tokens with the name, namespace and value type specified.|  
|CertificateUnsupportedForHttpTransportCredentialOnly|Certificate-based client authentication is not supported in TransportCredentialOnly security mode. Select the Transport security mode.|  
|ClaimTypeCannotBeEmpty|The claimType cannot be an empty string.|  
|ClientCertificateNotProvided|The certificate for the client has not been provided. The certificate can be set on the ClientCredentials or ServiceCredentials.|  
|ClientCredentialTypeMustBeSpecifiedForMixedMode|ClientCredentialType.None is not valid for the TransportWithMessageCredential security mode. Specify a credential type or use a different security mode.|  
|ConfigurationSchemaInsuffientForSecurityBindingElementInstance|The configuration schema is insufficient to describe the non-standard configuration of the following security binding element:|  
|DerivedKeyTokenGenerationAndLengthTooHigh|The derived key's specified generation and length result in a key derivation offset that is greater than the maximum offset allowed.|  
|DnsIdentityCheckFailedForIncomingMessage|The identity check failed for the incoming message. The expected domain name system (DNS) identity of the remote endpoint was specified. The remote endpoint provided the specified domain name system (DNS) claim. If this is a legitimate remote endpoint, you can fix the problem by specifying domain name system identity as the identity property of EndpointAddress when creating channel proxy.|  
|DnsIdentityCheckFailedForOutgoingMessage|The identity check failed for the message that was going out. The remote endpoint should have had the specified domain name system identity. The remote endpoint provided the domain name system (DNS) claim. If this is a legitimate remote endpoint, you can fix the problem by explicitly specifying DNS identity as the Identity property of EndpointAddress when creating channel proxy.|  
|DuplicateIdInMessageToBeVerified|The specified id occurred twice in the message that is supplied for verification.|  
|EmptyBase64Attribute|An empty value was found for the required base-64 attribute name and namespace.|  
|ExportOfBindingWithAsymmetricAndTransportSecurityNotSupported|Security policy export failed. The binding contains both an AsymmetricSecurityBindingElement and a secure transport binding element. Policy export for such a binding is not supported.|  
|ExportOfBindingWithSymmetricAndTransportSecurityNotSupported|Security policy export failed. The binding contains both a SymmetricSecurityBindingElement and a secure transport binding element. Policy export for such a binding is not supported.|  
|ExportOfBindingWithTransportSecurityBindingElementAndNoTransportSecurityNotSupported|Security policy export failed. The binding contains a TransportSecurityBindingElement but no transport binding element that implements ITransportTokenAssertionProvider. Policy export for such a binding is not supported. Make sure the transport binding element in the binding implements the ITransportTokenAssertionProvider interface.|  
|FoundMultipleCerts|Found multiple X.509 certificates using the specified search criteria: StoreName, StoreLocation, FindType, FindValue. Provide a more specific find value.|  
|FoundMultipleCertsForTarget|Found multiple X.509 certificates using the specified search criteria: StoreName, StoreLocation, FindType, FindValue for the specified target. Provide a more specific find value.|  
|HeaderDecryptionNotSupportedInWsSecurityJan2004|SecurityVersion.WSSecurityJan2004 does not support header decryption. Use SecurityVersion.WsSecurityXXX2005 and above or use transport security to encrypt the full message.|  
|IdentityCheckFailedForIncomingMessage|The identity check failed for the incoming message. The expected identity is specified for the target endpoint.|  
|IdentityCheckFailedForOutgoingMessage|The identity check failed for the outgoing message. The expected identity is specified for the target endpoint.|  
|IncorrectSpnOrUpnSpecified|Security Support Provider Interface (SSPI) authentication failed. The server may not be running in an account with the specified identity. If the server is running in a service account (Network Service for example), specify the account's ServicePrincipalName as the identity in the EndpointAddress for the server. If the server is running in a user account, specify the account's UserPrincipalName as the identity in the EndpointAddress for the server.|  
|InvalidAttributeInSignedHeader|The specified signed header contains the specified attribute. The expected attribute is specified.|  
|InvalidCloseResponseAction|A security session close response was received with the specified invalid action.|  
|InvalidQName|The QName is invalid.|  
|InvalidRenewResponseAction|A security session renew response was received with the specified invalid action.|  
|InvalidSspiNegotiation|The Security Support Provider Interface negotiation failed.|  
|IssuerBindingNotPresentInTokenRequirement|The security token manager requires the bootstrap security binding element to be specified in the token requirement that describes secure conversation. The token requirement is specified as follows.|  
|KeyLengthMustBeMultipleOfEight|The specified key length is not a multiple of 8 for symmetric keys.|  
|LsaAuthorityNotContacted|Internal SSL error (refer to Win32 status code for details). Check the server certificate to determine if it is capable of key exchange.|  
|MaximumPolicyRedirectionsExceeded|The recursive policy fetching limit has been reached. Check to determine if there is a loop in the federation service chain.|  
|MessagePartSpecificationMustBeImmutable|Message part specification must be made constant before being set.|  
|MissingCustomCertificateValidator|X509CertificateValidationMode.Custom requires CustomCertificateValidator. Specify the CustomCertificateValidator property.|  
|MissingCustomUserNamePasswordValidator|UserNamePasswordValidationMode.Custom requires CustomUserNamePasswordValidator. Specify the CustomUserNamePasswordValidator property.|  
|MissingMembershipProvider|UserNamePasswordValidationMode.MembershipProvider requires MembershipProvider. Specify the MembershipProvider property.|  
|NoBinaryNegoToSend|No binary negotiation was sent to the other party.|  
|NoEncryptionPartsSpecified|No encryption message parts were specified for messages with the specified  action.|  
|NoKeyInfoInEncryptedItemToFindDecryptingToken|The KeyInfo value was not found in the encrypted item to find the decrypting token.|  
|NonceLengthTooShort|The specified nonce is too short. The minimum required nonce length is 4 bytes.|  
|NoOutgoingEndpointAddressAvailableForDoingIdentityCheck|No outgoing EndpointAddress is available to check the identity on a message to be sent.|  
|NoOutgoingEndpointAddressAvailableForDoingIdentityCheckOnReply|No outgoing EndpointAddress is available to check the identity on a received reply.|  
|NoPartsOfMessageMatchedPartsToSign|No signature was created because no part of the message matched the supplied message part specification.|  
|NoPrincipalSpecifiedInAuthorizationContext|No custom principal is specified in the authorization context.|  
|NoSignatureAvailableInSecurityHeaderToDoReplayDetection|No signature is available in the security header to provide the nonce for replay detection.|  
|NoSignaturePartsSpecified|No signature message parts were specified for messages with the specified  action.|  
|NoSigningTokenAvailableToDoIncomingIdentityCheck|No signing token is available to do an incoming identity check.|  
|NoTimestampAvailableInSecurityHeaderToDoReplayDetection|No timestamp is available in the security header to do replay detection.|  
|NoTransportTokenAssertionProvided|The security policy expert failed. The provided transport token assertion of the specified type did not create a transport token assertion to include the sp:TransportBinding security policy assertion.|  
|OnlyOneOfEncryptedKeyOrSymmetricBindingCanBeSelected|The symmetric security protocol can either be configured with a symmetric token provider and a symmetric token authenticator or an asymmetric token provider. It cannot be configured with both.|  
|OperationCannotBeDoneOnReceiverSideSecurityHeaders|This operation cannot be done on the receiver security headers.|  
|OperationDoesNotAllowImpersonation|The specified service operation that belongs to the contract with the specified name and the namespace does not allow impersonation.|  
|PolicyRequiresConfidentialityWithoutIntegrity|Message security policy for the specified action requires confidentiality without integrity. Confidentiality without integrity is not supported.|  
|PrimarySignatureIsRequiredToBeEncrypted|The primary signature must be encrypted.|  
|PropertySettingErrorOnProtocolFactory|The required property on the specified  security protocol factory is not set or has an invalid value.|  
|ProtocolFactoryCouldNotCreateProtocol|The protocol factory cannot create a protocol.|  
|PublicKeyNotRSA|The public key is not an RSA key.|  
|RequiredMessagePartNotEncrypted|The specified required message part was not encrypted.|  
|RequiredMessagePartNotEncryptedNs|The specified required message part was not encrypted.|  
|RequiredMessagePartNotSigned|The specified required message part was not signed.|  
|RequiredMessagePartNotSignedNs|The specified required message part was not signed.|  
|RequiredSecurityHeaderElementNotSigned|The specified security header element with the specified id must be signed.|  
|RequiredSecurityTokenNotEncrypted|The specified ' security token with the specified attachment mode must be encrypted.|  
|RequiredSecurityTokenNotSigned|The specified security token with the specified attachment mode must be signed.|  
|RequiredSignatureMissing|The signature must be in the security header.|  
|RequireNonCookieMode|The specified binding with the specified namespace is configured to issue cookie security context tokens. COM+ Integration services does not support cookie security context tokens.|  
|RevertingPrivilegeFailed|The reverting operation failed with the specified exception.|  
|RSTRAuthenticatorIncorrect|The RequestSecurityTokenResponse CombinedHash is incorrect.|  
|SecureConversationCancelNotAllowedFaultReason|A secure conversation cancellation is not allowed by the binding.|  
|SecureConversationDriverVersionDoesNotSupportSession|The configured SecureConversation version does not support sessions. Use WSSecureConversationFeb2005 or above.|  
|SecureConversationRequiredByReliableSession|Cannot establish a reliable session without secure conversation. Enable secure conversation.|  
|SecurityAuditFailToLoadDll|The specified dynamic link library (dll) failed to load.|  
|SecurityAuditNotSupportedOnChannelFactory|SecurityAuditBehavior is not supported on the channel factory.|  
|SecurityAuditPlatformNotSupported|Writing audit messages to the Security log is not supported by the current platform. You must write audit messages to the Application log.|  
|SecurityBindingElementCannotBeExpressedInConfig|A security policy was imported for the endpoint. The security policy contains requirements that cannot be represented in a Windows Communication Foundation configuration. Look for a comment about the SecurityBindingElement parameters that are required in the configuration file that was generated. Create the correct binding element with code. The binding configuration that is in the configuration file is not secure.|  
|SecurityBindingSupportsOneWayOnly|The SecurityBinding for the specified binding for the specified contract only supports the OneWay operation.|  
|SecurityContextDoesNotAllowImpersonation|Cannot start impersonation because the SecurityContext for the UltimateReceiver role from the request message with the specified action is not mapped to a Windows identity.|  
|SecurityListenerClosing|The listener is not accepting new secure conversations because it is closing.|  
|SecurityListenerClosingFaultReason|The server is not accepting new secure conversations currently because it is closing. Please retry later.|  
|SecurityProtocolFactoryShouldBeSetBeforeThisOperation|The security protocol factory must be set before this operation is performed.|  
|SecuritySessionAbortedFaultReason|The security session was terminated. This may be because no messages were received on the session for too long.|  
|SecuritySessionKeyIsStale|The session key must be renewed before it can secure application messages.|  
|SecuritySessionLimitReached|Cannot create a security session. Retry later.|  
|SecuritySessionNotPending|No security session with the specified id is pending.|  
|SecurityTokenParametersHasIncompatibleInclusionMode|The specified binding is configured with a security token parameter that has the specified incompatible security token inclusion mode. Specify an alternate security token inclusion mode.|  
|SecurityVersionDoesNotSupportEncryptedKeyBinding|The specified binding for the specified contract has been configured with an incompatible security version that does not support unattached references to EncryptedKeys. Use the specified value or higher as the security version for the binding.|  
|SecurityVersionDoesNotSupportSignatureConfirmation|The specified SecurityVersion does not support signature confirmation. Use a later SecurityVersion.|  
|SecurityVersionDoesNotSupportThumbprintX509KeyIdentifierClause|The specified binding for the specified  contract is configured with a security version that does not support external references to X.509 tokens using the certificate's thumbprint value. Use the specified value or higher as the security version for the binding.|  
|SenderSideSupportingTokensMustSpecifySecurityTokenParameters|Security token parameters must be specified with supporting tokens for each message.|  
|ServerCertificateNotProvided|The recipient did not provide its certificate. This certificate is required by the TLS protocol. Both parties must have access to their certificates.|  
|SignatureConfirmationNotSupported|The configured SecurityVersion does not support signature confirmation. Use WSSecurityXXX2005 or above.|  
|SignatureConfirmationRequiresRequestReply|The protocol factory must support Request/Reply security in order to offer signature confirmation.|  
|SignatureNotExpected|A signature is not expected for this message.|  
|SigningTokenHasNoKeys|The specified signing token has no keys. The security token is used in a context that requires it to perform cryptographic operations, but the token contains no cryptographic keys. Either the token type does not support cryptographic operations, or the particular token instance does not contain cryptographic keys. Check your configuration to ensure that cryptographically disabled token types (for example, UserNameSecurityToken) are not specified in a context that requires cryptographic operations (for example, an endorsing supporting token).|  
|SpnegoImpersonationLevelCannotBeSetToNone|The Security Support Provider Interface does not support Impersonation level 'None'. Specify Identification, Impersonation or Delegation level.|  
|SslClientCertMustHavePrivateKey|The specified certificate must have a private key. The process must have access rights for the private key.|  
|SslServerCertMustDoKeyExchange|The specified certificate must have a private key that is capable of key exchange. The process must have access rights for the private key.|  
|StandardsManagerCannotWriteObject|The token Serializer cannot serialize the specified object.  If this is a custom type you must supply a custom serializer.|  
|TimeStampHasCreationAheadOfExpiry|The security timestamp is invalid because its creation time is greater than or equal to its expiration time.|  
|TimeStampHasCreationTimeInFuture|The security timestamp is invalid because its creation time is in the future. Current time is specified and allowed clock skew is specified.|  
|TimeStampHasExpiryTimeInPast|The security timestamp is stale because its expiration time is in the past. Current time is specified and allowed clock skew is specified.|  
|TimeStampWasCreatedTooLongAgo|The security timestamp is stale because its creation time is too far back in the past. Current time, maximum timestamp lifetime, and allowed clock skew are specified.|  
|TokenProviderCannotGetTokensForTarget|The token provider cannot get tokens for the specified target.|  
|TooManyIssuedSecurityTokenParameters|A leg of the federated security chain contains multiple IssuedSecurityTokenParameters. The InfoCard system only supports one IssuedSecurityTokenParameters for each leg.|  
|TransportDoesNotProtectMessage|The specified binding for the specified  contract is configured with an authentication mode that requires transport level integrity and confidentiality. However the transport cannot provide integrity and confidentiality.|  
|TrustApr2004DoesNotSupportCertainIssuedTokens|WSTrustApr2004 does not support issuing X.509 certificates or EncryptedKeys. Use WsTrustFeb2005 or above.|  
|TrustDriverVersionDoesNotSupportSession|The configured Trust version does not support sessions. Use WSTrustFeb2005 or above.|  
|UnableToCreateICryptoFromTokenForSignatureVerification|Cannot create an ICrypto interface from the specified token for signature verification.|  
|UnableToCreateSymmetricAlgorithmFromToken|Cannot create the specified symmetric algorithm from the token.|  
|UnableToDeriveKeyFromKeyInfoClause|The specified KeyInfo clause resolved to the specified token, which does not contain a symmetric key that can be used for derivation.|  
|UnableToFindTokenAuthenticator|Cannot find a token authenticator for the specified token type. Tokens of that type cannot be accepted according to current security settings.|  
|UnableToLoadCertificateIdentity|Cannot load the X.509 certificate identity specified in the configuration.|  
|UnexpectedEmptyElementExpectingClaim|The specified element from the specified  namespace is empty and does not specify a valid identity claim.|  
|UnknownEncodingInBinarySecurityToken|Unrecognized encoding occurred while reading the binary security token.|  
|UnsecuredMessageFaultReceived|An unsecured or incorrectly secured fault was received from the other party. See the inner FaultException for the fault code and detail.|  
|UnsupportedPasswordType|The specified username token has an unsupported password type.|  
|UnsupportedSecureConversationBootstrapProtectionRequirements|Cannot import the security policy. The protection requirements for the secure conversation bootstrap binding are not supported. Protection requirements for the secure conversation bootstrap must require both the request and the response to be signed and encrypted.|  
|UnsupportedSecurityPolicyAssertion|An unsupported security policy assertion was detected during the specified security policy import.|
