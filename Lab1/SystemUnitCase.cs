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

        public bool CheckPowerConsumption()
        {
            if (MotherboardAdded != null && MotherboardAdded.Processor != null && PowerSupply != null &&
                MotherboardAdded.MemoryCards != null && MotherboardAdded.MemoryCards.Count != 0)
            {
                int sum = 0;
                foreach (var c in MotherboardAdded.MemoryCards)
                {
                    sum += c.PowerConsumption;
                }

                sum += MotherboardAdded.PowerConsumption + MotherboardAdded.Processor.PowerConsumption;

                return (sum <= PowerSupply.Power);
            }
            else
            {
                return false;
            }
        }
    }
}