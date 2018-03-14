#pragma once

namespace cx_attributes
{

    //<snippet01>
    [Windows::Foundation::Metadata::WebHostHidden]
    public ref class MyClass : Windows::UI::Xaml::DependencyObject {};
    //</snippet01>

    //<snippet02>
    [Windows::Foundation::Metadata::WebHostHiddenAttribute]
    public ref class MyCustomAttribute sealed : Platform::Metadata::Attribute {
	public:
		int Num;
		Platform::String^ Msg;		
	};

    [MyCustomAttribute(Num=5, Msg="Hello")]
    public ref class Class1 sealed
    {
    public:
        Class1();
    };
   //</snippet02>

}