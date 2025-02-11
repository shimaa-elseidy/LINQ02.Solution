using System.Xml.Linq;
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

        }
    }
}
