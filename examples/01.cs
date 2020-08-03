using System;
using System.Collections.Generic;
using System.Text;

namespace TickManager
{
    class _01
    {
        public TickManager tick_manager = new TickManager();

        public void Main()
        {
            tick_manager.OnTick += Tick_manager_OnTick;

            while (true)
            {
                tick_manager.Tick();
            }
        }

        private void Tick_manager_OnTick()
        {
            Console.WriteLine("MSPT: ");
            Console.Write(tick_manager.MSPT);

            Console.WriteLine("TPS: ");
            Console.Write(tick_manager.TPS);
        }
    }
}
