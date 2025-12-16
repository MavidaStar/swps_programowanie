//lista znaków gry, pobierane w trakcie, liczenie znaków zaczyna się od 0, więc teraz mamy 0=rock, 1=paper, 2=scissors, 3=lizard, 4=spock
List<string> allowedSigns = ["rock", "paper", "scissors", "lizard", "spock"];
//słownik, typ danych, worek na informacje; winningMap = mapa wygranych elemntów - co wygrywa z czym, co przegrywa z czym
//new() nawias powtarza to co było wcześniej, tak samo jak po prostu same [], następnie lista elementów i z czym wygrywają/przegrywają
Dictionary<string, List<string>> winningMap = [];
winningMap["rock"] = ["scissors", "lizard"];
winningMap["paper"] = ["rock", "spock"];
winningMap["scissors"] = ["paper", "lizard"];
winningMap["lizard"] = ["paper", "spock"];
winningMap["spock"] = ["rock", "scissors"];

string GetCorrectSign(string playerName)
{
    Console.WriteLine($"{playerName}, choose your sign ({string.Join('/', allowedSigns)})");
    string sign = Console.ReadLine()!;

    //if (firstSign.Equals("rock", stringComaprison) && !firstSign.Equals("paper", stringComaprison) && !firstSign.Equals("scissors", stringComaprison))
    //while (!(firstSign.Equals(allowedSigns[0], stringComparison) || firstSign.Equals(allowedSigns[1], stringComparison) || firstSign.Equals(allowedSigns[2], stringComparison)))
    while (!allowedSigns.Contains(sign, StringComparer.OrdinalIgnoreCase))
    {
        Console.WriteLine($"{playerName}, choose correct sign ({string.Join('/', allowedSigns)})");
        sign = Console.ReadLine()!;
    }
    return sign;
}

string GetCorrectRandomSign(string playerName)
{
    int signIndex = Random.Shared.Next(allowedSigns.Count);
    string sign = allowedSigns[signIndex];
    Console.WriteLine($"{playerName} selected {sign}");

    return sign;
}

const StringComparison stringComparison = StringComparison.OrdinalIgnoreCase;
//utworzenie punktacji dla obu graczy
int firstPlayerPoints = 0;
int secondPlayerPoints = 0;

Console.WriteLine("Player 1, what's your name?");
string firstPlayerName = Console.ReadLine()!;

Console.WriteLine("Player 2, what's your name?");
string secondPlayerName = Console.ReadLine()!;

Console.WriteLine("How many wins?");
string maxWinsText = Console.ReadLine()!;
//int maxWins = int.Parse(maxWinsText);
//int maxWins = Convert.ToInt32(maxWinsText);
//int maxWins;
//bool = zmienna która przechowuje prawdę lub fałsz, TryParse - udało się "z parsować" czy nie? prawda czy fałsz? => 2; 
//bool parsingResult = int.TryParse(maxWinsText, out maxWins);
//bool parsingResult = int.TryParse(maxWinsText, out int maxWins); -> nie diała n aliczby ujemne, gra się kończy, bo każdy gracz ma więcej niż np. -200
bool parsingResult = uint.TryParse(maxWinsText, out uint maxWins);

//pętla w wypadku nie podania liczby, a tekstu rund do momentu podania liczby, która będzie >0, poniżej podanie jest przeciwieństwo, patrz !
while (!parsingResult || maxWins <= 0)
{
    Console.WriteLine("How many wins?");
    maxWinsText = Console.ReadLine()!;
    parsingResult = uint.TryParse(maxWinsText, out maxWins);
}

