using Gimba.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimba.Business
{
    public class ClienteSocioBusiness
    {
        public void CriarClienteSocio(ClienteSocioModel model)
        {
            using (var contexto = new GimbaContexto())
            {
                var id = contexto.Database.SqlQuery<SocioModel>("exec sp_clienteSocioCriar @IdCliente, @IdSocio",
                     new SqlParameter("IdCliente", model.IdCliente),
                     new SqlParameter("IdSocio", model.IdSocio)
                     ).ToList();
             
            }
        }
    }
}
