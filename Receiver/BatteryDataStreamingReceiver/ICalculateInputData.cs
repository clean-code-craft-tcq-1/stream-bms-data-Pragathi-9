using System.Collections.Generic;
namespace BatteryDataStreamingReceiver
{
    public interface ICalculateInputData
    {
        BatteryInputsInitiator CalculateMovingAverageValue(List<string> batteryParameters);
        BatteryInputsInitiator CalculateMinimumAndMaximumValues(string batteryParameter);
    }
}