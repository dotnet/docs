[System::Xml::Serialization::XmlRootAttribute(Namespace="http://tempuri.org/",IsNullable=true)]
public ref class UserName
{
public:
   String^ Name;
   String^ Domain;
};

public ref class MyUser: public System::Web::Services::Protocols::HttpPostClientProtocol
{
public:
   MyUser()
   {
      this->Url = "http://www.contoso.com/username.asmx";
   }

   [System::Web::Services::Protocols::HttpMethodAttribute(System::Web::Services::Protocols::XmlReturnReader::typeid,System::Web::Services::Protocols::HtmlFormParameterWriter::typeid)]
   UserName^ GetUserName()
   {
      return (dynamic_cast<UserName^>(this->Invoke( "GetUserName", (String::Concat( this->Url, "/GetUserName" )), gcnew array<Object^>(0) )));
   }

   System::IAsyncResult^ BeginGetUserName( System::AsyncCallback^ callback, Object^ asyncState )
   {
      return this->BeginInvoke( "GetUserName", (String::Concat( this->Url, "/GetUserName" )), gcnew array<Object^>(0), callback, asyncState );
   }

   UserName^ EndGetUserName( System::IAsyncResult^ asyncResult )
   {
      return (dynamic_cast<UserName^>(this->EndInvoke( asyncResult )));
   }
};