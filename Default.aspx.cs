using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Net;
using System.Configuration;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows;
public partial class _Default : System.Web.UI.Page
{
    private string[] files = Directory.GetFiles(Utils.GetUploadsPhysicalDirectory());
    private string[] exclusionFile = Directory.GetFiles(Utils.GetExclusionPhysicalDirectory());
    private int[] currentFiles = new int[20]; //Remove magic number later
    string stringToPrint = null;

    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void search_Click(object sender, EventArgs e)
    {
        Utils.Reset();
        string[] searchWords = keyword.Text.ToString().Trim().Split(' ');
        string exclusionWords = File.ReadAllText(exclusionFile[0]);
        bool isDisplay = false;

        for (int i = 0; i < files.Length; i++)
        {
            string contents = File.ReadAllText(files[i]);

            for (int j = 0; j < searchWords.Length; j++)
            {
                if (contents.Contains(searchWords[j]) && !exclusionWords.Contains(searchWords[j]))
                {
                    isDisplay = true;
                    break;
                }
                else
                {
                    isDisplay = false;
                }
            }
            if (isDisplay)
            {
                currentFiles[Utils.GetTotalCounter()] = i;
                Utils.IncreaseTotalCounter();
            }
        }
        if (Utils.GetTotalCounter() > 0)
        {
            string displayContent = File.ReadAllText(files[currentFiles[Utils.GetCurrentCounter()]]);

            tbContent.Text = displayContent;
            filename.Text = "Document:" + Path.GetFileName(files[currentFiles[Utils.GetCurrentCounter()]]);
            range.Text = "Result " + (Utils.GetCurrentCounter() + 1) + " of " + Utils.GetTotalCounter();
            Utils.SetArray(currentFiles);
        }
        else
        {
            tbContent.Text = null;
            filename.Text = "No Contents Found";
            range.Text = null;
        }
      

    }
    protected void next_Click(object sender, ImageClickEventArgs e)
    {
        if (Utils.GetCurrentCounter() + 1 < Utils.GetTotalCounter())
        {
            currentFiles = Utils.GetArray();
            Utils.IncreaseCurrentCounter();
            string displayContent = File.ReadAllText(files[currentFiles[Utils.GetCurrentCounter()]]);

            tbContent.Text = displayContent;
            filename.Text = "Document:" + Path.GetFileName(files[currentFiles[Utils.GetCurrentCounter()]]);
            range.Text = "Result " + (Utils.GetCurrentCounter() + 1) + " of " + Utils.GetTotalCounter();
        }
    }
    protected void prev_Click(object sender, ImageClickEventArgs e)
    {
        if (Utils.GetCurrentCounter() > 0)
        {
            currentFiles = Utils.GetArray();
            Utils.DecreaseCurrentCounter();
            string displayContent = File.ReadAllText(files[currentFiles[Utils.GetCurrentCounter()]]);

            tbContent.Text = displayContent;
            filename.Text = "Document:" + Path.GetFileName(files[currentFiles[Utils.GetCurrentCounter()]]);
            range.Text = "Result " + (Utils.GetCurrentCounter() + 1) + " of " + Utils.GetTotalCounter();
        }
    }
    protected void head_Click(object sender, ImageClickEventArgs e)
    {
        currentFiles = Utils.GetArray();
        Utils.SetCurrentCounter(0);
        string displayContent = File.ReadAllText(files[currentFiles[Utils.GetCurrentCounter()]]);

        tbContent.Text = displayContent;
        filename.Text = "Document:" + Path.GetFileName(files[currentFiles[Utils.GetCurrentCounter()]]);
        range.Text = "Result " + (Utils.GetCurrentCounter() + 1) + " of " + Utils.GetTotalCounter();
    }
    protected void end_Click(object sender, ImageClickEventArgs e)
    {
        currentFiles = Utils.GetArray();
        Utils.SetCurrentCounter(Utils.GetTotalCounter() - 1);
        string displayContent = File.ReadAllText(files[currentFiles[Utils.GetCurrentCounter()]]);

        tbContent.Text = displayContent;
        filename.Text = "Document:" + Path.GetFileName(files[currentFiles[Utils.GetCurrentCounter()]]);
        range.Text = "Result " + (Utils.GetCurrentCounter() + 1) + " of " + Utils.GetTotalCounter();
    }
    protected void save_Click(object sender, ImageClickEventArgs e)
    {

        if (filename.Text != null && !filename.Text.Equals(""))
        {
            string strFileName = filename.Text.Substring(9);
            string path = Utils.GetUploadsPhysicalDirectory() + strFileName;
            Response.AddHeader("Content-Disposition", "attachment;filename=" + Server.UrlPathEncode(strFileName));
            Response.TransmitFile(path);
        }
        else return;
    }



    protected void print_Click(object sender, ImageClickEventArgs e)
    {


        string path = null;
        if (filename.Text != null && !filename.Text.Equals(""))
        {
            string strFileName = filename.Text.Substring(9);
            path = Utils.GetUploadsPhysicalDirectory() + strFileName;
           
        }
        else return;
        stringToPrint = File.ReadAllText(files[currentFiles[Utils.GetCurrentCounter()]]);
       
        PrintDocument pd = new PrintDocument();
        pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
        PrintDialog ppd = new PrintDialog();

        ppd.Document = pd;

        if (ppd.ShowDialog() == DialogResult.OK)
        {
            pd.Print();
        }
       
    }

 
    private void pd_PrintPage(object sender, PrintPageEventArgs ev)
    {
        
        int charactersOnPage = 0;
        int linesPerPage = 0;
        Font drawFont = new Font("Arial", 16);
 

        // Sets the value of charactersOnPage to the number of characters  
        // of stringToPrint that will fit within the bounds of the page.
        ev.Graphics.MeasureString(stringToPrint, drawFont,
            ev.MarginBounds.Size, StringFormat.GenericTypographic,
            out charactersOnPage, out linesPerPage);     

        // Draws the string within the bounds of the page
        ev.Graphics.DrawString(stringToPrint, drawFont, Brushes.Black,
            ev.MarginBounds, StringFormat.GenericTypographic);

        // Remove the portion of the string that has been printed.
        stringToPrint = stringToPrint.Substring(charactersOnPage);

        // Check to see if more pages are to be printed.
        ev.HasMorePages = (stringToPrint.Length > 0);
        
    }
}