        // Check whether the request is sent
        // over HTTPS. If not, do not send 
        // content to the client.    
        if (!Request.IsSecureConnection)
        {
            Response.SuppressContent = true;
        }