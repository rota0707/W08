using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace W08
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            bool isWriten =WriteToFile();
            if (isWriten)
            {
              ReadFromFile();
            }
            else
            {
                System.Console.WriteLine("Write data to file occur an error. Please try again !");
            }

            Console.ReadKey();
        }
        class Book
        {
            public string Title { get; set; }
            public float Price { get; set; }
        }
        public static bool WriteToFile()
        {
            Book book = new Book();
            book.Title = "Đắc Nhân Tâm";
            book.Price = 123.5f;
            try
            {
                XDocument xDoc = XDocument.Load("books.xml");
                XElement newBook = new XElement("book",
                new XElement("title", book.Title),
                new XElement("price", book.Price.ToString()));

                xDoc.Element("bookstore").Add(newBook);
                xDoc.Save("books.xml");
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
                return false;
            }
        }
        public static void ReadFromFile()
        {
            XmlTextReader reader = new XmlTextReader("books.xml");
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        Console.Write("<" + reader.Name);
                        Console.WriteLine(">");
                        break;
                    case XmlNodeType.Text:
                        Console.WriteLine(reader.Value);
                        break;
                    case XmlNodeType.EndElement:
                        Console.Write("</" + reader.Name);
                        Console.WriteLine(">");
                        break;
                }
            }
        }

    }
   

}

