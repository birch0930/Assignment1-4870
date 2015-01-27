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
        string[] searchWords = keyword.Text.ToString().Trim().Split(' ');

        if (searchWords[0] == "" && !Utils.GetSelected())
        {
            next.Enabled = false;
            prev.Enabled = false;
            head.Enabled = false;
            end.Enabled = false;
        }
        else
        {
            next.Enabled = true;
            prev.Enabled = true;
            head.Enabled = true;
            end.Enabled = true;
        }
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
                if (exclusionWords.Contains(searchWords[j]))
                {
                    continue;
                }
                else if (contents.Contains(searchWords[j]))
                {
                    isDisplay = true;
                }
                else
                {
                    isDisplay = false;
                    break;
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

        Utils.SetSelected(); // Sets flag so that navigation buttons can be used
        head.Enabled = false;
        prev.Enabled = false;

        if (Utils.GetTotalCounter() == 1)
        {
            next.Enabled = false;
            end.Enabled = false;
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

        if ((Utils.GetCurrentCounter() + 1) == Utils.GetTotalCounter())
        {
            next.Enabled = false;
            end.Enabled = false;
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

        if ((Utils.GetCurrentCounter() + 1) == 1)
        {
            prev.Enabled = false;
            head.Enabled = false;
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

        head.Enabled = false;
        prev.Enabled = false;

    }
    protected void end_Click(object sender, ImageClickEventArgs e)
    {
        currentFiles = Utils.GetArray();
        Utils.SetCurrentCounter(Utils.GetTotalCounter() - 1);
        string displayContent = File.ReadAllText(files[currentFiles[Utils.GetCurrentCounter()]]);

        tbContent.Text = displayContent;
        filename.Text = "Document:" + Path.GetFileName(files[currentFiles[Utils.GetCurrentCounter()]]);
        range.Text = "Result " + (Utils.GetCurrentCounter() + 1) + " of " + Utils.GetTotalCounter();

        next.Enabled = false;
        end.Enabled = false;
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
}
