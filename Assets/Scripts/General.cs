using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class General
{
    private static int segundos = 5;
    private static int numPalomitasDestruidas = 0;

    public static int GetSegundos()
    {
        return segundos;
    }
    public static void SetSegundos(int s)
    {
       segundos = s;
    }

    public static int GetNumPalomitasDestruidas()
    {
        return numPalomitasDestruidas;
    }
    public static void SetNumPalomitasDestruidas(int n)
    {
        numPalomitasDestruidas = n;
    }
}
