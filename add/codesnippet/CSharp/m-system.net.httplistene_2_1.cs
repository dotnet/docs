    public static void SetExpirationDate(long seconds, HttpListenerResponse response)
    {
        response.AddHeader("Expires", seconds.ToString());
    }