using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipIt
{

        public interface iContainer
        {
            double getPriceToShip();

            bool requiresSpecialHandling { get; set; }

        }

        public class Box : iContainer
        {
            private double _x;
            private double _y;
            private double _z;

            public Box(double x, double y, double z)
            {
                _x = x;
                _y = y;
                _z = z;
                requiresSpecialHandling = false;
            }

            public bool requiresSpecialHandling { get; set; }

            public double getPriceToShip()
            {
                double price = (1.35*(_x*_y*(_z/2)))*.25;
                if (requiresSpecialHandling)
                {
                    price += 25.00;
                }


                return price;

            }

        }

        public class Bag : iContainer
        {
            double _volume;
            public Bag(double volume)
            {
                _volume = volume;
                requiresSpecialHandling = false;
            }
            public bool requiresSpecialHandling { get; set; }

            public double getPriceToShip()
            {
                double price = 0.99 * _volume;
                if(requiresSpecialHandling)
                {
                    price += 25.00;
                }


                return price;
            }
        }
    }

