using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MathParserNetDemo
{
    public partial class MathParserNetAboutBox : Form
    {
        public MathParserNetAboutBox()
        {
            InitializeComponent();
        }

        private void MathParserNetAboutBoxLoad(object sender, EventArgs e)
        {
            wbPacman.DocumentText = Strings.Pacman;
        }

        private void Button1Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
