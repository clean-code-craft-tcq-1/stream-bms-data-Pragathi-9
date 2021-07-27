using System.Collections.Generic;
namespace BatteryDataStreamingReceiver
{
    public interface IParseInputData
    {
        List<BatteryParameters> GetParsedBatteryParametersFromInput(List<string> inputData);
    }
}