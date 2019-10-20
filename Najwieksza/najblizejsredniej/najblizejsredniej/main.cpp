#include <iostream>

using namespace std;

float a,b,c,d,e;
float srednia;
float ns;

int main()
{
    cout << "Podaj 5 cyfr rozdzielonych spacja: " << endl;
    cin>>a>>b>>c>>d>>e;

    srednia =  (a+b+c+d+e)/5;
    cout<<"Wartosc sredniej to "<<srednia<<endl;

    ns=a;
    if (b-ns<ns) ns=b;
    if (c-ns<ns) ns=c;
    if (d-ns<ns) ns=d;
    if (e-ns<ns) ns=e;

    cout<<"Najbliszej sredniej jest: "<<ns<<endl;





    return 0;
}
