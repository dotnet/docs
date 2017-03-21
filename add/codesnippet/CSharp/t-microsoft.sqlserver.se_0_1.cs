[SqlFunctionAttribute(FillRowMethodName = "FillFileRow")]
public static IEnumerable GetFileDetails(string directoryPath)
{
   try
   {
      DirectoryInfo di = new DirectoryInfo(directoryPath);
      return di.GetFiles();
   }
   catch (DirectoryNotFoundException dnf)
   {
      return new string[1] { dnf.ToString() };
   }
			
}