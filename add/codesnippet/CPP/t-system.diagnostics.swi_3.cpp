public ref class MyMethodTracingSwitch: public Switch
{
protected:
    bool outExit;
    bool outEnter;
    MethodTracingSwitchLevel level;

public:
    MyMethodTracingSwitch( String^ displayName, String^ description )
       : Switch( displayName, description )
    {}

    property MethodTracingSwitchLevel Level
    {
        MethodTracingSwitchLevel get()
        {
            return level;
        }

       void set( MethodTracingSwitchLevel value )
       {
           SetSwitchSetting( (int)value );
       }
    }

protected:
    void SetSwitchSetting( int value )
    {
        if ( value < 0 )
        {
            value = 0;
        }

        if ( value > 3 )
        {
            value = 3;
        }

        level = (MethodTracingSwitchLevel)value;
        outEnter = false;
        if ((value == (int)MethodTracingSwitchLevel::EnteringMethod) ||
            (value == (int)MethodTracingSwitchLevel::Both))
        {
            outEnter = true;
        }

        outExit = false;
        if ((value == (int)MethodTracingSwitchLevel::ExitingMethod) ||
            (value == (int)MethodTracingSwitchLevel::Both))
        {
            outExit = true;
        }
    }

public:
    property bool OutputExit
    {
        bool get()
        {
            return outExit;
        }
    }

    property bool OutputEnter
    {
        bool get()
        {
            return outEnter;
        }
    }
};

