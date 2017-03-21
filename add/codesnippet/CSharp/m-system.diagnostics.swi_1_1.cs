    public class MySourceSwitch : SourceSwitch
    {
        int sourceAttribute = 0;
        public MySourceSwitch(string n) : base(n) { }
        public int CustomSourceSwitchAttribute
        {
            get
            {
                foreach (DictionaryEntry de in this.Attributes)
                    if (de.Key.ToString().ToLower() == "customsourceswitchattribute")
                        sourceAttribute = (int)de.Value;
                return sourceAttribute;
            }
            set { sourceAttribute = (int)value; }
        }

        protected override string[] GetSupportedAttributes()
        {
            return new string[] { "customsourceSwitchattribute" };
        }
    }