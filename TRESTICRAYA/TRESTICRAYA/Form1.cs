using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TRESTICRAYA
{
    public partial class Form1 : Form
    {
        private Boton[,] botones = new Boton[3, 3];
        private bool turnoJugador = true; 
        private int contadorTurnos = 0;
        private bool modoUnJugador = false;
        private Etiqueta estadoEtiqueta;
        private Button boton1vs1;
        private Button boton1vsComputadora;
        private List<string> hechosAleatorios = new List<string>
        {
            "El tibur�n ballena es el pez m�s grande del mundo.",
            "Los gatos tienen m�s huesos en sus cuerpos que los humanos.",
            "El coraz�n de un camar�n est� en su cabeza.",
            "Las medusas est�n compuestas en un 95% de agua.",
            "La Gran Muralla China no es visible desde el espacio sin ayuda.",
            "Los humanos comparten el 50% de su ADN con los pl�tanos.",
            "Las abejas pueden reconocer rostros humanos.",
            "El Sol es 400 veces m�s grande que la Luna, pero tambi�n est� 400 veces m�s lejos.",
            "Un rayo calienta el aire a una temperatura cinco veces mayor que la superficie del sol.",
            "Los flamingos son rosados debido a su dieta de camarones.",
            "La miel nunca se echa a perder. Se han encontrado tarros de miel de hace miles de a�os en tumbas egipcias que a�n est�n en buen estado.",
            "Las estrellas de mar no tienen cerebro.",
            "Los caballitos de mar son una de las pocas especies animales en las que el macho da a luz.",
            "La Tierra no es una esfera perfecta, es un esferoide oblato.",
            "Los elefantes son los �nicos mam�feros que no pueden saltar.",
            "Un d�a en Venus es m�s largo que un a�o en Venus.",
            "El kiwi es el �nico ave sin alas.",
            "El cerebro humano genera suficientes vatios para encender una bombilla.",
            "Las ranas pueden respirar a trav�s de su piel.",
            "Las hormigas no duermen.",
            "La luz del Sol tarda unos 8 minutos y 20 segundos en llegar a la Tierra.",
            "Los pulpos tienen tres corazones.",
            "El Monte Everest crece aproximadamente 4 mil�metros cada a�o.",
            "Los koalas duermen hasta 22 horas al d�a.",
            "Las mariposas tienen sensores de sabor en sus patas.",
            "El ADN humano es 99,9% id�ntico en todas las personas.",
            "Los peces no tienen p�rpados.",
            "Las cebras son negras con rayas blancas, no al rev�s.",
            "El pulpo de anillos azules es uno de los animales m�s venenosos del mundo.",
            "La sangre de los cangrejos herradura es azul debido a la hemocianina.",
            "Las tortugas pueden respirar a trav�s de su trasero.",
            "El veneno de la serpiente taip�n puede matar a un humano en menos de 45 minutos.",
            "El perro m�s antiguo registrado vivi� hasta los 29 a�os.",
            "El agua cubre aproximadamente el 71% de la superficie terrestre.",
            "La Gran Barrera de Coral es el organismo vivo m�s grande del mundo.",
            "El ave m�s r�pida del mundo es el halc�n peregrino.",
            "El calamar gigante tiene el mayor tama�o de ojo registrado en el reino animal.",
            "Las jirafas tienen la misma cantidad de v�rtebras en el cuello que los humanos.",
            "La mayor parte del ox�geno de la Tierra proviene del oc�ano.",
            "El cerebro humano puede tener m�s conexiones sin�pticas que estrellas en la V�a L�ctea.",
            "La piedra m�s antigua conocida en la Tierra tiene alrededor de 4.4 mil millones de a�os.",
            "La sombra en la Luna durante un eclipse lunar se llama la umbra.",
            "Las hormigas pueden levantar objetos que pesan hasta 50 veces su peso corporal.",
            "El colibr� es el �nico p�jaro que puede volar hacia atr�s.",
            "Los cerdos no pueden mirar al cielo.",
            "Las abejas tienen cinco ojos.",
            "El ojo humano puede distinguir aproximadamente 10 millones de colores diferentes.",
        };

        public Form1()
        {
            InitializeComponent();
            InicializarTablero();
            InicializarBotonesModoJuego();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void InicializarTablero()
        {
            int tama�oBoton = 100;
            int margen = 10;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Boton boton = new Boton
                    {
                        Size = new Size(tama�oBoton, tama�oBoton),
                        Location = new Point(i * (tama�oBoton + margen), j * (tama�oBoton + margen)),
                        Font = new Font("Arial", 24, FontStyle.Bold),
                        BackColor = Color.White,
                        Texto = ""
                    };
                    boton.Click += new EventHandler(Boton_Click);
                    botones[i, j] = boton;
                    this.Controls.Add(boton);
                }
            }

            estadoEtiqueta = new Etiqueta
            {
                AutoSize = true,
                Location = new Point(10, 3 * (tama�oBoton + margen) + margen),
                Font = new Font("Arial", 14, FontStyle.Bold),
                Text = "Turno de X"
            };
            this.Controls.Add(estadoEtiqueta);
        }

        private void InicializarBotonesModoJuego()
        {
            boton1vs1 = new Button
            {
                Text = "1 vs 1",
                Size = new Size(100, 30),
                Location = new Point(10, 3 * 110 + 40),
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            boton1vs1.Click += new EventHandler(Boton1vs1_Click);
            this.Controls.Add(boton1vs1);

            boton1vsComputadora = new Button
            {
                Text = "1 vs Computadora",
                Size = new Size(160, 30),
                Location = new Point(120, 3 * 110 + 40),
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            boton1vsComputadora.Click += new EventHandler(Boton1vsComputadora_Click);
            this.Controls.Add(boton1vsComputadora);
        }

        private void Boton1vs1_Click(object sender, EventArgs e)
        {
            modoUnJugador = false;
            ReiniciarJuego();
        }

        private void Boton1vsComputadora_Click(object sender, EventArgs e)
        {
            modoUnJugador = true;
            ReiniciarJuego();
        }

        private void Boton_Click(object sender, EventArgs e)
        {
            Boton botonClickeado = (Boton)sender;

            if (botonClickeado.Texto == "")
            {
                if (turnoJugador)
                {
                    botonClickeado.Texto = "X";
                    botonClickeado.BackColor = Color.LightBlue;
                }
                else
                {
                    botonClickeado.Texto = "O";
                    botonClickeado.BackColor = Color.LightCoral;
                }

                contadorTurnos++;
                if (VerificarVictoria())
                {
                    if (turnoJugador)
                    {
                        MostrarMensajeVictoria("X");
                    }
                    else
                    {
                        MostrarMensajeDerrota("O");
                    }
                }
                else if (contadorTurnos == 9)
                {
                    MostrarMensajeEmpate();
                }
                else
                {
                    turnoJugador = !turnoJugador;
                    ActualizarEstadoEtiqueta();

                    if (modoUnJugador && !turnoJugador)
                    {
                        RealizarMovimientoIA();
                    }
                }
            }
        }

        private void ActualizarEstadoEtiqueta()
        {
            if (turnoJugador)
            {
                estadoEtiqueta.Text = "Turno de X";
            }
            else
            {
                estadoEtiqueta.Text = "Turno de O";
            }
        }

        private bool VerificarVictoria()
        {
            for (int i = 0; i < 3; i++)
            {
                if (botones[i, 0].Texto == botones[i, 1].Texto && botones[i, 1].Texto == botones[i, 2].Texto && botones[i, 0].Texto != "")
                {
                    return true;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (botones[0, i].Texto == botones[1, i].Texto && botones[1, i].Texto == botones[2, i].Texto && botones[0, i].Texto != "")
                {
                    return true;
                }
            }

            if (botones[0, 0].Texto == botones[1, 1].Texto && botones[1, 1].Texto == botones[2, 2].Texto && botones[0, 0].Texto != "")
            {
                return true;
            }

            if (botones[0, 2].Texto == botones[1, 1].Texto && botones[1, 1].Texto == botones[2, 0].Texto && botones[0, 2].Texto != "")
            {
                return true;
            }

            return false;
        }

        private void MostrarMensajeVictoria(string ganador)
        {
            Random random = new Random();
            int indiceHechoAleatorio = random.Next(hechosAleatorios.Count);
            string hechoAleatorio = hechosAleatorios[indiceHechoAleatorio];

            MessageBox.Show($"�Victoria de {ganador}! Aqu� tienes un dato curioso: {hechoAleatorio}");

            ReiniciarJuego();
        }

        private void MostrarMensajeDerrota(string perdedor)
        {
            Random random = new Random();
            int indiceHechoAleatorio = random.Next(hechosAleatorios.Count);
            string hechoAleatorio = hechosAleatorios[indiceHechoAleatorio];

            MessageBox.Show($"�Derrota! {perdedor} ha ganado. Aqu� tienes un dato curioso: {hechoAleatorio}");

            ReiniciarJuego();
        }

        private void MostrarMensajeEmpate()
        {
            Random random = new Random();
            int indiceHechoAleatorio = random.Next(hechosAleatorios.Count);
            string hechoAleatorio = hechosAleatorios[indiceHechoAleatorio];

            MessageBox.Show($"�Empate! Aqu� tienes un dato curioso: {hechoAleatorio}");

            ReiniciarJuego();
        }

        private void ReiniciarJuego()
        {
            contadorTurnos = 0;
            turnoJugador = true;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    botones[i, j].Texto = "";
                    botones[i, j].BackColor = Color.White;
                }
            }

            estadoEtiqueta.Text = "Turno de X";
        }

        private void RealizarMovimientoIA()
        {
            Random random = new Random();
            int fila, columna;

            do
            {
                fila = random.Next(3);
                columna = random.Next(3);
            } while (botones[fila, columna].Texto != "");

            botones[fila, columna].Texto = "O";
            botones[fila, columna].BackColor = Color.LightCoral;
            contadorTurnos++;
            if (VerificarVictoria())
            {
                MostrarMensajeDerrota("O");
            }
            else if (contadorTurnos == 9)
            {
                MostrarMensajeEmpate();
            }
            else
            {
                turnoJugador = !turnoJugador;
                ActualizarEstadoEtiqueta();
            }
        }
    }

    public class Boton : Button
    {
        public string Texto
        {
            get { return this.Text; }
            set { this.Text = value; }
        }
    }

    public class Etiqueta : Label
    {
    }
}
