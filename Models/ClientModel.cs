namespace Challenge.Models{

    //Classe modelo do cliente, define a entidade a ser usada com modelo de dados
    public class Client
    {
        //Atributos no cliente
        public string cpf {get; set;} 
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
}