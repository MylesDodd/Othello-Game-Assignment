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
        int r;
        int c; 

        
       

      
        

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
               r = gameBoard.Get_Row(sender);
               c = gameBoard.Get_Col(sender);

                //firstly check if this is a legal move e.g. is there a black square in the 8 surrounding squares of this element. therefore psuedocode: is elementClicked next to a picturebox with the value of 0? If yes then change element if no then don't.

                IsValidPosition();
             


            }

           else if (playerTurn != true)
            {
                r = gameBoard.Get_Row(sender);
                c = gameBoard.Get_Col(sender);


                IsValidPosition();
            }


            


        }


        public void SetArrayValue() //potentially use this to search in the array for other values to set elements next to the element which has been clicked according to game logic
        {  //currently function does not work - null object reference

            if (playerTurn == true)
            {
                gameSpace[r, c] = 0;
            }

            else if (playerTurn == false)
            {
                gameSpace[r, c] = 1;
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


        public void PlayerTurn()
        {
            if (playerTurn == true)
            {
                playerTurn = false;
            }

            else if (playerTurn == false)
            {
                playerTurn = true;
            }
   
        }


        public void IsValidPosition()
        {

           

            if (playerTurn == true)
            {
                PictureBox topLeft = gameBoard.Get_Element(r - 1, c - 1);
                PictureBox topCenter = gameBoard.Get_Element(r - 1, c);
                PictureBox topRight = gameBoard.Get_Element(r - 1, c + 1);
                PictureBox left = gameBoard.Get_Element(r, c - 1);
                PictureBox right = gameBoard.Get_Element(r, c + 1);
                PictureBox bottomLeft = gameBoard.Get_Element(r + 1, c - 1);
                PictureBox bottomCenter = gameBoard.Get_Element(r + 1, c);
                PictureBox bottomRight = gameBoard.Get_Element(r + 1, c + 1);
                if (topLeft.ImageLocation == imageDirectory + "1" + ".PNG")
                {
                    gameBoard.Set_Element(r, c, "0");
                    PlayerTurn();
                }
                else if (topCenter.ImageLocation == imageDirectory + "1" + ".PNG")
                    {
                    gameBoard.Set_Element(r, c, "0");
                    PlayerTurn();
                }
                else if (topRight.ImageLocation == imageDirectory + "1" + ".PNG"){
                    gameBoard.Set_Element(r, c, "0");
                    PlayerTurn();
                }
                else if (left.ImageLocation == imageDirectory + "1" + ".PNG"){
                    gameBoard.Set_Element(r, c, "0");
                    PlayerTurn();
                }
                else if (right.ImageLocation == imageDirectory + "1" + ".PNG"){
                    gameBoard.Set_Element(r, c, "0");
                    PlayerTurn();
                }
                else if (bottomLeft.ImageLocation == imageDirectory + "1" + ".PNG"){
                    gameBoard.Set_Element(r, c, "0");
                    PlayerTurn();
                }
                else if (bottomCenter.ImageLocation == imageDirectory + "1" + ".PNG"){
                    gameBoard.Set_Element(r, c, "0");
                    PlayerTurn();
                }
                else if (bottomRight.ImageLocation == imageDirectory + "1" + ".PNG"){
                    gameBoard.Set_Element(r, c, "0");
                    PlayerTurn();
                }
                else
                {
                    MessageBox.Show("Invalid Placement of Black Counter, try again");
                }



                // error occurs here when selecting element in col 0 or col 7 because it attempts to check if there is something in the element to its left or right respectively (e.g. col -1 or col, 8) which do not exist
            }

           else if (playerTurn != true)
            {
                PictureBox topLeft = gameBoard.Get_Element(r - 1, c - 1);
                PictureBox topCenter = gameBoard.Get_Element(r - 1, c);
                PictureBox topRight = gameBoard.Get_Element(r - 1, c + 1);
                PictureBox left = gameBoard.Get_Element(r, c - 1);
                PictureBox right = gameBoard.Get_Element(r, c + 1);
                PictureBox bottomLeft = gameBoard.Get_Element(r + 1, c - 1);
                PictureBox bottomCenter = gameBoard.Get_Element(r + 1, c);
                PictureBox bottomRight = gameBoard.Get_Element(r + 1, c + 1);
                if (topLeft.ImageLocation == imageDirectory + "0" + ".PNG")
                {
                    gameBoard.Set_Element(r, c, "1");
                    PlayerTurn();
                }
                else if (topCenter.ImageLocation == imageDirectory + "0" + ".PNG")
                {
                    gameBoard.Set_Element(r, c, "1");
                    PlayerTurn();
                }
                else if (topRight.ImageLocation == imageDirectory + "0" + ".PNG")
                {
                    gameBoard.Set_Element(r, c, "1");
                    PlayerTurn();
                }
                else if (left.ImageLocation == imageDirectory + "0" + ".PNG")
                {
                    gameBoard.Set_Element(r, c, "1");
                    PlayerTurn();
                }
                else if (right.ImageLocation == imageDirectory + "0" + ".PNG")
                {
                    gameBoard.Set_Element(r, c, "1");
                    PlayerTurn();
                }
                else if (bottomLeft.ImageLocation == imageDirectory + "0" + ".PNG")
                {
                    gameBoard.Set_Element(r, c, "1");
                    PlayerTurn();
                }
                else if (bottomCenter.ImageLocation == imageDirectory + "0" + ".PNG")
                {
                    gameBoard.Set_Element(r, c, "1");
                    PlayerTurn();
                }
                else if (bottomRight.ImageLocation == imageDirectory + "0" + ".PNG")
                {
                    gameBoard.Set_Element(r, c, "1");
                    PlayerTurn();
                }
                else
                {
                    MessageBox.Show("Invalid Placement of white Counter, try again");
                }

            }
        }

        


        


        }

        
            
       

       



    }


