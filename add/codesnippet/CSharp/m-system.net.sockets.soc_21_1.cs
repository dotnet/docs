 try {
     aSocket.Bind(anEndPoint);
 }
 catch (Exception e) {
     Console.WriteLine("Winsock error: " + e.ToString());
 }
 