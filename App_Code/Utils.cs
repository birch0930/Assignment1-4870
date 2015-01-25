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
	public Utils()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static string GetUploadsPhysicalDirectory()
    {
        string physicalDir = HttpContext.Current.Server.MapPath("~/SearchStar/files/");
        return physicalDir;
    }
}