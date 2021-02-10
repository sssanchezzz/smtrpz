using System;
using System.Collections.Generic;

namespace Lab1
{
    public class Base<T>
    {
        private Guid Id;
        public string Name;
        public string Model;
        public int Price;

        public static List<T> Items = new List<T>();

        public Base()
        {
            Id = new Guid();
        }
        public override string ToString()
        {
            return $"Name: {Name}, Model: {Model}";
        }

    }
}
