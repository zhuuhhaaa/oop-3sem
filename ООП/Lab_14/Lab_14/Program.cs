using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Lab_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Plant pl1 = new Plant("Rose", true);
            CustomSerializer.Serialize("binPlant.bin", pl1);
            CustomSerializer.Deserialize("binPlant.bin");
            Plant pl2 = new Plant("Glasiolus", false);
            Plant pl3 = new Plant("Sunflower", true);
            CustomSerializer.Serialize("jsonPlant.json", pl2);
            CustomSerializer.Deserialize("jsonPlant.json");
            CustomSerializer.Serialize("xmlPlant.xml", pl2);
            CustomSerializer.Deserialize("xmlPlant.xml");

            XmlSerializer serializer = new XmlSerializer(typeof(List<Plant>));
            List<Plant> lst = new List<Plant>();
            lst.Add(pl1);
            lst.Add(pl2);
            lst.Add(pl3);

            using (FileStream fs = new FileStream("Collection.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, lst);
            }
            Console.WriteLine("Коллекция");
            using(FileStream fr = new FileStream("Collection.xml", FileMode.OpenOrCreate))
            {
                List<Plant> newLst = (List<Plant>)serializer.Deserialize(fr);
                foreach(var item in newLst)
                {
                    Console.WriteLine($"Десиарелизован: {item.Name}: Живой? {item.Alive}");
                }
            }

            XmlDocument document = new XmlDocument();
            document.Load("Collection.xml");

            XmlNode xmlRoot = document.DocumentElement;
            XmlNodeList allPlants = xmlRoot.SelectNodes("*");

            foreach (XmlNode item in allPlants)
            {
                Console.WriteLine(item.InnerText);
            }

            XDocument Children = new XDocument();               
            XElement root = new XElement("Дети");               

            XElement child;                                     
            XElement name;                                     
            XAttribute year;                                   

            child = new XElement("child");
            name = new XElement("name");
            name.Value = "Юля";
            year = new XAttribute("year", "1998");
            child.Add(name);
            child.Add(year);
            root.Add(child);

            child = new XElement("child");
            name = new XElement("name");
            name.Value = "Наташа";
            year = new XAttribute("year", "1995");
            child.Add(name);
            child.Add(year);
            root.Add(child);

            Children.Add(root);
            Children.Save("Children.xml");           



            Console.WriteLine("Введите год для поиска: ");
            string yearXML = Console.ReadLine();
            var allAlbums = root.Elements("child");

            foreach (var item in allAlbums)
            {
                if (item.Attribute("year").Value == yearXML)
                {
                    Console.WriteLine(item.Value);
                }
            }

        }
    }
}
