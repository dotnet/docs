    //Application settings wrapper class
    ref class FormSettings sealed: public ApplicationSettingsBase
    {
    public:
        [UserScopedSettingAttribute()]
        property String^ FormText
        {
            String^ get()
            {
                return (String^)this["FormText"];
            }
            void set( String^ value )
            {
                this["FormText"] = value;
            }
        }

    public:
        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("0, 0")]
        property Point FormLocation
        {
            Point get()
            {
                return (Point)(this["FormLocation"]);
            }
            void set( Point value )
            {
                this["FormLocation"] = value;
            }
        }

    public:
        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("225, 200")]
        property Size FormSize
        {
            Size get()
            {
                return (Size)this["FormSize"];
            }
            void set( Size value )
            {
                this["FormSize"] = value;
            }
        }

    public:
        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("LightGray")]
        property Color FormBackColor
        {
            Color get()
            {
                return (Color)this["FormBackColor"];
            }
            void set(Color value)
            {
                this["FormBackColor"] = value;
            }
        }

    };