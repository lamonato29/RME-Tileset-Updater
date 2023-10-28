/**
 * Developed by Lamonato29
 * https://github.com/lamonato29
 */
using GeneralParser;

namespace RME_Tileset_Updater
{
    public class Comparer
    {
        private string? itemsFolderPath;
        private string? tileSetsFolderPath;
        private object? checkedCategory;
        public Comparer(string itemsFolderPath, object checkedCategory)
        {
            this.checkedCategory = checkedCategory;
            this.itemsFolderPath = itemsFolderPath;

            if (itemsFolderPath == null)
            {
                return;
            }
          
        }
        public async Task<Dictionary<Item, string>?> SearchItemsIDs()
        { 
            ItemsXMLInterpreter itemsXMLInterpreter = new ItemsXMLInterpreter(Path.Combine(itemsFolderPath,"items.xml"));
            var listItemsXML = itemsXMLInterpreter.GetItemsXMLContent();

            var listTibiaWikia = new Dictionary<Item, string>();

            if (Enum.IsDefined(typeof(URLService.Categories), checkedCategory))
            {
                var list = URLService.GetCategoryLinks(checkedCategory.ToString());
                foreach (var link in list)
                {
                    int tryCount = 0;
                    try
                    {
                        WebRequestHandler.WebRequestHandler webRequestHandler = new WebRequestHandler.WebRequestHandler();
                    tryAgain:;
                        var contents = await webRequestHandler.GetFirstColumnContents(link.Key);
                        if (contents == null && tryCount < 3)
                        {
                            tryCount++;
                            goto tryAgain;
                        }
                        foreach (var item in contents)
                        {
                            var itemCorresp = listItemsXML.Items.Where(i => i.Name == item);
                            foreach (var itt in itemCorresp)
                            {
                                Item it = new Item()
                                {
                                    Name = itt.Name,
                                    Id = itt.Id,
                                    Category = link.Value
                                };
                                if(it.Id > 0)
                                listTibiaWikia.Add(it, link.Value);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
                return listTibiaWikia;
            }
            return null;
        }

    }
}
