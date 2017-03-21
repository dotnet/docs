bool readOnlySession = false;

if (Context.Handler is IReadOnlySessionState)
  readOnlySession = true;