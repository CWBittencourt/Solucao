using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimba.Model
{
    [Table("Socio")]
    public class SocioModel : IValidatableObject
    {
        [Key]
        [Column("IdSocio")]
        public long IdSocio { get; set; }

        [Column("Nome")]
        public String Nome { get; set; }

        [Column("CPF")]
        public String CPF { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(this.Nome))
            {
                yield return new ValidationResult("Informe o Nome");
            }

            if (string.IsNullOrEmpty(this.CPF))
            {
                yield return new ValidationResult("Informe o CPF");
            }
        }
    }
}
