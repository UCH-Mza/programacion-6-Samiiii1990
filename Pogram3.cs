using System;
using System.Threading.Tasks;

public class Program3
{
    public static void Main(string[] args)
    {
        Juego game = new Juego();

        Jugador jugador1 = new Jugador("Jugador 1", game);
        Jugador jugador2 = new Jugador("Jugador 2", game);

        Task t1 = Task.Factory.StartNew(jugador1.Run);
        Task t2 = Task.Factory.StartNew(jugador2.Run);

        Task.WaitAll(t1, t2);

        game.PlayerWinner();
    }
}

public class Juego
{
    private bool roundInProgress;
    private string player1Choice;
    private string player2Choice;
    private int counter1 = 0;
    private int counter2 = 0;

    public Juego()
    {
        roundInProgress = false;
        player1Choice = null;
        player2Choice = null;
    }

    public void PlayRound(string choice, string playerName)
    {
        lock (this)
        {
            while (roundInProgress)
            {
                System.Threading.Monitor.Wait(this);
            }

            if (playerName.Equals("Jugador 1"))
            {
                player1Choice = choice;
            }
            else if (playerName.Equals("Jugador 2"))
            {
                player2Choice = choice;
            }

            while (roundInProgress)
            {
                System.Threading.Monitor.Wait(this);
            }

            if (playerName.Equals("Jugador 2"))
            {
                roundInProgress = true;
                Console.WriteLine("Jugador 1 elige: " + player1Choice);
                Console.WriteLine("Jugador 2 elige: " + player2Choice);
                Console.WriteLine(GetRoundResult());
                Console.WriteLine("-----------------------------------------");

                roundInProgress = false;
                System.Threading.Monitor.PulseAll(this);
            }
        }
    }

    public string GetRoundResult()
    {
        lock (this)
        {
            roundInProgress = false;
            System.Threading.Monitor.PulseAll(this);

            if (player1Choice.Equals(player2Choice))
            {
                return "Empate!";
            }
            else if ((player1Choice.Equals("piedra") && player2Choice.Equals("tijera"))
                  || (player1Choice.Equals("papel") && player2Choice.Equals("piedra"))
                  || (player1Choice.Equals("tijera") && player2Choice.Equals("papel")))
            {
                counter1++;
                return "Jugador 1 gana!";
            }
            else
            {
                counter2++;
                return "Jugador 2 gana!";
            }
        }
    }

    public void PlayerWinner()
    {
        lock (this)
        {
            if (counter1 == counter2)
            {
                Console.WriteLine("Empate.");
            }
            else if (counter1 > counter2)
            {
                Console.WriteLine("Gana el Juego: Jugador 1");
            }
            else
            {
                Console.WriteLine("Gana el Juego: Jugador 2");
            }
        }
    }
}

public class Jugador
{
    private readonly string playerName;
    private readonly Juego game;

    public Jugador(string playerName, Juego game)
    {
        this.playerName = playerName;
        this.game = game;
    }

    private string GenerateRandomChoice()
    {
        string[] choices = { "piedra", "papel", "tijera" };
        Random random = new Random();
        int index = random.Next(choices.Length);
        return choices[index];
    }

    public void Run()
    {
        for (int i = 0; i < 5; i++)
        {
            try
            {
                string choice = GenerateRandomChoice();
                game.PlayRound(choice, playerName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
