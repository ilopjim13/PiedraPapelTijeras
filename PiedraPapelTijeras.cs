// See https://aka.ms/new-console-template for more information

namespace PiedraPapelTijeras;

class PiedraPapelTijeras
{
    
    static int _v1 = 0;
    static int _v2 = 0;

    static List<string> _texto1 = new List<string>();
    static List<string> _texto2 = new List<string>();
    
    
    static List<int> _ganadores = new List<int>();

    
    static void Main()
    {
        List<Thread?> threads = new List<Thread?>();

        for (int i = 0; i < 8; i++)
        {
            var t1 = new Thread(new ThreadStart (Go));
            var t2 = new Thread(new ThreadStart (Go2));
            threads.Add(t1);
            threads.Add(t2);
        }
        
        for (int j = 0; j < 16; j+=2)
        {
            Console.WriteLine("Partida");
            threads[j].Start();
            threads[j + 1].Start();
            int i = 0;
            bool ganador = false;
            while (!ganador)
            {
                Console.WriteLine($"Ronda {i + 1}");
                CheckVictory(_texto1[i], _texto2[i], j + 1 , j +2);
                i++;
                if (_v1 >= 2 || _v2 >= 2)
                {
                    ganador = true;
                }
            }

            if (_v1 > _v2)
            {
                Console.WriteLine("Este juego lo ha ganado el hilo 1");
                _ganadores.Add(j + 1);
            }
            else if (_v1 < _v2)
            {
                Console.WriteLine("Este juego lo ha ganado el hilo 2");
                _ganadores.Add(j +2);
            }
            else Console.WriteLine("Este juego ha quedado en empate");
            
            _v2 = 0;
            _v1 = 0;
        }
        
        Console.WriteLine(_ganadores.Count);
     
    }

    static void Go()
    {
        _texto1.RemoveAll(_texto1.Contains);
        var random = new Random();
        List<string> list = ["Piedra", "Papel", "Tijeras"];
        for (int i = 0; i < 18; i++)
        {
            _texto1.Add(list[random.Next(0, 3)]);
        }
    }

    static void Go2()
    {
        _texto2.RemoveAll(_texto2.Contains);
        var random = new Random();
        List<string> list = ["Piedra", "Papel", "Tijeras"];
        for (int i = 0; i < 18; i++)
        {
            _texto2.Add(list[random.Next(0, 3)]);
        }
    }

    static void CheckVictory(String text1, String text2, int hilo1, int hilo2)
    {
        Console.WriteLine($"Hilo {hilo1}: {text1}");
        Console.WriteLine($"Hilo {hilo2}: {text2}");
        if (text1 == "Tijeras" && text2 == "Papel")
        {
            _v1++;
            Console.WriteLine ($"Ha ganado el hilo {hilo1}");
        } else if (text2 == "Tijeras" && text1 == "Papel")
        {
            _v2++;
            Console.WriteLine ($"Ha ganado el hilo {hilo2}");
        } else if (text2 == "Piedra" && text1 == "Tijeras")
        {
            _v2++;
            Console.WriteLine ($"Ha ganado el hilo {hilo2}");
        } else if (text1 == "Piedra" && text2 == "Tijeras")
        {
            _v1++;
            Console.WriteLine ($"Ha ganado el {hilo1}");
        } else if (text1 == "Papel" && text2 == "Piedra")
        {
            _v1++;
            Console.WriteLine ($"Ha ganado el {hilo1}");
        } else if (text1 == "Piedra" && text2 == "Papel")
        {
            _v2++;
            Console.WriteLine ($"Ha ganado el {hilo2}");
        }
        else
        {
            Console.WriteLine ("Empate");
        }
    }
}