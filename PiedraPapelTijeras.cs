// See https://aka.ms/new-console-template for more information


class PiedraPapelTijeras
{
    private int v1 = 0;
    private int v2 = 0;
    
    public string texto1 = "";
    public string texto2 = "";
    
    
    static void Main() 
    {
        Thread t1 = new Thread(new ThreadStart (Go));
        Thread t2 = new Thread(new ThreadStart (Go2));

        for (int i = 0; i < 3; i++)
        {
            t1.Start();
            t2.Start();
        }
        
    }
    
    static void Go()
    {
        List<string> list = ["Piedra", "Papel", "Tijeras"];
        string texto1 = list[Random.Range(0, list.Count)];
        Console.WriteLine (texto1);
    }
    
    static void Go2()
    {
        List<string> list = ["Piedra", "Papel", "Tijeras"];
        string texto2 = list[Random.Range(0, 2)];
        Console.WriteLine (texto2);
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
        } else if (texto2 == "Piedra" && texto1 == "Tijeras")
        {
            v2++;
            Console.WriteLine ("Ha ganado el hilo 2");
        } else if (texto1 == "Piedra" && texto2 == "Tijeras")
        {
            v1++;
            Console.WriteLine ("Ha ganado el hilo 1");
        } else if (texto1 == "Papel" && texto2 == "Piedra")
        {
            v1++;
            Console.WriteLine ("Ha ganado el hilo 1");
        } else if (texto1 == "Piedra" && texto2 == "Papel")
        {
            v2++;
            Console.WriteLine ("Ha ganado el hilo 2");
        } 
        
    }
}
