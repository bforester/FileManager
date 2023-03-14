using Spectre.Console;
namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AnsiConsole.Status()
    .Start("Thinking...", ctx =>
    {
        // Simulate some work
        AnsiConsole.MarkupLine("Doing some work...");
        Thread.Sleep(1000);

        // Update the status and spinner
        ctx.Status("Thinking some more");
        ctx.Spinner(Spinner.Known.Star);
        ctx.SpinnerStyle(Style.Parse("green"));

        // Simulate some work
        AnsiConsole.MarkupLine("Doing some more work...");
        Thread.Sleep(2000);
    });
        }
    }
}