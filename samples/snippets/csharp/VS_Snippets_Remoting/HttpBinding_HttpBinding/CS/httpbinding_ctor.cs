//  System.Web.Services.Description.HttpBinding.HttpBinding()
//  System.Web.Services.Description.HttpBinding.Namespace
//  System.Web.Services.Description.HttpAddressBinding.HttpAddressBinding()

/*  The following program demonstrates the constructor, field 'Namespace' of
    class 'HttpBinding' and constructor of class 'HttpAddressBinding'. This program writes all 'HttpPost' binding      related information to the input wsdl file and genrates an output file which is later on compiled using wsdl       tool.
*/
using System;
using System.Web.Services.Description;
using System.Collections;
using System.Xml;

class MyHttpBindingClass
{
  public static void Main()
   {
      ServiceDescription myDescription = ServiceDescription.Read("HttpBinding_ctor_Input_CS.wsdl");
// <Snippet1>       
// <Snippet2>    
      // Create 'Binding' object.
      Binding myBinding = new Binding();
      myBinding.Name = "MyHttpBindingServiceHttpPost";
      XmlQualifiedName qualifiedName = new XmlQualifiedName("s0:MyHttpBindingServiceHttpPost");
      myBinding.Type = qualifiedName;
      // Create 'HttpBinding' object.
      HttpBinding myHttpBinding = new HttpBinding();
      myHttpBinding.Verb = "POST";
      Console.WriteLine("HttpBinding Namespace : "+HttpBinding.Namespace);
// </Snippet2> 
      // Add 'HttpBinding' to 'Binding'.
      myBinding.Extensions.Add(myHttpBinding);
// </Snippet1>
      // Create 'OperationBinding' object.
      OperationBinding myOperationBinding = new OperationBinding();
      myOperationBinding.Name = "AddNumbers";
      HttpOperationBinding myOperation = new HttpOperationBinding();
      myOperation.Location = "/AddNumbers";
      // Add 'HttpOperationBinding' to 'OperationBinding'.
      myOperationBinding.Extensions.Add(myOperation);
      // Create 'InputBinding' object.
      InputBinding myInput = new InputBinding();
      MimeContentBinding postMimeContentbinding = new MimeContentBinding();
      postMimeContentbinding.Type = "application/x-www-form-urlencoded";
      myInput.Extensions.Add(postMimeContentbinding);
      // Add 'InputBinding' to 'OperationBinding'.
      myOperationBinding.Input = myInput;
      // Create 'OutputBinding' object.
      OutputBinding myOutput = new OutputBinding();
      MimeXmlBinding postMimeXmlbinding = new MimeXmlBinding();
      postMimeXmlbinding .Part = "Body";
      myOutput.Extensions.Add(postMimeXmlbinding);
      // Add 'OutPutBinding' to 'OperationBinding'.
      myOperationBinding.Output = myOutput; 
      // Add 'OperationBinding' to 'Binding'.
      myBinding.Operations.Add(myOperationBinding);
      // Add 'Binding' to 'BindingCollection' of 'ServiceDescription'.
      myDescription.Bindings.Add(myBinding);
// <Snippet3>
     // Create a 'Port' object.
      Port postPort = new Port();
      postPort.Name = "MyHttpBindingServiceHttpPost";
      postPort.Binding = new XmlQualifiedName("s0:MyHttpBindingServiceHttpPost");
      // Create 'HttpAddressBinding' object.
      HttpAddressBinding postAddressBinding = new HttpAddressBinding();
      postAddressBinding.Location = "http://localhost/HttpBinding_ctor/HttpBinding_ctor_Service.cs.asmx";
      // Add 'HttpAddressBinding' to 'Port'.
      postPort.Extensions.Add(postAddressBinding);
// </Snippet3>
      // Add 'Port' to 'PortCollection' of 'ServiceDescription'.
      myDescription.Services[0].Ports.Add(postPort);
      // Write 'ServiceDescription' as a WSDL file.
      myDescription.Write("HttpBinding_ctor_Output_CS.wsdl");
      Console.WriteLine("WSDL file with name 'HttpBinding_ctor_Output_CS.wsdl' file created Successfully");
    }
}
