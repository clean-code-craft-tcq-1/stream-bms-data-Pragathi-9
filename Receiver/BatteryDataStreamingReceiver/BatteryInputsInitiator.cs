namespace BatteryDataStreamingReceiver
{
    public class BatteryInputsInitiator
    {
        public BatteryInputsInitiator()
        {
            Temperature = new Temperature();
            StateOfCharge = new StateOfCharge();
        }
        public Temperature Temperature { get; set; }
        public StateOfCharge StateOfCharge { get; set; }
    }
}
