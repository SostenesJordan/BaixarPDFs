using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;
using System.ComponentModel;

namespace BaixarPDFs
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = System.IO.File.ReadAllText(@"C:\Users\Sóstenes Jordan\source\repos\BaixarPDFs\BaixarPDFs\ParteDoHTML.txt");
            var caminho = @"C:\Users\Sóstenes Jordan\Desktop\Pdfs";
            var NomeDoArquivo = "Aula";

            Regex PDFs01 = new Regex("\\s*learn/api/public/v1/courses/(.*?)download");
            var Match01 = PDFs01.Matches(url);

            Regex PDFs02 = new Regex("http://www.ic.uff.br/~viviane.silva/es1/util/aula(.*?).pdf"); // baixa os pdfs da viviane
            var Match02 = PDFs02.Matches(url);

            Console.WriteLine("Iniciando....");

            for (int i = 0; i <= Match02.Count; i++)
            {
                //string RemoverAspas  = Match01[i].Value.Replace("\"", "");
                int aux = i;
                Console.WriteLine($"baixando o arquivo {i}");
                using (WebClient web = new WebClient())
                {
                    web.DownloadFile(Match02[i].Value, $"{caminho}/Aula_0{aux}.pdf");
                    web.DownloadProgressChanged += WebClientDownloadProgressChanged;
                    web.DownloadFileCompleted += WebClientDownloadCompleted;
                    Console.WriteLine($"Arquivo {aux} - OK");
                }


            }

            //using (WebClient web = new WebClient())
            //{
            //    web.DownloadFile(url, $"{caminho}/{NomeDoArquivo}.pdf");
            //    web.DownloadProgressChanged += WebClientDownloadProgressChanged;
            //    web.DownloadFileCompleted += WebClientDownloadCompleted;
            //    Console.WriteLine(@"Baixando o arquivo:");
            //}
        }

        private static void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void WebClientDownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
