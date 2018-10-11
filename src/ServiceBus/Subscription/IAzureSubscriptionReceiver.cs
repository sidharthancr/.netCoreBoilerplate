using System;
using ServiceBus.Common;

namespace ServiceBus.Subscription
{
    public interface IAzureSubscriptionReceiver<T>
    {
        void Receive(
            Func<T, MessageProcessResponse> onProcess, 
            Action<Exception> onError, 
            Action onWait);
    }
}