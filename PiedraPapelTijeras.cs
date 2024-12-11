// See https://aka.ms/new-console-template for more information

namespace PiedraPapelTijeras;

class PiedraPapelTijeras
{
    
    static int v1 = 0;
    static int v2 = 0;

    static string texto1 = "";
    static string texto2 = "";
    
    
    static void Main() 
    {
        for (var i = 0; i < 3; i++)
        {
            var t1 = new Thread(new ThreadStart (Go));
            var t2 = new Thread(new ThreadStart (Go2));
            Console.WriteLine($"Ronda {i + 1}");
            t1.Start();
            t2.Start();
            t2.Join();
            CheckVictory();
        }
        
        if (v1 > v2) Console.WriteLine("Este juego lo ha ganado el hilo 1");
        else if (v1 < v2) Console.WriteLine("Este juego lo ha ganado el hilo 2");
        else Console.WriteLine("Este juego ha quedado en empate");
    }

    static void Go()
    {
        var random = new Random();
        List<string> list = ["Piedra", "Papel", "Tijeras"];
        var text = list[random.Next(0, 3)];
        texto1 = text;
        Console.WriteLine ($"Hilo 1: {text}");
        Thread.Sleep(500);
    }

    static void Go2()
    {
        var random = new Random();
        List<string> list = ["Piedra", "Papel", "Tijeras"];
        var text = list[random.Next(0, 3)];
        texto2 = text;
        Console.WriteLine ($"Hilo 2: {text}");
        Thread.Sleep(600);
    }

    static void CheckVictory()
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
        else
        {
            Console.WriteLine ("Empate");
        }
    }
}