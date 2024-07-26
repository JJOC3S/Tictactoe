using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TRESTICRAYA
{
    public partial class Form1 : Form
    {
        private Button[,] buttons = new Button[3, 3];
        private bool playerTurn = true; // true = X turn; false = O turn
        private int turnCount = 0;
        private List<string> randomFacts = new List<string>
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
    "El insecto más antiguo registrado tiene 400 millones de años.",
    "Las ballenas azules son los animales más grandes que hayan existido.",
    "Las estrellas fugaces son en realidad meteoritos quemándose en la atmósfera de la Tierra.",
    "Los perezosos pueden aguantar la respiración más tiempo que los delfines.",
    "El elefante africano es el animal terrestre más grande.",
    "El camaleón puede mover sus ojos independientemente uno del otro.",
    "Las plantas de bambú pueden crecer hasta un metro en un solo día.",
    "Las abejas se comunican a través de una danza llamada 'baile de la abeja'.",
    "El lince tiene orejas que actúan como antenas para escuchar mejor.",
    "El águila calva es el ave nacional de Estados Unidos.",
    "El cerebro de un avestruz es más pequeño que uno de sus ojos.",
    "La seda de araña es más fuerte que el acero si se compara peso por peso.",
    "El tiburón mako es el tiburón más rápido del mundo.",
    "La Tierra es el único planeta del sistema solar que no lleva el nombre de un dios.",
    "Las libélulas han estado en la Tierra por más de 300 millones de años.",
    "La garza real puede extender su cuello hasta casi el doble de su longitud.",
    "La hormiga reina puede vivir hasta 30 años.",
    "El águila harpía tiene las garras más grandes de cualquier ave de presa.",
    "El ornitorrinco es uno de los pocos mamíferos venenosos.",
    "Los pulpos pueden cambiar el color y la textura de su piel para camuflarse.",
    "El pez más venenoso del mundo es el pez piedra.",
    "Las mariposas monarca migran más de 3,000 millas cada año.",
    "El animal más ruidoso del mundo es el camarón pistola.",
    "Los lobos tienen una estructura social jerárquica.",
    "El camaleón puede proyectar su lengua a una distancia de hasta dos veces la longitud de su cuerpo.",
    "El cóndor de los Andes tiene la mayor envergadura de cualquier ave terrestre.",
    "La piel de los tiburones está cubierta de diminutas escamas llamadas dentículos dérmicos.",
    "Los colibríes tienen el metabolismo más rápido de cualquier ave.",
    "Los elefantes se comunican usando infrasonidos que están fuera del alcance del oído humano.",
    "El océano contiene aproximadamente el 97% del agua de la Tierra.",
    "Las esponjas marinas no tienen órganos ni tejidos, pero pueden regenerar partes de su cuerpo.",
    "El pez más profundo registrado fue encontrado a más de 8,000 metros bajo el nivel del mar.",
    "El sistema de raíces de un árbol puede extenderse hasta cuatro veces la anchura de su copa.",
    "La abeja reina puede poner hasta 2,000 huevos en un solo día.",
    "El insecto más rápido del mundo es el escarabajo tigre.",
    "Las hormigas pueden construir puentes vivientes con sus cuerpos.",
    "El narval tiene un colmillo que puede crecer hasta 3 metros de largo.",
    "Las mariposas tienen escamas en sus alas que reflejan la luz para crear colores brillantes.",
    "El cocodrilo del Nilo es responsable de más muertes humanas en África que cualquier otro depredador salvaje.",
    "El pingüino emperador es el único pingüino que se reproduce durante el invierno antártico.",
    "El geco puede caminar por superficies verticales gracias a los millones de pequeños pelos en sus pies.",
    "El hipopótamo puede correr más rápido que un ser humano.",
    "El delfín nariz de botella puede nadar a velocidades de hasta 20 millas por hora.",
    "La luciérnaga produce luz a través de una reacción química en su abdomen llamada bioluminiscencia.",
    "El oso polar tiene una capa de grasa que puede medir hasta 4.5 pulgadas de espesor para aislarse del frío.",
    "El rinoceronte tiene una piel gruesa que puede medir hasta 1.5 pulgadas de grosor.",
    "El tiburón de Groenlandia puede vivir hasta 400 años, lo que lo convierte en uno de los vertebrados más longevos.",
    "El búho puede girar su cabeza hasta 270 grados sin dañar los vasos sanguíneos o las arterias de su cuello."
};


        public Form1()
        {
            InitializeComponent();
            InitializeGameBoard();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Inicializar la interfaz del juego cuando el formulario se carga.
        }

        private void InitializeGameBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(100, 100);
                    buttons[i, j].Location = new Point(i * 100, j * 100);
                    buttons[i, j].Font = new Font("Arial", 24);
                    buttons[i, j].Click += new EventHandler(ButtonClick);
                    this.Controls.Add(buttons[i, j]);
                }
            }

            // Agregar un Label para mostrar mensajes de estado
            Label statusLabel = new Label
            {
                Size = new Size(300, 30),
                Location = new Point(10, 310),
                Font = new Font("Arial", 12),
                Text = "Turno del jugador X"
            };
            this.Controls.Add(statusLabel);

            // Agregar un botón de reinicio
            Button resetButton = new Button
            {
                Size = new Size(100, 30),
                Location = new Point(110, 350),
                Text = "Reiniciar",
            };
            resetButton.Click += new EventHandler(ResetButtonClick);
            this.Controls.Add(resetButton);
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Text == "")
            {
                button.Text = "X";
                playerTurn = false;
                turnCount++;
                CheckWinner();

                if (!playerTurn)
                {
                    ComputerMove();
                }
            }
        }

        private void ComputerMove()
        {
            // Lógica simple para movimiento de la computadora
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (buttons[i, j].Text == "")
                    {
                        buttons[i, j].Text = "O";
                        playerTurn = true;
                        turnCount++;
                        CheckWinner();
                        return;
                    }
                }
            }
        }

        private void ResetButtonClick(object sender, EventArgs e)
        {
            // Reiniciar el juego
            foreach (Button btn in buttons)
            {
                btn.Text = "";
                btn.Enabled = true;
            }
            playerTurn = true;
            turnCount = 0;
        }

        private void CheckWinner()
        {
            bool thereIsAWinner = false;

            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if (buttons[i, 0].Text == buttons[i, 1].Text && buttons[i, 1].Text == buttons[i, 2].Text && buttons[i, 0].Text != "")
                {
                    thereIsAWinner = true;
                }
            }

            // Check columns
            for (int i = 0; i < 3; i++)
            {
                if (buttons[0, i].Text == buttons[1, i].Text && buttons[1, i].Text == buttons[2, i].Text && buttons[0, i].Text != "")
                {
                    thereIsAWinner = true;
                }
            }

            // Check diagonals
            if ((buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 2].Text && buttons[0, 0].Text != "") ||
                (buttons[0, 2].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 0].Text && buttons[0, 2].Text != ""))
            {
                thereIsAWinner = true;
            }

            if (thereIsAWinner)
            {
                DisableButtons();
                string winner = playerTurn ? "O" : "X";
                MessageBox.Show($"{winner} gana!", "¡Ganador!");
                ShowWinningImage();
            }
            else if (turnCount == 9)
            {
                MessageBox.Show("¡Empate!", "Fin del juego");
                ShowRandomFact();
            }
        }

        private void DisableButtons()
        {
            foreach (Button btn in buttons)
            {
                btn.Enabled = false;
            }
        }

        private void ShowRandomFact()
        {
            Random random = new Random();
            int index = random.Next(randomFacts.Count);
            MessageBox.Show(randomFacts[index], "Dato Interesante");
        }

        private void ShowWinningImage()
        {
            Form winForm = new Form
            {
                Size = new Size(800, 600),
                BackgroundImage = Image.FromFile("windores.png"),
                BackgroundImageLayout = ImageLayout.Stretch
            };
            winForm.ShowDialog();
        }
    }
}
