using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Console.WriteLine("\nHello World!");
            //
            // Motherboard motherboard = new Motherboard() { Model = "m1", Name = "mm1", Price = 200, Type = MotherboardTypes.MBT200};
            // motherboard.ProcessorTypesSupported.Add(ProcessorTypes.PT1);
            // motherboard.ProcessorTypesSupported.Add(ProcessorTypes.PT2);
            // motherboard.ProcessorTypesSupported.Add(ProcessorTypes.PT4);
            //
            // motherboard.MemoryCardTypesSupported.Add(MemoryCardTypes.MCT1);
            // motherboard.MemoryCardTypesSupported.Add(MemoryCardTypes.MCT3);
            // motherboard.MemoryCardTypesSupported.Add(MemoryCardTypes.MCT5);
            //
            // Processor processor = new Processor() { Type = ProcessorTypes.PT1, NumberOfCores = 8, Name = "pp1", Model = "0ek2i3" };
            // Processor processor1 = new Processor() { Type = ProcessorTypes.PT2, NumberOfCores = 4, Name = "pp1", Model = "0ek2i3" };
            // Processor processor2 = new Processor() { Type = ProcessorTypes.PT3, NumberOfCores = 16, Name = "pp1", Model = "0ek2i3" };
            //
            // MemoryCard m1 = new MemoryCard() {Name = "m1", Type = MemoryCardTypes.MCT1};
            // MemoryCard m2 = new MemoryCard() {Name = "m25", Type = MemoryCardTypes.MCT5};
            // MemoryCard m3 = new MemoryCard() {Name = "m3", Type = MemoryCardTypes.MCT6};
            // MemoryCard m4 = new MemoryCard() {Name = "m110", Type = MemoryCardTypes.MCT4};
            //
            // List<Processor> list = new List<Processor>();
            // list.Add(processor);
            // list.Add(processor1);
            // list.Add(processor2);
            //
            // List<MemoryCard> listM = new List<MemoryCard>();
            // listM.Add(m1);
            // listM.Add(m2);
            // listM.Add(m3);
            // listM.Add(m4);
            //
            // foreach (var p in motherboard.ProcessorTypesSupported)
            // {
            //     Console.WriteLine(p);
            // }
            //
            // Console.WriteLine(Motherboard.FormMotherboard(motherboard, list, listM));
            // Console.WriteLine(Motherboard.AddProcessorsToMotherboard(motherboard, processor2));

            TestData data = new TestData();
            Menu.ShowMenu();
            
            
            
        }
    }

}
