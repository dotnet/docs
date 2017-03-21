            OperationContext operationContext = OperationContext.Current;
            InstanceContext instanceContext = operationContext.InstanceContext;
            ICollection<IChannel> OutgoingChannels = instanceContext.OutgoingChannels;