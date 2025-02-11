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
        }
    }
}
