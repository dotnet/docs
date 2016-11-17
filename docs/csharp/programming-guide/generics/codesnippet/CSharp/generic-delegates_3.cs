        class Stack<T>
        {
            T[] items;
            int index;

            public delegate void StackDelegate(T[] items);
        }