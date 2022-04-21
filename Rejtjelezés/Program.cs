using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rejtjelezés
{
    class Program
    {
            static string rejtjelezett(string üzenet, string kulcs)
            {
                //Létrehoztam a változókat amelyekben eltárolom:
                string jelsor = "";  // A leendő jelsort amit betünkét egészítek ki a ciklus lefutása során
                int ukod = 0;  //az üzenet kódját
                int kkod = 0;  //a kulcs kódját
                int jel = 0;  //Az üzenet és a kulcs egyik kódjából képzett jelsorozat egyik kódját

                /*A feladat megoldásánál kihasználom, hogy az angol abc betűinek a kódjai egymást követik, egyedül a szóközt kell
                külön lekezelni, mint a 26. elem. Mivel az 'a' betűnek alapjáraton a 97-es a kódja, így ha kivonjuk mindig az adott
                betü kódjából az 'a' karakter kódját akkor 0-tól 25-ig kapjuk meg a betük kódjait.
                */
                for (int i = 0; i < üzenet.Length; i++)
                {
                    //Ha az üzenet egyik karaktere szóköz akkor annak a 26-os legyen a kódja
                    if (üzenet[i] == ' ')
                    {
                        ukod = 26;
                    }
                    // különben pedig az üzenet karakterének kódja -(minusz) az 'a' karakter kódja legyen a kódja ami egy 0-25ig ad vissza egy számot
                    else
                    {
                        ukod = üzenet[i] - 'a';
                    }
                    //majd ezt az eljárást a kulcs karaktereire is elvégezzük
                    if (kulcs[i] == ' ')
                    {
                        kkod = 26;
                    }
                    else
                    {
                        kkod = kulcs[i] - 'a';
                    }
                    /* A jel karakterének azonosítóját megkapjuk, ha összeadjuk az üznenet karakterének számát a kulcs adott 
                      karakterének megfelelő kódjával*/
                    jel = ukod + kkod;
                    //ha ez a szám nagyobb mint 26 akkor a maradékos osztás eredménye legyen az azonosítója
                    if (jel > 26)

                    {
                        jel = jel % 27;
                    }
                    /*Majd a jelsor nevű stringbe visszaalakítjuk karakterekké a karakterek azonosítóit, így betüket és esetleg 
                    szóközt kapunk a rejtjelezett üzenetbe amit folyamatosan bővítünk addig amíg vége nincs a ciklusnak( be nem olvasta és 
                    át nem alakította az összes karaktert az üzenetből, kódból)*/

                    jelsor = jelsor + Convert.ToChar(jel + 'a');

                }
                return jelsor;
            }

            static string megoldas(string kulcs, string rejtuz)
            {
                /*Amikor az eredeti üzenetet szeretnénk megkapni, hasonlómódszerrel tehetjük meg ezt, mint az előző függvény,
                viszont most hátulról haladunk előre így nem hozzáadni kell majd a kulcs kódját, hanem kivonni*/
                string uzenet = "";
                int kkod = 0;
                int rkod = 0;
                int jel = 0;

                for (int i = 0; i < rejtuz.Length; i++)
                {
                    if (rejtuz[i] == ' ')
                    {
                        rkod = 26;
                    }
                    else
                    {
                        rkod = rejtuz[i] - 'a';
                    }
                    if (kulcs[i] == ' ')
                    {
                        kkod = 26;
                    }
                    else
                    {
                        kkod = kulcs[i] - 'a';
                    }
                    jel = rkod - kkod;
                    /*Megvan annak az esélye, hogy az így kapott "jel" változóban negatív számot kapunk,
                     ha ez megtörténne akkor 27 hozzáadásával visszaáll a karakter kódja 0-26 intervallumra.*/
                    if (jel < 0)
                    {
                        jel = jel + 27;
                    }
                    if (jel > 26)
                    {
                        jel = jel % 27;
                    }
                    if (jel == 26)
                    {
                        uzenet = uzenet + " ";
                    }
                    //Miután megkaptuk az azonosítókat, átalakítjuk karakterré, majd az "uzenet" váltózóban eltároljuk ezeket.
                    else
                    {
                        uzenet = uzenet + Convert.ToChar(jel + 'a');
                    }
                }

                return uzenet;
            }


            /*static string miakulcs(string rejtjel1, string rejtjel2)
            {
                string kulcs = "";
                int r1kod = 0;


            }*/
            static void Main(string[] args)
            {
                //1. feladat a)
                Console.WriteLine("1. feladat a)");
                /*Majd bekérem a  felhasználótól az üzenetet, hozzá tartozó kulcsot,
                a függvény segítségével megadja a program a rejtjelezettüzenetet*/

                Console.Write("Kérem az üzenetet!: ");
                string beuzenet = Console.ReadLine();

                Console.Write("Kérem a kulcsot!: ");
                string bekulcs = Console.ReadLine();

                Console.Write("A rejtjelezett üzenet: {0}", rejtjelezett(beuzenet, bekulcs));
                Console.WriteLine();
                Console.WriteLine();
                //1. feladat b)
                Console.WriteLine("1. feladat b)");
                Console.Write("Kérem a kulcsot!: ");
                string bekulcsb = Console.ReadLine();

                Console.Write("Kérem a rejtjeles üzenetet!: ");
                string berejtuzenet = Console.ReadLine();

                Console.WriteLine("Az eredeti üzenet: {0}", megoldas(bekulcs, berejtuzenet));
                Console.WriteLine();

                //2. feladat




                Console.ReadKey();
            }
        }
    

    }

