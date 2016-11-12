using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ECCI_Gato
{
    public partial class Juego : System.Web.UI.Page
    {
        private ECCI_GatoService.ECCI_GatoPortClient gato;
        private int clickedByPlayerNo, clickNo;
        protected DataSet tabla;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
               // gato = new ECCI_GatoService.ECCI_GatoPortClient();
                Limpiartablero(false);
            }
            tabla = new DataSet();
            DataBind();
        }
        public Juego()
        {
            gato = new ECCI_GatoService.ECCI_GatoPortClient();
        }

        protected void NuevoJuego(object sender, EventArgs e)
        {
            Limpiartablero(true);
            clickNo = 0;
            gato.Close();
            infoGanador.Visible = false;
            top10.Visible = false;
            Button9.Enabled = false;
        }

        private void movida(object Sender, int[] coordinadas)
        {
            clickNo += 1;

            if ((gato.jugadorActual()) == "X")
            {
                ((Button)Sender).Text = "X";
            }
            else
            {
                ((Button)Sender).Text = "O";
            }
            ((Button)Sender).Enabled = false; //Disable the button once it is clicked
            string arreglo = coordinadas[0].ToString() + "," + coordinadas[1].ToString() + "," + gato.jugadorActual();
            gato.mover(arreglo);

            revisarGanador();
        }

        protected void Limpiartablero(bool a)
        {
            Button1.Text = "";
            Button1.Enabled = a;
            Button2.Text = "";
            Button2.Enabled = a;
            Button3.Text = "";
            Button3.Enabled = a;
            Button4.Text = "";
            Button4.Enabled = a;
            Button5.Text = "";
            Button5.Enabled = a;
            Button6.Text = "";
            Button6.Enabled = a;
            Button7.Text = "";
            Button7.Enabled = a;
            Button8.Text = "";
            Button8.Enabled = a;
            Button0.Text = "";
            Button0.Enabled = a;
        }

        protected void btn0_Click(object sender, EventArgs e)
        {
            int[] coordinadas = { 0, 0 };
            movida(sender, coordinadas);
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            int[] coordinadas = { 0, 1 };
            movida(sender, coordinadas);
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            int[] coordinadas = { 0, 2 };
            movida(sender, coordinadas);
        }

        protected void btn3_Click(object sender, EventArgs e)
        {
            int[] coordinadas = { 1, 0 };
            movida(sender, coordinadas);
        }

        protected void btn4_Click(object sender, EventArgs e)
        {
            int[] coordinadas = { 1, 1 };
            movida(sender, coordinadas);
        }

        protected void btn5_Click(object sender, EventArgs e)
        {
            int[] coordinadas = { 1, 2 };
            movida(sender, coordinadas);
        }

        protected void btn6_Click(object sender, EventArgs e)
        {
            int[] coordinadas = { 2, 0 };
            movida(sender, coordinadas);
        }

        protected void btn7_Click(object sender, EventArgs e)
        {
            int[] coordinadas = { 2, 1 };
            movida(sender, coordinadas);
        }

        protected void btn8_Click(object sender, EventArgs e)
        {
            int[] coordinadas = { 2, 2 };
            movida(sender, coordinadas);
        }


        private void revisarGanador()
        {
            if ((gato.terminado()) == "X")
            {
                desplegarGanador(1, "X");
            }

            if ((gato.terminado()) == "O")
            {
                desplegarGanador(1, "O");
            }

            if ((gato.terminado()) == "Empate")
            {
                desplegarGanador(1, "Empate");
            }
        }

        private void desplegarGanador(int x, string jugador)
        {
            Button9.Visible = false;
           // int x = 0;
            if (x == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Fue un empate');", true);
            }
            if (x == 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "El ganador fue: " + jugador + "');", true);
                infoGanador.Visible = true;
            }
        }

        protected void guardarGanador(object sender, EventArgs e)
        {
            string t = inputNombre.Value;
            gato.insertarJugadorBD(inputNombre.Value);
            Top10();
            top10.Visible = true;
        }

        private void Top10()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Nombre");
            table.Columns.Add("Tiempo");

            string die = gato.diezMejores();
            string[] jugadores = die.Split('-');
            string[] temp;
            for (int i = 0, j = 0; i < jugadores.Length; i++, j += 2)
            {
                temp = jugadores[i].Split(',');
                table.Rows.Add(temp[0], temp[1]);
            }
            tabla.Tables.Add(table);
            gato.juegoTerminado();
        }
    }
}