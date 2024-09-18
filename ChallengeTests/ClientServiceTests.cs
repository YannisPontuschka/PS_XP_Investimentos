using Challenge.Services;
using Challenge.Models;
using Xunit;

namespace ChallengeTests
{

    //Classe de testes unitários para a classe de serviços do cliente

    public class ClientServiceTests
    {
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
            Client new_client = client_service.AddClient(cpf, name, email);

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
            Client? client = client_service.GetClientByCpf(cpf);

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
            Client? client = client_service.GetClientByCpf("000.000.000-00");

            // Assert
            Assert.Null(client);
        }

        //Teste para atualização do email do cliente

        [Fact]
        public void Should_UpdateEmail_Successfully()
        {
            // Arrange
            string cpf = "376.352.140-20";
            string name = "Yax";
            string email = "yax@unicamp.com";
            client_service.AddClient(cpf, name, email);

            string new_email = "yax77@usp.br";

            // Act
            client_service.UpdateEmail(cpf, new_email);
            Client? updatedClient = client_service.GetClientByCpf(cpf);

            // Assert
            Assert.Equal(new_email, updatedClient?.Email);
        }

        //Teste para atualização do nome do cliente

        [Fact]
        public void Should_UpdateName_Successfully()
        {
            // Arrange
            string cpf = "042.133.660-90";
            string name = "Pedro";
            string email = "pedro@unicamp.com";
            client_service.AddClient(cpf, name, email);

            string new_name = "Pedrao";

            // Act
            client_service.UpdateEmail(cpf, new_name);
            Client? updatedClient = client_service.GetClientByCpf(cpf);

            // Assert
            Assert.Equal(new_name, updatedClient?.Email);
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
            Client? client = client_service.GetClientByCpf(cpf);

            // Assert
            Assert.Null(client);
        }
    }
}
