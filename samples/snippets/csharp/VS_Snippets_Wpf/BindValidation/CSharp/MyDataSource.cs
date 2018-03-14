using System;

namespace SDKSample
{
    public class MyDataSource
    {
        private int _age;
        private int _age2;
        private int _age3;

        public MyDataSource()
        {
            Age = 0;
            Age2 = 0;
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public int Age2
        {
            get { return _age2; }
            set { _age2 = value; }
        }

        public int Age3
        {
            get { return _age3; }
            set { _age3 = value; }
        }
    }
}
