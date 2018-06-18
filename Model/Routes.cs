using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionOfKrishnanand.Model
{
    public class Routes : PointsBase
    {
        public string Route { get; set; }
        public string StartTime { get; set; }
        public string DeliveryPoint { get; set; }
        public decimal DeliveryTime { get; set; }
        public string PickUpPoint { get; set; }
        public decimal PickUpTime { get; set; }
        public decimal TimeInTruck { get; set; }
    }
}
