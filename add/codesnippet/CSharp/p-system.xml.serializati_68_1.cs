public class Car
{
   [XmlAttribute(Namespace = "Make")]
   public string MakerName;

   [XmlAttribute(Namespace = "Model")]
   public string ModelName;
}
