using System;

namespace Contracts
{
    /// <summary>
    /// This is a basic class than can be used in both synchronous and asynchronous mode
    /// </summary>
    /// <typeparam name="T">Return type parameter</typeparam>
    public class FutureResult<T> : IValue
    {
        public delegate void ResultHandler(T result);

        private bool _valueSet;

        private T _value;

        public event ResultHandler OnResult;
        
        public Action<T> HandleResult
        {
            get
            {
                return result => { if (OnResult != null) OnResult(result); };
            }
        }

        public static implicit operator FutureResult<T>(T value)
        {
            return new FutureResult<T> {_value = value, _valueSet = true};
        }
       
        public void WhenReady(Action<T> action)
        {
            if (_valueSet)
            {
                action(_value);
            }
            else
            {
                OnResult = result => action(result);            
            }            
        }

        public object Value
        {
            get
            {
                if (_valueSet)
                {
                    return _value;
                }
                else
                {
                    throw new InvalidOperationException("Cannot retrieve value in async mode");
                }
            }
        }
    }

    public interface IValue
    {
        object Value { get; }
    }
}
