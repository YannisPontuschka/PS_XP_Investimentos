namespace Challenge;

//Classe de cliente para integrar a lógica de negócio
public class ClientService
{
    private static Dictionary<string, Client> clients_dictionary = new Dictionary<string, Client>();

    public Client AddClient(string cpf, string name, string email)
    {
        Client newClient = new Client(cpf, name, email);
        clients_dictionary.Add(newClient.cpf, newClient);
        return newClient;
    }

    public IEnumerable<Client> GetAllClients()
    {
        return clients_dictionary.Values;
    }

    public Client GetClientByCpf(string cpf)
    {
        return clients_dictionary.ContainsKey(cpf) ? clients_dictionary[cpf] : null;
    }

    public void UpdateEmail(string cpf, string email)
    {
        if (clients_dictionary.ContainsKey(cpf))
        {
            clients_dictionary[cpf].email = email;
        }
    }

    public void UpdateName(string cpf, string name)
    {
        if (clients_dictionary.ContainsKey(cpf))
        {
            clients_dictionary[cpf].name = name;
        }
    }

    public void DeleteClient(string cpf)
    {
        clients_dictionary.Remove(cpf);
    }

}