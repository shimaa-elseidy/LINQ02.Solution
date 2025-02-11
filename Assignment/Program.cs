using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Assignment.ListGenerator;
namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region LINQ - Restriction Operators
            // 1.Find all products that are out of stock.
            // By Fluent Sequence
            // var output = ProductList.Where(P => P.UnitsInStock == 0).ToList();
            // By Query Syntax (Expression)
            // var output = from p in ProductList
            //             where p.UnitsInStock == 0
            //             select p;

            // 2. Find all products that are in stock and cost more than 3.00 per unit.
            // By Fluent Sequence
            // var output = ProductList.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00m);
            // By Query Syntax (Expression)
            // var output = from p in ProductList
            //             where p.UnitsInStock > 0 && p.UnitPrice > 3.00m
            //             select p;
            // foreach (var item in output)
            // {
            //    Console.WriteLine(item);
            // }

            //3.Returns digits whose name is shorter than their value.
            //String[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            // By Fluent Sequence
            //var output = Arr.Where((p,i) => p.Length < i);
            // By Query Syntax (Expression)
            //var output = from i in Enumerable.Range(0, Arr.Length)
            //             let p = Arr[i]
            //             where p.Length < i
            //             select p;
            //foreach (var item in output)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
            #region LINQ - Element Operators

            // 1. Get first Product out of Stock 
            // Fluent Syntax  
            // var output = ProductList.FirstOrDefault(p => p.UnitsInStock == 0);
            // Query Syntax  
            //var output = (from p in ProductList
            //              where p.UnitsInStock == 0
            //              select p)
            //              .FirstOrDefault();
            // May Through Exception :: NullReferenceException
            //string message = output == null ? $"First out of stock product: {output.ProductName}" : $"First out of stock product: {output.ProductName}";
            //Console.WriteLine(message);

            // 2.Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
            // Fluent Syntax
            //var output = ProductList.FirstOrDefault(p => p.UnitPrice > 1000);
            // Query Syntax 
            //var output = (from p in ProductList
            //              where p.UnitPrice>1000
            //              select p).FirstOrDefault();
            //Console.WriteLine(output?.UnitPrice.ToString()?? "null");

            // 3.Retrieve the second number greater than 5
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // Fluent Syntax  
            //int? output = Arr.Where(x => x > 5).Skip(1).FirstOrDefault();
            // Query Syntax  
            //int? output = (from   x in Arr
            //               where  x > 5
            //               select x ).Skip(1).FirstOrDefault();

            //Console.WriteLine(output.HasValue ? output.Value.ToString() : "null");
            #endregion
            #region LINQ - Aggregate Operators

            // 1.Uses Count to get the number of odd numbers in the array
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            // By Fluent Syntax
            //int oddCount = Arr.Count(x => x % 2 != 0);
            // By query Syntax
            //var oddCount = (from p in Arr
            //               select p).Count(x => x % 2 != 0);
            //Console.WriteLine(oddCount); 

            //2.Return a list of customers and how many orders each has.
            //fluentsyntax
            //var output = CustomerList.Select(c => new { customer = c, orderCount = c.Orders.Count() });
            //query syntax
            //var output = from c in CustomerList
            //             select new { customer = c, orderCount = c.Orders.Count() } ;
            //foreach (var item in output)
            //{
            //    Console.WriteLine($"Customer: {item.customer.CustomerName}, Order Count: {item.orderCount}");
            //}


            // 3. Return a list of categories and how many products each has
            // Fluent syntax
            //var output = ProductList.GroupBy(x  => x.Category)
            //                        .Select ( g => new {  g.Key, ProductCount = g.Count() });
            //query syntax
            //var output = from x in ProductList
            //             group x by x.Category
            //             into g
            //             select new { g.Key, ProductCount = g.Count() };

            //foreach (var item in output)
            //{
            //    Console.WriteLine(item);
            //}


            //4.Get the total of the numbers in an array.
            // int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            // var output = Enumerable.Sum(Arr);
            // var output = Arr.Sum();
            // Console.WriteLine(output);

            //5. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            //string[] words = File.ReadAllLines("dictionary_english.txt");
            //int totalChars = words.Sum(word => word.Length);
            //Console.WriteLine(totalChars);

            //6. Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            //string[] words = File.ReadAllLines("dictionary_english.txt");
            //int ShortLen   = words.Min( x => x.Length );
            //Console.WriteLine(ShortLen);

            //7.Get the length of the longest word in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            //string[] words = File.ReadAllLines("dictionary_english.txt");
            //int MaxLen = words.Max(x => x.Length);
            //Console.WriteLine(MaxLen);

            //8.Get the average length of the words in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            //string[] words = File.ReadAllLines("dictionary_english.txt");
            //var avg = words.Average(x => x.Length);
            //Console.WriteLine(avg);//9.442576175563836

            // 9. Get the total units in stock for each product category.
            // by fluent syntax
            //var categoryUnits = ProductList.GroupBy(p => p.Category)
            //                               .Select( g => new{ Category = g.Key ,TotalUnits = g.Sum (p => p.UnitsInStock)});
            // by query syntax
            //var categoryUnits = from p in ProductList
            //                    group p by p.Category
            //                    into o
            //                    select new { Category = o.Key, TotalUnits = o.Sum(o => o.UnitsInStock) };
            //foreach (var item in categoryUnits)
            //{
            //    Console.WriteLine($"Category: {item.Category}, Total Units: {item.TotalUnits}");
            //}


            //10.Get the cheapest price among each category's products
            // fluent syntax
            //var cheapestProduct = ProductList.GroupBy(p => p.Category).Select(p => new { p.Key, cheapestprice = p.Min(p => p.UnitPrice) });
            //by query syntax
            //var cheapestProduct = from p in ProductList
            //                      group p by p.Category
            //                      into output
            //                      select  new { output.Key, cheapestprice = output.Min(output=> output.UnitPrice) };
            //foreach (var item in cheapestProduct)
            //{
            //    Console.WriteLine(item);
            //}

            ////11.Get the products with the cheapest price in each category(Use Let)
            //var cheapestProduct = from p in ProductList
            //                      let output = group p by p.Category
            //                      select new { output.Key, cheapestprice = output.Min(output => output.UnitPrice) };
            //foreach (var item in cheapestProduct)
            //{
            //    Console.WriteLine(item);
            //} 

            //12.Get the most expensive price among each category's products.
            //var mostExpensivePrices = ProductList.GroupBy(p => p.Category).Select(g => new{Category = g.Key,MostExpensivePrice = g.Max(p => p.UnitPrice)});
            //foreach (var item in mostExpensivePrices)
            //{
            //    Console.WriteLine($"Category: {item.Category}, Most Expensive Price: {item.MostExpensivePrice}");
            //}

            //13.Get the products with the most expensive price in each category.
            //var mostExpensiveProducts = ProductList.GroupBy(p => p.Category).Select(g => new{  Category = g.Key,MostExpensiveProduct = g.OrderByDescending(p => p.UnitPrice).FirstOrDefault()});
            //foreach (var item in mostExpensiveProducts)
            //{
            //    Console.WriteLine($"Category: {item.Category}, Most Expensive Product: {item.MostExpensiveProduct}, Price: {item.MostExpensiveProduct.UnitPrice}");
            //}

            //14.Get the average price of each category's products.
            //var averagePrices = ProductList.GroupBy(p => p.Category).Select(g => new{Category = g.Key, AveragePrice = g.Average(p => p.UnitPrice)});
            //foreach (var item in averagePrices)
            //{
            //    Console.WriteLine($"Category: {item.Category}, Average Price: {item.AveragePrice}");
            //}
            #endregion
            // 11
        }
    }
}
