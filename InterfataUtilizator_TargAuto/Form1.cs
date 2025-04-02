using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TargAutoLibrary;
using NivelStocareDate;


namespace InterfataUtilizator_TargAuto
{
    public partial class Form1 : Form
    {
        private FlowLayoutPanel panelAfisare;
        private Button btnReincarcare;

        public Form1()
        {
            InitializeComponent();

            // Setări fereastră
            this.Text = "Afișare Mașini - TargAuto";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
            this.Width = 1000;
            this.Height = 700;

            // Inițializare panel de afișare
            panelAfisare = new FlowLayoutPanel();
            panelAfisare.Dock = DockStyle.Fill;
            panelAfisare.AutoScroll = true;
            panelAfisare.WrapContents = false;
            panelAfisare.FlowDirection = FlowDirection.TopDown;
            this.Controls.Add(panelAfisare);

            // Inițializare buton reîncărcare
            btnReincarcare = new Button();
            btnReincarcare.Text = "Reîncarcă mașinile";
            btnReincarcare.Height = 40;
            btnReincarcare.Width = 200;
            btnReincarcare.Top = 10;
            btnReincarcare.Left = 10;
            btnReincarcare.Click += BtnReincarcare_Click;
            this.Controls.Add(btnReincarcare);

            // Afișare inițială
            AfiseazaMasini();
        }

        private void BtnReincarcare_Click(object? sender, EventArgs e)
        {
            AfiseazaMasini();
        }

        private void AfiseazaMasini()
        {
            panelAfisare.Controls.Clear();

            string caleFisier = Path.Combine(Directory.GetCurrentDirectory(), "masini.txt");
            MessageBox.Show($"Fisier folosit:\n{caleFisier}");
            var admin = new AdministrareMasini_FisierText(caleFisier);
            List<Masina> masini = admin.GetMasini();

            if (masini.Count == 0)
            {
                Label lbl = new Label();
                lbl.Text = "Nu există mașini salvate.";
                lbl.AutoSize = true;
                lbl.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                panelAfisare.Controls.Add(lbl);
                return;
            }

            foreach (var m in masini)
            {
                Label lbl = new Label();
                lbl.Text = m.Info();
                lbl.Width = 900;
                lbl.Height = 60;
                lbl.BackColor = Color.LightYellow;
                lbl.Font = new Font("Segoe UI", 10);
                lbl.Padding = new Padding(10);
                lbl.BorderStyle = BorderStyle.FixedSingle;

                panelAfisare.Controls.Add(lbl);
            }
        }
    }
}
