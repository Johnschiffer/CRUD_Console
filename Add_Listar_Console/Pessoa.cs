using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_Listar_Console
{
    public class Pessoa
    {
        private static int contador = 0;

        public Pessoa()
        {
            contador++;
            Id = contador;
        }
        public  int Id { get; private set; }
        public string Nome { get; private set; }

        public void SetNome(string nome)
        {
            this.Nome = nome;
        }

        public string GetNome()
        {
            return Nome;
        }
    }
}
