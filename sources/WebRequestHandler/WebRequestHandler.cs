/**
 * Developed by Lamonato29
 * https://github.com/lamonato29
 */
using HtmlAgilityPack;

namespace WebRequestHandler
{
    public class WebRequestHandler
    {
        public WebRequestHandler()
        {
        }

        public async Task<List<string>?> GetFirstColumnContents(string url)
        {
            List<string> ret = new();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string htmlContent = await response.Content.ReadAsStringAsync();

                        var htmlDocument = new HtmlDocument();
                        htmlDocument.LoadHtml(htmlContent);


                        var firstTable = htmlDocument.DocumentNode.SelectSingleNode("//table[contains(@class, 'wikitable')]");

                        if (firstTable != null)
                        {
                            foreach (var row in firstTable.SelectNodes(".//tr"))
                            {
                                var firstColumn = row.SelectSingleNode(".//td");
                                if (firstColumn != null)
                                {
                                    ret.Add(firstColumn.InnerText.Trim().ToLower());
                                }
                            }
                            return ret;
                        }
                        else
                        {
                            Console.WriteLine("No table found on the webpage.");
                            return null;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Failed to retrieve the webpage. Status code: " + response.StatusCode);
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    return null;
                }
            }

        }
    }
}