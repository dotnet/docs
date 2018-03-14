
using namespace System;

//<snippet1>
public ref struct Complex
{
public:
   double m_Re;
   double m_Im;
   virtual bool Equals( Object^ ob ) override
   {
      if ( dynamic_cast<Complex^>(ob) )
      {
         Complex^ c = dynamic_cast<Complex^>(ob);
         return m_Re == c->m_Re && m_Im == c->m_Im;
      }
      else
      {
         return false;
      }
   }

   virtual int GetHashCode() override
   {
      return m_Re.GetHashCode() ^ m_Im.GetHashCode();
   }
};
//</snippet1>
