    <%

        // Create a character array.
    char[] charArray = {'H', 'e', 'l', 'l', 'o', ',', ' ', 
                           'w', 'o', 'r', 'l', 'd'};

        // Write a character array to the client.
        Response.Write(charArray, 0, charArray.Length);

        // Write a single characher.
        Response.Write(';');

        // Write a sub-section of a character array to the client.
        Response.Write(charArray, 0, 5);
        // Write an object to the client.
        object obj = (object)13;
        Response.Write(obj);

    %>