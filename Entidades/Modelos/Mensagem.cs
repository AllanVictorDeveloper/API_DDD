using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Modelos
{
    [Table("TB_MENSAGEM")]
    public class Mensagem : Notifica
    {
        [Column("MSG_ID")]
        public int Id { get; set; }

        [Column("MSG_TITULO")]
        [MaxLength(255)]
        public string Titulo { get; set; }

        [Column("MSG_ATIVO")]
        public bool Ativo { get; set; }

        [Column("MSG_DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; }

        [Column("MSG_DATA_ALTERACAO")]
        public DateTime DataAlteracao { get; set; }

        [ForeignKey("ApplicationUSer")]
        [Column(Order = 1)]
        public int IdUser { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}