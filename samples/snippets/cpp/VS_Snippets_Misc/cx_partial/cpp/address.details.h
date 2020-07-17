//<snippet07>
// Address.Details.h
partial ref class Address
{
private:
  Platform::String^ street_;
  Platform::String^ city_;
  Platform::String^ state_;
  Platform::String^ zip_;
  Platform::String^ country_;
  void ValidateAddress(bool normalize = true);
};
//</snippet07>