using System;
using System.Threading.Tasks;

public class Program4
{
    public static async Task Main(string[] args)
    {
        Proceso proceso = new Proceso();

        Barra barra = new Barra(proceso);
        await barra.RunAsync();
    }
}

public class Barra
{
    private readonly Proceso proceso;

    public Barra(Proceso proceso)
    {
        this.proceso = proceso;
    }

    public async Task RunAsync()
    {
        await Task.Run(() => proceso.ProgressProcess());
    }
}

public class Proceso
{
    private int progress;

    public void ProgressProcess()
    {
        for (int i = 0; i < 100; i += 10)
        {
            try
            {
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                Console.WriteLine (e);
            }
            progress += 10;
            DrawProgressBar (progress);
        }

        Console.WriteLine("\nCompletado");
    }

    private void DrawProgressBar(int value)
    {
        Console.Write("Progress: [");
        int filledBars = value / 10;
        for (int i = 0; i < filledBars; i++)
        {
            Console.Write("====");
        }
        for (int i = filledBars; i < 10; i++)
        {
            Console.Write(" ");
        }
        Console.Write("] " + value + " % ");
        Console.SetCursorPosition(0, Console.CursorTop);
    }
}
