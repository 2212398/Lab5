using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bai2
{
    internal class Xml
    {

        public static void Main(string[] args)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load("C:\\Users\\PC602\\Downloads\\Lab5-main\\Lab5-main\\2212398_Lab5\\Bai2\\books.xml");
            var nodelist = xmlDoc.DocumentElement.SelectNodes("/catalog/book");
            foreach (XmlNode node in nodelist)
            {
                var isbn = node.Attributes["ISBN"].Value;
                var title = node.SelectSingleNode("title").InnerText;
                var price = node.SelectSingleNode("price").InnerText;
                var firstname = node.SelectSingleNode("author/first-name").InnerText;
                var lastname = node.SelectSingleNode("author/last-name").InnerText;
                Console.WriteLine("{0,-15}{1,-50}{2,-15}{3,-15}{4,6}", isbn, title, firstname, lastname, price);
            }
        }
    }
}
