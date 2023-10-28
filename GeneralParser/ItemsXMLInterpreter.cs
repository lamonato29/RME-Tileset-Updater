/**
 * Developed by Lamonato29
 * https://github.com/lamonato29
 */
using System.Xml;
using System.Xml.Serialization;

namespace GeneralParser
{

    public class Item
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        public string Category { get; set; }
    }

    [XmlRoot("items")]
    public class ItemList
    {
        [XmlElement("item")]
        public List<Item> Items { get; set; }
    }

    public class ItemsXMLInterpreter
    {
        private string filePath;

        public ItemsXMLInterpreter(string filePath)
        {
            this.filePath = filePath;
        }

        public ItemList GetItemsXMLContent()
        {
            try
            {
                var serializer = new XmlSerializer(typeof(ItemList));

                using (var reader = new StreamReader(filePath))
                {
                    return (ItemList)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing XML: {ex.Message}");
                return null;
            }
        }
    }
}