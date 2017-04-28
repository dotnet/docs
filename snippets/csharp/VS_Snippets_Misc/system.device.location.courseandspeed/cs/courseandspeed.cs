//<Snippet1>
using System;
using System.Device.Location;

namespace CourseAndSpeed
{
    class Program
    {
        static void Main(string[] args)
        {
            GetLocationCourseAndSpeed();
        }

        //<Snippet2>
        static void GetLocationCourseAndSpeed()
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();

            watcher.TryStart(true, TimeSpan.FromMilliseconds(1000));

            if (watcher.Position.Location.IsUnknown != true)
            {
                GeoCoordinate coord = watcher.Position.Location;

                Console.WriteLine("Course: {0}, Speed: {1}",
                    coord.Course,
                    coord.Speed);
            }
            else
            {
                Console.WriteLine("Unknown");
            }
        }
        //</Snippet2>

    }
}
//</Snippet1>
