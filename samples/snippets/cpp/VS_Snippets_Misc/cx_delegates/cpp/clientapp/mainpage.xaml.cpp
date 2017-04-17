//
// MainPage.xaml.cpp
// Implementation of the MainPage class.
//

#include "pch.h"
#include "MainPage.xaml.h"
#include <algorithm>

using namespace ClientApp;

using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;

using namespace DelegatesEvents;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

MainPage::MainPage()
{
    InitializeComponent();
}

/// <summary>
/// Invoked when this page is about to be displayed in a Frame.
/// </summary>
/// <param name="e">Event data that describes how this page was reached.  The Parameter
/// property is typically used to configure the page.</param>
void MainPage::OnNavigatedTo(NavigationEventArgs^ e)
{
    //<snippet118>
    //Client app
    obj = ref new DelegatesEvents::Class1();

    CustomStringDelegate^ myDel = ref new CustomStringDelegate([] (ContactInfo^ c)
    {
        return c->Salutation + " " + c->LastName;
    });
    IVector<String^>^ mycontacts = obj->GetCustomContactStrings(myDel);
    std::for_each(begin(mycontacts), end(mycontacts), [this] (String^ s)
    {
        this->ContactString->Text += s + " ";
    });
    //</snippet118>


    ContactInfo^ ci = ref new ContactInfo("Ms.", "FrankLynn", "Jones", "1234 Nowhere Mile");
    String^ s = ref new String(L"My name is ");

    CustomGreeting^ sd = ref new CustomGreeting([&s] (ContactInfo^ c)
    {
        return s + " " + c->FirstName + c->LastName;
    });

    obj->StoredDelegate = sd;

    String^ s2 = obj->StoredDelegate(ci);

}


void ClientApp::MainPage::Button_Click_1(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
    ContactString->Text = obj->CreateGreeting();
}
