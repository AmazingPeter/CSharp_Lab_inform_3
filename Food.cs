using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sem4_3
{
    abstract class Food
    {
        public string name;
        List<string> listOfIngredients;
        public double price;

        public Food(string name, List<string> listOfIngredients, double price)
        {
            this.name = name;
            this.listOfIngredients = listOfIngredients;
            this.price = price;
        }

        public string ListOfIngredients()
        {
            string ingredients = "";
            foreach (string i in listOfIngredients)
                ingredients += i + " ";
            return ingredients;
        }

        public override string ToString()
        {
            return name + " " + ListOfIngredients() + " " + price + " ";
        }

        public abstract double UnitPrice();//Цена за единицу

        public abstract int IsAlcoholic();

        public abstract int IsDietary();
    }
}
