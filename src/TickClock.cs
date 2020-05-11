using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;

namespace TickManager
{
    /// <summary>
    /// Clock that calculates tick time
    /// </summary>
    public class TickClock
    {
        /// <summary>
        /// The ammount of ticks a millisecond has
        /// </summary>
        internal const double TicksPerMillisecond = 10000;

        /// <summary>
        /// Internal application start timestamp
        /// </summary>
        internal double startTimeStamp;

        /// <summary>
        /// Resets the TickClock
        /// </summary>
        public void Reset()
        {
            startTimeStamp = TickHelper.GetCurrentTimestamp();
        }

        /// <summary>
        /// Register an application tick
        /// </summary>
        /// <returns>The amount of time the application took to register a tick</returns>
        public double Tick()
        {
            long currentTimestamp = TickHelper.GetCurrentTimestamp();
            return (currentTimestamp - startTimeStamp) / TicksPerMillisecond;
        }
    }
}