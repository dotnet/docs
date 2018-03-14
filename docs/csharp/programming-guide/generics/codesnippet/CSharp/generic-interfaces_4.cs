        interface IMonth<T> { }

        interface IJanuary     : IMonth<int> { }  //No error
        interface IFebruary<T> : IMonth<int> { }  //No error
        interface IMarch<T>    : IMonth<T> { }    //No error
        //interface IApril<T>  : IMonth<T, U> {}  //Error