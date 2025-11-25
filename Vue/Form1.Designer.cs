namespace Mission_C_
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbSecteur = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbLiaison = new System.Windows.Forms.ListBox();
            this.bAffichage = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tb_UpdateDuree = new System.Windows.Forms.TextBox();
            this.bMaj = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.bDelete = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbPortArrivee = new System.Windows.Forms.ComboBox();
            this.cbPortDepart = new System.Windows.Forms.ComboBox();
            this.cbSecteur = new System.Windows.Forms.ComboBox();
            this.tbDuree = new System.Windows.Forms.TextBox();
            this.tbCodeLiaison = new System.Windows.Forms.TextBox();
            this.bInsert = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbSecteur);
            this.groupBox1.Location = new System.Drawing.Point(26, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(171, 187);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Secteur";
            // 
            // lbSecteur
            // 
            this.lbSecteur.FormattingEnabled = true;
            this.lbSecteur.Location = new System.Drawing.Point(4, 15);
            this.lbSecteur.Margin = new System.Windows.Forms.Padding(2);
            this.lbSecteur.Name = "lbSecteur";
            this.lbSecteur.Size = new System.Drawing.Size(163, 160);
            this.lbSecteur.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbLiaison);
            this.groupBox2.Location = new System.Drawing.Point(219, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(372, 187);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Liaison";
            // 
            // lbLiaison
            // 
            this.lbLiaison.FormattingEnabled = true;
            this.lbLiaison.Location = new System.Drawing.Point(4, 15);
            this.lbLiaison.Margin = new System.Windows.Forms.Padding(2);
            this.lbLiaison.Name = "lbLiaison";
            this.lbLiaison.Size = new System.Drawing.Size(364, 160);
            this.lbLiaison.TabIndex = 1;
            // 
            // bAffichage
            // 
            this.bAffichage.Location = new System.Drawing.Point(326, 201);
            this.bAffichage.Margin = new System.Windows.Forms.Padding(2);
            this.bAffichage.Name = "bAffichage";
            this.bAffichage.Size = new System.Drawing.Size(62, 19);
            this.bAffichage.TabIndex = 3;
            this.bAffichage.Text = "Affichage";
            this.bAffichage.UseVisualStyleBackColor = true;
            this.bAffichage.Click += new System.EventHandler(this.bAffichage_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tb_UpdateDuree);
            this.groupBox3.Controls.Add(this.bMaj);
            this.groupBox3.Location = new System.Drawing.Point(112, 222);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(125, 81);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mise à jour";
            // 
            // tb_UpdateDuree
            // 
            this.tb_UpdateDuree.Location = new System.Drawing.Point(22, 27);
            this.tb_UpdateDuree.Margin = new System.Windows.Forms.Padding(2);
            this.tb_UpdateDuree.Name = "tb_UpdateDuree";
            this.tb_UpdateDuree.Size = new System.Drawing.Size(76, 20);
            this.tb_UpdateDuree.TabIndex = 5;
            // 
            // bMaj
            // 
            this.bMaj.Location = new System.Drawing.Point(33, 58);
            this.bMaj.Margin = new System.Windows.Forms.Padding(2);
            this.bMaj.Name = "bMaj";
            this.bMaj.Size = new System.Drawing.Size(56, 19);
            this.bMaj.TabIndex = 0;
            this.bMaj.Text = "MAJ";
            this.bMaj.UseVisualStyleBackColor = true;
            this.bMaj.Click += new System.EventHandler(this.bMaj_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.bDelete);
            this.groupBox4.Location = new System.Drawing.Point(250, 225);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(125, 81);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Suppression";
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(30, 32);
            this.bDelete.Margin = new System.Windows.Forms.Padding(2);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(62, 19);
            this.bDelete.TabIndex = 0;
            this.bDelete.Text = "DELETE";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbPortArrivee);
            this.groupBox5.Controls.Add(this.cbPortDepart);
            this.groupBox5.Controls.Add(this.cbSecteur);
            this.groupBox5.Controls.Add(this.tbDuree);
            this.groupBox5.Controls.Add(this.tbCodeLiaison);
            this.groupBox5.Controls.Add(this.bInsert);
            this.groupBox5.Location = new System.Drawing.Point(392, 201);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(195, 154);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Insertion";
            // 
            // cbPortArrivee
            // 
            this.cbPortArrivee.FormattingEnabled = true;
            this.cbPortArrivee.Location = new System.Drawing.Point(98, 90);
            this.cbPortArrivee.Name = "cbPortArrivee";
            this.cbPortArrivee.Size = new System.Drawing.Size(97, 21);
            this.cbPortArrivee.TabIndex = 9;
            this.cbPortArrivee.Text = "Port Arrivée";
            // 
            // cbPortDepart
            // 
            this.cbPortDepart.FormattingEnabled = true;
            this.cbPortDepart.Location = new System.Drawing.Point(0, 90);
            this.cbPortDepart.Name = "cbPortDepart";
            this.cbPortDepart.Size = new System.Drawing.Size(92, 21);
            this.cbPortDepart.TabIndex = 8;
            this.cbPortDepart.Text = "Port Départ";
            // 
            // cbSecteur
            // 
            this.cbSecteur.FormattingEnabled = true;
            this.cbSecteur.Location = new System.Drawing.Point(99, 27);
            this.cbSecteur.Margin = new System.Windows.Forms.Padding(2);
            this.cbSecteur.Name = "cbSecteur";
            this.cbSecteur.Size = new System.Drawing.Size(92, 21);
            this.cbSecteur.TabIndex = 7;
            this.cbSecteur.SelectedIndexChanged += new System.EventHandler(this.cbSecteur_SelectedIndexChanged);
            // 
            // tbDuree
            // 
            this.tbDuree.Location = new System.Drawing.Point(50, 55);
            this.tbDuree.Margin = new System.Windows.Forms.Padding(2);
            this.tbDuree.Name = "tbDuree";
            this.tbDuree.Size = new System.Drawing.Size(76, 20);
            this.tbDuree.TabIndex = 4;
            this.tbDuree.Text = "Durée";
            // 
            // tbCodeLiaison
            // 
            this.tbCodeLiaison.Location = new System.Drawing.Point(4, 28);
            this.tbCodeLiaison.Margin = new System.Windows.Forms.Padding(2);
            this.tbCodeLiaison.Name = "tbCodeLiaison";
            this.tbCodeLiaison.Size = new System.Drawing.Size(76, 20);
            this.tbCodeLiaison.TabIndex = 1;
            // 
            // bInsert
            // 
            this.bInsert.Location = new System.Drawing.Point(70, 131);
            this.bInsert.Margin = new System.Windows.Forms.Padding(2);
            this.bInsert.Name = "bInsert";
            this.bInsert.Size = new System.Drawing.Size(56, 19);
            this.bInsert.TabIndex = 0;
            this.bInsert.Text = "INSERT";
            this.bInsert.UseVisualStyleBackColor = true;
            this.bInsert.Click += new System.EventHandler(this.bInsert_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.bAffichage);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbSecteur;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbLiaison;
        private System.Windows.Forms.Button bAffichage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bMaj;
        private System.Windows.Forms.TextBox tb_UpdateDuree;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button bInsert;
        private System.Windows.Forms.TextBox tbCodeLiaison;
        private System.Windows.Forms.TextBox tbDuree;
        private System.Windows.Forms.ComboBox cbSecteur;
        private System.Windows.Forms.ComboBox cbPortArrivee;
        private System.Windows.Forms.ComboBox cbPortDepart;
    }
}

