using APICurso.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICurso.Models
{
    public class ClienteLimite
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }


        public void RegistrarLimite()
        {
            DAL obj = new DAL();

            string sql = $"insert into limitecliente(nome,valor) values({Nome},{Valor.ToString()})";
            obj.ExecutarComandoSQL(sql);
        }

        public void AtualizaLimite()
        {
            DAL obj = new DAL();

            string sql = $"update limitecliente set nome = '{Nome}', valor = '{Valor}' where codigo = '{Codigo}'";
            obj.ExecutarComandoSQL(sql);
        }

        public decimal Sacar(int codigo, decimal valor)
        {
            DAL obj = new DAL();
            decimal resultado = Valor - valor;
            string sql = $"update limitecliente set valor = '{resultado}' where codigo = '{codigo.ToString()}'";
            obj.ExecutarComandoSQL(sql);
            return resultado;
        }
    }


}
