# Battleship OOP

## Setup

- just run exe file and enjoy :)
- you might want to expand your console window to see things properly

## Story

> One of the reasons microcomputers progressed so fast is people are willing to
> accept crashes. It's faster to build something and try it, even if it means
> you'll have to rebuild later... If you spent too much time building and
> massaging one vehicle, you don't learn anything.
> <div style="text-align:right">John Carmack,<br>lead programmer of Doom (and more)</div>

In this project your job is to implement the
[Battleship game](https://en.wikipedia.org/wiki/Battleship_%28game%29) for two players. Use the newly learned OOP practices.

## What are you going to learn?

- UML diagrams
- clean code
- encapsulation
- abstraction
- polymorphism
- inheritance
- enums
- S and O principles from SOLID
- namespaces in C#
- properties and get-only properties in C#


## Tasks

1. Gain good understanding of the OOP principles and implement them in your code.
    - The program does not use static contexts.
    - Classes are grouped in namespaces.
    - Classes have fields, methods, and properties that are related only to them
    - Classes have access modifiers that expose their content as little as possible.
    - Properties with private setters are used instead of fields wherever possible.
    - Classes are logically structured and inherit from parents to eliminate code duplication.
    - Classes use public methods to communicate with outside code, and private methods to eliminate code duplication and improve readability.
    - Polymorphism is used wherever possible, to make the code as universal as possible and to avoid code duplication.

2. Implement the `Battleship` class. This will be used as the highest level class.
    - The `Battleship` class has `Display` and `Input` fields that are used throughout the program.
    - The `Battleship` class has a loop in which the program runs.
    - The `Battleship` class displays the main menu and allows the user to a start new game, display high scores, and exit.

3. Implement the `Display` class and its methods.
    - The `Display` class prints the game menu.
    - The `Display` class prints the board during manual ship placement process.
    - The `Display` class prints the gameplay.
    - The `Display` class prints the outcome of the game when it is over.
    - No `Console.WriteLine()` happens outside of the `Display` class.

4. Implement the `Input` class and its methods.
    - The `Input` class is responsible for gathering all input. It also provides a seperate method for each case.
    - The `Input` class handles input validation.

5. Implement the `Game` class and its methods.
    - The `Game` class has a loop in which players make moves.
    - The `Game` class has a logic which determines the flow of round.
    - The `Game` class has a condition on which game ends.
    - The `Game` class provides different game modes which use different round flows.

6. Implement the `Player` class and its methods.
    - The `Player` class has a logic responsible for handling shots.
    - The `Player` class has a field of the `List<Ship>` type.
    - The `Player` class has a get-only `IsAlive` property that checks whether the player lost all ships and return true or false accordingly.

7. [OPTIONAL] Implement the `ComputerPlayer` class and its methods.
    - The `ComputerPlayerEasy` class takes random shots excluding already struck fields.
    - The `ComputerPlayerNormal` class also excludes fields around ships when taking random hits.
    - The `ComputerPlayerNormal` class shoots around a ship after hitting it to determine its direction.
    - The `ComputerPlayerNormal` class changes direction to the opposite when shots cannot go further.
    - The `ComputerPlayerNormal` class follows the direction until the ship is sunk.
    - The `ComputerPlayerHard` class uses `ComputerPlayerNormal` logic but shoots diagonal fields only.

8. Implement the `BoardFactory` class and its methods.
    - The `BoardFactory` class has a `RandomPlacement()` method that handles random ship placement on board.
    - The `BoardFactory` class has a `ManualPlacement()` method that handles manual ship placement on board.

9. Implement the `Board` class and its methods.
    - The `Board` class has a `Square[,] ocean` field. This contains the squares that the board consists of.
    - The `Board` class has a `IsPlacementOk` get-only property that verifies if placement of ship is possible.

10. Implement the `Ship` class and its methods.
    - The `Ship` class has a `List<Square>` field. It contains the squares where the ship is located.

11. Implement the `ShipType` enum and its methods.
    - The `ShipType` enum represents ship types. The types are Carrier, Cruiser, Battleship, Submarine, and Destroyer.
    - Each `ShipType` has a unique length.

12. Implement the `Square` class and its methods.
    - The `Square` class has a `Position` property. The property is a tuple consisting of `x` and `y` coordinates.
    - The `Square` class has a `SquareStatus` field.
    - The `Square` class has method that returns a graphical representation of `SquareStatus`.

13. Implement the `SquareStatus` enum.
    - The `SquareStatus` enum represents possible square statuses (empty, ship, hit, missed).
    - Each `SquareStatus` has a unicode character that can be used for printing it out. This unicode character is returned by `Square.GetCharacter()` method.

## General requirements

None

## Hints

- There is no skeleton code for this project (on purpose), just an empty file.
  Try to create it from scratch.
- Focus on features first, and refactor at the end.

## Background materials

- [UML diagrams](https://www.lucidchart.com/blog/types-of-UML-diagrams)
- <i class="far fa-exclamation"></i> [S - Single Responsibility Principle](https://www.c-sharpcorner.com/article/solid-single-responsibility-principle-with-c-sharp/)
- <i class="far fa-exclamation"></i> [O - Open/Closed Principle](https://dotnettutorials.net/lesson/open-closed-principle/)
- <i class="far fa-exclamation"></i> [Inheritance in C#](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/inheritance)
- <i class="far fa-exclamation"></i> [Abstraction in C#](https://www.w3schools.com/cs/cs_abstract.asp)
- <i class="far fa-exclamation"></i> [Polymorphism in C#](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/polymorphism)
- <i class="far fa-exclamation"></i> [Properties in C#](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-properties)
- [Tips on Battleship strategy](https://www.wikihow.com/Win-at-Battleship)
