using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;

public partial class _Default : System.Web.UI.Page
{
    string[] files = Directory.GetFiles(Utils.GetUploadsPhysicalDirectory());
    int[] currentFiles = new int[20]; //Remove magic number later

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void print_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void search_Click(object sender, EventArgs e)
    {
        Utils.Reset();
        string[] searchWords = keyword.Text.ToString().Split(' ');
        bool isDisplay = false;

        for( int i = 0; i < files.Length; i++)
        {
            string contents = File.ReadAllText(files[i]);

            for(int j = 0; j < searchWords.Length; j++)
            {
                if (contents.Contains(searchWords[j]))
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

            string displayContent = File.ReadAllText(files[currentFiles[Utils.GetCurrentCounter()]]);

            tbContent.Text = displayContent;
            filename.Text = files[currentFiles[Utils.GetCurrentCounter()]];
            range.Text = "Result " + (Utils.GetCurrentCounter() + 1) + " of " + Utils.GetTotalCounter();
            Utils.SetArray(currentFiles);
            //return;
  
    }
    protected void next_Click(object sender, ImageClickEventArgs e)
    {
        if (Utils.GetCurrentCounter() + 1 < Utils.GetTotalCounter())
        {
            currentFiles = Utils.GetArray();
            Utils.IncreaseCurrentCounter();
            string displayContent = File.ReadAllText(files[currentFiles[Utils.GetCurrentCounter()]]);

            tbContent.Text = displayContent;
            filename.Text = files[currentFiles[Utils.GetCurrentCounter()]];
            range.Text = "Result " + (Utils.GetCurrentCounter() + 1) + " of " + Utils.GetTotalCounter();
        }
    }
    protected void prev_Click(object sender, ImageClickEventArgs e)
    {
        if (Utils.GetCurrentCounter() > 0 )
        {
            currentFiles = Utils.GetArray();
            Utils.DecreaseCurrentCounter();
            string displayContent = File.ReadAllText(files[currentFiles[Utils.GetCurrentCounter()]]);

            tbContent.Text = displayContent;
            filename.Text = files[currentFiles[Utils.GetCurrentCounter()]];
            range.Text = "Result " + (Utils.GetCurrentCounter() + 1) + " of " + Utils.GetTotalCounter();
        }
    }
    protected void head_Click(object sender, ImageClickEventArgs e)
    {

    }
}