namespace WorkerScope.Example;

sealed class AutoIncrementingIdProvider : IObjectIdProvider
{
    static int s_id;

    int IObjectIdProvider.GetNextId() => ++ s_id;
}
