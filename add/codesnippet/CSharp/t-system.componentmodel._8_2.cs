    public class SampleObject
    {
        private string stringValue = null;
        private int intValue = int.MinValue;
        private SampleObject childValue = null;

        public string StringProperty
        {
            get { return this.stringValue; }

            set { this.stringValue = value; }
        }

        public int IntProperty
        {
            get { return this.intValue; }

            set { this.intValue = value; }
        }

        public SampleObject Child
        {
            get { return this.childValue; }

            set { this.childValue = value; }
        }
    }