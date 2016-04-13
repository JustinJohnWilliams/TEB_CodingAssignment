using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GameConsole : Device
    {
        public GameConsole(string code)
        {
            Code = code;
        }

        public override void Power(string deviceCode)
        {
            //TODO: when turning off game console, we need to:
            //1. safely quit the current game, if any
            //2. safely close all current apps, if any
            //3. sign user out of game console netowrk (psn network, xbox live, etc)
            throw new NotImplementedException();
        }
    }
}
