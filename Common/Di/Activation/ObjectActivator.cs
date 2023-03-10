using System;

namespace Common.Di.Activation
{
    public class ObjectActivator
    {
        public object Activate(Type objectType, object[] dependencies) =>
            dependencies.Length > 0
                ? Activator.CreateInstance(objectType, dependencies)
                : Activator.CreateInstance(objectType);
    }
}