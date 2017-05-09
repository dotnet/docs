//<snippet00>
using System;
using System.IO;

class Test
{
    public static void Main()
    {
        DriveInfo[] allDrives = DriveInfo.GetDrives();

        foreach (DriveInfo d in allDrives)
        {
            Console.WriteLine("Drive {0}", d.Name);
            Console.WriteLine("  Drive type: {0}", d.DriveType);
            if (d.IsReady == true)
            {
                Console.WriteLine("  Volume label: {0}", d.VolumeLabel);
                Console.WriteLine("  File system: {0}", d.DriveFormat);
                Console.WriteLine(
                    "  Available space to current user:{0, 15} bytes", 
                    d.AvailableFreeSpace);

                Console.WriteLine(
                    "  Total available space:          {0, 15} bytes",
                    d.TotalFreeSpace);

                Console.WriteLine(
                    "  Total size of drive:            {0, 15} bytes ",
                    d.TotalSize);
            }
        }
    }
}
/* 
This code produces output similar to the following:

Drive A:\
  Drive type: Removable
Drive C:\
  Drive type: Fixed
  Volume label: 
  File system: FAT32
  Available space to current user:     4770430976 bytes
  Total available space:               4770430976 bytes
  Total size of drive:                10731683840 bytes 
Drive D:\
  Drive type: Fixed
  Volume label: 
  File system: NTFS
  Available space to current user:    15114977280 bytes
  Total available space:              15114977280 bytes
  Total size of drive:                25958948864 bytes 
Drive E:\
  Drive type: CDRom

The actual output of this code will vary based on machine and the permissions
granted to the user executing it.
*/
//</snippet00>