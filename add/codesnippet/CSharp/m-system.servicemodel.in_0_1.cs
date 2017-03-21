                string info = "";

                InstanceContext instanceContext = new InstanceContext(serviceHost);
                info += "    " + "State: " + instanceContext.State.ToString() + "\n";
                info += "    " + "ManualFlowControlLimit: " + instanceContext.ManualFlowControlLimit.ToString() + "\n";
                info += "    " + "HashCode: " + instanceContext.GetHashCode().ToString() + "\n";

                Console.WriteLine(info);