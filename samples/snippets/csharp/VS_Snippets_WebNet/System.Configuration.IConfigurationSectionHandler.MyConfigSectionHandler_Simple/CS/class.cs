//<snippet1>
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Xml;

namespace MyConfigSectionHandler
{
  public class MyHandler : IConfigurationSectionHandler
  {
    #region IConfigurationSectionHandler Members

    object IConfigurationSectionHandler.Create(
        object parent, object configContext, XmlNode section)
    {
      throw new Exception("The method is not implemented.");
    }

    #endregion
  }
}
//</snippet1>