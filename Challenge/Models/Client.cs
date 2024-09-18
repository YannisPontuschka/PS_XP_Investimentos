namespace Challenge.Models{

    //Classe modelo do cliente, define a entidade a ser usada com modelo de dados
    public class Client
    {
        //Atributos no cliente
        public string Cpf {get; set;} 
        public string Name {get; set;}
        public string Email {get; set;}

        //Construtor da classe cliente
        public Client(string cpf, string name, string email)
            {
                this.Cpf = cpf;
                this.Name = name;
                this.Email = email;
            }
    }
}