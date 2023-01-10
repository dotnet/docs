// <Snippet0>
// <Snippet1>
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
// </Snippet1>

namespace Samples
{
    public sealed class CustomBindingCreator
    {
        private CustomBindingCreator() { }

        // <Snippet2>
        // These public methods create custom bindings based on the built-in
        // authentication modes that use the static methods of
        // the System.ServiceModel.Channels.SecurityBindingElement class.
        public static Binding CreateAnonymousForCertificateBinding()
        {
            BindingElementCollection bec = new BindingElementCollection();
            bec.Add(SecurityBindingElement.
                CreateAnonymousForCertificateBindingElement());
            bec.Add(new TextMessageEncodingBindingElement());
            bec.Add(new HttpTransportBindingElement());
            return new CustomBinding(bec);
        }

        public static Binding CreateAnonymousForSslNegotiatedBinding()
        {
            BindingElementCollection bec = new BindingElementCollection();
            bec.Add(SecurityBindingElement.
                CreateSslNegotiationBindingElement(false));
            bec.Add(new TextMessageEncodingBindingElement());
            bec.Add(new HttpTransportBindingElement());
            return new CustomBinding(bec);
        }

        public static Binding CreateCertificateOverTransportBinding()
        {
            BindingElementCollection bec = new BindingElementCollection();
            bec.Add(SecurityBindingElement.
                CreateCertificateOverTransportBindingElement());
            bec.Add(new TextMessageEncodingBindingElement());
            bec.Add(new HttpsTransportBindingElement());
            return new CustomBinding(bec);
        }

        public static Binding CreateIssuedTokenBinding()
        {
            BindingElementCollection bec = new BindingElementCollection();
            bec.Add(SecurityBindingElement.
                CreateIssuedTokenBindingElement(
                new IssuedSecurityTokenParameters()));
            bec.Add(new TextMessageEncodingBindingElement());
            bec.Add(new HttpTransportBindingElement());
            return new CustomBinding(bec);
        }

        public static Binding CreateIssuedTokenForCertificateBinding()
        {
            BindingElementCollection bec = new BindingElementCollection();
            bec.Add(SecurityBindingElement.
                CreateIssuedTokenForCertificateBindingElement(
                new IssuedSecurityTokenParameters()));
            bec.Add(new TextMessageEncodingBindingElement());
            bec.Add(new HttpTransportBindingElement());
            return new CustomBinding(bec);
        }

        public static Binding CreateIssuedTokenForSslNegotiatedBinding()
        {
            BindingElementCollection bec = new BindingElementCollection();
            bec.Add(SecurityBindingElement.
                CreateIssuedTokenForSslBindingElement(
                new IssuedSecurityTokenParameters()));
            bec.Add(new TextMessageEncodingBindingElement());
            bec.Add(new HttpTransportBindingElement());
            return new CustomBinding(bec);
        }

        public static Binding CreateIssuedTokenOverTransportBinding()
        {
            BindingElementCollection bec = new BindingElementCollection();
            bec.Add(SecurityBindingElement.
                CreateIssuedTokenOverTransportBindingElement(
                new IssuedSecurityTokenParameters()));
            bec.Add(new TextMessageEncodingBindingElement());
            bec.Add(new HttpsTransportBindingElement());
            return new CustomBinding(bec);
        }

        public static Binding CreateKerberosBinding()
        {
            BindingElementCollection bec = new BindingElementCollection();
            bec.Add(SecurityBindingElement.CreateKerberosBindingElement());
            bec.Add(new TextMessageEncodingBindingElement());
            bec.Add(new HttpTransportBindingElement());
            return new CustomBinding(bec);
        }

        public static Binding CreateKerberosOverTransportBinding()
        {
            BindingElementCollection bec = new BindingElementCollection();
            bec.Add(SecurityBindingElement.
                CreateKerberosOverTransportBindingElement());
            bec.Add(new TextMessageEncodingBindingElement());
            bec.Add(new HttpsTransportBindingElement());
            return new CustomBinding(bec);
        }

        public static Binding CreateMutualCertificateBinding()
        {
            BindingElementCollection bec = new BindingElementCollection();
            bec.Add(SecurityBindingElement.
                CreateMutualCertificateBindingElement());
            bec.Add(new TextMessageEncodingBindingElement());
            bec.Add(new HttpTransportBindingElement());
            return new CustomBinding(bec);
        }

