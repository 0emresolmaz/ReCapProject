using System;
using System.IO;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            string projectDir =
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\.."));

            string path = @"\WebAPI\Resource\Images";

            Console.WriteLine(projectDir+path);


        }

    }
}
