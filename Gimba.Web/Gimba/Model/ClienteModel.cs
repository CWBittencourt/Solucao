using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimba.Model
{
    [Table("Cliente")]
    public class ClienteModel : IValidatableObject
    {

        public ClienteModel()
        {
            this.Emails = new HashSet<EmailModel>();
            this.Telefones = new HashSet<TelefoneModel>();
        }

        [Key]
        [Column("IdCliente")]
        public long IdCliente { get; set; }

        [Column("IdNome")]
        public String Nome { get; set; }

        [Column("CNPJ")]
        public String CNPJ { get; set; }

        [Column("Ativo")]
        public Boolean? Ativo { get; set; }


        public virtual ICollection<TelefoneModel> Telefones { get; set; }

        public virtual ICollection<EmailModel> Emails { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(this.Nome))
            {
                yield return new ValidationResult("Informe o Nome");
            }

            if (string.IsNullOrEmpty(this.CNPJ))
            {
                yield return new ValidationResult("Informe o CNPJ");
            }

            if (this.Ativo==null)
            {
                this.Ativo = false;
            }
        }
    }
}
