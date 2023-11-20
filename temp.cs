using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace temp{
    public static class tempMemory{
        public static DataTable vendor {get; set;} = new DataTable();
        public static DataTable food {get; set;} = new DataTable();
        public static DataTable foodType {get; set;} = new DataTable();
        public static DataTable cart {get; set;} = new DataTable();
        public static void initialize(){
            food.Columns.Add("cod", typeof(int));
            food.Columns.Add("desc", typeof(string));
            food.Columns.Add("codFoodType", typeof(int));
            food.Columns.Add("value", typeof(float));
            food.Columns.Add("codVendor", typeof(int));

            foodType.Columns.Add("cod", typeof(int));
            foodType.Columns.Add("name", typeof(string));

            vendor.Columns.Add("cod", typeof(int));
            vendor.Columns.Add("name", typeof(string));
            vendor.Columns.Add("overallStar", typeof(decimal));

            cart.Columns.Add("codVendor", typeof(int));
            cart.Columns.Add("codFood", typeof(int));
            cart.Columns.Add("qnt", typeof(float));
        }
    }
}