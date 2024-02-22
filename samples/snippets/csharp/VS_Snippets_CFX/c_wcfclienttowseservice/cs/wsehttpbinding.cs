
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.
// <snippet5>
using System;
using System.Text;
using System.Collections.Generic;
using System.Net.Security;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;

using System.ServiceModel.Security.Tokens;
using System.Xml;

namespace Microsoft.ServiceModel.Samples
{
    // <snippet1>
    public class WseHttpBinding : Binding
    {
    // </snippet1>
        public WseHttpBinding() { }
        // <snippet2>
        public override BindingElementCollection CreateBindingElements()
        {
            //SecurityBindingElement sbe = bec.Find<SecurityBindingElement>();
            BindingElementCollection bec = new BindingElementCollection();
            // By default http transport is used
            SecurityBindingElement securityBinding;
            BindingElement transport;

            switch (assertion)
            {
                case WseSecurityAssertion.UsernameOverTransport:
                    transport = new HttpsTransportBindingElement();
                    securityBinding = (TransportSecurityBindingElement)SecurityBindingElement.CreateUserNameOverTransportBindingElement();
                    if (establishSecurityContext == true)
                        throw new InvalidOperationException("Secure Conversation is not supported for this Security Assertion Type");
                    if (requireSignatureConfirmation == true)
                        throw new InvalidOperationException("Signature Confirmation is not supported for this Security Assertion Type");
                    break;
                case WseSecurityAssertion.MutualCertificate10:
                    transport = new HttpTransportBindingElement();
                    securityBinding = SecurityBindingElement.CreateMutualCertificateBindingElement(MessageSecurityVersion.WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10);
                    if (requireSignatureConfirmation == true)
                        throw new InvalidOperationException("Signature Confirmation is not supported for this Security Assertion Type");
                    ((AsymmetricSecurityBindingElement)securityBinding).MessageProtectionOrder = messageProtectionOrder;
                    break;
                case WseSecurityAssertion.UsernameForCertificate:
                    transport = new HttpTransportBindingElement();
                    securityBinding = (SymmetricSecurityBindingElement)SecurityBindingElement.CreateUserNameForCertificateBindingElement();
                    // We want signatureconfirmation on the bootstrap process
                    // either for the application messages or for the RST/RSTR
                    ((SymmetricSecurityBindingElement)securityBinding).RequireSignatureConfirmation = requireSignatureConfirmation;
                    ((SymmetricSecurityBindingElement)securityBinding).MessageProtectionOrder = messageProtectionOrder;
                    break;
                case WseSecurityAssertion.AnonymousForCertificate:
                    transport = new HttpTransportBindingElement();
                    securityBinding = (SymmetricSecurityBindingElement)SecurityBindingElement.CreateAnonymousForCertificateBindingElement();
                    ((SymmetricSecurityBindingElement)securityBinding).RequireSignatureConfirmation = requireSignatureConfirmation;
                    ((SymmetricSecurityBindingElement)securityBinding).MessageProtectionOrder = messageProtectionOrder;
                    break;
                case WseSecurityAssertion.MutualCertificate11:
                    transport = new HttpTransportBindingElement();
                    securityBinding = SecurityBindingElement.CreateMutualCertificateBindingElement(MessageSecurityVersion.WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11);
                    ((SymmetricSecurityBindingElement)securityBinding).RequireSignatureConfirmation = requireSignatureConfirmation;
                    ((SymmetricSecurityBindingElement)securityBinding).MessageProtectionOrder = messageProtectionOrder;
                    break;
                case WseSecurityAssertion.Kerberos:
                    transport = new HttpTransportBindingElement();
                    securityBinding = (SymmetricSecurityBindingElement)SecurityBindingElement.CreateKerberosBindingElement();
                    ((SymmetricSecurityBindingElement)securityBinding).RequireSignatureConfirmation = requireSignatureConfirmation;
                    ((SymmetricSecurityBindingElement)securityBinding).MessageProtectionOrder = messageProtectionOrder;
                    break;
                default:
                    throw new NotSupportedException("This supplied Wse security assertion is not supported");
            }
            //Set defaults for the security binding
            securityBinding.IncludeTimestamp = true;

            // Derived Keys
            // set the preference for derived keys before creating SecureConversationBindingElement
            securityBinding.SetKeyDerivation(requireDerivedKeys);

            //Secure Conversation
            if (establishSecurityContext == true)
            {
                SymmetricSecurityBindingElement secureconversation =
                        (SymmetricSecurityBindingElement)SymmetricSecurityBindingElement.CreateSecureConversationBindingElement(
                                                    securityBinding, false);
                // This is the default
                //secureconversation.DefaultProtectionLevel = ProtectionLevel.EncryptAndSign;

                //Set defaults for the secure conversation binding
                secureconversation.DefaultAlgorithmSuite = SecurityAlgorithmSuite.Basic256;
                // We do not want signature confirmation on the application level messages
                // when secure conversation is enabled.
                secureconversation.RequireSignatureConfirmation = false;
                secureconversation.MessageProtectionOrder = messageProtectionOrder;
                secureconversation.SetKeyDerivation(requireDerivedKeys);
                securityBinding = secureconversation;
            }

            // Add the security binding to the binding collection
            bec.Add(securityBinding);

            // Add the message encoder.
            TextMessageEncodingBindingElement textelement = new TextMessageEncodingBindingElement();
            textelement.MessageVersion = MessageVersion.Soap11WSAddressingAugust2004;
            //These are the defaults required for WSE
            //textelement.MessageVersion = MessageVersion.Soap11Addressing1;
            //textelement.WriteEncoding = System.Text.Encoding.UTF8;
            bec.Add(textelement);

            // Add the transport
            bec.Add(transport);

            // return the binding elements
            return bec;
        }
        // </snippet2>
        // Finds the named WSE 3.0 Policy and initialize the WseHttpBinding;
        public void LoadPolicy(String filename, String policyName)
        {
            bool readPolicy = false;

            XmlReader reader = XmlReader.Create(filename);
            reader.MoveToContent();

            if (!reader.ReadToDescendant("policy", "http://schemas.microsoft.com/wse/2005/06/policy"))
                throw new InvalidOperationException("The reader does not contain any Policy element. Check the policy file if it contains any policy.");

            do
            {
                if (reader["name"] == policyName)
                {
                    reader.Read();
                    reader.MoveToContent();

                    switch (reader.Name)
                    {
                        case "usernameForCertificateSecurity":
                            SecurityAssertion = WseSecurityAssertion.UsernameForCertificate;
                            PolicyProperties(reader.ReadSubtree());
                            break;
                        case "usernameOverTransportSecurity":
                            SecurityAssertion = WseSecurityAssertion.UsernameOverTransport;
                            PolicyProperties(reader.ReadSubtree());
                            break;
                        case "mutualCertificate10Security":
                            SecurityAssertion = WseSecurityAssertion.MutualCertificate10;
                            PolicyProperties(reader.ReadSubtree());
                            break;
                        case "mutualCertificate11Security":
                            SecurityAssertion = WseSecurityAssertion.MutualCertificate11;
                            PolicyProperties(reader.ReadSubtree());
                            break;
                        case "anonymousForCertificateSecurity":
                            SecurityAssertion = WseSecurityAssertion.AnonymousForCertificate;
                            PolicyProperties(reader.ReadSubtree());
                            break;
                        case "kerberosSecurity":
                            SecurityAssertion = WseSecurityAssertion.Kerberos;
                            PolicyProperties(reader.ReadSubtree());
                            break;
                        // not used.
                        case "authorization":
                        case "requireSoapHeader":
                        case "requireActionHeader":
                        default:
                            throw new NotSupportedException("The given policy contains unrecognized or unsupported security element.");
                    }
                    readPolicy = true;
                    break;
                }
            } while (reader.ReadToNextSibling("policy", "http://schemas.microsoft.com/wse/2005/06/policy"));

            if (!readPolicy)
                throw new InvalidOperationException("The given policy name is not present in the given reader.");
        }

