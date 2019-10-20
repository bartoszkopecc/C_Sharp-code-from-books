#include <iostream>
#include <fstream>

using namespace std;

string imie;
string nazwisko;
int telefon;

int main()
{
    cout << "Podaj imie: " << endl;
    cin>>imie;
    cout<<"Podaj nazwisko: "<< endl;
    cin>>nazwisko;
    cout<<"Podaj numer telefonu: "<<endl;
    cin>>telefon;

    fstream plik;
    plik.open("plik.txt",ios::out | ios::app);

    plik<<imie<<endl;
    plik<<nazwisko<<endl;
    plik<<telefon<<endl;

    plik.close();
    plik.clear();



    return 0;
}
