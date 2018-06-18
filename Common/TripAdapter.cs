using SolutionOfKrishnanand.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionOfKrishnanand
{
    public static class TripAdapter
    {
        public static List<PickUpPoints> getPickUpPoints(List<string> input)
        {
            List<PickUpPoints> pickupPoints = new List<PickUpPoints>();
            string routeName, east, south;
            var pickUpPoint = input.Skip(1);
            bool status=GetPickUpPoints(pickupPoints, out routeName, out east, out south, pickUpPoint);

            return status?pickupPoints : null;
        }

        public static List<DeliveryPoints> getDeliveryPoints(List<string> input)
        {
            List<DeliveryPoints> deliveryPoints = new List<DeliveryPoints>();
            var deliveryPoint = input.First();
            string routeName, east, south;
            bool status=GetDeliveryPoints(deliveryPoints, out routeName, out east, out south, deliveryPoint);
            return status? deliveryPoints : null;
        }

        private static bool GetPickUpPoints(List<PickUpPoints> pickupPoints, out string routeName, out string east, out string south,  IEnumerable<string> pickUpPoint)
        {
            routeName = "";east = "";south = "";
            
                foreach (var s in pickUpPoint)
                {
                    string[] line = s.Split('\t');
                    for (int i = 1; i < line.Length; i++)
                    {
                        try
                        {
                            string[] pickUp = line[i].Split(':');
                            routeName = pickUp[0];
                            string[] directions = pickUp[1].Split(',');
                            east = directions[0].Replace('[', ' ').Replace(']', ' ').Trim();
                            south = directions[1].Replace('[', ' ').Replace(']', ' ').Trim();
                            pickupPoints.Add(new PickUpPoints { RouteName = routeName, East = Convert.ToDecimal(east), South = Convert.ToDecimal(south) });
                        }
                        catch (Exception ex)
                        {
                        Console.WriteLine($"PickPoint {line[i]} is invalid!! Error message:  {ex.Message}");
                        pickupPoints = null;
                        return false;
                        }
                    }
                
                }
            return true;
        }

        private static bool GetDeliveryPoints(List<DeliveryPoints> deliveryPoints, out string routeName, out string east, out string south, string deliveryPoint)
        {
            routeName = ""; east = ""; south = "";
        
                string[] line = deliveryPoint.Split('\t');
                for (int i = 1; i < line.Length; i++)
                {
                try
                {
                    string[] pickUp = line[i].Split(':');
                    routeName = pickUp[0];
                    string[] directions = pickUp[1].Split(',');
                    east = directions[0].Replace('[', ' ').Replace(']', ' ').Trim();
                    south = directions[1].Replace('[', ' ').Replace(']', ' ').Trim();
                    deliveryPoints.Add(new DeliveryPoints { RouteName = routeName, East = Convert.ToDecimal(east), South = Convert.ToDecimal(south) });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"DeliveryPoint {line[i]} is invalid!! Error message:  {ex.Message}");
                    deliveryPoints = null;
                    return false;
                }
                }
            return true;
            
        }


    }
}
