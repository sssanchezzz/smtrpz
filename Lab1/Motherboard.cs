using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab1
{
    public class Motherboard : Base<Motherboard>
    {
        public List<string> ProcessorTypesSupported { get; }
        public List<string> MemoryCardTypesSupported { get; }
        public string Type { get; set; }


        public Motherboard()
        {
            MemoryCardTypesSupported = new List<string>();
            ProcessorTypesSupported = new List<string>();
        }
        public static bool FormMotherboard(Motherboard m, List<Processor> processors
            //, List<MemoryCard> cards
            )
        {
            //var processorsList = processors.Select(p => p.Type);
            //var inters = m.ProcessorTypesSupported.Intersect(processorsList);
            var inter = processors
                .Select(p => p.Type)
                .Where(pr => m.ProcessorTypesSupported
                    .Any(i => pr == i));

            foreach (var s in m.ProcessorTypesSupported)
                Console.WriteLine(s);

            //foreach (var s in processorsList)
            //    Console.WriteLine(s);
            //Console.WriteLine("intersection");

            //foreach (var s in inter)
            //    Console.WriteLine(s);
            Console.WriteLine("linq");
            foreach (var s in inter)
                Console.WriteLine(s);

            return true;

        }
    }
}
