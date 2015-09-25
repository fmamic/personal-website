using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicesLibrary.Connection
{
    public interface IInterface
    {
        void Send();
        void LoadTokens();
    }
}
