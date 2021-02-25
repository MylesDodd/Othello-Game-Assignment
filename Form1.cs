﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUIImageArray;

namespace Othello_Game_Assignment
{
    public partial class Form1 : Form
    {
        string imageDirectory = Directory.GetCurrentDirectory() + "\\images\\";
        int[,] gameSpace;
        GImageArray gameBoard;
        public Form1()
        {

            InitializeComponent();

        }

        private void startNewGame_Click(object sender, EventArgs e)
        {
            
            int[,] gameSpace = new int[8, 8]
            {{10,10,10,10,10,10,10,10 },
            { 10,10,10,10,10,10,10,10 },
            { 10,10,10,10,10,10,10,10 },
            { 10,10,10,0,1,10,10,10 },
            { 10,10,10,1,0,10,10,10 },
            { 10,10,10,10,10,10,10,10 },
            { 10,10,10,10,10,10,10,10 },
            { 10,10,10,10,10,10,10,10}};
            gameBoard = new GImageArray(this, gameSpace, 50, 50, 50, 50, 0, imageDirectory);


            gameBoard.Which_Element_Clicked += new GImageArray.ImageClickedEventHandler(Which_Element_Clicked);


        }


        private void Which_Element_Clicked(object sender, EventArgs e)
        {
            MessageBox.Show("This box was clicked");
        }

















    }
}
