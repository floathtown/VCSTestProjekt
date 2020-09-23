using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Serialisierung
{
    class Program
    {
        static void Main(string[] args)
        {
            //XDocument doc = XDocument.Parse("<root><A>Irgendein Text</A><B name=\"BBB\"/></root>"); //or XDocument.Load(path)
            //string jsonText = JsonConvert.SerializeXNode(doc);
            //dynamic dyn = JsonConvert.DeserializeObject<ExpandoObject>(jsonText);
            //var text = dyn.root.B("@name");
            MetaDataItem[] metaDataItems = new MetaDataItem[2];
            //metaDataItems[0] = new MetaDataItem();
            //metaDataItems[0].Name = "Fall.ZustaendigerSachbearbeiter.Vorname3";
            //metaDataItems[0].Value = "Mustermann";

            //metaDataItems[1] = new MetaDataItem();
            //metaDataItems[1].Name = "Dokument.Druck.Sachbearbeiter.Vorname3";
            //metaDataItems[1].Value = "Mustermann2";

            var firstnameItemNames = new List<string>() { "Vorgang.Sachbearbeiter.Vorname", "Fall.ZustaendigerSachbearbeiter.Vorname", "Dokument.Druck.Sachbearbeiter.Vorname" };
            var value = FindItemValue(metaDataItems,firstnameItemNames.Find(f => FindItemValue(metaDataItems, f) != ""));
            //string name = Array.Find(metaDataItems, f => f.Name.Equals("Name"))?.Value ?? "";
            //Console.WriteLine(name);

        }

        private static string FindItemValue(MetaDataItem[] metaDataItems, string name)
        {
            if (string.IsNullOrWhiteSpace(name)) { return ""; }
            return Array.Find(metaDataItems, f => f.Name.Equals(name))?.Value ?? "";
        }
    }

    public class MetaDataItem
    {
        public string Name;
        public string Value;
    }
}
