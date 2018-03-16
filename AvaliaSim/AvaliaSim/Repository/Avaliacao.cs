using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AvaliaSim.Repository
{
    public class Avaliacao
    {
        public Avaliacao() { }

        [Key]
        public int Id { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; }
        [DisplayName("Sobrenome")]
        public string SobreNome { get; set; }
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "Entre com a data de aniversário")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Nascimento { get; set; }

        [DisplayName("Nome")]
        public string nome { get; set; }
        [DisplayName("Cidade")]
        public string cidade { get; set; }
        [DisplayName("Estado")]
        public string estado { get; set; }
        [DisplayName("Tipo")]
        public string tipo { get; set; }
        [DisplayName("total_avaliacoes")]
        public int totalAvaliacoes { get; set; }
        [DisplayName("_data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime _data { get; set; }
        [DisplayName("serv_agilidade")]
        public int servAgilidade { get; set; }
        [DisplayName("serv_satisfacao")]
        public int servsatisfacao { get; set; }
        [DisplayName("serv_atendimento")]
        public int servAtendimento { get; set; }
        [DisplayName("prod_qualidade")]
        public int prodQualidade { get; set; }
        [DisplayName("prod_custo_beneficio")]
        public int prodCusto_beneficio { get; set; }
        [DisplayName("prod_satisfacao")]
        public int prodSatisfacao { get; set; }

    }
}


public enum Tipo
{
    Produto,
    Serviço
}

public enum Estado
{
    RJ,
    SP,
    MG,
    ES
}

public enum Qualidade
{
    Bom,
    Neutro,
    Ruim
}