//pętla do grania w nieskończoność - oryginalnie, teraz jest pętla gry dopóki jedenz graczy nie otrzyma 3 punktów
//while (true)
//pętla do wybranej ilości rund gry
while (firstPlayerPoints < maxWins && secondPlayerPoints < maxWins)
{
    //List<string> allowedSigns = ["rock", "paper", "scissors"];
    Console.WriteLine("Let's play Rock-Paper-Scissors!");

    //Console.WriteLine($"Player 1, choose your sign ({string.Join('/', allowedSigns)})");
    //Console.WriteLine($"Player 1, choose your sign ({string.Join("/", allowedSigns)})");
    //Console.WriteLine($"Player 1, choose your sign ({allowedSigns[0]}/{allowedSigns[1]}/{allowedSigns[2]})");
    //string firstSign = Console.ReadLine()!;

    //if (firstSign.Equals("rock", stringComaprison) && !firstSign.Equals("paper", stringComaprison) && !firstSign.Equals("scissors", stringComaprison))
    //while (!(firstSign.Equals(allowedSigns[0], stringComparison) || firstSign.Equals(allowedSigns[1], stringComparison) || firstSign.Equals(allowedSigns[2], stringComparison)))
    //while (!allowedSigns.Contains(firstSign, StringComparer.OrdinalIgnoreCase))
    //{
    //    Console.WriteLine($"Player 1, choose correct sign ({string.Join('/', allowedSigns)})");
    //    firstSign = Console.ReadLine()!;
    //}
    string firstSign = GetCorrectSign(firstPlayerName); //P1 (na tablicy)
    string secondSign = GetCorrectSign(secondPlayerName); //P2 (na tablicy)

    List<string> signsLosingWithFirstSign = winningMap[firstSign];

    //po utworzeniu dictionary, nie jest już nam ten etap potrzebny
    // 1. Pobierz indeks znaku podanego przez osobę drugą (np. 0, 1, 2) - nazwę to secondSignIndex
    //int secondSignIndex = allowedSigns.IndexOf(secondSign);
    // 2. Wylicz indeks znaku, który wygrywa z podanym przez osobę drugą - wzór - (secondSignIndex + 1) % rozmiarListy
    //int winningSignIndex = (secondSignIndex + 1) % allowedSigns.Count;
    // 3. Czy indeks znaku podanego przez pierwszą osobę to indeks wyliczony w punkcie 2.
    //int firstSignIndex = allowedSigns.IndexOf(firstSign);

    if (firstSign.Equals(secondSign, stringComparison))
    {
        Console.WriteLine("It's a draw!");
    }
    //else if (firstSignIndex == winningSignIndex)
    else if (signsLosingWithFirstSign.Contains(secondSign, StringComparer.OrdinalIgnoreCase))
    {
        Console.WriteLine($"{firstPlayerName} won!");  
        //firstPlayerPoints = firstPlayerPoints + 1;
        //firstPlayerPoints++;
        firstPlayerPoints += 1;    
    }

    //else if ((firstSign.Equals(allowedSigns[0], stringComparison) && secondSign.Equals(allowedSigns[2], stringComparison))
    //    || (firstSign.Equals(allowedSigns[1], stringComparison) && secondSign.Equals(allowedSigns[0], stringComparison))
    //    || (firstSign.Equals(allowedSigns[2], stringComparison) && secondSign.Equals(allowedSigns[1], stringComparison)))
    //{
    //    Console.WriteLine("First player won!");
    //}

    else
    {
        Console.WriteLine($"{secondPlayerName} won!");
        //secondPlayerPoints = secondPlayerPoints + 1; 
        //secondPlayerPoints++;
        secondPlayerPoints += 1;
    }

    //wyświetlanie punktacji dla obu graczy
    Console.WriteLine($"{firstPlayerName}: {firstPlayerPoints}");
    Console.WriteLine($"{secondPlayerName}: {secondPlayerPoints}");

    //if(!(firstPlayerPoints < 3 && secondPlayerPoints < 3))
    
    //if (!(firstPlayerPoints >= 3 || secondPlayerPoints >= 3))
    if (!(firstPlayerPoints >= maxWins || secondPlayerPoints >= maxWins))
    {
        break;
    }
}