        void PolicyProperties(XmlReader reader)
        {
            reader.Read();
            //Set the Security Assertion XML attributes onto the binding properties
            while (reader.MoveToNextAttribute())
            {
                if (reader.Name == "establishSecurityContext")
                    EstablishSecurityContext = reader.ReadContentAsBoolean();
                if (reader.Name == "requireSignatureConfirmation")
                    RequireSignatureConfirmation = reader.ReadContentAsBoolean();
                if (reader.Name == "requireDerivedKeys")
                    RequireDerivedKeys = reader.ReadContentAsBoolean();
                if (reader.Name == "messageProtectionOrder")
                {
                    String protectionOrder = reader.Value;
                    switch (protectionOrder)
                    {
                        case "SignBeforeEncrypt":
                            MessageProtectionOrder = MessageProtectionOrder.SignBeforeEncrypt;
                            break;
                        case "EncryptBeforeSign":
                            MessageProtectionOrder = MessageProtectionOrder.EncryptBeforeSign;
                            break;
                        case "SignBeforeEncryptAndEncryptSignature":
                            MessageProtectionOrder = MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature;
                            break;
                    }
                }
            }
        }

        public override string Scheme
        {
            get { return "http"; }
        }
        // <snippet3>

        private WseSecurityAssertion assertion;
        public WseSecurityAssertion SecurityAssertion
        {
            get { return assertion; }
            set { assertion = value; }
        }

        private bool requireDerivedKeys;
        public bool RequireDerivedKeys
        {
            get { return requireDerivedKeys; }
            set { requireDerivedKeys = value; }
        }

        private bool establishSecurityContext;
        public bool EstablishSecurityContext
        {
            get { return establishSecurityContext; }
            set { establishSecurityContext = value; }
        }

        private bool requireSignatureConfirmation;
        public bool RequireSignatureConfirmation
        {
            get { return requireSignatureConfirmation; }
            set { requireSignatureConfirmation = value; }
        }

        private MessageProtectionOrder messageProtectionOrder;
        public MessageProtectionOrder MessageProtectionOrder
        {
            get { return messageProtectionOrder; }
            set { messageProtectionOrder = value; }
        }
        // </snippet3>
    }
}
// </snippet5>
