            SendActivity sendActivity1 = new SendActivity();
            ChannelToken channelToken1 = new ChannelToken();
            sendActivity1.ChannelToken = channelToken1;
            Dictionary<String, String> Context = (Dictionary<String, String>)SendActivity.GetContext(sendActivity1, channelToken1, contractType);