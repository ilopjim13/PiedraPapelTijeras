// See https://aka.ms/new-console-template for more information


class PiedraPapelTijeras
{
    private int v1 = 0;
    private int v2 = 0;
    
    public string texto1 = "";
    public string texto2 = "";
    
    private List<string> list = ["Piedra", "Papel", "Tijeras"];
    
    static void Main() 
    {
        Thread t1 = new Thread(new ThreadStart (Go));
        Thread t2 = new Thread(new ThreadStart (Go));
        
        t1.Start();
        t2.Start();
        
        
    }
    
    static void Go()
    {
        Console.WriteLine ();
    }

    void CheckVictory()
    {
        if (texto1 == "Tijeras" && texto2 == "Papel")
        {
            v1++;
            Console.WriteLine ("Ha ganado el hilo 1");
        } else if (texto2 == "Tijeras" && texto1 == "Papel")
        {
            v2++;
            Console.WriteLine ("Ha ganado el hilo 2");
        }
    }
}
