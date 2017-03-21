    [DefaultEvent("CollectionChanged")]
    public class MyCollection : BaseCollection {
         
        private CollectionChangeEventHandler onCollectionChanged;
         
        public event CollectionChangeEventHandler CollectionChanged {
           add {
              onCollectionChanged += value;
           }
           remove {
              onCollectionChanged -= value;
           }
        }
        // Insert additional code.
    }