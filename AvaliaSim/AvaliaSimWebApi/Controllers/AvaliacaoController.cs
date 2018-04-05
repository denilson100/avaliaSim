using Data;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AvaliaSimWebApi.Controllers
{
    public class AvaliacaoController : ApiController
    {
        AvaliacaoRepositorio _avaliacaoRepositorio = new AvaliacaoRepositorio();

        // GET: api/Avaliacao
        public IEnumerable<Avaliacao> Get()
        {
            return _avaliacaoRepositorio.GetAllAvaliacoes();
        }

        // GET: api/Avaliacao/nome
        public IEnumerable<Avaliacao> BuscaPorNome(string nome)
        {
            return _avaliacaoRepositorio.GetLitsBuscaPorNome(nome);
        }

        // POST: api/Avaliacao
        public void Post([FromBody]Avaliacao avaliacao)
        {
            _avaliacaoRepositorio.AddAvaliacao(avaliacao);
        }

        // PUT: api/Avaliacao/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Avaliacao/5
        public void Delete(int id)
        {
            _avaliacaoRepositorio.deleteAvaliacao(id);
        }
    }
}
