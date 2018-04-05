using AvaliaSim.Models;
using AvaliaSim.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace AvaliaSim.Controllers
{
    public class AvaliacaoControllerApi : ApiController
    {
        AvaliacaoRepository avaliacaoRepository = new AvaliacaoRepository();
        static readonly IAvaliacaoRepositorio repositorio = new AvaliacaoRepository();

        public IEnumerable<Avaliacao> GetAllAvaliacoesApi()
        {
            return repositorio.GetAll();
        }

        public Avaliacao GetAvaliacao(int id)
        {
            Avaliacao item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

    }
}