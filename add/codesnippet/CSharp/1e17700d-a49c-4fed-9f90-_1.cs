public class StateObject{
     public Socket workSocket = null;
     public const int BUFFER_SIZE = 1024;
     public byte[] buffer = new byte[BUFFER_SIZE];
     public StringBuilder sb = new StringBuilder();
}