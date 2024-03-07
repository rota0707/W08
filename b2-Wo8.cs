using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace W08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Xin moi banj nhap duong dan file");
            string path = Console.ReadLine();
            Console.WriteLine($"File path: {path}");
            ReadTextFileExample readfile = new ReadTextFileExample();
            readfile.SumValueinFile(path);


            Console.ReadKey();
        }
      
    }
    class ReadTextFileExample
    {
       public void SumValueinFile(string filePath)
        {
            try
            {
                // kiem tra file ton taij chua
                FileInfo file = new FileInfo(filePath);
                if (!file.Exists)
                {
                    throw new FileNotFoundException();
                }
                // doc nd trong file
                StreamReader streamReader = new StreamReader(filePath);
                string line = "";
                int sum = 0;
                string lines = streamReader.ReadLine();
                while (lines != null)
                {
                    Console.WriteLine(line);
                    sum += Int32.Parse(line);

                }
                streamReader.Close();
                Console.WriteLine($"Tong : {sum}");

            }
            catch (System.Exception)
            {
                Console.WriteLine("Khong tim dk file or file k ton tai.");
            }
        }
    }
}
