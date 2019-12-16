using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(950);

            string sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output"); ;

            ImageProcess imageProcess = new ImageProcess();

            imageProcess.Clean(destinationPath);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            Task.Run( () => imageProcess.ResizeImagesAsync(sourcePath, destinationPath, 2.0)).Wait();
            sw.Stop();

            Console.WriteLine();
            Console.WriteLine($"花費時間: {sw.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }
    }
}
