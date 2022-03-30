using System;
using System.Threading;

namespace Task2
{
    class MemoryWatcher
    {
        private decimal minLevelMemory;
        private decimal maxLevelMemory;
        private readonly int interval;
        Thread thread;

        public int Interval => interval;

        protected MemoryWatcher() { }
        public MemoryWatcher(decimal minLevelMemory, decimal maxLevelMemory)
            : this(minLevelMemory, maxLevelMemory, 1) { }
        public MemoryWatcher(decimal minLevelMemory, decimal maxLevelMemory, int interval)
        {
            this.maxLevelMemory = maxLevelMemory;
            this.minLevelMemory = minLevelMemory;
            this.interval = interval;
            this.thread = null;
        }
        public virtual void Start()
        {
            if (thread == null)
            {
                thread = new Thread(WatchingMemory);
                thread.Start();
            }
        }
        public virtual void Abort()
        {
            if (thread != null)
            {
                thread.Abort();
                thread = null;
            }
        }
        public virtual void WatchingMemory()
        {
            while (true)
            {
                decimal totalMemory = GC.GetTotalMemory(false);
                if (totalMemory >= minLevelMemory && totalMemory < maxLevelMemory)
                {
                    Console.WriteLine($"Attention! Reached level of {totalMemory}B.");
                }
                else if (totalMemory >= maxLevelMemory)
                {
                    Console.WriteLine($"Attention! The maximum allowable memory level has been exceeded.");
                }
                Thread.Sleep(interval);
            }
        }
    }
}
