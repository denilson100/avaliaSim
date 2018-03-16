using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AvaliaSim.Repository
{
    public class Produto
    {
        public Produto() { }

        [DisplayName("Bom")]
        public string Bom { get; set; }
        [DisplayName("Neutro")]
        public string Neutro { get; set; }
        [DisplayName("Ruim")]
        public string Ruim { get; set; }

        public string SelectedDepartment { get; set; }
        public List<Produto> Departments
        {
            get
            {
                Produto produto = new Produto();
                produto.Bom = "Bom";
                produto.Neutro = "Neutro";
                produto.Ruim = "Ruim";
                Departments.Add(produto);
                return Departments.ToList();
            }
        }

    }

}