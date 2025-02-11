namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Filtration Operator - Where & OfType
            // LINQ                    :: 40+ Extension methods
            // LINQ                    :: 13 Category ==> 10 differd & 3 immediate (Elemnt operator - aggregation operator - casting operator ))            
            // 01.Filteration operator :: where - OfType == [Differd]
            // By fluent syntax :: 
            // var result = ProductList.Where( p=> p.UnitsInStock == 0);
            // By Query Expression ::
            // var result = from P in ProductList 
            //             where P.UnitsInStock == 0 // filtration
            //             select P;
            // var result = ProductList.Where(P => P.Category == "Meat/Poultry" && P.UnitsInStock != 0);
            //var result = from P in ProductList
            //             where P.Category == "Meat/Poultry" && P.UnitsInStock != 0
            //             select P;
            //var result = ProductList.Where(P => P.Category == "Meat/Poultry" ).Where( P=>P.UnitsInStock != 0);
            //var result = from P in ProductList
            //             where P.Category == "Meat/Poultry" 
            //              where P.UnitsInStock != 0
            //             select P;


            // Indexed where : valid in fluent syntax , can't be written using query syntax (query expression)
            //var result= ProductList.Where((P,Index )=>P.UnitsInStock == 0 && Index<10);
            //var result = ProductList.Where((P, Index) =>Index < 5);
            //var result = ProductList.Where(P => P.UnitsInStock > 0).Where((P, i) => i < 5);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            //ArrayList arrayList = new ArrayList() { "shimaa", "ali", "ahmed" , "nour" , "ibrahim", 1,3,5,9 ,1.5,1.2,1.8f,1.4m , ProductList[0], ProductList[3] };
            //arrayList.OfType<string>();
            //foreach (var item in arrayList.OfType<Product> ())
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
            #region Transformation Operators - Select, SelectMany
            // Select - SelectMany [Differd]
            // By Fluent Syntax
            //   var output = ProductList.Select(p => p);
            //   var output = ProductList.Select(p => p.ProductName);

            // By Query Expression
            //var output = from P in ProductList
            //             select P;
            //var output = from P in ProductList
            //             select P.ProductName;

            //var output = ProductList.Where(P => P.UnitsInStock > 0 && P.Category == "Seafood")
            //                        .Select(P => P.ProductName);

            //var output = ProductList.Where(P => P.UnitsInStock > 0 && P.Category == "Seafood")
            //                        .Select( P => new 
            //                               { P.ProductName ,
            //                                 P.Category , 
            //                                 OldPrice=P.UnitPrice , 
            //                                 NewPrice = P.UnitPrice - P.UnitPrice *.1m
            //                               });

            //var output = from p in ProductList
            //             where p.UnitsInStock > 0 && p.Category == "Seafood"
            //             select new 
            //                    {  name = p.ProductName,
            //                       category = p.Category,
            //                       OldPrice = p.UnitPrice,
            //                       NewPrice = p.UnitPrice - p.UnitPrice *.1m  } ;
            // var output = CustomerList.Select(p => p.Orders);// name space

            // use SelectMany ==> if one of the property is sequence 
            //var output = CustomerList.SelectMany(p => p.Orders); 
            //var output = from c in CustomerList
            //             from o in c.Orders
            //             select o;
            // Indexed Select:: Valid in Fluent Syntax Can't be written using query syntax (query expression)
            //var output = ProductList.Select((p, i) =>new {i, p.ProductName }).Where(p => p.i < 5);
            //foreach (var item in output)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
            #region Ordering Operators
            // Sorting :: OrderBy() ==>[Differd]
            //var output = ProductList.OrderBy(P => P.UnitsInStock)
            //                        .Select(p=>new { p.ProductName, p.Category });
            //var output = ProductList.OrderByDescending(P => P.UnitsInStock)
            //                        .ThenBy(p => p.UnitPrice)
            //                        .Select(p => new { p.ProductName, p.UnitPrice, p.UnitsInStock });
            //var output = ProductList.OrderByDescending(P => P.UnitsInStock)
            //                       .ThenByDescending(p => p.UnitPrice)
            //                       .Select(p => new { p.ProductName, p.UnitPrice, p.UnitsInStock });

            //var output = ProductList.Where(p=>p.Category == "Meat/Poultry"  && p.UnitsInStock > 0)
            //                        .OrderBy(P => P.UnitsInStock)
            //                        .ThenByDescending(p => p.UnitPrice)
            //                        .Select(p => new { p.ProductName, p.UnitPrice, p.UnitsInStock });

            // NOTE :: must use ThenBy after OrderBy direct 

            //var output = from p in ProductList
            //             where p.Category == "Meat/Poultry" && p.UnitsInStock > 0
            //             orderby p.UnitsInStock , p.UnitPrice descending
            //             select new
            //             { p.ProductName, p.UnitPrice, p.UnitsInStock };


            //var output = ProductList.Reverse<Product>();
            //foreach (var item in output)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
            #region Element Operators - Immediate Execution
            // var output = ProductList.First();
            // var output = ProductList.Last()
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //ProductList = new List<Product>(); // make product list empty
            //var output = ProductList.First();  // May Throw Exception  [Sequence contains no elements]
            //var output = ProductList.Last();  // May Throw Exception   [Sequence contains no elements]
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //var output = ProductList.First(p => p.UnitsInStock > 10);
            //var output = ProductList.Last(p => p.UnitsInStock > 10);
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //ProductList = new List<Product>();
            //var output = ProductList.FirstOrDefault();  // LastOrDefault() ==> the same action
            //Console.WriteLine(output?.ProductName ?? "null" ); // null [? null propagation operator , ?? null coleasing(law b null etb3 null)]
            //===
            //ProductList = new List<Product>();
            //var output = ProductList.FirstOrDefault(new Product() { ProductName = "Default Product" }); // don't throw exception
            //Console.WriteLine(output.ProductName);// Default Product
            //var output = ProductList.FirstOrDefault(p => p.UnitsInStock < 0,new Product() { ProductName = "Default Product" }); // don't throw exception
            //Console.WriteLine(output.ProductName);// Default Product

            //var output = ProductList.ElementAt(0);// may throw exception [index out of range]
            //var output = ProductList.ElementAtOrDefault(1000);//null
            //var output = ProductList.Single(); // may through exception ==> Sequence contains more than one element
            //var output = ProductList.Single(p=>p.UnitsInStock==0); // may through exception ==> Sequence contains more than one matching element
            //var output = ProductList.SingleOrDefault(); // if sequence empty ==> will return null
            //ProductList = new List<Product>();
            //var output = ProductList.SingleOrDefault(p => p.ProductID == 5, new Product { ProductName = "single default" }); // single default
            //Console.WriteLine(output?.ProductName ?? "null");

            //var output = ProductList.DefaultIfEmpty();
            //foreach (var item in output)
            //{
            //    Console.WriteLine(item);
            //}

            //ProductList = new List<Product>();
            //var output = ProductList.DefaultIfEmpty();
            //foreach (var item in output)
            //{
            //    Console.WriteLine(item);
            //}

            //ProductList = new List<Product>();
            //var output = ProductList.DefaultIfEmpty(new Product() { ProductName = "Default" });
            //foreach (var item in output)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
            #region Aggregate Operators - Immediate Execution
            // count - sum - max - min - avg
            // var output = ProductList.Count();// 77
            //var output = ProductList.Count( p => p.UnitsInStock == 0);//5 empty in stock
            //var output = ProductList.Where(p => p.UnitsInStock == 0).Count();//5 empty in stock
            //var output = ProductList.Sum(p => p.UnitPrice);  // 2222.7100
            //var output = ProductList.Sum(p => p.UnitsInStock); // 3180
            //var output = ((float)ProductList.Average(p => p.UnitPrice));// 28.866363636363636363636363636
            //var output = ((int)ProductList.Average(p => p.UnitPrice));// 28
            //var output = ProductList.Max();// May throw exception ==>  At least one object must implement IComparable. so i did implemintation l IComparable<Product>
            //var output = ProductList.Max(p => p.UnitPrice); // 263.5000
            //var output = ((int)ProductList.Max(p => p.UnitPrice)); // 263

            //var output = ProductList.Max(new ProductComparerUnitInStock());
            //var output = ProductList.MaxBy(p => p.UnitsInStock);

            //var output = ProductList.Min();
            //var output = ProductList.MinBy(p => p.UnitPrice);
            //var output = ProductList.Min(new ProductComparerUnitInStockByName());

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~Aggrigate operator~~~~~~~~~~~~~~~~~~~~~~
            //List<string> strings = new List<string>() { "A", "B", "C", "D" };
            //var output = strings.Aggregate((S01,S02) => S01 + S02);     // ABCD
            //var output = strings.Aggregate((S01,S02) => $"{S01} {S02}");// A B C D
            //Console.WriteLine(output);
            #endregion
            #region Casting Operators - Immediate Execution 
            // List<Product> list =( List<Product>) ProductList.Where(p => p.UnitsInStock == 0); // In-Valid :: Unable to cast object
            //List<Product> list = ProductList.Where(p => p.UnitsInStock == 0).ToList(); // use ToList() to return sequence to list
            //Product[] array = ProductList.Where(p => p.UnitsInStock == 0).ToArray();
            //Dictionary<string , Product> keys = ProductList.Where(p => p.UnitsInStock == 0).ToDictionary(p=>p.ProductName);
            //HashSet<Product> HS = ProductList.Where(p => p.UnitsInStock == 0).ToHashSet();
            //foreach (var item in HS)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
            #region Generation Operators
            // Must be used as class member method to call it through "Enumrable"
            // Range - Empty - Repeat
            //var output = Enumerable.Range(1, 100);
            //var output = Enumerable.Empty<Product>().ToList(); // generate sequence empty from specific sequence

            //output.Add(new Product() { ProductName = "suchi" });
            //output.Add(new Product() { ProductName = "spaghti" });
            //var output = Enumerable.Repeat(ProductList[0], 3);
            //foreach (var item in output)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
            #region Set operator
            // set operator - union family
            // Union - Union All - Intersect - Except
            //var S01 = Enumerable.Range(1,100);
            //var S02 = Enumerable.Range(50, 149);
            //var result = S01.Union(S02); // Like union in SQL without dublication
            //var result = S01.Concat(S02); // Like union in SQL with dublication
            //result = result.Distinct(); // remove dublication
            //var result = S01.Intersect(S02); 
            //var result = S01.Except(S02);
            //foreach (var item in result) 
            //{
            //    Console.Write($"{item} ");
            //}
            #endregion
            #region Quantifier Operators - Return Boolean
            // Any - All - sequenceEqual - contains
            //var seq01 = Enumerable.Range(1 , 100);
            //var seq02 = Enumerable.Range(50, 100);
            // Any() ==> return true if there are one elemnt in the sequence [in sequence or match condition]
            //var result = seq01.Any();// true
            //var result = seq01.Any( N => N%2 == 0);
            //var result = ProductList.Any();// true
            //var result = ProductList.Any( p => p.UnitsInStock == 0 );// true

            //All() ==> return true if all elemnts in the sequence in sequence  match condition or sequence is empty
            //var result = ProductList.All(p => p.UnitsInStock == 0);// false
            //var result = ProductList.All(p => p.UnitPrice > 0); // true
            //var result = seq01.SequenceEqual(seq02);//false
            //var result = seq01.Contains(2);// true
            //Console.WriteLine(result);
            #endregion
            #region Zip Operator
            //List<string> strings = new List<string>() { "A", "B", "C", "D" };
            //List<int> ints       = new List<int>()    { 1, 2, 3, 4 , 4 , 5 };
            //var output = strings.Zip(ints, (s, i) => $"{i} ---> {s} ");
            //foreach (var item in output)
            //{
            //    Console.WriteLine(item);
            //}
            /*
             1 ---> A
             2 ---> B
             3 ---> C
             4 ---> D
             */
            #endregion
        }
    }
}
