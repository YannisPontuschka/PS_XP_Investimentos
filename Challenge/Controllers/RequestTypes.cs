using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Challenge.Helper;
using Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{

    //Classe relacionada à requisição de adição de novos clientes
    public class AddClientRequestType
    {

        
        [Required]
        public required string Cpf { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Email { get; set; }
    }

    //Classe relacionada à atualização dos dados dos clientes (assume-se que CPF não se muda)
    public class UpdateClientRequestType
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
    }


}