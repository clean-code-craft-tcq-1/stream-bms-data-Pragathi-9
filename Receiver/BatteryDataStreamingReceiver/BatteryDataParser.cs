using System;
using System.Collections.Generic;
namespace BatteryDataStreamingReceiver
{
    public class inputDataParser : IParseInputData
    {
        public inputDataParser(string delimeterValue)
        {
            delimeter = delimeterValue;
        }
        private string delimeter;
        public List<BatteryParameters> GetParsedBatteryParametersFromInput(List<string> inputData)
        {
            List<BatteryParameters> batteryParameters = new List<BatteryParameters>();
            if (inputData == null)
                return batteryParameters;
            foreach (string  parameter in inputData)
            {
                BatteryParameters batteryParameter = new BatteryParameters();
                string[] batteryParameterValues = parameter.Split(delimeter);
                batteryParameter.Temperature = Convert.ToDouble(batteryParameterValues[0]);
                batteryParameter.StateOfCharge = Convert.ToDouble(batteryParameterValues[1]);
                batteryParameters.Add(batteryParameter);
            }
            return batteryParameters;
        }
    }
}
