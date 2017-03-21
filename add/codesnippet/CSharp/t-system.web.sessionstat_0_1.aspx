bool requiresSession = false;

if (Context.Handler is IRequiresSessionState)
  requiresSession = true;