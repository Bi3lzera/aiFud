

using System.Data;
using System.Diagnostics.SymbolStore;

namespace consumer{
    public class consumer{
        user_terminal.consumerText text = new user_terminal.consumerText();
        action action = new action();
        public void start(){
            Console.WriteLine("Você entrou no sistema como CONSUMIDOR");

            text.navigation();
        }
    }

    public class action{
        public void addToCart(int codVendor, int codFood, float qntFood){
            if(qntFood > 0) temp.tempMemory.cart.Rows.Add(codVendor, codFood, qntFood);
        }
    }
}