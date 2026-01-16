using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dia2
{
    class Program
    {
        public static void Main(string[] args)
        {
            Movimentacao movimentacao1 = new Movimentacao(1, -20, "Compra Mercado");
            Movimentacao movimentacao2 = new Movimentacao(2, 120, "Pix Recebido");
            Movimentacao movimentacao22 = new Movimentacao(2, 120, "Pix Recebido");
            Movimentacao movimentacao21 = new Movimentacao(3, 120, "Pix Recebido");
            Movimentacao movimentacao3 = new Movimentacao(4, -50, "Compra Mercado");
            Movimentacao movimentacao4 = new Movimentacao(5, 50, "Pix Recebido");
            Movimentacao movimentacao5 = new Movimentacao(6, 50, "Pix Recebido");

            List<Movimentacao> listaMovimentacao = 
            new List <Movimentacao>  {
            movimentacao1, 
            movimentacao2, 
            movimentacao3, 
            movimentacao4, 
            movimentacao22, 
            movimentacao21, 
            movimentacao5 };

            ExtratoBancario extratoDeborah = new ExtratoBancario("0991494651", 1000, listaMovimentacao);

            extratoDeborah.ImprimirRelatorio();

        }
    }  
          
   
    public class Movimentacao
    {

        public int Id {get; set;}
        public double Valor { get; }
        public string Descricao { get; set; }



        public Movimentacao(int Id,double Valor, string Descricao)
        {
            this.Id = Id;
            this.Valor = Valor;
            this.Descricao = Descricao;


        }

    }

    public class ExtratoBancario
    {
        string CPFTitular;
        string NomeTitular = "Joe Doe";
        double SaldoInicial;
        List<Movimentacao> ListaMovimentacao;
        double SaldoFinal;

        public ExtratoBancario(string CPFTitular, double SaldoInicial, List<Movimentacao> movimentacoes)
        {
            this.CPFTitular = CPFTitular;
            this.SaldoInicial = SaldoInicial;
            this.ListaMovimentacao = movimentacoes;
        }

        public double ApurarSaldoFinal()
        {

            this.SaldoFinal = this.SaldoInicial;
            foreach(Movimentacao movimentacao in ListaMovimentacao)
            {
              this.SaldoFinal = this.SaldoFinal + movimentacao.Valor;

            }
            return this.SaldoFinal;
        }

        public void ImprimirRelatorio()
        {
            bool hasEqual = (this.ListaMovimentacao.Select(u => u.Id).Distinct().Count() - this.ListaMovimentacao.Count < 0) ? true : false;


            if(hasEqual && (this.ListaMovimentacao.Select(u => u.Id).Distinct().Count() >= 5))
            {
                System.Console.WriteLine("Extrato Bancário de "+this.NomeTitular);
                System.Console.WriteLine("Saldo Inicial: R$ "+ this.SaldoInicial);
                foreach(Movimentacao mov in ListaMovimentacao)
                {
                    string signal = mov.Valor > 0 ? "+": "-";

                    System.Console.WriteLine("Dia " + mov.Id + " ("+signal+") " + "R$ " + mov.Valor + "("+ mov.Descricao +")" );
                }

                System.Console.WriteLine("Saldo Final: R$ " + this.ApurarSaldoFinal());
            } else
            {
                System.Console.Write("Extrato não pode ser gerado!");
            }


            

        }
    }
 }
