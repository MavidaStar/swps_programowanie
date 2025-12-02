//lista znaków gry, pobierane w trakcie, liczenie znaków zaczyna się od 0, więc teraz mamy 0=rock, 1=paper, 2=scissors
List<string> allowedSigns = ["rock", "paper", "scissors"];
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

//pętla do grania w nieskończoność
while (true)
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
    string firstSign = GetCorrectSign("Player 1");
    string secondSign = GetCorrectRandomSign("Player 2");

    // 1. Pobierz indeks znaku podanego przez osobę drugą (np. 0, 1, 2) - nazwę to secondSignIndex
    int secondSignIndex = allowedSigns.IndexOf(secondSign);
    // 2. Wylicz indeks znaku, który wygrywa z podanym przez osobę drugą - wzór - (secondSignIndex + 1) % rozmiarListy
    int winningSignIndex = (secondSignIndex + 1) % allowedSigns.Count;
    // 3. Czy indeks znaku podanego przez pierwszą osobę to indeks wyliczony w punkcie 2.
    int firstSignIndex = allowedSigns.IndexOf(firstSign);

    if (firstSign.Equals(secondSign, stringComparison))
    {
        Console.WriteLine("It's a draw!");
    }
    else if (firstSignIndex == winningSignIndex)
    {
        Console.WriteLine("First player won!");
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
        Console.WriteLine("Second player won!");
        //secondPlayerPoints = secondPlayerPoints + 1; 
        //secondPlayerPoints++;
        secondPlayerPoints += 1;
    }

    //wyświetlanie punktacji dla obu graczy
    Console.WriteLine($"First player: {firstPlayerPoints}");
    Console.WriteLine($"Second player: {secondPlayerPoints}");

    //if(!(firstPlayerPoints < 3 && secondPlayerPoints < 3))
    if (!(firstPlayerPoints >= 3 || secondPlayerPoints >= 3))
    {
        break;
    }
}
