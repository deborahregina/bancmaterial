using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> ehPar = (int x) => (x % 2 == 0) ? true : false;

            Console.WriteLine("Número é par? 2 - "+ ehPar(2));
            Console.WriteLine("Número é par? 3 - "+ ehPar(3));

            Action<int> calculaQuadrado = (int x) => Console.WriteLine("Quadrado de " + x + " é: " + Math.Pow(x, 2));

            calculaQuadrado(2);
            calculaQuadrado(7);

            Func<string,string> converteMaiusculo = (string x) => x.ToUpper();

            Console.WriteLine(converteMaiusculo("gato"));
            Console.WriteLine(converteMaiusculo("cachorro"));

            Func<List<int>,List<int>> filtrarPares = list =>
            { 
                Console.WriteLine("Lista Original:");
                
                list.Select((x,i) => new {Index = i, Value = x }).ToList().ForEach( u =>
                {
            
                if(u.Index < list.Count - 1)
                    {
                        Console.Write(u.Value + ",");
                    } else
                    {
                        Console.Write(u.Value + "\n");
                    }
                    
                });
                
   
                Console.WriteLine("\nLista Filtrada:");

                foreach (var numero in list.Where(n => n % 2 == 0).Select(
                    (x, i) => new { Index = i, Value = x }))
                {
                    if(numero.Index < list.Where(n => n%2 ==0).ToList().Count -1)
                    {
                        Console.Write(numero.Value + ",");
                    } else
                    {
                        Console.Write(numero.Value + "\n");
                    }
                    
                    
                }
                return list;
            };

            List<int> lista = filtrarPares(new List<int> { 1,2,3,4,5,6,7,8});

            Func<List<int>, List<int>> OrdemCrescente = (numbers) => numbers.OrderBy(x => x).ToList();

            List<int> lista1 = OrdemCrescente(new List<int> { 13, 21, 3, 445, 52, 61, 7, 18 });

            lista1.Select((x, i) => new { Index = i, Value = x }).ToList().ForEach(u =>
            {

                if (u.Index < lista1.Count - 1)
                {
                    Console.Write(u.Value + ",");
                }
                else
                {
                    Console.Write(u.Value + "\n");
                }

            });

            Func<List<int>, int> SomaMaior10 = numbers =>
            {
                int soma = 0;

                numbers = numbers.Where(u => u>10).ToList();

                numbers.ForEach(u => soma = soma + u);

                numbers.Select((x, i) => new { Index = i, Value = x }).ToList().ForEach(u =>
                {

                    if (u.Index < numbers.Count - 1)
                    {
                        Console.Write(u.Value + ",");
                    }
                    else
                    {
                        Console.Write(u.Value + "\n");
                    }

                });
                return soma;
            };

            Console.WriteLine(SomaMaior10(new List<int> { 1,2,3,10,20,30,50,100}));
        }

     
    }




}
