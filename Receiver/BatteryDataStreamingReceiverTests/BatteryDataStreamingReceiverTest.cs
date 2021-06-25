using Xunit;
using BatteryDataStreamingReceiver;
using System.Collections.Generic;

namespace BatteryDataStreamingReceiverTests
{
    public class BatteryDataStreamingReceiverTest
    {
        IParseInputData inputDataParser = new inputDataParser(",");
        List<string> batteryData = new List<string>() { "12,45", "0,52", "10,12", "11,9", "51,54","31,58","43,45","20,45","56,45","34,45" };

        public List<BatteryParameters> ExpectedBatteryDataList()
        {
            List<BatteryParameters> expectedBatteryData = new List<BatteryParameters>();
            BatteryParameters batteryParameter = new BatteryParameters() { Temperature = 12, StateOfCharge = 45};
            expectedBatteryData.Add(batteryParameter);
            batteryParameter = new BatteryParameters() { Temperature = 0, StateOfCharge = 52 };
            expectedBatteryData.Add(batteryParameter);
            batteryParameter = new BatteryParameters() { Temperature = 10, StateOfCharge = 12 };
            expectedBatteryData.Add(batteryParameter);
            batteryParameter = new BatteryParameters() { Temperature = 11, StateOfCharge = 9 };
            expectedBatteryData.Add(batteryParameter);
            batteryParameter = new BatteryParameters() { Temperature = 51, StateOfCharge = 54 };
            expectedBatteryData.Add(batteryParameter);
            batteryParameter = new BatteryParameters() { Temperature = 31, StateOfCharge = 58 };
            expectedBatteryData.Add(batteryParameter);
            batteryParameter = new BatteryParameters() { Temperature = 43, StateOfCharge = 45 };
            expectedBatteryData.Add(batteryParameter);
            batteryParameter = new BatteryParameters() { Temperature = 20, StateOfCharge = 45 };
            expectedBatteryData.Add(batteryParameter);
            batteryParameter = new BatteryParameters() { Temperature = 56, StateOfCharge = 45 };
            expectedBatteryData.Add(batteryParameter);
            batteryParameter = new BatteryParameters() { Temperature = 34, StateOfCharge = 45 };
            expectedBatteryData.Add(batteryParameter);
            return expectedBatteryData;
        }

        [Fact]
        public void GivenBatteryDataList_WhenBatteryDataListIsNull_ThenReturnBatteryParameterListEmpty()
        {
            List<string> batteryData = null;
            List<BatteryParameters> batteryParameters = inputDataParser.GetParsedBatteryParametersFromInput(batteryData);
            Assert.True(batteryParameters.Count == 0);
        }

        [Fact]
        public void GivenBatteryDataList_WhenBatteryDataListIsEmpty_ThenReturnBatteryParameterListEmpty()
        {
            List<string> batteryData = new List<string>();
            List<BatteryParameters> batteryParameters = inputDataParser.GetParsedBatteryParametersFromInput(batteryData);
            Assert.True(batteryParameters.Count == 0);
        }

        [Fact]
        public void GivenBatteryDataList_WhenBatteryDataListIsValid_ThenReturnExpectedBatteryParameterList()
        {
            List<BatteryParameters> batteryParameters = inputDataParser.GetParsedBatteryParametersFromInput(batteryData);
            Assert.True(AssertObjectsHelper.ActualAndExpectedObjectsAreEqual(ExpectedBatteryDataList(), batteryParameters));
        }

        [Fact]
        public void GivenBatteryDataList_WhenBatteryDataListIsValid_ThenCheckTemperatureMinimum()
        {
            BatteryInputCalculator batteryDataProcessor = new BatteryInputCalculator(inputDataParser);
            BatteryInputsInitiator batteryCharacteristics = null;
            double expectedTemperature = 0;
            for (int i = 0; i < batteryData.Count; i++)
            {
                batteryCharacteristics = batteryDataProcessor.CalculateMinimumAndMaximumValues(batteryData[i]);
            }
            Assert.Equal(batteryCharacteristics.Temperature.MinimumTemperature, expectedTemperature);
        }

        [Fact]
        public void GivenBatteryDataList_WhenBatteryDataListIsValid_ThenCheckTemperatureMaximum()
        {
            BatteryInputCalculator batteryDataProcessor = new BatteryInputCalculator(inputDataParser);
            BatteryInputsInitiator batteryCharacteristics = null;
            double expectedTemperature = 56;
            for (int i = 0; i < batteryData.Count; i++)
            {
                batteryCharacteristics = batteryDataProcessor.CalculateMinimumAndMaximumValues(batteryData[i]);
            }
            Assert.Equal(batteryCharacteristics.Temperature.MaximumTemperature, expectedTemperature);
        }

        [Fact]
        public void GivenBatteryDataList_WhenBatteryDataListIsValid_ThenCheckStateOfChargeMinimum()
        {
            BatteryInputCalculator batteryDataProcessor = new BatteryInputCalculator(inputDataParser);
            BatteryInputsInitiator batteryCharacteristics = null;
            double expectedStateOfCharge = 9;
            for (int i = 0; i < batteryData.Count; i++)
            {
                batteryCharacteristics = batteryDataProcessor.CalculateMinimumAndMaximumValues(batteryData[i]);
            }
            Assert.Equal(batteryCharacteristics.StateOfCharge.MinimumStateOfCharge, expectedStateOfCharge);
        }

        [Fact]
        public void GivenBatteryDataList_WhenBatteryDataListIsValid_ThenCheckStateOfChargeMaximum()
        {
            BatteryInputCalculator batteryDataProcessor = new BatteryInputCalculator(inputDataParser);
            BatteryInputsInitiator batteryCharacteristics = null;
            double expectedStateOfCharge = 58;
            for (int i = 0; i < batteryData.Count; i++)
            {
                batteryCharacteristics = batteryDataProcessor.CalculateMinimumAndMaximumValues(batteryData[i]);
            }
            Assert.Equal(batteryCharacteristics.StateOfCharge.MaximumStateOfCharge, expectedStateOfCharge);
        }

        [Fact]
        public void GivenBatteryDataList_WhenBatteryDataIsValid_ThenCheckMovingAverageForTemperature()
        {
            BatteryInputCalculator batteryDataProcessor = new BatteryInputCalculator(inputDataParser);
            double expectedTemperature = 26.8;
            BatteryInputsInitiator batteryCharacteristics = batteryDataProcessor.CalculateMovingAverageValue(batteryData);
            Assert.Equal(batteryCharacteristics.Temperature.MovingAverageTemperature, expectedTemperature);
        }
        
        [Fact]
        public void GivenBatteryDataList_WhenBatteryDataIsValid_ThenCheckMovingAverageForStateOfCharge()
        {
            BatteryInputCalculator batteryDataProcessor = new BatteryInputCalculator(inputDataParser);
            double expectedStateOfCharge = 41;
            BatteryInputsInitiator batteryCharacteristics = batteryDataProcessor.CalculateMovingAverageValue(batteryData);
            Assert.Equal(batteryCharacteristics.StateOfCharge.MovingAverageSoc, expectedStateOfCharge);
        }
    }
}
