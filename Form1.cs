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
        bool playerTurn = true;

        
       

      
        

        public Form1()
        {

            InitializeComponent();

        }

        private void startNewGame_Click(object sender, EventArgs e)
        {




            if (player1TextBox.Text == "" || player2TextBox.Text == "" )
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


        public void Which_Element_Clicked(object sender, EventArgs e)
        {

           

            


            if (playerTurn == true)
            {
                int r = gameBoard.Get_Row(sender);
                int c = gameBoard.Get_Col(sender);
                gameBoard.Set_Element(r, c, "0");
                playerTurn = false;
            }

           else if (playerTurn != true)
            {
                int r = gameBoard.Get_Row(sender);
                int c = gameBoard.Get_Col(sender);
                gameBoard.Set_Element(r, c, "1");

                playerTurn = true;

            }



            

        }

        public void player1TextBox_TextChanged(object sender, EventArgs e)
        {
 
            TextBox player1TextBox = (TextBox)sender;
            Convert.ToString(player1TextBox.Text);
            player1 = player1TextBox.Text;

        }



        public void player2TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox player2TextBox = (TextBox)sender;
            Convert.ToString(player2TextBox.Text);
            player2 = player2TextBox.Text;
            
        }



    }
}
