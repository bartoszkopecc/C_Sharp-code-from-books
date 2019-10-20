#include <iostream>
#include <cstdlib>
#include <stdio.h>
#include <conio.h>

using namespace std;

float x;
float y;
char wybor;

int main()
{
    for(;;)
    {
    cout << "Podaj 1 liczbe: ";
    cin>> x;
    cout<< "Podaj 2 liczba: ";
    cin>> y;

    cout<<endl;
    cout<<"MENU GLOWNE" <<endl;
    cout<<"-----------------" << endl;
    cout<<"1. Dodawanie" <<endl;
    cout<<"2. Odejmowanie" <<endl;
    cout<<"3. Mnozenie" <<endl;
    cout<<"4. Dzielenie" <<endl;
    cout<<"5. Koniec programu"<<endl;

    wybor=getch();


    switch (wybor)
    {
     case '1':
         cout<<"Suma = "<<x+y;
     break;

     case '2':
        cout<<"Odejmowanie = "<<x-y;
     break;

     case '3':
        cout<<"Mnozenie = "<<x*y;
     break;

     case '4':
        if (y==0) cout<<"Tak sie nie godzi";
        else cout<<"Dzielenie = "<<x/y;
     break;

     case '5':
     exit(0);

    default: cout<<"Nie ma takiej opcji chuju";
    }
    getchar(); getchar();

    system("cls");

    }
    return 0;
}
