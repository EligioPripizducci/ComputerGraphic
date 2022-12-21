using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompGraph
{
    public partial class Trimetria : Form
    {
        public int Phi_corner;
        public int Tetta_corner;
        public double viewer;
        public Trimetria()
        {
            InitializeComponent();
        }

        private void Build_Click(object sender, EventArgs e)
        {
            if (phi_tb.Text != "")
            {
                if (!(int.TryParse(phi_tb.Text, out Phi_corner)))
                {
                    MessageBox.Show("Ошибка ввода параметра φ!", "Ошибка");
                }               
            }
            else
            {
                MessageBox.Show("Введите значение φ!", "Ошибка");
            }

            if (tetta_tb.Text != "")
            {
                if (!(int.TryParse(tetta_tb.Text, out Tetta_corner)))
                {
                    MessageBox.Show("Ошибка ввода параметра θ!", "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Введите значение θ!", "Ошибка");
            }

            if (Zc_tb.Text != "")
            {
                if (!(double.TryParse(Zc_tb.Text, out viewer)))
                {
                    MessageBox.Show("Ошибка ввода параметра Zc!", "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Введите значение Zc!", "Ошибка");
            }
            this.Close();
        }
    }
}
