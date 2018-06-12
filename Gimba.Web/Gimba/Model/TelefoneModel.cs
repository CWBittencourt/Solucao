using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimba.Model
{
    [Table("Telefone")]
    public class TelefoneModel : IValidatableObject
    {
        [Key]
        [Column("IdTelefone")]
        public long IdTelefone { get; set; }

        [Column("DDD")]
        public String DDD { get; set; }


        [Column("Numero")]
        public String Numero { get; set; }


        [Column("IdTipoTelefone")]
        public long IdTipoTelefone { get; set; }
        [ForeignKey("IdTipoTelefone")]
        public TipoTelefoneModel TipoTelefone { get; set; }


        [Column("IdCliente")]
        public long IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public ClienteModel Cliente { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(this.Numero))
            {
                yield return new ValidationResult("Informe o Número");
            }
            if (string.IsNullOrEmpty(this.DDD))
            {
                yield return new ValidationResult("Informe o DDD");
            }
        }
    }
}
