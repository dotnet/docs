            string[] strings = { "Hello", "world" };
            MyBodyWriter bodyWriter = new MyBodyWriter(strings);

            StringBuilder strBuilder = new StringBuilder(10);
            XmlWriter writer = XmlWriter.Create(strBuilder);
            XmlDictionaryWriter dictionaryWriter = XmlDictionaryWriter.CreateDictionaryWriter(writer);

            bodyWriter.WriteBodyContents(dictionaryWriter);
            dictionaryWriter.Flush();

            MyBodyWriter bufferedBodyWriter = (MyBodyWriter) bodyWriter.CreateBufferedCopy(1024);