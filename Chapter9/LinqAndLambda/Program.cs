using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqAndLambda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var array = new[] { 1, 2, 3, 4 };
            var result =
                from i in array
                select i * 2;

            // if you hover over the select, then the Intelisense shows in the popup
            // (extension) IEnumerable<int> IEnumerable<int>.Select<int,int>(Func<int, int> selector)
            // everytime when a method uses the Func<int,int> you can call a lambda expression
            // like this:

            var resultWithLambda = array.Select(i => i * 2);

            foreach (var i in result)
                Console.WriteLine(i);
            foreach (int i in resultWithLambda)
                Console.WriteLine(i);


            int[] values = new int[] { 0, 12, 44, 36, 92, 54, 13, 8 };
            IEnumerable<int> result2 = 
                from v in values
                where v < 37
                orderby -v
                select v;

            // where and orderby (when hovering over it with the mouse) having Func<> in their methods
            // so it should be 

            var result2WithLambda = 
                values
                .Where(v => v < 37)
                .OrderBy(v => -v)
                .Select(v => v);

            // It's possible to leave the select, if the result should not be changed like above i => i * 2
            var result2WithLambda2 =
                values
                .Where(v => v < 37)
                .OrderBy(v => -v);

            // OrderBy -v (descending) is also possible with

            var result2WithLambda3 =
                values
                .Where(v => v < 37)
                .OrderByDescending(v => v);

            foreach (var v in result2)
                Console.WriteLine(v);
            foreach (var v in result2WithLambda)
                Console.WriteLine(v);
            foreach (var v in result2WithLambda2)
                Console.WriteLine(v);
            foreach (var v in result2WithLambda3) Console.WriteLine(v);

            int[] values2 = new int[] { 0, 12, 44, 92, 36, 0, 92, 54, 13, 8 };

            var resultWithLambdaV2 =
                values2
                .GroupBy(v => v)
                .OrderByDescending(v => v.Key)
                .Select(v => v.Key.ToString());

            foreach (var v in resultWithLambdaV2) Console.WriteLine(v);

        }
    }
}
