using SolutionOfKrishnanand.Core;
using SolutionOfKrishnanand.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionOfKrishnanand
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Route | Start From Factory @ | Delivery Point | Delivery Time | PickUp Point | PickUp Time | Time In Truck");
            Console.WriteLine("==========================================================================================================");
            List<string> input = new List<string>();
            string delivery;
            string pickup;
            input = RouteFactory.Get("tsv");
            if (input.Validated("tsv"))
            {
                List<PickUpPoints> pickUpPoints = TripAdapter.getPickUpPoints(input);
                List<DeliveryPoints> deliveryPoints = TripAdapter.getDeliveryPoints(input);
                try
                {
                    IEnumerable<Routes> routes = TripCalculator.getRoutes(pickUpPoints, deliveryPoints).OrderBy(x => x.TimeInTruck).Take(1);

                    
                        foreach (Routes s in routes)
                        {
                            if (s.DeliveryTime > 12) { delivery = Convert.ToString(s.DeliveryTime - 12) + " PM"; }
                            else { delivery = Convert.ToString(s.DeliveryTime) + " AM"; }
                            if (s.PickUpTime > 12) { pickup = Convert.ToString(s.PickUpTime - 12) + " PM"; }
                            else { pickup = Convert.ToString(s.PickUpTime) + " AM"; }
                            Console.WriteLine($"{s.Route} | {s.StartTime} | { s.DeliveryPoint} | {delivery} | {s.PickUpPoint} | {pickup} | {s.TimeInTruck} hour(s)");
                        }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.ReadLine();
        }
    }
}
