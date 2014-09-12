using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CC.Common.Compression;

namespace CC.Common.Compression.Demo
{
  public partial class frmMain : Form
  {
    private string _dir;

    public frmMain()
    {
      InitializeComponent();
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      Guid guid = Guid.NewGuid();
      _dir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\" + guid.ToString() + @"\";
    }

    private void btnExtractAll_Click(object sender, EventArgs e)
    {
      CleanUp();

      // Test.zip is in the project and is copied to the output directory
      // The file filter will extract all files (this is the default, no need to pass in anything)
      if (CCZip.ExtractZip("Test.zip", _dir))
      {
        // Walk the extracted directory - if you find dummy.dat or Crash.txt raise an exception
        string[] files = Directory.GetFiles(_dir, "*", SearchOption.AllDirectories);
        if (files.Count() == 9)
        {
          MessageBox.Show("All desired files were extracted properly");
        }
        else
        {
          MessageBox.Show("Uh-oh. We didn't extract the files we thought we would");
        }
      }
    }

    private void btnExtract_Click(object sender, EventArgs e)
    {
      CleanUp();

      // Test.zip is in the project and is copied to the output directory
      // The file filter will extract all dat files except for dummy.dat
      if (CCZip.ExtractZip("Test.zip", _dir, @"+\.dat$;-dummy\.dat$"))
      {
        // Walk the extracted directory - if you find dummy.dat or Crash.txt raise an exception
        string[] files = Directory.GetFiles(_dir, "*", SearchOption.AllDirectories);
        foreach (string file in files)
        {
          if (file.Contains("dummy.dat"))
            throw new Exception("Dummy.dat found - error");
          if (file.Contains(".txt"))
            throw new Exception("Text file found - error");
        }

        if (files.Count() == 4)
        {
          MessageBox.Show("All desired files were extracted properly");
        }
        else
        {
          MessageBox.Show("Uh-oh. We didn't extract the files we thought we would");
        }

      }
    }

    private void btnCreateZip_Click(object sender, EventArgs e)
    {
      if (Directory.Exists(_dir))
      {
        string file = _dir.Trim('\\') + ".zip";
        CCZip.CreateZip(file, _dir);
      }
      else
      {
        MessageBox.Show("Try an Extract option first");
      }
    }

    private void btnCleanUp_Click(object sender, EventArgs e)
    {
      CleanUp();
    }

    private void CleanUp()
    {
      // Clean up
      if (Directory.Exists(_dir))
      {
        string[] files = Directory.GetFiles(_dir, "*", SearchOption.AllDirectories);
        foreach (string file in files)
        {
          File.Delete(file);
          try
          {
            // The first file in files is from the root directory
            // we can't delete that yet because we have other files in it
            Directory.Delete(Path.GetDirectoryName(file));
          }
          catch { }
        }
        // Delete the root directory now
        Directory.Delete(_dir);
      }
    }

    private void btnZipDir_Click(object sender, EventArgs e)
    {
      CCZip.CreateZip(@".\Temp1.zip", @"C:\Temp");
      CCZip.CreateZip(@".\Temp2.zip", "C:/Temp/");
    }
  }
}
