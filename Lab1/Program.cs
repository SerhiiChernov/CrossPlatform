// See https://aka.ms/new-console-template for more information

namespace Lab1;

public class Program
{
    
    public static void Main(string[] args)
    {
        string projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        //string inputFilePath = Path.Combine(projectDir, "Input.txt");
        //string outputFilePath = Path.Combine(projectDir, "Output.txt");
        string inputFilePath = "Input.txt";
        string outputFilePath = "Output.txt";

        SoldierSeparator soldierSeparator = new SoldierSeparator();
        int res = soldierSeparator.Execute(ReadNumberFromFile(inputFilePath));
        WriteNumberToFile(outputFilePath,res);
        Console.WriteLine("The result was written to Output.txt");
    }
    public static int ReadNumberFromFile(string filePath)
    {
        try
        {
            string content = File.ReadAllText(filePath);
            if (string.IsNullOrEmpty(content))
                throw new ArgumentNullException();
            int number = int.Parse(content);
            if (number < 0)
                throw new InvalidDataException("Number should be above zero");
            return number;
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (InvalidDataException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: File {filePath} not found.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: The content of the file is not a number.");
        }
        return 0;
    }
    public static void WriteNumberToFile(string filePath, int number)
    {
        try
        {
            File.WriteAllText(filePath, number.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error writing to file: {e.Message}");
        }
    }
}