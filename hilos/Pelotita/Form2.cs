using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;



namespace Pelotita
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Pelotita_Sin_Thread.Pelotita nuevaPelotita = new Pelotita_Sin_Thread.Pelotita(this.pictureBox1);

            //nuevaPelotita.DoWork();

            Pelotita_Con_Thread.Pelotita Pelotita = new Pelotita_Con_Thread.Pelotita(this.pictureBox1);

            Thread nuevoHilo = new Thread(Pelotita.DoWork); //El hilo se lo puede destruir y no se tilda como pasaba con el while true.

            nuevoHilo.Start();
        }
    }
}
