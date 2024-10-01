// See https://aka.ms/new-console-template for more information

namespace Lab1;

public class Program
{
    
    public static void Main(string[] args)
    {
        //string projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        //string inputFilePath = Path.Combine(projectDir, "Input.txt");
        //string outputFilePath = Path.Combine(projectDir, "Output.txt");
        string inputfilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Input.txt");
        string outputFilePath = "Output.txt";

        SoldierSeparator soldierSeparator = new SoldierSeparator();
        int res = soldierSeparator.Execute(ReadNumberFromFile(inputfilePath));
        WriteNumberToFile(outputFilePath,res);
        Console.WriteLine("The result was written to Output.txt");
    }
    public static int ReadNumberFromFile(string filePath)
    {
        try
        {
            string content = File.ReadAllText(filePath).Trim();
        
            if (string.IsNullOrEmpty(content))
                throw new ArgumentNullException("File is empty or null.");
        
            if (!long.TryParse(content, out long number))
                throw new FormatException("The content of the file is not a valid number.");
        
            if (number < 0)
                throw new InvalidDataException("Number should be greater than or equal to zero.");
        
            if (number > 1018)
                throw new InvalidDataException("Number should be less than or equal to 1018.");
        
            return (int)number;
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
            Console.WriteLine("Error: The content of the file is not a valid number.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: The number in the file is too large to be processed.");
        }

        return 0; // Повертає 0 у випадку помилки
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