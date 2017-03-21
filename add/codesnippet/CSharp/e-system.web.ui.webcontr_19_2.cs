    public void EmployeeUpdating(object source, ObjectDataSourceMethodEventArgs e)
    {
        DataContractSerializer dcs = new DataContractSerializer(typeof(Employee));

        String xmlData = ViewState["OriginalEmployee"].ToString();
        XmlReader reader = XmlReader.Create(new StringReader(xmlData));
        Employee originalEmployee = (Employee)dcs.ReadObject(reader);
        reader.Close();

        e.InputParameters.Add("originalEmployee", originalEmployee);
    }

    public void EmployeeSelected(object source, ObjectDataSourceStatusEventArgs e)
    {
        if (e.ReturnValue != null)
        {
            DataContractSerializer dcs = new DataContractSerializer(typeof(Employee));
            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb);
            dcs.WriteObject(writer, e.ReturnValue);
            writer.Close();

            ViewState["OriginalEmployee"] = sb.ToString();
        }
    }