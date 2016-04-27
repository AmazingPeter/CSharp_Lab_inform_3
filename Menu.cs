using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sem4_3
{
    class Menu : ICollection<Food>
    {
        public List<Food> food = new List<Food>();

        private double averagePrice;

        private bool isReadOnly = false;

        public void Add(Food f)
        {
            food.Add(f);
        }

        public void OrderByUnitPrice()//Цена за единицу
        {
            IEnumerable<Food> f = food.OrderBy(s => s.UnitPrice());
            int len = food.Count();
            food.InsertRange(len, f);//вставляем отсортированный
            food.RemoveRange(0, len);//удаляем старый

            Print(f, 1);

        }

        public void GetDishAndDrink(double price)
        {
            var f = food.SelectMany((oneFood, i) => food
                .Where((s, j) => s.price + oneFood.price < price && i != j && (oneFood is Dish && s is Drink))
                .Select(s => new { name1=oneFood.name, name2=s.name }));
                if (f.Count() > 0)
                    Console.WriteLine("--------------------------------");
                    foreach (var result in f)
                        Console.WriteLine(result.name1 + " " + result.name2);
        }

        public void GetIngredients()
        {
            IEnumerable<Food> f = food.Where(s => s is Dish);

            Print(f, 2);
        }

        public void GetNonAlcoholic()
        {
            IEnumerable<Food> f = food.Where(s => s is Drink && s.IsAlcoholic() == false);

            Print(f, 3);
        }

        public void GetDietary()
        {
            averagePrice = food.Where(s => s is Drink && s.IsAlcoholic() == true).Average(s => s.price);
            IEnumerable<Food> f = food.Where(s => s is Dish && s.IsDietary() == true && s.price < averagePrice);

            Print(f, 4);
        }

        public void Print()
        {
            Console.WriteLine("--------------------------------");
            foreach (Food fNow in food)
                Console.WriteLine(fNow.ToString());
        }

        void Print(IEnumerable<Food> f, int numTask)
        {
            Console.WriteLine("--------------------------------");
            switch (numTask)
            {
                case 1:
                    {
                        foreach (Food fNow in f)
                            Console.WriteLine(fNow.name + " , " + fNow.UnitPrice());
                    } break;
                case 2:
                    {
                        foreach (Food fNow in f)
                            Console.WriteLine(fNow.name + " : " + fNow.ListOfIngredients());
                    } break;
                case 3:
                    {
                        foreach (Food fNow in f)
                            Console.WriteLine(fNow.name + " non-alcoholic");
                    } break;
                case 4:
                    {
                        foreach (Food fNow in f)
                            Console.WriteLine(fNow.name + " " + averagePrice);
                    } break;
            }
        }


        public void Clear()
        {
            food.Clear();
        }

        public bool Contains(Food item)
        {
            return food.Contains(item);
        }

        public void CopyTo(Food[] array, int arrayIndex)
        {
            food.CopyTo(array,arrayIndex);
        }

        public int Count
        {
            get { return food.Count; }
        }

        public bool IsReadOnly
        {
            get { return isReadOnly; }
        }

        public bool Remove(Food item)
        {
            return food.Remove(item);
        }

        public IEnumerator<Food> GetEnumerator()
        {
            return food.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return food.GetEnumerator();
        }
    }
}
