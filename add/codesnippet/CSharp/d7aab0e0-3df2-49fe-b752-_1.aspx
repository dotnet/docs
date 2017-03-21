    public class CustomStyle : 
        System.Web.UI.MobileControls.Style
        {
            private string themeNameKey;

            public CustomStyle(string name)
            {
                themeNameKey = 
                    RegisterStyle(name, typeof(String), 
                        String.Empty, true).ToString();
            }
            
            public string ThemeName
            {
                get
                {
                    return this[themeNameKey].ToString();
                }
                set
                {
                    this[themeNameKey] = value;
                }
            }
        }