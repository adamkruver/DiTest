using System;

namespace Common.Di.Activation
{
    public interface IActivateStrategy
    {
        object Activate(Type type);
    }
}