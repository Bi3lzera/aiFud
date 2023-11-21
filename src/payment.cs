
namespace payment{
    class payment{
        string endereco = string.Empty;
        string pontoRef = string.Empty;
        string name = string.Empty;
        string paymentMethod = string.Empty;
        public bool pay(){
            user_terminal.consumerText t = new user_terminal.consumerText();

            Console.WriteLine("=====PAGAMENTO======");
            t.listCart(frete(), false);
            
            Console.WriteLine("SELECIONE A FORMA DE PAGAMENTO:\n");
            Console.WriteLine("[0] - Cartão de Crédito/Débito");
            Console.WriteLine("[1] - Pix");

            int option;
            while(!int.TryParse(Console.ReadLine(), out option) && option <= 1 && option >= 0){
                Console.WriteLine("Opção inválida");
            }

            switch(option){
                case 0:
                    paymentMethod = "Cartão de Crédito/Débito";
                    break;
                case 1:
                    paymentMethod = "Pix";
                    break;
                default:
                    break;
            }

            Console.WriteLine("DESEJA CONFIRMAR?");
            Console.WriteLine("[1] - SIM");
            Console.WriteLine("[2] - NÃO");

            while(!int.TryParse(Console.ReadLine(), out option) && option <= 2 && option >= 1){
                Console.WriteLine("Opção inválida");
            }

            if(option == 1){
                Console.WriteLine("##########PEDIDO CONFIRMADO COM SUCESSO!###############");
                Console.WriteLine("*EM ATÉ 60 MINUTOS O PEDIDO SERÁ ENTREGUE EM SEU ENDEREÇO.");
                Console.WriteLine("**O PAGAMENTO SERÁ REALIZADO NO MOMENTO DA ENTREGA");
                Console.WriteLine("#######################################################");
                Console.WriteLine("Sistema voltando ao início...\nPressione ENTER\n\n\n\n");
                Console.ReadKey();
                temp.tempMemory.cart.Rows.Clear();
                return true;
            }else{
                return false;
            }
        }

        public decimal frete(){
            Console.Write("DIGITE SEU ENDEREÇO COMPLETO: ");
            endereco = Console.ReadLine()!;
            Console.Write("DIGITE UM PONTO DE REFERÊNCIA: ");
            pontoRef = Console.ReadLine()!;
            Console.Write("DIGITE O NOME DE QUEM IRÁ RECEBER: ");
            name = Console.ReadLine()!;

            return 5;
        }
    }
}