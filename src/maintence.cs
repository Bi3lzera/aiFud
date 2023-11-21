using temp;

namespace maintence{
    public class maintence{
        user_terminal.maintenceText text = new user_terminal.maintenceText();
        action action = new action();
        public void start(){
            Console.WriteLine("Você entrou no sistema como ADMINISTRADOR\n");
            
            selectedOption(text.option());
        }

        private void selectedOption(int option){
            switch(option){
                case 1:
                    string vendorName = text.addVendor();
                    action.addVendor(vendorName);
                    break;
                case 2:
                    int cod = text.delVendor();
                    if(cod == -1) break;
                    action.delVendor(cod);
                    break;
                case 3:
                    text.addFood();
                    break;
                case 4:
                    text.delFood();
                    break;
                default:
                    return;
            }
        }
    }

    public class action{
        function.function function = new function.function();
        public void addVendor(string name){
            int getCode = Convert.ToInt32(temp.tempMemory.vendor.Rows[temp.tempMemory.vendor.Rows.Count - 1][0]) + 1;
            temp.tempMemory.vendor.Rows.Add(getCode, name);
            
        }

        public void delVendor(int cod){
            temp.tempMemory.vendor.Rows[cod].Delete();
            Console.WriteLine("Vendedor deletado.");
            function.delLinesByValue(cod, 4, tempMemory.food);
        }

        public void addFood(string name, decimal value, int codFoodType, int codVendor){
            int getCode = Convert.ToInt32(temp.tempMemory.food.Rows[temp.tempMemory.food.Rows.Count - 1][0]) + 1;
            temp.tempMemory.food.Rows.Add(getCode, name, codFoodType, value, codVendor);
        }

        public void delFood(int codFood){
            temp.tempMemory.food.Rows[function.findIndexByCod(codFood, tempMemory.food)].Delete();
        }
    }
}