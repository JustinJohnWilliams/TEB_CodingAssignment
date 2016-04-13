namespace Model
{
    public class Remote
    {
        private Device _device;

        public Remote(Device device)
        {
            _device = device;
        }

        public void ChannelUp()
        {
            _device.ChangeChannel(_device.Code, ChannelChangeType.Up);
        }

        public void ChannelDown()
        {
            _device.ChangeChannel(_device.Code, ChannelChangeType.Down);
        }

        public void Power()
        {
            _device.Power(_device.Code);
        }

        public void GoToChannel(int channel)
        {
            _device.ChangeChannel(_device.Code, ChannelChangeType.Specific, channel);
        }
    }
}
