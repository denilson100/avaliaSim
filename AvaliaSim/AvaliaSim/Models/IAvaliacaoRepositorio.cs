using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvaliaSim.Models
{
    public interface IAvaliacaoRepositorio
    {
        IEnumerable<Repository.Avaliacao> GetAll();
        Repository.Avaliacao Get(int id);
        Repository.Avaliacao Add(Repository.Avaliacao item);
        void Remove(int id);
        bool Update(Repository.Avaliacao item);
    }
}