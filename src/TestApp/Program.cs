using System.Threading;
using Darwin;

namespace TestApp
{
    public static class Program
    {
        private static readonly AutoResetEvent WindowClosed = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            NSRunLoop.MainRunLoop.BeginInvokeOnMainThread(ShowMainWindow);

            WindowClosed.WaitOne();
        }

        private static void ShowMainWindow()
        {
            var windowController = new MyWindowController(null, "My Window Title", "https://www.google.co.uk");
            windowController.Run();

            WindowClosed.Set();
        }
    }
}
