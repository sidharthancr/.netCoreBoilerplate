using ServiceBus.Common;
using System;

namespace ServiceBus.Queue
{
    public interface IAzureQueueReceiver<T>
    {
        void Receive(
            Func<T, MessageProcessResponse> onProcess,
            Action<Exception> onError,
            Action onWait);
    }
}
