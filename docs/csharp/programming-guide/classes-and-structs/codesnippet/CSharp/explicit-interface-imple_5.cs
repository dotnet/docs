    class Middle : ILeft, IRight
    {
        public int P() { return 0; }
        int ILeft.P { get { return 0; } }
    }