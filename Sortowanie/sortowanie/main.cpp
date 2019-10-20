#include <iostream>
#include <time.h>
#include <windows.h>

using namespace std;

int ile;
clock_t start, stop;
double czas;

void sortowanie_babelkowe(int *tab, int n)
{
    for (int i=1; i<n; i++)
    {
        for (int j=n-1; j>=1; j--)
        {
            if (tab[j]<tab[j-1])
            {
                int bufor;
                bufor = tab[j-1];
                tab[j-1]=tab[j];
                tab[j]=bufor;

            }
        }
    }
}
int main()
{
    cout << "Porownanie czasow sortowanie v.1" << endl;
    cout<<"Ile losowych liczb w tablicy: "<<endl;
    cin>>ile;

    //dynamiczna alokacja tablicy
    int *tablica;
    tablica=new int [ile];

    //inicjowanie generatora
    srand(time(NULL));

    //wczytywanie losowych liczb do tablicy
    for (int i=0; i<ile; i++)
    {
        tablica[i] = rand()%100000+1;
       // cout<<tablica[i]<< " ";
    }

    //cout<<"Przed posortowaniem: "<<endl;
    for (int i=0; i<ile; i++)
    {
    //   cout<<tablica[i]<< " ";
    }

    cout<<"Sortuje babelkowo, prosze czekac"<<endl;

    start = clock();
    sortowanie_babelkowe(tablica,ile);
    stop = clock();
    czas= (double)(stop-start)/CLOCKS_PER_SEC;
    //cout<<"Po sortowaniu: "<<endl;

    for (int i=0; i<ile; i++)
    {
    //   cout<<tablica[i]<< " ";
    }
    cout<<endl<<"Czas sortowania babelkowego: "<<czas<<" s"<<endl;

    delete [] tablica;


    return 0;
}
