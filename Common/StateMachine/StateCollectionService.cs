using System;
using System.Collections.Generic;

namespace Assets.Common.StateMachine
{
    public class StateCollectionService: IStateCollectionService
    {
        private readonly Dictionary<Type, IState> _states = new Dictionary<Type, IState>();

        public void Add<T>(IState state) where T : IState
        {
            if (_states.ContainsKey(typeof(T)))
                throw new ArgumentException($"{GetType()} state {state.GetType()} already added");
            
            _states.Add(typeof(T), state);
        }

        public T Get<T>() where T : class, IState
        {
            if (_states.ContainsKey(typeof(T)))
                return _states[typeof(T)] as T;

            throw new ArgumentException($"{GetType()} state {typeof(T)} not found");
        }
    }
}