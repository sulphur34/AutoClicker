using System;

namespace CollectSystem
{
    public interface ICollect
    {
        event Action<float> Collected;
    }
}