using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Othello_Game_Assignment
{
    public partial class aboutForm : Form
    {
        public aboutForm()
        {
            InitializeComponent();
        }

        private void closeAboutButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
