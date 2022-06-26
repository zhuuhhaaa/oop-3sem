using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Lab_14
{
    [DataContract]
    [Serializable]
    public class Plant
    {
        public Plant() { }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool Alive { get; set; }
        public Plant(string name, bool alive)
        {
            Name = name;
            Alive = alive;
        }

        public override string ToString()
        {
            return $"Цветок {Name}";
        }
    }
}
