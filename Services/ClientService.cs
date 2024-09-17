using Challenge.Models;
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
        private static Dictionary<string, Client> clients_dictionary = new Dictionary<string, Client>();
        private static void ValidateCPF(string cpf)
        {

            if (string.IsNullOrWhiteSpace(cpf))
                throw new InvalidCPFException("O CPF inválido - entrada vazia.");
            //validação do formato do CPF
            if (!HasValidCpfStructure(cpf))
                throw new InvalidCPFException("CPF inválido - formatação incorreta. ");
            //validação da corretude dos números do CPF.
            if (!HasValidCpfDigits(cpf))
                throw new InvalidCPFException("CPF inválido - formato correto, mas sequência impossível.");
        }

        private static void ValidateName(string name)
        {
            // Verifica se o nome está vazio ou nulo
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidNameException("O nome não pode estar vazio.");

            // Verifica o comprimento do nome
            if (name.Length < 2 || name.Length > 50)
                throw new InvalidNameException("O nome deve ter entre 2 e 50 caracteres.");
    
            // Verifica se o nome contém apenas letras
            if (!Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
                throw new InvalidNameException("O nome deve conter apenas letras");
        }

        public static void ValidateEmail(string email)
        {
            // Verifica se o email está vazio ou nulo
            if (string.IsNullOrWhiteSpace(email))
                throw new InvalidEmailException("O e-mail não pode estar vazio.");
            // Verifica se o e-mail segue o padrão
            if (!HasValidEmailStructure(email))
                throw new InvalidEmailException("O e-mail fornecido é inválido.");
        }

        private static bool HasValidCpfDigits(string cpf)
        {
            // Remover todos os caracteres não numéricos do CPF
            string formatted_cpf = Regex.Replace(cpf, @"\D", string.Empty);

            // Verificar se o CPF tem exatamente 11 dígitos
            if (formatted_cpf.Length != 11)
                return false;

            // Extrair os dígitos verificadores informados
            int first_digit = int.Parse(formatted_cpf[9].ToString());
            int second_digit = int.Parse(formatted_cpf[10].ToString());

            // Calcular o primeiro dígito verificador
            int sum1 = 0;
            for (int i = 0; i < 9; i++)
                sum1 += int.Parse(formatted_cpf[i].ToString()) * (10 - i);
                
            int calculated_first_digit = (sum1 * 10) % 11;
            calculated_first_digit = calculated_first_digit == 10 ? 0 : calculated_first_digit;

            // Calcular o segundo dígito verificador
            int sum2 = 0;
            for (int i = 0; i < 10; i++)
                sum2 += int.Parse(formatted_cpf[i].ToString()) * (11 - i);
         
            int calculated_second_digit = (sum2 * 10) % 11;
            calculated_second_digit = calculated_second_digit == 10 ? 0 : calculated_second_digit;

            // Verificar se os dígitos calculados são iguais aos informados
            return calculated_first_digit == first_digit && calculated_second_digit == second_digit;
        }

        private static bool HasValidCpfStructure(string cpf)
        {
            string cpf_pattern = @"\d{3}.\d{3}.\d{3}-\d{2}";
            if (!Regex.IsMatch(cpf, cpf_pattern))
                return false;
            return true;
        }

        private static bool HasValidEmailStructure(string email)
        {
            string email_pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(email, email_pattern))
                return false;
            return true;
        }

        public Client AddClient(string cpf, string name, string email)
        {  //validar parametros

            Client newClient = new Client(cpf, name, email);
            clients_dictionary.Add(newClient.cpf, newClient);
            return newClient;
        }

        public Dictionary<string, Client>.ValueCollection GetAllClients()
        {
            //verificar se há pelo menos um cliente
            return clients_dictionary.Values;
        }

        public Client GetClientByCpf(string cpf)
        {
            //validar CPF
            //verificar se ele existe no banco de dados
            return clients_dictionary.ContainsKey(cpf) ? clients_dictionary[cpf] : null;
        }

        public void UpdateEmail(string cpf, string email)
        {

            //validar CPF
            //verificar se ele existe no banco de dados
            if (clients_dictionary.ContainsKey(cpf))
            {
                clients_dictionary[cpf].email = email;
            }
        }

        public void UpdateName(string cpf, string name)
        {
            //validar CPF
            //verificar se ele existe no banco de dados
            if (clients_dictionary.ContainsKey(cpf))
            {
                clients_dictionary[cpf].name = name;
            }
        }

        public void DeleteClient(string cpf)
        {
            //validar CPF
            //verificar se ele existe no banco de dados
            clients_dictionary.Remove(cpf);
        }

    }

}