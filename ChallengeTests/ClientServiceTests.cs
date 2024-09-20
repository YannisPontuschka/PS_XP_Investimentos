using Challenge.Services;
using Challenge.Models;
using Xunit;

namespace ChallengeTests
{

    //Classe de testes unitários para a classe de serviços do cliente

    public class ClientServiceTests
    {
        //Referência à classe de serviço do cliente
        private ClientService client_service;

        public ClientServiceTests()
        {
            client_service = new ClientService();
        }

        //Teste para adição do cliente
        [Fact]
        public void Should_AddClient_Successfully()
        {
            // Arrange
            string cpf = "385.579.150-39";
            string name = "Yannis Pontuschka";
            string email = "yannisp77@gmail.com";

            // Act
            ClientModel new_client = client_service.AddClient(cpf, name, email);

            // Assert
            Assert.NotNull(new_client);
            Assert.Equal(cpf, new_client.Cpf);
            Assert.Equal(name, new_client.Name);
            Assert.Equal(email, new_client.Email);
        }

        //Teste para consulta pelo cliente
        [Fact]
        public void Should_GetClientByCpf_ReturnsCorrectClient()
        {
            // Arrange
            string cpf = "818.573.120-90";
            string name = "Joãozinho";
            string email = "joao@gmail.com";
            client_service.AddClient(cpf, name, email);

            // Act
            ClientModel? client = client_service.GetClientByCpf(cpf);

            // Assert
            Assert.NotNull(client);
            Assert.Equal(cpf, client?.Cpf);
            Assert.Equal(name, client?.Name);
            Assert.Equal(email, client?.Email);
        }

        //Teste para consulta pelo cliente quando não existe
        [Fact]
        public void Should_ReturnNull_WhenClientDoesNotExist()
        {
            // Act
            ClientModel? client = client_service.GetClientByCpf("000.000.000-00");

            // Assert
            Assert.Null(client);
        }


        //Teste para atualização de email e nome do cliente
        [Theory]
        [InlineData("376.352.140-20", "Yax", "yax@unicamp.com", "Yex", "yax@usp.br")]
        [InlineData("522.242.610-63", "João", "bota@unicamp.com", "Jota", "Jota@usp.br")]
        [InlineData("798.350.110-28", "Pedro", "pedro@unicamp.com", "Pedrão", "pedro@unicamp.com")]
        [InlineData("212.323.440-01", "Sávio", "savio@unicamp.com", "Saviola", "saviola@usp.com")]
        public void Should_Update_Successfully(string cpf, string old_name, string old_email, string new_email, string new_name)
        {
            // Arrange
            client_service.AddClient(cpf, old_name, old_email);

            // Act
            client_service.UpdateClient(cpf, new_name, new_email);
            ClientModel? updated_client = client_service.GetClientByCpf(cpf);

            // Assert
            Assert.True(new_email == updated_client?.Email && new_name == updated_client?.Name);
        }


        //Teste para remoção de um cliente do banco de dados
        [Fact]
        public void Should_DeleteClient_Successfully()
        {
            // Arrange
            string cpf = "017.074.700-06";
            string name = "Fernanda";
            string email = "fernanda@usp.br";
            client_service.AddClient(cpf, name, email);

            // Act
            client_service.DeleteClient(cpf);
            ClientModel? client = client_service.GetClientByCpf(cpf);

            // Assert
            Assert.Null(client);
        }
    }
}
