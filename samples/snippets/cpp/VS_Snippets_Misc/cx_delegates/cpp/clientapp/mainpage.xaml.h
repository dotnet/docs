//
// MainPage.xaml.h
// Declaration of the MainPage class.
//

#pragma once

#include "pch.h"
#include "MainPage.g.h"

namespace ClientApp
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public ref class MainPage sealed
	{
	public:
		MainPage();

	protected:
		virtual void OnNavigatedTo(Windows::UI::Xaml::Navigation::NavigationEventArgs^ e) override;
    private:
        void Button_Click_1(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
        DelegatesEvents::Class1^ obj;
    };

    public ref class TestRefClass sealed
	{
	public:
        TestRefClass(){}

	    property int Num;
	};

     public value class TestValueClass sealed
	{
    public:
		    int Num;
	};

}
