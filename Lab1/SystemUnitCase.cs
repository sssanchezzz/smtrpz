using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab1
{
    //  корпус системного блока
    public class SystemUnitCase : Base<SystemUnitCase>
    {
        public ArrayList MotherboardTypesSupported { get; }

        public Dimensions PowerSupplyDimensions { get; set; }
        public List<PowerSupply> PowerSupplies { get; }

        public SystemUnitCase()
        {
        }


        public bool AddMotherboardBool(Motherboard motherboard)
        {
            if (MotherboardTypesSupported.Contains(motherboard.Type))
                return true;
            return false;
        }



        public bool AddPowerSupplyBool(PowerSupply supply)
        {
            if (supply.Dimensions.Width <= PowerSupplyDimensions.Width
                && supply.Dimensions.Length <= PowerSupplyDimensions.Length
                && supply.Dimensions.Height <= PowerSupplyDimensions.Height)
            {
                return true;
            }
            return false;
        }

        public void AddPowerSupply(PowerSupply supply, bool possible)
        {
            if (possible)
            {
                PowerSupplies.Add(supply);
            }

        }



    }
}
