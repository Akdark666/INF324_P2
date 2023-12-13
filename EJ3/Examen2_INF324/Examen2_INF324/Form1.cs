using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Examen2_INF324
{
    public partial class Form1 : Form
    {

        Bitmap bmp;
        int x, y;
        int mR, mG, mB;
        int cont = 0;
        int red = 0;
        int green = 0;
        int blue = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Todos|*.*|Archivos JPEG|*.jpg|Archivos GIF|*.gif";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bmp = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = bmp;
                cont = 0;

                button6.Visible = true;
                button2.Visible = true;


                ELIMINAR();
                TEXTURA();
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Debe Cargar una Imagen!!.", "ERROR", MessageBoxButtons.OK);
            }
            else
            {
                
                x = e.X;
                y = e.Y;
                textBox5.Text = x.ToString();
                textBox4.Text = y.ToString();


                Color c = new Color();
                c = bmp.GetPixel(x, y);
                mR = 0;
                mG = 0;
                mB = 0;

                for (int i = x; i < x + 10; i++)
                {
                    for (int j = y; j < y + 10; j++)
                    {
                        c = bmp.GetPixel(i, j);
                        mR = mR + c.R;
                        mG = mG + c.G;
                        mB = mB + c.B;
                    }
                }
                mR = mR / 100;
                mG = mG / 100;
                mB = mB / 100;
                textBox1.Text = c.R.ToString();
                textBox2.Text = c.G.ToString();
                textBox3.Text = c.B.ToString();

                if (cont < 3)
                {
                    INSERT("Selec: " + cont, c.R.ToString(), c.G.ToString(), c.B.ToString());
                    cont++;
                    TEXTURA();
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Debe Cargar una Imagen!!.", "ERROR", MessageBoxButtons.OK);
            }
            else
            {
                int mRn = 0, mGn = 0, mBn = 0;
                Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
                Color c = new Color();
                for (int i = 0; i < bmp.Width - 10; i = i + 10)
                    for (int j = 0; j < bmp.Height - 10; j = j + 10)
                    {

                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                c = bmp.GetPixel(i2, j2);
                                mRn = mRn + c.R;
                                mGn = mGn + c.G;
                                mBn = mBn + c.B;
                            }
                        mRn = mRn / 100;
                        mGn = mGn / 100;
                        mBn = mBn / 100;

                        if (((mR - 10 <= mRn) && (mRn <= mR + 10)) &&
                            ((mG - 10 <= mGn) && (mGn <= mG + 10)) &&
                            ((mB - 10 <= mBn) && (mBn <= mB + 10)))
                        {
                            for (int i2 = i; i2 < i + 10; i2++)
                                for (int j2 = j; j2 < j + 10; j2++)
                                {
                                    bmp2.SetPixel(i2, j2, Color.Red);
                                }
                        }
                        else
                        {
                            for (int i2 = i; i2 < i + 10; i2++)
                                for (int j2 = j; j2 < j + 10; j2++)
                                {
                                    c = bmp.GetPixel(i2, j2);
                                    bmp2.SetPixel(i2, j2, Color.FromArgb(c.R, c.G, c.B));
                                }
                        }


                    }
                pictureBox1.Image = bmp2;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Debe Cargar una Imagen!!.", "ERROR", MessageBoxButtons.OK);
            }
            else
            {
                int mRn = 0, mGn = 0, mBn = 0;
                Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
                Color c = new Color();
                for (int i = 0; i < bmp.Width - 10; i = i + 10)
                    for (int j = 0; j < bmp.Height - 10; j = j + 10)
                    {

                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                c = bmp.GetPixel(i2, j2);
                                mRn = mRn + c.R;
                                mGn = mGn + c.G;
                                mBn = mBn + c.B;
                            }
                        mRn = mRn / 100;
                        mGn = mGn / 100;
                        mBn = mBn / 100;

                        if (((mR - 10 <= mRn) && (mRn <= mR + 10)) &&
                            ((mG - 10 <= mGn) && (mGn <= mG + 10)) &&
                            ((mB - 10 <= mBn) && (mBn <= mB + 10)))
                        {
                            for (int i2 = i; i2 < i + 10; i2++)
                                for (int j2 = j; j2 < j + 10; j2++)
                                {
                                    bmp2.SetPixel(i2, j2, Color.Blue);
                                }
                        }
                        else
                        {
                            for (int i2 = i; i2 < i + 10; i2++)
                                for (int j2 = j; j2 < j + 10; j2++)
                                {
                                    c = bmp.GetPixel(i2, j2);
                                    bmp2.SetPixel(i2, j2, Color.FromArgb(c.R, c.G, c.B));
                                }
                        }


                    }
                pictureBox1.Image = bmp2;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Debe Cargar una Imagen!!.", "ERROR", MessageBoxButtons.OK);
            }
            else
            {
                int mRn = 0, mGn = 0, mBn = 0;
                Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
                Color c = new Color();
                for (int i = 0; i < bmp.Width - 10; i = i + 10)
                    for (int j = 0; j < bmp.Height - 10; j = j + 10)
                    {

                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                c = bmp.GetPixel(i2, j2);
                                mRn = mRn + c.R;
                                mGn = mGn + c.G;
                                mBn = mBn + c.B;
                            }
                        mRn = mRn / 100;
                        mGn = mGn / 100;
                        mBn = mBn / 100;

                        if (((mR - 10 <= mRn) && (mRn <= mR + 10)) &&
                            ((mG - 10 <= mGn) && (mGn <= mG + 10)) &&
                            ((mB - 10 <= mBn) && (mBn <= mB + 10)))
                        {
                            for (int i2 = i; i2 < i + 10; i2++)
                                for (int j2 = j; j2 < j + 10; j2++)
                                {
                                    bmp2.SetPixel(i2, j2, Color.White);
                                }
                        }
                        else
                        {
                            for (int i2 = i; i2 < i + 10; i2++)
                                for (int j2 = j; j2 < j + 10; j2++)
                                {
                                    c = bmp.GetPixel(i2, j2);
                                    bmp2.SetPixel(i2, j2, Color.FromArgb(c.R, c.G, c.B));
                                }
                        }


                    }
                pictureBox1.Image = bmp2;
            }
        }
        public void TEXTURA()
        {
            SqlConnection con = new SqlConnection();
            //con.ConnectionString = "server=(local);database=ImgTextura;user=examen324;pwd=123456";
            con.ConnectionString = "Data Source=IVAN_PC\\SQLEXPRESS;Initial Catalog=EX2_P3;Integrated Security=True";


            SqlDataAdapter ada = new SqlDataAdapter();
            ada.SelectCommand = new SqlCommand();
            ada.SelectCommand.Connection = con;
            ada.SelectCommand.CommandText = "SELECT * FROM textura";
            ada.SelectCommand.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            ada.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        public void ELIMINAR()
        {
            SqlConnection con = new SqlConnection();
            //con.ConnectionString = "server=(local);database=ImgTextura;user=examen324;pwd=123456";
            con.ConnectionString = "Data Source=IVAN_PC\\SQLEXPRESS;Initial Catalog=EX2_P3;Integrated Security=True";


            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM textura";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void INSERT(string idTextura, string cR, string cG, string cB)
        {

            SqlConnection con = new SqlConnection();
            //con.ConnectionString = "server=(local);database=EX2_P3;user=IVAN_PC\SQLEXPRESS;pwd=Ivan";
            con.ConnectionString = "Data Source=IVAN_PC\\SQLEXPRESS;Initial Catalog=EX2_P3;Integrated Security=True";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = string.Format("INSERT INTO textura values ('{0}','{1}','{2}','{3}')", idTextura, cR, cG, cB);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            cont = 0;
            ELIMINAR();
            TEXTURA();
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = bmp;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cont == 3)
            {
                int cPos = 0;
                int[] ccR = new int[3];
                int[] ccG = new int[3];
                int[] ccB = new int[3];

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        ccR[cPos] = Int32.Parse(row.Cells["cR"].Value.ToString());
                        ccG[cPos] = Int32.Parse(row.Cells["cG"].Value.ToString());
                        ccB[cPos] = Int32.Parse(row.Cells["cB"].Value.ToString());
                        cPos++;
                    }
                }

                int mRn = 0, mGn = 0, mBn = 0;
                Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
                Color c = new Color();
                for (int i = 0; i < bmp.Width - 10; i = i + 10)
                    for (int j = 0; j < bmp.Height - 10; j = j + 10)
                    {
                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                c = bmp.GetPixel(i2, j2);
                                mRn = mRn + c.R;
                                mGn = mGn + c.G;
                                mBn = mBn + c.B;
                            }
                        mRn = mRn / 100;
                        mGn = mGn / 100;
                        mBn = mBn / 100;

                        if (((ccR[0] - 10 <= mRn) && (mRn <= ccR[0] + 10)) &&
                            ((ccG[0] - 10 <= mGn) && (mGn <= ccG[0] + 10)) &&
                            ((ccB[0] - 10 <= mBn) && (mBn <= ccB[0] + 10)))
                        {
                            for (int i2 = i; i2 < i + 10; i2++)
                                for (int j2 = j; j2 < j + 10; j2++)
                                {
                                    red = int.Parse(txtR1.Text);
                                    green = int.Parse(txtG1.Text);
                                    blue = int.Parse(txtB1.Text);

                                    // Asegurarse de que los valores están en el rango correcto (0-255)
                                    red = Math.Max(0, Math.Min(255, red));
                                    green = Math.Max(0, Math.Min(255, green));
                                    blue = Math.Max(0, Math.Min(255, blue));

                                    // Crear un nuevo color con los valores proporcionados
                                    Color newColor = Color.FromArgb(red, green, blue);

                                    // Establecer el nuevo color en el píxel (i2, j2) del objeto Bitmap (bmp2)
                                    bmp2.SetPixel(i2, j2, newColor);
                                }
                        }
                        else if (((ccR[1] - 10 <= mRn) && (mRn <= ccR[1] + 10)) &&
                            ((ccG[1] - 10 <= mGn) && (mGn <= ccG[1] + 10)) &&
                            ((ccB[1] - 10 <= mBn) && (mBn <= ccB[1] + 10)))
                        {
                            for (int i2 = i; i2 < i + 10; i2++)
                                for (int j2 = j; j2 < j + 10; j2++)
                                {
                                    red = int.Parse(txtR2.Text);
                                    green = int.Parse(txtG2.Text);
                                    blue = int.Parse(txtB2.Text);

                                    // Asegurarse de que los valores están en el rango correcto (0-255)
                                    red = Math.Max(0, Math.Min(255, red));
                                    green = Math.Max(0, Math.Min(255, green));
                                    blue = Math.Max(0, Math.Min(255, blue));

                                    // Crear un nuevo color con los valores proporcionados
                                    Color newColor = Color.FromArgb(red, green, blue);

                                    // Establecer el nuevo color en el píxel (i2, j2) del objeto Bitmap (bmp2)
                                    bmp2.SetPixel(i2, j2, newColor);
                                }
                        }
                        else if (((ccR[2] - 10 <= mRn) && (mRn <= ccR[2] + 10)) &&
                            ((ccG[2] - 10 <= mGn) && (mGn <= ccG[2] + 10)) &&
                            ((ccB[2] - 10 <= mBn) && (mBn <= ccB[2] + 10)))
                        {
                            for (int i2 = i; i2 < i + 10; i2++)
                                for (int j2 = j; j2 < j + 10; j2++)
                                {
                                    red = int.Parse(txtR3.Text);
                                    green = int.Parse(txtG3.Text);
                                    blue = int.Parse(txtB3.Text);

                                    // Asegurarse de que los valores están en el rango correcto (0-255)
                                    red = Math.Max(0, Math.Min(255, red));
                                    green = Math.Max(0, Math.Min(255, green));
                                    blue = Math.Max(0, Math.Min(255, blue));

                                    // Crear un nuevo color con los valores proporcionados
                                    Color newColor = Color.FromArgb(red, green, blue);

                                    // Establecer el nuevo color en el píxel (i2, j2) del objeto Bitmap (bmp2)
                                    bmp2.SetPixel(i2, j2, newColor);
                                }
                        }
                        else
                        {
                            for (int i2 = i; i2 < i + 10; i2++)
                                for (int j2 = j; j2 < j + 10; j2++)
                                {
                                    c = bmp.GetPixel(i2, j2);
                                    bmp2.SetPixel(i2, j2, Color.FromArgb(c.R, c.G, c.B));
                                }
                        }


                    }
                pictureBox1.Image = bmp2;
            }
            else
            {
                MessageBox.Show("Selecciona 3 sectores de la imagen", "ERROR", MessageBoxButtons.OK);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Debe Cargar una Imagen!!.", "ERROR", MessageBoxButtons.OK);
            }
            else
            {
                int mRn = 0, mGn = 0, mBn = 0;
                Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
                Color c = new Color();
                for (int i = 0; i < bmp.Width - 10; i = i + 10)
                    for (int j = 0; j < bmp.Height - 10; j = j + 10)
                    {

                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                c = bmp.GetPixel(i2, j2);
                                mRn = mRn + c.R;
                                mGn = mGn + c.G;
                                mBn = mBn + c.B;
                            }
                        mRn = mRn / 100;
                        mGn = mGn / 100;
                        mBn = mBn / 100;

                        if (((mR - 10 <= mRn) && (mRn <= mR + 10)) &&
                            ((mG - 10 <= mGn) && (mGn <= mG + 10)) &&
                            ((mB - 10 <= mBn) && (mBn <= mB + 10)))
                        {
                            for (int i2 = i; i2 < i + 10; i2++)
                                for (int j2 = j; j2 < j + 10; j2++)
                                {
                                    // Suponiendo que txtR, txtG y txtB son TextBox que contienen los valores RGB introducidos por el usuario
                                    red = int.Parse(txtR.Text);
                                    green = int.Parse(txtG.Text);
                                    blue = int.Parse(txtB.Text);

                                    // Asegurarse de que los valores están en el rango correcto (0-255)
                                    red = Math.Max(0, Math.Min(255, red));
                                    green = Math.Max(0, Math.Min(255, green));
                                    blue = Math.Max(0, Math.Min(255, blue));

                                    // Crear un nuevo color con los valores proporcionados
                                    Color newColor = Color.FromArgb(red, green, blue);

                                    // Establecer el nuevo color en el píxel (i2, j2) del objeto Bitmap (bmp2)
                                    bmp2.SetPixel(i2, j2, newColor);
                                    //bmp2.SetPixel(i2, j2, Color.Green);
                                }
                        }
                        else
                        {
                            for (int i2 = i; i2 < i + 10; i2++)
                                for (int j2 = j; j2 < j + 10; j2++)
                                {
                                    c = bmp.GetPixel(i2, j2);
                                    bmp2.SetPixel(i2, j2, Color.FromArgb(c.R, c.G, c.B));
                                }
                        }


                    }
                pictureBox1.Image = bmp2;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Debe Cargar una Imagen!!.", "ERROR", MessageBoxButtons.OK);
            }
            else
            {
                int mRn = 0, mGn = 0, mBn = 0;
                Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
                Color c = new Color();
                for (int i = 0; i < bmp.Width - 10; i = i + 10)
                    for (int j = 0; j < bmp.Height - 10; j = j + 10)
                    {

                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                c = bmp.GetPixel(i2, j2);
                                mRn = mRn + c.R;
                                mGn = mGn + c.G;
                                mBn = mBn + c.B;
                            }
                        mRn = mRn / 100;
                        mGn = mGn / 100;
                        mBn = mBn / 100;

                        if (((mR - 10 <= mRn) && (mRn <= mR + 10)) &&
                            ((mG - 10 <= mGn) && (mGn <= mG + 10)) &&
                            ((mB - 10 <= mBn) && (mBn <= mB + 10)))
                        {
                            for (int i2 = i; i2 < i + 10; i2++)
                                for (int j2 = j; j2 < j + 10; j2++)
                                {
                                    bmp2.SetPixel(i2, j2, Color.Green);
                                }
                        }
                        else
                        {
                            for (int i2 = i; i2 < i + 10; i2++)
                                for (int j2 = j; j2 < j + 10; j2++)
                                {
                                    c = bmp.GetPixel(i2, j2);
                                    bmp2.SetPixel(i2, j2, Color.FromArgb(c.R, c.G, c.B));
                                }
                        }


                    }
                pictureBox1.Image = bmp2;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Debe Cargar una Imagen!!.", "ERROR", MessageBoxButtons.OK);
            }
            else
            {
                int mRn = 0, mGn = 0, mBn = 0;
                Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
                Color c = new Color();
                for (int i = 0; i < bmp.Width - 10; i = i + 10)
                    for (int j = 0; j < bmp.Height - 10; j = j + 10)
                    {

                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                c = bmp.GetPixel(i2, j2);
                                mRn = mRn + c.R;
                                mGn = mGn + c.G;
                                mBn = mBn + c.B;
                            }
                        mRn = mRn / 100;
                        mGn = mGn / 100;
                        mBn = mBn / 100;

                        if (((mR - 10 <= mRn) && (mRn <= mR + 10)) &&
                            ((mG - 10 <= mGn) && (mGn <= mG + 10)) &&
                            ((mB - 10 <= mBn) && (mBn <= mB + 10)))
                        {
                            for (int i2 = i; i2 < i + 10; i2++)
                                for (int j2 = j; j2 < j + 10; j2++)
                                {
                                    bmp2.SetPixel(i2, j2, Color.Black);
                                }
                        }
                        else
                        {
                            for (int i2 = i; i2 < i + 10; i2++)
                                for (int j2 = j; j2 < j + 10; j2++)
                                {
                                    c = bmp.GetPixel(i2, j2);
                                    bmp2.SetPixel(i2, j2, Color.FromArgb(c.R, c.G, c.B));
                                }
                        }


                    }
                pictureBox1.Image = bmp2;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Especifica la URL que deseas abrir en Chrome
            string url = "https://htmlcolorcodes.com/es/";

            // Abre la URL en el navegador predeterminado
            System.Diagnostics.Process.Start(url);
        }

        private void txtR1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
