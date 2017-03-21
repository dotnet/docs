            NetMsmqBinding binding = new NetMsmqBinding();
            BindingElementCollection bindingElements = binding.CreateBindingElements();

            foreach (BindingElement element in bindingElements)
            {
                Console.WriteLine(element.ToString());
            }