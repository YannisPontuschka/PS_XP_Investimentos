using Challenge.Models;
using Challenge.Helper;
using Challenge.Services;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Runtime.CompilerServices;
using System.Globalization;

//Classe de serviço do cliente para integrar a lógica de negócio e manipulação dos dados

namespace Challenge.Services
{
    public class ClientService
    {
        //Uso de um dicionário para armazenar os clientes em memória.
        private static Dictionary<string, ClientModel> clients_dictionary = new Dictionary<string, ClientModel>();

        //Validação dos dados do cliente
        public bool ValidateClient(string cpf, string name, string email)
        {

            if (!ClientValidation.ValidateCPF(cpf))
                return false;

            if (!ClientValidation.ValidateName(name))
                return false;

            if (!ClientValidation.ValidateEmail(email))
                return false;

            return true;
        }

        //Atualização dos dados do cliente no dicionário
        public void UpdateClient(string cpf, string name, string email)
        {

            clients_dictionary[cpf].Name = name;
            clients_dictionary[cpf].Email = email;

        }

        //Instanciação de um novo cliente e sua adição no dicionário
        public ClientModel AddClient(string cpf, string name, string email)
        {

            ClientModel client = new ClientModel(cpf, name, email);
            clients_dictionary.Add(cpf, client);
            return client;
        }

        //Retorna todos os clientes, ou nulo se não houver nenhum
        public Dictionary<string, ClientModel>.ValueCollection? GetAllClients()
        {
            return clients_dictionary.Count == 0 ? null : clients_dictionary.Values;
        }

        //Consulta o cliente pelo CPF;
        public ClientModel? GetClientByCpf(string cpf)
        {
            return clients_dictionary.ContainsKey(cpf) ? clients_dictionary[cpf] : null;
        }

        //Deleta o cliente pelo CPF
        public void DeleteClient(string cpf)
        {
            clients_dictionary.Remove(cpf);
        }

    }

}