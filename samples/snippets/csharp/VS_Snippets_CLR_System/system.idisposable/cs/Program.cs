﻿Test();

void Test()
{
    using DisposableDerived a = new();
    using DisposableDerivedWithFinalizer b = new();
    b.Dispose();
    using DisposableBaseWithSafeHandle c = new();
}

