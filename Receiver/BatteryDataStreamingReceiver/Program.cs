using System;
using System.Collections.Generic;
namespace BatteryDataStreamingReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            IParseInputData inputDataParser = new inputDataParser(",");
            BatteryInputCalculator batteryDataProcessor = new BatteryInputCalculator(inputDataParser);
            List<string> batteryData = new List<string>();
            string input;
            while ((input = Console.ReadLine()) != null)
            {
                Console.WriteLine(input);
                batteryData.Add(input);
                BatteryInputsInitiator batteryCharacteristics;
                batteryCharacteristics = batteryDataProcessor.CalculateMinimumAndMaximumValues(input);
                string message = string.Format("Minimum Temperature - {0} Maximum Temperature - {1}\n" +
                                                "Minimum StateOfCharge - {2} Maximum StateOfCharge - {3}", batteryCharacteristics.Temperature.MinimumTemperature,
                                                batteryCharacteristics.Temperature.MaximumTemperature, batteryCharacteristics.StateOfCharge.MinimumStateOfCharge, batteryCharacteristics.StateOfCharge.MaximumStateOfCharge);
                Display(message);
                if (batteryData.Count >= 5)
                {
                    batteryCharacteristics = batteryDataProcessor.CalculateMovingAverageValue(batteryData.GetRange(batteryData.Count - 5, 5));
                    message = string.Format("Moving Average Temperature - {0} Moving AveragetateOfCharge - {1}",
                        batteryCharacteristics.Temperature.MovingAverageTemperature, batteryCharacteristics.StateOfCharge.MovingAverageSoc);
                    Display(message);
                }
            }
        }
        private static void Display(string message)
        {
            Console.WriteLine(message);
        }
    }
}
