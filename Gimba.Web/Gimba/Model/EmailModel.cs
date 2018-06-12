using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Gimba.Model
{
    [Table("Email")]
    public class EmailModel : IValidatableObject
    {
        [Key]
        [Column("IdEmail")]
        public long IdEmail { get; set; }

        [Column("Email")]
        public String Email { get; set; }

        [Column("IdCliente")]
        public long IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public ClienteModel Cliente { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if ((string.IsNullOrEmpty(this.Email)) || (string.IsNullOrWhiteSpace(this.Email)))
            {
                yield return new ValidationResult("Informe o Email");
            }

            if (!string.IsNullOrEmpty(this.Email))
            {
                bool emailValido = true;
                try
                {
                    MailAddress m = new MailAddress(this.Email);
                }
                catch (FormatException)
                {
                    emailValido = false;
                }

                if (emailValido == false)
                {
                    yield return new ValidationResult("Email inválido");
                }
            }
        }
    }
}
