            ChannelToken channelToken1 = new ChannelToken();
            SendActivity requestQuoteFromShipper3 = new SendActivity();
            channelToken1.EndpointName = "Shipper3Endpoint";
            channelToken1.Name = "Shipper3Endpoint";
            channelToken1.OwnerActivityName = "GetShippingQuotes";
            requestQuoteFromShipper3.ChannelToken = channelToken1;