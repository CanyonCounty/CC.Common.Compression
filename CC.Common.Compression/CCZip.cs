using System;
using System.IO;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;

// http://wiki.sharpdevelop.net/SharpZipLib-Zip-Samples.ashx
namespace CC.Common.Compression
{
  /// <summary>
  /// Just A Wrapper for ICSharpCode.SharpZipLib
  /// </summary>
  public class CCZip
  {
    private static string _error_message = String.Empty;
    private static int _compression_level = 9;
    private static int _buffer_size = 4096;
    private static string _search_pattern = "*.*";
    private static string _root_path = String.Empty;

    public static String Error
    {
      get { return _error_message; }
    }

    public static int CompressionLevel
    {
      get { return _compression_level; }
      set
      {
        _compression_level = value;
        if (_compression_level < 0) _compression_level = 0;
        if (_compression_level > 9) _compression_level = 9;
      }
    }

    public static int BufferSize
    {
      get { return _buffer_size; }
      set { _buffer_size = value; }
    }

    public static String SearchPattern
    {
      get { return _search_pattern; }
      set { _search_pattern = value; }
    }

    /// <summary>
    /// Extracts the zipFile to targetDirectory using the fileFilter
    /// </summary>
    /// <param name="zipFile">The path to the .zip file to extract</param>
    /// <param name="targetDirectory">The directory to extract it to</param>
    /// <param name="fileFilter">regex values semi-colon separated for files to extract (Example @"+\.dat$;-^dummy\.dat$" will extract all .dat files except for dummy.dat</param>
    /// <returns>True if operation completed successfully</returns>
    public static bool ExtractZip(string zipFile, string targetDirectory, string fileFilter = "")
    {
      bool ret = false;
      _error_message = "";
      try
      {
        FastZip fz = new FastZip();
        fz.ExtractZip(zipFile, targetDirectory, fileFilter);
        ret = true;
      }
      catch (Exception e) { _error_message = e.Message; }
      return ret;
    }

    /// <summary>
    /// Creates a zip file from the contents of the source directory
    /// </summary>
    /// <param name="zipFile">The path to the zip file you want to create</param>
    /// <param name="srcDirectory">The directory to zip up</param>
    /// <returns></returns>
    public static bool CreateZip(string zipFile, string srcDirectory)
    {
      bool ret = false;
      FileStream fsOut = File.Create(zipFile);
      ZipOutputStream zipStream = new ZipOutputStream(fsOut);

      zipStream.SetLevel(_compression_level);

      _root_path = srcDirectory;
      CompressFolder(srcDirectory, zipStream);

      zipStream.IsStreamOwner = true;	// Makes the Close also Close the underlying stream
      zipStream.Close();

      return ret;
    }

    // Recurses down the folder structure
    //
    private static void CompressFolder(string path, ZipOutputStream zipStream)
    {
      string[] files = Directory.GetFiles(path, _search_pattern);
      foreach (string filename in files)
      {
        FileInfo fi = new FileInfo(filename);

        //string entryName = filename.Substring(folderOffset); // Makes the name in zip based on the folder
        string entryName = filename.Replace(_root_path, "");
        entryName = ZipEntry.CleanName(entryName); // Removes drive from name and fixes slash direction
        ZipEntry newEntry = new ZipEntry(entryName);
        newEntry.DateTime = fi.LastWriteTime; // Note the zip format stores 2 second granularity

        newEntry.Size = fi.Length;

        zipStream.PutNextEntry(newEntry);

        // Zip the file in buffered chunks
        // the "using" will close the stream even if an exception occurs
        byte[] buffer = new byte[_buffer_size];
        using (FileStream streamReader = File.OpenRead(filename))
        {
          StreamUtils.Copy(streamReader, zipStream, buffer);
        }
        zipStream.CloseEntry();
      }
      string[] folders = Directory.GetDirectories(path);
      foreach (string folder in folders)
      {
        CompressFolder(folder, zipStream);//, folderOffset);
      }
    }

    //public static bool CreateZip(string zipFile, string srcDirectory, string fileFilter = "*")
    //{
    //  bool ret = false;
    //  string[] srcFiles = Directory.GetFiles(srcDirectory, fileFilter, SearchOption.AllDirectories);
    //  ret = CreateZip(zipFile, srcFiles);
    //  return ret;
    //}

    //public static bool CreateZip(string zipFile, string[] srcFiles)
    //{
    //  bool ret = false;
    //  try
    //  {
    //    string dir = Path.GetDirectoryName(srcFiles[0]);
    //    dir += Path.DirectorySeparatorChar;

    //    ZipFile zip = ZipFile.Create(zipFile);
    //    zip.BufferSize = _buffer_size;
    //    zip.BeginUpdate();
    //    foreach (string file in srcFiles)
    //    {
    //      string real = file.Replace(dir, "");
    //      if (real.Contains(Path.DirectorySeparatorChar))
    //      {
    //        try { zip.AddDirectory(Path.GetDirectoryName(file).Replace(dir, "")); }
    //        catch { }
    //      }
    //      zip.Add(file, real);
    //    }
    //    zip.CommitUpdate();
    //    zip.Close();
    //  }
    //  catch (Exception e) { _error_message = e.Message; }
    //  return ret;
    //}

    //public static bool CreateZip(string zipFile, string[] srcFiles)
    //{
    //  bool ret = false;
    //  // 'using' statements guarantee the stream is closed properly which is a big
    //  // source of problems otherwise. Exception safe - woot!
    //  try
    //  {
    //    using (ZipOutputStream s = new ZipOutputStream(File.Create(zipFile)))
    //    {
    //      s.SetLevel(_compression_level);
    //      byte[] buffer = new byte[_buffer_size];
    //      foreach (string file in srcFiles)
    //      {
    //        ZipEntry entry = new ZipEntry(Path.GetFileName(file));// Not sure if GetFileName is needed
    //        entry.DateTime = DateTime.Now; // Why?

    //        s.PutNextEntry(entry);
    //        using (FileStream fs = File.OpenRead(file))
    //        {
    //          // using a buffer keeps a lid on memory usage
    //          int sourceBytes;
    //          do
    //          {
    //            sourceBytes = fs.Read(buffer, 0, buffer.Length);
    //            s.Write(buffer, 0, sourceBytes);
    //          } while (sourceBytes > 0);
    //        }
    //      }

    //      // the using should handle this for us
    //      s.Finish();
    //      s.Close();
    //      ret = true;
    //    }
    //  }
    //  catch (Exception e) { _error_message = e.Message; }
    //  return ret;
    //}
  }
}
