using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lab1
{
    public class Menu
    {
        private delegate bool CheckFunction<T>(T t);

        private static List<bool> res = new List<bool>();

        private static SystemUnitCase unit;

        public static void ShowMenu()
        {
            Console.WriteLine("Please, choose a system unit case");
            foreach (var s in SystemUnitCase.Items)
            {
                Console.WriteLine($"{(SystemUnitCase.Items.IndexOf(s) + 1)} - {s}");
            }

            bool repeat = true;
            while (repeat)
            {
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input > 0 && input <= SystemUnitCase.Items.Count)
                    {
                        repeat = false;
                        unit = SystemUnitCase.Items[input - 1];
                        bool loopmenu = true;
                        while (loopmenu)
                        {
                            Console.WriteLine("Press:\n" +
                                              "1 - to choose motherboard\n" +
                                              "2 - to choose power supply\n" +
                                              "3 - to choose processor\n" +
                                              "4 - to choose memory card\n" +
                                              "C - to get conclusion");

                            var inputKey = Console.ReadKey().Key;
                            switch (inputKey)
                            {
                                case ConsoleKey.D1:
                                    CheckFunction<Motherboard> checkMoth = unit.AddMotherboardBool;
                                    Choose(unit, Motherboard.Items, "motherboard", checkMoth);
                                    break;
                                case ConsoleKey.D2:
                                    CheckFunction<PowerSupply> checkPow = unit.AddPowerSupplyBool;
                                    Choose(unit, PowerSupply.Items, "power", checkPow);
                                    break;
                                case ConsoleKey.D3:
                                    if (MotherboardIsChosen(unit))
                                    {
                                        CheckFunction<Processor> checkProc =
                                            unit.MotherboardAdded.AddProcessorsToMotherboard;
                                        Choose(unit, Processor.Items, "processor", checkProc);
                                    }
                                    else
                                    {
                                        Console.WriteLine("You should choose motherboard!");
                                    }
                                    break;
                                case ConsoleKey.D4:
                                    if (MotherboardIsChosen(unit))
                                    {
                                        ChooseMemoryCard(unit);
                                    }
                                    else
                                    {
                                        Console.WriteLine("You should choose motherboard!");
                                    }

                                    break;
                                case ConsoleKey.C:
                                    bool can = CanGetConclusion(unit);
                                    if (can)
                                    {
                                        loopmenu = false;
                                        Conclusion();
                                    }
                                    else
                                    {
                                        Console.WriteLine("You should finish choosing!");
                                        loopmenu = true;
                                    }

                                    break;
                                default:
                                    loopmenu = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Number out of range, please try again!");
                    }
                }
                else
                {
                    Console.WriteLine("Not a number, please try again!");
                }
            }
        }

        private static void Choose<T>(SystemUnitCase unitCase, List<T> list, string choice, CheckFunction<T> function)
        {
            Console.WriteLine($"\nPlease choose {choice}:\n");
            foreach (var s in list)
            {
                Console.WriteLine(function(s)
                    ? $"{(list.IndexOf(s) + 1)} - {s} - fits"
                    : $"{list.IndexOf(s) + 1} - {s} - does not fit");
            }

            Console.WriteLine("\nPlease enter your option:");
            bool repeat = true;
            while (repeat)
            {
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input > 0 && input <= list.Count)
                    {
                        //add funcrion to set properties
                        SetProp(unitCase, choice, list[input - 1]);
                        Console.WriteLine($"You`ve chosen {list[input - 1]}\n");
                        repeat = false;
                    }
                    else
                    {
                        Console.WriteLine("Number out of range, please try again!");
                        repeat = true;
                    }
                }
                else
                {
                    Console.WriteLine("Not a number, please try again!");
                }
            }
        }


        private static bool SetProp(SystemUnitCase unitCase, string prop, Object obj)
        {
            bool result;
            switch (prop)
            {
                case "motherboard":
                    unitCase.MotherboardAdded = (Motherboard) obj;
                    result = true;
                    break;
                case "power":
                    unitCase.PowerSupply = (PowerSupply) obj;
                    result = true;
                    break;
                case "processor":
                    unitCase.MotherboardAdded.Processor = (Processor) obj;
                    result = true;
                    break;
                default:
                    result = false;
                    break;
            }

            return result;
        }

        private static void ChooseMemoryCard(SystemUnitCase unitCase)
        {
            Console.WriteLine("Choose memory card(-s):\n");

            foreach (var s in MemoryCard.Items)
            {
                Console.WriteLine(unitCase.MotherboardAdded.AddMemoryCardsToMotherBoard(s)
                    ? $"{(MemoryCard.Items.IndexOf(s) + 1)} - {s} - fits"
                    : $"{(MemoryCard.Items.IndexOf(s) + 1)} - {s} - does not fit");
            }

            Console.WriteLine("Please enter your options, to exit enter 'exit':\n");
            Console.WriteLine("memory cards count: " + MemoryCard.Items.Count);
            bool exit = false;
            while (!exit)
            {
                var inputString = Console.ReadLine();
                if (inputString != null)
                {
                    if (int.TryParse(inputString, out int input))
                    {
                        if (input > 0 && input <= MemoryCard.Items.Count)
                        {
                            unitCase.MotherboardAdded.MemoryCards.Add(MemoryCard.Items[input - 1]);
                            Console.WriteLine($"You`ve chosen {MemoryCard.Items[input - 1]}");
                        }
                        else
                        {
                            Console.WriteLine("Wrong number, please try again!\n");
                            exit = false;
                        }
                    }
                    else if (inputString.Equals("exit"))
                    {
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("Not a number, try again");
                    }
                }
            }
        }

        private static void Conclusion()
        {
            Console.WriteLine($"\nYour set:\n" +
                              $"System unit case: {unit};\n" +
                              $"PowerSupply: {unit.PowerSupply}, it {CheckString(unit.AddPowerSupplyBool(unit.PowerSupply))} the unit case;\n" +
                              $"Motherboard: {unit.MotherboardAdded}, it {CheckString(unit.MotherboardTypesSupported.Contains(unit.MotherboardAdded.Type))} the motherboard;\n" +
                              $"Processor: {unit.MotherboardAdded.Processor}, it {CheckString(unit.MotherboardAdded.AddProcessorsToMotherboard(unit.MotherboardAdded.Processor))} the motherboard;\n");

            Console.WriteLine($"Memory card{(unit.MotherboardAdded.MemoryCards.Count == 1 ? "" : "s")}:");
            foreach (var s in unit.MotherboardAdded.MemoryCards)
            {
                Console.WriteLine(
                    $"{s} - {CheckString(unit.MotherboardAdded.MemoryCardTypesSupported.Contains(s.Type))}");
            }

            bool power = unit.CheckPowerConsumption();
            res.Add(power);
            Console.WriteLine($"battery is {(power ? "" : "not")} enough to power all the elements");
            Console.WriteLine($"\nYou can{(res.Contains(false) ? " not" : "")} form a set out of these items");
        }

        private static bool CanGetConclusion(SystemUnitCase unitCase)
        {
            if (unitCase == null)
            {
                return false;
            }
            else
            {
                if (unitCase.MotherboardAdded == null)
                {
                    Console.WriteLine("\nChoose motherboard!");
                }
                else
                {
                    if (unitCase.MotherboardAdded.Processor == null)
                    {
                        Console.WriteLine("\nChoose processor!");
                        return false;
                    }

                    if (unitCase.MotherboardAdded.MemoryCards == null ||
                        unitCase.MotherboardAdded.MemoryCards.Count == 0)
                    {
                        Console.WriteLine("\nChoose memory card!");
                        return false;
                    }
                }

                if (unitCase.PowerSupply == null)
                {
                    Console.WriteLine("\nChoose power supply!");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private static bool MotherboardIsChosen(SystemUnitCase unitCase)
        {
            return (unitCase.MotherboardAdded != null);
        }

        private static string CheckString(bool b)
        {
            if (b)
            {
                res.Add(true);
                return "fits";
            }
            else
            {
                res.Add(false);
                return "does not fit";
            }
        }
    }
}