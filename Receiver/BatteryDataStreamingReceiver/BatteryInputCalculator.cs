using System;
using System.Collections.Generic;
namespace BatteryDataStreamingReceiver
{
    public class BatteryInputCalculator : ICalculateInputData
    {
        private BatteryInputsInitiator batteryCharacteristics;
        private IParseInputData inputDataParser;

        public BatteryInputCalculator(IParseInputData _inputDataParser)
        {
            inputDataParser = _inputDataParser;
            batteryCharacteristics = new BatteryInputsInitiator();
        }
        public BatteryInputsInitiator CalculateMovingAverageValue(List<string> batteryInputParameters)
        {
            List<BatteryParameters> batteryParameters = inputDataParser.GetParsedBatteryParametersFromInput(batteryInputParameters);
            CalculateMovingAverage(batteryParameters);
            return batteryCharacteristics;
        }

        public BatteryInputsInitiator CalculateMinimumAndMaximumValues(string batteryParameter)
        {
            List<BatteryParameters> batteryParameters = inputDataParser.GetParsedBatteryParametersFromInput(new List<string>() { batteryParameter });
            CalculateMinimumValue(batteryParameters[0]);
            CalculateMaximumValue(batteryParameters[0]);
            return batteryCharacteristics;
        }

        private void CalculateMinimumValue(BatteryParameters batteryParameter)
        {
            batteryCharacteristics.Temperature.MinimumTemperature = Math.Min(batteryCharacteristics.Temperature.MinimumTemperature, batteryParameter.Temperature);
            batteryCharacteristics.StateOfCharge.MinimumStateOfCharge = Math.Min(batteryCharacteristics.StateOfCharge.MinimumStateOfCharge, batteryParameter.StateOfCharge);
        }

        private void CalculateMaximumValue(BatteryParameters batteryParameter)
        {
            batteryCharacteristics.Temperature.MaximumTemperature = Math.Max(batteryCharacteristics.Temperature.MaximumTemperature, batteryParameter.Temperature);
            batteryCharacteristics.StateOfCharge.MaximumStateOfCharge = Math.Max(batteryCharacteristics.StateOfCharge.MaximumStateOfCharge, batteryParameter.StateOfCharge);
        }

        private void CalculateMovingAverage(List<BatteryParameters> batteryParameters)
        {
            if (batteryParameters.Count <= 0)
                return;
            batteryCharacteristics.Temperature.MovingAverageTemperature = batteryParameters[0].Temperature;
            batteryCharacteristics.StateOfCharge.MovingAverageSoc = batteryParameters[0].StateOfCharge;

            double sumOfTemperature = 0;
            double sumOfStateOfCharge = 0;
            foreach (BatteryParameters batteryParameter in batteryParameters)
            {
                sumOfTemperature += batteryParameter.Temperature;
                sumOfStateOfCharge += batteryParameter.StateOfCharge;
            }
            batteryCharacteristics.Temperature.MovingAverageTemperature = sumOfTemperature / batteryParameters.Count;
            batteryCharacteristics.StateOfCharge.MovingAverageSoc = sumOfStateOfCharge / batteryParameters.Count;
        }
    }
}
