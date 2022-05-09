using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class General
{
    private static int segundos = 60;
    private static int segundosRestorer = 60;
    private static int segundosInicio = 3;
    private static int segundosInicioRestorer = 3;
    private static int numPalomitasDestruidas = 0;

    public static int GetSegundos()
    {
        return segundos;
    }
    public static void SetSegundos(int s)
    {
       segundos = s;
    }

    public static int GetSegundosInicio()
    {
        return segundosInicio;
    }
    public static void SetSegundosInicio(int s)
    {
       segundosInicio = s;
    }

    public static int GetSegundosRestorer()
    {
        return segundosRestorer;
    }
    public static void SetSegundosRestorer(int s)
    {
       segundosRestorer = s;
    }

    public static int GetSegundosInicioRestorer()
    {
        return segundosInicioRestorer;
    }
    public static void SetSegundosInicioRestorer(int s)
    {
       segundosInicioRestorer = s;
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
