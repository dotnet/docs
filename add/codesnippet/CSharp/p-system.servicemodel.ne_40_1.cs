            NetMsmqBinding binding = new NetMsmqBinding();
            XmlDictionaryReaderQuotas readerQuotas = new XmlDictionaryReaderQuotas();
            readerQuotas.MaxArrayLength = 25 * 1024;
            binding.ReaderQuotas = readerQuotas;