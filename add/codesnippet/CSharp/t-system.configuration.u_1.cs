    //Application settings wrapper class
    sealed class FormSettings : ApplicationSettingsBase
    {
        [UserScopedSettingAttribute()]
        public String FormText
        {
            get { return (String)this["FormText"]; }
            set { this["FormText"] = value; }
        }

        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("0, 0")]
        public Point FormLocation
        {
            get { return (Point)(this["FormLocation"]); }
            set { this["FormLocation"] = value; }
        }

        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("225, 200")]
        public Size FormSize
        {
            get { return (Size)this["FormSize"]; }
            set { this["FormSize"] = value; }
        }


        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("LightGray")]
        public Color FormBackColor
        {
            get { return (Color)this["FormBackColor"]; }
            set { this["FormBackColor"] = value; }
        }

    }