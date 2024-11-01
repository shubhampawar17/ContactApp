using ContactApp.Controller;
using ContactApp.PresentationLayer;
using ContactApp.Service;

namespace ContactApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var presentation = new Presentation();
            presentation.Start();
        }
    }
}
