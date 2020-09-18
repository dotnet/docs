using System;

namespace Samples
{
    public interface Book   // Violates this rule
    {
        string Title
        {
            get;
        }

        void Read();        
    }
}