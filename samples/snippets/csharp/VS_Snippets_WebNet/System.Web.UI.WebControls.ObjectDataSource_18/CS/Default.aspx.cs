using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Runtime.Serialization;
using System.Xml;
using System.Text;
using System.IO;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // <Snippet2>
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
    // </Snippet2>
}
