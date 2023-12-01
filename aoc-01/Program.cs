using System.Collections.Immutable;

int sum = 0;

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


foreach (var line in File.ReadLines("input.txt"))
{

    SortedList<int,char> temp = new SortedList<int, char>();

    foreach(string key in replacements.Keys) {
        int idx = 0;
        int ptr = 0;
        
        while (idx >= 0) {
            idx = line.IndexOf(key, ptr);
            ptr = idx + 1;
            if (idx >= 0)
                temp.Add(idx, replacements[key]);            
        }
    }
    
    sum += int.Parse(String.Concat(temp.First().Value, temp.Last().Value));      

    Console.WriteLine($"{line} \t\t:: {temp.First().Value} :: {temp.Last().Value} :: {sum}");

}

Console.WriteLine(sum);


