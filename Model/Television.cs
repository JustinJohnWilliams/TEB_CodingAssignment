namespace Model
{
    public class Television : Device
    {
        public Television(string code)
        {
            Code = code;
        }

        public override void Power(string deviceCode)
        {
            if(deviceCode != Code)
            {
                return;
            }

            TurnedOn = !TurnedOn;
        }

        public void ManualChannelUp()
        {
            ChangeChannel(Code, ChannelChangeType.Up);
        }

        public void ManualChannelDown()
        {
            ChangeChannel(Code, ChannelChangeType.Down);
        }

        public void ManualPower()
        {
            TurnedOn = !TurnedOn;
        }
    }
}
