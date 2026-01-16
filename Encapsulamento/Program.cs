using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulamento
{
    class Program
    {
        static void Main(string[] args)
        {

            ContaBancaria contaJohn = new ContaBancaria("2","148.578.595-25", "John Doe", 100);

            //contaJohn.getNumeroDaConta = 25; // Erro.

            //contaJohn.Titular = "Mary Monroe"; // Erro.

            //contaJohn.Saldo = 1000000; // Erro.

            //Console.WriteLine($"Conta {contaJohn.Numero} em nome de {contaJohn.Titular}: Saldo de {contaJohn.Saldo}.");

            contaJohn.Depositar(100);

            Console.WriteLine($"Saque de R$ 30,00 {(contaJohn.Sacar(30) ? "bem sucedido!" : "Não foi concluído.")}"); // Bem sucedido.

            Console.WriteLine($"Saque de R$ 100,00 {(contaJohn.Sacar(100) ? "bem sucedido!" : "Não foi concluído.")}"); // Não concluído.

            Console.WriteLine($"Conta {contaJohn.getNumeroDaConta()} em nome de {contaJohn.getNomeTitular()}: Saldo de {contaJohn.getSaldo()}.");

        }
    }

    public class ContaBancaria
    {
        private string NumeroDaConta;
        private string CPFTitular;
        private string NomeTitular;
        private double Saldo;

        public ContaBancaria(string NumeroDaConta, string CPFTitular, string NomeTitular, double Saldo)
        {
            this.NumeroDaConta = NumeroDaConta;
            this.CPFTitular = CPFTitular;
            this.NomeTitular = NomeTitular;
            this.Saldo = Saldo;

        }

        public string getNumeroDaConta()
        {
            return this.NumeroDaConta;
        }

        public string getCPFTitular()
        {
            return this.CPFTitular;
        }

        public string getNomeTitular()
        {
            return this.NomeTitular;
        }

        public double getSaldo()
        {
            return this.Saldo;
        }

        //public void setSaldo(double saldo)
        //{
        //    this.Saldo = saldo;
        //}

        public bool Depositar(double saldo)
        {
            if (saldo > 0) {

                this.Saldo =+ saldo;
                return true;
            }

            else return false;
        }

        public bool Sacar(double saldo)
        {
            if(saldo >0)
            {
                if(this.Saldo - saldo > 0)
                {
                    this.Saldo = this.Saldo - saldo;
                    return true;
                } 

                return false;
            }

            return false;
        }
    }
}
