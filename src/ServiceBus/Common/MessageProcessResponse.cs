using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceBus.Common
{
    public enum MessageProcessResponse
    {
        Complete,
        Abandon,
        Dead
    }
}
