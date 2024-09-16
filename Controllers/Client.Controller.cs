using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Controllers
{

    [ApiController] // itens entre [] indicam atributos (?)
    [Route("[controller]")]
     public class ClientController : ControllerBase
    {

        //Uso de um dicionário para eficiência da busca, que terá complexidade O(1).
        //Assume-se que CPF é único.
        private static Dictionary<string, Client> clients_dictionary = new Dictionary<string, Client>();

        //operação POST para adicionar um cliente
        [HttpPost("add")] 
        public IActionResult AddClient(string cpf, string name, string email)
        {
            Client new_client = new Client(cpf, name, email);
            clients_dictionary.Add(new_client.cpf, new_client);
            return Ok(new_client);
           
        }

        //operação GET para listar todos os clientes
        [HttpGet("showAll")] 
        public IActionResult ShowAllClients()
        {       
            return Ok (clients_dictionary.Values);
        }

        //operação GET para listar um cliente com cpf 'cpf'
        [HttpGet("show/{cpf}")] 
        public IActionResult ShowAllClients(string cpf)
        {       
            return Ok (clients_dictionary[cpf]);
        }

        
        //operação PUT para atualizar o email;
        [HttpPut("update_email/{cpf}")]
        public IActionResult UpdateEmailClient(string cpf, string email)
        {
            clients_dictionary[cpf].cpf = email;
            return Ok (email);

        }

        //operação PUT para atualizar o nome;
        [HttpPut("update_name/{cpf}/")]
        public IActionResult UpdateNameClient(string cpf, string name)
        {
            clients_dictionary[cpf].name = name;
            return Ok (name);

        }

        //operação DELETE para deletar informações de um cliente com CPF 'cpf'
        [HttpDelete("delete/{cpf}")]
        public IActionResult DeleteClient(string cpf)
        {
            clients_dictionary.Remove(cpf);
            return Ok(cpf);
        }
        
    }

}