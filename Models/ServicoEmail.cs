using SendGrid;
using System.Net;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Collections.Generic;


namespace LanceUmDesafio.Models
{
    public class ServicoEmail
    {
        
        public static Task EnviarRedefinicaoSenha(string email, string nome, string url)
        {
            var username = Properties.Resources.userMail;
            var pswd = Properties.Resources.userSenha;
            SendGridMessage myMessage = new SendGridMessage();

            myMessage.AddTo(email);
            myMessage.From = new MailAddress("noreply@jatanamao.com.br", "Lance Um Desafio");
            myMessage.EnableTemplateEngine("c03dd00b-eaf1-42f7-9047-5f026f42163f"); // Redefinição De Senha
            myMessage.Subject = "Lance Um Desafio - Redefinição De Senha";
            myMessage.Html = "Olá";
            myMessage.Text = "Olá";

            myMessage.AddSubstitution("[USER_NAME]",new List<string> { nome });
            myMessage.AddSubstitution("[URL_RESET]", new List<string> { url });
            var credenciais = new NetworkCredential(username, pswd);
            var transporteWeb = new Web(credenciais);

            
                if (transporteWeb != null)
                {
                    return transporteWeb.DeliverAsync(myMessage);
                }
                else
                {
                    return Task.FromResult(0);
                }
            
        }

        public static Task EnviarEmailDeConfirmacao(string email, string nome, string url)
        {
            var username = Properties.Resources.userMail;
            var pswd = Properties.Resources.userSenha;

            SendGridMessage myMessage = new SendGridMessage();

            myMessage.AddTo(email);
            myMessage.From = new MailAddress("noreply@lanceumdesafio.com.br", "Lance Um Desafio");
            myMessage.EnableTemplateEngine("41f6a9cb-13d7-4ea9-9d19-75cde64d849d"); // Confirme Seu Cadastro
            myMessage.Subject = "Lance Um Desafio - Confirmação De Cadastro";
            myMessage.Html = "Olá";
            myMessage.Text = "Olá";                 
            myMessage.AddSubstitution("[USER_NAME]", new List<string> { nome });
            myMessage.AddSubstitution("[URL_CONFIRM]", new List<string> { url });

            var credenciais = new NetworkCredential(username, pswd);
            var transporteWeb = new Web(credenciais);

            
                if (transporteWeb != null)
                {
                    return transporteWeb.DeliverAsync(myMessage);
                }
                else
                {
                    return Task.FromResult(0);
                }
        }

        //public static Task EnviarEmailPropostaAluguelProduto(AlugarProduto alugar)
        //{
        //    var username = Properties.Resources.userMail;
        //    var pswd = Properties.Resources.userSenha;

        //    SendGridMessage myMessage = new SendGridMessage();

        //    myMessage.AddTo(alugar.EmailAnunciante);
        //    myMessage.From = new MailAddress("noreply@jatanamao.com.br", "Já Tá Na Mão");
        //    myMessage.EnableTemplateEngine("bcc0dc51-be63-4e7c-a4a4-3045ea14f8fb");
        //    myMessage.Subject = "Solicitação De Aluguel Do Seu Produto";
        //    myMessage.Html = "Olá";
        //    myMessage.Text = "Olá";
        //    myMessage.AddSubstitution("[USER_NAME]", new List<string> { alugar.NomeAnunciante });
        //    myMessage.AddSubstitution("[NOME_SOLICITANTE]", new List<string> { alugar.NomeAlugador });
        //    myMessage.AddSubstitution("[PRODUTO_ANUNCIADO]", new List<string> { alugar.NomeProduto });
        //    myMessage.AddSubstitution("[URL_PRODUTO]", new List<string> { alugar.UrlProduto });
        //    myMessage.AddSubstitution("[PERIODO_ALUGUEL]", new List<string> { alugar.DiasAluguel.ToString() });
        //    myMessage.AddSubstitution("[DATA_INICIAL]", new List<string> { alugar.NomeAnunciante });
        //    myMessage.AddSubstitution("[DATA_FINAL]", new List<string> { alugar.NomeAnunciante });
        //    myMessage.AddSubstitution("[VALOR_TOTAL]", new List<string> { alugar.TotalAluguel.ToString() });
        //    myMessage.AddSubstitution("[TAXA_ALUGUEL]", new List<string> { alugar.TaxaAluguel.ToString() });
        //    myMessage.AddSubstitution("[URL_PERFILSOL]", new List<string> { alugar.UrlPerfilSolicitante });
        //    myMessage.AddSubstitution("[VALOR_RECEBER]", new List<string> { alugar.TotalGeral.ToString() });
            

        //    var credenciais = new NetworkCredential(username, pswd);
        //    var transporteWeb = new Web(credenciais);

            
        //    if (transporteWeb != null)
        //    {
        //        return transporteWeb.DeliverAsync(myMessage);
        //    }
        //    else
        //    {
        //        return Task.FromResult(0);
        //    }
        //}

    }
}