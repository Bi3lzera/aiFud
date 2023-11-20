using System.Data;
using System.Globalization;
using System.IO;

using maintence;
using consumer;
using temp;
using payment;

namespace user_terminal
{
    public class terminal{
        consumer.consumer consumer = new consumer.consumer();
        maintence.maintence maintence = new maintence.maintence();
        public void start(){
            while(true){
                Console.WriteLine("Dentre as opções abaixo, digite o número da opção desejada:");
                Console.WriteLine("[1] - Iniciar Sistema");
                Console.WriteLine("[2] - Manutenção do Sistema");

                int option;
                bool nulo = int.TryParse(Console.ReadLine(), out option);

                if(nulo && option <= 2 && option >= 1) selectedOption(option);
                else Console.WriteLine("Opção incorreta, por favor, digite uma opção válida");
                
            }
        }

        private void selectedOption(int num){
            switch(num){
                case 1:
                    consumer.start();
                    break;
                case 2:
                    maintence.start();
                    break;
                default:
                    return;
            }
        }
    }

    public class maintenceText{
        public int option(){
            int selectedOption;

            while(true){
                Console.WriteLine("Dentre as opções abaixo, digite a opção desejada:");
                Console.WriteLine("[1] - Inserir vendedor");  

                bool nulo = int.TryParse(Console.ReadLine(), out selectedOption);

                if(nulo && selectedOption <= 1 && selectedOption >= 1) break;
                else Console.WriteLine("\nOpção digitada inválida, por favor, digite uma opção válida");
            }
            
            return selectedOption;
        }

        public string addVendor(){
            Console.Write("Digite o nome do Vendedor: ");
            string name = Console.ReadLine()!;
            if(name == null) name = "";
            return name;
        }
    }

    public class consumerText{
        consumer.action action = new consumer.action();
        payment.payment payment = new payment.payment();
        public int option_filter(){
            int selectedOption;

            while(true){
                Console.WriteLine("Selecione em como quer filtrar:");
                Console.WriteLine("[1] - Vendedores");  
                Console.WriteLine("[2] - Tipo de Comida");
                Console.WriteLine("\n[3] - Carrinho");

                bool nulo = int.TryParse(Console.ReadLine(), out selectedOption);

                if(nulo && selectedOption <= 3 && selectedOption >= 1) break;
                else Console.WriteLine("\nOpção digitada inválida, por favor, digite uma opção válida");
            }
            
            return selectedOption;
        }

        public int option_availableFood(int cod, string filter){
            int selectedOption;

            while(true){
                Console.WriteLine("SELECIONE A COMIDA DESEJADA DO CARDÁPIO:\n");
                foreach(DataRow row in tempMemory.food.Rows){
                    if(row[4].ToString() == cod.ToString() && filter == "vendor"){
                        Console.WriteLine($"[{row[0]}] - {row[1]} : R${row[3]}");
                    }

                    if(row[2].ToString() == cod.ToString() && filter == "foodType"){
                        Console.WriteLine($"[{row[0]}] - {row[1]} : R${row[3]} (Nota Restaurante {temp.tempMemory.vendor.Rows[Convert.ToInt32(row[4])][2]}/5)");
                    }
                }

                bool nulo = int.TryParse(Console.ReadLine(), out selectedOption);

                if(nulo && selectedOption <= 1 && selectedOption >= 1) break;
                else Console.WriteLine("\nOpção digitada inválida, por favor, digite uma opção válida");
            }
            
            return selectedOption;
        }

        public void listFoodType(){
            int selectedOption;

            while(true){
                Console.WriteLine("SELECIONE O TIPO DE COMIDA DESEJADA:\n");
                foreach(DataRow row in tempMemory.foodType.Rows){
                    Console.WriteLine($"[{row[0]}] - {row[1]}");
                }

                bool nulo = int.TryParse(Console.ReadLine(), out selectedOption);

                if(nulo && selectedOption <= tempMemory.foodType.Rows.Count && selectedOption >= 0) break;
                else Console.WriteLine("\nOpção digitada inválida, por favor, digite uma opção válida");
            }
            
            addToCart(option_availableFood(selectedOption, "foodType"));
        }
        public void listVendors(){
            int selectedOption;

            while(true){
                Console.WriteLine("\nRESTAURANTES:\n");
                foreach(DataRow vendor in temp.tempMemory.vendor.Rows){
                    Console.WriteLine($"[{vendor[0]}] - {vendor[1]} (NOTA {vendor[2]}/{5.0})");
                }

                bool nulo = int.TryParse(Console.ReadLine(), out selectedOption);

                if(nulo && selectedOption <= tempMemory.vendor.Rows.Count && selectedOption >= 0) break;
                else Console.WriteLine("\nOpção digitada inválida, por favor, digite uma opção válida");
            }

            addToCart(option_availableFood(Convert.ToInt32(temp.tempMemory.vendor.Rows[selectedOption][0]), "vendor"));
        }

        public void addToCart(int codFood){
            Console.WriteLine("Digite a quantidade deste item. (Caso queira cancelar, digite 0)");
            Console.Write("QUANTIDADE: ");
            int qntSelectedFood;
            while(!int.TryParse(Console.ReadLine(), out qntSelectedFood)){
                Console.WriteLine("Valor digitado inválido.");
            }

            action.addToCart(Convert.ToInt32(tempMemory.food.Rows[codFood][4]), codFood, qntSelectedFood);

            Console.WriteLine($"\n{qntSelectedFood} unidade(s) de {tempMemory.food.Rows[codFood][1]}, do restaurante {tempMemory.vendor.Rows[Convert.ToInt32(tempMemory.food.Rows[codFood][4])][1]}, no valor unitário de R${tempMemory.food.Rows[codFood][3]} (total R${Convert.ToDecimal(tempMemory.food.Rows[codFood][3]) * qntSelectedFood}) foram adicionados ao carrinho!\n");

            if(addMoreOrPay() == 1) listVendors();
            else payment.pay();
        }
        public void navigation(){
            int option = option_filter();
            switch(option){
                case 1:
                    listVendors();
                    break;
                case 2:
                    listFoodType();
                    break;
                case 3:
                    listCart();
                    break;
                default:
                    break;
            }
        }

        public void listCart(){
            foreach(DataRow item in tempMemory.cart.Rows){
                string foodName = tempMemory.food.Rows[Convert.ToInt32(item[1])][1].ToString();
                string vendorName;
                string foodQnt;
                string foodValue;
                Console.WriteLine($"{foodName}");
            }
        }
        public int addMoreOrPay(){
            Console.WriteLine("Deseja adicionar mais itens ao carrinho ou deseja finalizar o pedido? \n[1] - ADIONAR MAIS ITENS\n[2] - FINALIZAR PEDIDO");
            int option;
            while(!int.TryParse(Console.ReadLine(), out option) && option <= 2 && option >= 1){
                Console.WriteLine("Opção inválida");
            }

            return option;
        }
    }
}