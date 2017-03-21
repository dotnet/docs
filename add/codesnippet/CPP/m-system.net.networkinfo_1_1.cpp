   System::Net::NetworkInformation::NetworkInformationPermission^ read = gcnew System::Net::NetworkInformation::NetworkInformationPermission( System::Net::NetworkInformation::NetworkInformationAccess::Read );
   
   System::Net::NetworkInformation::NetworkInformationPermission^ copyPermission = dynamic_cast<System::Net::NetworkInformation::NetworkInformationPermission^>(read->Copy());
   