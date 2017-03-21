        Dim reader As New XmlTextReader("myfile.xml")
        Dim nsmanager As New XmlNamespaceManager(reader.NameTable)
        nsmanager.AddNamespace("msbooks", "www.microsoft.com/books")
        nsmanager.PushScope()
        nsmanager.AddNamespace("msstore", "www.microsoft.com/store")
        While reader.Read()
            Console.WriteLine("Reader Prefix:{0}", reader.Prefix)
            Console.WriteLine("XmlNamespaceManager Prefix:{0}",             nsmanager.LookupPrefix(nsmanager.NameTable.Get(reader.NamespaceURI)))
        End While