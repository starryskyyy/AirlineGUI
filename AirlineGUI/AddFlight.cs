﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineGUI
{
    public partial class AddFlight : Form
    {
        public AddFlight()
        {
            InitializeComponent();
        }

        //Moveable Form
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        //Starting of Switching Forms
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddCustomer ac = new AddCustomer();
            ac.ShowDialog();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mm = new MainMenu();
            mm.ShowDialog();
            this.Close();
        }

        private void btnAddBooking_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddBooking ab = new AddBooking();
            ab.ShowDialog();
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            fnTextBox.Clear();
            orTextBox.Clear();
            destTextBox.Clear();
            mSeatsTextBox.Clear();
        }

        private void btnViewFlights_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewFlight vf = new ViewFlight();
            vf.ShowDialog();
            this.Close();
        }

        private void btnViewCustomers_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewCustomer vc = new ViewCustomer();
            vc.ShowDialog();
            this.Close();
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeleteCustomer dc = new DeleteCustomer();
            dc.ShowDialog();
            this.Close();
        }

        private void btnAddFlight_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddFlight af = new AddFlight();
            af.ShowDialog();
            this.Close();
        }

        private void btnDeleteFlights_Click(object sender, EventArgs e)
        {
                        this.Hide();
            DeleteFlight df = new DeleteFlight();
            df.ShowDialog();
            this.Close();
        }
        //End of Switching Forms

        //Confirmation for when user exits program
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you would like to exit?", "Exiting Program", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                this.Activate();
            }
            else
            {
                this.Close();
            }
        }

        //Create flights and validates textbox
        private void btnAddFlights_Click(object sender, EventArgs e)
        {
            int fn;
            string or = (orTextBox.Text);
            string dest = (destTextBox.Text);
            int mSeats;

            if (!int.TryParse(fnTextBox.Text, out fn) || String.IsNullOrEmpty(orTextBox.Text) || String.IsNullOrEmpty(destTextBox.Text) || !int.TryParse(mSeatsTextBox.Text, out mSeats))
            {
                MessageBox.Show("Uh Oh...Information Is Missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("You have added a flight", "Success", MessageBoxButtons.OK);
                Program.addFlight(fn, or, dest, mSeats);
            }
        }

    }
}
