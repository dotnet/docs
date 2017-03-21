    public string CreateSessionID(HttpContext context)
    {
      return Guid.NewGuid().ToString();
    }