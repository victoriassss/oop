using System;                    // system przestrzen nazw
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




    static class Menu // klasa statyczna 
    {
        public static void StartMenu() //metoda publiczna
        {
            Console.Title = "Menu"; //tytuł konsoli
        bool exit = false; //pętla jest kontynuowana gdy warunek nie jest spelniony
            while (!exit) //petla !-operator negacji, negacja operandu
            {
                Console.Clear(); //czyszczenie konsoli
            Console.WriteLine("Spróbuj odgadnąć 4 cyfry wylosowane dla Ciebie przez komputer:"); // wyswietlanie tekstu
            Console.WriteLine("Wybierz:"); // wyswietlanie tekstu
                Console.WriteLine("1. Aby zagrać.");// wyswietlanie tekstu
            Console.WriteLine("2. Aby zakończyć program.");// wyswietlanie tekstu

            ConsoleKeyInfo klawisz = Console.ReadKey(); // obiekt struktury consoleKeyInfo nazwany ''klawisz'
                                                            // i przypisany mu efekt instrukcji console.readKey
                                                            // czyli czekanie na wcisniecie klawisza
                switch (klawisz.Key) // instrukcja sprawdzenie wlasciwosci Key dla wcisnietego klawisza
                                     // zmienna od wartosci, której zalezy wybor odpowiedniego case
                {
                    case ConsoleKey.NumPad1: //NumPad1=1 wartosci typu obliczeniowego ConsoleKey
                        Console.Clear(); Los(); break; // o nacisnieciu klawisza nastepuje wyczyszczenie konsoli i wywolanie metody o nazwie los
                    case ConsoleKey.NumPad2:
                    exit = true; //operand ma wartosć true czyli warunek nie jest spelniony - aplikacja zamknie się
                    break;
                    default: break;
                }
            }
        }

    static void Los() // metoda statyczna o nazwie los

    {

        // deklarowanie liczb

        int Liczba1;
        int Liczba2;
        int Liczba3;
        int Liczba4;

        int Liczenia;
        int zgadywanie;

        // deklarowanie stałych

        const int liczby = 4;
        const int jednotrafienie = 1;
        const int dwatrafienia = 2;
        const int trzytrafienia = 3;
        const int czterytrafienia = 4;


        // deklarowanie tablic

        int[] sortowanieLiczb = new int[4];
        int[] zgadywania = new int[4];
        int[] sortowanieZgadywania = new int[4];

        // generowanie liczb losowych miedzy 1 a 9

        Random randomnumber = new Random(); //operstor new- utworzenie 

        Liczba1 = randomnumber.Next(1, 9); // liczby miedzy 1, a 9
        Liczba2 = randomnumber.Next(1, 9); // zwraca losowa liczbe calkowita znajdujaca sie miedzy 1 a 9
        Liczba3 = randomnumber.Next(1, 9);
        Liczba4 = randomnumber.Next(1, 9);
        sortowanieLiczb[0] = Liczba1; // przypisanie liczb do tablicy
        sortowanieLiczb[1] = Liczba2;
        sortowanieLiczb[2] = Liczba3;
        sortowanieLiczb[3] = Liczba4;
        Array.Sort(sortowanieLiczb); // metoda sortowania elementow w tablicy jednowymiarowej
        for (Liczenia = 0; Liczenia < liczby; Liczenia++) //wykonuje instrukcje dopoki liczenie nie wyniesie 4
        {
            Console.Write("\nLiczba:" + (Liczenia + 1) + " Wybierz liczbę: ");//wyswietla tekst oraz zwieksza liczbe liczen o 1 
            zgadywanie = Convert.ToInt32(Console.ReadLine()); // metoda konwertuje okreslona wartosc na 32bitowa liczbe calkowita 
                                                              // wpisywanie liczby przez uzytkownika

            while (zgadywanie < 1 || zgadywanie > 9) // kiedy ucytkownik wpisze liczbe z pora przedzialu
            {                                        // wyswietli sie ponozszy tekst
                Console.WriteLine("Wybrałeś złą liczbę, spróbuj jeszcze raz.");
                Console.Write("\nLiczba:" + (Liczenia + 1) + " Wybierz liczbę: "); // znowu prosi uzytkownika o wpisanie liczby
                zgadywanie = Convert.ToInt32(Console.ReadLine());
            }

            zgadywania[Liczenia] = zgadywanie; // liczba elementow w tablicy wyniesie 
            sortowanieZgadywania[Liczenia] = zgadywanie;
        }

        Array.Sort(sortowanieZgadywania); // metoda sortowania elementow w tablicy jednowymiarowej       

        Console.WriteLine();
        Console.WriteLine("Losowe liczby to    : " + Liczba1 + ", " + Liczba2 + ", " + Liczba3 + " , " + Liczba4); //wyswietla liczby
        Console.WriteLine("Liczby które wybrałeś : " + zgadywania[0] + ", " + zgadywania[1] + ", " + zgadywania[2] + " , " + zgadywania[3]); // wyswietla elementy tablicy

        if (zgadywania[0] == Liczba1 && zgadywania[1] == Liczba2 && zgadywania[2] == Liczba3 && zgadywania[3] == Liczba4) // == - zwraca wartosc jesli true operandy sa rowne, w rzeciwnym razie false
        {                                                                                                                 //  x && y -  wynik jest true jesli obydwa x i y sa true
            Console.WriteLine("Zdobyłeś punktów: " + czterytrafienia); // wyswietla jesli zostana spelnione powyzsze wyrazenie
        }         // instrukcja warunkowa (if) wykonuje instrukcje jesli spenia warunek w innym wypadku (else if, else)

        else if (sortowanieZgadywania[0] == sortowanieLiczb[0] && sortowanieZgadywania[1] == sortowanieLiczb[1]
        && sortowanieZgadywania[2] == sortowanieLiczb[2])
        {
            Console.WriteLine("Zdobyłeś punktów:" + trzytrafienia); //instrukcja
        }

        else if ((zgadywania[0] == Liczba1 && zgadywania[1] == Liczba2) || (zgadywania[1] == Liczba2 && zgadywania[2] == Liczba3))
        {
            Console.WriteLine("Zdobyłeś punktów:" + dwatrafienia);
        }

        else if (zgadywania[0] == Liczba1 || zgadywania[1] == Liczba2 || zgadywania[2] == Liczba3)
        {
            Console.WriteLine("Zdobyłeś punktów:" + jednotrafienie);
        }

        else // jesli nie zostana spelnione powyzsze 
        {
            Console.WriteLine("Przykro mi, zdobyłeś 0 punktów. Spróbuj jeszcze raz");
        }


        Console.ReadKey(); //pobiera znak lub funkcje wskutek nacisniecia klawisza, zostawe wyswietlony w konsoli


    }
        }
    

    




