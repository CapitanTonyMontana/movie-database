namespace movie_database
{
    public class Validator
    {
        public string GetNonEmptyString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input.Trim();
                Printer.ValueCannotBeEmpty();
            }
        }
        public string GetFileFormat()
        {
            while (true)
            {
                Printer.SelectFormatJsonXML();
                var input = Console.ReadLine()?.Trim().ToLower();
                if (input == "json" || input == "xml")
                    return input;
                Printer.InvalidFormat();
            }
        }
        public int GetValidYear(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int year))
                    return year;

                Printer.InvalidYearFormat();
            }
        }
        public List<string> GetActorList(string prompt)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            return string.IsNullOrWhiteSpace(input)
                ? new List<string>()
                : input.Split(",").Select(a => a.Trim()).Where(a => a.Length > 0).ToList();
        }
        public string? GetOptionalString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine()?.Trim();
        }
    }
}
