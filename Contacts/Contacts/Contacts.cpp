// Contacts.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <stdio.h>
#include <iostream>
#include <stdlib.h>
#include <windows.h>

void showMenu();

int main()
{
    char cmd;

    do {
        showMenu();
        std::cout << "\tPlease enter your choice: ";
        std::cin >> cmd;
    } while (cmd != 'Q' && cmd != 'q');

    return 0;
}

void showMenu() {
    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), FOREGROUND_RED |
        FOREGROUND_GREEN |
        FOREGROUND_INTENSITY |
        BACKGROUND_BLUE
    );

    system("cls");
    std::cout << "\t===============================\n";
    std::cout << "\t|       Contact Manager       |\n";
    std::cout << "\t|                             |\n";
    std::cout << "\t| (G)et List                  |\n";
    std::cout << "\t| (S)ave List                 |\n";
    std::cout << "\t| (F)ind Contact              |\n";
    std::cout << "\t| (A)dd Contact               |\n";
    std::cout << "\t| (M)odify Contact            |\n";
    std::cout << "\t| (D)elete Contact            |\n";
    std::cout << "\t|                             |\n";
    std::cout << "\t| (Q)uit                      |\n";
    std::cout << "\t===============================\n";
}

