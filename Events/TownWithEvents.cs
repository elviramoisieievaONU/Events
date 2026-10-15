using System;
using System.Collections.Generic;
using System.Text;
using static Events.TownWithEvents;

namespace Events
{
    class TownEventArgs : EventArgs
    {
        public int Day { get; private set; }
        public int Building { get; private set; }
        public TownEventArgs(int day, int building)
        {
            Day = day;
            Building = building;
        }
    }
        public delegate void FireEvent
          (int day, int building);

    internal class TownWithEvents
    {
        private int buildings;          // кількість будинків у місті 
        private int days;               // період життя міста
        private double fireProbability; // ймовірність пожежі
        Random random;                  // генератор випадкових чисел
        public string TownName { get; private set; } // н

        EventHandler<TownEventArgs> fireEvent;
        public TownWithEvents(int buildings, int days, double fireProbability, string name)
        {
            this.buildings = buildings;
            this.days = days;
            this.fireProbability = fireProbability;
            TownName = name;
            this.random = new Random();
        }
        private void OnFire(int day, int building)
        {
            if (fireEvent != null)
            {
                fireEvent(this, new TownEventArgs(day, building));
            }
        }
        public void TownLife()
        {
            for (int day = 1; day <= days; day++)
            {
                for (int building = 1; building <= buildings; building++)
                {
                    if (random.NextDouble() < fireProbability)
                    {
                        OnFire(day, building);

                    }
                }
            }
        }
        public class FireMan
        {
            private TownWithEvents MyNativeTown;
            public FireMan(TownWithEvents town)
            {
                MyNativeTown = town;

            }
            public void FireHandler(object town, TownEventArgs args)
            {
                MyNativeTown = (TownWithEvents)town;
                Console.WriteLine("Fire in " + MyNativeTown.TownName + ", day: " + args.Day + ", building: " + args.Building);
            }
            public void Subscribe()
            {
                MyNativeTown.fireEvent += FireHandler;
            }
            public void Unsubscribe()
            {
                MyNativeTown.fireEvent -= FireHandler;
            }
        }

    }
}