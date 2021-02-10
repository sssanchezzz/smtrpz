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
            
            motherboard.MemoryCardTypesSupported.Add("m1");
            motherboard.MemoryCardTypesSupported.Add("m2");
            motherboard.MemoryCardTypesSupported.Add("m3");

            
            Processor processor = new Processor() { Type = "p1", Performance = 300, Name = "pp1", Model = "0ek2i3" };
            Processor processor1 = new Processor() { Type = "p10", Performance = 300, Name = "pp1", Model = "0ek2i3" };
            Processor processor2 = new Processor() { Type = "p4", Performance = 300, Name = "pp1", Model = "0ek2i3" };

            MemoryCard m1 = new MemoryCard() {Name = "m1", Type = "m1"};
            MemoryCard m2 = new MemoryCard() {Name = "m25", Type = "m25"};
            MemoryCard m3 = new MemoryCard() {Name = "m3", Type = "m3"};
            MemoryCard m4 = new MemoryCard() {Name = "m110", Type = "m110"};

            List<Processor> list = new List<Processor>();
            list.Add(processor);
            list.Add(processor1);
            list.Add(processor2);
            
            List<MemoryCard> listM = new List<MemoryCard>();
            listM.Add(m1);
            listM.Add(m2);
            listM.Add(m3);
            listM.Add(m4);


            Console.WriteLine(Motherboard.FormMotherboard(motherboard, list, listM));
            Console.WriteLine(Motherboard.AddProcessorsToMotherboard(motherboard, processor));


        }
    }
}
