using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sem4_3
{
    class Menu
    {
        public List<Food> food = new List<Food>();

        private Food fNow;//для DishAndDrink

        private double averagePrice;

        public void Add(Food f)
        {
            food.Add(f);
        }

        public void OrderByUnitPrice()
        {
            IEnumerable<Food> f = food.OrderBy(s => s.UnitPrice());
            int len = food.Count();
            food.InsertRange(len,f);//вставляем отсортированный
            food.RemoveRange(0, len);//удаляем старый

            Print(f, 1);

        }

        public void GetDishAndDrink(double price)
        {
            foreach(Food fNow in food){
                this.fNow = fNow;
                IEnumerable<Food> f = food.Where(s => s.price+fNow.price < price);
                if(f.Count() > 0)
                    Print(f, 2);
            }
        }

        public void GetIngredients()
        {
            IEnumerable<Food> f = food.Where(s => s.GetType().ToString() == "sem4_3.Dish");

            Print(f, 3);
        }

        public void GetNonAlcoholic()
        {
            IEnumerable<Food> f = food.Where(s => s.IsAlcoholic() == 0);

            Print(f, 4);
        }

        public void GetDietary()
        {
            averagePrice = food.Where(s => s.IsAlcoholic() == 1).Average(s => s.price);
            IEnumerable<Food> f = food.Where(s => s.price < averagePrice && s.IsDietary() == 1);

            Print(f, 5);
        }

        public void Print()
        {
            Console.WriteLine("--------------------------------");
            foreach (Food fNow in food)
                Console.WriteLine(fNow.ToString());
        }

        void Print(IEnumerable<Food> f,int numTask)
        {
            Console.WriteLine("--------------------------------");
            switch(numTask){
                case 1:
                    {
                        foreach (Food fNow in f)
                            Console.WriteLine(fNow.name + " , " + fNow.UnitPrice());
                    } break;
                case 2:
                    {
                        foreach (Food result in f)
                            if (result != fNow)
                                Console.WriteLine(fNow.name + " " + result.name);
                    } break;
                case 3:
                    {
                        foreach (Food fNow in f)
                            Console.WriteLine(fNow.name + " : " + fNow.ListOfIngredients());    
                    } break;
                case 4:
                    {
                        foreach (Food fNow in f)
                            Console.WriteLine(fNow.name + " non-alcoholic");
                    } break;
                case 5:
                    {
                        foreach (Food fNow in f)
                            Console.WriteLine(fNow.name + " " + averagePrice);
                    } break;
            }
        }
    }
}
