Dictionary<string, int> colors = new Dictionary<string, int> {
    { "red", 12 },
    { "green", 13 },
    { "blue", 14 }
};

Stack<int> possibleGameStack = new Stack<int>();

File.ReadLines("input.txt").ToList().ForEach(line => {
    var gameKey = int.Parse(line.Split(":")[0].Trim().Split(" ")[1]);
    var gameSet = line.Split(":")[1].Trim();
    var gameRounds = gameSet.Split(";").Select(r => r.Trim()).ToList();

    bool gameFailed = false;

    possibleGameStack.Push(gameKey);

    gameRounds.ForEach(r => {
        r.Split(",").ToList().ForEach(c => {
            var color = c.Trim().Split(" ")[1];
            var count = int.Parse(c.Trim().Split(" ")[0]);

            if (count > colors[color])
                gameFailed = true;            
        });
    });

    if (gameFailed)
        possibleGameStack.Pop();
});

int sum = 0;
possibleGameStack.ToList().ForEach(g => sum += g);

Console.WriteLine($"The sum of possible game ids is {sum}");
