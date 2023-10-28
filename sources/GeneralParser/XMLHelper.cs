/**
 * Developed by Lamonato29
 * https://github.com/lamonato29
 */
namespace GeneralParser
{
    public static class XMLHelper
    {
        public static T ParseXmlString<T>(string xmlString) where T : class
        {
            try
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

                using (var reader = new StringReader(xmlString))
                {
                    return (T)serializer.Deserialize(reader);
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
