using AvaliaSim.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AvaliaSim.Controllers
{
    public class AvaliacaoController : Controller
    {
        
        AvaliacaoRepository avaliacaoRepository = new AvaliacaoRepository();

        // GET: Avaliacao
        public ActionResult Index()
        {
            return View();
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Session["CheckAvaliacaoID"] == null)
                Session["CheckAvaliacaoID"] = new List<int>();
        }

        // GET: Checkbox
        public ActionResult MarkCheckBox(int avaliacaoId)
        {
            List<int> CheckAvaliacaoID = (List<int>)Session["CheckAvaliacaoID"];
            CheckAvaliacaoID.Add(avaliacaoId);
            Session["CheckAvaliacaoID"] = CheckAvaliacaoID;

            return Json(new { status = "OK" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MarkOffCheckBox(int avaliacaoId)
        {
            List<int> RemoveCheckBox = (List<int>)Session["CheckAvaliacaoID"];
            RemoveCheckBox.Remove(avaliacaoId);
            Session["CheckAvaliacaoID"] = RemoveCheckBox;

            return Json(new { status = "OK" }, JsonRequestBehavior.AllowGet);
        }



        public ActionResult GetAllAvaliacoes()
        {
            List<Avaliacao> listAvaliacao = (List<Avaliacao>)avaliacaoRepository.GetAllAvaliacoes();

            return View(listAvaliacao);
        }

        public ActionResult ListBuscaPorNome(string nome)
        {
            List<Avaliacao> listAvaliacao = (List<Avaliacao>)avaliacaoRepository.GetLitsBuscaPorNome(nome);

            return View(listAvaliacao);
        }

        // GET: Avaliacao/Avaliar/1
        public ActionResult Avaliar(int id)
        {
            return View(avaliacaoRepository.GetAvaliacao(id));
        }

        // POST: Avaliacao/Avaliar/1
        [HttpPost]
        public ActionResult Avaliar(FormCollection formCollection)
        {
            Avaliacao avaliacao = new Avaliacao()
            {
                Id = int.Parse(formCollection["id"]),
                nome = formCollection["nome"]
            };

            avaliacaoRepository.UpdateAvaliacao(avaliacao);

            return RedirectToAction("Index");
        }

        //Redirecionar para Produto ou servico
        public ActionResult Redirect(int id)
        {
            Avaliacao avaliacao = new Avaliacao();
            avaliacao = avaliacaoRepository.GetAvaliacao(id);

            // Soma 1 no total
            avaliacaoRepository.UpdateTotalAvaliacoes(id);

            if (avaliacao.tipo == "Serviço")
            {
                return RedirectToAction("AvaliarServAtendimento/" + id);
            }

            if (avaliacao.tipo == "Produto")
            {
                return RedirectToAction("AvaliarProdQualidade/" + id);
            }

            return View(avaliacaoRepository.GetAvaliacao(id));
        }

        // ServAtendimento
        public ActionResult AvaliarServAtendimento(int id)
        {
            return View(avaliacaoRepository.GetAvaliacao(id));
        }

        [HttpPost]
        public ActionResult AvaliarServAtendimento(int id, int recebeOpcao)
        {
            avaliacaoRepository.UpdateServAtendimento(id, recebeOpcao);
            return RedirectToAction("AvaliarServAgilidade/" + id);
        }

        // ServAgilidade
        public ActionResult AvaliarServAgilidade(int id)
        {
            return View(avaliacaoRepository.GetAvaliacao(id));
        }

        [HttpPost]
        public ActionResult AvaliarServAgilidade(int id, int recebeOpcao)
        {
            avaliacaoRepository.UpdateServAgilidade(id, recebeOpcao);
            return RedirectToAction("AvaliarServSatisfacao/" + id);
        }

        // ServSatisfação
        public ActionResult AvaliarServSatisfacao(int id)
        {
            return View(avaliacaoRepository.GetAvaliacao(id));
        }

        [HttpPost]
        public ActionResult AvaliarServSatisfacao(int id, int recebeOpcao)
        {
            avaliacaoRepository.UpdateServSatisfacao(id, recebeOpcao);
            return RedirectToAction("GetAllAvaliacoes");
        }

        // ProdQualidade
        public ActionResult AvaliarProdQualidade(int id)
        {
            return View(avaliacaoRepository.GetAvaliacao(id));
        }

        [HttpPost]
        public ActionResult AvaliarProdQualidade(int id, int recebeOpcao)
        {
            avaliacaoRepository.UpdateProdQualidade(id, recebeOpcao);
            return RedirectToAction("AvaliarProdCustoBeneficio/" + id);
        }

        // ProdCustoBeneficio
        public ActionResult AvaliarProdCustoBeneficio(int id)
        {
            return View(avaliacaoRepository.GetAvaliacao(id));
        }

        [HttpPost]
        public ActionResult AvaliarProdCustoBeneficio(int id, int recebeOpcao)
        {
            avaliacaoRepository.UpdateProdCustoBeneficio(id, recebeOpcao);
            return RedirectToAction("AvaliarProdSatisfacao/" + id);
        }

        // ProdSatisfacao
        public ActionResult AvaliarProdSatisfacao(int id)
        {
            return View(avaliacaoRepository.GetAvaliacao(id));
        }

        [HttpPost]
        public ActionResult AvaliarProdSatisfacao(int id, int recebeOpcao)
        {
            avaliacaoRepository.UpdateProdSatisfacao(id, recebeOpcao);
            return RedirectToAction("GetAllAvaliacoes");
        }

        // GET: Avaliacao/Avaliar/1
        public ActionResult avaliar1(int id)
        {
            return View(avaliacaoRepository.GetAvaliacao(id));
        }

        [HttpPost]
        public ActionResult avaliar1(string recebeTipo, int recebeOpcao)
        {
            if (recebeTipo == "Serviço")
            {
                if (recebeOpcao == 1)
                {
                    return RedirectToAction("GetAllAvaliacoes");
                }
                if (recebeOpcao == 2)
                {
                    return RedirectToAction("GetAllAvaliacoes");
                }
                if (recebeOpcao == 3)
                {
                    return RedirectToAction("GetAllAvaliacoes");
                }
            }
            if (recebeTipo == "Produto")
            {
                if (recebeOpcao == 1)
                {
                    return RedirectToAction("Index");
                }
                if (recebeOpcao == 2)
                {
                    return RedirectToAction("Index");
                }
                if (recebeOpcao == 3)
                {
                    return RedirectToAction("Index");
                }
            }

            // avaliacaoRepository.UpdateAvaliacao(avaliacao);

            return RedirectToAction("Create");
        }

        // GET: Amigo/Details/5
        public ActionResult Details(int id)
        {
            return View(avaliacaoRepository.GetAvaliacao(id));
        }

        // GET: Amigo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Amigo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            avaliacaoRepository.AddAvaliacao(collection["nome"], collection["cidade"], collection["estado"], collection["tipo"]);

            return RedirectToAction("GetAllAvaliacoes");
        }

        // GET: Amigo/Edit/5
        public ActionResult Edit(int id)
        {
            return View(avaliacaoRepository.GetAvaliacao(id));
        }

        // POST: Amigo/Edit/5
        [HttpPost]
        public ActionResult Edit(FormCollection formCollection)
        {
            Avaliacao amigo = new Avaliacao()
            {
                Id = int.Parse(formCollection["id"]),
                Nome = formCollection["nome"],
                SobreNome = formCollection["sobreNome"],
                Email = formCollection["email"],
                Nascimento = DateTime.Parse(formCollection["nascimento"])
            };

            avaliacaoRepository.UpdateAmigo(amigo);

            return RedirectToAction("Index");
        }

        // GET: Amigo/Delete/5
  //      public ActionResult Delete(int id)
  //      {
  //          amigoRepository.RemoveAmigo(id);

  //          return RedirectToAction("Index");
  //      }

        // POST: Amigo/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}