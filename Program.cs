using System.IO;
using System.Data;

using user_terminal;
class ifood_project{
    public static void Main(string[] args){
        terminal t = new terminal();
        def.def def = new def.def();
        
        temp.tempMemory.initialize();
        def.apply();
        t.start();
    }
}