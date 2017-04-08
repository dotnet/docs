//<Snippet1>
using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class Forest{
   /* Set the NestingLevel for each array. The first 
   attribute (NestingLevel = 0) is optional. */
   [XmlArrayItem(ElementName = "tree", NestingLevel = 0)]
   [XmlArrayItem(ElementName = "branch", NestingLevel = 1)]
   [XmlArrayItem(ElementName = "leaf",NestingLevel = 2)]
   public string[][][] TreeArray;
}

public class Test{
   public static void Main(){
      Test t = new Test();
      t.SerializeObject("Tree.xml");
   }
   private void SerializeObject(string filename){
      XmlSerializer serializer = 
      new XmlSerializer(typeof(Forest));

      Forest f = new Forest();
      string[][][] myTreeArray = new string[2] [][];

      string[][]myBranchArray1= new string[1][];
      myBranchArray1[0]=new string[1]{"One"};
      myTreeArray[0]=myBranchArray1;

      string[][]myBranchArray2= new string[2][];
      myBranchArray2[0]=new string[2]{"One","Two"};
      myBranchArray2[1]=new string[3]{"One","Two","Three"};
      myTreeArray[1]=myBranchArray2;
   
      f.TreeArray=myTreeArray;

     serializer.Serialize(Console.Out, f);
   }
}
//</Snippet1>
