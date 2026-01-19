using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exlinq
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Produto> produtos = new List<Produto>
            
            {new Produto("Celular",5000),
            new Produto("Lápis",5),
            new Produto("Mesa",1000),
            new Produto("Relógio",45)};

            List<Produto> produtos2 = new List<Produto>

            {new Produto("Celular",5000),
            new Produto("Lápis",5),
            new Produto("Lápis",5),
            new Produto("Lápis",5),
            new Produto("Mesa",1000),
            new Produto("Mesa",1000),
            new Produto("Relógio",45)};

            Action<List<Produto>> filtrar50 = list => list.
            Where(produto => produto.Preco > 50)
            .ToList().
            OrderByDescending(produ => produ.Preco).
            Reverse().
            ToList().
            ForEach(u => Console.WriteLine(u.Nome));

            //filtrar50(produtos);

            /*Lista de Vendas*/

            Venda venda1 = new Venda(produtos);
            Venda venda2 = new Venda(produtos2);

            List<Venda> vendasProdutos = new List<Venda>();
            vendasProdutos.Add(venda1);
            vendasProdutos.Add(venda2);

            Func<List<Venda>, double> totalVendas = vendas =>
            {
                var total = 0.0;
                foreach(Venda vend in vendas)
                {
                    total = total + vend.CalculaTotal();
                }

            return total;
            };

            //
            Func<List<Venda>, List<Tuple<string, double, double, double>> > mediaPorProduto = listaVendas =>
            {

                var list = listaVendas.Select(prop => prop.produtos).ToList();

                List<Produto> listaTotal = new List<Produto>();
                foreach (var prop in list)
                {
                
                    foreach(Produto prod in prop)
                    {
                       listaTotal.Add(prod);
                    }

                }
                    var resultado = listaTotal.GroupBy(pro => pro.Nome)
                    .Select(g => new
                    {
                        Nome = g.FirstOrDefault().Nome,
                        Quantidade = g.Count(),
                        PrecoTotal = g.Sum(p => p.Preco),
                        PrecoMedio = g.Average(p => p.Preco)
                    });

                    //resultado.ToList().ForEach(u => Console.WriteLine(u));

                //var resultadoFinal = resultado.GroupBy(prodc => prodc.Nome).Select(g => new
                //{
                //    Nome = g.First().Nome,
                //    Quantidade = g.Sum(p => p.Quantidade)
                //});
                //resultadoFinal.ToList().ForEach(u => Console.WriteLine(u));

                List < Tuple<string, double, double, double> > listaFinal = new List<Tuple<string, double, double, double>>();
                foreach (var result in resultado.ToList())
                {
                    var tupla = new Tuple<string,double, double, double> (result.Nome, result.Quantidade,result.PrecoTotal,result.PrecoMedio);
                    listaFinal.Add(tupla);
                }

                return listaFinal;
                
            };

            mediaPorProduto(vendasProdutos).ForEach(prod => Console.WriteLine(prod));
        }
    }

        public class Produto
        {
            public string Nome;
            public int Preco;

            public Produto(string Nome, int Preco)
            {
                this.Nome = Nome;
                this.Preco = Preco;
            }

        public override string ToString()
        {
            return "Nome: " + Nome + " Preço: " + Preco;
        }
    }

        public class Venda
        {
            public List<Produto> produtos;

            public Venda(List<Produto> produtos)
            {
                this.produtos = produtos;
            }

            public double CalculaTotal()
            {
                double soma = 0;

                foreach(Produto prod in this.produtos)
                {
                    Console.WriteLine("Produto: "+ prod.Nome + " Valor: "+ prod.Preco);
                    soma = soma + prod.Preco;
                }

                    Console.WriteLine("Total da Venda: "+ soma +"\n");
                
                return soma;
            }
        }

    }

