            Dim fs As New FileStream("mystuff.xml", FileMode.Create, FileAccess.ReadWrite)
            Dim myElement As New XElement("Parent", New XElement("child1", "form"), _
                New XElement("child2", "base"), _
                New XElement("child3", "formbase") _
                )
            Dim ser As New System.Runtime.Serialization. _
              NetDataContractSerializer()
            ser.WriteObject(fs, myElement)