using ADS_ED2_20230821.Controllers;
using ADS_ED2_20230821.Models;

namespace ADS_ED2_20230821;

internal class Program
{
    static void Main(string[] args)
    {
        ContatosController controller = new ContatosController();

        void addContato()
        {
            Console.WriteLine("--- Adicionar contato ---\n");

            Console.Write("Digite um email: ");
            string email = Console.ReadLine();

            Console.Write("Digite um nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o dia de nascimento: ");
            int dia = int.Parse(Console.ReadLine());

            Console.Write("Digite o mes de nascimento: ");
            int mes = int.Parse(Console.ReadLine());

            Console.Write("Digite o ano de nascimento: ");
            int ano = int.Parse(Console.ReadLine());

            ContatoController contato = new ContatoController(
                email, 
                nome, 
                new DataController(dia, mes, ano),
                new List<TelefoneModel>()
                );

            Console.WriteLine();

            Console.WriteLine(controller.Adicionar(contato) ? "Contato adicionado." : "Contato não adicionado.");

            Console.WriteLine("\n--- Adicionar contato ---\n");
        }

        void addTelefone()
        {
            Console.WriteLine("--- Adicionar telefone ---\n");

            Console.Write("Digite o email de um contato: ");
            string email = Console.ReadLine();

            ContatoController contato = new(email);

            contato = controller.pesquisar(contato);

            if (contato.Email == "")
            {
                Console.WriteLine("\nContato não encontrado.");

                Console.WriteLine("\n--- Adicionar telefone ---\n");
                return;
            }

            Console.Write("\nDigite o tipo de telefone: ");
            string tipo = Console.ReadLine();

            Console.Write("\nDigite o numero de telefone: ");
            string numero = Console.ReadLine();

            Console.Write("\nÉ principal (Y/n) ? : ");
            string principal = Console.ReadLine();

            TelefoneModel telefone = new(tipo, numero, principal.ToUpper() == "Y");

            contato.adicionarTelefone(telefone);

            Console.WriteLine("Telefone adicionado.");

            Console.WriteLine("\n--- Adicionar telefone ---\n");
        }

        void getContato()
        {
            Console.WriteLine("--- Buscar telefone ---\n");

            Console.Write("\nDigite o email de um contato: ");
            string email = Console.ReadLine();

            ContatoController contato = new(email);

            contato = controller.pesquisar(contato);

            Console.WriteLine(contato.Email != "" ? contato.ToString() : "Contato não encontrado");

            Console.WriteLine("\n--- Buscar telefone ---\n");
        }

        void editContato()
        {
            Console.WriteLine("--- Editar contato ---\n");

            Console.Write("\nDigite o email de um contato: ");
            string email = Console.ReadLine();

            ContatoController contato = new(email);

            contato = controller.pesquisar(contato);

            if (contato.Email == "")
            {
                Console.WriteLine("\nContato não encontrado.");
                return;
            }

            Console.Write("Digite um nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o dia de nascimento: ");
            int dia = int.Parse(Console.ReadLine());

            Console.Write("Digite o mes de nascimento: ");
            int mes = int.Parse(Console.ReadLine());

            Console.Write("Digite o ano de nascimento: ");
            int ano = int.Parse(Console.ReadLine());

            ContatoController editedContato = new(
                email,
                nome,
                new DataController(dia, mes, ano),
                contato.Telefones
                );

            Console.WriteLine(controller.alterar(contato) ? "Contato alterado." : "Contato não alterado.");

            Console.WriteLine("\n--- Editar contato ---\n");
        }

        void deleteContato()
        {
            Console.WriteLine("--- Deletar contato ---\n");

            Console.Write("\nDigite o email de um contato: ");
            string email = Console.ReadLine();

            ContatoController contato = new(email);

            contato = controller.pesquisar(contato);

            if (contato.Email == "")
            {
                Console.WriteLine("\nContato não encontrado.");
                return;
            }

            Console.WriteLine(controller.remover(contato) ? "Contato removido." : "Contato não removido.");

            Console.WriteLine("\n--- Deletar contato ---\n");
        }

        void getAllContatos()
        {
            Console.WriteLine("--- Visualizar todos os contatos ---\n");

            if (controller.Agenda.Count == 0)
            {
                Console.WriteLine("Não há contatos cadastrados.");

                Console.WriteLine("\n--- Visualizar todos os contatos ---\n");

                return;
            }

            int sum = 0;

            foreach (ContatoController c in controller.Agenda)
            {
                Console.WriteLine(c.ToString());
                sum++;
            }

            Console.WriteLine($"\nTotal de contatos cadastrados: {sum}");

            Console.WriteLine("\n--- Visualizar todos os contatos ---\n");
        }

        while (true)
        {
            int option;

            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Adicionar contato");
            Console.WriteLine("2. Adicionar telefone no contato");
            Console.WriteLine("3. Pesquisar contato");
            Console.WriteLine("4. Alterar contato");
            Console.WriteLine("5. Remover contato");
            Console.WriteLine("6. Listar contatos");

            Console.Write("\nEscolha uma opção: ");
            option = int.Parse(Console.ReadLine());

            Console.Clear();

            switch (option)
            {
                case 1:
                    addContato();
                    break;
                case 2:
                    addTelefone();
                    break;
                case 3:
                    getContato();
                    break;
                case 4:
                    editContato();
                    break;
                case 5:
                    deleteContato();
                    break;
                case 6:
                    getAllContatos();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}