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
}
