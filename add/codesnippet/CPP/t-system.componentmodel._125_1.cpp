    [DefaultEvent("CollectionChanged")]
    public ref class TestCollection: public BaseCollection
    {
    private:
        CollectionChangeEventHandler^ onCollectionChanged;
        
    public:
        event CollectionChangeEventHandler^ CollectionChanged 
        {
        public:
            void add(CollectionChangeEventHandler^ eventHandler)
            { 
                onCollectionChanged += eventHandler; 
            }

        protected:
            void remove(CollectionChangeEventHandler^ eventHandler) 
            { 
                onCollectionChanged -= eventHandler; 
            }
        }
        // Insert additional code.
    };