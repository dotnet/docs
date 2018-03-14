//<Snippet1>
using System;
using System.Configuration;
using System.Web.Configuration;

namespace Samples.AspNet
{
  class lowerCaseDescContext : System.ComponentModel.ITypeDescriptorContext
  {

    #region ITypeDescriptorContext Members

    public System.ComponentModel.IContainer Container
    {
      get { throw new Exception("The method or operation is not implemented."); }
    }

    public object Instance
    {
      get { throw new Exception("The method or operation is not implemented."); }
    }

    public void OnComponentChanged()
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public bool OnComponentChanging()
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public System.ComponentModel.PropertyDescriptor PropertyDescriptor
    {
      get { throw new Exception("The method or operation is not implemented."); }
    }

    #endregion

    #region IServiceProvider Members

    public object GetService(Type serviceType)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    #endregion
}

  class UsingLowerCaseStringConverter
  {
    static void Main(string[] args)
    {
      // Display title.
      Console.WriteLine("Using LowerCaseStringConverter");
      Console.WriteLine();
      
      try
      {
        // Create string.
        object testStrVal = "TESTVALUE";
        object resultStrVal;

        //<Snippet2>
        // Create LowerCaseStringConverter object.
        LowerCaseStringConverter myLCStrConverter = 
          new LowerCaseStringConverter();

        // Create lowerCaseDescContext object.
        lowerCaseDescContext ctx = new lowerCaseDescContext();

        // Create CultureInfo object.
        System.Globalization.CultureInfo ci = 
          new System.Globalization.CultureInfo(1033);
        //</Snippet2>
        
        //<Snippet3>
        // CanConvertFrom method.
        Console.WriteLine("CanConvertFrom: {0}",
          myLCStrConverter.CanConvertFrom(ctx, testStrVal.GetType()));
        //</Snippet3>

        //<Snippet4>
        // CanConvertTo method.
        Console.WriteLine("CanConvertTo: {0}",
          myLCStrConverter.CanConvertTo(ctx, testStrVal.GetType()));
        //</Snippet4>

         //<Snippet5>
        // ConvertFrom method.
        Console.WriteLine("Original Value: {0}",
          testStrVal.ToString());
        resultStrVal = myLCStrConverter.ConvertFrom(ctx, ci, testStrVal);
        Console.WriteLine("ConvertFrom result: {0}", 
          resultStrVal.ToString());
        //</Snippet5>

        //<Snippet6>
        // ConvertTo method.
        Console.WriteLine("Original Value: {0}",
          testStrVal.ToString());
        resultStrVal = myLCStrConverter.ConvertTo
          (ctx,ci,testStrVal, testStrVal.GetType());
        Console.WriteLine("ConvertTo result: {0}",
          resultStrVal.ToString());
        //</Snippet6>
      }

      catch (Exception e)
      {
        // Unknown error.
        Console.WriteLine(e.ToString());
      }

      // Display and wait.
      Console.ReadLine();
    }
  }
}
// </Snippet1>