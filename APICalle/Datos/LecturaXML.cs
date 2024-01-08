﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace APICalle
{
    public class LecturaXML
    {

        public void  LecturaXML_Nodes(string filepath) {

            string text = string.Empty;
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {

                text += node.InnerText;

            }
            MessageBox.Show(text);


        }

        public ItemsReaded LecturaXML_Deserialize(string filepath)
        {
            ItemsReaded i = new ItemsReaded();
            var serializer= new XmlSerializer(typeof(ItemsReaded));
            using (Stream reader = new FileStream(filepath, FileMode.Open))
            {
                i= serializer.Deserialize(reader) as ItemsReaded;
            }
            return i;
        }



    }
}
