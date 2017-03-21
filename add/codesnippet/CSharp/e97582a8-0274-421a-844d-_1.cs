        CustomTextMessageBindingElement(CustomTextMessageBindingElement binding)
            : this(binding.Encoding, binding.MediaType, binding.MessageVersion)
        {
            this.readerQuotas = new XmlDictionaryReaderQuotas();
            binding.ReaderQuotas.CopyTo(this.readerQuotas);
        }