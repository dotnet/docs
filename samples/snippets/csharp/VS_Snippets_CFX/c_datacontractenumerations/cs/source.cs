//<snippet0>
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
//</snippet0>

namespace ServiceModel.Samples
{
    //<snippet1>
    [DataContract]
    public class Car
    {
        [DataMember]
        public string model;
        [DataMember]
        public CarConditionEnum condition;
    }

    [DataContract(Name = "CarCondition")]
    public enum CarConditionEnum
    {
        [EnumMember]
        New,
        [EnumMember]
        Used,
        [EnumMember]
        Rental,
        Broken,
        Stolen
    }
    //</snippet1>

    //<snippet2>
    [DataContract(Name = "CarCondition")]
    public enum CarConditionWithNumbers
    {
        [EnumMember]
        New = 10,
        [EnumMember]
        Used = 20,
        [EnumMember]
        Rental = 30,
    }
    //</snippet2>

    //<snippet3>
    [DataContract(Name = "CarCondition")]
    public enum CarConditionWithDifferentNames
    {
        [EnumMember(Value = "New")]
        BrandNew,
        [EnumMember(Value = "Used")]
        PreviouslyOwned,
        [EnumMember]
        Rental
    }
    //</snippet3>

    //<snippet4>
    [DataContract][Flags]
    public enum CarFeatures
    {
        None = 0,
        [EnumMember]
        AirConditioner = 1,
        [EnumMember]
        AutomaticTransmission = 2,
        [EnumMember]
        PowerDoors = 4,
        AlloyWheels = 8,
        DeluxePackage = AirConditioner | AutomaticTransmission | PowerDoors | AlloyWheels,
        [EnumMember]
        CDPlayer = 16,
        [EnumMember]
        TapePlayer = 32,
        MusicPackage = CDPlayer | TapePlayer,
        [EnumMember]
        Everything = DeluxePackage | MusicPackage
    }
    //</snippet4>

    public class FlagsExample
    {
        //<snippet5>
        CarFeatures cf1 = CarFeatures.AutomaticTransmission;
        //Serialized as <cf1>AutomaticTransmission</cf1>

        CarFeatures cf2 = (CarFeatures)5;
        //Serialized as <cf2>AirConditioner PowerDoors</cf2> since 5=1+4

        CarFeatures cf3 = CarFeatures.MusicPackage;
        //Serialized as <cf3>CDPlayer TapePlayer</cf3> since MusicPackage itself is not an EnumMember

        CarFeatures cf4 = CarFeatures.Everything;
        //Serialized as <cf4>Everything</cf4> since Everything itself is an EnumMember

        CarFeatures cf5 = CarFeatures.DeluxePackage;
        //Throws a SerializationException since neither DeluxePackage nor AlloyWheels are EnumMembers

        CarFeatures cf6 = CarFeatures.None;
        //Serialized as the empty list <cf6></cf6> since there is no EnumMember mapped to zero
        //</snippet5>
    }

    //<snippet6>
    public enum CarCondition
    {
        New,
        Used,
        Rental,
        [NonSerialized]
        Lost
    }
    //</snippet6>
}
