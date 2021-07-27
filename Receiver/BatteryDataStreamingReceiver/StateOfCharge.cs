namespace BatteryDataStreamingReceiver
{
    public class StateOfCharge
    {
        private double minSOC = double.MaxValue;
        public double MinimumStateOfCharge
        {
            get { return minSOC; }
            set { minSOC = value; }
        }
        private double maxSOC = double.MinValue;
        public double MaximumStateOfCharge
        {
            get { return maxSOC; }
            set { maxSOC = value; }
        }
        public double MovingAverageSoc { get; set; }
    }
}
