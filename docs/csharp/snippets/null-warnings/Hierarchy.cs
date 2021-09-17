using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace null_warnings
{
    // <Hierarchy>
    public class B
    {
        public virtual string GetMessage(int id) => string.Empty;
    }
    public class D : B
    {
        public override string? GetMessage(int id) => default;
    }
    // </Hierarchy>
}
