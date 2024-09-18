using Challenge.Models;
using Challenge.Helper;
using Challenge.Services;
using Challenge.Exceptions;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Runtime.CompilerServices;
using System.Globalization;

//Classe de cliente para integrar a lógica de negócio

namespace Challenge.Services
{
    public class ClientService
    {
        //uso de um dicionário para armazenar os clientes em memória.
        private static Dictionary<string, Client> clients_dictionary = new Dictionary<string, Client>();

        public Client AddClient(string cpf, string name, string email)
        {

            //chama-se o construtor do namespace Models
            Client newClient = new Client(cpf, name, email);
            clients_dictionary.Add(newClient.cpf, newClient);
            return newClient;
        }

        public Dictionary<string, Client>.ValueCollection? GetAllClients()
        {
            return clients_dictionary.Count == 0 ? null : clients_dictionary.Values;
        }

        public Client? GetClientByCpf(string cpf)
        {
            //se o dicionário não contiver 'cpf', devolve-se null
            return clients_dictionary.ContainsKey(cpf) ? clients_dictionary[cpf] : null;
        }

        public void UpdateEmail(string cpf, string email)
        {
            clients_dictionary[cpf].email = email;
        }

        public void UpdateName(string cpf, string name)
        {
            clients_dictionary[cpf].name = name;
        }

        public void DeleteClient(string cpf)
        {
            clients_dictionary.Remove(cpf);
        }

    }

}