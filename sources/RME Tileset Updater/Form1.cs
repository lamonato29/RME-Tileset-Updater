
using System.Xml;
using System.Xml.Linq;
/**
 * Developed by Lamonato29
 * https://github.com/lamonato29
 */
namespace RME_Tileset_Updater
{
    public partial class Form1 : Form
    {
        private bool checkedListBoxControlMechanism = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkedListBoxCategories.Items.Clear();
            foreach (var item in Enum.GetNames(typeof(GeneralParser.URLService.Categories)))
            {
                checkedListBoxCategories.Items.Add(item, true);
            }
        }

        private void buttonSelectCheckedList_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxCategories.Items.Count; i++)
            {
                checkedListBoxCategories.SetItemChecked(i, !checkedListBoxControlMechanism);
            }
            checkedListBoxControlMechanism = !checkedListBoxControlMechanism;
        }

        private async void buttonUpdate_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string exeDirectory = System.IO.Path.GetDirectoryName(exePath);

            string dataItemsPath;
            string tilesetsPath;
            using (FolderBrowserDialog fbd = new())
            {
                MessageBox.Show(@"Select Items Folder: data\items");
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    dataItemsPath = fbd.SelectedPath;
                }
                else
                {
                    return;
                }
            }
            List<string> subcats = new();
            foreach (var checkedItem in checkedListBoxCategories.CheckedItems)
            {
                richTextBox1.AppendText($"-- Updating {checkedItem} --\n");
                Comparer comparer = new Comparer(dataItemsPath, checkedItem);
                var list = await comparer.SearchItemsIDs(); // List of all items and IDs.
                if (list != null)
                {
                    var subcategories = list.Select(c => c.Value.ToLowerInvariant()).Distinct();
                    subcats.AddRange(subcategories);
                    foreach (var subcategory in subcategories)
                    {
                        string embeddedXML = $"<materials>\n\t<tileset name=\"new_{subcategory.Replace("_", " ")}\">\n\t\t<items>\n";
                        //Create the tags to the tileset file.
                        var subList = list.Where(p => p.Value.ToLowerInvariant() == subcategory).ToList();
                        foreach (var item in subList)
                        {
                            embeddedXML = embeddedXML + $"\t\t\t<item id=\"{item.Key.Id}\"/>\n";
                        }
                        embeddedXML = embeddedXML + "\t\t</items>\n\t</tileset>\n</materials>\n";
                        var directoryPath = Path.Combine(exeDirectory, "Updated_Tilesets");
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }
                        directoryPath = Path.Combine(directoryPath, $"new_{subcategory}.xml");
                        File.WriteAllText(directoryPath, embeddedXML);
                        richTextBox1.AppendText($"-- {checkedItem} -- {subcategory} -- Succesfully Updated with {subList.Count} items!\n");

                    }

                }
                else
                    throw new ArgumentException($"Failed to get {checkedItem} items list");
            }
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("Please, copy the files in the folder Updated_Tilesets to RME's tileset folder and update your tilesets.xml file in RME Folder adding the following:");
            richTextBox1.AppendText("\n");
            string finalString = "";
            foreach (var item in subcats)
            {
                finalString = finalString + $"\t<include file=\"tilesets/new_{item}.xml\"/>\n";
            }

            richTextBox1.AppendText(finalString);
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("Finished.");


        }

        private void buttonVerifyDuplicated_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            Dictionary<int, List<string>> all = new Dictionary<int, List<string>>();
            if (MessageBox.Show("Select the RME's tilesets folder", "Verify Duplicated IDs", MessageBoxButtons.OK) == DialogResult.OK)
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        string selectedFolderPath = fbd.SelectedPath;

                        string[] xmlFiles = Directory.GetFiles(selectedFolderPath, "*.xml");

                        foreach (string xmlFile in xmlFiles)
                        {
                            var fileName = Path.GetFileName(xmlFile);
                            try
                            {
                                var xmlDoc = new XmlDocument();
                                xmlDoc.Load(xmlFile);
                                XmlNodeList itemNodes = xmlDoc.SelectNodes("//item");

                                foreach (XmlNode itemNode in itemNodes)
                                {
                                    if (itemNode.Attributes["id"] != null)
                                    {
                                        int itemId = Convert.ToInt32(itemNode.Attributes["id"].Value);

                                        if (!all.ContainsKey(itemId))
                                        {
                                            all[itemId] = new List<string>() { fileName };
                                        }
                                        else
                                        {
                                            all[itemId].Add(fileName);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error parsing XML: " + ex.Message);
                            }
                        }

                        all = all.Where(item => item.Value.Count > 1).ToDictionary(item => item.Key, item => item.Value);

                        all = all.OrderBy(item => item.Key).ToDictionary(item => item.Key, item => item.Value);

                        var countUniques = all.Keys.Distinct().Count();
                        richTextBox1.AppendText($"Number of Unique IDs: {countUniques}\n");

                        foreach (var item in all)
                        {
                            foreach (var file in item.Value)
                            {
                                richTextBox1.AppendText($"{item.Key}-{file}\n");
                            }
                        }
                    }
                }
            }
        }
    }
}