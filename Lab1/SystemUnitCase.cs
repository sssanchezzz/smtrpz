using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab1
{
    //  корпус системного блока
    public class SystemUnitCase : Base<SystemUnitCase>
    {
        public List<MotherboardTypes> MotherboardTypesSupported { get; }
        public Dimensions PowerSupplyDimensions { get; set; }
        public PowerSupply PowerSupply { get; set; }
        public Motherboard MotherboardAdded { get; set; }
        
        public SystemUnitCase()
        {
            MotherboardTypesSupported = new List<MotherboardTypes>();
        }


        public bool AddMotherboardBool(Motherboard motherboard)
        {
            return (MotherboardTypesSupported.Contains(motherboard.Type));
        }

        public void AddMotherboard(Motherboard motherboard, bool res)
        {
            if (res)
            {
                MotherboardAdded = motherboard;
            }
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

      

        



    }
}
