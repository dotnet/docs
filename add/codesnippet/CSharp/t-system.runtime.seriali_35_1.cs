            FileStream fs = new FileStream("mystuff.xml", FileMode.Create, FileAccess.ReadWrite);
            XElement myElement = new XElement("Parent", new XElement("child1", "form"),
                new XElement("child2", "base"),
                new XElement("child3", "formbase")
                );
            NetDataContractSerializer dcs = new NetDataContractSerializer();
            dcs.WriteObject(fs, myElement);