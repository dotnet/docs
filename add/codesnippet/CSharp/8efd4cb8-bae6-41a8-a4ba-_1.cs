            string[] strings = {"Hello", "world"};
            MyBodyWriter bw = new MyBodyWriter(strings);

            StringBuilder strBuilder = new StringBuilder(10);
            XmlWriter writer = XmlWriter.Create(strBuilder);
            XmlDictionaryWriter dictionaryWriter = XmlDictionaryWriter.CreateDictionaryWriter(writer);

            bw.WriteBodyContents(dictionaryWriter);
            dictionaryWriter.Flush();