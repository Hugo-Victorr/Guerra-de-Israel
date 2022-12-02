using Guerra_Israel.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;


namespace BatalhaDeIsrael
{
    class Program
    {
        private char letra;
        private int comprimento;
        private int quantidade;

        public static char[] mar = new char[60];

        public Program(char letra, int comprimento, int quantidade)
        {
            this.letra = letra;
            this.comprimento = comprimento;
            this.quantidade = quantidade;

        }

        static void Main(string[] args)
        {
            //instanciando objetos
            Program portaAvioes = new Program('P', 5, 1);
            Program cruzador = new Program('C', 4, 2);
            Program destroyer = new Program('D', 3, 3);
            Program submarino = new Program('S', 2, 3);


            bool inicio = true;

            Abertura();

            while (inicio == true)
            {

                //preencher o vetor mar com "agua"
                Preencher(ref mar);
                //mostra o vetor mar
                VistaMar(mar);


                bool teste = true;

                while (teste == true)
                {
                    Console.Clear();
                    VistaMar(mar);
                    Menu(portaAvioes, cruzador, destroyer, submarino);

                    string menu = Console.ReadLine();

                    int posicaoRandom = Posicao();


                    switch (menu)
                    {
                        case "1":
                            //verificação se caso a posição final é valida
                            if (portaAvioes.comprimento + posicaoRandom < 60)
                            {
                                Console.WriteLine("Posição sorteada: {0}", posicaoRandom);

                                //verificação de quantidade disponivel
                                if (portaAvioes.quantidade > 0)
                                {
                                    Colocar(portaAvioes, posicaoRandom, ref mar);
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("Esta embarcação não está mais disponivel, selecione outra!");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Posição invalida!");
                                Console.ReadKey();

                            }
                            break;

                        case "2":
                            //verificação se caso a posição final é valida
                            if (cruzador.comprimento + posicaoRandom < 60)
                            {
                                Console.WriteLine("Posição sorteada: {0}", posicaoRandom);

                                //verificação de quantidade disponivel
                                if (cruzador.quantidade > 0)
                                {
                                    Colocar(cruzador, posicaoRandom, ref mar);
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("Esta embarcação não está mais disponivel, selecione outra!");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Posição invalida!");
                                Console.ReadKey();
                            }
                            break;

                        case "3":
                            //verificação se caso a posição final é valida
                            if (destroyer.comprimento + posicaoRandom < 60)
                            {
                                Console.WriteLine("Posição sorteada: {0}", posicaoRandom);

                                //verificação de quantidade disponivel
                                if (destroyer.quantidade > 0)
                                {
                                    Colocar(destroyer, posicaoRandom, ref mar);
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("Esta embarcação não está mais disponivel, selecione outra!");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Posição invalida!");
                                Console.ReadKey();
                            }
                            break;

                        case "4":
                            //verificação se caso a posição final é valida
                            if (submarino.comprimento + posicaoRandom < 60)
                            {
                                Console.WriteLine("Posição sorteada: {0}", posicaoRandom);

                                //verificação de quantidade disponivel
                                if (submarino.quantidade > 0)
                                {
                                    Colocar(submarino, posicaoRandom, ref mar);
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("Esta embarcação não está mais disponivel, selecione outra!");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Posição invalida!"); ;
                                Console.ReadKey();
                            }
                            break;

                        default:
                            Console.WriteLine("Digite uma opção válida");
                            break;
                    }
                    //verificação de final de jogo
                    if ((portaAvioes.quantidade == 0) && (cruzador.quantidade == 0) && (destroyer.quantidade == 0) && (submarino.quantidade == 0))
                    {
                        inicio = false;
                        teste = false;
                        Console.Clear();
                        VistaMar(mar);
                        Menu(portaAvioes, cruzador, destroyer, submarino);
                    }

                }

                Console.WriteLine("PARABENS!!!!! VOCÊ CONSEGUIU POSICIONAR TODAS AS EMBARCAÇÕES!!");
                Console.ReadKey();
            }

        }

        //verificando e posicionando a embarcação no vetor
        public static void Colocar(Program obj, int posicao, ref char[] mar)
        {
            bool validar = true;

            for (int i = posicao; i < obj.comprimento + posicao; i++)
            {
                if (mar[i] != '≈')
                {
                    Console.WriteLine("Posição não disponível!!");
                    validar = false;
                    break;
                }

                else
                {

                }
            }
            if (validar == true)
            {
                for (int i = posicao; i < obj.comprimento + posicao; i++)
                {
                    mar[i] = obj.letra;
                }
                SubQuant(ref obj);
            }


        }
        //preenchendo o vetor mar com "agua"
        public static void Preencher(ref char[] mar)
        {
            int tamanho = mar.Length - 1;

            for (int i = 0; i <= tamanho; i++)
            {
                mar[i] = '≈';

            }
        }

        //mostrando o vetor mar
        public static void VistaMar(char[] mar)
        {
            int tamanho = mar.Length - 1;
            for (int i = 0; i <= tamanho; i++)
            {
                if (i == 15 || i == 30 || i == 45)
                {
                    Console.WriteLine("\n");
                }
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write(mar[i]);
            }
        }

        //gerando posição aleatoria
        public static int Posicao()
        {
            Random posicao = new Random();
            return posicao.Next(0, 60);

        }

        //menos 1 na quantidade do objeto
        public static void SubQuant(ref Program obj)
        {
            obj.quantidade -= 1;
        }

        //menu
        public static void Menu(Program obj1, Program obj2, Program obj3, Program obj4)
        {
            Console.WriteLine("\nEscolha qual embarcação deseja posicionar: \n" +
                        "1 - Porta Aviões\t" + "Restam: {0}\n" +
                        "2 - Cruzador\t\t" + "Restam: {1}\n" +
                        "3 - Destroyer\t\t" + "Restam: {2}\n" +
                        "4 - Submarino\t\t" + "Restam: {3}\n", obj1.quantidade, obj2.quantidade, obj3.quantidade, obj4.quantidade);
        }

        static void WriteASCII(string[] texto, bool escolha) //Escreve o texto e colore
                                                             //TRUE para colorir 
                                                             //FALSE para não colorir
        {
            if (escolha == true) //Não achei uma outra forma de trocar as cores nesta ordem.
            {
                Console.ForegroundColor = ConsoleColor.Black;

                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(texto[0]);

                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine(texto[1]);

                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine(texto[2]);

                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(texto[3]);

                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine(texto[4]);

                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(texto[5]);
            }
            else
            {
                for (int i = 0; i < texto.Length; i++)
                {
                    Console.WriteLine(texto[i]);
                }
            }
        }
        static void Abertura() //Tela de início
        {

            String[] titulo = { "\r ██████╗ ██╗   ██╗███████╗██████╗ ██████╗  █████╗     ██████╗  ██████╗     ██╗███████╗██████╗  █████╗ ███████╗██╗     ",
                            "    \r██╔════╝ ██║   ██║██╔════╝██╔══██╗██╔══██╗██╔══██╗    ██╔══██╗██╔═══██╗    ██║██╔════╝██╔══██╗██╔══██╗██╔════╝██║     ",
                              "   \r██║  ███╗██║   ██║█████╗  ██████╔╝██████╔╝███████║    ██║  ██║██║   ██║    ██║███████╗██████╔╝███████║█████╗  ██║   "  ,
                                 "\r██║   ██║██║   ██║██╔══╝  ██╔══██╗██╔══██╗██╔══██║    ██║  ██║██║   ██║    ██║╚════██║██╔══██╗██╔══██║██╔══╝  ██║     " ,
                                   "\r╚██████╔╝╚██████╔╝███████╗██║  ██║██║  ██║██║  ██║    ██████╔╝╚██████╔╝    ██║███████║██║  ██║██║  ██║███████╗███████╗  " ,
                                  " \r ╚═════╝  ╚═════╝ ╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝    ╚═════╝  ╚═════╝     ╚═╝╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝╚══════╝    \r                                                                                                                        \r\n"};

            WriteASCII(titulo, true);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            String[] fundo = { "                  ~.\r\n           Ya...___|__..aab     .   .\r\n            Y88a  Y88o  Y88a   (     )\r\n             Y88b  Y88b  Y88b   `.oo'\r\n             :888  :888  :888  ( (`-'\r\n    .---.    d88P  d88P  d88P   `.`.\r\n   / .-._)  d8P'\"\"\"|\"\"\"'-Y8P      `.`.\r\n  ( (`._) .-.  .-. |.-.  .-.  .-.   ) )\r\n   \\ `---( O )( O )( O )( O )( O )-' /\r\n    `.    `-'  `-'  `-'  `-'  `-'  .' CJ\r\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" };
            WriteASCII(fundo, false);




            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("Pressione qualquer botão para continuar...\n");

            Sons("ABTR");

            Console.ReadKey();


            Console.Clear();
        }
        static void Sons(string somesco) //Função de sons (Foram escolhidas Strings para melhor entendimento).
        {


            SoundPlayer abertura = new SoundPlayer(Resources.Abertura);

            switch (somesco)
            {
                case "ABTR":
                    abertura.Play();
                    break;

            }
        }
    }


}

