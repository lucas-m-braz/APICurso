using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using APICurso.Models;
using APICurso.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace APICurso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet]
        [Route("/all")]
        public ActionResult<DataTable> GetAll()
        {
            var obj = new DAL();
            string sql = "SELECT * from limitecliente";
            DataTable dados = obj.RetornarDataTable(sql);

            return dados;
        }

        // GetValor /limite/id

        [HttpGet("{id}")]
        [Route("/limite/{id}")]
        public ActionResult<string> GetValor(int id)
        {
            var obj = new DAL();

            string sql = $"SELECT * from limitecliente where codigo = {id}";
            DataTable dados = obj.RetornarDataTable(sql);
            return dados.Rows[0]["Valor"].ToString();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] ClienteLimite dados)
        {
            dados.RegistrarLimite();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // SAQUE cliente/saque/valor
        [HttpPut("{id}")]
        [Route("/sacar/{id}/{valor}")]
        public void Sacar(int id, decimal valor)
        {
            var obj = new DAL();

            string sql = $"SELECT * from limitecliente where codigo = {id}";
            DataTable dados = obj.RetornarDataTable(sql);
            ClienteLimite cliente = new ClienteLimite() { Codigo = int.Parse(dados.Rows[0]["Codigo"].ToString()), Nome = dados.Rows[0]["Nome"].ToString(), Valor = decimal.Parse(dados.Rows[0]["Valor"].ToString()) };
            cliente.Sacar(cliente.Codigo, valor);
        }
    }
}
