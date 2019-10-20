#include <iostream>

using namespace std;
string login;
string haslo;

int main()
{
    cout << "Podaj login " ;
    cin >>login;
    cout<< "Podaj haslo ";
    cin>> haslo;

    if ((login=="admin")&&(haslo=="szarlotka"));
    {
        cout<<"Udalo sie zalogowac";
    }

    return 0;
}
