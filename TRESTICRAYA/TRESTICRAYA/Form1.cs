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
            "El tiburón ballena es el pez más grande del mundo.",
            "Los gatos tienen más huesos en sus cuerpos que los humanos.",
            "El corazón de un camarón está en su cabeza.",
            "Las medusas están compuestas en un 95% de agua.",
            "La Gran Muralla China no es visible desde el espacio sin ayuda.",
            "Los humanos comparten el 50% de su ADN con los plátanos.",
            "Las abejas pueden reconocer rostros humanos.",
            "El Sol es 400 veces más grande que la Luna, pero también está 400 veces más lejos.",
            "Un rayo calienta el aire a una temperatura cinco veces mayor que la superficie del sol.",
            "Los flamingos son rosados debido a su dieta de camarones.",
            "La miel nunca se echa a perder. Se han encontrado tarros de miel de hace miles de años en tumbas egipcias que aún están en buen estado.",
            "Las estrellas de mar no tienen cerebro.",
            "Los caballitos de mar son una de las pocas especies animales en las que el macho da a luz.",
            "La Tierra no es una esfera perfecta, es un esferoide oblato.",
            "Los elefantes son los únicos mamíferos que no pueden saltar.",
            "Un día en Venus es más largo que un año en Venus.",
            "El kiwi es el único ave sin alas.",
            "El cerebro humano genera suficientes vatios para encender una bombilla.",
            "Las ranas pueden respirar a través de su piel.",
            "Las hormigas no duermen.",
            "La luz del Sol tarda unos 8 minutos y 20 segundos en llegar a la Tierra.",
            "Los pulpos tienen tres corazones.",
            "El Monte Everest crece aproximadamente 4 milímetros cada año.",
            "Los koalas duermen hasta 22 horas al día.",
            "Las mariposas tienen sensores de sabor en sus patas.",
            "El ADN humano es 99,9% idéntico en todas las personas.",
            "Los peces no tienen párpados.",
            "Las cebras son negras con rayas blancas, no al revés.",
            "El pulpo de anillos azules es uno de los animales más venenosos del mundo.",
            "La sangre de los cangrejos herradura es azul debido a la hemocianina.",
            "Las tortugas pueden respirar a través de su trasero.",
            "El veneno de la serpiente taipán puede matar a un humano en menos de 45 minutos.",
            "El perro más antiguo registrado vivió hasta los 29 años.",
            "El agua cubre aproximadamente el 71% de la superficie terrestre.",
            "La Gran Barrera de Coral es el organismo vivo más grande del mundo.",
            "El ave más rápida del mundo es el halcón peregrino.",
            "El calamar gigante tiene el mayor tamaño de ojo registrado en el reino animal.",
            "Las jirafas tienen la misma cantidad de vértebras en el cuello que los humanos.",
            "La mayor parte del oxígeno de la Tierra proviene del océano.",
            "El cerebro humano puede tener más conexiones sinápticas que estrellas en la Vía Láctea.",
            "La piedra más antigua conocida en la Tierra tiene alrededor de 4.4 mil millones de años.",
            "La sombra en la Luna durante un eclipse lunar se llama la umbra.",
            "Las hormigas pueden levantar objetos que pesan hasta 50 veces su peso corporal.",
            "El colibrí es el único pájaro que puede volar hacia atrás.",
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
            int tamañoBoton = 100;
            int margen = 10;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Boton boton = new Boton
                    {
                        Size = new Size(tamañoBoton, tamañoBoton),
                        Location = new Point(i * (tamañoBoton + margen), j * (tamañoBoton + margen)),
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
                Location = new Point(10, 3 * (tamañoBoton + margen) + margen),
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

            MessageBox.Show($"¡Victoria de {ganador}! Aquí tienes un dato curioso: {hechoAleatorio}");

            ReiniciarJuego();
        }

        private void MostrarMensajeDerrota(string perdedor)
        {
            Random random = new Random();
            int indiceHechoAleatorio = random.Next(hechosAleatorios.Count);
            string hechoAleatorio = hechosAleatorios[indiceHechoAleatorio];

            MessageBox.Show($"¡Derrota! {perdedor} ha ganado. Aquí tienes un dato curioso: {hechoAleatorio}");

            ReiniciarJuego();
        }

        private void MostrarMensajeEmpate()
        {
            Random random = new Random();
            int indiceHechoAleatorio = random.Next(hechosAleatorios.Count);
            string hechoAleatorio = hechosAleatorios[indiceHechoAleatorio];

            MessageBox.Show($"¡Empate! Aquí tienes un dato curioso: {hechoAleatorio}");

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
