using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
Задача:
    Создать абстрактный класс Food (параметры - название, список ингредиентов, цена).
    Создать производные классы: Drink (алкогольный/неалкогольный, объем в мл), Dish (диетический/нет, масса в граммах)
    Создать пользовательскую коллекцию Menu, которая работает только с Food и производными от него классами.
    Заполнить коллекцию тестовыми данными (придумать самостоятельно Drink и Dish), не менее 20
    Написать  для заполненных тестовыми данными коллекций запросы на LINQ  как методы коллекции:
        - упорядочить все товары по цене за грамм или за мл
        - найти все возможные комбинации dish+drink, цена которых менее, указанной в аргументе
        - получить все ингредиенты из всех блюд
        - получить только безалкогольные напитки
        - получить только диетические блюда, которые дешевле средней цены алкогольных напитков
*/
namespace sem4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu m = new Menu();
            List<string> ingredients = new List<string>(), ingredients2 = new List<string>();
            ingredients.Add("тесто");
            ingredients.Add("яйца");
            ingredients.Add("капуста");

            ingredients2.Add("кетчуп");
            ingredients2.Add("тесто");
            ingredients2.Add("колбаса");
            m.Add(new Dish("пирожок", ingredients, 25.5, true, 300));
            m.Add(new Drink("выпивка1", ingredients, 25.5, true, 500));
            m.Add(new Dish("пицца", ingredients2, 55.5, true, 500));
            m.Add(new Drink("выпивка2", ingredients2, 85.5, true, 200));
            m.Add(new Dish("блюдо3", ingredients, 35.5, false, 400));
            m.Add(new Dish("блюдо4", ingredients2, 45.5, false, 600));
            m.Add(new Drink("выпивка3", ingredients2, 95.5, false, 300));
            m.Add(new Drink("выпивка4", ingredients2, 25.5, true, 200));
            m.Add(new Drink("выпивка5", ingredients2, 15.5, false, 100));
            m.Add(new Dish("блюдо5", ingredients2, 65.5, true, 700));

            m.Print();

            m.OrderByUnitPrice();

            m.GetDishAndDrink(100);

            m.GetIngredients();

            m.GetNonAlcoholic();

            m.GetDietary();


            Console.Read();
        }
    }
}
