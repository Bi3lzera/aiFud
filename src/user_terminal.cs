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
        user_terminal.consumerText consumer = new user_terminal.consumerText();
        maintence.action action = new maintence.action();
        function.function func = new function.function();
        public int option(){
            int selectedOption;

            while(true){
                Console.WriteLine("\nDIGITE A OPÇÃO DESEJADA:");
                Console.WriteLine("[1] - Inserir restaurante");
                Console.WriteLine("[2] - Excluir restaurante");
                Console.WriteLine("[3] - Inserir prato");
                Console.WriteLine("[4] - Excluir prato");
                Console.WriteLine("");  

                bool nulo = int.TryParse(Console.ReadLine(), out selectedOption);

                if(nulo && selectedOption <= 4 && selectedOption >= 1) break;
                else Console.WriteLine("\n***Opção digitada inválida, por favor, digite uma opção válida***\n");
            }
            
            return selectedOption;
        }

        public string addVendor(){
            Console.Write("DIGITE O NOME DO VENDEDOR: ");
            string name = Console.ReadLine()!;
            if(name == null) name = "";
            return name;
        }

        public int delVendor(){
            consumerText consumerText = new consumerText();
            consumerText.listVendors(true);
            Console.WriteLine("DIGITE O CÓDIGO DO VENDEDOR A SER EXCLUÍDO: ");
            Console.WriteLine("Para cancelar, digite [-1]");
            int cod;
            while(!int.TryParse(Console.ReadLine(), out cod)){
                Console.WriteLine("VALOR DIGITADO ESTÁ INCORRETO, VERIFIQUE.");
            }
            return cod;
        }

        public void addFood(){
            consumerText consumerText = new consumerText();
            consumerText.listVendors(true);
            Console.WriteLine("DIGITE O CÓDIGO DO RESTURANTE A QUE SERÁ ADICIONADO O PRATO: ");
            Console.WriteLine("Para cancelar, digite [-1]");
            int cod;
            while(!int.TryParse(Console.ReadLine(), out cod)){
                Console.WriteLine("VALOR DIGITADO ESTÁ INCORRETO, VERIFIQUE.");
            }
            if(cod == -1) return;

            Console.Write("DIGITE O NOME DO PRATO: ");
            string name = Console.ReadLine()!;
            Console.WriteLine("DIGITE O TIPO DO PRATO, SENDO UM DA LISTA ABAIXO:");
            foreach(DataRow row in tempMemory.foodType.Rows){
                Console.WriteLine($"[{row[0]} - {row[1]}]");
            }

            int codFoodType;
            while(!int.TryParse(Console.ReadLine(), out codFoodType) && !func.codExist(codFoodType, tempMemory.foodType)){
                if(codFoodType == -1) return;
                Console.WriteLine("Opção digitada inválida. (Digite [-1] para cancelar)");
            }

            Console.Write("DIGITE O VALOR DO PRATO: ");
            decimal foodValue;
            while(!decimal.TryParse(Console.ReadLine(), out foodValue)){
                Console.WriteLine("Valor digitado inválido.");
            }

            action.addFood(name, foodValue, codFoodType, cod);
        }

        public void delFood(){
            consumerText consumerText = new consumerText();
            consumerText.listVendors(true);
            Console.WriteLine("DIGITE O CÓDIGO DO RESTURANTE A QUE SERÁ EXCLUÍDO O PRATO: ");
            Console.WriteLine("Para cancelar, digite [-1]");
            int cod;
            while(!int.TryParse(Console.ReadLine(), out cod)){
                Console.WriteLine("VALOR DIGITADO ESTÁ INCORRETO, VERIFIQUE.");
            }
            if(cod == -1) return;
            consumer.option_availableFood(cod, "vendor", true);
            Console.WriteLine("DIGITE O CÓDIGO DO PRATO A SER EXCLUÍDO");
            int codFood;
            while(!int.TryParse(Console.ReadLine(), out codFood) && !func.codExist(codFood, tempMemory.food) && tempMemory.food.Rows[func.findIndexByCod(codFood, tempMemory.food)][4].ToString() == cod.ToString()){
                if(codFood == -1) return;
                Console.WriteLine("Opção digitada inválida. (Digite [-1] para cancelar)");
            }
            
            action.delFood(codFood);
        }
    }

    public class consumerText{
        function.function function  = new function.function();
        consumer.action action = new consumer.action();
        payment.payment payment = new payment.payment();
        public int option_filter(){
            int selectedOption;

            while(true){
                Console.WriteLine("\nDIGITE A OPÇÃO DESEJADA:\n");

                Console.WriteLine("FILTRO:");
                Console.WriteLine("[1] - Vendedores");  
                Console.WriteLine("[2] - Tipo de Comida");

                Console.WriteLine("\nOUTRAS OPÇÕES:");
                Console.WriteLine("[3] - Carrinho");
                Console.WriteLine("[4] - Avaliar um Restaurante");

                Console.WriteLine("\n[-1] - Voltar");
                
                bool nulo = int.TryParse(Console.ReadLine(), out selectedOption);

                if(nulo && selectedOption <= 4 && selectedOption >= 1) break;
                else if (goBack(selectedOption)) return -1;
                else Console.WriteLine("\n***Opção digitada inválida, por favor, digite uma opção válida***\n");
            }
            
            return selectedOption;
        }
        public int option_availableFood(int cod, string filter, bool justList = false){
            int selectedOption;

            while(true){
                Console.WriteLine("\nSELECIONE A COMIDA DESEJADA DO CARDÁPIO:\n");

                foreach(DataRow row in tempMemory.food.Rows){
                    if(row[4].ToString() == cod.ToString() && filter == "vendor"){
                        Console.WriteLine($"[{row[0]}] - {row[1]} : R${row[3]}");
                    }

                    if(row[2].ToString() == cod.ToString() && filter == "foodType"){
                        Console.WriteLine($"[{row[0]}] - {row[1]} : R${row[3]} (Nota Restaurante {temp.tempMemory.vendor.Rows[Convert.ToInt32(row[4])][2]}/5)");
                    }
                }

                if(justList) return 0;

                Console.WriteLine("\n[-1] - Voltar\n");

                bool nulo = int.TryParse(Console.ReadLine(), out selectedOption);

                if(goBack(selectedOption)) return -1;
                if(!function.codExist(selectedOption, temp.tempMemory.food)){
                    Console.WriteLine("\n***Opção digitada inválida, por favor, digite uma opção válida***\n");
                    continue;
                } 
                if(nulo && function.codExist(selectedOption, tempMemory.food) && selectedOption >= 0 && (tempMemory.food.Rows[function.findIndexByCod(selectedOption, tempMemory.food)][4].ToString() == cod.ToString() && filter == "vendor") || (tempMemory.food.Rows[function.findIndexByCod(selectedOption, tempMemory.food)][2].ToString() == cod.ToString() && filter == "foodType") ) break;
                else Console.WriteLine("\n***Opção digitada inválida, por favor, digite uma opção válida***\n");
            }
            
            return selectedOption;
        }
        public void listFoodType(bool justList = false){
            int selectedOption;

            while(true){
                Console.WriteLine("\nSELECIONE O TIPO DE COMIDA DESEJADA:\n");
                foreach(DataRow row in tempMemory.foodType.Rows){
                    Console.WriteLine($"[{row[0]}] - {row[1]}");
                }
                
                if(justList) return;

                Console.WriteLine("\n[-1] - Voltar\n");

                bool nulo = int.TryParse(Console.ReadLine(), out selectedOption);

                if (goBack(selectedOption)) return;

                if(nulo && function.codExist(selectedOption, tempMemory.food) && selectedOption >= 0) break;
                else Console.WriteLine("\n***Opção digitada inválida, por favor, digite uma opção válida***\n");
            }

            int foodOption;
            if(selectedOption != -1) {
                foodOption = option_availableFood(selectedOption, "foodType");
                if(foodOption != -1) addToCart(foodOption);
            }
        }
        public void listVendors(bool justList = false){
            int selectedOption;

            while(true){
                Console.WriteLine("\nRESTAURANTES:\n");
                foreach(DataRow vendor in temp.tempMemory.vendor.Rows){
                    Console.WriteLine($"[{vendor[0]}] - {vendor[1]} (NOTA {vendor[2]}/{5.0})");
                }
                
                if(justList) return;

                Console.WriteLine("\n[-1] - Voltar");

                bool nulo = int.TryParse(Console.ReadLine(), out selectedOption);

                if (goBack(selectedOption)) return;

                if(nulo && function.codExist(selectedOption, tempMemory.vendor) && selectedOption >= 0) break;
                else Console.WriteLine("\n***Opção digitada inválida, por favor, digite uma opção válida***\n");
            }

            int foodOption;
            if(selectedOption != -1) {
                foodOption = option_availableFood(selectedOption, "vendor");
                if(foodOption != -1) addToCart(foodOption);
            }
        }
        public void addToCart(int codFood){
            Console.WriteLine("Digite a quantidade deste item. (Caso queira cancelar, digite 0)");
            Console.Write("QUANTIDADE: ");
            int qntSelectedFood;
            while(!int.TryParse(Console.ReadLine(), out qntSelectedFood)){
                Console.WriteLine("Valor digitado inválido.");
            }

            action.addToCart(Convert.ToInt32(tempMemory.food.Rows[function.findIndexByCod(codFood, tempMemory.food)][4]), codFood, qntSelectedFood);
            Console.WriteLine($"{function.findIndexByCod(codFood, tempMemory.food)} - {tempMemory.food.Rows.Count}");
            Console.WriteLine($"\n{qntSelectedFood} unidade(s) de {tempMemory.food.Rows[function.findIndexByCod(codFood, tempMemory.food)][1]}, do restaurante {tempMemory.vendor.Rows[function.findIndexByCod(Convert.ToInt32(tempMemory.food.Rows[function.findIndexByCod(codFood, tempMemory.food)][4]), tempMemory.vendor)][1]}, no valor unitário de R${tempMemory.food.Rows[function.findIndexByCod(codFood, tempMemory.food)][3]} (total R${Convert.ToDecimal(tempMemory.food.Rows[function.findIndexByCod(codFood, tempMemory.food)][3]) * qntSelectedFood}) foram adicionados ao carrinho!\n");

            if(addMoreOrPay() == 1) navigation();
            else payment.pay();
        }
        public void navigation(){
            while(true){
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
                    case 4:
                        avaliate();
                        break;
                    case -1:
                        return;
                    default:
                        break;
                }
            }
        }
        public void avaliate(){
            Console.WriteLine("DIGITE UM DOS RESTAURANTES A SEGUIR PARA AVALIAR\n");
            listVendors(true);
            int choosen, stars;
            while(!int.TryParse(Console.ReadLine(), out choosen) && function.codExist(choosen, tempMemory.vendor)){
                Console.WriteLine("\n***Digite um valor válido***");
            }

            Console.WriteLine("DIGITE UMA NOTA DE 1 a 5");
            while(!int.TryParse(Console.ReadLine(), out stars) && stars <= 5 && stars >= 0){
                Console.WriteLine("\n***Digite um valor válido***");
            }

            tempMemory.vendor.Rows[choosen][2] = (Convert.ToDecimal(tempMemory.vendor.Rows[choosen][2]) + stars) / 2;

            Console.WriteLine("AVALIADO COM SUCESSO!\n\n");
        }
        public void listCart(decimal frete = -1, bool askMoreOrPay = true){
            decimal total = 0;
            Console.WriteLine("\n[Restaurante] Descrição : Qnt : Vlr Uni : Vlr Total");
            Console.WriteLine("-----------------------------------------------------");
            foreach(DataRow item in tempMemory.cart.Rows){
                object foodName = tempMemory.food.Rows[function.findIndexByCod(Convert.ToInt32(item[1]), tempMemory.food)][1];
                object vendorName = tempMemory.vendor.Rows[function.findIndexByCod(Convert.ToInt32(item[0]), tempMemory.vendor)][1];
                object foodQnt = item[2];
                object foodValue = tempMemory.food.Rows[function.findIndexByCod(Convert.ToInt32(item[1]), tempMemory.food)][3];
                Console.WriteLine($"[{vendorName}] {foodName} : {foodQnt} : R${foodValue} : R${Convert.ToDecimal(foodValue) * Convert.ToDecimal(foodQnt)}");
                total += Convert.ToDecimal(foodValue) * Convert.ToDecimal(foodQnt);
            }
            if(frete >= 0) {
                total += frete;
                Console.WriteLine($"VALOR FRETE: R${frete}");
            }
            Console.WriteLine($"=====VALOR TOTAL: R${total}=====\n");
            Console.WriteLine("Pressione enter para continuar ou digite [0] para limpar o carrinho.");
            string option = Console.ReadLine()!;
            if(option == "0") tempMemory.cart.Rows.Clear();            

            if(askMoreOrPay && tempMemory.cart.Rows.Count != 0 && addMoreOrPay() == 2) payment.pay();
        }
        public int addMoreOrPay(){
            Console.WriteLine("Deseja adicionar mais itens ao carrinho ou deseja finalizar o pedido? \n[1] - ADIONAR MAIS ITENS\n[2] - FINALIZAR PEDIDO");
            int option;
            while(!int.TryParse(Console.ReadLine(), out option) && option <= 2 && option >= 1){
                Console.WriteLine("Opção inválida");
            }

            return option;
        }
        public bool goBack(int typedNum){
            if(typedNum == -1) return true;
            else return false; 
        }
    }
}