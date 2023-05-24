using System;

Console.WriteLine("Guess the secret number!");
Console.WriteLine("------------------------");

// Prompt the user for a difficulty level
Console.WriteLine("Choose a difficulty level:");
Console.WriteLine("1. Easy");
Console.WriteLine("2. Medium");
Console.WriteLine("3. Hard");
Console.WriteLine("4. Cheater");

int maxGuesses;
int userChoice;

// Make sure the user's input is an integer. We're going to take the input but not display it 
// ReadKey reads the user's input without displaying it
// We take KeyChar (the character the user pressed) and convert it to a string
// Then we try to parse the string as an integer. If it fails, we ask the user to enter an integer
while (!int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out userChoice))
{
    Console.Write("Invalid input. Please enter an integer: ");
}

// Set the maximum number of guesses based on the user's choice
switch (userChoice)
{
    // if userChoice == 1, set maxGuesses to 8, etc 
    case 1:
        maxGuesses = 8;
        Console.WriteLine("You chose easy difficulty.");
        break;
    case 2:
        maxGuesses = 6;
        Console.WriteLine("You chose medium difficulty.");
        break;
    case 3:
        maxGuesses = 4;
        Console.WriteLine("You chose hard difficulty.");
        break;
    case 4:
        maxGuesses = int.MaxValue;
        Console.WriteLine("You chose cheater difficulty.");
        break;
    default:
        Console.WriteLine("Invalid choice. Defaulting to medium difficulty.");
        maxGuesses = 6;
        Console.WriteLine("You chose medium difficulty.");
        break;
}

int secretNumber = new Random().Next(1, 101); // Generate a random number between 1 and 100
int numGuesses = 0; // Keep track of how many guesses the user has made
int userGuess; // Store the user's guess

while (numGuesses < maxGuesses) // Loop until the user runs out of guesses
{
    int guessesLeft = maxGuesses - numGuesses;
    Console.Write("Guess #{0} (You have {1} guesses left): ", numGuesses + 1, guessesLeft); 

    // Make sure the user's input is an integer
    while (!int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out userGuess))
    {
        Console.Write("Invalid input. Please enter an integer: ");
    }

    if (userGuess == secretNumber)
    {
        Console.WriteLine("You guessed right!");
        return;
    }
    else if (userGuess < secretNumber) {
        Console.WriteLine("Too small!");
    }
    else
    {
        Console.WriteLine("Too high!");
    }
    
    numGuesses++;
}

Console.WriteLine("Sorry, you ran out of guesses." +
    " The secret number was {0}.", secretNumber);