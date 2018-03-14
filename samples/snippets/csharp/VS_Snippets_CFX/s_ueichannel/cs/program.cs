using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace cs
{

    abstract class newChannel
    {
        public virtual T GetProperty<T>()
        {
            IChannel innerChannel = this.InnerChannel;
            if (innerChannel != null)
                return innerChannel.GetProperty<T>();
            return null;
        }
    }

    class Program
    {



        static void Main(string[] args)

        {
        }
    }
}
