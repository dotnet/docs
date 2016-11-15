        class BaseNodeMultiple<T, U> { }

        //No error
        class Node4<T> : BaseNodeMultiple<T, int> { }

        //No error
        class Node5<T, U> : BaseNodeMultiple<T, U> { }

        //Generates an error
        //class Node6<T> : BaseNodeMultiple<T, U> {} 