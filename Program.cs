using System;
using System.IO;
using System.Text.Json;

namespace Task16
{
    class Program
    {   
        static Product[] arr = new Product[5];
        static void Main(string[] args)
        {
            //заполняем массив значениями
            /*for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Product()
                {
                    ProductCode = int.Parse(Console.ReadLine()),
                    ProductName = Console.ReadLine(),
                    ProductPrice = double.Parse(Console.ReadLine())
                };
            }*/
            /* пример заполнения для проверки  */
            arr[0] = new Product() { ProductCode = 1, ProductName = "name1", ProductPrice = 10 };
            arr[1] = new Product() { ProductCode = 2, ProductName = "name2", ProductPrice = 12 };
            arr[2] = new Product() { ProductCode = 3, ProductName = "name3", ProductPrice = 14 };
            arr[3] = new Product() { ProductCode = 4, ProductName = "name4", ProductPrice = 16 };
            arr[4] = new Product() { ProductCode = 5, ProductName = "name5", ProductPrice = 120 };
           

            //запускаем метод для сериализации и записи в файл по пути D:\Product.json
            Json.Serialize(arr);
            // читаем из файла по указанному пути и десериализируем 
            var arr2 = Json.DeSerialize(@"C:\Users\kamru\Downloads\Task16\Task16\bin\Debug\Product.json");
            double highestPrice = 0;
            int idx = 0;
            // находим наибольшую стоимость и запоминаем индекс
            for (int i = 0; i < arr2.Length; i++)
            {
                if (arr2[i].ProductPrice > highestPrice)
                {
                    highestPrice = arr2[i].ProductPrice;
                    idx = i;
                }
            }
            Console.WriteLine($"{arr2[idx].ProductName} - самый дорогой продукт с ценой: {highestPrice}");

        }
    }
    class Json
    {
        public static void Serialize(Product[] arr)
        {
            string json = JsonSerializer.Serialize(arr);
            //Console.WriteLine(json);
            File.WriteAllText(@"C:\Users\kamru\Downloads\Task16\Task16\bin\Debug\Product.json", json);
        }
        public static Product[] DeSerialize(string path)
        {
            string text = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Product[]>(text);
        }
    }
    public class Product
    {
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
    }
}
