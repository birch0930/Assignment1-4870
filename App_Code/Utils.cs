using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Utils
/// </summary>
public class Utils
{
    private static int[] array = new int[20];
    private static int totalCounter = 0;
    private static int currentCounter = 0;
	public Utils()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static void Reset()
    {
        array = new int[20];
        totalCounter = 0;
        currentCounter = 0;
    }

    public static string GetUploadsPhysicalDirectory()
    {
        string physicalDir = HttpContext.Current.Server.MapPath("~/SearchStar/files/");
        return physicalDir;
    }

    public static string GetExclusionPhysicalDirectory()
    {
        string physicalDir = HttpContext.Current.Server.MapPath("~/SearchStar/exclusion/");
        return physicalDir;
    }

    public static void SetArray(int[] newArray)
    {
        array = newArray;
    }

    public static int[] GetArray()
    {
        return array;
    }

    public static void IncreaseTotalCounter()
    {
        totalCounter++;
    }

    public static int GetTotalCounter()
    {
        return totalCounter;
    }

    public static void SetCurrentCounter(int newValue)
    {
        currentCounter = newValue;
    }

    public static void IncreaseCurrentCounter()
    {
        currentCounter++;
    }

    public static void DecreaseCurrentCounter()
    {
        currentCounter--;
    }

    public static int GetCurrentCounter()
    {
        return currentCounter;
    }

}