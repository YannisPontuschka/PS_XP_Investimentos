using System;
using System.Text.RegularExpressions;

namespace Challenge.Helper
{
    //Classe de validação dos atributos da classe cliente.
    public class ClientValidation
    {
        //método de validação de CPF
        public static bool ValidateCPF(string cpf)
        {
            //Testa se é vazio
            if (string.IsNullOrWhiteSpace(cpf))
                return false;
            //Validação do formato do CPF
            if (!HasValidCpfStructure(cpf))
                return false;
            //Validação da corretude dos números do CPF.
            if (!HasValidCpfDigits(cpf))
                return false;
            return true;
        }

        //Validação de nome
        public static bool ValidateName(string name)
        {
            // Verifica se o nome está vazio ou nulo
            if (string.IsNullOrWhiteSpace(name))
                return false;

            // Verifica o comprimento do nome
            if (name.Length < 2 || name.Length > 50)
                return false;

            // Verifica se o nome contém apenas letras
            if (!HasValidNameStructure(name))
                return false;
            return true;

        }

        //Validação de email
        public static bool ValidateEmail(string email)
        {
            // Verifica se o email está vazio ou nulo
            if (string.IsNullOrWhiteSpace(email))
                return false;
            // Verifica se o e-mail segue o padrão
            if (!HasValidEmailStructure(email))
                return false;
            return true;
        }

        //Validação dos dígitos finais do CPF
        private static bool HasValidCpfDigits(string cpf)
        {
            string formatted_cpf = Regex.Replace(cpf, @"\D", string.Empty);
            if (formatted_cpf.Length != 11)
                return false;

            int first_digit = int.Parse(formatted_cpf[9].ToString());
            int second_digit = int.Parse(formatted_cpf[10].ToString());
            int sum1 = 0;

            for (int i = 0; i < 9; i++)
                sum1 += int.Parse(formatted_cpf[i].ToString()) * (10 - i);

            int calculated_first_digit = (sum1 * 10) % 11;
            calculated_first_digit = calculated_first_digit == 10 ? 0 : calculated_first_digit;


            int sum2 = 0;
            for (int i = 0; i < 10; i++)
                sum2 += int.Parse(formatted_cpf[i].ToString()) * (11 - i);

            int calculated_second_digit = (sum2 * 10) % 11;
            calculated_second_digit = calculated_second_digit == 10 ? 0 : calculated_second_digit;

            return calculated_first_digit == first_digit && calculated_second_digit == second_digit;
        }

        //Validação da estrutura do CPF - auxiliar ao método principal
        private static bool HasValidCpfStructure(string cpf)
        {
            string cpf_pattern = @"^\d{3}.\d{3}.\d{3}-\d{2}$";
            if (!Regex.IsMatch(cpf, cpf_pattern))
                return false;
            return true;
        }

        //Validação da estrutura do Email - auxiliar ao método principal
        private static bool HasValidEmailStructure(string email)
        {
            string email_pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(email, email_pattern))
                return false;
            return true;
        }

        //Validação da estrutura do nome - auxiliar ao método principal
        private static bool HasValidNameStructure(string name)
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Zà-úÀ-Ú\s]{3,}$"))
                return false;
            return true;
        }

    }

}