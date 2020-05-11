using System;
using System.Collections.Generic;
using System.Text;

namespace TickManager
{
    /// <summary>
    /// Handles ticking for an application
    /// </summary>
    public class TickManager
    {
        /// <summary>
        /// The frequency the application should be running at
        /// </summary>
        internal double internalFrequency;
        
        /// <summary>
        /// Variable to store the milliseconds each tick should take
        /// </summary>
        internal double msptInternal;

        /// <summary>
        /// Tick clock object
        /// </summary>
        internal TickClock tc = new TickClock();

        /// <summary>
        /// The frequency your application will tick
        /// </summary>
        public int Frequency
        {
            get => (int)internalFrequency;
            set
            {
                // Tries to get an exact aproximation to the integer because Math...
                internalFrequency = value + 0.001;
                msptInternal = TickHelper.TpsToMspt(internalFrequency);
            }
        }

        /// <summary>
        /// Milliseconds per tick that took to run last tick
        /// </summary>
        public double MSPT { get; private set; }

        /// <summary>
        /// The ticks per second the server is running at relative to last tick
        /// </summary>
        public double TPS 
        { 
            get => TickHelper.MsptToTps(MSPT);
        }

        /// <summary>
        /// Checks if the application can process the same tick relative to the frequency set
        /// </summary>
        /// <returns>Whether the application should process the next tick or not</returns>
        public bool CanTick()
        {
            double internalMspt = tc.Tick();
            bool canTick = internalMspt > msptInternal;
            if (canTick)
            {
                MSPT = internalMspt;
                tc.Reset();
            }
            return canTick;
        }
    }
}
