using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sem4_3
{
    class Food
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

        public virtual double UnitPrice()//Цена за единицу
        {
            return 0;
        }

        public virtual bool IsDietary()
        {
            return false;
        }

        public virtual bool IsAlcoholic()
        {
            return false;
        }
    }
}
