using System;
using System.Collections.Generic;
using System.Text;
using static Events.TownWithEvents;

namespace Events
{
    internal class Testing
    {
        public void TestTown()
        {
            string townName = "New Town";
            int buildings = 1000;
            int days = 30;
            double fireProbability = 1e-3;
            TownWithEvents town = new
            TownWithEvents(buildings, days, fireProbability, townName);
            FireMan fireMan = new FireMan(town);
            fireMan.Subscribe();
            Console.WriteLine("Події в місті " + townName);
            town.TownLife();
        }
    }
}
