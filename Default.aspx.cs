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

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void print_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void search_Click(object sender, EventArgs e)
    {
        string[] searchWords = keyword.Text.ToString().Split(' ');

        for( int i = 0; i < files.Length; i++)
        {
            string contents = File.ReadAllText(files[i]);

            for(int j = 0; j < searchWords.Length; j++)
            {
                if(contents.Contains(searchWords[j]))
                {
                    tbContent.Text = contents;
                }
            }
        }
    }
}