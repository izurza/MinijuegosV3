using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class General
{
    private static int segundos = 10;
    private static int segundosRestorer = 10;
    private static int timer = 0;
    private static int timerRestorer = 0;
    private static int segundosInicio = 3;
    private static int segundosInicioRestorer = 3;
    private static int numPalomitasDestruidas = 0;
    private static int numPalomitasAtrapadas = 0;

    private static bool win = false;

    public static int GetSegundos()
    {
        return segundos;
    }
    public static void SetSegundos(int s)
    {
       segundos = s;
    }

    public static bool GetWin()
    {
        return win;
    }
    public static void SetWin(bool w)
    {
        win = w;
    }
    public static void ResetWin()
    {
        win = false;
    }

    public static int GetTimer()
    {
        return timer;
    }
    public static void SetTimer(int s)
    {
        timer = s;
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

    public static int GetTimerRestorer()
    {
        return timerRestorer;
    }
    public static void SetTimerRestorer(int s)
    {
        timerRestorer = s;
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
    public static void ResetPalomitas()
    {
        numPalomitasDestruidas = 0;
        numPalomitasAtrapadas = 0;
    }
    public static int GetNumPalomitasAtrapadas()
    {
        return numPalomitasAtrapadas;
    }
    public static void SetNumPalomitasAtrapadas(int n)
    {
        numPalomitasAtrapadas = n;
    }
}
