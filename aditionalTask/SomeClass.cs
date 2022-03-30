using System;

namespace aditionalTask
{
    public class SomeClass : IDisposable
    {
        byte[] array;
        private bool disposed;

        public SomeClass()
        {
            this.array = new byte[1000000];
            disposed = false;
        }

        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!disposed)
                {
                    Console.WriteLine("disposing...");
                    this.disposed = true;
                }
            }
        }
        ~SomeClass()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
