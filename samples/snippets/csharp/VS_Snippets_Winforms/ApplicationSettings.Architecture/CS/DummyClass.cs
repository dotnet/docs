//<SNIPPET1>
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace ApplicationSettingsArchitectureCS
{
    class CustomSettings : ApplicationSettingsBase
    {
        // Implementation goes here.
    }
}
//</SNIPPET1>

namespace ApplicationSettingsArchitectureCS
{
    public abstract class DummySettingsBase
    {
        public abstract string ApplicationName
        {
            get;
            set;
        }
    }

    public class DummySettings : DummySettingsBase
    {
        //<SNIPPET2>
        public override string ApplicationName
        {
            get
            {
                return (System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            }
            set
            {
                // Do nothing.
            }
        }
        //</SNIPPET2>
    }
}

