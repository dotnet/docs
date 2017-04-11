using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//namespace GFUDemo_CS
//{
    public class Automobile
    {
        public int TopSpeed { get; set; }

        public string Model { get; set; }

        public Automobile(string model, int topSpeed)
        {
            this.Model = model;
            this.TopSpeed = topSpeed;
        }

        //<Snippet5>
        public Automobile()
        {
            this.Model = "Not specified";
            this.TopSpeed = -1;
            this.IsRunning = true;
        }
        //</Snippet5>

        //<Snippet6>
        public void Start()
        {
            if (this.Model != "Not specified" || this.TopSpeed != -1)
                this.IsRunning = true;
            else
                this.IsRunning = false;
        }
        //</Snippet6>

        public bool IsRunning { get; set; }
    }
//}
