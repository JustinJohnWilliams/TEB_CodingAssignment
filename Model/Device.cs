namespace Model
{
    public abstract class Device
    {
        //model can access
        internal string Code { get; set; }

        //if children need to do this differently, they can
        public virtual int CurrentChannel { get; set; }
        
        //if children need to do this differently, they can
        public virtual bool TurnedOn { get; set; }

        //children need to implement. "Power" may do more than just simply turn off machine
        public abstract void Power(string deviceCode);

        //if children need to do this differently they can
        public virtual void ChangeChannel(string deviceCode, ChannelChangeType channelChangeType, int channel = 0)
        {
            if (Code != deviceCode)
            {
                return;
            }

            switch (channelChangeType)
            {
                case ChannelChangeType.Up:
                    CurrentChannel++;
                    break;
                case ChannelChangeType.Down:
                    if(CurrentChannel > 0) CurrentChannel--;
                    break;
                case ChannelChangeType.Specific:
                    if (channel <= 0)
                    {
                        throw new InvalidChannelException();
                    }

                    CurrentChannel = channel;
                    break;
            }
        }
    }
}
