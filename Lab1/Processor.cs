using System;
namespace Lab1
{
    public class Processor : Base<Processor>
    {
        public ProcessorTypes Type;

        public int ClockRate;
        public int NumberOfCores;
        public int PowerConsumption;
        public string Architecture;

        public Processor()
        {
        }
    }
}
