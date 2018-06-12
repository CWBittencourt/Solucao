using Gimba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimba.Business
{
    public class TipoTelefoneBusiness
    {
        public List<TipoTelefoneModel> GetTiposTelefone()
        {
            try
            {
                using (var contexto = new GimbaContexto())
                {
                    var retorno = contexto.Database.SqlQuery<TipoTelefoneModel>("exec sp_TipoTelefoneLerTodos").ToList();

                    return retorno.ToList<TipoTelefoneModel>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
