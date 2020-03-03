

// <snippet1>
/// <summary>
/// The following class represents simple functionality of the trapezoid.
/// </summary>
using namespace System;

public ref class MathTrapezoidSample
{
private:
   double m_longBase;
   double m_shortBase;
   double m_leftLeg;
   double m_rightLeg;

public:
   MathTrapezoidSample( double longbase, double shortbase, double leftLeg, double rightLeg )
   {
      m_longBase = Math::Abs( longbase );
      m_shortBase = Math::Abs( shortbase );
      m_leftLeg = Math::Abs( leftLeg );
      m_rightLeg = Math::Abs( rightLeg );
   }


private:
   double GetRightSmallBase()
   {
      return (Math::Pow( m_rightLeg, 2.0 ) - Math::Pow( m_leftLeg, 2.0 ) + Math::Pow( m_longBase, 2.0 ) + Math::Pow( m_shortBase, 2.0 ) - 2 * m_shortBase * m_longBase) / (2 * (m_longBase - m_shortBase));
   }


public:
   double GetHeight()
   {
      double x = GetRightSmallBase();
      return Math::Sqrt( Math::Pow( m_rightLeg, 2.0 ) - Math::Pow( x, 2.0 ) );
   }

   double GetSquare()
   {
      return GetHeight() * m_longBase / 2.0;
   }

   double GetLeftBaseRadianAngle()
   {
      double sinX = GetHeight() / m_leftLeg;
      return Math::Round( Math::Asin( sinX ), 2 );
   }

   double GetRightBaseRadianAngle()
   {
      double x = GetRightSmallBase();
      double cosX = (Math::Pow( m_rightLeg, 2.0 ) + Math::Pow( x, 2.0 ) - Math::Pow( GetHeight(), 2.0 )) / (2 * x * m_rightLeg);
      return Math::Round( Math::Acos( cosX ), 2 );
   }

   double GetLeftBaseDegreeAngle()
   {
      double x = GetLeftBaseRadianAngle() * 180 / Math::PI;
      return Math::Round( x, 2 );
   }

   double GetRightBaseDegreeAngle()
   {
      double x = GetRightBaseRadianAngle() * 180 / Math::PI;
      return Math::Round( x, 2 );
   }

};

int main()
{
   MathTrapezoidSample^ trpz = gcnew MathTrapezoidSample( 20.0,10.0,8.0,6.0 );
   Console::WriteLine( "The trapezoid's bases are 20.0 and 10.0, the trapezoid's legs are 8.0 and 6.0" );
   double h = trpz->GetHeight();
   Console::WriteLine( "Trapezoid height is: {0}", h.ToString() );
   double dxR = trpz->GetLeftBaseRadianAngle();
   Console::WriteLine( "Trapezoid left base angle is: {0} Radians", dxR.ToString() );
   double dyR = trpz->GetRightBaseRadianAngle();
   Console::WriteLine( "Trapezoid right base angle is: {0} Radians", dyR.ToString() );
   double dxD = trpz->GetLeftBaseDegreeAngle();
   Console::WriteLine( "Trapezoid left base angle is: {0} Degrees", dxD.ToString() );
   double dyD = trpz->GetRightBaseDegreeAngle();
   Console::WriteLine( "Trapezoid left base angle is: {0} Degrees", dyD.ToString() );
}
// </snippet1>
