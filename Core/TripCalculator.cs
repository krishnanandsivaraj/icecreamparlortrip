using SolutionOfKrishnanand.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionOfKrishnanand.Core
{
    public static class TripCalculator
    {
        public static List<Routes> getRoutes(List<PickUpPoints> pickUpPoints,List<DeliveryPoints> deliveryPoints) {
            List<Routes> routes = new List<Routes>();bool status;
            try
            {

                foreach (var pickUp in pickUpPoints)
                {
                    foreach (var delivery in deliveryPoints)
                    {
                        routes.Add(new Routes
                        {
                            Route = delivery.RouteName + "-" + pickUp.RouteName,
                            StartTime = "7 AM",
                            DeliveryPoint = delivery.RouteName,
                            PickUpPoint = pickUp.RouteName,
                            DeliveryTime = 7 + delivery.East + delivery.South,
                            PickUpTime = Math.Abs(delivery.East - pickUp.East) + Math.Abs(delivery.South - pickUp.South) + 7 + delivery.East + delivery.South,
                            TimeInTruck = Math.Abs(delivery.East - pickUp.East) + Math.Abs(delivery.South - pickUp.South)
                        });
                    }
                }
                status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Inputs malformed. Not able to generate results!!");
                status = false;
            }

            return status? routes: null;
            
        }
    }
}
