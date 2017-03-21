// Find the number of members in the StaticObjects collection.
int ObjCount = Application.StaticObjects.Count;
// Create an array of the same size.
Object[] MyObjArray = new Object[ObjCount];
// Copy the entire collection into the array.
Application.StaticObjects.CopyTo(MyObjArray, 0);
