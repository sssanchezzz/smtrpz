using System;
namespace Lab1
{
    public class Processor : Base<Processor>
    {
        public string Type;

        public int ClockRate;
        public int Performance;
        public int PowerConsumption;
        public string Architecture;

        public Processor()
        {
        }
    }
}
