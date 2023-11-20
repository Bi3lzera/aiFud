namespace def{
    public class def{
        public void apply(){
            ///Adiciona alguns restaurantes a tabela vendors
            temp.tempMemory.vendor.Rows.Add(0, "Lancheria Mandacaru", 4.7);
            temp.tempMemory.vendor.Rows.Add(1, "Pizzaria Vila Bela", 3.8);
            temp.tempMemory.vendor.Rows.Add(2, "Restaurante Takamoto", 4.2);

            ///Adiciona a tabela de Tipos de Comida (foodType) da memória temporária as colunas e os dados padrões
            temp.tempMemory.foodType.Rows.Add(0 , "Lanche");
            temp.tempMemory.foodType.Rows.Add(1 , "Pizza");
            temp.tempMemory.foodType.Rows.Add(2 , "Japonesa");
            temp.tempMemory.foodType.Rows.Add(3 , "Marmita");

            ///Adiciona a tabela de comidas, algumas comidas para os vendedores default (teste)
            temp.tempMemory.food.Rows.Add(0, "X Frango", 0, 17.99, 0);
            temp.tempMemory.food.Rows.Add(1, "X Salada", 0, 15.99, 0);
            temp.tempMemory.food.Rows.Add(2, "X Burguer", 0, 13.99, 0);
            
            temp.tempMemory.food.Rows.Add(3, "Pizza Portuguesa", 1, 40.99, 1);
            temp.tempMemory.food.Rows.Add(4, "Pizza 4 Queijos", 1, 38.99, 1);
            temp.tempMemory.food.Rows.Add(5, "Pizza Strogonoff de Carne", 1, 42.99, 1);

            temp.tempMemory.food.Rows.Add(6, "Sushi", 2, 40.99, 2);
            temp.tempMemory.food.Rows.Add(7, "ramen", 2, 25.99, 2);
            temp.tempMemory.food.Rows.Add(8, "Tempura", 2, 20.99, 2);
        }
    }
}