using APICalle.pizzasXML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APICalle
{
    public partial class Form1 : Form
    {

        configReader Config { get; set; }

        LecturaXMLPizza readXML { get; set; }
        public Form1()
        {
            InitializeComponent();

            Config= new configReader();
           readXML= new LecturaXMLPizza();
            ItemsReadedPizza items = readXML.LecturaXML_Deserialize(Config.rutapizza);

            TreeNode nodo = new TreeNode("pizzas");
            treeView1.Nodes.Add(nodo);

            int mostrarNodo = 0;

            foreach (var pizza in items.Pizzas)
            {
                TreeNode pizzaNode = new TreeNode(pizza.nombre);
                TreeNode pizzaPrecio= new TreeNode(" -Precio: " + pizza.precio.ToString() + "€");

                nodo.Nodes.Add(pizzaNode);
                nodo.Nodes[mostrarNodo].Nodes.Add(pizzaPrecio);
                

                foreach (var ingrediente in pizza.ingredientes)
                {
                    TreeNode ingredienteNode = new TreeNode(ingrediente.nombre);
                    nodo.Nodes[mostrarNodo].Nodes.Add(ingredienteNode);
                }

                mostrarNodo++;
            }




        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            //new LecturaXML().LecturaXML_Nodes(Config.ruta);
            new LecturaXMLPizza().LecturaXML_Nodes(Config.rutapizza);
            

        }
    }
}
