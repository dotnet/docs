    public:
        generic <typename T> where T:gcnew()
        static T Bar()
        {
            return gcnew T();
        }