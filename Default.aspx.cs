using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    string[] files = Directory.GetFiles(Utils.GetUploadsPhysicalDirectory());
    int totalCount = 0;
    int currentCount = 0;
    int index = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void print_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void search_Click(object sender, EventArgs e)
    {
        string[] searchWords = keyword.Text.ToString().Split(' ');
        bool isDisplay = false;

        for( index = 0; index < files.Length; index++)
        {
            string contents = File.ReadAllText(files[index]);

            for(int j = 0; j < searchWords.Length; j++)
            {
                if (!contents.Contains(searchWords[j]))
                {
                    isDisplay = false;
                    break;
                }
                else
                {
                    isDisplay = true;
                }
            }
            if (isDisplay)
            {
                totalCount++;
            }
        }

        for (index = 0; index < files.Length; index++)
        {
            string contents = File.ReadAllText(files[index]);

            for (int j = 0; j < searchWords.Length; j++)
            {
                if (!contents.Contains(searchWords[j]))
                {
                    isDisplay = false;
                    break;
                }
                else
                {
                    isDisplay = true;
                }
            }
            if (isDisplay)
            {
                tbContent.Text = contents;
                currentCount++;
                range.Text = "Result " + currentCount + " of " + totalCount;
                filename.Text = files[index];
                return;
            }
        }
    }
}