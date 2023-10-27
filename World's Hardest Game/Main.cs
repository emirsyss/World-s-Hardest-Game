using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace World_s_Hardest_Game
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        public int characterSpeed = 3;
        public int barrierSpeed = 7;

        public int score = 0;

        public int gameInterval = 1000 / 60;

        List<Guna.UI2.WinForms.Guna2CircleButton> leftbarriers = new List<Guna.UI2.WinForms.Guna2CircleButton>();
        List<Guna.UI2.WinForms.Guna2CircleButton> rightbarriers = new List<Guna.UI2.WinForms.Guna2CircleButton>();


        private void gameScreen_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            leftbarriers.Add(leftbarrier1);
            leftbarriers.Add(leftbarrier2);
            leftbarriers.Add(leftbarrier3);

            rightbarriers.Add(rightbarrier1);
            rightbarriers.Add(rightbarrier2);

            GameTimer.Enabled = true;
            GameTimer.Interval = gameInterval;


        }
        public bool IsCharacterDead()
        {
            foreach (Control x in gameScreen.Controls)
            {
                if (x is Guna.UI2.WinForms.Guna2CircleButton) // Kontrolün bir Panel olup olmadığını kontrol etmek için
                {
                    Guna.UI2.WinForms.Guna2CircleButton barrier = (Guna.UI2.WinForms.Guna2CircleButton)x;

                    if (barrier.Tag != null && barrier.Tag.ToString() == "barrier")
                    {
                        if (character.Bounds.IntersectsWith(barrier.Bounds))
                        {
                            return true;
                        }
                    }
                }

            }
            return false;
        }
        public bool IsCharacterCollidingWithWall(string direction)
        {
            if (direction == "up")
            {
                foreach (Control x in gameScreen.Controls)
                {
                    if (x is Panel) // Kontrolün bir Panel olup olmadığını kontrol etmek için
                    {
                        Panel wallPanel = (Panel)x;

                        if (wallPanel.Tag != null && wallPanel.Tag.ToString() == "upwall")
                        {
                            if (character.Bounds.IntersectsWith(wallPanel.Bounds))
                            {
                                return false;
                            }
                        }
                    }

                }
            }
            if (direction == "down")
            {
                foreach (Control x in gameScreen.Controls)
                {
                    if (x is Panel) // Kontrolün bir Panel olup olmadığını kontrol etmek için
                    {
                        Panel wallPanel = (Panel)x;

                        if (wallPanel.Tag != null && wallPanel.Tag.ToString() == "downwall")
                        {
                            if (character.Bounds.IntersectsWith(wallPanel.Bounds))
                            {
                                return false;
                            }
                        }
                    }

                }
            }
            if (direction == "left")
            {
                foreach (Control x in gameScreen.Controls)
                {
                    if (x is Panel) // Kontrolün bir Panel olup olmadığını kontrol etmek için
                    {
                        Panel wallPanel = (Panel)x;

                        if (wallPanel.Tag != null && wallPanel.Tag.ToString() == "leftwall")
                        {
                            if (character.Bounds.IntersectsWith(wallPanel.Bounds))
                            {
                                return false;
                            }
                        }
                    }

                }
            }
            if (direction == "right")
            {
                foreach (Control x in gameScreen.Controls)
                {
                    if (x is Panel) // Kontrolün bir Panel olup olmadığını kontrol etmek için
                    {
                        Panel wallPanel = (Panel)x;

                        if (wallPanel.Tag != null && wallPanel.Tag.ToString() == "rightwall")
                        {
                            if (character.Bounds.IntersectsWith(wallPanel.Bounds))
                            {
                                return false;
                            }
                        }
                    }

                }
            }
            return true;
           
        }
        void CharacterMovement(string direction)
        {
            if (direction == "up")
            {
                
                character.Top -= characterSpeed;
            }
            if (direction == "down")
            {
                character.Top += characterSpeed;

            }
            if (direction == "right")
            {
                character.Left += characterSpeed;

            }
            if (direction == "left")
            {
                character.Left -= characterSpeed;
            }
        }
        bool goUp, goLeft, goRight, goDown;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                goLeft = true;
             
            }
          
            if (keyData == Keys.Right)
            {
                goRight = true;
      
            }
           
            if (keyData == Keys.Up)
            {
                 goUp = true;
             
            }
       
            if (keyData == Keys.Down)
            {
                goDown = true;
  
            }
         
            if (keyData == Keys.W)
            {
                goUp = true;
              
            }
            
            if (keyData == Keys.S)
            {
                goDown = true;
                
            }
            
            if (keyData == Keys.A)
            {
                goLeft = true;
               
            }
              
            if (keyData == Keys.D)
            {
                goRight = true;
          
            }
          
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
          
        }
        bool[] leftbarrierMovementPerrmission = { true,  true, true};
        bool[] rightbarrierMovementPerrmission = { true, true };

        public void LeftBarriersMovement()
        {
            for (int i = 0; i < leftbarriers.Count; i++)
            {
                try
                {
                    if (leftbarriers[i].Location.X >= 527)
                    {
                        leftbarrierMovementPerrmission[i] = false;
                    }
                    else if (leftbarriers[i].Location.X <= 220)
                    {
                        leftbarrierMovementPerrmission[i] = true;
                    }
                    
                   
                    if (leftbarrierMovementPerrmission[i] == true)
                    {
                        leftbarriers[i].Left += barrierSpeed;
                    }
                    else
                    {
                        leftbarriers[i].Left -= barrierSpeed;
                    }
                }
                catch
                {

                }
            }
        }

        public void CharacterMoves()
        {
            if (goUp)
            {
                bool cakismakontrol = IsCharacterCollidingWithWall("up");
                if (cakismakontrol == true)
                {
                    CharacterMovement("up");

                }
                
            }
            if (goDown)
            {
                bool cakismakontrol = IsCharacterCollidingWithWall("down");
                if (cakismakontrol == true)
                {
                    CharacterMovement("down");

                }
               
            }
            if (goRight)
            {
                bool cakismakontrol = IsCharacterCollidingWithWall("right");
                if (cakismakontrol == true)
                {
                    CharacterMovement("right");

                }
                
            }
            if (goLeft)
            {
                bool cakismakontrol = IsCharacterCollidingWithWall("left");
                if (cakismakontrol == true)
                {
                    CharacterMovement("left");

                }
               
            }
        }

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {

                goUp = false;
            }
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {

                goDown = false;
            }
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                goRight = false;

            }
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                goLeft = false;

            }
        }

        public void RightBarriesMovement()
        {
            for (int i = 0; i < rightbarriers.Count; i++)
            {
                try
                {
                    if (rightbarriers[i].Location.X >= 527)
                    {
                        rightbarrierMovementPerrmission[i] = false;
                    }
                    else if (rightbarriers[i].Location.X <= 220)
                    {
                        rightbarrierMovementPerrmission[i] = true;
                    }


                    if (rightbarrierMovementPerrmission[i] == true)
                    {
                        rightbarriers[i].Left += barrierSpeed;
                    }
                    else
                    {
                        rightbarriers[i].Left -= barrierSpeed;
                    }
                }
                catch
                {

                }
            }
        }

        public void Update()
        {
            LeftBarriersMovement();
            RightBarriesMovement();
            CharacterMoves();
            bool characterdeadcontrol = IsCharacterDead();
            if (characterdeadcontrol)
            {
                Restart();
            }
        }
        public void Restart()
        {
            score = 0;
            character.Location = new Point(84, 119);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {

            Update();
        }
    }
}
