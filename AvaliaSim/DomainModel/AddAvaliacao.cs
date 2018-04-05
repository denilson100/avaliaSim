using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    // Apenas um objeto auxiliar para enviar via post no service
    public class AddAvaliacao
    {
        public AddAvaliacao() { }

        [DisplayName("nome")]
        public string nome { get; set; }
        [DisplayName("cidade")]
        public string cidade { get; set; }
        [DisplayName("estado")]
        public string estado { get; set; }
        [DisplayName("tipo")]
        public string tipo { get; set; }
    }
}
