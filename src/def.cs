namespace def{
    public class def{
        public void apply(){
            ///Adiciona alguns restaurantes a tabela vendors
            temp.tempMemory.vendor.Rows.Add(temp.tempMemory.vendor.Rows.Count, "Lancheria Mandacaru", 4.7);
            temp.tempMemory.vendor.Rows.Add(temp.tempMemory.vendor.Rows.Count, "Pizzaria Vila Bela", 3.8);
            temp.tempMemory.vendor.Rows.Add(temp.tempMemory.vendor.Rows.Count, "Restaurante Takamoto", 4.2);

            ///Adiciona a tabela de Tipos de Comida (foodType) da memória temporária as colunas e os dados padrões
            temp.tempMemory.foodType.Rows.Add(temp.tempMemory.foodType.Rows.Count, "Lanche");
            temp.tempMemory.foodType.Rows.Add(temp.tempMemory.foodType.Rows.Count, "Pizza");
            temp.tempMemory.foodType.Rows.Add(temp.tempMemory.foodType.Rows.Count, "Japonesa");

            ///Adiciona a tabela de comidas, algumas comidas para os vendedores default (teste)
            temp.tempMemory.food.Rows.Add(temp.tempMemory.food.Rows.Count, "X Frango", 0, 17.99, 0);
            temp.tempMemory.food.Rows.Add(temp.tempMemory.food.Rows.Count, "X Salada", 0, 15.99, 0);
            temp.tempMemory.food.Rows.Add(temp.tempMemory.food.Rows.Count, "X Burguer", 0, 13.99, 0);
            
            temp.tempMemory.food.Rows.Add(temp.tempMemory.food.Rows.Count, "Pizza Portuguesa", 1, 40.99, 1);
            temp.tempMemory.food.Rows.Add(temp.tempMemory.food.Rows.Count, "Pizza 4 Queijos", 1, 38.99, 1);
            temp.tempMemory.food.Rows.Add(temp.tempMemory.food.Rows.Count, "Pizza Strogonoff de Carne", 1, 42.99, 1);

            temp.tempMemory.food.Rows.Add(temp.tempMemory.food.Rows.Count, "Sushi", 2, 40.99, 2);
            temp.tempMemory.food.Rows.Add(temp.tempMemory.food.Rows.Count, "ramen", 2, 25.99, 2);
            temp.tempMemory.food.Rows.Add(temp.tempMemory.food.Rows.Count, "Tempura", 2, 20.99, 2);
        }
    }
}