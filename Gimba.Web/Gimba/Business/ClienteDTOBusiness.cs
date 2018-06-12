using Gimba.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimba.Business
{
    public class ClienteDTOBusiness
    {
        public void CriarCliente(ClienteModelDTO cliente)
        {
            long idCliente = new ClienteBusiness().CriarCliente(cliente.Cliente);

            cliente.Endereco.IdCliente = idCliente;

            new EnderecoBusiness().CriarEndereco(cliente.Endereco);

            foreach (var item in cliente.Cliente.Emails)
            {
                item.IdCliente = idCliente;
                new EmailBusiness().CriarEmail(item);
            }

            foreach (var item in cliente.Cliente.Telefones)
            {
                item.IdCliente = idCliente;
                new TelefoneBusiness().CriarTelefone(item);
            }

            foreach (var item in cliente.Socios)
            {
                SocioModel socio = new SocioModel();
                socio.Nome = item.Nome;
                socio.CPF = item.CPF;

                long idSocio = new SocioBusiness().CriarSocio(socio);

                ClienteSocioModel clienteSocio = new ClienteSocioModel();
                clienteSocio.IdCliente = idCliente;
                clienteSocio.IdSocio = idSocio;

                new ClienteSocioBusiness().CriarClienteSocio(clienteSocio);
            }
        }
    }
}
