using System;
using System.Linq;

namespace Course // Note: actual namespace depends on the project name.
{
    public class Program
    {
        // É um conjunto de tecnologias baseadas na integração de funcionalidades de
        //consulta diretamente na linguagem C#

        //• Criar um data source (coleção, array, recurso de E/S, etc.)
        //• Definir a query
        //• Executar a query(foreach ou alguma operação terminal

        static void Main(string[] args)
        {
            // Specify the data source.
            int[] numbers = new int[] { 2, 3, 4, 5 };

            // Define the query expression.
            var result1 = numbers.Where(x => x % 2 == 0).Select(x => x * 10); // Same method below
                                                         

            IEnumerable<int> result = numbers
            .Where(x => x % 2 == 0) //Where filters the data source based on a predicate(argument)
            .Select(x => 10 * x); // Select method a pipeline that applies another function in the partial result of the Where method

            // Execute the query.
            foreach (int x in result)
            {
                Console.WriteLine(x);
            }

        }
    }
}
