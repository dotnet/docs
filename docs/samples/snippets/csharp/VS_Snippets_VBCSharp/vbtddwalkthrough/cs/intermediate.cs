using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

class Intermediate
{
    [TestClass]
    public class Class1
    {
        //<Snippet2>
        [TestMethod]
        public void AutomobileWithModelNameCanStart()
        {
            string model = "Contoso";
            int topSpeed = 199;
            Automobile myAuto = new Automobile(model, topSpeed);
        }
        //</Snippet2>
    }

    //<Snippet4>
    public class Automobile
    {
        public string Model { get; set; }
        public int TopSpeed { get; set; }

        public Automobile(string model, int topSpeed)
        {
            this.Model = model;
            this.TopSpeed = topSpeed;
        }

        public Automobile()
        {
            // TODO: Complete member initialization
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public bool IsRunning { get; set; }
    }
    //</Snippet4>
}
