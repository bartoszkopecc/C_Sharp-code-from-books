#include <iostream>
#include <cmath>
#include <iomanip>

using namespace std;

long long int x;
unsigned int y;


int main()
{
    x = (pow(2,32))-1;
    y=x+1;
    cout<<setprecision(20);
    cout<<"Max: "<<y<<endl;

    cout<<x<<endl;


    cout << sizeof(x) << endl;

    return 0;
}
