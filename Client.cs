namespace Challenge;

public class Client

{

    //Atributos no cliente
    public string  cpf {get; set;} 
    public string name {get; set;}
    public string email {get; set;}

    //Construtor da classe cliente
     public Client(string cpf, string name, string email)
        {
            this.cpf = cpf;
            this.name = name;
            this.email = email;
        }
}