using System.Collections.Generic;
using System.Reflection;
using BatteryDataStreamingReceiver;

namespace BatteryDataStreamingReceiverTests
{
    public static class AssertObjectsHelper
    {
        public static bool ActualAndExpectedObjectsAreEqual(List<BatteryParameters> actualList, List<BatteryParameters> expectedList)
        {
            if (actualList.Count != expectedList.Count)
                return false;

            for (int i = 0; i < actualList.Count; i++)
            {
                var actualValue = actualList[i];
                var expectedValue = expectedList[i];
                if (!AssertPropertiesOfObjectAreEquals((BatteryParameters)actualValue, (BatteryParameters)expectedValue))
                    return false;
            }
            return true;
        }

        private static bool AssertPropertiesOfObjectAreEquals(BatteryParameters actualObject, BatteryParameters expectedObject)
        {
            bool result = true;
            PropertyInfo[] properties = expectedObject.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object expectedValue = property.GetValue(expectedObject, null);
                object actualValue = property.GetValue(actualObject, null);
                if (!Equals(expectedValue, actualValue))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
    }
}
