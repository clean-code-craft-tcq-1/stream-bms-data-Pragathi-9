namespace BatteryDataStreamingReceiver
{
    public class Temperature
    {
        private double minTemp = double.MaxValue;

        public double MinimumTemperature
        {
            get { return minTemp; }
            set { minTemp = value; }
        }

        private double maxTemp = double.MinValue;

        public double MaximumTemperature
        {
            get { return maxTemp; }
            set { maxTemp = value; }
        }

        public double MovingAverageTemperature { get; set; }
    }
}
