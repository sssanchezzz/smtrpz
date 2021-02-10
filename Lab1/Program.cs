using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nHello World!");

            Motherboard motherboard = new Motherboard() { Model = "m1", Name = "mm1", Price = 200, Type = "A" };
            motherboard.ProcessorTypesSupported.Add("p1");

            motherboard.ProcessorTypesSupported.Add("p2");
            motherboard.ProcessorTypesSupported.Add("p3");
            motherboard.ProcessorTypesSupported.Add("p4");
            motherboard.ProcessorTypesSupported.Add("p5");

            Processor processor = new Processor() { Type = "p1", Performance = 300, Name = "pp1", Model = "0ek2i3" };
            Processor processor1 = new Processor() { Type = "p10", Performance = 300, Name = "pp1", Model = "0ek2i3" };

            Processor processor2 = new Processor() { Type = "p4", Performance = 300, Name = "pp1", Model = "0ek2i3" };

            List<Processor> list = new List<Processor>();
            list.Add(processor);
            list.Add(processor1);
            list.Add(processor2);


            Motherboard.FormMotherboard(motherboard, list);

        }
    }
}
