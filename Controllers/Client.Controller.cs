using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Controllers
{

//Classe controladora do cliente
[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{


    //Lógica de negócio é integrada na classe de serviço para o cliente
    private ClientService _clientService = new ClientService();

    [HttpPost("add")]
    public IActionResult AddClient(string cpf, string name, string email)
    {
        var new_client = _clientService.AddClient(cpf, name, email);
        return Ok(new_client);
    }

    [HttpGet("showAll")]
    public IActionResult ShowAllClients()
    {
        var clients = _clientService.GetAllClients();
        return Ok(clients);
    }

    [HttpGet("show/{cpf}")]
    public IActionResult ShowClient(string cpf)
    {
        var client = _clientService.GetClientByCpf(cpf);
        return client != null ? Ok(client) : NotFound();
    }

    [HttpPut("update_email/{cpf}")]
    public IActionResult UpdateEmailClient(string cpf, string email)
    {
        _clientService.UpdateEmail(cpf, email);
        return Ok(email);
    }

    [HttpPut("update_name/{cpf}")]
    public IActionResult UpdateNameClient(string cpf, string name)
    {
        _clientService.UpdateName(cpf, name);
        return Ok(name);
    }

    [HttpDelete("delete/{cpf}")]
    public IActionResult DeleteClient(string cpf)
    {
        _clientService.DeleteClient(cpf);
        return Ok(cpf);
    }
}

}