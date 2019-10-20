#include <iostream>
#include <cmath>

using namespace std;

float kat;

int main()
{
    cout << "Wartosc w stopniach: ";
    cin>>kat;

    cout<<sin(kat*M_PI/180.0)<<endl;
    cout<<cos(kat*M_PI/180.0)<<endl;
    cout<<tan(kat*M_PI/180.0)<<endl;
    cout<<1/tan(kat*M_PI/180.0)<<endl;
    return 0;
}
