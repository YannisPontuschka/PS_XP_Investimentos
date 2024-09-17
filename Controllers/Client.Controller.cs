using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        var new_client = _clientService.AddClient(cpf, name, email);
        return Ok(new_client);
    }

    //Operação de GET para apresentar todos os clientes
    [HttpGet("showAll")]
    public IActionResult ShowAllClients()
    {
        var clients = _clientService.GetAllClients();
        return Ok(clients);
    }

    //Operação de GET para apresentar um cliente com um dado 'cpf'
    [HttpGet("show/{cpf}")]
    public IActionResult ShowClient(string cpf)
    {
        var client = _clientService.GetClientByCpf(cpf);
        return client != null ? Ok(client) : NotFound();
    }

    //Operação PUT para atualizar o email de um clinte com um dado 'cpf'
    [HttpPut("update_email/{cpf}")]
    public IActionResult UpdateEmailClient(string cpf, string email)
    {
        _clientService.UpdateEmail(cpf, email);
        return Ok(email);
    }


   //Operação PUT para atualizar o nome de um cliente com um dado 'cpf'
    [HttpPut("update_name/{cpf}")]
    public IActionResult UpdateNameClient(string cpf, string name)
    {
        _clientService.UpdateName(cpf, name);
        return Ok(name);
    }

    //operação de deletar um cliente com um dado 'cpf'
    [HttpDelete("delete/{cpf}")]
    public IActionResult DeleteClient(string cpf)
    {
        _clientService.DeleteClient(cpf);
        return Ok(cpf);
    }
}

}