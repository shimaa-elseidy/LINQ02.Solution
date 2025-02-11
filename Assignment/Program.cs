using System.Diagnostics;
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
            #endregion
        }
    }
}
