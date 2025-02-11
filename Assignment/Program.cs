using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading;
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
            #region LINQ - Ordering Operators
            // 1. Sort a list of products by name
            //var output = ProductList.OrderBy(p=>p.ProductName);
            //foreach (var item in output)
            //{
            //    Console.WriteLine(item.ProductName);
            //}

            //2. Uses a custom comparer to do a case-insensitive sort of the words in an array.
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var output = Arr.OrderBy(s => s  ,  StringComparer.CurrentCultureIgnoreCase);
            //var output = Arr.OrderBy(s => s, StringComparer.OrdinalIgnoreCase);
            //foreach (var item in output)
            //{
            //    Console.WriteLine(item);
            //}

            //3. Sort a list of products by units in stock from highest to lowest.
            //var output = ProductList.OrderByDescending(p => p.UnitsInStock);
            //foreach (var item in output)
            //{
            //    Console.WriteLine(item);
            //}

            // 4.Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //var sortedArr = Arr.OrderBy(s => s.Length).ThenBy(s => s);
            //foreach (var digit in sortedArr)
            //{
            //    Console.WriteLine(digit);
            //}

            // 5. Sort first by-word length and then by a case-insensitive sort of the words in an array.
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var sortedArr = Arr.OrderBy(s => s.Length).ThenBy(s => s, StringComparer.CurrentCultureIgnoreCase);
            //foreach (var item in sortedArr)
            //{
            //    Console.WriteLine(item);
            //}

            //6.Sort a list of products, first by category, and then by unit price, from highest to lowest.
            //var output = ProductList.OrderBy(x => x.Category ).ThenByDescending(x => x.UnitPrice);
            //foreach (var item in output)
            //{
            //    Console.WriteLine($"Product Name : {item.ProductName} , category: {item.Category}  , unitprice: {item.UnitPrice}" );
            //}


            //7.Sort first by-word length and then by a case -insensitive descending sort of the words in an array.
            // string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            // var output = Arr.OrderBy(x => x.Length).ThenByDescending(x=>x,StringComparer.OrdinalIgnoreCase);
            // foreach (var item in output)
            // {
            //    Console.WriteLine(item);
            // }

            //  8.Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
            //string[] Arr = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
            //var output = Arr.Where(s=>s.Length>1 && s[1] == 'i').Reverse();
            //foreach (var item in output)
            //{
            //   Console.WriteLine(item);
            //}

            #endregion
            #region LINQ – Transformation Operators
            // 1. Return a sequence of just the names of a list of products.
            //var result = ProductList.Select(x => x.ProductName);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item); 
            //}


            // 2. Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).
            //string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            //var output = words.Select(x => new { lowercase = x.ToLower(), uppercase = x.ToUpper() });
            //foreach (var item in output)
            //{
            //    Console.WriteLine(item);
            //}

            // 3.Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.
            //var productProperties = ProductList.Select(p => new
            //{
            //    Name = p.ProductName,
            //    Price = p.UnitPrice, // UnitPrice renamed to Price  
            //    category = p.Category
            //});

            //foreach (var item in productProperties)
            //{
            //    Console.WriteLine($"Name: {item.Name}, Price: {item.Price}, Category: {item.category}");
            //}

            // 4.Determine if the value of int in an array matches their position in the array.
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var output = Arr.Where((arr, i) => arr.Equals(i));
            //foreach (var item in output)
            //{
            //    Console.WriteLine(item);
            //}
            // Another Way
            //int[] Arr = { 5, 4, 1, 3, 9, 6, 7, 2, 0 };
            //var matchesPosition = Arr.Select((value, index) => new{Number = value,Index = index, Matches = (value == index)});
            //foreach (var item in matchesPosition)
            //{
            //    Console.WriteLine($"Number: {item.Number}, Index: {item.Index}, Matches: {item.Matches}");
            //}


            // 5.Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.
            //int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            //int[] numbersB = { 1, 3, 5, 7, 8 };
            //var   pairs    = numbersA.SelectMany( a => numbersB.Where( b => a < b ) , (a, b) => new { a, b } );
            //foreach (var pair in pairs)
            //{
            //   Console.WriteLine($"{pair.a} is less than {pair.b}");
            //}


            //// 6.Select all orders where the order total is less than 500.00.
            //var cheapOrders = CustomerList.Where(p => p.Orders == 500.00m);


            //// 7.Select all orders where the order was made in 1998 or later.
            //var oldOrders = Order.Where(o => o.orderDate.Year >= 1998);
            #endregion
            #region LINQ - Set Operators
            // 1.Find the unique Category names from Product List
            //var result = ProductList.DistinctBy(x => x.Category);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Category);
            //}


            // 2.Produce a Sequence containing the unique first letter from both product and customer names.
            //var result = ProductList.Select(p => p.ProductName.Substring(0, 1)).Union(CustomerList.Select(c => c.CustomerName.Substring(0, 1))).Distinct();
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}


            // 3.Create one sequence that contains the common first letter from both product and customer names.
            //var result = ProductList.Select(p => p.ProductName.Substring(0, 1)).Intersect(CustomerList.Select(c => c.CustomerName.Substring(0, 1))).Distinct();
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            // 4.Create one sequence that contains the first letters of product names that are not also first letters of customer names.
            //var productFirstLetters  = ProductList.Select (p => p.ProductName.Substring(0, 1));
            //var customerFirstLetters = CustomerList.Select(c => c.CustomerName.Substring(0, 1));
            //var productOnlyFirstLetters = productFirstLetters.Except(customerFirstLetters).Distinct();
            //foreach (var item in productOnlyFirstLetters)
            //{
            //    Console.WriteLine(item);
            //}

            // 5.Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates
            //var customerLastThree = CustomerList.Select(c => c.CustomerName.Length >= 3 ? c.CustomerName.Substring(c.CustomerName.Length - 3) : c.CustomerName);
            //var productLastThree  = ProductList.Select(p => p.ProductName.Length >= 3 ? p.ProductName.Substring(p.ProductName.Length - 3) : p.ProductName);
            //var result = customerLastThree.Concat(productLastThree);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
            #region LINQ - Partitioning Operators
            // 1.Get the first 3 orders from customers in Washington
            //var result = CustomerList.Where(c => c.Address == "Washington")  
            //                         .SelectMany(c => c.Orders)  
            //                         .Take(3);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}


            // 2.Get all but the first 2 orders from customers in Washington.
            //var result = CustomerList.Where(c => c.Region == "Washington")
            //                                          .SelectMany(c => c.Orders)
            //                                           .Skip(2);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}


            // 3.Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.
            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var output = numbers.TakeWhile((number, index) => number >= index);
            //foreach (var item in output)
            //{
            //    Console.WriteLine( item);
            //}

            //4.Get the elements of the array starting from the first element divisible by 3.
            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var output = numbers.SkipWhile(number => number % 3 != 0);
            //foreach (var item in output)
            //{
            //    Console.WriteLine(item);
            //}


            //5.Get the elements of the array starting from the first element less than its position.
            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var output = numbers.SkipWhile((number, index) => number >= index);
            //foreach (var item in output)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
            // 11 // 6 , 7   // 6.Select all orders where the order total is less than 500.00.
            // var cheapOrders = CustomerList.Where(p => p.Orders == 500.00m);


            // 7.Select all orders where the order was made in 1998 or later.
            //var oldOrders = Order.Where(o => o.orderDate.Year >= 1998);
        }
    }
}
