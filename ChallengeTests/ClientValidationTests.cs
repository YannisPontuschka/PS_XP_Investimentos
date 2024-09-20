using Challenge.Helper;
using Xunit;

namespace ChallengeTests
{
    public class ClientValidationTests
    {
        // Testes para CPF
        [Theory]
        [InlineData("345.743.928-19", true)] // CPF válido
        [InlineData("123.123.123-45", false)] // CPF inválido
        [InlineData("123.123.123", false)] // CPF com menos de 11 dígitos
        [InlineData("a2rf2341521fsa", false)] // CPF com estrutura incorreta
        public void ValidateCPF_ShouldReturnExpectedResult(string cpf, bool expected)
        {
            // Act
            bool is_cpf_valid = ClientValidation.ValidateCPF(cpf);

            // Assert
            Assert.True(is_cpf_valid == expected);
        }

        // Testes para Nome
        [Theory]
        [InlineData("Yannis", true)] //Nome válido
        [InlineData("", false)] //Nome vazio
        [InlineData("124214", false)] //Nome de números
        [InlineData(" ", false)] //Nome com números
        [InlineData("Yannis Bianchini Pontuschka", true)] //Nome composto
        [InlineData("Y", false)] //Nome muito pequeno
        public void ValidateName_ShouldReturnExpectedResult(string name, bool expected)
        {
            // Act
            bool is_name_valid = ClientValidation.ValidateName(name);

            // Assert
            Assert.True(is_name_valid == expected);
        }

        // Testes para Email
        [Theory]
        [InlineData("yannisp77@usp.br", true)] //Email válido
        [InlineData("yannisp77usp.br", false)] //Email sem @
        [InlineData("yannisp77@", false)] //Email sem domínio
        [InlineData("yannisp77@usp.", false)] //Email com domínio incompleto
        [InlineData("yannis!p77@usp.br", false)] //Email com caracter especial

        public void ValidateEmail_ShouldReturnExpectedResult(string email, bool expected)
        {
            // Act
            bool is_email_valid = ClientValidation.ValidateEmail(email);

            // Assert
            Assert.True(is_email_valid == expected);
        }
    }
}
