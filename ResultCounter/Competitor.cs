using System.Collections.Generic;

namespace ResultCounter
{
    class Competitor
    {
        public List<string> pointsList;

        public string StartNum { get; set; }
        public string Driver { get; set; }
        public string CoDriver { get; set; }
        public int TotalPoints { get; private set; }      

        public Competitor()
        {
            pointsList = new List<string>();
        }

        public void addPointsToList(string value)
        {
            int points;
            if(int.TryParse(value, out points))
            {
                pointsList.Add(value);
                int sum = TotalPoints + points;
                TotalPoints = sum;
            }
        }
    }
}
