using System;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.ServiceModel.Security.Tokens;

namespace Microsoft.ServiceModel.Samples
{
  //<snippet2>
    public class InternetClientValidatorBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint serviceEndpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters) { }
        public void ApplyClientBehavior(ServiceEndpoint serviceEndpoint, System.ServiceModel.Dispatcher.ClientRuntime behavior) { }
        public void ApplyDispatchBehavior(ServiceEndpoint serviceEndpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher) { }

        public void Validate(ServiceEndpoint endpoint)
        {
            BindingElementCollection elements = endpoint.Binding.CreateBindingElements();

            if (EndpointIsDual(endpoint, elements))
                throw new InvalidOperationException("InternetClientValidator: endpoint uses 'dual' mode. This mode is disallowed for use with untrusted services.");

            if (EndpointAllowsNtlm(endpoint, elements))
                throw new InvalidOperationException("InternetClientValidator: endpoint allows NTLM. This mode is disallowed for use with untrusted services.");

            if (EndpointAllowsTransactionFlow(endpoint, elements))
                throw new InvalidOperationException("InternetClientValidator: endpoint flows transaction ids. This mode is disallowed for use with untrusted services.");
        }
        //</snippet2>

        static bool EndpointIsDual(ServiceEndpoint endpoint, BindingElementCollection elements)
        {
            return elements.Contains(typeof(CompositeDuplexBindingElement));
        }

        static bool EndpointAllowsNtlm(ServiceEndpoint endpoint, BindingElementCollection elements)
        {
            ClientCredentials creds = endpoint.Behaviors.Find<ClientCredentials>();
            return creds != null && creds.Windows.AllowNtlm && BindingRequiresAuthentication(elements);
        }

        static bool EndpointAllowsTransactionFlow(ServiceEndpoint endpoint, BindingElementCollection elements)
        {
            TransactionFlowBindingElement flow = elements.Find<TransactionFlowBindingElement>();
            return flow != null && ContractAllowsTransactionFlow(endpoint.Contract);
        }

        static bool ContractAllowsTransactionFlow(ContractDescription contract)
        {
            foreach (OperationDescription operation in contract.Operations)
            {
                TransactionFlowAttribute flowAttr = operation.Behaviors.Find<TransactionFlowAttribute>();
                if (flowAttr != null && flowAttr.Transactions != TransactionFlowOption.NotAllowed)
                    return true;
            }
            return false;
        }

        static bool BindingRequiresAuthentication(BindingElementCollection elements)
        {
            SecurityBindingElement element = elements.Find<SecurityBindingElement>();
            if (element != null)
            {
                foreach (SecurityTokenParameters parameters in EnumerateNestedTokenParameters(element))
                {
                    if (parameters is SspiSecurityTokenParameters)
                        return true;
                }
            }
            return false;
        }

        static IEnumerable<SecurityTokenParameters> EnumerateNestedTokenParameters(SecurityBindingElement element)
        {
            foreach (SecurityTokenParameters parameters in EnumerateTokenParameters(element))
            {
                if (parameters is SecureConversationSecurityTokenParameters)
                {
                    SecurityBindingElement nestedElement = ((SecureConversationSecurityTokenParameters)parameters).BootstrapSecurityBindingElement;
                    foreach (SecurityTokenParameters nestedParameters in EnumerateTokenParameters(nestedElement))
                    {
                        yield return nestedParameters;
                    }
                }
            }
        }

        static IEnumerable<SecurityTokenParameters> EnumerateTokenParameters(SecurityBindingElement element)
        {
            bool clientTokensOnly = true;

            if (element is SymmetricSecurityBindingElement)
            {
                SymmetricSecurityBindingElement ssbe = (SymmetricSecurityBindingElement)element;
                if (ssbe.ProtectionTokenParameters != null /*&& (!clientTokensOnly || !ssbe.ProtectionTokenParameters.HasAsymmetricKey)*/)
                    yield return ssbe.ProtectionTokenParameters;
            }
            else if (element is AsymmetricSecurityBindingElement)
            {
                AsymmetricSecurityBindingElement asbe = (AsymmetricSecurityBindingElement)element;
                if (asbe.InitiatorTokenParameters != null)
                    yield return asbe.InitiatorTokenParameters;
                if (asbe.RecipientTokenParameters != null && !clientTokensOnly)
                    yield return asbe.RecipientTokenParameters;
            }
            foreach (SecurityTokenParameters stp in element.EndpointSupportingTokenParameters.Endorsing)
                if (stp != null)
                    yield return stp;
            foreach (SecurityTokenParameters stp in element.EndpointSupportingTokenParameters.SignedEncrypted)
                if (stp != null)
                    yield return stp;
            foreach (SecurityTokenParameters stp in element.EndpointSupportingTokenParameters.SignedEndorsing)
                if (stp != null)
                    yield return stp;
            foreach (SecurityTokenParameters stp in element.EndpointSupportingTokenParameters.Signed)
                if (stp != null)
                    yield return stp;
            foreach (SupportingTokenParameters str in element.OperationSupportingTokenParameters.Values)
                if (str != null)
                {
                    foreach (SecurityTokenParameters stp in str.Endorsing)
                        if (stp != null)
                            yield return stp;
                    foreach (SecurityTokenParameters stp in str.SignedEncrypted)
                        if (stp != null)
                            yield return stp;
                    foreach (SecurityTokenParameters stp in str.SignedEndorsing)
                        if (stp != null)
                            yield return stp;
                    foreach (SecurityTokenParameters stp in str.Signed)
                        if (stp != null)
                            yield return stp;
                }
        }
    }
}
