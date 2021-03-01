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

                PictureBox elementClicked = gameBoard.Get_Element(r, c);


                IsValidPosition();
                 

                //after this we need to actually set the element
                //then we need to check for if any white squares are outflanked and change them to black 


                gameBoard.Set_Element(r, c, "0");
                




                PlayerTurn();
                


            }

           else if (playerTurn != true)
            {
                r = gameBoard.Get_Row(sender);
                c = gameBoard.Get_Col(sender);

                
               
                gameBoard.Set_Element(r, c, "1");
                



                // for as long as there are items in the row which =! 1 we need to set their value to 1 until we meet another value of 1               

                PlayerTurn();

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
            PictureBox topLeft = gameBoard.Get_Element(r - 1, c - 1);



            if (topLeft.ImageLocation != imageDirectory + "0" + ".PNG") 
            {
                MessageBox.Show("Cannot be placed");
            }
           

                



            
       
            

           



                
            
        }
       

       



    }
}
