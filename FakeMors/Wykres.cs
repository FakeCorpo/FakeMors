using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakeMors
{
    public partial class Wykres : Form
    {
        short[] arr;
        public Wykres(short[] arr)
        {
            InitializeComponent();
            this.arr = arr;
            chart1.Series.Add("Wykres");
            foreach (var item in arr)
            {
                chart1.Series[0].Points.Add(item);
            }      
        }
    }
}
