using System.Collections.Generic;

namespace Runtime.Core.Ticking
{
    public class TickManager
    {
        private readonly List<ITickable> _tickables = new();

        public void Register(ITickable tickable)
        {
            if (!_tickables.Contains(tickable))
                _tickables.Add(tickable);
        }

        public void Unregister(ITickable tickable)
        {
            _tickables.Remove(tickable);
        }

        public void Tick()
        {
            for (int i = 0; i < _tickables.Count; i++)
                _tickables[i].Tick();
        }
    }
}