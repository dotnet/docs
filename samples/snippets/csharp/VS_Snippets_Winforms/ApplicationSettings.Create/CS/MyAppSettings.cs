//<SNIPPET1>
using System;
using System.Configuration;
using System.Drawing;

public class MyUserSettings : ApplicationSettingsBase
{
    [UserScopedSetting()]
    [DefaultSettingValue("white")]
    public Color BackgroundColor
    {
        get
        {
            return ((Color)this["BackgroundColor"]);
        }
        set
        {
            this["BackgroundColor"] = (Color)value;
        }
    }
}
//</SNIPPET1>
