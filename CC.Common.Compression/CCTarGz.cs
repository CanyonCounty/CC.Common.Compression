using System;
using System.IO;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.GZip;

// http://wiki.sharpdevelop.net/GZip-and-Tar-Samples.ashx
namespace CC.Common.Compression
{
  public class CCTarGz
  {
    public void ExtractTGZ(String gzArchiveName, String destFolder)
    {
      Stream inStream = File.OpenRead(gzArchiveName);
      Stream gzipStream = new GZipInputStream(inStream);

      TarArchive tarArchive = TarArchive.CreateInputTarArchive(gzipStream);
      tarArchive.ExtractContents(destFolder);
      tarArchive.Close();

      gzipStream.Close();
      inStream.Close();
    }
  }
}
