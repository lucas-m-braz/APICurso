using APICurso.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace APICurso.Utilities
{
    public class DAL
    {
        

        private static string Server = "localhost";
        private static string Database = "BDSERVICO";
        private static string User = "root";
        private static string Password = "";
        private MySqlConnection Connection;

        private string ConnectionString = $"Server={Server};Database={Database};Uid={User};Pwd={Password};Sslmode=none;";

        public DAL()
        {
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();
        }


        public void ExecutarComandoSQL(string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            Command.ExecuteNonQuery();
        }




        public DataTable RetornarDataTable(string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            MySqlDataAdapter DataAdaptar = new MySqlDataAdapter(Command);
            DataTable Dados = new DataTable();
            DataAdaptar.Fill(Dados);
            return Dados;
        }


    }
}
