using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BussinessLayer;

namespace BookStoreApp.UserForms
{
    public partial class HomeFrm : Form
    {
        private FlowLayoutPanel flowLayoutPanel; // Declare FlowLayoutPanel

        public HomeFrm()
        {
            InitializeComponent();
        }

        private void InitializeFlowLayoutPanel()
        {
            flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight // Adjust the direction if needed
            };
            this.Controls.Add(flowLayoutPanel);
        }

        private void LoadBooks()
        {
            DataTable booksTable = clsBooks.GetAllBooks(); // Fetch data

            if (booksTable == null || booksTable.Rows.Count == 0)
            {
                MessageBox.Show("No books found or error in fetching data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataRow row in booksTable.Rows)
            {
                // Extract book information
                string bookId = row["BookID"].ToString();
                string title = row["Title"].ToString();
                string imagePath = row["ImagePath"].ToString(); // Ensure this path is valid

                // Create a Panel for each book
                Panel bookPanel = new Panel
                {
                    Width = 150,
                    Height = 250,
                    Margin = new Padding(10),
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Create PictureBox for the book image
                PictureBox pictureBox = new PictureBox
                {
                    Image = LoadImage(imagePath), // Call the LoadImage function
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = 140,
                    Height = 140,
                    Top = 10,
                    Left = 5
                };

                // Create Label for the book title
                Label titleLabel = new Label
                {
                    Text = title,
                    AutoSize = true,
                    Top = 160,
                    Left = 5,
                    Width = 140,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                // Create Button for book details
                Button detailsButton = new Button
                {
                    Text = "View Details",
                    Top = 200,
                    Left = 35,
                    Width = 80,
                    Tag = bookId // Use Tag to store the book ID for reference in the click event
                };
                detailsButton.Click += DetailsButton_Click;

                // Add controls to the panel
                bookPanel.Controls.Add(pictureBox);
                bookPanel.Controls.Add(titleLabel);
                bookPanel.Controls.Add(detailsButton);

                // Add panel to the FlowLayoutPanel
                flowLayoutPanel.Controls.Add(bookPanel);
            }
        }

        private Image LoadImage(string path)
        {
            try
            {
                return Image.FromFile(path);
            }
            catch (Exception ex)
            {
                // Handle image loading errors (e.g., file not found, invalid path)
                Console.WriteLine($"Error loading image: {ex.Message}");
                return Image.FromFile("F:\\learn c#\\assets\\bookstore assets\\error.png"); // Use a default image from your resources
            }
        }

        private void DetailsButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string bookId = button.Tag.ToString();
                ShowBookDetails(bookId);
            }
        }

        private void ShowBookDetails(string bookId)
        {
            // Implement the logic to show book details here.
            // You might want to open a new form or display a message box.
            MessageBox.Show($"Showing details for Book ID: {bookId}", "Book Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void HomeFrm_Load(object sender, EventArgs e)
        {
            InitializeFlowLayoutPanel();
            LoadBooks();
        }
    }
}
