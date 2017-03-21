            Dim newElement As New SecurityElement("PolicyStatement")
            newElement.AddAttribute("class", policyStatement.ToString())
            newElement.AddAttribute("version", "1.1")

            newElement.AddChild(New SecurityElement("PermissionSet"))

            policyStatement.FromXml(newElement)