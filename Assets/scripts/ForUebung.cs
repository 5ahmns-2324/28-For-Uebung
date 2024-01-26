using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForUebung : MonoBehaviour
{
    int zeilenAnzahl = 3;

    private void Start()
    {
        for(int zeile = 1; zeile <= zeilenAnzahl; zeile++)
        {
            string ausgabe = "";

            ausgabe = GeneriereMinuszeichen(ausgabe, zeile);

            for(int sterne = 1; sterne <= 2 * zeile -1; sterne++)
            {
                ausgabe += "*";
            }

            ausgabe = GeneriereMinuszeichen(ausgabe, zeile);

            Debug.Log(ausgabe);
        }
    }

    private string GeneriereMinuszeichen(string ausgabe, int zeile)
    {
        for (int minus = 1; minus <= zeilenAnzahl - zeile; minus++)
        {
            ausgabe += "-";
        }

        return ausgabe;
    }
}
