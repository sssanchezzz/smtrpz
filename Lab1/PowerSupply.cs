using System;
namespace Lab1
{
    public class PowerSupply : Base<PowerSupply>
    {
        // защита от перепадов напряжения, цена, мощность
        public bool VoltageDropsProtection { get; set; }
        public int Power { get; set; }
        //габариты
        public Dimensions Dimensions { get; set; }

        public PowerSupply()
        {
        }


    }
}
