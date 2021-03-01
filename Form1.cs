using System;
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
        string player1;
        string player2;


      
        

        public Form1()
        {

            InitializeComponent();

        }

        private void startNewGame_Click(object sender, EventArgs e)
        {

            if (player1 == "" || player2 == "")
            {
                MessageBox.Show("Please set the player names");
            }

            else
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


            





        }


        private void Which_Element_Clicked(object sender, EventArgs e)
        {
            //get the row and column, pass that into get element then set the element 


            int r = gameBoard.Get_Row(sender);
            int c = gameBoard.Get_Col(sender);
            gameBoard.Set_Element(r, c, "0");

        }

        private void player1TextBox_TextChanged(object sender, EventArgs e)
        {
            
            TextBox player1TextBox = (TextBox)sender;
            player1 = player1TextBox.Text;
            
        }



        private void player2TextBox_TextChanged(object sender, EventArgs e)
        {

            TextBox player2TextBox = (TextBox)sender;
            player2 = player2TextBox.Text;

        }
    }
}
