
        if(service == null) {
            Console.WriteLine("Could not locate server.");
            return;
        }


        // Calls the remote method.
        Console.WriteLine();
        Console.WriteLine("Calling remote object");
        Console.WriteLine(service.HelloMethod("Caveman"));
        Console.WriteLine(service.HelloMethod("Spaceman"));
        Console.WriteLine(service.HelloMethod("Client Man"));
        Console.WriteLine("Finished remote object call");
        Console.WriteLine();
    }
}