using System;
using System.Threading;

namespace Darwin
{
    public abstract class NSDispatcher : NSObject
    {
        // TODO: get the 'Execute' method to be invoked.. somehow
        public static IntPtr SelectorHandle => IntPtr.Zero;

        public abstract void Execute();
    }

    public class NSActionDispatcher : NSDispatcher
    {
        private readonly Action _action;

        public NSActionDispatcher(Action action)
        {
            _action = action;
        }

        public override void Execute()
        {
            _action();
        }
    }

    internal class NSSynchronizationContextDispatcher : NSDispatcher
    {
        private readonly SendOrPostCallback _cb;
        private readonly object _state;

        public NSSynchronizationContextDispatcher(SendOrPostCallback cb, object state)
        {
            _cb = cb;
            _state = state;
        }

        public override void Execute()
        {
            _cb(_state);
        }
    }
}