        public static Binding CreateMutualCertificateDuplexBinding()
        {
            BindingElementCollection bec = new BindingElementCollection();
            bec.Add(SecurityBindingElement.
                CreateMutualCertificateDuplexBindingElement());
            bec.Add(new CompositeDuplexBindingElement());
            bec.Add(new OneWayBindingElement());
            bec.Add(new TextMessageEncodingBindingElement());
            bec.Add(new HttpTransportBindingElement());
            return new CustomBinding(bec);
        }

        public static Binding CreateMutualSslNegotiatedBinding()
        {
            BindingElementCollection bec = new BindingElementCollection();
            bec.Add(SecurityBindingElement.
                CreateSslNegotiationBindingElement(true));
            bec.Add(new TextMessageEncodingBindingElement());
            bec.Add(new HttpTransportBindingElement());
            return new CustomBinding(bec);
        }

        public static Binding CreateSecureConversationBinding()
        {
            BindingElementCollection bec = new BindingElementCollection();
            bec.Add(SecurityBindingElement.
                CreateSecureConversationBindingElement(
                SecurityBindingElement.CreateSspiNegotiationBindingElement()));
            bec.Add(new TextMessageEncodingBindingElement());
            bec.Add(new HttpTransportBindingElement());
            return new CustomBinding(bec);
        }

        public static Binding CreateSspiNegotiatedBinding()
        {
            BindingElementCollection bec = new BindingElementCollection();
            bec.Add(SecurityBindingElement.CreateSspiNegotiationBindingElement());
            bec.Add(new TextMessageEncodingBindingElement());
            bec.Add(new HttpTransportBindingElement());
            return new CustomBinding(bec);
        }

        public static Binding CreateSspiNegotiatedOverTransportBinding()
        {
            BindingElementCollection bec = new BindingElementCollection();
            bec.Add(SecurityBindingElement.
                CreateSspiNegotiationOverTransportBindingElement());
            bec.Add(new TextMessageEncodingBindingElement());
            bec.Add(new HttpsTransportBindingElement());
            return new CustomBinding(bec);
        }

        public static Binding CreateUserNameForCertificateBinding()
        {
            BindingElementCollection bec = new BindingElementCollection();
            bec.Add(SecurityBindingElement.
                CreateUserNameForCertificateBindingElement());
            bec.Add(new TextMessageEncodingBindingElement());
            bec.Add(new HttpTransportBindingElement());
            return new CustomBinding(bec);
        }

        public static Binding CreateUserNameForSslNegotiatedBinding()
        {
            BindingElementCollection bec = new BindingElementCollection();
            bec.Add(SecurityBindingElement.CreateUserNameForSslBindingElement());
            bec.Add(new TextMessageEncodingBindingElement());
            bec.Add(new HttpTransportBindingElement());
            return new CustomBinding(bec);
        }

        public static Binding CreateUserNameOverTransportBinding()
        {
            BindingElementCollection bec = new BindingElementCollection();
            bec.Add(SecurityBindingElement.
                CreateUserNameOverTransportBindingElement());
            bec.Add(new TextMessageEncodingBindingElement());
            bec.Add(new HttpsTransportBindingElement());
            return new CustomBinding(bec);
        }
        // </Snippet2>
    }
}
// </Snippet0>

namespace samples2
{
    public class Test
    {

        static void Main()
        {
        }

        public static Binding CreateCustomBinding()
        {
            // <Snippet8>
            // <Snippet3>
            SymmetricSecurityBindingElement b =
                SecurityBindingElement.
                CreateAnonymousForCertificateBindingElement();
            // </Snippet3>

            // <Snippet4>
            BindingElementCollection outputBindings =
                new BindingElementCollection();
            // </Snippet4>

            // <Snippet5>
            b.DefaultAlgorithmSuite = SecurityAlgorithmSuite.Basic128;
            b.MessageProtectionOrder =
                MessageProtectionOrder.SignBeforeEncrypt;
            b.ProtectionTokenParameters =
                new KerberosSecurityTokenParameters();
            // </Snippet5>
            // </Snippet8>

            // <Snippet6>
            outputBindings.Add(b);
            outputBindings.Add(new TextMessageEncodingBindingElement());
            outputBindings.Add(new HttpTransportBindingElement());
            // </Snippet6>

            // <Snippet7>
            return new CustomBinding(outputBindings);
            // </Snippet7>
        }
    }
}
