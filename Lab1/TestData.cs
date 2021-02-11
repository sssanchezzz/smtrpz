using System;
namespace Lab1
{
    public class TestData
    {
        public TestData()
        {
            SystemUnitCase u1 = new SystemUnitCase()
            {
                Model = "SysUniCa2000", Name = "SystemUnitCase", Price = 2000,
                PowerSupplyDimensions = new Dimensions(200, 100, 50)
            };
            SystemUnitCase u2 = new SystemUnitCase()
            {
                Model = "SysUniCa150", Name = "SystemUnitCase", Price = 2000,
                PowerSupplyDimensions = new Dimensions(120, 120, 50)
            };
            SystemUnitCase u3 = new SystemUnitCase()
            {
                Model = "SysUniCa3000", Name = "SystemUnitCase", Price = 2000,
                PowerSupplyDimensions = new Dimensions(100, 80, 30)
            };
            
            u1.MotherboardTypesSupported.Add(MotherboardTypes.MBT100);
            u1.MotherboardTypesSupported.Add(MotherboardTypes.MBT200);
            u1.MotherboardTypesSupported.Add(MotherboardTypes.MBT300);
            u1.MotherboardTypesSupported.Add(MotherboardTypes.MBT500);
            
            u2.MotherboardTypesSupported.Add(MotherboardTypes.MBT400);
            u2.MotherboardTypesSupported.Add(MotherboardTypes.MBT500);
            u2.MotherboardTypesSupported.Add(MotherboardTypes.MBT600);
            
            u3.MotherboardTypesSupported.Add(MotherboardTypes.MBT700);
            u3.MotherboardTypesSupported.Add(MotherboardTypes.MBT400);
            u3.MotherboardTypesSupported.Add(MotherboardTypes.MBT300);
            u3.MotherboardTypesSupported.Add(MotherboardTypes.MBT600);

            SystemUnitCase.Items.Add(u1);
            SystemUnitCase.Items.Add(u2);
            SystemUnitCase.Items.Add(u3);
            
            Motherboard m1 = new Motherboard() {Type = MotherboardTypes.MBT100, Model = "M1", Name = "Motherboard M1"};
            Motherboard m2 = new Motherboard() {Type = MotherboardTypes.MBT200, Model = "M2", Name = "Motherboard M2"};
            Motherboard m3 = new Motherboard() {Type = MotherboardTypes.MBT300, Model = "M3", Name = "Motherboard M3"};
            Motherboard m4 = new Motherboard() {Type = MotherboardTypes.MBT700, Model = "M4", Name = "Motherboard M4"};
            Motherboard m5 = new Motherboard() {Type = MotherboardTypes.MBT700, Model = "M5", Name = "Motherboard M5"};
            
            m1.ProcessorTypesSupported.Add(ProcessorTypes.PT1);
            m1.ProcessorTypesSupported.Add(ProcessorTypes.PT2);
            m1.MemoryCardTypesSupported.Add(MemoryCardTypes.MCT1);
            m1.MemoryCardTypesSupported.Add(MemoryCardTypes.MCT2);
            m1.MemoryCardTypesSupported.Add(MemoryCardTypes.MCT5);

            
            m2.ProcessorTypesSupported.Add(ProcessorTypes.PT3);
            m2.MemoryCardTypesSupported.Add(MemoryCardTypes.MCT4);

            m3.ProcessorTypesSupported.Add(ProcessorTypes.PT4);
            m3.MemoryCardTypesSupported.Add(MemoryCardTypes.MCT1);
            m3.MemoryCardTypesSupported.Add(MemoryCardTypes.MCT3);

            
            m4.ProcessorTypesSupported.Add(ProcessorTypes.PT4);
            m4.ProcessorTypesSupported.Add(ProcessorTypes.PT5);
            m4.MemoryCardTypesSupported.Add(MemoryCardTypes.MCT5);
            m4.MemoryCardTypesSupported.Add(MemoryCardTypes.MCT5);

            
            m5.ProcessorTypesSupported.Add(ProcessorTypes.PT2);
            m5.ProcessorTypesSupported.Add(ProcessorTypes.PT3);
            m5.ProcessorTypesSupported.Add(ProcessorTypes.PT4);
            m5.MemoryCardTypesSupported.Add(MemoryCardTypes.MCT2);
            m5.MemoryCardTypesSupported.Add(MemoryCardTypes.MCT3);
            m5.MemoryCardTypesSupported.Add(MemoryCardTypes.MCT4);
            m5.MemoryCardTypesSupported.Add(MemoryCardTypes.MCT5);

            Motherboard.Items.Add(m1);
            Motherboard.Items.Add(m2);
            Motherboard.Items.Add(m3);
            Motherboard.Items.Add(m4);
            Motherboard.Items.Add(m5);

            Processor p1 = new Processor() { Type = ProcessorTypes.PT1, Name = "Processor PT1 4 cores", Model = "Jfwk7", NumberOfCores = 4};
            Processor p2 = new Processor() { Type = ProcessorTypes.PT1, NumberOfCores = 8, Name = "Processor PT1 8 cores", Model = "Jnkc3728" };
            Processor p3 = new Processor() { Type = ProcessorTypes.PT2, NumberOfCores = 4, Name = "Processor PT2 4 cores", Model = "Tyeiq5" };
            Processor p4 = new Processor() { Type = ProcessorTypes.PT3, NumberOfCores = 16, Name = "Processor PT3 16 cores", Model = "KKdjwk12" };
            
            Processor.Items.Add(p1);
            Processor.Items.Add(p2);
            Processor.Items.Add(p3);
            Processor.Items.Add(p4);
            
            MemoryCard c1 = new MemoryCard()
                {Type = MemoryCardTypes.MCT1, Name = "Memory Card", Model = "Jkrv 4893", Price = 2000, MemoryCapacity = 1024};
            MemoryCard c2 = new MemoryCard()
                {Type = MemoryCardTypes.MCT4, Name = "Memory Card", Model = "Jkrv 4893", Price = 3200, MemoryCapacity = 2048};
            MemoryCard c3 = new MemoryCard()
                {Type = MemoryCardTypes.MCT5, Name = "Memory Card", Model = "Jkrv 4893", Price = 1200, MemoryCapacity = 1024};
            MemoryCard c4 = new MemoryCard()
                {Type = MemoryCardTypes.MCT3, Name = "Memory Card", Model = "Jkrv 4893", Price = 700, MemoryCapacity = 512};
            MemoryCard c5 = new MemoryCard()
                {Type = MemoryCardTypes.MCT1, Name = "Memory Card", Model = "Jkrv 4893", Price = 1700, MemoryCapacity = 1024};
            
            MemoryCard.Items.Add(c1);
            MemoryCard.Items.Add(c2);
            MemoryCard.Items.Add(c3);
            MemoryCard.Items.Add(c4);
            MemoryCard.Items.Add(c5);

            PowerSupply s1 = new PowerSupply()
                {Name = "PS1000", Dimensions = new Dimensions(120, 200, 10), Power = 4500, Price = 500};
            PowerSupply s2 = new PowerSupply()
                {Name = "PS1000", Dimensions = new Dimensions(120, 200, 10), Power = 4500, Price = 500};
            PowerSupply s3 = new PowerSupply()
                {Name = "PS1000", Dimensions = new Dimensions(120, 200, 10), Power = 4500, Price = 500};
            PowerSupply s4 = new PowerSupply()
                {Name = "PS1000", Dimensions = new Dimensions(120, 200, 10), Power = 4500, Price = 500};

            PowerSupply.Items.Add(s1);
            PowerSupply.Items.Add(s2);
            PowerSupply.Items.Add(s3);
            PowerSupply.Items.Add(s4);
        }
        
    }
}
