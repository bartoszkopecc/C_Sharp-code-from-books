#include <iostream>

using namespace std;

int main()
{
    string imie;
    cout<<"Jak masz na imie?"<<endl;
    cin>>imie;

    int dlugosc = imie.length();

     if (imie[dlugosc-1]=='a')
        cout<<"Chyba jestes kobieta"<<endl;
     else cout<<"Jestes facetem"<<endl;



    return 0;
}
