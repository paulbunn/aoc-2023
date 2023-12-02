/*
   Use a map of strings to find and with digit equivalents.
   For simplicity, I'll search for digits too, rather than adding logic
   to treat them differently
*/
Dictionary<string, char> replacements = new Dictionary<string, char>() {
    { "one", '1'},
    { "two", '2'},
    { "three", '3'},
    { "four", '4'},
    { "five", '5'},
    { "six", '6'},
    { "seven", '7'},
    { "eight", '8'},
    { "nine", '9'},
    { "1", '1'},
    { "2", '2'},
    { "3", '3'},
    { "4", '4'},
    { "5", '5'},
    { "6", '6'},
    { "7", '7'},
    { "8", '8'},
    { "9", '9'},
    { "0", '0'},
};

int sum = 0;

foreach (var line in File.ReadLines("input.txt"))
{
    SortedList<int, char> digits = new SortedList<int, char>();

    /*
        Search line for all occurence of replacement values
        and capture occurences in a sorted list so that it is 
        trivial to get the first and last digit later
    */
    foreach (string key in replacements.Keys)
    {
        int idx = 0;
        int ptr = 0;

        while (idx >= 0)
        {
            idx = line.IndexOf(key, ptr);
            ptr = idx + 1;
            if (idx >= 0)
                digits.Add(idx, replacements[key]);
        }
    }

    /* 
        Concatenate the first and last digit, convert to an int, 
        and add to the sum

        Note:  If there is only one digit in the line, use it as
        both the first and second digit of the number.
    */
    sum += int.Parse(String.Concat(digits.First().Value, digits.Last().Value));
}

Console.WriteLine($"The sum is {sum}");


