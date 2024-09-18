using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge.Exceptions;
using Challenge.Helper;
using Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{

    //Classe controladora do cliente, lida com as requisições

    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        //referência à classe serviço o cliente
        private static ClientService _clientService = new ClientService();


        //operação de POST para adicionar um cliente
        [HttpPost("add")]
        public IActionResult AddClient(string cpf, string name, string email)
        {
            try
            {
                if (!ClientValidation.ValidateCPF(cpf))
                    return BadRequest($"CPF '{cpf}' inválido.");

                if (_clientService.GetClientByCpf(cpf) != null)
                    return StatusCode(403, "Proibido inserir um cliente com CPF já existente no banco de dados.");

                if (!ClientValidation.ValidateName(name))
                    return BadRequest($"Nome '{name}' Inválido");

                if (!ClientValidation.ValidateEmail(email))
                    return BadRequest($"Email '{email}' inválido.");


                var new_client = _clientService.AddClient(cpf, name, email);
                return Ok(new_client);
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
                if (!ClientValidation.ValidateCPF(cpf))
                    return BadRequest($"CPF '{cpf}' inválido.");
                var client = _clientService.GetClientByCpf(cpf);
                return client != null ? Ok(client) : NotFound($"Cliente com CPF '{cpf}' não encontrado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no servidor - {ex.Message}");

            }
        }

        //Operação PUT para atualizar o email de um clinte com um dado 'cpf'
        [HttpPut("update_email/{cpf}")]
        public IActionResult UpdateEmailClient(string cpf, string email)
        {
            try
            {
                if (!ClientValidation.ValidateCPF(cpf))
                    return BadRequest($"CPF '{cpf}' inválido.");

                if (_clientService.GetClientByCpf(cpf) == null)
                    return NotFound($"Cliente com CPF '{cpf}' não encontrado.");

                if (!ClientValidation.ValidateEmail(email))
                    return BadRequest($"Email novo '{email}' é inválido.");

                _clientService.UpdateEmail(cpf, email);
                return Ok($"Email do cliente '{cpf}' atualizado para '{email}'.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no servidor - {ex.Message}");
            }

        }


        //Operação PUT para atualizar o nome de um cliente com um dado 'cpf'
        [HttpPut("update_name/{cpf}")]
        public IActionResult UpdateNameClient(string cpf, string name)
        {
            try
            {
                if (!ClientValidation.ValidateCPF(cpf))
                    return BadRequest($"CPF '{cpf}' inválido.");

                if (_clientService.GetClientByCpf(cpf) == null)
                    return NotFound($"Cliente com CPF '{cpf}' não encontrado.");

                _clientService.UpdateName(cpf, name);
                return Ok($"Nome do cliente '{cpf}' atualizado para '{name}'");
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
                if (!ClientValidation.ValidateCPF(cpf))
                    return BadRequest($"CPF '{cpf}' inválido.");

                if (_clientService.GetClientByCpf(cpf) == null)
                    return NotFound($"Cliente com CPF '{cpf}' não encontrado.");

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