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
    "El insecto m�s antiguo registrado tiene 400 millones de a�os.",
    "Las ballenas azules son los animales m�s grandes que hayan existido.",
    "Las estrellas fugaces son en realidad meteoritos quem�ndose en la atm�sfera de la Tierra.",
    "Los perezosos pueden aguantar la respiraci�n m�s tiempo que los delfines.",
    "El elefante africano es el animal terrestre m�s grande.",
    "El camale�n puede mover sus ojos independientemente uno del otro.",
    "Las plantas de bamb� pueden crecer hasta un metro en un solo d�a.",
    "Las abejas se comunican a trav�s de una danza llamada 'baile de la abeja'.",
    "El lince tiene orejas que act�an como antenas para escuchar mejor.",
    "El �guila calva es el ave nacional de Estados Unidos.",
    "El cerebro de un avestruz es m�s peque�o que uno de sus ojos.",
    "La seda de ara�a es m�s fuerte que el acero si se compara peso por peso.",
    "El tibur�n mako es el tibur�n m�s r�pido del mundo.",
    "La Tierra es el �nico planeta del sistema solar que no lleva el nombre de un dios.",
    "Las lib�lulas han estado en la Tierra por m�s de 300 millones de a�os.",
    "La garza real puede extender su cuello hasta casi el doble de su longitud.",
    "La hormiga reina puede vivir hasta 30 a�os.",
    "El �guila harp�a tiene las garras m�s grandes de cualquier ave de presa.",
    "El ornitorrinco es uno de los pocos mam�feros venenosos.",
    "Los pulpos pueden cambiar el color y la textura de su piel para camuflarse.",
    "El pez m�s venenoso del mundo es el pez piedra.",
    "Las mariposas monarca migran m�s de 3,000 millas cada a�o.",
    "El animal m�s ruidoso del mundo es el camar�n pistola.",
    "Los lobos tienen una estructura social jer�rquica.",
    "El camale�n puede proyectar su lengua a una distancia de hasta dos veces la longitud de su cuerpo.",
    "El c�ndor de los Andes tiene la mayor envergadura de cualquier ave terrestre.",
    "La piel de los tiburones est� cubierta de diminutas escamas llamadas dent�culos d�rmicos.",
    "Los colibr�es tienen el metabolismo m�s r�pido de cualquier ave.",
    "Los elefantes se comunican usando infrasonidos que est�n fuera del alcance del o�do humano.",
    "El oc�ano contiene aproximadamente el 97% del agua de la Tierra.",
    "Las esponjas marinas no tienen �rganos ni tejidos, pero pueden regenerar partes de su cuerpo.",
    "El pez m�s profundo registrado fue encontrado a m�s de 8,000 metros bajo el nivel del mar.",
    "El sistema de ra�ces de un �rbol puede extenderse hasta cuatro veces la anchura de su copa.",
    "La abeja reina puede poner hasta 2,000 huevos en un solo d�a.",
    "El insecto m�s r�pido del mundo es el escarabajo tigre.",
    "Las hormigas pueden construir puentes vivientes con sus cuerpos.",
    "El narval tiene un colmillo que puede crecer hasta 3 metros de largo.",
    "Las mariposas tienen escamas en sus alas que reflejan la luz para crear colores brillantes.",
    "El cocodrilo del Nilo es responsable de m�s muertes humanas en �frica que cualquier otro depredador salvaje.",
    "El ping�ino emperador es el �nico ping�ino que se reproduce durante el invierno ant�rtico.",
    "El geco puede caminar por superficies verticales gracias a los millones de peque�os pelos en sus pies.",
    "El hipop�tamo puede correr m�s r�pido que un ser humano.",
    "El delf�n nariz de botella puede nadar a velocidades de hasta 20 millas por hora.",
    "La luci�rnaga produce luz a trav�s de una reacci�n qu�mica en su abdomen llamada bioluminiscencia.",
    "El oso polar tiene una capa de grasa que puede medir hasta 4.5 pulgadas de espesor para aislarse del fr�o.",
    "El rinoceronte tiene una piel gruesa que puede medir hasta 1.5 pulgadas de grosor.",
    "El tibur�n de Groenlandia puede vivir hasta 400 a�os, lo que lo convierte en uno de los vertebrados m�s longevos.",
    "El b�ho puede girar su cabeza hasta 270 grados sin da�ar los vasos sangu�neos o las arterias de su cuello."
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

            // Agregar un bot�n de reinicio
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
            // L�gica simple para movimiento de la computadora
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
                MessageBox.Show($"{winner} gana!", "�Ganador!");
                ShowWinningImage();
            }
            else if (turnCount == 9)
            {
                MessageBox.Show("�Empate!", "Fin del juego");
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
