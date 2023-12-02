int sum = 0;

File.ReadLines("input.txt").ToList().ForEach(line => {
    var gameSet = line.Split(":")[1].Trim();
    var gameRounds = gameSet.Split(";").Select(r => r.Trim()).ToList();
    
    Dictionary<string, int> colors = new Dictionary<string, int> {
        { "red", 1 },
        { "green", 1 },
        { "blue", 1 }
    };

    gameRounds.ForEach(r => {        
        r.Split(",").ToList().ForEach(c => {            
            var color = c.Trim().Split(" ")[1];
            var count = int.Parse(c.Trim().Split(" ")[0]);            
            colors[color] = Math.Max(count, colors[color]);
        });
    });

    int power = colors["red"] * colors["green"] * colors["blue"];
    sum += power;

});

Console.WriteLine($"The sum of game powers is {sum}");




