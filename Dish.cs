using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sem4_3
{
    class Dish:Food
    {
        bool isDietary;
        int weight;
        public Dish(string name, List<string> listOfIngredients, double price, bool isDietary, int weight):base(name,listOfIngredients,price)
        {
            this.isDietary = isDietary;
            this.weight = weight;
        }

        public override double UnitPrice()
        {
            return price / weight;
        }

        public override bool IsDietary()
        {
            return isDietary;
        }

        public override string ToString()
        {
            return base.ToString() + isDietary + " " + weight;
        }

    }
}
