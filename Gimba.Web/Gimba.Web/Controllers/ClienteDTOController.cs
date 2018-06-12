using Gimba.Business;
using Gimba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Web.Routing;

namespace Gimba.Web.Controllers
{
    public class ClienteDTOController : ApiController
    {

        // GET api/values

        public List<ClienteModelDTO> Get()
        {

            List<ClienteModel> clientess = new ClienteBusiness().GetClientes();
            List<ClienteModelDTO> clientes = new List<ClienteModelDTO>();






            foreach (var item in clientess)
            {
                ClienteModelDTO clienteDTO = new ClienteModelDTO();

                ClienteModel cliente = new ClienteModel();
                cliente.Ativo = item.Ativo;
                cliente.Nome = item.Nome;
                cliente.CNPJ = item.CNPJ;
                cliente.IdCliente = item.IdCliente;

                cliente.Telefones = new TelefoneBusiness().GetTelefonePorIdCliente(item.IdCliente);
                cliente.Emails = new EmailBusiness().GetEmailPorIdCliente(item.IdCliente);
                
                clienteDTO.Cliente = cliente;

                clientes.Add(clienteDTO);
            }

            return clientes;
        }

        // GET api/values/5
        public string Get(long id)
        {
            return "value";
        }

        // POST api/values
        [ResponseType(typeof(ClienteModelDTO))]
        public IHttpActionResult Post([FromBody]ClienteModelDTO model)
        {
            try
            {
                new ClienteDTOBusiness().CriarCliente(model);
                Uri url = new Uri(this.Request.RequestUri.OriginalString);
                return CreatedAtRoute("DefaultApi", new { }, new ClienteModelDTO());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]ClienteModelDTO model)
        {
        }

        // DELETE api/values/5
        public void Delete(long id)
        {
            new ClienteBusiness().ExcluirCliente(id);
        }

        public JsonResult<EnderecoModel> GetCep(string cep)
        {
            return Json<EnderecoModel>(new Business.EnderecoBusiness().GetEnderecoPorCEP(cep));
        }
    }
}
