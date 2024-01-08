using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace APICalle.pizzasXML
{
    internal class LecturaXMLPizza
    {


        public void LecturaXML_Nodes(string filepath)
        {

            string testpizza = string.Empty;
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {

                testpizza += node.InnerText;

            }
            MessageBox.Show(testpizza);


        }


        public ItemsReadedPizza LecturaXML_Deserialize(string filepath)
        {
            ItemsReadedPizza i = new ItemsReadedPizza();
            var serializer = new XmlSerializer(typeof(ItemsReadedPizza));
            using (Stream reader = new FileStream(filepath, FileMode.Open))
            {
                i = serializer.Deserialize(reader) as ItemsReadedPizza;
            }
            return i;
        }
    }
}
