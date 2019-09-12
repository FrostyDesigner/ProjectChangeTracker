using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace PT
{
    //SQL Server Configuration
    //SQL Server Security:
    //Server Authentication: SQL Server and Windows Authentication Mode
    //Login Auditing: Both Failed and Successful logins

    //SQL Server Connctions:
    //Allow Remote Conncetions: True

    //SQL Server Configuration Utility:
    //Shared Memory: Enabled
    //TCP/IP: Enabled
    //Named Pipes: Enabled

    //Firewall Settings:
    //Inbound Rules:
    //Port 1433 Protocol TCP Enabled
    //Port 1434 Protocol UDP Enabled
    //Port 65058 Protocol TCP Enabled

    //Outbound Rules:
    //Port 1433 Protocol TCP Enabled
    //Port 1434 Protocol UDP Enabled
    //Port 65058 Protocol TCP Enabled

    public partial class Form1 : Form
    {
        public static string conn = ConfigurationManager.ConnectionStrings["DevConnString"].ToString();
        
        public Form1()
        {
            InitializeComponent();

            checkUser();

            ArrayList aList = new ArrayList();
            aList.Add("ProjectNumber");
            aList.Add("ProjectName");
            aList.Add("Date");
            aList.Add("Drafter");
            aList.Add("InitiatedBy");
            aList.Add("ChangeType");
            aList.Add("CurrentVersion");
            aList.Add("Description");
            aList.Add("NewVersion");
            aList.Add("Comments");

            // deleted
            //cboDbFields.DataSource = aList;

            ArrayList changType = new ArrayList();
            changType.Add(string.Empty);
            changType.Add("Initial Design");
            changType.Add("Arch. Marks");
            changType.Add("Engineer Marks");
            changType.Add("Internal Review");
            changType.Add("Cross Check");
            cbChangeType.DataSource = changType;

            ArrayList person = new ArrayList();
            person.Add(string.Empty);
            person.Add("Erin");
            person.Add("Nadia");
            person.Add("Alberto");
            person.Add("Nate");
            person.Add("Stephen");
            person.Add("Austin");
            person.Add("Robert");
            cbDrafter.DataSource = person;

            ArrayList iPerson = new ArrayList();
            iPerson.Add(string.Empty);
            iPerson.Add("Erin");
            iPerson.Add("Nadia");
            iPerson.Add("Alberto");
            iPerson.Add("Nate");
            iPerson.Add("Stephen");
            iPerson.Add("Austin");
            iPerson.Add("Robert");
            cbInitiatedBy.DataSource = iPerson;

            ArrayList iDescription = new ArrayList();
            iDescription.Add(string.Empty);
            iDescription.Add("Issued for First Preliminary Review");
            iDescription.Add("Issued for Second Preliminary Review");
            iDescription.Add("Issued for Third Preliminary Review");
            iDescription.Add("Issued for Fourth Preliminary Review");
            iDescription.Add("Issued for Fifth Preliminary Review");
            iDescription.Add("Issued for Preliminary Field Measurements");
            iDescription.Add("Issued for Fabrication");
            cbDescription.DataSource = iDescription;
        }

        private void checkUser()
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            //MessageBox.Show(userName);

            if (userName == @"ALLNEWGLASS\rhale")
            {
                button1.Visible = true;
            }

            if (userName == @"ALLNEWGLASS\rhale" || userName == @"ALLNEWGLASS\nkucukovic")
            {
                btnDelete.Visible = true;
            }
        }

        private void btnDoStuff_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(conn);
            //DataClasses1DataContext dc = new DataClasses1DataContext();
            //BindingSource bindingSource1 = new BindingSource();
            try
            {
                // search all
                // working
                var query = from pc in dc.ProjectChanges
                                //where (pc.ProjectName.Contains(tbProjectName.Text ?? string.Empty) ||
                                //pc.ProjectNumber.Contains(tbProjectNumber.Text ?? string.Empty))
                                //select pc;
                            where pc.ProjectNumber.Contains(tbProjectNumber.Text ?? string.Empty) &&
                                    pc.ProjectName.Contains(tbProjectName.Text ?? string.Empty) &&
                                    pc.SubProject.Contains(tbSubProject.Text ?? string.Empty) &&
                                    pc.ChangeType.Contains(cbChangeType.Text ?? string.Empty) &&
                                    pc.ChangeDescription.Contains(cbDescription.Text ?? string.Empty) &&
                                    pc.Comments.Contains(tbComments.Text ?? string.Empty) //&&
                                                                                          //pc.Archive.Contains(tbArchive.Text ?? string.Empty)
                                                                                          //pc.ChangeType.Contains(cbChangeType.Text ? != null : string.Empty)
                            select pc;

                // expermiental
                //var query = from pc in dc.ProjectChanges
                //                //where (pc.ProjectName.Contains(tbProjectName.Text ?? string.Empty) ||
                //                //pc.ProjectNumber.Contains(tbProjectNumber.Text ?? string.Empty))
                //                //select pc;
                //            where pc.ProjectNumber.Contains(tbProjectNumber.Text ?? string.Empty) &&
                //                    //pc.ProjectName.Contains(tbProjectName.Text ?? string.Empty) //&&
                //                    // longer way of saying same thing...
                //                    pc.ProjectName.Contains(tbProjectName.Text != null ? tbProjectName.Text : string.Empty) &&
                //                    pc.SubProject.Contains(tbSubProject.Text ?? null) //&&
                //                    //pc.ChangeType.Contains(cbChangeType.Text ?? string.Empty) &&
                //                    //pc.ChangeDescription.Contains(cbDescription.Text ?? string.Empty) &&
                //                    //pc.Comments.Contains(tbComments.Text ?? string.Empty) //&&
                //                    //pc.Archive.Contains(tbArchive.Text ?? string.Empty)
                //                    //pc.ChangeType.Contains(cbChangeType.Text ? != null : string.Empty)
                //            select pc;



                //foreach (var item in query)
                //{
                //    MessageBox.Show(item.ProjectName + item.ProjectNumber);

                //    tbId.Text = item.Id.ToString();
                //    tbProjectNumber.Text = item.ProjectNumber.ToString();
                //    tbProjectName.Text = item.ProjectName.ToString();
                //    tbDate.Text = item.Date.ToString();
                //    tbDrafter.Text = item.Drafter.ToString();
                //    tbInitiatedBy.Text = item.InitiatedBy.ToString();
                //    tbChangeType.Text = item.ChangeType.ToString();
                //    tbCurrentVersion.Text = item.CurrentVersion.ToString();
                //    tbDescription.Text = item.Description.ToString();
                //    tbNewVersion.Text = item.NewVersion.ToString();
                //    tbComments.Text = item.Comments.ToString();
                //}

                // auto fit column widths
                dataGridView1.DataSource = query;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                lblRecordCount.Text = dataGridView1.Rows.Count.ToString() + " Records Found";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to connect", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string cadFileName = GetCadFileName();
                tbCadFile.Text = cadFileName;
                string newFilePath = ArchiveFile(cadFileName);

                DataClasses1DataContext dc = new DataClasses1DataContext(conn);
                ProjectChange pc = new ProjectChange();

                pc.Id = Guid.NewGuid().ToString();
                pc.ProjectNumber = tbProjectNumber.Text;
                pc.ProjectName = tbProjectName.Text;
                pc.SubProject = tbSubProject.Text;
                //pc.Date = Convert.ToDateTime(tbDate.Text);
                pc.ProjectDate = Convert.ToDateTime(dtpData.Text);
                pc.Drafter = cbDrafter.Text;
                pc.InitiatedBy = cbInitiatedBy.Text;
                pc.ChangeType = cbChangeType.Text;
                pc.OldVersion = tbOldVersion.Text;
                pc.ChangeDescription = cbDescription.Text;
                pc.NewVersion = tbNewVersion.Text;
                pc.Comments = tbComments.Text;
                pc.CadFile = cadFileName;
                pc.Archive = newFilePath;

                //Adds an entity in a pending insert state to this System.Data.Linq.Table<TEntity>and parameter is the entity which to be added  
                dc.ProjectChanges.InsertOnSubmit(pc);
                // executes the appropriate commands to implement the changes to the database 
                dc.SubmitChanges();



                string recordName = getRecordName();
                sendEmail(recordName, pc.Drafter, pc.ProjectNumber, pc.ProjectName, pc.SubProject, pc.Comments, cadFileName);

                UpdateGridView();
                ClearForm();
                MessageBox.Show("Record Inserted.", "Success");
            }
            catch (Exception)
            {
                MessageBox.Show("Failure to connect to database. Please verify SQL Server is running or contact system administrator.");
            }
           }

        private void UpdateGridView()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(conn);
            try
            {
                var query = from pc in dc.ProjectChanges
                            where pc.ProjectNumber.Contains(tbProjectNumber.Text ?? string.Empty) 
                            select pc;

                dataGridView1.DataSource = query;

                lblRecordCount.Text = dataGridView1.Rows.Count.ToString() + " Records Found";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to connect", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private string GetCadFileName()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Please select the CAD file that was updated.";
            //ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.RestoreDirectory = true;

            string _cadFileName = string.Empty;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _cadFileName = ofd.FileName;
                    //Get the path of specified file
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to recognize CAD filename.");
                }
            }
                    return _cadFileName;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DataClasses1DataContext dcContext = new DataClasses1DataContext(conn);
                //Get Single record which we need to update  
                ProjectChange pc = dcContext.ProjectChanges.Single(r => r.Id == tbId.Text);

                //pc.Id = Guid.NewGuid().ToString();
                pc.ProjectNumber = tbProjectNumber.Text;
                pc.ProjectName = tbProjectName.Text;
                pc.SubProject = tbSubProject.Text;
                //pc.Date = Convert.ToDateTime(tbDate.Text);
                pc.ProjectDate = Convert.ToDateTime(dtpData.Text);
                pc.Drafter = cbDrafter.Text;
                pc.InitiatedBy = cbInitiatedBy.Text;
                pc.ChangeType = cbChangeType.Text;
                pc.OldVersion = tbOldVersion.Text;
                pc.ChangeDescription = cbDescription.Text;
                pc.NewVersion = tbNewVersion.Text;
                pc.Comments = tbComments.Text;
                pc.CadFile = tbCadFile.Text;
                pc.Archive = tbArchive.Text;

                dcContext.SubmitChanges();
                MessageBox.Show("Record Updated.", "Success");

                UpdateGridView();
                ClearForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Record Id must be populated in Id text box.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (DataClasses1DataContext dataContext = new DataClasses1DataContext(conn))
                {
                    ProjectChange projectChange = dataContext.ProjectChanges.SingleOrDefault(x => x.Id == tbId.Text);
                    dataContext.ProjectChanges.DeleteOnSubmit(projectChange);
                    dataContext.SubmitChanges();

                    dataContext.SubmitChanges();
                    MessageBox.Show("Record Deleted.", "Success");

                    UpdateGridView();
                    ClearForm();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Record Id must be populated in Id text box.");
            }
        }

        public void InsertRando()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(conn);
            ProjectChange pc = new ProjectChange();
            pc.Id = Guid.NewGuid().ToString();
            pc.ProjectNumber = tbProjectNumber.Text;
            pc.ProjectName = tbProjectName.Text;
            pc.SubProject = tbSubProject.Text;
            //pc.Date = Convert.ToDateTime(tbDate.Text);
            pc.ProjectDate = Convert.ToDateTime(dtpData.Text);
            pc.Drafter = cbDrafter.Text;
            pc.InitiatedBy = cbInitiatedBy.Text;
            pc.ChangeType = cbChangeType.Text;
            pc.OldVersion = tbOldVersion.Text;
            pc.ChangeDescription = cbDescription.Text;
            pc.NewVersion = tbNewVersion.Text;
            pc.Comments = tbComments.Text;
            pc.Archive = tbArchive.Text;

            //Adds an entity in a pending insert state to this System.Data.Linq.Table<TEntity>and parameter is the entity which to be added  
            dc.ProjectChanges.InsertOnSubmit(pc);
            // executes the appropriate commands to implement the changes to the database 
            dc.SubmitChanges();

            // archive the file and name it per the random values
            var oldFilePath = string.Empty;
            var newFilePath = string.Empty;

            string projectNumber = tbProjectNumber.Text;
            string projectName = tbProjectName.Text;
            string subProject = tbSubProject.Text;
            string newVersion = tbNewVersion.Text;
            string projectDescription = cbDescription.SelectedItem.ToString();
            string projectDate = dtpData.Value.Date.ToString("yyyyMMdd");
            string archiveFileName = string.Empty;

            // check if the version is greater than 0
            var isNumeric = int.TryParse(tbNewVersion.Text, out int n);
            if (n > 0)
            {
                archiveFileName = $@"{projectNumber} {projectName} {subProject} Rev {newVersion} - {projectDescription} - Revision {projectDate}";
            }
            else
            {
                archiveFileName = $@"{projectNumber} {projectName} {subProject} Rev {newVersion} - {projectDescription} {projectDate}";
            }

            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                //Get the path of specified file
                // hard coded
                //oldFilePath = @"C:\Users\Robert\Desktop\squid.pdf";
                oldFilePath = $@"{path}\squid.pdf";

                // works for ABF P Drive - commented out for development
                newFilePath = $@"P:\A&B\Projects\Archive\{archiveFileName}.pdf";
                //newFilePath = $@"C:\Users\Robert\Desktop\squid\{archiveFileName}.pdf";

                //Copy and rename the file into the Archive Directory
                //works
                //File.Copy(filePath, @"P:\A&B\Projects\Squid\Archive\My1234.pdf");
                File.Copy(oldFilePath, newFilePath);
                tbArchive.Text = newFilePath;
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to copy to Archive location.");
            }

            //////
            ///
            MessageBox.Show("Done!");
        }

        public void RandomInsert()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1712, "2 & U");
            dict.Add(1719, "Two Union Square");
            dict.Add(1800, "Vulcan Block Buildings");
            dict.Add(1808, "Dexter333 Art Door");
            dict.Add(1809, "VMC Pavilion Nesser");
            dict.Add(1813, "ExpediaABCD");
            dict.Add(1814, "Block 21 GLY");
            dict.Add(1815, "Block 20TI");
            dict.Add(1816, "Vance Building Upgrades");
            dict.Add(1818, "Block 31 TI GLY");
            dict.Add(1819, "Building cure");
            dict.Add(1825, "Washington State Convention Center");
            dict.Add(1826, "Fed Res");
            dict.Add(1827, "Block 25 East & West TI GLY");
            dict.Add(1828, "Nexus");
            dict.Add(1829, "UTC Northway");
            dict.Add(1830, "KCCFJC Howard S Wright");
            dict.Add(1831, "Watershed Turner");
            dict.Add(1832, "Bellevue College HSW");
            dict.Add(1901, "HST 925 WeWork");
            dict.Add(1904, "Spring Street JTM");
            dict.Add(1907, "HST 1201 WEWork");
            dict.Add(1909, "U - Village ANG");
            dict.Add(1910, "10885 WeWork Bellevue");
            dict.Add(1912, "Google Jayhawk");
            dict.Add(1913, "UW Bagley Hall Remodel GLY");
            dict.Add(1914, "Block 57 East Terrace Guardrail");
            dict.Add(2181, "9 Mantel_Huang");
            dict.Add(21821, "Brake_ComOffice");
            dict.Add(16000, "Example VS ABF_Projects.Add(CA)");
            dict.Add(1820, "Expedia K");
            dict.Add(1823, "Expedia Collab Structures");
            dict.Add(1906, "Expedia Site rails");
            dict.Add(21810, "Kidder Mathews");

            Random rnd = new Random();
            string[] abPetNames = { "Erin", "Nadia", "Robert", "Alberto", "Nate", "Stephen", "Austin" };
            string[] abPetNames2 = { "Nadia", "Robert", "Alberto", "Nate", "Stephen", "Austin", "Erin" };

            string[] abChangeType = { "Initial Design", "Arch. Marks", "Engineer Marks", "Internal Review", "Cross Check" };

            string[] abVersion = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "0", "1", "2", "3", "4" };
            string[] abVersion2 = { "B", "C", "D", "E", "F", "G", "H", "I", "0", "1", "2", "3", "4", "5" };

            string[] abDescription = { "Issued for First Preliminary Review", "Issued for Second Preliminary Review", "Issued for Third Preliminary Review", "Issued for Fourth Preliminary Review",
                "Issued for Fifth Preliminary Review", "Issued for Preliminary Field Measurements", "Issued for Fabrication"};

            string[] abComments = { "Architect changed mind", "Engineer changed design", "Architect does not understand", "Costs too much money",
                "Original design was changed", "Shop cannot fabricate", "The upstairs refrigerator stinks", "Fabricated Incorrectly", "Installed Incorrectly", "Field measurments incorrect",
                "Advance Steel part drawings were not understood", "Architect wanted 3d model"};

            string[] abSubProject = { "Blackened Moat", "Gate G1", "Wall W18", "Wall W25", "2nd Level Stairs", "3rd Level Stairs", "4th Level Stairs",
                "Vehicular Access Gate", "Pedestrian Access Gate", "Wall W11", "Handrail at Mezzanine", "Glass guardrail", "Guardrail", "Water Feature Bridge",
                "FE3 Wood Post Fence", "FE9 Steel Panel Fence", "FE7 Wood Post Fence", "Planter Boxes"};

            foreach (KeyValuePair<int, string> item in dict)
            {
                tbProjectName.Text = item.Value;
                tbProjectNumber.Text = item.Key.ToString();
                //tbDate.Text = "2019/06/19";
                dtpData.Text = dtpData.Text;

                int petIndex = rnd.Next(abPetNames.Length);
                cbDrafter.Text = abPetNames[petIndex];

                int chTypeIndex = rnd.Next(abChangeType.Length);
                cbChangeType.Text = abChangeType[chTypeIndex];

                int changeIndex = rnd.Next(abPetNames2.Length);
                cbInitiatedBy.Text = abPetNames2[petIndex];

                int versionIndex = rnd.Next(abVersion.Length);
                tbOldVersion.Text = abVersion[versionIndex];

                int versionIndex2 = rnd.Next(abVersion2.Length);
                tbNewVersion.Text = abVersion2[versionIndex];

                int descIndex = rnd.Next(abPetNames.Length);
                cbDescription.Text = abDescription[descIndex];

                int commIndex = rnd.Next(abPetNames.Length);
                tbComments.Text = abComments[commIndex];

                int subProjectIndex = rnd.Next(abPetNames.Length);
                tbSubProject.Text = abSubProject[subProjectIndex];

                InsertRando();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RandomInsert();
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //gets a collection that contains all the rows
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            //populate the textbox from specific value of the coordinates of column and row.
            tbId.Text = row.Cells[0].Value.ToString();
            tbProjectNumber.Text = row.Cells[1].Value.ToString();
            tbProjectName.Text = row.Cells[2].Value.ToString();
            tbSubProject.Text = row.Cells[3].Value.ToString();
            dtpData.Text = row.Cells[4].Value.ToString();
            cbDrafter.Text = row.Cells[5].Value.ToString();
            //tbInitiatedBy.Text = row.Cells[5].Value.ToString();
            cbInitiatedBy.Text = row.Cells[6].Value.ToString();
            cbChangeType.Text = row.Cells[7].Value.ToString();
            cbDescription.Text = row.Cells[8].Value.ToString();
            tbNewVersion.Text = row.Cells[9].Value.ToString();
            tbOldVersion.Text = row.Cells[10].Value.ToString();
            tbComments.Text = row.Cells[11].Value.ToString();
            tbCadFile.Text = row.Cells[12].Value.ToString();
            // ternary conditional to check if the value is null - may have to math this condition on the other values
            // tbArchive.Text = row.Cells[12].Value.ToString();
            tbArchive.Text = row.Cells[13].Value == null ? string.Empty : row.Cells[13].Value.ToString();



            // conditional for tbArchive
            // below works if value is not null otherwis throws error
            // tbArchive.Text = row.Cells[12].Value.ToString();
            //string archiveLocation = row.Cells[12].Value.ToString();
            //if (DBNull.Value.Equals(row.Cells[12].Value.ToString()))
            //{
            //    tbArchive.Text = "null";
            //}
            //else
            //{
            //    tbArchive.Text = row.Cells[12].Value.ToString();
            //}

            //if (row.Cells[12].Value == DBNull.Value)
            //{
            //    tbArchive.Text = "null";
            //}
            //else
            //{
            //    tbArchive.Text = tbArchive.Text = row.Cells[12].Value.ToString();
            //}

            //tbArchive.Text =  ?? row.Cells[12].Value.ToString() : null;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            tbId.Clear();
            tbProjectNumber.Clear();
            tbProjectName.Clear();
            tbSubProject.Clear();
            //dtpData.CustomFormat = " ";
            //dtpData.Format = DateTimePickerFormat.Custom;
            dtpData.ResetText();
            //cbDrafter.SelectedIndex = -1;
            cbDrafter.Text = string.Empty;
            //cbInitiatedBy.SelectedIndex = -1;
            cbInitiatedBy.Text = string.Empty;
            //cbChangeType.SelectedIndex = -1;
            cbChangeType.Text = string.Empty;
            tbOldVersion.Clear();
            cbDescription.Text = string.Empty;
            tbNewVersion.Clear();
            tbComments.Clear();
            tbCadFile.Clear();
            tbArchive.Clear();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutbox = new AboutBox1();
            aboutbox.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();

            var headers = dataGridView1.Columns.Cast<DataGridViewColumn>();
            sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var cells = row.Cells.Cast<DataGridViewCell>();
                sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (StreamWriter sw = new StreamWriter($@"{path}\ABF_ProjectChangeReport.csv"))
            {
                sw.Write(sb);
            }

            MessageBox.Show($@"File written  to {path}\ABF_ProjectChangeReport.csv");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                var filePath = tbArchive.Text;
                // works
                //System.Diagnostics.Process.Start(@"P:\A&B\Projects\Squid\Archive\1906 Expedia W18 Rev A - Issued for First Preliminary Review 20190710.pdf");
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot find the file requested. Please verify that the file exists.");
            }
        }

        private string ArchiveFile(string cadFileName)
        {
            var oldFilePath = string.Empty;
            var newFilePath = string.Empty;

            string archiveFileName = getRecordName();

            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //ofd.Title = "Please Select File to be Archived.";
            //ofd.ShowDialog();

            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
                try
                {

                    //Get the path of specified file
                    //oldFilePath = ofd.FileName;
                    oldFilePath = cadFileName;
                    string oldFileExtension = Path.GetExtension(oldFilePath);
                    // works for ABF - Commented out for development
                    newFilePath = $@"P:\A&B\Projects\Archive\{archiveFileName}{oldFileExtension}";
                    // dev only
                    //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    //newFilePath = $@"{path}\Squid\{archiveFileName}{oldFileExtension}";

                    //Copy and rename the file into the Archive Directory
                    //works
                    //File.Copy(filePath, @"P:\A&B\Projects\Squid\Archive\My1234.pdf");
                    tbArchive.Text = newFilePath;
                    File.Copy(oldFilePath, newFilePath);
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to copy to Archive location.");
                }

                return newFilePath;

                //try
                //{
                //    DataClasses1DataContext dcContext = new DataClasses1DataContext(conn);
                //    //Get Single record which we need to update  
                //    ProjectChange pc = dcContext.ProjectChanges.Single(r => r.Id == tbId.Text);

                //    //pc.Id = Guid.NewGuid().ToString();
                //    pc.ProjectNumber = tbProjectNumber.Text;
                //    pc.ProjectName = tbProjectName.Text;
                //    //pc.Date = Convert.ToDateTime(tbDate.Text);
                //    pc.ProjectDate = Convert.ToDateTime(dtpData.Text);
                //    pc.Drafter = cbDrafter.Text;
                //    pc.InitiatedBy = cbInitiatedBy.Text;
                //    pc.ChangeType = cbChangeType.Text;
                //    pc.OldVersion = tbOldVersion.Text;
                //    pc.ChangeDescription = cbDescription.Text;
                //    pc.NewVersion = tbNewVersion.Text;
                //    pc.Comments = tbComments.Text;
                //    pc.Archive = tbArchive.Text;

                //    dcContext.SubmitChanges();
                //    //MessageBox.Show("Record Updated.", "Success");
                //}
                //catch (Exception)
                //{
                //    MessageBox.Show("Record Id must be populated in Id text box.");
                //}
            //}
        }

        private string getRecordName()
        {
            string projectNumber = tbProjectNumber.Text;
            string projectName = tbProjectName.Text;
            string subProject = tbSubProject.Text;
            string newVersion = tbNewVersion.Text;
            //string projectDescription = cbDescription.SelectedItem.ToString();
            string projectDescription = cbDescription.Text;
            string projectDate = dtpData.Value.Date.ToString("yyyyMMdd");
            string archiveFileName = string.Empty;

            // check if the version is greater than 0
            var isNumeric = int.TryParse(tbNewVersion.Text, out int n);
            if (n > 0)
            {
                archiveFileName = $@"{projectNumber} {projectName} {subProject} Rev {newVersion} - {projectDescription} - Revision {projectDate}";
            }
            else
            {
                archiveFileName = $@"{projectNumber} {projectName} {subProject} Rev {newVersion} - {projectDescription} {projectDate}";
            }

            return archiveFileName;

        }

        // need to add reference Microsoft.Office.Interop.Outlook - its on the COM tab
        private void sendEmail(string recordName, string Drafter, string ProjectNumber, string ProjectName, string SubProject, string comments, string cadFileName)
        {
            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook.MailItem mailItem = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
            mailItem.Subject = $"Drawing Updated: {ProjectNumber} - {ProjectName} - {SubProject}";
            mailItem.To = "NadiaK@abfabricators.com";
            mailItem.Body = $"Drafter {Drafter} has updated CAD File at this location: {cadFileName}.{Environment.NewLine}" +
                            $"{Environment.NewLine}" +
                            $"Note:{Environment.NewLine}" +
                            $"{comments}";
            //mailItem.Attachments.Add(logPath);//logPath is a string holding path to the log.txt file

            try
            {
                mailItem.Display(true); //THIS IS THE CHANGE;
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot create Outlook email object, perhaps Outlook object is open?");
            }
        }

        private void sendEmail(string recordName, string Drafter, string ProjectNumber, string ProjectName, string SubProject)
        {
            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook.MailItem mailItem = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
            mailItem.Subject = $"{ProjectNumber} - {ProjectName} - {SubProject} : Drawing Change Requested";
            mailItem.To = "NadiaK@abfabricators.com";
            mailItem.Body = $"Hi {Drafter}, {Environment.NewLine}" +
                            $"{Environment.NewLine}" +
                            $"Please update the drawing with the following edits..." +
                            $"{Environment.NewLine}";
            //mailItem.Attachments.Add(logPath);//logPath is a string holding path to the log.txt file

            try
            {
                mailItem.Display(true); //THIS IS THE CHANGE;
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot create Outlook email object, perhaps Outlook object is open?");
            }
        }

        private void BtnChangeRequest_Click(object sender, EventArgs e)
        {
            try
            {
                //string cadFileName = GetCadFileName();
                //tbCadFile.Text = cadFileName;
                //string newFilePath = ArchiveFile(cadFileName);

                DataClasses1DataContext dc = new DataClasses1DataContext(conn);
                ProjectChange pc = new ProjectChange();

                pc.Id = Guid.NewGuid().ToString();
                pc.ProjectNumber = tbProjectNumber.Text;
                pc.ProjectName = tbProjectName.Text;
                pc.SubProject = tbSubProject.Text;
                //pc.Date = Convert.ToDateTime(tbDate.Text);
                pc.ProjectDate = Convert.ToDateTime(dtpData.Text);
                pc.Drafter = cbDrafter.Text;
                pc.InitiatedBy = cbInitiatedBy.Text;
                pc.ChangeType = cbChangeType.Text;
                pc.OldVersion = tbOldVersion.Text;
                pc.ChangeDescription = cbDescription.Text;
                pc.NewVersion = tbNewVersion.Text;
                pc.Comments = tbComments.Text;
                //pc.CadFile = cadFileName;
                //pc.Archive = newFilePath;
                               
                string recordName = getRecordName();
                sendEmail(recordName, pc.Drafter, pc.ProjectNumber, pc.ProjectName, pc.SubProject);
            }
            catch (Exception)
            {
                MessageBox.Show("Failure to connect to database. Please verify SQL Server is running or contact system administrator.");
            }
        }
    }
}
