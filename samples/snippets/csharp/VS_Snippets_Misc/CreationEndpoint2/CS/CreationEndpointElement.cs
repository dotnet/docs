//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
using System;
using System.Configuration;
using System.ServiceModel.Activities;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;

namespace Microsoft.Samples.WF.CreationEndpoint
{
    //config element for CreationEndpoint
    public class CreationEndpointElement : StandardEndpointElement
    {
        protected override Type EndpointType
        {
            get { return typeof(CreationEndpoint); }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                ConfigurationPropertyCollection properties = base.Properties;
                properties.Add(new ConfigurationProperty("name", typeof(String), null, ConfigurationPropertyOptions.IsRequired));
                return properties;
            }
        }

        protected override ServiceEndpoint CreateServiceEndpoint(ContractDescription contractDescription)
        {
            return new CreationEndpoint();
        }

        protected override void OnApplyConfiguration(ServiceEndpoint endpoint, ChannelEndpointElement channelEndpointElement)
        {
        }

        protected override void OnApplyConfiguration(ServiceEndpoint endpoint, ServiceEndpointElement serviceEndpointElement)
        {
        }

        protected override void OnInitializeAndValidate(ChannelEndpointElement channelEndpointElement)
        {
        }

        protected override void OnInitializeAndValidate(ServiceEndpointElement serviceEndpointElement)
        {
        }
    }

    public class CreationEndpointCollection : StandardEndpointCollectionElement<CreationEndpoint, CreationEndpointElement>
    {
    }

}

