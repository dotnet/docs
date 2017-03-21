            SecurityElement newElement = 
                new SecurityElement("PolicyStatement");
            newElement.AddAttribute("class", policyStatement.ToString());
            newElement.AddAttribute("version","1.1");

            newElement.AddChild(new SecurityElement("PermissionSet"));

            policyStatement.FromXml(newElement);