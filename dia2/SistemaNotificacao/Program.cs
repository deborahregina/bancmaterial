using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNotificacao
{
    class Program
    {
        static void Main(string[] args)
        {

            INotificacao email = new EMail();
            INotificacao sms = new SMS();
            INotificacao push = new Push();

            string mensagem = "Pedido confirmado!";

            email.EnviarMensagem(mensagem);
            sms.EnviarMensagem(mensagem);
            push.EnviarMensagem(mensagem);
        }
    }

    public interface INotificacao
    {
        string EnviarMensagem(string mensagem);
    }

    public class EMail : INotificacao
    {

        public string EnviarMensagem(string mensagem)
        {

            return "Enviando E-mail: Pedido confirmado!";
        }
    }

    public class SMS : INotificacao
    {

        public string EnviarMensagem(string mensagem)
        {

            return "Enviando SMS: Pedido confirmado!";
        }
    }

    public class Push : INotificacao
    {

        public string EnviarMensagem(string mensagem)
        {

            return "Enviando Push: Pedido confirmado!";
        }
    }
}
