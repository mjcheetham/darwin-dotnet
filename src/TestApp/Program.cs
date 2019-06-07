using Darwin;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var frame = new CGRect(250, 250, 400, 600);
            using (var view = new NSView(frame))
            {
                ;
            }
        }
    }
}
