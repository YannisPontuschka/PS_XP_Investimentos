using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge.Helper;
using Challenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Challenge.Controllers
{

    //Classe controladora do cliente, trata as requisições
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        //referência à classe serviço o cliente
        private static ClientService _clientService = new ClientService();

        //operação de POST para adicionar um cliente
        [HttpPost("add")]
        public IActionResult AddClient([FromBody] AddClientRequestType client_request)
        {
            try
            {
                var cpf = client_request.Cpf;
                var name = client_request.Name;
                var email = client_request.Email;

                bool has_valid_client = _clientService.ValidateClient(cpf, name, email);
                bool already_created_client = _clientService.GetClientByCpf(cpf) != null;

                if (!has_valid_client || already_created_client)
                    return BadRequest("CPF, nome ou email inválido(s) ou cliente já existente");

                _clientService.AddClient(cpf, name, email);
                return Ok($"Usuário '{cpf}' criado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no servidor - {ex.Message}");
            }
        }


        //Operação de GET para apresentar todos os clientes
        [HttpGet("showAll")]
        public IActionResult ShowAllClients()
        {
            try
            {
                var clients = _clientService.GetAllClients();
                if (clients == null)
                    return NotFound("Sem clientes cadastrados.");
                return Ok(clients);
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no servidor - {ex.Message}");
            }
        }

        //Operação de GET para apresentar um cliente com um dado 'cpf'
        [HttpGet("show/{cpf}")]
        public IActionResult ShowClient(string cpf)
        {
            try
            {
                var client = _clientService.GetClientByCpf(cpf);
                bool client_is_found = client != null;
                return client_is_found ? Ok(client) : BadRequest($"CPF '{cpf}' inválido ou não encontrado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no servidor - {ex.Message}");

            }
        }

        //Operação PUT para atualizar o email e/ou nome de um cliente
        [HttpPut("update/{cpf}")]
        public IActionResult UpdateClient([FromRoute] string cpf, [FromBody] UpdateClientRequestType update_client)
        {
            try
            {

                var client = _clientService.GetClientByCpf(cpf);
                if (client == null)
                    return NotFound("Cliente não encontrado.");

                bool has_valid_types = cpf.GetType() != typeof(string) || update_client?.Name?.GetType() != typeof(string) || update_client?.Email?.GetType() != typeof(string);


                if (update_client?.Name != null)
                    client.Name = update_client.Name;
                if (update_client?.Email != null)
                    client.Email = update_client.Email;

                string name = client.Name;
                string email = client.Email;

                bool client_is_valid = _clientService.ValidateClient(cpf, name, email);
                if (!client_is_valid)
                    return BadRequest("CPF, Nome ou Email inválido(s)");

                _clientService.UpdateClient(cpf, name, email);
                return Ok($"Dados do cliente '{cpf}' atualizados.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no servidor - {ex.Message}");
            }

        }


        //operação de deletar um cliente com um dado 'cpf'
        [HttpDelete("delete/{cpf}")]
        public IActionResult DeleteClient(string cpf)
        {
            try
            {
                var client_for_delete = _clientService.GetClientByCpf(cpf);

                if (client_for_delete == null)
                    return BadRequest($"Remoção não possível. CPF não encontrado ou inválido.");

                _clientService.DeleteClient(cpf);

                return Ok($"Cliente com CPF '{cpf}' deletado.");
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no servidor - {ex.Message}");
            }

        }
    }

}