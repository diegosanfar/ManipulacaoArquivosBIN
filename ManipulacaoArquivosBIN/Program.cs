using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ManipulacaoArquivosBIN
{
    class Program
    {
        [System.Serializable]
        struct Produto
        {
            public string nome;
            public float preco;
        }
        static void Main(string[] args)
        {
            int a = 120;
            string nome = "Bruce Kent";
            float b = 12.2f;
            List<string> langs = new List<string>();
            langs.Add("C#");
            langs.Add("javascript");
            langs.Add("PHP");

            Produto banana = new Produto();
            banana.nome = "Banana";
            banana.preco = 1F;

            FileStream stream = new FileStream("meuarquivo.generic",FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            //  encoder.Serialize(stream, langs);
            //  encoder.Serialize(stream, banana);

            List<string> listaDoArquivo = (List<string>)encoder.Deserialize(stream);
            Produto prod = (Produto)encoder.Deserialize(stream);

            Console.WriteLine(listaDoArquivo[0]);
            Console.WriteLine(prod.nome);

            /*encoder.Serialize(stream, a);
              encoder.Serialize(stream, nome);
              encoder.Serialize(stream, b);
            */

            stream.Close();

            Console.ReadLine();
        }
    }
}
