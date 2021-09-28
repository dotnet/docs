#pragma once
#include <Windows.h>

namespace cx_properties
{

    public ref class Class1 sealed
    {
    public:
        Class1();
    };

    //<snippet01>
    public ref class Prescription sealed
    {
    private:
        Platform::String^ m_doctor;
        int quantity;
    public:
		Prescription(Platform::String^ name, Platform::String^ d) : m_doctor(d)
        {
            // Trivial properties can't be initialized in member list.
            Name = name;
        }

        // Trivial property
        property Platform::String^ Name;

        // Read-only property
        property Platform::String^ Doctor
        {
            Platform::String^ get() { return m_doctor; }
        }

        // Read-write property
        property int Quantity
        {
            int get() { return quantity; }
            void set(int value)
            {
                if (value <= 0) 
                { 
                    throw ref new Platform::InvalidArgumentException(); 
                }
                quantity = value;
            }
        }
    };
    
	public ref class PropertyConsumer sealed
	{
	private:
		void GetPrescriptions()
		{
			Prescription^ p = ref new Prescription("Louis", "Dr. Who");
			p->Quantity = 5;
			Platform::String^ s = p->Doctor;
			int32 i = p->Quantity;

			Prescription p2("JR", "Dr. Dat");
			p2.Quantity = 10;
		}
	};
	//</snippet01>
}