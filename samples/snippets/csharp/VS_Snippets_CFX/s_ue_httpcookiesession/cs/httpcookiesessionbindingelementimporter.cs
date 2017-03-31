
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

namespace Microsoft.ServiceModel.Samples
{
    using System;
    using System.ServiceModel.Description;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Xml;

    public class HttpCookieSessionBindingElementImporter : IPolicyImportExtension
    {
        void IPolicyImportExtension.ImportPolicy(MetadataImporter importer, 
            PolicyConversionContext context)
        {
            foreach (XmlElement assertion in context.GetBindingAssertions())
            {
                if (assertion.Name == HttpCookiePolicyStrings.HttpCookiePolicyElement
                    && assertion.NamespaceURI == HttpCookiePolicyStrings.Namespace)
                {
                    HttpCookieSessionBindingElement bindingElement =
                        new HttpCookieSessionBindingElement();

                    XmlAttribute attribute =
                        assertion.Attributes[HttpCookiePolicyStrings.ExchangeTerminateAttribute];

                    if(attribute != null)
                    {
                        bindingElement.ExchangeTerminateMessage = true;
                    }

                    context.BindingElements.Add(bindingElement);
                    break;
                }
            }
        }
    }
}
