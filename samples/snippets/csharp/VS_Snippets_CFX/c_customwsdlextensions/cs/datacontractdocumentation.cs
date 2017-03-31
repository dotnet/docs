using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.WCF.Documentation
{
  public class DataContractDocumentationAttribute : Attribute
  {
    private string annotation;

    public DataContractDocumentationAttribute(string comment)
    {
      this.annotation = comment;
    }

    public string Comment
    {
      get { return annotation; }
      set { annotation = value; }
    }
  }

  public class DCAnnotationSurrogate : IDataContractSurrogate
  {
    #region IDataContractSurrogate Members
    public object GetCustomDataToExport(Type clrType, Type dataContractType)
    {
      object[] dcDocAttrs 
        = dataContractType.GetCustomAttributes(typeof(DataContractDocumentationAttribute), false);
      Console.WriteLine("IDataContractSurrogate.GetCustomDataToExport(type) called.");
      if (dcDocAttrs.Length == 1)
      { 
        return "<summary>"
          + ((DataContractDocumentationAttribute)dcDocAttrs[0]).Comment 
          + "</summary>";
      }
      else
        return null;
    }

    public object GetCustomDataToExport(System.Reflection.MemberInfo memberInfo, Type dataContractType)
    {
      object[] dcDocAttrs
        = memberInfo.GetCustomAttributes(typeof(DataContractDocumentationAttribute), false);
      Console.WriteLine("IDataContractSurrogate.GetCustomDataToExport(member) called.");
      if (dcDocAttrs.Length == 1)
      {
        return "<summary>"
          + ((DataContractDocumentationAttribute)dcDocAttrs[0]).Comment
          + "</summary>";
      }
      else
        return null;
    }

    public Type GetDataContractType(Type type)
    {
      Console.WriteLine("GetDataContractType called.");
      return type;
    }

    public object GetDeserializedObject(object obj, Type targetType)
    {
      Console.WriteLine("GetDeserializedObject called.");
      return obj;
    }

    public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
    {
      Console.WriteLine("GetKnownCustomDataTypes called for {0} of types:", customDataTypes.Count);
      foreach(Type thing in customDataTypes)
        Console.WriteLine("\t{0}", thing.Name);
    }

    public object GetObjectToSerialize(object obj, Type targetType)
    {
      Console.WriteLine("IDataContractSurrogate.GetObjectToSerialize called.");
      return null;
    }

    public Type GetReferencedTypeOnImport(
      string typeName, 
      string typeNamespace, 
      object customData)
    {
      Console.WriteLine(typeName);
      Console.WriteLine(typeNamespace);
      if (customData != null)
      Console.WriteLine("GetReferenceTypeOnImport called. Custom data is: {0}", customData.ToString());
      return null;
    }

    public System.CodeDom.CodeTypeDeclaration ProcessImportedType(
      System.CodeDom.CodeTypeDeclaration typeDeclaration, 
      System.CodeDom.CodeCompileUnit compileUnit
    )
    {
      Console.WriteLine("ProcessImportedType called for {0}.", typeDeclaration.Name);
      object typeCustomData = typeDeclaration.UserData[typeof(IDataContractSurrogate)];
      if (typeDeclaration.Comments.Count == 0)
        typeDeclaration.Comments.AddRange(Formatter.FormatComments(typeCustomData.ToString()));
      
      foreach (CodeTypeMember member in typeDeclaration.Members)
      {
        object memberCustomData = member.UserData[typeof(IDataContractSurrogate)];
        if (memberCustomData != null 
          && memberCustomData is string
          && member.Comments.Count == 0)
        {
          member.Comments.AddRange(
            Formatter.FormatComments(memberCustomData.ToString())
          );
        }
      }
      return typeDeclaration;
    }
    #endregion
  }
}
