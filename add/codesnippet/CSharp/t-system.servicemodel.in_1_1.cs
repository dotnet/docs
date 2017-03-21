            string info = "";

            OperationContext operationContext = OperationContext.Current;
            InstanceContext instanceContext = operationContext.InstanceContext;

            info += "    " + "State: " + instanceContext.State.ToString() + "\n";
            info += "    " + "ManualFlowControlLimit: " + instanceContext.ManualFlowControlLimit.ToString() + "\n";
            info += "    " + "HashCode: " + instanceContext.GetHashCode().ToString() + "\n";
                     
            return info;