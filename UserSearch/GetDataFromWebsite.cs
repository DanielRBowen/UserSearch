using System.Net;

public static class GetDataFromWebsite
{
    public static byte[] GetContentFromSiteURL(string url)
    {
        using (var client = new WebClient())
        {
            var content = client.DownloadData(url);
            return content;
        }
    }
}
