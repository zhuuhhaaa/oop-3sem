using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Serialization;

namespace Lab_14
{
    public class CustomSerializer
    {
        public static void Deserialize(string fname)
        {
            string[] format = fname.Split('.');
            switch (format[1])
            {
                case "bin":
                    {
                        BinaryFormatter binarForm = new BinaryFormatter();
                        using (FileStream fr = new FileStream(fname, FileMode.Open))
                        {
                            Plant newPl = (Plant)binarForm.Deserialize(fr);
                            Console.WriteLine($"Десиарелизован: {newPl.Name}: Живой? {newPl.Alive}");
                        }
                        break;
                    }
                case "json":
                    {
                        DataContractJsonSerializer jsonForm = new DataContractJsonSerializer(typeof(Plant));
                        using (FileStream fr = new FileStream(fname, FileMode.OpenOrCreate))
                        {
                            Plant newPl = (Plant)jsonForm.ReadObject(fr);
                            Console.WriteLine($"Десиарелизован: {newPl.Name}: Живой? {newPl.Alive}");
                        }
                        break;
                    }
                case "xml":
                    {
                        XmlSerializer xmlSer = new XmlSerializer(typeof(Plant));
                        using (FileStream fr = new FileStream(fname, FileMode.OpenOrCreate))
                        {
                            Plant newPl = (Plant)xmlSer.Deserialize(fr);
                            Console.WriteLine($"Десиарелизован: {newPl.Name}: Живой? {newPl.Alive}");
                        }
                        break;
                    }

            }

        }

        public static void Serialize(string fname, Plant name)
        {
            string[] format = fname.Split('.');
            switch(format[1])
            {
                case "bin":
                    {
                        BinaryFormatter binarForm = new BinaryFormatter();
                        using (FileStream fs = new FileStream(fname, FileMode.OpenOrCreate))
                        {
                            binarForm.Serialize(fs, name);
                        }
                        break;
                    }
                case "json":
                    {
                        DataContractJsonSerializer jsonForm = new DataContractJsonSerializer(typeof(Plant));
                        using(FileStream fs = new FileStream(fname, FileMode.OpenOrCreate))
                        {
                            jsonForm.WriteObject(fs, name);
                        }
                        break;
                    }
                case "xml":
                    {
                        XmlSerializer xmlSer = new XmlSerializer(typeof(Plant));
                        using(FileStream fs = new FileStream(fname, FileMode.OpenOrCreate))
                        {
                            xmlSer.Serialize(fs, name);
                        }
                        break;
                    }
            }

        }
    }
}
