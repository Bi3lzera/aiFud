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
                default:
                    return;
            }
        }
    }

    public class action{
        public void addVendor(string name){
            temp.tempMemory.vendor.Rows.Add(temp.tempMemory.vendor.Rows.Count, name);
        }
    }
}