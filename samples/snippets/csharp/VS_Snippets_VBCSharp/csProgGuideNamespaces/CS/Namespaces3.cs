//<Snippet19>
using System;
//<Snippet18>
using Microsoft.VisualBasic.Devices;
//</Snippet18>

class TestMyServices
{
    static void Main()
    {
        // Play a sound with the Audio class:
        Audio myAudio = new Audio();
        Console.WriteLine("Playing sound...");
        myAudio.Play(@"c:\WINDOWS\Media\chimes.wav");

        // Display time information with the Clock class:
        Clock myClock = new Clock();
        Console.Write("Current day of the week: ");
        Console.WriteLine(myClock.LocalTime.DayOfWeek);
        Console.Write("Current date and time: ");
        Console.WriteLine(myClock.LocalTime);

        // Display machine information with the Computer class:
        Computer myComputer = new Computer();
        Console.WriteLine("Computer name: " + myComputer.Name);

        if (myComputer.Network.IsAvailable)
        {
            Console.WriteLine("Computer is connected to network.");
        }
        else
        {
            Console.WriteLine("Computer is not connected to network.");
        }
    }
}
//</Snippet19>

//-----------------------------------------------------------------------------
public class TestCopy{

    public void CopyDirectory()
    {
        //<Snippet20>
        // Duplicate a directory
        Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(
            @"C:\original_directory",
            @"C:\copy_of_original_directory");
        //</Snippet20>
    }
}