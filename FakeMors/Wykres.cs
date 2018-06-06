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
        short[] data;
        

        /// <summary>
        /// kurwa chuj
        /// </summary>
        /// <param name="arr"></param>
        public Wykres(short[] arr)
        {
            //data = arr;
            InitializeComponent();
            
            chart1.Series.Add("Wykres");
            for (int i = 0; i < arr.Length; i++)
            {
                chart1.Series[0].Points.AddY(arr[i]);
            }
            
   
        }
    }
}
