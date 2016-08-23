namespace ClassesAndObjects
{
    using System;
    class EntityExample
    {
        public static void Usage() 
        {
            Entity.SetNextSerialNo(1000);
            Entity e1 = new Entity();
            Entity e2 = new Entity();
            Console.WriteLine(e1.GetSerialNo());            // Outputs "1000"
            Console.WriteLine(e2.GetSerialNo());            // Outputs "1001"
            Console.WriteLine(Entity.GetNextSerialNo());    // Outputs "1002"
        }
    }
    class Entity
    {
        static int nextSerialNo;
        int serialNo;
        public Entity() 
        {
            serialNo = nextSerialNo++;
        }
        public int GetSerialNo() 
        {
            return serialNo;
        }
        public static int GetNextSerialNo() 
        {
            return nextSerialNo;
        }
        public static void SetNextSerialNo(int value) 
        {
            nextSerialNo = value;
        }
    }
}