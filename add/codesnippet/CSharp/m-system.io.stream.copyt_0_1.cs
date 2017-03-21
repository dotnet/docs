// Create the streams.
MemoryStream destination = new MemoryStream();

using (FileStream source = File.Open(@"c:\temp\data.dat",
    FileMode.Open))
{

    Console.WriteLine("Source length: {0}", source.Length.ToString());

    // Copy source to destination.
    source.CopyTo(destination);
}

Console.WriteLine("Destination length: {0}", destination.Length.ToString());