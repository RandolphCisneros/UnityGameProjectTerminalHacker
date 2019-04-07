using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    // Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;
    string passwordEasy = "food";
    string passwordHard = "degenerate";

    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu") // we can always go direct to main menu
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            RunPassword(input);
        }
        else if (currentScreen == Screen.Win)
        {
            RunWinScreen(input);
        }
    }

    void RunWinScreen(string input)
    {
        if(input == "y")
        {
            Start();
        }
        else if (input == "n")
        {
            Terminal.WriteLine("Game Over");
            //Quit game here or the loop will continue
        }
        else
        {
            Terminal.WriteLine("Please enter valid input");
        }
    }

    void RunPassword(string input)
    {
        if (level == 1)
        {
            if (input == passwordEasy)
            {

                Terminal.WriteLine("You've won!");
                Terminal.WriteLine("Would you like to play again? y/n");
                currentScreen = Screen.Win;
            }
            else
            {
                Terminal.WriteLine("Guess again");
            }
        } else if (level == 2)
        {
            if (input == passwordHard)
            {

                Terminal.WriteLine("You've won!");
                Terminal.WriteLine("Would you like to play again? y/n");
                currentScreen = Screen.Win;
            }
            else
            {
                Terminal.WriteLine("Guess again");
            }
        } 
    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter your password: ");
    }
}