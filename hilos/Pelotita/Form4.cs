using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Pelotita
{
    public partial class Form4 : Form
    {
        Thread _miHilo;
        //int _contador;
        List<Thread> _hilos;

        public Form4()
        {
            InitializeComponent();

            this.btnPausar.Click += new EventHandler(this.PausarPelotita);
            this.btnDestruir.Click += new EventHandler(this.DestruirPelotita);
            this.btnReanudar.Click += new EventHandler(this.ReanudarPelotita);
            //this._contador = 0;

            _hilos = new List<Thread>();
        }


        private void btnCrear_Click_1(object sender, EventArgs e)
        {
            Pelotita_Con_Thread.Pelotita Pelotita = new Pelotita_Con_Thread.Pelotita(this.pictureBox1);

            //El hilo se lo puede destruir y no se tilda como pasaba con el while true.
            this._miHilo = new Thread(Pelotita.DoWork); //Como parametro va el nombre del metodo que vamos a correr, no el metodo en si mismo

            this._hilos.Add(this._miHilo);

            this._miHilo.Start();

            //this._contador++;
            //this.label1.Text = this._contador.ToString();
            this.label1.Text = this._hilos.Count.ToString();

            //this.btnCrear.Click -= new System.EventHandler(this.btnCrear_Click);
        }

        private void PausarPelotita(object sender, EventArgs e)
        {
            
            try
            {
                //MessageBox.Show("Hola");
                //this._miHilo.Resume();
                //this._miHilo.Suspend();
              
                this._hilos[this._hilos.Count - 1].Suspend();
            }
            catch (Exception)
            {
                
                
            }
        }

        private void ReanudarPelotita(object sender, EventArgs e)
        {
            try
            {
                //this._miHilo.Resume();
                this._hilos[this._hilos.Count - 1].Resume();
            }
            catch (Exception)
            {
                
               
            }
            
        }

        private void DestruirPelotita(object sender, EventArgs e)
        {
            try
            {
                //this._miHilo.Abort();
                this._hilos[this._hilos.Count - 1].Abort();

                Graphics g = this.pictureBox1.CreateGraphics();
                g.Clear(this.pictureBox1.BackColor);
            }
            catch (Exception)
            {
                
            }
            

        }

        
    }
}
