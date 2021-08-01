using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mchw02
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Bitmap newbmp;
        int[,] img;
        int[,] img1;
        int[,] img2;
        public Form1()
        {
            InitializeComponent();
        }

        private void oPENIMG01ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Bmp File(*.bmp)|*.bmp|jpg File(*.jpg)|*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bmp = new Bitmap(openFileDialog1.FileName);                //圖片像素資料存於變數bmp
                pictureBox1.Image = bmp;                                   //顯示於pictureBox1.
                img1 = BmpToAry.Transfer(bmp);                         //將相速資料置入test.BmpToAry.Transfer函式，輸出陣列img1            
            }
        }

        private void oPENIMG02ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Bmp File(*.bmp)|*.bmp|jpg File(*.jpg)|*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bmp = new Bitmap(openFileDialog1.FileName);                //圖片像素資料存於變數bmp
                pictureBox2.Image = bmp;                                   //顯示於pictureBox2.
                img2 = BmpToAry.Transfer(bmp);                         //將相速資料置入test.BmpToAry.Transfer函式，輸出陣列img2            
            }
        }

        private void sAVEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                newbmp.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);   //圖檔newbmp輸出
            }
        }

        private void fullSearchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            int HEIGHT = img1.GetLength(0);
            int WIDTH = img1.GetLength(1);
            int T = 0;
            int R = 0;
            int rs = 0;
            
            for (int i = 0; i < HEIGHT ; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    int min = 9999;
                     for (int x = 0; x < 5; x++)
                     {
                         for (int y = 0; y < 5; y++)
                         {
                             for (int n1 = -25; n1 < 25; n1++)
                             {
                                 for (int n2 = 0; n2 < 90; n2++)
                                 {
                                     if ((i + x + n1 >= 0) && (i + x + n1 < 384) && (j + y + n2 >= 0) && (j + y + n2 < 512) && (i + x >= 0) && (i + x < 384) && (j + y >= 0) && (j + y < 512))
                                     {
                                         T = img1[i + x, j + y];
                                         R = img2[i + x + n1, j + y + n2];
                                         rs = Math.Abs(T - R);
                                         int su = rs;
                                         if (min > su)
                                         {
                                             min = su;
                                         }
                                         img1[i + x, j + y] = img2[i + x + n1, j + y + n2] - img2[i, j];
                                     }
                                 }
                             }
                             
                         }
                     }
                   
                    //img1[i, j] = img1[i, j];
                }
                
            }
            newbmp = BmpToAry.Invert(img1);
            pictureBox3.Image = newbmp;
        }
    }
}
