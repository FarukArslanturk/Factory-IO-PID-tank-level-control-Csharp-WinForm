using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineIO;

namespace PID_tanklevelcontrol
{
    public abstract class Executer
    {
        public abstract void Execute(int elapsedMilliseconds);

    }
}
