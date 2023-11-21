using System.Data;

namespace function{
    public class function{
        public int findIndexByCod(int cod, DataTable table){
            int i = 0;
            foreach(DataRow row in table.Rows){
                if(row[0].ToString() == cod.ToString()) return i;
                i++;
            }
            
            return -1;
        }

        public bool codExist(int cod, DataTable table){
            foreach(DataRow row in table.Rows){
                if(row[0].ToString() == cod.ToString()) return true;
            }

            return false;
        }

        public void delLinesByValue(int value, int column, DataTable table){
            int i = 0, count = table.Rows.Count;

            for (int n = 0; n < table.Rows.Count; n++){
                if(table.Rows[n][column].ToString() == value.ToString()) {
                    table.Rows[n].Delete();
                    i++;
                    n = 0;
                    count = table.Rows.Count;
                }
            }
            Console.WriteLine($"{i} linha(s) foram deletada(s).\n\n");
        }
    }
}